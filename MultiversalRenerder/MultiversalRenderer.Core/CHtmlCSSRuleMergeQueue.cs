using System;
using System.Collections;
using System.Text;
using MultiversalRenderer.Interfaces;

namespace MultiversalRenderer.Core
{
    /// <summary>
    /// CHtmlCSSRuleMergeQueue stores StyleElement in queue and dispatch to list
    /// [Note]
    /// This class has been Generic.List of StyleElement but there is a bug on .net, if we use generic list, comparer throws exception 
    /// frequently
    /// 
    /// [Exception Message]
    /// System.ArgumentException: Offset and length were out of bounds for the array or count is greater than 
    /// the number of elements from index to the end of the source collection.
     ///  at System.Array.BinarySearch[T](T[] array, Int32 index, Int32 length, T value, IComparer`1 comparer)
     /// 
     /// [Cause]
     /// .NET framework 2.0-4.5 has Generic Comparer Bug which is hard to work around. 
     /// 
     /// [WorkAround]
     /// We decide convert this class back to ArrayList. It seems to be stable more. 
     /// Do NOT CHANGE this class to Generic List!!!!
     /// 
     /// Note 2)
    /// PerformStyleGroudMeargeToGroundList() is nomally called with one thread (not multi-thread).
    /// So, unlike putting into queue, PerformStyleGroudMeargeToGroundList() nommay does not require to use lock.
     /// This 
    /// </summary>
    public sealed class CHtmlCSSRuleMergeQueue : System.Collections.ArrayList, System.IDisposable
    {
        private System.Threading.Thread ___QueueThread;
        internal System.Threading.AutoResetEvent ___StyleEvent;
        private readonly object ___AddToQueueLockingObject = new object();
        public bool Disposing;
        public bool IsAllCSSComplete;
        public bool ___needsExitFunctionIfQueueZero;
        private int MergedCount;
        private int EnqueuedCount;
        public CHtmlDocument ___parentDocument;
        private System.WeakReference ___documentReference;
        public string ShortName = null;
        private const int MAX_WAIT = 5000;
        private CHtmlCSSRuleGroundKeyNonGenericComparer _GroundStyleSheetNonGenericSorter;
        private bool IsMergeFunctionEntered;
        private uint ___MeargedOrRemovedStyleCount;
        /// <summary>
        /// How may this Style Thread Waited on long period of time
        /// </summary>
        private uint ___StyleLongWaitOneCount;
        /// <summary>
        /// How may this Style Thread Waited on short period of time
        /// </summary>
        private uint ___StyleShortWaitOneCount;
        private readonly object ___MergeLockingObject = new object();
        public CHtmlCSSRuleMergeQueue()
        {
            this.___StyleEvent = new System.Threading.AutoResetEvent(false);
            _GroundStyleSheetNonGenericSorter = new CHtmlCSSRuleGroundKeyNonGenericComparer();
        }
        ~CHtmlCSSRuleMergeQueue()
        {
            this.Disposing = true;
            this.CleanUp();
        }
        private void CleanUp()
        {
            try
            {
                if (this.___StyleEvent != null)
                {
                    this.___StyleEvent.Close();
                    commonData.DisposeObject(this.___StyleEvent);
                    this.___StyleEvent = null;
                }
                if (this.___QueueThread != null)
                {
                    this.___QueueThread.Abort();
                }
            }
            finally
            {
            }
        }
        public void Dispose()
        {
            this.Disposing = true;
            this.CleanUp();
        }
        private int ___StyleStatus = -1;
        public void  Add(CHtmlCSSRule value)
        {
#if DEBUG
            if (string.IsNullOrEmpty(value.___baseUrl) == true)
            {
                commonLog.LogEntry("CHtmlCSSStyleSheet Add Style does not have baseURL. but cont : {0}...", value.___SelectorID);
            }
#endif
            if (System.Threading.Monitor.TryEnter(this.___AddToQueueLockingObject, MAX_WAIT))
            {
                try
                {
                    base.Add(value);
                    System.Threading.Interlocked.Increment(ref this.EnqueuedCount);

                }
                catch (Exception ex)
                {
                    if (commonLog.LoggingEnabled)
                    {
                        commonLog.LogEntry("StyleQueue Add Exception", ex);
                    }
                }
                finally
                {
                    System.Threading.Monitor.Exit(this.___AddToQueueLockingObject);
                }
            }
            else
            {
                if (commonLog.LoggingEnabled)
                {
                    commonLog.LogEntry("Uhhh. CHtmlCSSRuleMergeQueue failed to obtain lock.");
                }
            }
            if (___StyleEvent != null)
            {
                this.___StyleEvent.Set();
            }
            if (this.IsAllCSSComplete == true)
            {
                if (this.IsMergeFunctionEntered == false)
                {
                    if (___StyleStatus == 0)
                    {
                        if (commonLog.LoggingEnabled &&commonLog.LogLevel > 100)
                        {
                            ___StyleStatus++;
                            commonLog.LogEntry("Style will be must be mearged as JIT afterword.");
                        }
                    }
                    if (!___needsExitFunctionIfQueueZero)
                    {
                        ___needsExitFunctionIfQueueZero = true;
                    }

                    this.PerformStyleGroudMeargeToGroundList();
                }

            }
            return;
        }
        internal int counterPerformStyleGroudMeargeToGroundListEnterd;
        public void InitalizeMeargeThread()
        {
            if (this.___QueueThread == null)
            {
                System.Threading.ThreadStart st = new System.Threading.ThreadStart(this.PerformStyleGroudMeargeToGroundList);
                this.___QueueThread = new System.Threading.Thread(st);
                this.___QueueThread.IsBackground = true;
                this.___QueueThread.ApartmentState = System.Threading.ApartmentState.MTA;
                this.___QueueThread.Name = "StyleMeargeThreadFor" + this.ShortName;
                this.___QueueThread.Start();
                if (commonLog.LoggingEnabled &&commonLog.LogLevel > 1)
                {
                   commonLog.LogEntry(this.___QueueThread.Name + " has started");
                }
            }
        }
        public void CompleteMergeProcess()
        {
            this.IsAllCSSComplete = true;
            if (this.___StyleEvent != null)
            {
                this.___StyleEvent.Set();
            }
            if (commonLog.LoggingEnabled &&commonLog.LogLevel > 1)
            {
                if (this.Count > 0)
                {
                   commonLog.LogEntry("StyleMerge still leave {0} items to mearge...", this.Count);
                }
            }
        }
        private string ConvertStyleUrlIntoFullUrl(string _cssUrl,string ___baseUrl, string _partUri, int _mode)
        {
            if (commonLog.LoggingEnabled && commonLog.LogLevel >= 10)
            {
                commonLog.LogEntry("Need to convert partial url to full url: {0} mode: {1} css: {2}", _partUri, _mode, _cssUrl);
            }
            switch (_mode)
            {
                case 0: // Segment
                    return _partUri;
                default:
                case 1:
                    return commonHTML.GetAbsoluteUri(_cssUrl, "", _partUri);

            }
        }
        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.Synchronized)]
        internal void PerformStyleGroudMeargeToGroundList()
        {
            DateTime dtPerformStyleGroudMeargeToGroundList = DateTime.Now;
            this.IsMergeFunctionEntered = true;
            counterPerformStyleGroudMeargeToGroundListEnterd++;

            try
            {
                if (this.___parentDocument != null && this.___documentReference == null)
                {
                    this.___documentReference = new WeakReference(this.___parentDocument, false);
                }

                if (this.___parentDocument == null)
                {
                    // it may be completed
                    if (this.___documentReference != null)
                    {
                        this.___parentDocument = this.___documentReference.Target as CHtmlDocument;
                    }
                    if (this.___parentDocument == null)
                    {
                        this.IsMergeFunctionEntered = false;
                        return;
                    }
                }
                // ====================================================
                //  We do want merge data quickly, DisabledList Check is not done. It will check at element 
                // style collection stage only
                // ====================================================
                //System.Collections.Generic.Dictionary<string, string> ___LinkBadList = this.___parentDocument.___LinkDisabledHerfList;
                System.Collections.Generic.Dictionary<string, ushort> ___CSSAttributeLookupFieldList = this.___parentDocument.___CSSAttributeLookupFieldList;
                System.Collections.Generic.Dictionary<string,ushort> ___CSSNthOfTypeTagTypesList    = this.___parentDocument.___CSSNthOfTypeTagTypesList;
                CHtmlCSSRuleGroundList ____DocumentStylesheetGroundList = this.___parentDocument.___cssRuleGroundList;
                string ___DocumentURL = string.Copy(this.___parentDocument.___URL);
                string ___DocumentBaseUrl = null;
                if (string.IsNullOrEmpty(this.___parentDocument.___baseUrl) == false)
                {
                    ___DocumentBaseUrl = string.Copy(this.___parentDocument.___baseUrl);
                }

                CHtmlDocument ___targetDocument = this.___parentDocument;
                int posInsert;
                while (true)
                {

                    int ___CurrentCount = base.Count;
                    if (___CurrentCount == 0)
                    {
                        if (this.___needsExitFunctionIfQueueZero == true)
                        {
                            goto CompletePhase;
                        }
                        if (___needsExitFunctionIfQueueZero == false && ___targetDocument != null && ___targetDocument.___isStyleQueueShouldBeStopedAfterBodyTag == true)
                        {
                            goto CompletePhase;
                        }
                        if (this.___StyleEvent != null)
                        {
                            if (this.___MeargedOrRemovedStyleCount == 0)
                            {
                                this.___StyleEvent.WaitOne(3000, false);
                                this.___StyleLongWaitOneCount++;
                            }
                            else
                            {
                                this.___StyleEvent.WaitOne(1000, false);
                                this.___StyleShortWaitOneCount++;
                            }
                        }

                        if (this.___needsExitFunctionIfQueueZero || this.Disposing || ___targetDocument == null || (___targetDocument != null && (___targetDocument.___readyStateType == CHtmlReadytStateType.complete || ___targetDocument.___IsThreadAbortOccurred == true || ___targetDocument.___IsThreadAbortOccurred == true || ___targetDocument.___IsDisposing)))
                        {
                            
                            goto CompletePhase;

                        }
                        
                    }
                    else
                    {
                        CHtmlCSSRule sPart = null;
                        try
                        {
                            sPart = base[0] as CHtmlCSSRule;
                            if (sPart == null)
                            {
                                goto RemoveListPhase;

                            }
                            /*
                            if (___LinkBadList != null && ___LinkBadList.Count != 0)
                            {
                                if (___LinkBadList.ContainsKey(sPart.___baseUrl) == true)
                                {
                                    if (___targetDocument.___cssRuleBlackList.Count < 1000)
                                    {
                                        ___targetDocument.___cssRuleBlackList.Add(sPart);
                                    }
                                    goto RemoveListPhase;
                                }
                            }
                            */

                            if (sPart.___CSSHack != CSSHackType.None || sPart.___NonSearchableStyleSheet == true)
                            {
                                if (sPart.___CSSHack == CSSHackType.None)
                                {
                                    switch (sPart.___ruleType)
                                    {
                                        case CHtmlCSSRule.CSSRuleType.Import_Rule:
                                            {
                                                if (string.IsNullOrEmpty(sPart.___baseUrl) == false)
                                                {

                                                    CHtmlElement ___cssTagRootElement = null;
                                                    if (sPart.___srcElementReference != null)
                                                    {
                                                        ___cssTagRootElement = sPart.___srcElementReference.Target as CHtmlElement;
                                                    }
                                                    bool __IsEnqueued = ___targetDocument.___downloadviaQueue(sPart.___baseUrl, "StyleSheet", "", "", "", "", CHtmlThreadPoolQueueObjectType.UrlStyleSheet, sPart.___baseUrl, ___cssTagRootElement, 0, CHtmlUrlSourceType.Unknown, false);
                                                    if (__IsEnqueued)
                                                    {
                                                        ___targetDocument.___IncrementDocumentDownloadCounter();
                                                    }
                                                }
                                            }
                                            break;
                                        default: break;
                                    }
                                }
                                if (___targetDocument.___cssRuleBlackList.Count < 1000)
                                {
                                    if (System.Threading.Monitor.TryEnter(___targetDocument.___cssRuleBlackList, 500))
                                    {
                                        try
                                        {
                                            ___targetDocument.___cssRuleBlackList.Add(sPart);
                                        }
                                        finally
                                        {
                                            System.Threading.Monitor.Exit(___targetDocument.___cssRuleBlackList);
                                        }
                                    }
                                }
                                goto RemoveListPhase;
                            }
   
                           

                            if (sPart.___AttributesBulkTitleList != null && sPart.___AttributesBulkTitleList.Count > 0)
                            {

                                foreach (string strAttributeKey in sPart.___AttributesBulkTitleList.Keys)
                                {
                                    if (___CSSAttributeLookupFieldList.ContainsKey(strAttributeKey) == false)
                                    {
                                        ___CSSAttributeLookupFieldList[strAttributeKey] = 1;
                                    }
                                }
                            }
                            
                            if (sPart.___ListNthOfTypeTagTypes.Count > 0)
                            {
                                // ___ListNthOfTypeTagTypes may contains other than TagTypes in future. objtain as object
                                foreach (string strNthOfTagType in sPart.___ListNthOfTypeTagTypes.Keys)
                                {

                                    if (strNthOfTagType == null)
                                        continue;
                                    // Comment) Checking Existance of key is 2% faster
                                    if (___CSSNthOfTypeTagTypesList.ContainsKey(strNthOfTagType) == false)
                                    {
                                        ___CSSNthOfTypeTagTypesList[strNthOfTagType] = 1;
                                    }
                                }
                            }
                            
                            try
                            {
                                if (counterPerformStyleGroudMeargeToGroundListEnterd > 1)
                                {
                                    if (System.Threading.Monitor.TryEnter(___MergeLockingObject, MAX_WAIT))
                                    {
                                        try
                                        {
                                            if (sPart.___PseudoClassType != CHtmlPseudoClassType.None)
                                            {
                                                ___targetDocument.___CSSDocumentTotalPseudoClass = ___targetDocument.___CSSDocumentTotalPseudoClass | sPart.___PseudoClassType;
                                            }
          
                                            posInsert = ____DocumentStylesheetGroundList.BinarySearch(sPart, this._GroundStyleSheetNonGenericSorter);
                                            if (posInsert < 0)
                                            {
                                                posInsert = ~posInsert;
                                            }
                                            ___MeargedOrRemovedStyleCount++; // it is dirty increment, but it is ok!
                                            ____DocumentStylesheetGroundList.Insert(posInsert, sPart);
                                            MergedCount++;
                                        }
                                        catch (Exception exInsert)
                                        {
                                            if (commonLog.LoggingEnabled && commonLog.LogLevel >= 3)
                                            {
                                                commonLog.LogEntry("CSSRuleMeargeQueue Insert or Merge Exception. ", exInsert);
                                            }
                                        }
                                        finally
                                        {
                                            try
                                            {
                                                System.Threading.Monitor.Exit(___MergeLockingObject);
                                            }
                                            catch { }
                                        }
                                    }
                                    else
                                    {
                                        if (commonLog.LoggingEnabled && commonLog.LogLevel >= 3)
                                        {
                                            commonLog.LogEntry("Style Merge Monitor List Lock Failed");
                                        }
                                    }
                                    
                                }
                                else
                                {
                                    // ==========================================================
                                    // CHtmlCSSRuleMergeQueue is normally singe thread operation. So No lock is usually required
                                    // ==========================================================
                                    if (sPart.___PseudoClassType != CHtmlPseudoClassType.None)
                                    {
                                        ___targetDocument.___CSSDocumentTotalPseudoClass = ___targetDocument.___CSSDocumentTotalPseudoClass | sPart.___PseudoClassType;
                                    }
                                    posInsert = ____DocumentStylesheetGroundList.BinarySearch(sPart, this._GroundStyleSheetNonGenericSorter);
                                    if (posInsert < 0)
                                    {
                                        posInsert = ~posInsert;
                                    }
                                    ___MeargedOrRemovedStyleCount++; // it is dirty increment, but it is ok!
                                    ____DocumentStylesheetGroundList.Insert(posInsert, sPart);
                                    MergedCount++;
                                }
                            }
                            catch (Exception exBinarySearch)
                            {
                                if (commonLog.LoggingEnabled && commonLog.LogLevel >= 3)
                                {
                                    commonLog.LogEntry("[@@@@@!!!SYSTEM ERROR!!!!@@@@]  Style Merge Queue BinarySearch Failed. ", exBinarySearch.Message);
                                }
                            }


                        RemoveListPhase:
                            if (counterPerformStyleGroudMeargeToGroundListEnterd > 1)
                            {
                                if (System.Threading.Monitor.TryEnter(this.___MergeLockingObject, MAX_WAIT))
                                {
                                    try
                                    {
                                        ___MeargedOrRemovedStyleCount++;// it is dirty increment, but it is ok!
                                        base.RemoveAt(0);
                                    }
                                    finally
                                    {
                                        System.Threading.Monitor.Exit(this.___MergeLockingObject);
                                    }
                                }
                            }
                            else
                            {
                                ___MeargedOrRemovedStyleCount++;
                                base.RemoveAt(0);
                            }
                        }
                        catch (Exception exStyle)
                        {
                            if (commonLog.LoggingEnabled &&commonLog.LogLevel > 1)
                            {
                               commonLog.LogEntry("PerformStyleGroudMeargeToGroundList() Style Level", exStyle);
                            }

                        }

                    }
                }
            CompletePhase:
                if (commonLog.LoggingEnabled &&commonLog.LogLevel > 1 && this.___needsExitFunctionIfQueueZero == false)
                {
                    TimeSpan tpSpanPerformStyleGroudMeargeToGroundList = DateTime.Now.Subtract(dtPerformStyleGroudMeargeToGroundList);
                   commonLog.LogEntry("CSS PerformStyleGroudMeargeToGroundList() Thread completed with {0} items.  Short Wait : {1} Long Wait : {2} Elapsed : {3} ms...",  this.MergedCount, this.___StyleShortWaitOneCount , this.___StyleLongWaitOneCount, tpSpanPerformStyleGroudMeargeToGroundList);
                }
                if (this.___StyleEvent != null)
                {
                    this.___StyleEvent.Close();
                    commonData.DisposeObject(this.___StyleEvent);
                    this.___StyleEvent = null;
                }
            }
            catch (System.Threading.ThreadAbortException)
            {
                if (commonLog.LoggingEnabled &&commonLog.LogLevel > 10)
                {
                   commonLog.LogEntry("PerformStyleGroudMeargeToGroundList() encouteres ThreadAbort. Cont..");
                }
            }
            catch (Exception ex)
            {
                if (ex is System.Threading.ThreadAbortException)
                {
                    if (commonLog.LoggingEnabled &&commonLog.LogLevel > 10)
                    {
                       commonLog.LogEntry("PerformStyleGroudMeargeToGroundList() encounters ThreadAbort. Cont..");
                    }
                }
                else
                if (commonLog.LoggingEnabled &&commonLog.LogLevel > 10)
                {
                   commonLog.LogEntry("PerformStyleGroudMeargeToGroundList() exception", ex);
                }

            }
            if (this.___StyleEvent != null)
            {
                this.___StyleEvent.Close();
                commonData.DisposeObject(this.___StyleEvent);
                this.___StyleEvent = null;
            }
            this.___parentDocument  = null;// Just Release Reference.
            this.IsMergeFunctionEntered = false;
        }
    }
}
