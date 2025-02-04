﻿using System;
using System.Collections.Generic;
using System.Text;
using MultiversalRenderer.Interfaces;



namespace MultiversalRenderer.Core
{

    public sealed class CHtmlMultiversalWindow : IMultiversalWindow, IMultiversalWindow_HTML5_Property_Interface, IDisposable
    {
   
        public delegate void UrlEventHandler(object sender, string _url);
        public event UrlEventHandler UrlChanged;
        internal bool ___isWindowNavigating = false;
        private System.Collections.Generic.Dictionary<int, System.WeakReference> ___childMultiversalWindows = new Dictionary<int, WeakReference>();

        private bool ___IsDispoing = false;
        internal int ___WindowLevel = 1;
        internal string ___id = null; // keep this field as null as defult value.
        internal string ___name = null; // keep this field as null as defult value.
        private static int MAX_WINDOW_LEVEL_PERFORM_NAVIGATE = 5;
        internal int ___NavigateMethodCallCount;
        private bool ___Disposing = false;
        private string ___URL_WIP = null;
        private string ___URL_Request_Original = null;
        private System.WeakReference ___renderingTargetManagedControlWeakReference = null;

        private IMultiversalWindowType ___multiversalWindowType = IMultiversalWindowType.NormalWindow;
        private static System.Collections.Generic.SortedList<System.RuntimeTypeHandle, object> ___MultivarsalScopeTypes = new SortedList<System.RuntimeTypeHandle, object>(new RuntimeTypeHandleComparer());
        private System.WeakReference ___TopMultiversalWindowWeakReference = null;
        internal System.WeakReference ___parentMultiversalWindowWeakReference = null;
        internal System.WeakReference ___parentDocumentWeakReference = null;
        internal System.WeakReference ___ownerElementWeakReference = null;
        public CHtmlWindowURL ___WindowURLObjectInstance = null;
        internal System.DateTime ___windowAnimationStartTime = DateTime.Now;
        public delegate IMultiversalScope delegateCreateMultiversalScope(IMultiversalWindow multi);
        private System.Collections.Generic.Dictionary<string, DateTime> ___multiversalRedirectURLList = new Dictionary<string, DateTime>();
        /// <summary>
        /// If there is no timer interval event but control needs to create
        /// how long timer can be wait.
        /// it is beyond this limit.
        /// Timer should be disposed
        /// </summary>
        private static int[] ___MultiversalTimerControlIntervalArray = new int[] { 100, 250, 500, 3000, 5000, 10000, 15000 };
        //private int ___TimerControlCreatingPendingCount = 0;


        internal System.WeakReference ___HiddenPanelControlReference = null;
        /// <summary>
        /// Stores Script Scope
        /// </summary>
        internal System.Collections.Generic.Dictionary<string, IMultiversalScope> ___MultiversalScopeList;

        private object ___WindowPropertiesLockingObject = new object();
        internal System.Collections.Generic.SortedList<string, object> ___WindowsPropertiesList = new System.Collections.Generic.SortedList<string, object>(StringComparer.Ordinal);

        private object ___PrototypeSampleObject = new object();
        internal CHtmlLocationBase ___locationBase = null;
        public delegate void MultiversalWindowNavigateDelegate2(string ___url, string ___referer);
        public delegate void MultiversalWindowNavigateDelegate5(string ___url, string ___referer, string ___method, string ___data, bool ___asRedirect);
        /// <summary>
        /// Document to be parsed
        /// </summary>
        internal CHtmlDocument ___document = null;

        internal string ___windowName = null;

        internal System.Collections.Generic.Dictionary<string, System.WeakReference> ___MultiversalCallingNameList = null;

        internal IMultiversalScope ___MultiversalScriptScopeDefaultLanguage = null;
        /// <summary>
        /// Counter keep traks how many redirected 
        /// </summary>
        public int ___RedirectCount = 0;

        private static int HTTP_REDIRECT_LIMIT = 15;

        private readonly object ___ChildWindowControlCreationPendingList_LockingObject = new object();
        private System.Threading.Timer ___MultiversalTimer = null;
        private object ___MultiversalTimerLockingObject = new object();

        #region WindowObjects
        internal CHtmlConsole ___console = null;
        internal CHtmlWindowExternal ___external = null;
        internal CHtmlNavigator ___navigator = null;
        internal CHtmlHistoryList ___history = null;
        internal CHtmlWindowEvent ___event = null;
        internal CHtmlPerformance ___performance = null;
        internal CHtmlWebSpeechSynthehesis ___speechSynthehesis = null;

        public delegate void controlVoidDelegete();

        internal CHtmlCrypto ___crypto = null;

        internal CHtmlMultiversalRootNode ___WindowPrototypeRootNode = ___createMultiversalWindowStandardProtypeNode();
        private string ___WindowStatusString = null;
        private bool ___IsWindowClosed = false;
        public static int ___MultiversalLockTimeout = 500;
        internal static System.Collections.Generic.SortedList<System.RuntimeTypeHandle, string> ____FunctionTypeHandleList = new SortedList<System.RuntimeTypeHandle, string>(new RuntimeTypeHandleComparer());
        internal System.Collections.ArrayList ___dynamicallyCreateObjectList = null;

        internal static bool ___isActiveXObjectSupportedGlobal = false;
        internal bool ___isActiveXObjectSupportedThisWindow = false;
        private class RuntimeTypeHandleComparer : System.Collections.Generic.IComparer<System.RuntimeTypeHandle>
        {
            public int Compare(System.RuntimeTypeHandle typeX, System.RuntimeTypeHandle typeY)
            {
                return (int)(typeX.Value.ToInt64() - typeY.Value.ToInt64());
            }
        }
        #endregion
        public CHtmlMultiversalWindow()
            : this(null, true, IMultiversalWindowType.NormalWindow)
        {
        }




        public CHtmlMultiversalWindow(CHtmlMultiversalWindow parentMultiversalWindow, bool IsInitializeStandardObjects)
            : this(parentMultiversalWindow, IsInitializeStandardObjects, IMultiversalWindowType.NormalWindow)
        {
        }
        public CHtmlMultiversalWindow(CHtmlMultiversalWindow parentMultiversalWindow, bool IsInitializeStandardObjects, IMultiversalWindowType ___windowType)
        {
            // ActiveXObject Support is inherirs global settings
            this.___isActiveXObjectSupportedThisWindow = ___isActiveXObjectSupportedGlobal;
            this.___locationBase = new CHtmlLocationBase();
            this.___locationBase.ownerElement = this;
            this.___multiversalWindowType = ___windowType;
            if (parentMultiversalWindow != null)
            {
                this.___parentMultiversalWindowWeakReference = new WeakReference(parentMultiversalWindow, false);

                parentMultiversalWindow.childMultiversalWindows[this.GetHashCode()] = new WeakReference(this, false);

            }
            CHtmlMultiversalWindow topWidnow = this.___getTopMultiversalWindow();
            if (topWidnow != null)
            {
                this.___TopMultiversalWindowWeakReference = new WeakReference(topWidnow, false);
            }
            this.___MultiversalScopeList = new Dictionary<string, IMultiversalScope>(StringComparer.Ordinal);
            this.___MultiversalCallingNameList = new Dictionary<string, System.WeakReference>(StringComparer.OrdinalIgnoreCase);

            this.initializeMultiversalScopes(IsInitializeStandardObjects);
            this.___history = new CHtmlHistoryList();
            this.___history.___ownerRendererWeakReference = new WeakReference(this, false);
            //this.___history.defineFunctionProperties(CHtmlHistoryList.___HistoryObjectFunctionPropertiesNames, typeof(CHtmlHistoryList), org.mozilla.javascript.ScriptableObject.DONTENUM);
            if (this.___crypto == null)
            {
                this.___crypto = new CHtmlCrypto();
            }
            if (this.___console == null)
            {
                this.___console = new CHtmlConsole();
            }
            if (this.___external == null)
            {
                this.___external = new CHtmlWindowExternal();
            }
            if (this.___navigator == null)
            {
                this.___navigator = new CHtmlNavigator();
            }

            this.___WindowURLObjectInstance = new CHtmlWindowURL();
            if (this.___event == null)
            {
                this.___event = new CHtmlWindowEvent();
                this.___event.___isMultiversalMode = true;
                this.___event.___ownerMultiversalWindowWeakReference = new WeakReference(this, false);
                this.___event.___eventSourceType = CHtmlWindowEvent.CHtmlWindowEventEventType.staticwindow;
                this.___event.___prototypeWeakReference = this.___WindowPrototypeRootNode.___EventPrototypeWeakReference;
            }

            if(this.___speechSynthehesis == null)
            {
                this.___speechSynthehesis = new CHtmlWebSpeechSynthehesis();
            }
            if (this.___performance == null)
            {
                this.___performance = new CHtmlPerformance();
            }
            else
            {
                if (this.___performance != null)
                {
                    if (this.___performance.timing != null)
                    {
                        // clear performance timing data now.
                        this.___performance.timing.___clearCounterData();
                    }
                }
            }


        }
        ~CHtmlMultiversalWindow()
        {
            this.___IsDispoing = true;
            this.___CleanUp();
        }
        public int ___getScriptProcessorCount()
        {
            if (this.___MultiversalScopeList != null)
            {
                return this.___MultiversalScopeList.Count;
            }
            return 0;
        }
        public override string ToString()
        {
            if (this.___windowName == null || this.___windowName.Length == 0)
            {
                return "CHtmlMultiversalWindow(" + this.___WindowLevel.ToString() + ")";
            }
            else
            {
                return "CHtmlMultiversalWindow(" + this.___WindowLevel.ToString() + "    \'" + this.___windowName + "\')";
            }
        }
        private void ___CleanUp()
        {
            try
            {
                if (this.___isWindowNavigating == false)
                {
                    this.___isWindowNavigating = true;
                }
                this.___setChildMultiversalWindowNavigatingStatus();
                if (this.___document != null)
                {
                    this.___document.Dispose();
                }


            }
            catch (Exception ex)
            {
                if (commonLog.LoggingEnabled && commonLog.CommonLogLevel >= 10)
                {
                    commonLog.LogEntry("CleanUp Timer Error. but cont...", ex.Message);
                }
            }
        }

        public static void registerFunctionObjectType(Type ___scriptableType, string ___callingName)
        {
            ____FunctionTypeHandleList[___scriptableType.TypeHandle] = ___callingName;
        }
        internal void ___clearWindowEvent()
        {
            if (this.___event != null)
            {
                this.___event.___resetToDefaults();
            }
        }
        internal void ___copyWindowEventValuesFromWindowEvent(CHtmlWindowEvent ___newEvent)
        {
            if (this.___event != null)
            {
                this.___event.___resetToDefaults();

            }
            this.___event.___copyWindowEventValuesFromWindowEvent(___newEvent);
        }
        /*
         internal void ___addChildMultiversalWindowToCreateControl(CHtmlMultiversalWindow ___childMultiversalWindow)
         {
             if (this.___ChildWindowControlCreationPendingList == null)
             {
                 this.___ChildWindowControlCreationPendingList = new List<WeakReference>();
             }
             if (System.Threading.Monitor.TryEnter(___ChildWindowControlCreationPendingList, 5000))
             {
                 this.___ChildWindowControlCreationPendingList.Add(new WeakReference(___childMultiversalWindow));
                 System.Threading.Monitor.Exit(___ChildWindowControlCreationPendingList);
             }
             if (this.___MultiversalTimer == null)
             {
                 System.Windows.Forms.MethodInvoker invoker = new System.Windows.Forms.MethodInvoker(this.___startCreationChildControlBaseduponPendingList);
                 invoker.Invoke();
             }
         }

         internal void ___startCreationChildControlBaseduponPendingList()
         {

             if (this.___MultiversalTimer == null)
             {
                 if (System.Threading.Monitor.TryEnter(this.___MultiversalTimerLockingObject, 1000) == true)
                 {
                     try
                     {
                         System.Threading.TimerCallback tb = new System.Threading.TimerCallback(this.___MultiversalTimerParentChildCreation_Tick);

                         this.___MultiversalTimer = new System.Threading.Timer(tb);
                         this.___MultiversalTimer.Change(250, 250);
                     }
                     catch (Exception ex)
                     {
                         if (commonLog.LoggingEnabled && commonLog.CommonLogLevel >= 10)
                         {
                             commonLog.LogEntry("___startCreationChildControlBaseduponPendingList() Exception. " + ex.Message);
                         }
                     }
                     finally
                     {
                         System.Threading.Monitor.Exit(this.___MultiversalTimerLockingObject);
                     }
                 }
             }
         }
         */
        public System.Collections.Generic.Dictionary<int, System.WeakReference> childMultiversalWindows
        {
            get
            {
                return this.___childMultiversalWindows;
            }
        }
        private static CHtmlMultiversalRootNode ___createMultiversalWindowStandardProtypeNode()
        {
            CHtmlMultiversalRootNode rootPrototypeNode = new CHtmlMultiversalRootNode();
            rootPrototypeNode.___IsPrototype = true;

            CHtmlHistoryList ___historyPrototype = new CHtmlHistoryList();

            ___historyPrototype.___IsPrototype = true;
          //  ___historyPrototype.defineFunctionProperties(CHtmlHistoryList.___HistoryObjectFunctionPropertiesNames, typeof(CHtmlHistoryList), org.mozilla.javascript.ScriptableObject.DONTENUM);
            rootPrototypeNode.___childNodes.Add(___historyPrototype);
            rootPrototypeNode.___HistoryPrototypeWeakReference = new WeakReference(___historyPrototype, false);

            CHtmlXPathResult ___xpathResultPrototype = new CHtmlXPathResult();
            ___xpathResultPrototype.___IsPrototype = true;
            ___xpathResultPrototype.parentNode = rootPrototypeNode;
            rootPrototypeNode.___XPathResultPrototypeWeakReference = new WeakReference(___xpathResultPrototype, false);
            rootPrototypeNode.___childNodes.Add(___xpathResultPrototype);

            CHtmlAttribute ___attrPrototype = new CHtmlAttribute();
            ___attrPrototype.___multiversalClassType = IMutilversalObjectType.Attr;
            ___attrPrototype.___IsPrototype = true;
            ___attrPrototype.parentNode = rootPrototypeNode;
            rootPrototypeNode.___AttrProtoTypeWeakReference = new WeakReference(___attrPrototype, false);
            rootPrototypeNode.___childNodes.Add(___attrPrototype);

            CHtmlCanvasContext ___C2DPrototype = new CHtmlCanvasContext(true);
            ___C2DPrototype.___IsPrototype = true;
            ___C2DPrototype.___multiversalClassType = IMutilversalObjectType.CanvasRenderingContext2D;
            ___C2DPrototype.___CanvasContextModeType = CanvasContextModeType.Canvas2DPrototype;
            ___C2DPrototype.parentNode = rootPrototypeNode;
            rootPrototypeNode.___childNodes.Add(___C2DPrototype);
            rootPrototypeNode.___CanvasContextPrototypeWeakReference = new WeakReference(___C2DPrototype, false);

            CHtmlCanvasContext ___canvasWebGLPrototype = new CHtmlCanvasContext(true);
            ___canvasWebGLPrototype.___IsPrototype = true;
            ___canvasWebGLPrototype.___CanvasContextModeType = CanvasContextModeType.WebGLPrototype;
            ___canvasWebGLPrototype.parentNode = rootPrototypeNode;
            rootPrototypeNode.___childNodes.Add(___canvasWebGLPrototype);
            rootPrototypeNode.___CanvasWebGLRenderingContextPrototypeWeakReference = new WeakReference(___canvasWebGLPrototype, false);


            CHtmlAudioContext  ___canvasAudioContextPrototype = new CHtmlAudioContext(true);
            ___canvasAudioContextPrototype.___multiversalClassType = IMutilversalObjectType.AudioContext;
            ___canvasAudioContextPrototype.___IsPrototype = true;
            ___canvasAudioContextPrototype.___CanvasContextModeType = CanvasContextModeType.CanvasAudioContextPrototype;
            ___canvasAudioContextPrototype.parentNode = rootPrototypeNode;
            rootPrototypeNode.___childNodes.Add(___canvasAudioContextPrototype);
            rootPrototypeNode.___AudioContextPrototypeWeakReference = new WeakReference(___canvasAudioContextPrototype, false);

            CHtmlAudioBufferSourceNode ___audioBufferSouceNodePrototype = new CHtmlAudioBufferSourceNode();
            ___audioBufferSouceNodePrototype.___IsPrototype = true;
            ___audioBufferSouceNodePrototype.___multiversalClassType = IMutilversalObjectType.AudioBufferSourceNode;
            ___audioBufferSouceNodePrototype.parentNode = rootPrototypeNode;
            rootPrototypeNode.___childNodes.Add(___audioBufferSouceNodePrototype);
            rootPrototypeNode.___AudioBuuferSourceNodeWeakReference = new WeakReference(___audioBufferSouceNodePrototype, false);

            CHtmlAudioOscillatorNode ___audioOscillatorNodeProtoType = new CHtmlAudioOscillatorNode();
            ___audioOscillatorNodeProtoType.___IsPrototype = true;
            ___audioOscillatorNodeProtoType.___multiversalClassType = IMutilversalObjectType.OscillatorNode;
            ___audioOscillatorNodeProtoType.parentNode = rootPrototypeNode;
            rootPrototypeNode.___childNodes.Add(___audioOscillatorNodeProtoType);
            rootPrototypeNode.___AudioOscillatorNodeWeakReference = new WeakReference(___audioOscillatorNodeProtoType);


            CHtmlNavigator ___navigatorPrototype = new CHtmlNavigator();
            ___navigatorPrototype.___multiversalClassType = IMutilversalObjectType.Navigator;
            ___navigatorPrototype.___IsPrototype = true;
            ___navigatorPrototype.parentNode = rootPrototypeNode;

            rootPrototypeNode.___childNodes.Add(___navigatorPrototype);
            rootPrototypeNode.___NavigatorPrototypeWeakReference = new WeakReference(___navigatorPrototype, false);

            CHtmlConsole ___consolePrototype = new CHtmlConsole();
            ___consolePrototype.___multiversalClassType = IMutilversalObjectType.Console;
            ___consolePrototype.___IsPrototype = true;
            ___consolePrototype.parentNode = rootPrototypeNode;
            rootPrototypeNode.___childNodes.Add(___consolePrototype);
            rootPrototypeNode.___ConsolePrototypeWeakReference = new WeakReference(___consolePrototype, false);

            CHtmlWindowEvent ___keyboardEventPrototype = new CHtmlWindowEvent();
            ___keyboardEventPrototype.___multiversalClassType = IMutilversalObjectType.KeyboardEvent;
            ___keyboardEventPrototype.parentNode = rootPrototypeNode;
            rootPrototypeNode.___childNodes.Add(___keyboardEventPrototype);
            rootPrototypeNode.___KeyboardEventWeakReference = new WeakReference(___keyboardEventPrototype, false);


            /* HTMLCollection Prototype */
            CHtmlCollection ___htmlCollectionPrototype = new CHtmlCollection();
            ___htmlCollectionPrototype.___multiversalClassType = IMutilversalObjectType.HTMLCollection;
            ___htmlCollectionPrototype.___IsPrototype = true;
            ___htmlCollectionPrototype.___CollectionType = CHtmlHTMLCollectionType.HTMLCollectionPrototype;
            rootPrototypeNode.___childNodes.Add(___htmlCollectionPrototype);
            rootPrototypeNode.___HTMLCollectionPrototypeWeakReference = new WeakReference(___htmlCollectionPrototype, false);

            /* NodeList Prototype */
            CHtmlCollection ___nodeListPrototype = new CHtmlCollection();
            ___nodeListPrototype.___multiversalClassType = IMutilversalObjectType.NodeList;
            ___nodeListPrototype.___IsPrototype = true;
            ___nodeListPrototype.___CollectionType = CHtmlHTMLCollectionType.NodeListPrototype;
            rootPrototypeNode.___childNodes.Add(___nodeListPrototype);
            rootPrototypeNode.___NodeListPrototypeWeakReference = new WeakReference(___nodeListPrototype, false);


            CHtmlElement ___elementPrototype = new CHtmlElement();
            ___elementPrototype.___multiversalClassType = IMutilversalObjectType.Element;
            ___elementPrototype.___SetTagNameOnly("#ELEMENT_PROTOTYPE");
            ___elementPrototype.___elementTagType = CHtmlElementType._ELEMENT_PROTOTYPE;
            ___elementPrototype.___IsPrototype = true;
            ___elementPrototype.parentNode = rootPrototypeNode;
            rootPrototypeNode.___childNodes.Add(___elementPrototype);

            rootPrototypeNode.___ElementPrototypeWeakReference = new WeakReference(___elementPrototype, false);

            CHtmlElement ___HTMLElementPrototype = new CHtmlElement();
            ___HTMLElementPrototype.___multiversalClassType = IMutilversalObjectType.HTMLElement;
            ___HTMLElementPrototype.___SetTagNameOnly("#HTMLELEMENT_PROTOTYPE");
            ___HTMLElementPrototype.___elementTagType = CHtmlElementType._HTMLELEMENT_PROTOTYPE;
            ___HTMLElementPrototype.___IsPrototype = true;
            ___HTMLElementPrototype.parentNode = ___elementPrototype;
            ___elementPrototype.___childNodes.Add(___HTMLElementPrototype);

            rootPrototypeNode.___HTMLElementPrototypeWeakReference = new WeakReference(___HTMLElementPrototype, false);



            CHtmlElement ___WindowHTMLCanvasElementPrototype = null;
            CHtmlElement ___WindowHTMLHtmlElementPrototype = null;
            CHtmlElement ___WindowHTMLIFrameElementPrototype = null;
            CHtmlElement ___WindowHTMLFrameElementPrototype = null;
            CHtmlElement ___WindowHTMLInputElementPrototype = null;
            CHtmlElement ___WindowHTMLFormElementPrototype = null;
            CHtmlMediaElement ___WindowHTMLVideoElementPrototype = null;
            CHtmlMediaElement ___WindowHTMLAudioElementPrototype = null;
            CHtmlElement ___WindowHTMLLinkElementPrototype = null;
            CHtmlElement ___WindowHTMLAnchorElementPrototype = null;
            CHtmlElement ___WindowHTMLScriptElementPrototype = null;
            CHtmlElement ___WindowHTMLImageElementPrototype = null;


            CHtmlWindowEvent ___WindowEventPrototype = null;
            CHtmlWindowEvent ___WindowMouseEventPrototype = null;
            CHtmlCSSStyleSheet ___WindowStylePrototype = null;
            CHtmlCanvasContext ___WindowCanvasContextPrototype = null;
            CHtmlCanvasContextExtenstionObject ___WindowCanvasExtenstionPrototype = null;
            CHtmlCSSRule ___WindowCSSRulePrototype = null;
            CHtmlCSSStyleSheet ___WindowCSSStyleSheetPrototype = null;


            ___WindowHTMLCanvasElementPrototype = new CHtmlElement();
            ___WindowHTMLCanvasElementPrototype.___SetTagNameOnly("CANVAS");
            ___WindowHTMLCanvasElementPrototype.___elementTagType = CHtmlElementType.CANVAS;
            ___WindowHTMLCanvasElementPrototype.___multiversalClassType = IMutilversalObjectType.HTMLCanvasElement;

            ___WindowHTMLCanvasElementPrototype.___IsPrototype = true;
            ___WindowHTMLCanvasElementPrototype.parentNode = ___HTMLElementPrototype;
            ___HTMLElementPrototype.___childNodes.Add(___WindowHTMLCanvasElementPrototype);

            rootPrototypeNode.___HTMLCanvasElementPrototypeWeakReference = new WeakReference(___WindowHTMLCanvasElementPrototype, false);


            ___WindowHTMLAudioElementPrototype = new CHtmlMediaElement();
            ___WindowHTMLAudioElementPrototype.___SetTagNameOnly("AUDIO");
            ___WindowHTMLAudioElementPrototype.___elementTagType = CHtmlElementType.AUDIO;
            ___WindowHTMLAudioElementPrototype.___IsPrototype = true;
            ___WindowHTMLAudioElementPrototype.parentNode = ___HTMLElementPrototype;
            ___WindowHTMLAudioElementPrototype.___multiversalClassType = IMutilversalObjectType.HTMLAudioElement;
            ___HTMLElementPrototype.___childNodes.Add(___WindowHTMLAudioElementPrototype);

            rootPrototypeNode.___HTMLAudioElementPrototypeWeakReference = new WeakReference(___WindowHTMLAudioElementPrototype, false);


            ___WindowHTMLVideoElementPrototype = new CHtmlMediaElement();
            ___WindowHTMLVideoElementPrototype.___SetTagNameOnly("VIDEO");
            ___WindowHTMLVideoElementPrototype.___elementTagType = CHtmlElementType.VIDEO;
            ___WindowHTMLVideoElementPrototype.___IsPrototype = true;
            ___WindowHTMLVideoElementPrototype.parentNode = ___HTMLElementPrototype;
            ___WindowHTMLVideoElementPrototype.___multiversalClassType = IMutilversalObjectType.HTMLVideoElement;
            ___HTMLElementPrototype.___childNodes.Add(___WindowHTMLVideoElementPrototype);

            rootPrototypeNode.___HTMLVideoElementPrototypeWeakReference = new WeakReference(___WindowHTMLVideoElementPrototype, false);


            ___WindowHTMLInputElementPrototype = new CHtmlElement();

            ___WindowHTMLInputElementPrototype.___SetTagNameOnly("INPUT");
            ___WindowHTMLInputElementPrototype.___multiversalClassType = IMutilversalObjectType.HTMLInputElement;
            ___WindowHTMLInputElementPrototype.___elementTagType = CHtmlElementType.INPUT;
            ___WindowHTMLInputElementPrototype.___IsPrototype = true;
            ___WindowHTMLInputElementPrototype.parentNode = ___HTMLElementPrototype;
            ___HTMLElementPrototype.___childNodes.Add(___WindowHTMLInputElementPrototype);

            rootPrototypeNode.___HTMLInputElementPrototypeWeakReference = new WeakReference(___WindowHTMLInputElementPrototype, false);

            ___WindowHTMLImageElementPrototype = new CHtmlElement();
            ___WindowHTMLImageElementPrototype.___SetTagNameOnly("IMG");
            ___WindowHTMLImageElementPrototype.___multiversalClassType = IMutilversalObjectType.HTMLImageElement;
            ___WindowHTMLImageElementPrototype.___elementTagType = CHtmlElementType.IMG;
            ___WindowHTMLImageElementPrototype.___IsPrototype = true;
            ___WindowHTMLImageElementPrototype.parentNode = ___HTMLElementPrototype;
            ___HTMLElementPrototype.___childNodes.Add(___WindowHTMLImageElementPrototype);

            rootPrototypeNode.___HTMLImageElementPrototypeWeakReference = new WeakReference(___WindowHTMLImageElementPrototype, false);


            ___WindowHTMLHtmlElementPrototype = new CHtmlElement();
            ___WindowHTMLHtmlElementPrototype.___SetTagNameOnly("HTML");
            ___WindowHTMLHtmlElementPrototype.___multiversalClassType = IMutilversalObjectType.HTMLHtmlElement;
            ___WindowHTMLHtmlElementPrototype.___elementTagType = CHtmlElementType.HTML;
            ___WindowHTMLHtmlElementPrototype.___IsPrototype = true;
            ___WindowHTMLHtmlElementPrototype.parentNode = ___HTMLElementPrototype;
            ___HTMLElementPrototype.___childNodes.Add(___WindowHTMLHtmlElementPrototype);

            rootPrototypeNode.___HTMLHtmlElementPrototypeWeakReference = new WeakReference(___WindowHTMLHtmlElementPrototype, false);


            ___WindowHTMLFormElementPrototype = new CHtmlElement();
            ___WindowHTMLFormElementPrototype.___SetTagNameOnly("FORM");
            ___WindowHTMLFormElementPrototype.___elementTagType = CHtmlElementType.FORM;
            ___WindowHTMLFormElementPrototype.___multiversalClassType = IMutilversalObjectType.HTMLFormElement;
            ___WindowHTMLFormElementPrototype.___IsPrototype = true;
            ___WindowHTMLFormElementPrototype.parentNode = ___HTMLElementPrototype;
            ___HTMLElementPrototype.___childNodes.Add(___WindowHTMLFormElementPrototype);

            rootPrototypeNode.___HTMLFormElementPrototypeWeakReference = new WeakReference(___WindowHTMLFormElementPrototype, false);


            ___WindowHTMLIFrameElementPrototype = new CHtmlElement();
            ___WindowHTMLIFrameElementPrototype.___SetTagNameOnly("IFRAME");
            ___WindowHTMLIFrameElementPrototype.___multiversalClassType = IMutilversalObjectType.HTMLIFrameElement;
            ___WindowHTMLIFrameElementPrototype.___elementTagType = CHtmlElementType.IFRAME;
            ___WindowHTMLIFrameElementPrototype.___IsPrototype = true;
            ___WindowHTMLIFrameElementPrototype.parentNode = ___HTMLElementPrototype;
            ___HTMLElementPrototype.___childNodes.Add(___WindowHTMLIFrameElementPrototype);

            rootPrototypeNode.___HTMLIFrameElementPrototypeWeakReference = new WeakReference(___WindowHTMLIFrameElementPrototype, false);

            ___WindowHTMLFrameElementPrototype = new CHtmlElement();
            ___WindowHTMLFrameElementPrototype.___SetTagNameOnly("FRAME");
            ___WindowHTMLFrameElementPrototype.___multiversalClassType = IMutilversalObjectType.HTMLFrameElement;
            ___WindowHTMLFrameElementPrototype.___elementTagType = CHtmlElementType.FRAME;
            ___WindowHTMLFrameElementPrototype.___IsPrototype = true;
            ___WindowHTMLFrameElementPrototype.parentNode = ___HTMLElementPrototype;
            ___HTMLElementPrototype.___childNodes.Add(___WindowHTMLFrameElementPrototype);

            rootPrototypeNode.___HTMLFrameElementPrototypeWeakReference = new WeakReference(___WindowHTMLFrameElementPrototype, false);



            ___WindowHTMLLinkElementPrototype = new CHtmlElement();
            ___WindowHTMLLinkElementPrototype.___SetTagNameOnly("LINK");
            ___WindowHTMLLinkElementPrototype.___elementTagType = CHtmlElementType.LINK;
            ___WindowHTMLLinkElementPrototype.___IsPrototype = true;
            ___WindowHTMLLinkElementPrototype.parentNode = ___HTMLElementPrototype;
            ___HTMLElementPrototype.___childNodes.Add(___WindowHTMLLinkElementPrototype);


            rootPrototypeNode.___HTMLLinkElementPrototypeWeakReference = new WeakReference(___WindowHTMLLinkElementPrototype, false);

            ___WindowHTMLAnchorElementPrototype = new CHtmlElement();
            ___WindowHTMLAnchorElementPrototype.___SetTagNameOnly("A");
            ___WindowHTMLAudioElementPrototype.___multiversalClassType = IMutilversalObjectType.HTMLAnchorElement;
            ___WindowHTMLAnchorElementPrototype.___elementTagType = CHtmlElementType.A;
            ___WindowHTMLAnchorElementPrototype.___IsPrototype = true;
            ___WindowHTMLAnchorElementPrototype.parentNode = ___HTMLElementPrototype;
            ___HTMLElementPrototype.___childNodes.Add(___WindowHTMLAnchorElementPrototype);

            rootPrototypeNode.___HTMLAnchorElementPrototypeWeakReference = new WeakReference(___WindowHTMLAnchorElementPrototype, false);


            ___WindowHTMLScriptElementPrototype = new CHtmlElement();
            ___WindowHTMLScriptElementPrototype.___SetTagNameOnly("SCRIPT");
            ___WindowHTMLScriptElementPrototype.___elementTagType = CHtmlElementType.SCRIPT;
            ___WindowHTMLScriptElementPrototype.___multiversalClassType = IMutilversalObjectType.HTMLScriptElement;
            ___WindowHTMLScriptElementPrototype.___IsPrototype = true;
            ___WindowHTMLScriptElementPrototype.parentNode = ___HTMLElementPrototype;
            ___HTMLElementPrototype.___childNodes.Add(___WindowHTMLScriptElementPrototype);
            rootPrototypeNode.___HTMLScriptElementPrototypeWeakReference = new WeakReference(___WindowHTMLScriptElementPrototype, false);


            CHtmlElement ___WindowOptionElementPrototype = new CHtmlElement();
            ___WindowOptionElementPrototype.___SetTagNameOnly("OPTION");
            ___WindowOptionElementPrototype.___multiversalClassType = IMutilversalObjectType.HTMLOptionElement;
            ___WindowOptionElementPrototype.___elementTagType = CHtmlElementType.OPTION;
            ___WindowOptionElementPrototype.___IsPrototype = true;
            ___WindowOptionElementPrototype.parentNode = ___HTMLElementPrototype;
            ___HTMLElementPrototype.___childNodes.Add(___WindowOptionElementPrototype);
            rootPrototypeNode.___HTMLOptionElementPrototypeWeakReference = new WeakReference(___WindowOptionElementPrototype, false);

            CHtmlElement ___WindowOptGroupElementPrototype = new CHtmlElement();
            ___WindowOptGroupElementPrototype.___SetTagNameOnly("OPTGROUP");
            ___WindowOptGroupElementPrototype.___multiversalClassType = IMutilversalObjectType.HTMLOptGroupElement;
            ___WindowOptGroupElementPrototype.___elementTagType = CHtmlElementType.OPTGROUP;
            ___WindowOptGroupElementPrototype.___IsPrototype = true;
            ___WindowOptGroupElementPrototype.parentNode = ___HTMLElementPrototype;
            ___HTMLElementPrototype.___childNodes.Add(___WindowOptGroupElementPrototype);
            rootPrototypeNode.___HTMLOptGroupElementPrototypeWeakReference = new WeakReference(___WindowOptGroupElementPrototype, false);

            CHtmlElement ___WindowSourceElementPrototype = new CHtmlElement();
            ___WindowSourceElementPrototype.___multiversalClassType = IMutilversalObjectType.HTMLSourceElement;
            ___WindowSourceElementPrototype.___SetTagNameOnly("SOURCE");
            ___WindowSourceElementPrototype.___elementTagType = CHtmlElementType.SOURCE;
            ___WindowSourceElementPrototype.___IsPrototype = true;
            ___WindowSourceElementPrototype.parentNode = ___HTMLElementPrototype;
            ___HTMLElementPrototype.___childNodes.Add(___WindowSourceElementPrototype);
            rootPrototypeNode.___HTMLSourceElementPrototypeWeakReference = new WeakReference(___WindowSourceElementPrototype, false);

            CHtmlElement ___WindowHTMLButtonElementPrototype = new CHtmlElement();
            ___WindowHTMLButtonElementPrototype.___SetTagNameOnly("BUTTON");
            ___WindowHTMLButtonElementPrototype.___elementTagType = CHtmlElementType.BUTTON;
            ___WindowHTMLButtonElementPrototype.___IsPrototype = true;
            ___WindowHTMLButtonElementPrototype.___multiversalClassType = IMutilversalObjectType.HTMLButtonElement;
            ___WindowHTMLButtonElementPrototype.parentNode = ___HTMLElementPrototype;
            ___HTMLElementPrototype.___childNodes.Add(___WindowHTMLButtonElementPrototype);

            rootPrototypeNode.___HTMLButtonElementPrototypeWeakReference = new WeakReference(___WindowHTMLButtonElementPrototype, false);



            CHtmlElement ___WindowSelectElementPrototype = new CHtmlElement();
            ___WindowSelectElementPrototype.___SetTagNameOnly("SELECT");
            ___WindowSelectElementPrototype.___elementTagType = CHtmlElementType.SELECT;
            ___WindowSelectElementPrototype.___multiversalClassType = IMutilversalObjectType.HTMLSelectElement;
            ___WindowSelectElementPrototype.___IsPrototype = true;
            ___WindowSelectElementPrototype.parentNode = ___HTMLElementPrototype;
            ___HTMLElementPrototype.___childNodes.Add(___WindowSelectElementPrototype);

            rootPrototypeNode.___HTMLSelectElementPrototypeWeakReference = new WeakReference(___WindowSelectElementPrototype, false);



            CHtmlElement ___WindowTableElementPrototype = new CHtmlElement();
            ___WindowTableElementPrototype.___SetTagNameOnly("TABLE");
            ___WindowTableElementPrototype.___elementTagType = CHtmlElementType.TABLE;
            ___WindowTableElementPrototype.___multiversalClassType = IMutilversalObjectType.HTMLTableElement;
            ___WindowTableElementPrototype.___IsPrototype = true;
            ___WindowTableElementPrototype.parentNode = ___HTMLElementPrototype;
            ___HTMLElementPrototype.___childNodes.Add(___WindowTableElementPrototype);
            rootPrototypeNode.___HTMLTableElementPrototypeWeakReference = new WeakReference(___WindowTableElementPrototype, false);

            CHtmlElement ___WindowTableSectionElementPrototype = new CHtmlElement();
            ___WindowTableSectionElementPrototype.___SetTagNameOnly("THEAD");
            ___WindowTableSectionElementPrototype.___elementTagType = CHtmlElementType.THEAD;
            ___WindowTableSectionElementPrototype.___IsPrototype = true;
            ___WindowTableSectionElementPrototype.parentNode = ___HTMLElementPrototype;
            ___HTMLElementPrototype.___childNodes.Add(___WindowTableSectionElementPrototype);
            rootPrototypeNode.___HTMLTableSectionElementPrototypeWeakReference = new WeakReference(___WindowTableElementPrototype, false);


            CHtmlElement ___WindowTableRowElementPrototype = new CHtmlElement();
            ___WindowTableRowElementPrototype.___SetTagNameOnly("TR");
            ___WindowTableRowElementPrototype.___multiversalClassType = IMutilversalObjectType.HTMLTableRowElement;
            ___WindowTableRowElementPrototype.___elementTagType = CHtmlElementType.TR;
            ___WindowTableRowElementPrototype.___IsPrototype = true;
            ___WindowTableRowElementPrototype.parentNode = ___HTMLElementPrototype;
            ___HTMLElementPrototype.___childNodes.Add(___WindowTableRowElementPrototype);

            rootPrototypeNode.___HTMLTableRowElementPrototypeWeakReference = new WeakReference(___WindowTableRowElementPrototype, false);

            CHtmlElement ___WindowTableCellElementPrototype = new CHtmlElement();
            ___WindowTableCellElementPrototype.___SetTagNameOnly("TD");
            ___WindowTableCellElementPrototype.___multiversalClassType = IMutilversalObjectType.HTMLTableCellElement;
            ___WindowTableCellElementPrototype.___elementTagType = CHtmlElementType.TD;
            ___WindowTableCellElementPrototype.___IsPrototype = true;
            ___WindowTableCellElementPrototype.parentNode = ___HTMLElementPrototype;
            ___HTMLElementPrototype.___childNodes.Add(___WindowTableCellElementPrototype);
            rootPrototypeNode.___HTMLTableCellElementPrototypeWeakReference = new WeakReference(___WindowTableCellElementPrototype, false);

            CHtmlElement ___WindowTableColElementPrototype = new CHtmlElement();
            ___WindowTableColElementPrototype.___SetTagNameOnly("COL");
            ___WindowTableColElementPrototype.___multiversalClassType = IMutilversalObjectType.HTMLTableColElement;
            ___WindowTableColElementPrototype.___elementTagType = CHtmlElementType.COL;
            ___WindowTableColElementPrototype.___IsPrototype = true;
            ___WindowTableColElementPrototype.parentNode = ___HTMLElementPrototype;
            ___HTMLElementPrototype.___childNodes.Add(___WindowTableColElementPrototype);
            rootPrototypeNode.___HTMLTableColElementPrototypeWeakReference = new WeakReference(___WindowTableColElementPrototype, false);

            CHtmlElement ___WindowTextAreaElementPrototype = new CHtmlElement();
            ___WindowTextAreaElementPrototype.___SetTagNameOnly("TEXTAREA");
            ___WindowTextAreaElementPrototype.___multiversalClassType = IMutilversalObjectType.HTMLTextAreaElement;
            ___WindowTextAreaElementPrototype.___elementTagType = CHtmlElementType.TEXTAREA;
            ___WindowTextAreaElementPrototype.___IsPrototype = true;
            ___WindowTextAreaElementPrototype.parentNode = ___HTMLElementPrototype;
            ___HTMLElementPrototype.___childNodes.Add(___WindowTextAreaElementPrototype);
            rootPrototypeNode.___HTMLTextAreaElementPrototypeWeakReference = new WeakReference(___WindowTextAreaElementPrototype, false);

            CHtmlElement ___WindowUListPrototype = new CHtmlElement();
            ___WindowUListPrototype.___SetTagNameOnly("U");
            ___WindowUListPrototype.___elementTagType = CHtmlElementType.U;
            ___WindowUListPrototype.___IsPrototype = true;
            ___WindowUListPrototype.parentNode = ___HTMLElementPrototype;
            ___HTMLElementPrototype.___childNodes.Add(___WindowUListPrototype.parentNode);
            rootPrototypeNode.___HTMLUListElementPrototypeWeakReference = new WeakReference(___WindowUListPrototype.parentNode, false);

            CHtmlElement ___WindowLIElementPrototype = new CHtmlElement();
            ___WindowLIElementPrototype.___SetTagNameOnly("LI");
            ___WindowLIElementPrototype.___elementTagType = CHtmlElementType.LI;
            ___WindowLIElementPrototype.___IsPrototype = true;
            ___WindowLIElementPrototype.parentNode = ___HTMLElementPrototype;
            ___HTMLElementPrototype.___childNodes.Add(___WindowLIElementPrototype.parentNode);
            rootPrototypeNode.___HTMLIElementPrototypeWeakReference = new WeakReference(___WindowLIElementPrototype.parentNode, false);




            CHtmlElement ___WindowBodyElementPrototype = new CHtmlElement();
            ___WindowBodyElementPrototype.___SetTagNameOnly("BODY");
            ___WindowBodyElementPrototype.___multiversalClassType = IMutilversalObjectType.HTMLBodyElement;
            ___WindowBodyElementPrototype.___elementTagType = CHtmlElementType.BODY;
            ___WindowBodyElementPrototype.___IsPrototype = true;
            ___WindowBodyElementPrototype.parentNode = ___HTMLElementPrototype;
            ___HTMLElementPrototype.___childNodes.Add(___WindowBodyElementPrototype);
            rootPrototypeNode.___HTMLBodyElementPrototypeWeakReference = new WeakReference(___WindowBodyElementPrototype, false);

            CHtmlElement ___WindowHeadElementPrototype = new CHtmlElement();
            ___WindowHeadElementPrototype.___SetTagNameOnly("HEAD");
            ___WindowHeadElementPrototype.___multiversalClassType = IMutilversalObjectType.HTMLHeadElement;
            ___WindowHeadElementPrototype.___elementTagType = CHtmlElementType.HEAD;
            ___WindowHeadElementPrototype.___IsPrototype = true;
            ___WindowHeadElementPrototype.parentNode = ___HTMLElementPrototype;
            ___HTMLElementPrototype.___childNodes.Add(___WindowHeadElementPrototype);
            rootPrototypeNode.___HTMLHeadElementPrototypeWeakReference = new WeakReference(___WindowHeadElementPrototype, false);


            CHtmlElement ___WindowBaseElementPrototype = new CHtmlElement();
            ___WindowBaseElementPrototype.___SetTagNameOnly("BASE");
            ___WindowBaseElementPrototype.___elementTagType = CHtmlElementType.BASE;
            ___WindowBaseElementPrototype.___IsPrototype = true;
            ___WindowBaseElementPrototype.parentNode = ___HTMLElementPrototype;
            ___HTMLElementPrototype.___childNodes.Add(___WindowBaseElementPrototype);
            rootPrototypeNode.___HTMLBaseElementPrototypeWeakReference = new WeakReference(___WindowBaseElementPrototype, false);

            CHtmlElement ___WindowDivElementPrototype = new CHtmlElement();
            ___WindowDivElementPrototype.___SetTagNameOnly("DIV");
            ___WindowDivElementPrototype.___multiversalClassType = IMutilversalObjectType.HTMLDivElement;
            ___WindowDivElementPrototype.___elementTagType = CHtmlElementType.DIV;
            ___WindowDivElementPrototype.___IsPrototype = true;
            ___WindowDivElementPrototype.parentNode = ___HTMLElementPrototype;
            ___HTMLElementPrototype.___childNodes.Add(___WindowDivElementPrototype);
            rootPrototypeNode.___HTMLDivElementPrototypeWeakReference = new WeakReference(___WindowDivElementPrototype, false);

            CHtmlElement ___WindowSpanElementPrototype = new CHtmlElement();
            ___WindowSpanElementPrototype.___multiversalClassType = IMutilversalObjectType.HTMLSpanElement;
            ___WindowSpanElementPrototype.___SetTagNameOnly("SPAN");
            ___WindowSpanElementPrototype.___elementTagType = CHtmlElementType.SPAN;
            ___WindowSpanElementPrototype.___IsPrototype = true;
            ___WindowSpanElementPrototype.parentNode = ___HTMLElementPrototype;
            ___HTMLElementPrototype.___childNodes.Add(___WindowSpanElementPrototype);
            rootPrototypeNode.___HTMLSpanElementPrototypeWeakReference = new WeakReference(___WindowSpanElementPrototype, false);

            CHtmlElement ___WindowObjectElementPrototype = new CHtmlElement();
            ___WindowObjectElementPrototype.___multiversalClassType = IMutilversalObjectType.HTMLObjectElement;
            ___WindowObjectElementPrototype.___SetTagNameOnly("OBJECT");
            ___WindowObjectElementPrototype.___elementTagType = CHtmlElementType.OBJECT;
            ___WindowObjectElementPrototype.___IsPrototype = true;
            ___WindowObjectElementPrototype.parentNode = ___HTMLElementPrototype;
            ___HTMLElementPrototype.___childNodes.Add(___WindowObjectElementPrototype);
            rootPrototypeNode.___HTMLObjectElementPrototypeWeakReference = new WeakReference(___WindowObjectElementPrototype, false);

            CHtmlElement ___WindowStyleElementPrototype = new CHtmlElement();
            ___WindowStyleElementPrototype.___multiversalClassType = IMutilversalObjectType.HTMLStyleElement;
            ___WindowStyleElementPrototype.___SetTagNameOnly("STYLE");
            ___WindowStyleElementPrototype.___elementTagType = CHtmlElementType.STYLE;
            ___WindowStyleElementPrototype.___IsPrototype = true;
            ___WindowStyleElementPrototype.parentNode = ___HTMLElementPrototype;
            ___HTMLElementPrototype.___childNodes.Add(___WindowStyleElementPrototype);
            rootPrototypeNode.___HTMLStyleElementPrototypeWeakReference = new WeakReference(___WindowStyleElementPrototype, false);

            CHtmlElement ___WindowTemplateElementPrototype = new CHtmlElement();
            ___WindowTemplateElementPrototype.___multiversalClassType = IMutilversalObjectType.HTMLTemplateElement;
            ___WindowTemplateElementPrototype.___SetTagNameOnly("TEMPLATE");
            ___WindowTemplateElementPrototype.___elementTagType = CHtmlElementType.TEMPLATE;
            ___WindowTemplateElementPrototype.___IsPrototype = true;
            ___WindowTemplateElementPrototype.parentNode = ___HTMLElementPrototype;
            ___HTMLElementPrototype.___childNodes.Add(___WindowTemplateElementPrototype);
            rootPrototypeNode.___HTMLTemplateElementPrototypeWeakReference = new WeakReference(___WindowTemplateElementPrototype, false);

            CHtmlElement ___WindowAreaElementPrototype = new CHtmlElement();
            ___WindowAreaElementPrototype.___multiversalClassType = IMutilversalObjectType.HTMLAreaElement;
            ___WindowAreaElementPrototype.___SetTagNameOnly("AREA");
            ___WindowAreaElementPrototype.___elementTagType = CHtmlElementType.AREA;
            ___WindowAreaElementPrototype.___IsPrototype = true;
            ___WindowAreaElementPrototype.parentNode = ___HTMLElementPrototype;
            ___HTMLElementPrototype.___childNodes.Add(___WindowAreaElementPrototype);
            rootPrototypeNode.___HTMLAreaElementPrototypeWeakReference = new WeakReference(___WindowAreaElementPrototype, false);

            CHtmlSVGElement ___WindowSVGElementPrototype = new CHtmlSVGElement();
            ___WindowSVGElementPrototype.___multiversalClassType = IMutilversalObjectType.SVGElement;
            ___WindowSVGElementPrototype.___SetTagNameOnly("SVG");
            ___WindowSVGElementPrototype.___elementTagType = CHtmlElementType.SVG;
            ___WindowSVGElementPrototype.___IsPrototype = true;
            ___WindowSVGElementPrototype.parentNode = ___HTMLElementPrototype;
            ___HTMLElementPrototype.___childNodes.Add(___WindowSVGElementPrototype);
            rootPrototypeNode.___SVGElementPrototypeWeakReference = new WeakReference(___WindowSVGElementPrototype, false);

            CHtmlElement ___WindowHTMLDatalistElementPrototype = new CHtmlElement();
            ___WindowHTMLDatalistElementPrototype.___multiversalClassType = IMutilversalObjectType.HTMLDataListElement;
            ___WindowHTMLDatalistElementPrototype.___SetTagNameOnly("DATALIST");
            ___WindowHTMLDatalistElementPrototype.___elementTagType = CHtmlElementType.DATALIST;
            ___WindowHTMLDatalistElementPrototype.___IsPrototype = true;
            ___WindowHTMLDatalistElementPrototype.parentNode = ___HTMLElementPrototype;
            ___HTMLElementPrototype.___childNodes.Add(___WindowHTMLDatalistElementPrototype);
            rootPrototypeNode.___HTMLDataListPrototypeWeakReference = new WeakReference(___WindowHTMLDatalistElementPrototype, false);

            // HTMLPictureElement
            CHtmlElement ___WindowHTMLPictureElementPrototype = new CHtmlElement();
            ___WindowHTMLPictureElementPrototype.___multiversalClassType = IMutilversalObjectType.HTMLPictureElement;
            ___WindowHTMLPictureElementPrototype.___SetTagNameOnly("PICTURE");
            ___WindowHTMLPictureElementPrototype.___elementTagType = CHtmlElementType.PICTURE;
            ___WindowHTMLPictureElementPrototype.___IsPrototype = true;
            ___WindowHTMLPictureElementPrototype.parentNode = ___HTMLElementPrototype;
            ___HTMLElementPrototype.___childNodes.Add(___WindowHTMLPictureElementPrototype);
            rootPrototypeNode.___HTMLPictureElementPrototypeWeakReference = new WeakReference(___WindowHTMLPictureElementPrototype, false);

            ___WindowEventPrototype = new CHtmlWindowEvent();
            ___WindowEventPrototype.___multiversalClassType = IMutilversalObjectType.Event;
            ___WindowEventPrototype.___eventSourceType = CHtmlWindowEvent.CHtmlWindowEventEventType.prototype;
            ___WindowEventPrototype.___IsPrototype = true;
            rootPrototypeNode.___childNodes.Add(___WindowEventPrototype);
            rootPrototypeNode.___EventPrototypeWeakReference = new WeakReference(___WindowEventPrototype, false);

            ___WindowMouseEventPrototype = new CHtmlWindowEvent();
            ___WindowMouseEventPrototype.___multiversalClassType = IMutilversalObjectType.MouseEvent;
            ___WindowMouseEventPrototype.___eventSourceType = CHtmlWindowEvent.CHtmlWindowEventEventType.prototypeMouseEvent;
            ___WindowMouseEventPrototype.___IsPrototype = true;
            rootPrototypeNode.___childNodes.Add(___WindowMouseEventPrototype);
            rootPrototypeNode.___MouseEventPrototypeWeakReference = new WeakReference(___WindowMouseEventPrototype, false);


            ___WindowStylePrototype = new CHtmlCSSStyleSheet(CHtmlElementStyleType.Prototype);
            ___WindowStyleElementPrototype.___multiversalClassType = IMutilversalObjectType.CSSStyleSheet;

            ___WindowStylePrototype.___IsPrototype = true;
            rootPrototypeNode.___childNodes.Add(___WindowStylePrototype);
            rootPrototypeNode.___StyleSheetPrototypeWeakReference = new WeakReference(___WindowStylePrototype, false);


            ___WindowCanvasContextPrototype = new CHtmlCanvasContext(true);
            ___WindowCanvasContextPrototype.___multiversalClassType = IMutilversalObjectType.CanvasRenderingContext2D;

            ___WindowCanvasContextPrototype.___IsPrototype = true;

            rootPrototypeNode.___childNodes.Add(___WindowCanvasContextPrototype);
            rootPrototypeNode.___CanvasContextPrototypeWeakReference = new WeakReference(___WindowCanvasContextPrototype, false);



            ___WindowCanvasExtenstionPrototype = new CHtmlCanvasContextExtenstionObject(CanvasExtentionObjectType.UNKNOWN);
            ___WindowCanvasExtenstionPrototype.___IsPrototype = true;
            rootPrototypeNode.___childNodes.Add(___WindowCanvasExtenstionPrototype);
            ___WindowCSSRulePrototype = new CHtmlCSSRule(CHtmlElementStyleType.Prototype);
            ___WindowCSSRulePrototype.___IsPrototype = true;

            ___WindowCSSStyleSheetPrototype = new CHtmlCSSStyleSheet(CHtmlElementStyleType.Prototype);
            ___WindowCSSStyleSheetPrototype.___IsPrototype = true;
            rootPrototypeNode.___childNodes.Add(___WindowCSSStyleSheetPrototype);
            rootPrototypeNode.___CSSStyleSheetPrototypeWeakReference = new WeakReference(___WindowCSSRulePrototype, false);

            CHtmlNativeArray ___arrayBufferPrototype = new CHtmlNativeArray(CHtmlNumericArrayType.ArrayBuffer, true);
            ___arrayBufferPrototype.___IsPrototype = true;
            rootPrototypeNode.___childNodes.Add(___arrayBufferPrototype);
            rootPrototypeNode.___ArrayBufferPrototypeWeakReference = new WeakReference(___arrayBufferPrototype, false);

            CHtmlNativeArray ___typedArrayPrototype = new CHtmlNativeArray(CHtmlNumericArrayType.TypedArray, true);
            ___typedArrayPrototype.___IsPrototype = true;
            rootPrototypeNode.___childNodes.Add(___typedArrayPrototype);
            rootPrototypeNode.___TypedArrayPrototypeWeakReference = new WeakReference(___typedArrayPrototype, false);

            CHtmlNativeArray ___float32ArrayPrototype = new CHtmlNativeArray(CHtmlNumericArrayType.Float32Array, true);
            ___float32ArrayPrototype.___IsPrototype = true;
            rootPrototypeNode.___childNodes.Add(___float32ArrayPrototype);
            rootPrototypeNode.___Float32ArrayPrototypeWeakReference = new WeakReference(___float32ArrayPrototype, false);

            CHtmlNativeArray ___float64ArrayPrototype = new CHtmlNativeArray(CHtmlNumericArrayType.Float64Array, true);
            ___float64ArrayPrototype.___IsPrototype = true;
            rootPrototypeNode.___childNodes.Add(___float64ArrayPrototype);
            rootPrototypeNode.___Float64ArrayPrototypeWeakReference = new WeakReference(___float64ArrayPrototype, false);

            CHtmlNativeArray ___int8ArrayPrototype = new CHtmlNativeArray(CHtmlNumericArrayType.Int8Array, true);
            ___int8ArrayPrototype.___IsPrototype = true;
            rootPrototypeNode.___childNodes.Add(___int8ArrayPrototype);
            rootPrototypeNode.___Int8ArrayPrototypeWeakReference = new WeakReference(___int8ArrayPrototype, false);

            CHtmlNativeArray ___int16ArrayPrototype = new CHtmlNativeArray(CHtmlNumericArrayType.Int16Array, true);
            ___int16ArrayPrototype.___IsPrototype = true;
            rootPrototypeNode.___childNodes.Add(___int16ArrayPrototype);
            rootPrototypeNode.___Int16ArrayPrototypeWeakReference = new WeakReference(___int16ArrayPrototype, false);

            CHtmlNativeArray ___int32ArrayPrototype = new CHtmlNativeArray(CHtmlNumericArrayType.Int32Array, true);
            ___int32ArrayPrototype.___IsPrototype = true;
            rootPrototypeNode.___childNodes.Add(___int32ArrayPrototype);
            rootPrototypeNode.___Int32ArrayPrototypeWeakReference = new WeakReference(___int32ArrayPrototype, false);

            CHtmlNativeArray ___uint8ArrayPrototype = new CHtmlNativeArray(CHtmlNumericArrayType.Uint8Array, true);
            ___uint8ArrayPrototype.___IsPrototype = true;
            rootPrototypeNode.___childNodes.Add(___uint8ArrayPrototype);
            rootPrototypeNode.___Uint8ArrayPrototypeWeakReference = new WeakReference(___uint8ArrayPrototype, false);

            CHtmlNativeArray ___uint16ArrayPrototype = new CHtmlNativeArray(CHtmlNumericArrayType.Uint16Array, true);
            ___uint16ArrayPrototype.___IsPrototype = true;
            rootPrototypeNode.___childNodes.Add(___uint16ArrayPrototype);
            rootPrototypeNode.___Uint16ArrayPrototypeWeakReference = new WeakReference(___uint16ArrayPrototype, false);

            #region WebSpeechAPI
            CHtmlNativeArray ___uint32ArrayPrototype = new CHtmlNativeArray(CHtmlNumericArrayType.Uint32Array, true);
            ___uint32ArrayPrototype.___IsPrototype = true;
            rootPrototypeNode.___childNodes.Add(___uint32ArrayPrototype);
            rootPrototypeNode.___Uint32ArrayPrototypeWeakReference = new WeakReference(___uint32ArrayPrototype, false);

            CHtmlWebSpeechSynthesisUtterance ___speechSynthesisUtterance = new CHtmlWebSpeechSynthesisUtterance();
            ___speechSynthesisUtterance.___IsPrototype = true;
            rootPrototypeNode.___childNodes.Add(___speechSynthesisUtterance);
            rootPrototypeNode.___WebSpeechSynthesisUtterranceWeakReference = new WeakReference(___speechSynthesisUtterance, false);

            CHtmlWebSpeechRecognition ___speechRecognition = new CHtmlWebSpeechRecognition();
            ___speechRecognition.___IsPrototype = true;
            rootPrototypeNode.___childNodes.Add(___speechRecognition);
            rootPrototypeNode.___WebSpeechRecognitionWeakReference = new WeakReference(___speechRecognition, false);

            CHtmlWebSpeechRecognitionEvent ___speechRecognitionEvent = new CHtmlWebSpeechRecognitionEvent();
            ___speechRecognitionEvent.___IsPrototype = true;
            rootPrototypeNode.___childNodes.Add(___speechRecognitionEvent);
            rootPrototypeNode.___WebSpeechRecognitionEventWeakReference = new WeakReference(___speechRecognitionEvent, false);

            CHtmlWebSpeechGrammar ___speechGrammar = new CHtmlWebSpeechGrammar();
            ___speechGrammar.___IsPrototype = true;
            rootPrototypeNode.___childNodes.Add(___speechGrammar);
            rootPrototypeNode.___WebSpeechGrammarWeakReference = new WeakReference(___speechGrammar, false);

            CHtmlWebSpeechGrammarList ___speechGrammarList = new CHtmlWebSpeechGrammarList();
            ___speechGrammar.___IsPrototype = true;
            rootPrototypeNode.___childNodes.Add(___speechGrammar);
            rootPrototypeNode.___WebSpeechGrammarWeakReference = new WeakReference(___speechGrammar, false);

            #endregion





            CHtmlMultiversalLightweightPrototypeContainer ___windowPrototype = new CHtmlMultiversalLightweightPrototypeContainer();
            ___windowPrototype.___prototypeName = "Window";
            ___windowPrototype.___multiversalClassType = IMutilversalObjectType.Window;
            ___windowPrototype.___IsPrototype = true;
            rootPrototypeNode.___childNodes.Add(___windowPrototype);
            rootPrototypeNode.___WindowPrototypeWeakReference = new WeakReference(___windowPrototype, false);

            CHtmlMultiversalLightweightPrototypeContainer ___windowDomStringMapPrototype = new CHtmlMultiversalLightweightPrototypeContainer();
            ___windowDomStringMapPrototype.___prototypeName = "DOMStringMap";
            ___windowDomStringMapPrototype.___multiversalClassType = IMutilversalObjectType.DOMStringMap;
            ___windowDomStringMapPrototype.___IsPrototype = true;
            rootPrototypeNode.___childNodes.Add(___windowDomStringMapPrototype);
            rootPrototypeNode.___DOMStringMapWeakReference = new WeakReference(___windowDomStringMapPrototype, false);

            CHtmlDocument ___documentPrototype = new CHtmlDocument(CHtmlDomModeType.HTMLDOM_NoGUI);
            ___documentPrototype.___IsPrototype = true;
            ___documentPrototype.___multiversalClassType = IMutilversalObjectType.Document;
            rootPrototypeNode.___childNodes.Add(___documentPrototype);
            rootPrototypeNode.___DocumentPrototypeWeakReference = new WeakReference(___documentPrototype, false);


            CHtmlMultiversalLightweightPrototypeContainer ___workerPrototype = new CHtmlMultiversalLightweightPrototypeContainer();
            ___workerPrototype.___prototypeName = "Worker";
            ___workerPrototype.___multiversalClassType = IMutilversalObjectType.Worker;
            ___workerPrototype.___IsPrototype = true;
            rootPrototypeNode.___childNodes.Add(___workerPrototype);
            rootPrototypeNode.___WorkerPrototypeWeakReference = new WeakReference(___workerPrototype, false);

            CHtmlMultiversalLightweightPrototypeContainer ___sharedWorkerPrototype = new CHtmlMultiversalLightweightPrototypeContainer();
            ___sharedWorkerPrototype.___prototypeName = "SharedWorker";
            ___sharedWorkerPrototype.___multiversalClassType = IMutilversalObjectType.SharedWorker;
            ___sharedWorkerPrototype.___IsPrototype = true;
            rootPrototypeNode.___childNodes.Add(___sharedWorkerPrototype);
            rootPrototypeNode.___SharedWorkerPrototypeWeakReference = new WeakReference(___sharedWorkerPrototype, false);

            CHtmlClassList ___domtokenListPrototype = new CHtmlClassList();
            ___domtokenListPrototype.___IsPrototype = true;
            ___domtokenListPrototype.___multiversalClassType = IMutilversalObjectType.DOMTokenList;
            rootPrototypeNode.___childNodes.Add(___domtokenListPrototype);
            rootPrototypeNode.___DOMTokenListWeakReference = new WeakReference(___domtokenListPrototype, false);

            CHtmlElement ___activeXObjectPrototype = new CHtmlElement();
            ___activeXObjectPrototype.___SetTagNameOnly("Object");
            ___activeXObjectPrototype.___elementTagType = CHtmlElementType.OBJECT;
            ___activeXObjectPrototype.___multiversalClassType = IMutilversalObjectType.HTMLObjectElement;
            ___activeXObjectPrototype.___IsPrototype = true;
            rootPrototypeNode.___childNodes.Add(___activeXObjectPrototype);
            rootPrototypeNode.___ActiveXObjectPrototypeWeakReference = new WeakReference(___activeXObjectPrototype, false);

            CHtmlWebFile ___filePrototype = new CHtmlWebFile();

            ___filePrototype.___IsPrototype = true;
            ___filePrototype.___multiversalClassType = IMutilversalObjectType.File;
            rootPrototypeNode.___childNodes.Add(___filePrototype);
            rootPrototypeNode.___FilePrototypeWeakReference = new WeakReference(___filePrototype, false);

            CHtmlFileReader ___fileReaderPrototype = new CHtmlFileReader();
            ___fileReaderPrototype.___IsPrototype = true;
            ___fileReaderPrototype.___multiversalClassType = IMutilversalObjectType.FileReader;
            rootPrototypeNode.___childNodes.Add(___fileReaderPrototype);
            rootPrototypeNode.___FileReaderPrototypeWeakReference = new WeakReference(___fileReaderPrototype, false);

            CHtmlMultiversalLightweightPrototypeContainer timeRangesPrototype = new CHtmlMultiversalLightweightPrototypeContainer();
            timeRangesPrototype.___multiversalClassType = IMutilversalObjectType.TimeRanges;
            timeRangesPrototype.___IsPrototype = true;
            rootPrototypeNode.___childNodes.Add(timeRangesPrototype);
            rootPrototypeNode.___TimeRangesPrototypeWeakReference = new WeakReference(timeRangesPrototype, false);
            CHtmlFileList ___fileListPrototype = new CHtmlFileList();
            ___filePrototype.___IsPrototype = true;
            rootPrototypeNode.___childNodes.Add(___filePrototype);
            rootPrototypeNode.___FileListProtoTypeWeakReference = new WeakReference(___filePrototype, false);

            CHtmlBlob ___blobPrototype = new CHtmlBlob();
            ___blobPrototype.___multiversalClassType = IMutilversalObjectType.Blob;
            ___blobPrototype.___IsPrototype = true;
            rootPrototypeNode.___childNodes.Add(___blobPrototype);
            rootPrototypeNode.___BlobPrototypeWeakReference = new WeakReference(___blobPrototype, false);

            return rootPrototypeNode;
        }
        internal void ___assignElementPrototype(CHtmlElement ___element)
        {
            try
            {
                switch (___element.___elementTagType)
                {

                    case CHtmlElementType.AUDIO:
                        ___element.___prototypeWeakReference = this.___WindowPrototypeRootNode.___HTMLAudioElementPrototypeWeakReference;
                        break;
                    case CHtmlElementType.VIDEO:
                        ___element.___prototypeWeakReference = this.___WindowPrototypeRootNode.___HTMLVideoElementPrototypeWeakReference;
                        break;
                    case CHtmlElementType.CANVAS:
                        ___element.___prototypeWeakReference = this.___WindowPrototypeRootNode.___HTMLCanvasElementPrototypeWeakReference;
                        break;
                    case CHtmlElementType.IMG:
                        ___element.___prototypeWeakReference = this.___WindowPrototypeRootNode.___HTMLImageElementPrototypeWeakReference;
                        break;
                    case CHtmlElementType.TABLE:
                        ___element.___prototypeWeakReference = this.___WindowPrototypeRootNode.___HTMLTableElementPrototypeWeakReference;
                        break;
                    case CHtmlElementType.TR:
                        ___element.___prototypeWeakReference = this.___WindowPrototypeRootNode.___HTMLTableRowElementPrototypeWeakReference;
                        break;
                    case CHtmlElementType.TD:
                        ___element.___prototypeWeakReference = this.___WindowPrototypeRootNode.___HTMLTableCellElementPrototypeWeakReference;
                        break;
                    case CHtmlElementType.HTML:
                        ___element.___prototypeWeakReference = this.___WindowPrototypeRootNode.___HTMLHtmlElementPrototypeWeakReference;
                        break;
                    case CHtmlElementType.BODY:
                        ___element.___prototypeWeakReference = this.___WindowPrototypeRootNode.___HTMLBodyElementPrototypeWeakReference;
                        break;
                    case CHtmlElementType.HEAD:
                        ___element.___prototypeWeakReference = this.___WindowPrototypeRootNode.___HTMLHeadElementPrototypeWeakReference;
                        break;
                    case CHtmlElementType.LINK:
                        ___element.___prototypeWeakReference = this.___WindowPrototypeRootNode.___HTMLLinkElementPrototypeWeakReference;
                        break;
                    case CHtmlElementType.A:
                        ___element.___prototypeWeakReference = this.___WindowPrototypeRootNode.___HTMLAnchorElementPrototypeWeakReference;
                        break;
                    case CHtmlElementType.SCRIPT:
                        ___element.___prototypeWeakReference = this.___WindowPrototypeRootNode.___HTMLScriptElementPrototypeWeakReference;
                        break;
                    case CHtmlElementType.IFRAME:
                        ___element.___prototypeWeakReference = this.___WindowPrototypeRootNode.___HTMLIFrameElementPrototypeWeakReference;
                        break;
                    case CHtmlElementType.FORM:
                        ___element.___prototypeWeakReference = this.___WindowPrototypeRootNode.___HTMLFormElementPrototypeWeakReference;
                        break;
                    case CHtmlElementType.DIV:
                        ___element.___prototypeWeakReference = this.___WindowPrototypeRootNode.___HTMLDivElementPrototypeWeakReference;
                        break;
                    case CHtmlElementType.SPAN:
                        ___element.___prototypeWeakReference = this.___WindowPrototypeRootNode.___HTMLSpanElementPrototypeWeakReference;
                        break;
                    case CHtmlElementType.TEXTAREA:
                        ___element.___prototypeWeakReference = this.___WindowPrototypeRootNode.___HTMLTextAreaElementPrototypeWeakReference;
                        break;
                    case CHtmlElementType.INPUT:
                        ___element.___prototypeWeakReference = this.___WindowPrototypeRootNode.___HTMLInputElementPrototypeWeakReference;
                        break;
                    case CHtmlElementType.OPTION:
                        ___element.___prototypeWeakReference = this.___WindowPrototypeRootNode.___HTMLOptionElementPrototypeWeakReference;
                        break;
                    case CHtmlElementType.STYLE:
                        ___element.___prototypeWeakReference = this.___WindowPrototypeRootNode.___HTMLStyleElementPrototypeWeakReference;
                        break;
                }
            }
            catch
            {
                if (commonLog.LoggingEnabled)
                {
                   commonLog.LogEntry("BUGBUG! Can not assign prototoype {0}", ___element.___elementTagType);
                }
            }
            if (___element.___prototypeWeakReference == null)
            {
                ___element.___prototypeWeakReference = this.___WindowPrototypeRootNode.___HTMLElementPrototypeWeakReference;
            }
        }

   
        private void MultiversalTimer_Elapsed(object _o)
        {
            int ValidScriptCount = 0;
            DateTime ___dtStart = DateTime.Now;

            try
            {
                if (this.___document == null || this.___document.___Disposing)
                {
                    this.___MultiversalTimer.Dispose();
                    this.___MultiversalTimer = null;
                    return;
                }
                if (this.___MultiversalTimer != null)
                {
                    this.___MultiversalTimer.Change(System.Threading.Timeout.Infinite, System.Threading.Timeout.Infinite);
                }

                ValidScriptCount = 0;
                ___dtStart = DateTime.Now;
                if (this.___MultiversalTimer == null)
                {
                    goto TimerProcessDone;
                }
                if (this.___document.___documentTimerTickCount >= int.MaxValue)
                {
                    this.___document.___documentTimerTickCount = 10000;
                }
                this.___document.___documentTimerTickCount++;

                try
                {
                    if (this == null || this.___IsDispoing == true || this.___document.___IsDocumentTimerTooksTooLong == true || this.___document.___DisableDocumentTimer == true || this.___document.___IsThreadAbortOccurred == true)
                    {
                        try
                        {
                            if (this.___MultiversalTimer != null)
                            {
                                try
                                {
                                    this.___MultiversalTimer.Dispose();
                                }
                                catch { }
                                finally
                                {

                                    this.___MultiversalTimer = null;
                                    this.___document.___DocumentTimerMimimunIntervalOrTimeout = int.MaxValue;
                                }
                            }
                        }
                        catch { }
                        goto TimerProcessDone;

                    }
                    // it may be enqueued scripts on queue which remains unprocessed status 
                    // only runs if document.readystate = complete
                    if (this.___document.___readyStateType == CHtmlReadytStateType.complete)
                    {
                        if (this.___document.___DeferredEnqueuedScriptCount > 0)
                        {
                            try
                            {

                                if (commonLog.LoggingEnabled && commonLog.CommonLogLevel >= 8)
                                {
                                    commonLog.LogEntry("DocumentTimer has found Queued Script Process Now...");
                                }
                                //this.___processDocumentEnqueuedScripts(EnqeueStatus.ProcessQueue);
                            }
                            catch { }
                        }
                    }
                    if (this.___document.___DocumentTimerBrandNewIDList != null && this.___document.___DocumentTimerBrandNewIDList.Count > 0)
                    {
                        this.___document.___DocumentTimerBrandNewIDList.Clear();
                    }

                    // [Do not use property value always use .Count
                    //int __CurrentEventCount =  this.___DocumentTimerLiveList.Count;
                    // 
                    CHtmlEventInfo timerEvt = null;
                    TimeSpan timerElapsed;
                    for (int i = this.___document.___DocumentTimerLiveList.Count - 1; i >= 0; i--)
                    {
                        if (this == null || this.___document.___Disposing == true || this.___document.___IsThreadAbortOccurred)
                        {
                            try
                            {
                                if (this.___MultiversalTimer != null)
                                {
                                    this.___MultiversalTimer = null;
                                }
                            }
                            catch { }


                            goto TimerProcessDone;
                        }
                        int ___timerkey = this.___document.___DocumentTimerLiveList.Keys[i];
                        if (this.___document.___DocumentTimerBrandNewIDList.ContainsKey(___timerkey))
                        {
                            // It is new created event list. do not execute one.
                            continue;
                        }

                        this.___document.___DocumentTimerLiveList.TryGetValue(___timerkey, out timerEvt);
                        bool ___IsInterval = false;
                        bool ___IsTimeout = false;
                        bool ___IsEventHasBeenFromLiveList = false;
                        if (timerEvt == null || timerEvt.TimerType == -1)
                            continue;
                        else
                        {
                            if (timerEvt.TimerType == 10)
                            {
                                if (timerEvt.IsCompleted == false)
                                {
                                    ___IsTimeout = true;
                                    ValidScriptCount++;
                                }
                            }
                            else if (timerEvt.TimerType == 1)
                            {
                                if (timerEvt.IsCompleted == false)
                                {
                                    ___IsInterval = true;
                                    ValidScriptCount++;
                                }
                            }
                            else
                            {
                                continue;
                            }
                        }
                        if (___IsTimeout == true && timerEvt.IsCompleted == false)
                        {
                            timerElapsed = DateTime.Now.Subtract(timerEvt.LastCallTime);
                            if (Math.Abs(timerElapsed.TotalMilliseconds) > timerEvt.Timeout)
                            {
                                CHtmlScriptResultElement scriptResult = null;
                                if (commonHTML.MAX_EVENT_RECORD_COUNT < this.___document.___scriptEventList.Count)
                                {

                                }
                                else
                                {


                                    scriptResult = new CHtmlScriptResultElement();

                                    scriptResult.text = string.Concat(timerEvt.Name, ' ', timerEvt, ' ', timerEvt.GetHashCode());
                                }
                                object objFunction = timerEvt.Function;
                                try
                                {
                                    //this.___processTimerScriptOrFunction(objFunction);
                                    if (scriptResult != null)
                                    {
                                        scriptResult.result = 200;
                                    }


                                }
                                catch (Exception ex)
                                {
                                    if (scriptResult != null)
                                    {
                                        scriptResult.result = 500;

                                        scriptResult.resultText = "Timer Function Error " + timerEvt.ToString() + " Compile Error " + ex.Message.ToString();
                                        scriptResult.errorDetail = commonData.GetExceptionAsString(ex);

                                    }
                                }
                                if (scriptResult != null)
                                {
                                    if (commonHTML.MAX_EVENT_RECORD_COUNT > this.___document.___scriptEventList.Count)
                                    {
                                        this.___document.___scriptEventList.Add(scriptResult);
                                    }
                                }
                                else
                                {

                                }

                                timerEvt.LastCallTime = DateTime.Now;
                                timerEvt.IsCompleted = true;
                                while (this.___document.___DocumentTimerCompleteList.Count > commonHTML.MAX_TIMER_COPLETE_RECORD_COUNT)
                                {
                                    this.___document.___DocumentTimerCompleteList.RemoveAt(0);
                                }
                                this.___document.___DocumentTimerCompleteList.Add(timerEvt);
                                if (___IsTimeout == true)
                                {
                                    if (___IsEventHasBeenFromLiveList == false)
                                    {
                                        if (commonLog.LoggingEnabled &&commonLog.CommonLogLevel >= 1000)
                                        {
                                           commonLog.LogEntry("DocumentTimerLiveList Removing : {0}", ___timerkey);
                                        }

                                        this.___document.___DocumentTimerLiveList.Remove(___timerkey);

                                    }
                                }

                            }
                            continue;
                        }
                        if (___IsInterval == true && timerEvt.IsCompleted == false)
                        {
                            timerElapsed = DateTime.Now.Subtract(timerEvt.LastCallTime);
                            if (Math.Abs(timerElapsed.TotalMilliseconds) > timerEvt.Timeout)
                            {
                                bool __IntervalSuccess = false;
                                CHtmlScriptResultElement scriptResult = null;
                                if (commonHTML.MAX_EVENT_RECORD_COUNT < this.___document.___scriptEventList.Count)
                                {

                                }
                                else
                                {
                                    scriptResult = new CHtmlScriptResultElement();
                                    scriptResult.text = string.Concat(timerEvt.Name, ' ', timerEvt, ' ', timerEvt.GetHashCode());
                                    scriptResult.href = this.___document.___URL;
                                }

                                object objFunction = timerEvt.Function;

                                try
                                {
                                    ///this.___processTimerScriptOrFunction(objFunction);
                                    scriptResult.result = 200;
                                }
                                catch (Exception ex)
                                {
                                    __IntervalSuccess = false;
                                    if (scriptResult != null)
                                    {
                                        scriptResult.result = 500;


                                        scriptResult.resultText = string.Format("Script Onload Segment '{0}' Compile Error {1}", timerEvt, ex.Message);

                                    }
                                }
                                if (scriptResult != null)
                                {
                                    if (commonHTML.MAX_EVENT_RECORD_COUNT > this.___document.___scriptEventList.Count)
                                    {
                                        this.___document.___scriptEventList.Add(scriptResult);
                                    }
                                }

                                if (__IntervalSuccess == true)
                                {
                                    timerEvt.LastCallTime = DateTime.Now;
                                    // Do not set is Complete here because timer may cleared during script
                                    //timerEvt.IsCompleted = false;
                                }
                                else
                                {
                                    // If it is unsuccessfull , it complete to true no more exection
                                    timerEvt.LastCallTime = DateTime.Now;
                                    timerEvt.IsCompleted = true;
                                    while (this.___document.___DocumentTimerCompleteList.Count > commonHTML.MAX_TIMER_COPLETE_RECORD_COUNT)
                                    {
                                        this.___document.___DocumentTimerCompleteList.RemoveAt(0);
                                    }
                                    this.___document.___DocumentTimerCompleteList.Add(timerEvt);
                                    if (commonLog.LoggingEnabled &&commonLog.CommonLogLevel >= 1000)
                                    {
                                       commonLog.LogEntry("DocumentTimerLiveList Removing : {0}", ___timerkey);
                                    }

                                    this.___document.___DocumentTimerLiveList.Remove(___timerkey);
                                }
                            }
                            continue;
                        }

                    }
                }
                catch (Exception ex)
                {
                    if (commonLog.LoggingEnabled && commonLog.CommonLogLevel >= 5)
                    {
                        commonLog.LogEntry("DocumentTimer_Elapsed Error. ", ex);
                    }
                }

                this.___document.___DrawCanvasCreatedElements();


                if (ValidScriptCount == 0)
                {
                    if (this.___document.___documentTimerTickCount >= 5)
                    {
                        if (this.___document.___DocumentTimerLiveList != null && this.___document.___DocumentTimerLiveList.Count > 0)
                        {
                            goto TimerProcessDone;
                        }
                        if (commonLog.LoggingEnabled && commonLog.CommonLogLevel >= 3)
                        {
                            commonLog.LogEntry("No Event DocumentTimer should process...");
                        }
                        if (this.___MultiversalTimer != null)
                        {
                            this.___MultiversalTimer.Dispose();
                            this.___MultiversalTimer = null;
                        }
                        this.___document.StoreCookieListIfUpdated();
                        goto TimerProcessDone;
                    }

                }
                else
                {
                    TimeSpan tpSpan = DateTime.Now.Subtract(___dtStart);
                    if (tpSpan.TotalSeconds >= commonHTML.MAX_DOCUMENT_TIMER_TIMEOUT_SECONDS)
                    {
                        if (commonLog.LoggingEnabled && commonLog.CommonLogLevel >= 10)
                        {
                            commonLog.LogEntry("DocumentTimer tooks long to complete. Disable Doucument Timer From now on...");
                        }

                        try
                        {

                            if (this.___MultiversalTimer != null)
                            {
                                this.___MultiversalTimer.Dispose();
                                this.___MultiversalTimer = null;
                            }
                            this.___document.StoreCookieListIfUpdated();
                        }
                        catch { }

                        goto TimerProcessDone;
                    }
                    else
                    {
                        // There is timer to process

                    }
                }
                //WaitForNextLoop:
                if (this == null || this.___IsDispoing == true || this.___document == null || this.___MultiversalTimer == null)
                {
                    goto TimerProcessDone;
                }




                TimerProcessDone:
                if (false) {; }
            }
            catch (System.Threading.ThreadAbortException)
            {
                // just cont

            }
            catch (Exception ex)
            {
                if (ex is System.Threading.ThreadAbortException)
                {
                    if (commonLog.LoggingEnabled && commonLog.CommonLogLevel >= 30)
                    {
                        commonLog.LogEntry("DocumentTimerThread_Elapsed Thread Abort. It is ok!");
                    }

                }
                else if (commonLog.LoggingEnabled && commonLog.CommonLogLevel >= 5)
                {
                    commonLog.LogEntry("DocumentTimerThread_Elapsed", ex);
                }
            }
        }
        /// <summary>
        /// Set true to support ActiveXObject for IE.
        /// default: false
        /// </summary>
        /// <param name="___enabled"></param>
        public static void ___enableActiveXObjectSupportAsGlobal(bool ___enabled)
        {
            ___isActiveXObjectSupportedGlobal = ___enabled;
        }
        public void ___enableActiveXObjectSupportThisWindow(bool ___enabled)
        {
            this.___isActiveXObjectSupportedThisWindow = ___enabled;
        }
        /*
        private void ___MultiversalTimerParentChildCreation_Tick(object ___object)
        {
            if (this.___MultiversalTimer == null)
            {
                return;
            }
            bool ___IsDocumentStatusNotReadyYet = false;
            bool ___IsOperationOnlyCreateControl = true;
            bool ___NeedsDiposeTimerAndExit = false;
            int ___SuccessControlCreateCount = 0;
            if (System.Threading.Monitor.TryEnter(this.___MultiversalTimerLockingObject, 500) == true)
            {
                try
                {

                    this.___MultiversalTimer.Change(System.Threading.Timeout.Infinite, System.Threading.Timeout.Infinite);


                    if (this.___IsDispoing == true)
                    {
                        ___NeedsDiposeTimerAndExit = true;
                    }
                    System.Windows.Forms.Control ___currentRenderingManagedControl = null;
                    if (this.___renderingTargetManagedControlWeakReference != null)
                    {
                        ___currentRenderingManagedControl = this.___renderingTargetManagedControlWeakReference.Target as System.Windows.Forms.Control;
                        if (___currentRenderingManagedControl != null)
                        {
                            if (___currentRenderingManagedControl.Disposing == true)
                            {
                                ___NeedsDiposeTimerAndExit = true;
                            }
                        }
                    }
                    try
                    {
                        if (___NeedsDiposeTimerAndExit == true)
                        {
                            if (this.___MultiversalTimer != null)
                            {
                                this.___MultiversalTimer.Dispose();
                                this.___MultiversalTimer = null;
                            }
                            return;
                        }

                    }
                    catch (Exception ex)
                    {
                        if (commonLog.LoggingEnabled)
                        {
                           commonLog.LogEntry("CHtmlMultiversalWinow Timer Dispose", ex);
                        }
                    }
                    int ___pendingCount = 0;

                    try
                    {
                        if (this.___ChildWindowControlCreationPendingList != null)
                        {
                            ___TimerControlCreatingPendingCount++;
                            if (commonLog.LoggingEnabled && commonLog.CommonLogLevel >= 10)
                            {
                                commonLog.LogEntry("There are {0} multiversal windows needs to be created", this.___ChildWindowControlCreationPendingList.Count);
                            }
                            Multiversal.IMultiversalHostingControlInterface ___targetRenderer = this.___renderingTargetManagedRendererStrongReference;
                            if (___targetRenderer == null && this.___renderingTargetManagedControlWeakReference != null)
                            {
                                ___targetRenderer = this.___renderingTargetManagedControlWeakReference.Target as Multiversal.IMultiversalHostingControlInterface;
                            }
                            if (___targetRenderer != null)
                            {
                                if (System.Threading.Monitor.TryEnter(this.___ChildWindowControlCreationPendingList_LockingObject, 5000))
                                {
                                    try
                                    {
                                        ___pendingCount = this.___ChildWindowControlCreationPendingList.Count;

                                        for (int i = ___pendingCount - 1; i >= 0; i--)
                                        {
                                            try
                                            {
                                                System.WeakReference ___chidWindowWeakRef = this.___ChildWindowControlCreationPendingList[i];
                                                if (___chidWindowWeakRef != null)
                                                {
                                                    CHtmlMultiversalWindow ___childMultiversalWindow = ___chidWindowWeakRef.Target as CHtmlMultiversalWindow;
                                                    if (___childMultiversalWindow != null)
                                                    {
                                                        if (___childMultiversalWindow.___ownerElementWeakReference != null)
                                                        {
                                                            CHtmlElement ___iframeElement = ___childMultiversalWindow.___ownerElementWeakReference.Target as CHtmlElement;
                                                            
                                                            if (___iframeElement != null)
                                                            {
                                                                if (___iframeElement.___IsDisposing == true)
                                                                {
                                                                    if (commonLog.LoggingEnabled && commonLog.CommonLogLevel >= 5)
                                                                    {
                                                                        commonLog.LogEntry("child element is disposing {0}. skipping now.", ___iframeElement);
                                                                    }
                                                                    this.___ChildWindowControlCreationPendingList.RemoveAt(i);
                                                                    continue;
                                                                }
                                                                if (___iframeElement.___Document != null && ___iframeElement.___Document.___readyStateType != CHtmlReadytStateType.complete && ___iframeElement.___Document.___DocumentPaintedCount < 1)
                                                                {
                                                                    ___IsDocumentStatusNotReadyYet = true;
                                                                    break;
                                                                }

                                                                Multiversal.createControlOnMultiversalWindowRendererDelegate createDelegate = new createControlOnMultiversalWindowRendererDelegate(___targetRenderer.createControl);
                                                                System.IAsyncResult __asyncResult = ((System.Windows.Forms.Control)___targetRenderer).BeginInvoke(createDelegate, new object[] { typeof(CHtmlMultiversalRenderer), "", (int)___iframeElement.offsetWidth, (int)___iframeElement.offsetHeight, ___iframeElement.___style.___BackgroundSysColor, ___iframeElement.___style.___ForegroundSysColor, true, true, false == ___iframeElement.___IsElementVisible, false });

                                                                object ___controlResult = ((System.Windows.Forms.Control)___targetRenderer).EndInvoke(__asyncResult);
                                                                if (___controlResult != null)
                                                                {
                                                                    ___SuccessControlCreateCount++;

                                                                    this.___ChildWindowControlCreationPendingList.RemoveAt(i);
                                                                    ___childMultiversalWindow.___renderingTargetManagedRendererStrongReference = ___controlResult as CHtmlMultiversalRenderer;
                                                                    ___childMultiversalWindow.___renderingTargetManagedControlWeakReference = new WeakReference(___controlResult, false);
                                                                    ___iframeElement.___ManagedControlWeakReference = new WeakReference(___controlResult, false);

                                                                    if (___childMultiversalWindow.___renderingTargetManagedRendererStrongReference != null)
                                                                    {
                                                                        ___childMultiversalWindow.___renderingTargetManagedRendererStrongReference.setMultiversalWindow(___childMultiversalWindow);
                                                                    }
                                                                    if (___controlResult is CHtmlMultiversalRenderer)
                                                                    {
                                                                        CHtmlMultiversalRenderer ___renderer = ___controlResult as CHtmlMultiversalRenderer;
                                                                        // ==============================================
                                                                        // Now Target Child Renderer (Iframe is created)
                                                                        // If document is complete. Create Child Control
                                                                        // ==============================================
                                                                        if (___renderer != null)
                                                                        {
                                                                            if (___childMultiversalWindow.___document != null)
                                                                            {
                                                                                CHtmlDocument ___doc = ___childMultiversalWindow.___document;
                                                                                if (___doc.___IsThreadAbortOccurred == false && ___doc.___Disposing == false && ___doc.___IsOnLoadWindowDocumentCompletedCalled == true)
                                                                                {
                                                                                    if (___doc.___ManagedControlPendingElementList != null && ___doc.___ManagedControlPendingElementList.Count > 0)
                                                                                    {
                                                                                        if (commonLog.LoggingEnabled && commonLog.CommonLogLevel >= 5)
                                                                                        {
                                                                                            commonLog.LogEntry("IFrame Window is created for {0} contains document {1} needs to create sub controls {2}", ___childMultiversalWindow, ___doc, ___doc.___ManagedControlPendingElementList.Count);
                                                                                        }
                                                                                        CHtmlMultiversalRenderer.CreateControlWithDocumentDelegate ___createControlInvoker = new CHtmlMultiversalRenderer.CreateControlWithDocumentDelegate(___renderer.createControlFromDocument);
                                                                                        ___renderer.BeginInvoke(___createControlInvoker, new object[] { ___doc });
                                                                                        // ___renderer.EndInvoke(___controlAsync);
                                                                                    }
                                                                                }

                                                                            }
                                                                        }
                                                                    }

                                                                }
                                                            }
                                                        }
                                                    }
                                                }

                                            }
                                            catch (Exception exControlAdd)
                                            {
                                                if (commonLog.LoggingEnabled && commonLog.CommonLogLevel >= 8)
                                                {
                                                    commonLog.LogEntry("MultiversalTimer_Tick Control Add Operation Exception", exControlAdd);
                                                    // it may failed to next operation. so remove it from list
                                                 
                                                 
                                                }
                                                this.___ChildWindowControlCreationPendingList.RemoveAt(i);
                                                continue;

                                            }


                                        }
                                    }

                                    catch (Exception exLoop)
                                    {
                                        if (commonLog.LoggingEnabled && commonLog.CommonLogLevel >= 8)
                                        {
                                            commonLog.LogEntry("MultiversalTimer_Tick Control Add Loop Exception", exLoop);
                                            // it may failed to next operation. so remove it from list

                                        }
                                    }
                                    finally
                                    {
                                        System.Threading.Monitor.Exit(this.___ChildWindowControlCreationPendingList_LockingObject);
                                    }
                                }
                            }
                            if (___SuccessControlCreateCount == ___pendingCount)
                            {
                                this.___ChildWindowControlCreationPendingList = null;
                                ___NeedsDiposeTimerAndExit = true;
                            }
                        }

                        if (___currentRenderingManagedControl != null)
                        {

                        }

                    }

                    catch
                    { }
                    finally
                    {
                        if (this.___MultiversalTimer != null)
                        {
                            if (___NeedsDiposeTimerAndExit == true)
                            {
                                this.___MultiversalTimer.Dispose();
                                this.___MultiversalTimer = null;
                            }
                            if (this.___MultiversalTimer != null)
                            {

                                if (___TimerControlCreatingPendingCount > CHtmlMultiversalWindow.___MultiversalTimerControlIntervalArray.Length - 1)
                                {

                                    if (commonLog.LoggingEnabled && commonLog.CommonLogLevel >= 8)
                                    {
                                        commonLog.LogEntry("Multiversal Control Create Timer has been expired. Dispose Timer...");
                                        // it may failed to next operation. so remove it from list

                                    }
                                    this.___MultiversalTimer.Dispose();
                                    this.___MultiversalTimer = null;

                                }
                                else
                                {
                                    if (___IsDocumentStatusNotReadyYet == true)
                                    {
                                        this.___MultiversalTimer.Change(1000, 1000);
                                    }
                                    else
                                    {
                                        if (___IsOperationOnlyCreateControl == true)
                                        {
                                            this.___MultiversalTimer.Change(250, CHtmlMultiversalWindow.___MultiversalTimerControlIntervalArray[___TimerControlCreatingPendingCount]);
                                        }
                                        else
                                        {
                                            this.___MultiversalTimer.Change(250, 250);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                catch (Exception exFinal)
                {
                    if (commonLog.LoggingEnabled && commonLog.CommonLogLevel >= 8)
                    {
                        commonLog.LogEntry("Multiversal Control Create Timer final exception. ", exFinal);
                        // it may failed to next operation. so remove it from list

                    }
                }
                finally
                {
                    System.Threading.Monitor.Exit(this.___MultiversalTimerLockingObject);
                }
            }
        }
         */



        public void ___resetParentMultiversalWindow(CHtmlMultiversalWindow ___parentWindow)
        {

            if (this.___parentMultiversalWindowWeakReference != null)
            {
                CHtmlMultiversalWindow __oldWindow = this.___parentMultiversalWindowWeakReference.Target as CHtmlMultiversalWindow;
                if (__oldWindow != null)
                {
                    if (__oldWindow.childMultiversalWindows.ContainsKey(this.GetHashCode()) == true)
                    {
                        __oldWindow.childMultiversalWindows.Remove(this.GetHashCode());
                    }
                }
                this.___parentMultiversalWindowWeakReference = null;
            }
            if (___parentWindow != null)
            {
                this.___parentMultiversalWindowWeakReference = new WeakReference(___parentWindow, false);
                ___parentWindow.childMultiversalWindows[this.GetHashCode()] = new WeakReference(this, false);
                this.___WindowLevel = ___parentWindow.___WindowLevel + 1;
            }
            this.___TopMultiversalWindowWeakReference = null;
            CHtmlMultiversalWindow topWidnow = this.___getTopMultiversalWindow();
            if (topWidnow != null)
            {
                this.___TopMultiversalWindowWeakReference = new WeakReference(topWidnow, false);
            }
        }
        public CHtmlMultiversalWindow getTopMultiversalWindow()
        {
            if (this.___TopMultiversalWindowWeakReference != null)
            {
                return this.___TopMultiversalWindowWeakReference.Target as CHtmlMultiversalWindow;
            }
            else
            {
                CHtmlMultiversalWindow topWidnow = this.___getTopMultiversalWindow();
                if (topWidnow != null)
                {
                    this.___TopMultiversalWindowWeakReference = new WeakReference(topWidnow, false);
                    return this.___TopMultiversalWindowWeakReference.Target as CHtmlMultiversalWindow;
                }
            }
            return this;
        }
        /// <summary>
        /// Recalucutate Top Multiversal Window based upon parentMultiversal Winow
        /// </summary>
        /// <returns>Top Multiversal Widnow (may be this)</returns>
        private CHtmlMultiversalWindow ___getTopMultiversalWindow()
        {
            if (this.___parentMultiversalWindowWeakReference != null)
            {
                CHtmlMultiversalWindow ___parentWindow = this.___parentMultiversalWindowWeakReference.Target as CHtmlMultiversalWindow;
                if (___parentWindow == null)
                {
                    return this;
                }
                else
                {
                    int ___LookupCount = 0;
                    while (___parentWindow != null)
                    {
                        ___LookupCount++;
                        if (___LookupCount > 16)
                        {
                            if (commonLog.LoggingEnabled && commonLog.CommonLogLevel > 0)
                            {
                                commonLog.LogEntry("there is top Multiversal Widnow may be too deep. returns {0}", ___parentWindow);
                            }
                            return ___parentWindow;
                        }
                        if (___parentWindow.___parentMultiversalWindowWeakReference != null)
                        {
                            ___parentWindow = ___parentWindow.___parentMultiversalWindowWeakReference.Target as CHtmlMultiversalWindow;
                            continue;
                        }
                        else
                        {
                            // Top Window is normally does not change.
                            // We should create weak reference for next search.

                            return ___parentWindow;
                        }
                    }
                }
            }
            return null;
        }
#if use_rhino
        /// <summary>
        /// This function is copy interpreted function property 
        /// specially used for setting 'caller' in Jquery 1.7.2 StorageManager
        /// </summary>
        /// <param name="___originProperty"></param>
        /// <param name="___targetProperty"></param>
        /// <param name="___interpretedFunction"></param>
        private void ___copyCallerToFunctionInstanceSpecial(string ___originProperty, string ___targetProperty, org.mozilla.javascript.Function ___interpretedFunction)
        {
            try
            {
                object objCaller = ___interpretedFunction.get(___targetProperty, ___interpretedFunction);
                object objGetInstance = ___interpretedFunction.get(___originProperty, ___interpretedFunction);
                if (objCaller == org.mozilla.javascript.UniqueTag.NOT_FOUND && objGetInstance is org.mozilla.javascript.Function)
                {
                    ___interpretedFunction.put(___targetProperty, ___interpretedFunction, objGetInstance);
                    if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
                    {
                       commonLog.LogEntry("performed ___copyCallerToFunctionInstanceSpecial({0}, {1}, {2})  ", ___originProperty, ___targetProperty, objGetInstance);
                    }
                }
            }
            catch (Exception ex)
            {
                if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
                {
                   commonLog.LogEntry("___copyCallerToFunctionInstanceSpecial() Exception.  ", ex);
                }
            }
        }
#endif
        public object get(string ___name)
        {

            object __objectInList;

#if DEBUG
            if (commonLog.LoggingEnabled &&commonLog.CommonLogLevel >= 50)
            {
               commonLog.LogEntry("CHtmlMultiversalWindow entering {0}.get(\'{1}\')", this, ___name);

            }
#endif

            try
            {
                if (this.___WindowsPropertiesList != null && this.___WindowsPropertiesList.TryGetValue(___name, out __objectInList) == true)
                {
                   
                    /*
                        if (commonLog.LoggingEnabled &&commonLog.CommonLogLevel >= 1000)
                        {
                           commonLog.LogEntry("{0}.get(\'{1}\') found {2}", this, ___name, __objectInList);
                        }
                        if (___name.Length == 14 && string.Equals(___name, "StorageManager", StringComparison.Ordinal) == true)
                        {
                            if ((__objectInList is org.mozilla.javascript.Undefined) == false)
                            {
                                ___copyCallerToFunctionInstanceSpecial("getInstance", "caller", __objectInList as org.mozilla.javascript.Function);
                            }
                        }
                    */
                        return __objectInList;
                }

            }
            catch (Exception ex)
            {
                if (commonLog.LoggingEnabled &&commonLog.CommonLogLevel >= 3)
                {
                   commonLog.LogEntry("CHtmlMultiversalWindow get error ", ex);
                }
            }


            // CHtmlMultiversalRenderer ___currentRenderer = null;

            // ============================
            // final values check.
            // ============================

            switch (___name)
            {
                case "id":
                    if (string.IsNullOrEmpty(this.___id) == false)
                    {
                        return this.___id;
                    }
                    else
                    {
                        return "";
                    }
                case "execScript": // IE11 depriciated window.execScript(). IE Only old feature
                case "nodeType":
                    return MultiversalRenderer.Interfaces.MultiversalUniqueTag.UniqueType.Undefined;
                case "name":
                    if (string.IsNullOrEmpty(this.___name) == false)
                    {
                        return this.___name;
                    }
                    else
                    {
                        return "";
                    }


                //   case "History":
                //         return this.___WindowPrototypeRootNode.___HistoryPrototypeWeakReference.Target;
                // case "Event":
                //    return this.___WindowPrototypeRootNode.___EventPrototypeWeakReference.Target;
                //case "Screen":
                //   return this.___WindowPrototypeRootNode.___ScreenPrototypeWeakReference.Target;
                // case "Element":
                //    return this.___WindowPrototypeRootNode.___ElementPrototypeWeakReference.Target;
                //   case "Navigator":
                //        return this.___WindowPrototypeRootNode.___NavigatorPrototypeWeakReference.Target;
                //   case "Console":
                //       return this.___WindowPrototypeRootNode.___ConsolePrototypeWeakReference.Target;
                //   case "Clipboard":
                //       return this.___WindowPrototypeRootNode.___ClipboardWeakReference.Target;
                //  case "Node":
                //     return this.___WindowPrototypeRootNode;
                case "XPathResult":
                    return this.___WindowPrototypeRootNode.___XPathResultPrototypeWeakReference.Target;
                case "StyleSheet":
                    return this.___WindowPrototypeRootNode.___StyleSheetPrototypeWeakReference.Target;
                case "CSSStyleSheet":
                    return this.___WindowPrototypeRootNode.___CSSStyleSheetPrototypeWeakReference.Target;
                case "clipboardData":
                    return null;
                case "devicePixelRatio":
                    return (double)0.85;
                case "status":
                case "defaultStatus":
                    return this.___WindowStatusString;
                case "top":
                    if (this.___TopMultiversalWindowWeakReference != null)
                    {
                        return this.___TopMultiversalWindowWeakReference.Target as CHtmlMultiversalWindow;
                    }
                    else
                    {
                        if (commonLog.LoggingEnabled && commonLog.CommonLogLevel > 1000)
                        {
                            commonLog.LogEntry("BUGBUG! there is no top Multiversal Widnow. Return this as ad hoc.");
                        }
                        return this;
                    }
                case "document":
                    return this.___document;
                case "location":
                    return this.___locationBase;

                case "length":
                    if (this.___document != null)
                    {
                        return ___document.___get_window_length_count_viaWidow();
                    }
                    return 0;
                case "frames":
                    if (this.___document != null)
                    {
                        return this.___document.___get_window_frames_viaWindow();
                    }
                    return MultiversalRenderer.Interfaces.MultiversalUniqueTag.UniqueType.Undefined;
                case "screen":
                    return null;
                case "speechSynthesis":
                    return this.___speechSynthehesis;
                case "navigator":
                case "clientInformation":
                    return this.___navigator;
                case "external":
                    return this.___external;
                case "console":
                    return this.___console;
                case "crypto":
                    return this.___crypto;
                case "closed":
                    return this.___IsWindowClosed;
                case "history":
                    return this.___history;
                case "applicationCache":
                    return null;
                case "offscreenBuffering":
                    return true;
                case "parent":
                case "parentWindow":
                    if (this.___parentMultiversalWindowWeakReference != null)
                    {
                        return this.___parentMultiversalWindowWeakReference.Target;
                    }
                    // if there is no parent explicitly set. returns current Window.
                    return this;
                case "statusbars":
                    return null;
                case "localStorage":
                    if (this.___document != null)
                    {
                        return this.___document.___get_localStorage_viaWindow();
                    }
                    return MultiversalRenderer.Interfaces.MultiversalUniqueTag.UniqueType.Undefined;
                case "sessionStorage":
                    if (this.___document != null)
                    {
                        return this.___document.___get_sessionStorage_viaWindow();
                    }
                    return MultiversalRenderer.Interfaces.MultiversalUniqueTag.UniqueType.Undefined;
                case "screenX":
                case "screenY":
                case "screenLeft":
                case "screenTop":
                    return (double)0;
                case "scrollX":
                    {
                        return 0;
                    }
                case "scrollY":
                    {
                        return 0;
                    }
                case "pageYOffset":
                    {
                        return 0;
                    }
                //break;
                case "pageXOffset":
                    {
                        return 0;
                    }
                //break;
                case "outerHeight":
                    return 0;

                case "outerWidth":

                    return 0;


                case "innerHeight":
                    return 0;



                case "innerWidth":
                    return 0;

                case "opener":
                    if (this.___parentMultiversalWindowWeakReference != null)
                    {
                        return 0;
                    }
                    return MultiversalRenderer.Interfaces.MultiversalUniqueTag.UniqueType.Undefined;
                case "frameElement":
                    if (this.___parentMultiversalWindowWeakReference != null)
                    {
                        return 0;
                    }
                    return null;
                case "personalbar":
                case "statusbar":
                case "toolbar":
                    if (commonLog.LoggingEnabled &&commonLog.CommonLogLevel >= 10)
                    {
                       commonLog.LogEntry("TODO: CHtmlMutiversalWindow {0}.get(\'{1}\') returns null", this, ___name);
                    }
                    return MultiversalRenderer.Interfaces.MultiversalUniqueTag.UniqueType.Undefined;
                case commonHTML.ENGINE_SHUTDOWN_STRING:
                    return this.___IsDispoing;
                case "event":
                    return this.___event;
                case "URL":
                    return this.___WindowURLObjectInstance;
                case "performance":
                case "mozPerformance":
                case "msPerformance":
                case "webkitPerformance":
                case "oPerformance":
                    return this.___performance;
                case "exports":
                    if (this.___WindowsPropertiesList.ContainsKey("exports") == true)
                    {
                        return this.___WindowsPropertiesList["exports"];
                    }
                    else
                    {
                        return MultiversalRenderer.Interfaces.MultiversalUniqueTag.UniqueType.Undefined;
                    }
                /*
                case "orientation":
                    return Multiversal.UniqueTag.Undefined;
                 */
                case "animationStartTime":
                case "mozAnimationStartTime":
                case "msAnimationStartTime":
                case "webKitAnimationStartTime":
                    return this.___windowAnimationStartTime;
                case "undefined":
                    return MultiversalRenderer.Interfaces.MultiversalUniqueTag.UniqueType.Undefined;
            }
            if (this.___document != null)
            {
                CHtmlElement ___elementInDocID = null;
                if (this.___document.___DocumentElementIDList != null && this.___document.___DocumentElementIDList.Count > 0 && this.___document.___DocumentElementIDList.TryGetValue(___name, out ___elementInDocID) == true)
                {

                    if (commonLog.LoggingEnabled &&commonLog.CommonLogLevel >= 10)
                    {
                       commonLog.LogEntry("window {0}.get(\'{1}\') found {2} in document", this, ___name, ___elementInDocID);
                    }
                    return ___elementInDocID;
                }
            }

            if (commonLog.LoggingEnabled &&commonLog.CommonLogLevel >= 10)
            {
               commonLog.LogEntry("called {0}.get(\'{1}\') returns null...", this, ___name);
            }
            return MultiversalUniqueTag.UniqueType.Not_Found;
        }
        public object get(int ___index)
        {
            if (___index >= 0 && this.___WindowsPropertiesList.Count > ___index)
            {
                return this.___WindowsPropertiesList.Values[___index];
            }

            return MultiversalUniqueTag.UniqueType.Not_Found;
        }
        public void Dispose()
        {
            this.___IsDispoing = true;
            this.___CleanUp();
            GC.SuppressFinalize(this);
        }
        public void delete(string ___name)
        {
            try
            {
                if (this.___WindowsPropertiesList != null)
                {
                    this.___WindowsPropertiesList.Remove(___name);
                }
                else
                {
                    if (commonLog.LoggingEnabled &&commonLog.CommonLogLevel >= 10)
                    {
                       commonLog.LogEntry("CHtmlMultiversalWindow.delete({0}) skip because there is no container.", ___name);
                    }
                }
            }
            catch (Exception exDelete)
            {
                if (commonLog.LoggingEnabled &&commonLog.CommonLogLevel >= 10)
                {
                   commonLog.LogEntry("CHtmlMultiversalWindow.delete() exception", exDelete);
                }
            }

        }
        public void delete(int ___index)
        {
            bool ___isDeleteByIndexSuccess = false;
            try
            {
                if (this.___WindowsPropertiesList != null)
                {
                    if (___index >= 0 && this.___WindowsPropertiesList.Count > ___index)
                    {
                        this.___WindowsPropertiesList.RemoveAt(___index);
                        ___isDeleteByIndexSuccess = true;
                    }
                }
            }
            catch (Exception exDelete)
            {
                if (commonLog.LoggingEnabled &&commonLog.CommonLogLevel >= 10)
                {
                   commonLog.LogEntry("CHtmlMultiversalWindow.delete() exception", exDelete);
                }
            }
            if (___isDeleteByIndexSuccess == false)
            {
                if (commonLog.LoggingEnabled &&commonLog.CommonLogLevel >= 10)
                {
                   commonLog.LogEntry("CHtmlMultiversalWindow.delete({0}) skipped.", ___index);
                }
            }
        }
        public object hasOwnProperty(object[] args)
        {
            int argsLen = 0;
            if (args != null)
            {
                argsLen = args.Length;
            }
            if (commonLog.LoggingEnabled &&commonLog.CommonLogLevel >= 10)
            {
               commonLog.LogEntry("CHtmlMultiversalWindow.hasOwnProperty({0}:len:{1}) called", args, argsLen);
            }

            return (object)this.has(___name);
        }
        public bool has(string ___name)
        {
            switch (___name)
            {
                case "window":
                case "event":
                case "console":
                case "external":
                case "screen":
                case "parent":
                case "top":
                case "closed":
                case "defaultStatus":
                case "document":
                case "frames":
                case "frameElement":
                case "history":
                case "length":
                case "location":
                case "name":
                case "navigator":
                case "opener":
                case "innerHeight":
                case "innerWidth":
                case "outerHeight":
                case "outerWidth":
                case "pageXOffset":
                case "pageYOffset":
                case "screenX":
                case "screenY":
                case "status":
                case "offscreenBuffering":
                case "statusbar":
                case "toolbar":
                case "scrollbars":
                case "screenLeft":
                case "screenTop":
                case "scrollX":
                case "scrollY":
                case "clientInformation":
                case "localStorage":
                case "sessionStorage":
                case "locationbar":
                case "performance":
                case "mozPerformance":
                case "msPerformance":
                case "webkitPerformance":
                case "oPerformance":
                case "parentWindow":
                case "URL":
                case "devicePixelRatio":
                case "clipboadData":
                case "animationStartTime":
                case "mozAnimationStartTime":
                case "msAnimationStartTime":
                case "webKitAnimationStartTime":
                case "StyleSheet":
                case "CSSStyleSheet":
                case "CanvasRenderingContext2D":
                case "applicationCache":
                case "XPathResult":
                case "crypto":
                    return true;
                default:
                    break;
            }
            if (this.___WindowsPropertiesList != null)
            {
                return this.___WindowsPropertiesList.ContainsKey(___name);
            }
            else
            {
                return false;
            }
        }
        public bool has(int ___index)
        {
            if (___index >= 0 && this.___WindowsPropertiesList != null && this.___WindowsPropertiesList.Count > ___index)
            {
                return true;
            }
            return false;
        }

        public bool isRenderingMultiversalRendererControlSet()
        {
            if (this.___renderingTargetManagedControlWeakReference != null)
            {
                return true;
            }
            return false;

        }
        public object[] getIds()
        {
            string[] propNames = new string[this.___WindowsPropertiesList.Count];
            this.___WindowsPropertiesList.Keys.CopyTo(propNames, 0);
            return propNames;
        }
        public List<string> getPropertyListKeys()
        {
            string[] strKeys = new string[this.___WindowsPropertiesList.Count];
            List<string> listStr = new List<string>();
            foreach (string strKey in this.___WindowsPropertiesList.Keys)
            {
                listStr.Add(strKey);
            }
            return listStr;
        }
        public void put(string ___name, Object ___val)
        {
            switch (___name)
            {
                case "defaultStatus":
                case "status":
                    this.___WindowStatusString = commonHTML.GetStringValue(___val);
                    return;
                case "name":
                    this.___windowName = commonHTML.GetStringValue(___val);
                    return;
                case "location":
                    if (commonHTML.IsObjectStringType(___val))
                    {
                        this.___locationBase.href = commonHTML.GetStringValue(___val);
                    }
                    return;
                case "closed":
                case "console":
                case "navigator":
                case "screen":
                case "document":
                case "external":
                case "screenX":
                case "screenY":
                case "pageYOffset":
                case "pageXOffset":
                case "opener":
                case "parent":
                case "window":
                case "top":
                case "event":
                case "history":
                    if (commonLog.LoggingEnabled &&commonLog.CommonLogLevel >= 10)
                    {
                       commonLog.LogEntry("stange. trying {0}.put(\'{1}\') = {2}", this, ___name, ___val);
                    }
                    return;
                default:
                    break;

            }
            if (commonLog.LoggingEnabled &&commonLog.CommonLogLevel >= 10)
            {
               commonLog.LogEntry("{0}.put(\'{1}\') = {2}", this, ___name, ___val);
            }
            /*
            if (___val is org.mozilla.javascript.IdFunctionObject)
            {
                // ==================================================
                // Following code is to avoid put Rhino Native Object into Multiversal properties
                // They should be stored in Rhino base scope. not in multiveral properties.
                // ==================================================
                switch (___name)
                {
                    case "RegExp":
                    case "ArrayBuffer":
                    case "Float32Array":
                    case "Float64Array":
                    case "Int8Array":
                    case "Int16Array":
                    case "Int32Array":
                    case "Uint8Array":
                    case "Uint16Array":
                    case "Uint32Array":
                    case "Uint8ClampedArray":
                         IMultiversalScriptProcessor processor =  this.getMultiversalScriptProcessorByScriptType("");
                         processor.put(___name, ___val);
                         return;
                }
            }
             */

            try
            {
                if (this.___WindowsPropertiesList != null)
                {
                    if (System.Threading.Monitor.TryEnter(this.___WindowPropertiesLockingObject, ___MultiversalLockTimeout))
                    {
                        try
                        {

                            this.___WindowsPropertiesList[___name] = ___val;
                        }
                        catch (Exception ex)
                        {
                            if (commonLog.LoggingEnabled &&commonLog.CommonLogLevel >= 1)
                            {
                               commonLog.LogEntry("___WindowsPropertiesList{0}.put(\'{1}\') = {2} error", ex);
                            }
                        }
                        finally
                        {
                            System.Threading.Monitor.Exit(___WindowPropertiesLockingObject);
                        }
                    }
                    else
                    {
                        
                        this.___WindowsPropertiesList[___name] = ___val;
                        if (commonLog.LoggingEnabled &&commonLog.CommonLogLevel >= 1)
                        {
                           commonLog.LogEntry("___WindowsPropertiesList{0}.put(\'{1}\') = {2} lock failed", this, ___name, ___val);
                        }
                    }
                }
                else
                {
                    if (commonLog.LoggingEnabled &&commonLog.CommonLogLevel >= 1)
                    {
                       commonLog.LogEntry("___WindowsPropertiesList{0}.put(\'{1}\') = {2} sored object not found", this, ___name, ___val);
                    }

                }

            }
            catch (Exception exPut)
            {
                if (commonLog.LoggingEnabled &&commonLog.CommonLogLevel >= 1)
                {
                   commonLog.LogEntry("put() Excpetion", exPut);
                }
                try
                {
                    this.___WindowsPropertiesList[___name] = ___val;
                }
                catch { }
            }
        }
        public void put(int ___index, Object ___val)
        {
            try
            {
                if (this.___WindowsPropertiesList != null)
                {
                    if (System.Threading.Monitor.TryEnter(this.___WindowPropertiesLockingObject, ___MultiversalLockTimeout))
                    {
                        try
                        {
                            this.___WindowsPropertiesList.Values[___index] = ___val;
                        }
                        finally
                        {
                            System.Threading.Monitor.Exit(___WindowPropertiesLockingObject);
                        }
                    }
                    else
                    {
                
                        this.___WindowsPropertiesList.Values[___index] = ___val;
                        if (commonLog.LoggingEnabled &&commonLog.CommonLogLevel >= 1)
                        {
                           commonLog.LogEntry("___WindowsPropertiesList{0}.put(\'{1}\') = {2} lock failed", this, ___index, ___val);
                        }
                    }
                }
                else
                {
                    if (commonLog.LoggingEnabled &&commonLog.CommonLogLevel >= 1)
                    {
                       commonLog.LogEntry("___WindowsPropertiesList{0}.put(\'{1}\') = {2} sored object not found", this, ___index, ___val);
                    }
                }
            }
            catch (Exception exPut)
            {
                try
                {
                    this.___WindowsPropertiesList.Values[___index] = ___val;
                }
                catch (Exception ex2)
                {
                    if (commonLog.LoggingEnabled &&commonLog.CommonLogLevel >= 1)
                    {
                       commonLog.LogEntry("put() Excpetion", ex2);
                    }
                }
                if (commonLog.LoggingEnabled &&commonLog.CommonLogLevel >= 1)
                {
                   commonLog.LogEntry("put() Excpetion", exPut);
                }
            }
        }

        public static void registerMultiversalScope(Type type)
        {
            ___MultivarsalScopeTypes[type.TypeHandle] = null;
        }
        public static void removeMultiversalScope(Type type)
        {
            ___MultivarsalScopeTypes.Remove(type.TypeHandle);
        }

        public void initializeMultiversalScopes(bool isCreateStandardObjects)
        {
            int iTypeCont = ___MultivarsalScopeTypes.Count;
            for (int i = 0; i < iTypeCont; i++)
            {
                System.RuntimeTypeHandle typehandle = ___MultivarsalScopeTypes.Keys[i];
                Type type = Type.GetTypeFromHandle(typehandle);
                delegateCreateMultiversalScope ___constructor = null;
                object ___constructorObject = ___MultivarsalScopeTypes[typehandle];
                ___constructor = ___constructorObject as delegateCreateMultiversalScope;
                if (___constructor == null)
                {

                    System.Reflection.MethodInfo constructorMethod = type.GetMethod("___constructorMultiversalScope", System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.Public);
                    if (constructorMethod == null)
                    {
                        //Console.WriteLine("MethodInfo {0} is found", constructorMethod);
                        ___MultivarsalScopeTypes[typehandle] = "none";
                    }
                    else
                    {
                        ___constructor = Delegate.CreateDelegate(typeof(delegateCreateMultiversalScope), null, constructorMethod) as delegateCreateMultiversalScope;
                        if (___constructor != null)
                        {
                            // Console.WriteLine("delegate {0} is created", ___constructor);
                            ___MultivarsalScopeTypes[typehandle] = ___constructor;
                        }
                    }
                }
                IMultiversalScope iscope = null;
                if (___constructor != null)
                {
                    iscope = ___constructor.Invoke(this);
                }
                else
                {
                    iscope = Activator.CreateInstance(type) as IMultiversalScope;
                }




                if (iscope.isDefaultMultiversalProcessor() == true)
                {
                    if (this.___MultiversalScriptScopeDefaultLanguage == null)
                    {
                        this.___MultiversalScriptScopeDefaultLanguage = iscope;
                    }
                }
                string[] strCallingNames = iscope.getMultiversalInvokeScriptNames();
                iscope.setMutilversalWindowType(this.___multiversalWindowType);
                if (commonLog.LoggingEnabled == true)
                {
                  //  iscope.___enableLogging(true);
                  //  iscope.___setLoggingLevel(commonLog.CommonLogLevel);
                }
                if (strCallingNames != null)
                {
                    int strCallingNamesLength = strCallingNames.Length;
                    for (int s = 0; s < strCallingNamesLength; s++)
                    {
                        if (strCallingNames[s].Length > 0)
                        {
                            if (this.___MultiversalCallingNameList.ContainsKey(strCallingNames[s]) == false)
                            {
                                this.___MultiversalCallingNameList[strCallingNames[s]] = new System.WeakReference(iscope, false);
                            }
                            else
                            {

                            }
                        }
                    }
                }

                if (isCreateStandardObjects)
                {
                    iscope.initScriptEngine();
                }
               
            }
        }
        public IMultiversalScope getMultiversalScopeByScriptType(string ___type)
        {
            if (string.IsNullOrEmpty(___type) && this.___MultiversalScriptScopeDefaultLanguage != null)
            {
                return this.___MultiversalScriptScopeDefaultLanguage;
            }
            else
            {

                System.WeakReference __ref;
                if (this.___MultiversalCallingNameList.TryGetValue(___type, out __ref))
                {
                    if (__ref != null)
                    {
                        return __ref.Target as IMultiversalScope;
                    }
                }

            }
            return null;
        }
        public IMultiversalScriptProcessor getMultiversalScriptProcessorByScriptType(string ___type)
        {
            IMultiversalScope __scope = this.getMultiversalScopeByScriptType(___type);
            if (__scope != null)
            {
                return __scope.getMultiversalScriptProcessor();
            }
            return null;
        }
        public IMultiversalScope getMultiversalScopeByName(string scopename)
        {
            IMultiversalScope iscope;
            if(this.___MultiversalScopeList.TryGetValue(scopename, out iscope) == true){
                return iscope;
            }
            throw new NullReferenceException($"Multiversal Scope Interpretor {scopename} is not supported/registered");
        }
        public int ___getMultiversalWindowLevel()
        {
            return this.___WindowLevel;
        }
        /// <summary>
        /// Register Prototpe constuctor function into Multipversal
        /// </summary>
        /// <param name="___protoFunction">IPrototypeFuctioin object</param>
        public void registerPrototypeObject(IPrototypeFunction ___protoFunction)
        {
            //Console.WriteLine("registerPrototypeFunction {0}", ___protoFunction);
            if (___protoFunction == null)
                return;
            try
            {
                switch (___protoFunction.multiversalClassType)
                {
                    case IMutilversalObjectType.Window:
                        ___protoFunction.multiversal_prototype_object = this.___WindowPrototypeRootNode.___WindowPrototypeWeakReference.Target;
                        return;
                    case IMutilversalObjectType.Document:
                        ___protoFunction.multiversal_prototype_object = this.___WindowPrototypeRootNode.___DocumentPrototypeWeakReference.Target;
                        return;
                    case IMutilversalObjectType.Worker:
                        ___protoFunction.multiversal_prototype_object = this.___WindowPrototypeRootNode.___WorkerPrototypeWeakReference.Target;
                        return;
                    case IMutilversalObjectType.SharedWorker:
                        ___protoFunction.multiversal_prototype_object = this.___WindowPrototypeRootNode.___SharedWorkerPrototypeWeakReference.Target;
                        return;
                    case IMutilversalObjectType.Image:
                        ___protoFunction.multiversal_prototype_object = this.___WindowPrototypeRootNode.___HTMLImageElementPrototypeWeakReference.Target;
                        return;
                    case IMutilversalObjectType.ActiveXObject:
                        ___protoFunction.multiversal_prototype_object = this.___WindowPrototypeRootNode.___ActiveXObjectPrototypeWeakReference.Target;
                        return;

                    case IMutilversalObjectType.DOMTokenList:
                        ___protoFunction.multiversal_prototype_object = this.___WindowPrototypeRootNode.___DOMTokenListWeakReference.Target;
                        return;

                    case IMutilversalObjectType.XMLHttpRequest:
                    case IMutilversalObjectType.DOMParser:
                        ___protoFunction.multiversal_prototype_object = null;
                        return;
                    case IMutilversalObjectType.HTMLAudioElement:
                        ___protoFunction.multiversal_prototype_object = this.___WindowPrototypeRootNode.___HTMLAudioElementPrototypeWeakReference.Target;
                        return;
                    
                    case IMutilversalObjectType.HTMLVideoElement:
                        ___protoFunction.multiversal_prototype_object = this.___WindowPrototypeRootNode.___HTMLVideoElementPrototypeWeakReference.Target;
                        return;
                    /*
                    case IMutilversalObjectType.Screen:
                        ___protoFunction.multiversal_prototype_object = this.___WindowPrototypeRootNode.___ScreenPrototypeWeakReference.Target;
                        return;
                    */
                    case IMutilversalObjectType.Event:
                        ___protoFunction.multiversal_prototype_object = this.___WindowPrototypeRootNode.___EventPrototypeWeakReference.Target;
                        return;
                    case IMutilversalObjectType.MouseEvent:
                        ___protoFunction.multiversal_prototype_object = this.___WindowPrototypeRootNode.___MouseEventPrototypeWeakReference.Target;
                        return;

                    case IMutilversalObjectType.History:
                        ___protoFunction.multiversal_prototype_object = this.___WindowPrototypeRootNode.___HistoryPrototypeWeakReference.Target;
                        return;
                    case IMutilversalObjectType.Attr:
                        ___protoFunction.multiversal_prototype_object = this.___WindowPrototypeRootNode.___AttrProtoTypeWeakReference.Target;
                        return;
                    case IMutilversalObjectType.Navigator:
                        ___protoFunction.multiversal_prototype_object = this.___WindowPrototypeRootNode.___NavigatorPrototypeWeakReference.Target;
                        return;
                    case IMutilversalObjectType.CanvasRenderingContext2D:
                        ___protoFunction.multiversal_prototype_object = this.___WindowPrototypeRootNode.___CanvasContextPrototypeWeakReference.Target;
                        return;
                    case IMutilversalObjectType.WebGLRenderingContext:
                        ___protoFunction.multiversal_prototype_object = this.___WindowPrototypeRootNode.___CanvasWebGLRenderingContextPrototypeWeakReference.Target;
                        return;
                    case IMutilversalObjectType.AudioContext:

                        ___protoFunction.multiversal_prototype_object = this.___WindowPrototypeRootNode.___AudioContextPrototypeWeakReference.Target;
                        return;
                    case IMutilversalObjectType.AudioBufferSourceNode:
                        ___protoFunction.multiversal_prototype_object = this.___WindowPrototypeRootNode.___AudioBuuferSourceNodeWeakReference.Target;
                        return;
                    case IMutilversalObjectType.OscillatorNode:
                        ___protoFunction.multiversal_prototype_object = this.___WindowPrototypeRootNode.___AudioOscillatorNodeWeakReference.Target;
                        return;

                    case IMutilversalObjectType.Console:
                        ___protoFunction.multiversal_prototype_object = this.___WindowPrototypeRootNode.___ConsolePrototypeWeakReference.Target;
                        return;
                    case IMutilversalObjectType.KeyboardEvent:
                        ___protoFunction.multiversal_prototype_object = this.___WindowPrototypeRootNode.___KeyboardEventWeakReference.Target;
                        return;
                    /*
                    case IMutilversalObjectType.Clipboard:
                        ___protoFunction.multiversal_prototype_object = this.___WindowPrototypeRootNode.___ClipboardPrototypeWeakReference.Target;
                        return;
                    */
                    case IMutilversalObjectType.Node:
                        ___protoFunction.multiversal_prototype_object = this.___WindowPrototypeRootNode;
                        return;
                    case IMutilversalObjectType.Element:

                        ___protoFunction.multiversal_prototype_object = this.___WindowPrototypeRootNode.___ElementPrototypeWeakReference.Target;
                        return;
                    case IMutilversalObjectType.HTMLElement:
                    case IMutilversalObjectType.HTMLTextElement:
                        ___protoFunction.multiversal_prototype_object = this.___WindowPrototypeRootNode.___HTMLElementPrototypeWeakReference.Target;
                        return;
                    case IMutilversalObjectType.HTMLCollection:
                        ___protoFunction.multiversal_prototype_object = this.___WindowPrototypeRootNode.___HTMLCollectionPrototypeWeakReference.Target;
                        return;
                    case IMutilversalObjectType.NodeList:
                        ___protoFunction.multiversal_prototype_object = this.___WindowPrototypeRootNode.___NodeListPrototypeWeakReference.Target;
                        return;

                    case IMutilversalObjectType.HTMLHtmlElement:
                        ___protoFunction.multiversal_prototype_object = this.___WindowPrototypeRootNode.___HTMLHtmlElementPrototypeWeakReference.Target;
                        return;
                    case IMutilversalObjectType.HTMLBodyElement:
                        ___protoFunction.multiversal_prototype_object = this.___WindowPrototypeRootNode.___HTMLBodyElementPrototypeWeakReference.Target;
                        return;
                    case IMutilversalObjectType.HTMLImageElement:
                        ___protoFunction.multiversal_prototype_object = this.___WindowPrototypeRootNode.___HTMLImageElementPrototypeWeakReference.Target;
                        return;

                    case IMutilversalObjectType.HTMLFormElement:
                        ___protoFunction.multiversal_prototype_object = this.___WindowPrototypeRootNode.___HTMLFormElementPrototypeWeakReference.Target;
                        return;
                    case IMutilversalObjectType.HTMLDivElement:
                        ___protoFunction.multiversal_prototype_object = this.___WindowPrototypeRootNode.___HTMLDivElementPrototypeWeakReference.Target;
                        return;
                    case IMutilversalObjectType.HTMLSpanElement:
                        ___protoFunction.multiversal_prototype_object = this.___WindowPrototypeRootNode.___HTMLSpanElementPrototypeWeakReference.Target;
                        return;
                    case IMutilversalObjectType.HTMLLinkElement:
                        ___protoFunction.multiversal_prototype_object = this.___WindowPrototypeRootNode.___HTMLLinkElementPrototypeWeakReference.Target;
                        return;
                    case IMutilversalObjectType.HTMLScriptElement:
                        ___protoFunction.multiversal_prototype_object = this.___WindowPrototypeRootNode.___HTMLScriptElementPrototypeWeakReference.Target;
                        return;
                    case IMutilversalObjectType.HTMLButtonElement:
                        ___protoFunction.multiversal_prototype_object = this.___WindowPrototypeRootNode.___HTMLButtonElementPrototypeWeakReference.Target;
                        return;

                    case IMutilversalObjectType.HTMLInputElement:
                        ___protoFunction.multiversal_prototype_object = this.___WindowPrototypeRootNode.___HTMLInputElementPrototypeWeakReference.Target;
                        return;
                    case IMutilversalObjectType.HTMLOptionElement:
                        ___protoFunction.multiversal_prototype_object = this.___WindowPrototypeRootNode.___HTMLOptionElementPrototypeWeakReference.Target;
                        return;
                    case IMutilversalObjectType.HTMLOptGroupElement:
                        ___protoFunction.multiversal_prototype_object = this.___WindowPrototypeRootNode.___HTMLOptGroupElementPrototypeWeakReference.Target;
                        return;
                    case IMutilversalObjectType.HTMLSourceElement:
                        ___protoFunction.multiversal_prototype_object = this.___WindowPrototypeRootNode.___HTMLSourceElementPrototypeWeakReference.Target;
                        return;
                    case IMutilversalObjectType.HTMLSelectElement:
                        ___protoFunction.multiversal_prototype_object = this.___WindowPrototypeRootNode.___HTMLSelectElementPrototypeWeakReference.Target;
                        return;
                    case IMutilversalObjectType.HTMLCanvasElement:
                        ___protoFunction.multiversal_prototype_object = this.___WindowPrototypeRootNode.___HTMLCanvasElementPrototypeWeakReference.Target;
                        return;
                    case IMutilversalObjectType.HTMLIFrameElement:
                        ___protoFunction.multiversal_prototype_object = this.___WindowPrototypeRootNode.___HTMLIFrameElementPrototypeWeakReference.Target;
                        return;
                    case IMutilversalObjectType.HTMLBaseElement:
                        ___protoFunction.multiversal_prototype_object = this.___WindowPrototypeRootNode.___HTMLBaseElementPrototypeWeakReference.Target;
                        return;
                    case IMutilversalObjectType.HTMLFrameElement:
                        ___protoFunction.multiversal_prototype_object = this.___WindowPrototypeRootNode.___HTMLFrameElementPrototypeWeakReference.Target;
                        return;
                    case IMutilversalObjectType.HTMLAnchorElement:
                        ___protoFunction.multiversal_prototype_object = this.___WindowPrototypeRootNode.___HTMLAnchorElementPrototypeWeakReference.Target;
                        return;
                    case IMutilversalObjectType.HTMLTemplateElement:
                        ___protoFunction.multiversal_prototype_object = this.___WindowPrototypeRootNode.___HTMLTemplateElementPrototypeWeakReference.Target;
                        return;
                    case IMutilversalObjectType.HTMLUnknownElement:
                        ___protoFunction.multiversal_prototype_object = this.___WindowPrototypeRootNode.___HTMLElementPrototypeWeakReference.Target;
                        return;
                    case IMutilversalObjectType.HTMLTableElement:
                        ___protoFunction.multiversal_prototype_object = this.___WindowPrototypeRootNode.___HTMLTableElementPrototypeWeakReference.Target;
                        return;
                    case IMutilversalObjectType.HTMLTableSectionElement:
                        ___protoFunction.multiversal_prototype_object = this.___WindowPrototypeRootNode.___HTMLTableSectionElementPrototypeWeakReference.Target;
                        return;
                    case IMutilversalObjectType.HTMLTableRowElement:
                        ___protoFunction.multiversal_prototype_object = this.___WindowPrototypeRootNode.___HTMLTableRowElementPrototypeWeakReference.Target;
                        return;
                    case IMutilversalObjectType.HTMLTableCellElement:
                        ___protoFunction.multiversal_prototype_object = this.___WindowPrototypeRootNode.___HTMLTableCellElementPrototypeWeakReference.Target;
                        return;
                    case IMutilversalObjectType.HTMLTableColElement:
                        ___protoFunction.multiversal_prototype_object = this.___WindowPrototypeRootNode.___HTMLTableColElementPrototypeWeakReference.Target;
                        return;
                    case IMutilversalObjectType.HTMLObjectElement:
                        ___protoFunction.multiversal_prototype_object = this.___WindowPrototypeRootNode.___HTMLObjectElementPrototypeWeakReference.Target;
                        return;
                    case IMutilversalObjectType.HTMLTextAreaElement:
                        ___protoFunction.multiversal_prototype_object = this.___WindowPrototypeRootNode.___HTMLTextAreaElementPrototypeWeakReference.Target;
                        return;
                    case IMutilversalObjectType.HTMLAreaElement:
                        ___protoFunction.multiversal_prototype_object = this.___WindowPrototypeRootNode.___HTMLAreaElementPrototypeWeakReference.Target;
                        return;
                    case IMutilversalObjectType.HTMLHeadElement:
                        ___protoFunction.multiversal_prototype_object = this.___WindowPrototypeRootNode.___HTMLHeadElementPrototypeWeakReference.Target;
                        return;
                    case IMutilversalObjectType.HTMLUListElement:
                        ___protoFunction.multiversal_prototype_object = this.___WindowPrototypeRootNode.___HTMLUListElementPrototypeWeakReference.Target;
                        return;
                    case IMutilversalObjectType.HTMLLIElement:
                        ___protoFunction.multiversal_prototype_object = this.___WindowPrototypeRootNode.___HTMLIElementPrototypeWeakReference.Target;
                        return;
                    case IMutilversalObjectType.SVGElement:
                        ___protoFunction.multiversal_prototype_object = this.___WindowPrototypeRootNode.___SVGElementPrototypeWeakReference.Target;
                        return;
                    case IMutilversalObjectType.HTMLDataListElement:
                        ___protoFunction.multiversal_prototype_object = this.___WindowPrototypeRootNode.___HTMLDataListPrototypeWeakReference.Target;
                        return;
                    case IMutilversalObjectType.HTMLPictureElement:
                        ___protoFunction.multiversal_prototype_object = this.___WindowPrototypeRootNode.___HTMLPictureElementPrototypeWeakReference.Target;
                        return;

                    case IMutilversalObjectType.File:
                        ___protoFunction.multiversal_prototype_object = this.___WindowPrototypeRootNode.___FilePrototypeWeakReference.Target;
                        return;
                    case IMutilversalObjectType.FileReader:
                        ___protoFunction.multiversal_prototype_object = this.___WindowPrototypeRootNode.___FileReaderPrototypeWeakReference.Target;
                        return;
                    case IMutilversalObjectType.FileList:
                        ___protoFunction.multiversal_prototype_object = this.___WindowPrototypeRootNode.___FileListProtoTypeWeakReference.Target;
                        return;



                    case IMutilversalObjectType.ArrayBuffer:
                        ___protoFunction.multiversal_prototype_object = this.___WindowPrototypeRootNode.___ArrayBufferPrototypeWeakReference.Target;

                        return;
                    case IMutilversalObjectType.TypedArray:
                        ___protoFunction.multiversal_prototype_object = this.___WindowPrototypeRootNode.___TypedArrayPrototypeWeakReference.Target;
                        return;
                    case IMutilversalObjectType.Float32Array:
                        ___protoFunction.multiversal_prototype_object = this.___WindowPrototypeRootNode.___Float32ArrayPrototypeWeakReference.Target;
                        return;
                    case IMutilversalObjectType.Float64Array:
                        ___protoFunction.multiversal_prototype_object = this.___WindowPrototypeRootNode.___Float64ArrayPrototypeWeakReference.Target;
                        return;
                    case IMutilversalObjectType.Int8Array:
                        ___protoFunction.multiversal_prototype_object = this.___WindowPrototypeRootNode.___Int8ArrayPrototypeWeakReference.Target;
                        return;
                    case IMutilversalObjectType.Int16Array:
                        ___protoFunction.multiversal_prototype_object = this.___WindowPrototypeRootNode.___Int8ArrayPrototypeWeakReference.Target;
                        return;
                    case IMutilversalObjectType.Int32Array:
                    case IMutilversalObjectType.Int64Array:
                        ___protoFunction.multiversal_prototype_object = this.___WindowPrototypeRootNode.___Int32ArrayPrototypeWeakReference.Target;
                        return;
                    case IMutilversalObjectType.Uint8Array:
                        ___protoFunction.multiversal_prototype_object = this.___WindowPrototypeRootNode.___Uint8ArrayPrototypeWeakReference.Target;
                        return;
                    case IMutilversalObjectType.Uint16Array:
                        ___protoFunction.multiversal_prototype_object = this.___WindowPrototypeRootNode.___Uint16ArrayPrototypeWeakReference.Target;
                        return;
                    case IMutilversalObjectType.Uint32Array:
                        ___protoFunction.multiversal_prototype_object = this.___WindowPrototypeRootNode.___Uint32ArrayPrototypeWeakReference.Target;
                        return;
                    case IMutilversalObjectType.HTMLStyleElement:
                        ___protoFunction.multiversal_prototype_object = this.___WindowPrototypeRootNode.___HTMLStyleElementPrototypeWeakReference.Target;
                        return;
                    case IMutilversalObjectType.Blob:
                        ___protoFunction.multiversal_prototype_object = this.___WindowPrototypeRootNode.___BlobPrototypeWeakReference.Target;
                        return;

                }
            }
            catch
            {
                if (commonLog.LoggingEnabled)
                {
                    commonLog.LogEntry("BUGUBG !!!" + ___protoFunction.name + " prototype is not property assigned");
                }
                return;
            }

            if (commonLog.LoggingEnabled && commonLog.CommonLogLevel >= 1)
            {
                commonLog.LogEntry("registerPrototypeObject(" + ___protoFunction.name + ") prototype is not assigned");
            }

        }
     


        public CHtmlLocationBase location
        {
            get { return this.___locationBase; }
            set
            {
                string ___strValue = commonHTML.GetStringValue(value);
                if (___strValue.Length != 0)
                {
                    this.___locationBase.assign(___strValue);
                }
            }
        }
        internal void ___navigateUrl(string __url, string __referer)
        {
            this.___navigateUrl(__url, __referer, null, null, false);
        }
        internal void ___navigateUrl(string __url, string __referer, string __method, string __postData, bool ___asRedirect)
        {
            if (commonLog.LoggingEnabled)
            {
                commonLog.LogEntry("entering {0}.___navigateUrl({1}, {2},  {3})", this, __url, __referer, __method);
            }
            if (MAX_WINDOW_LEVEL_PERFORM_NAVIGATE < this.___WindowLevel)
            {
                if (commonLog.LoggingEnabled && commonLog.CommonLogLevel >= 5)
                {
                    commonLog.LogEntry("CHtmlMultiversalWindow.navigate(" + __url + ") cancelled due to  this window level" + this.___WindowLevel.ToString());

                }
                return;
            }
            if (this.___Disposing)
                return;
            if (__url == null || __url.Length == 0)
                return;
            if (string.IsNullOrEmpty(this.___URL_WIP) == false)
            {
                if (string.Equals(this.___URL_WIP, __url, StringComparison.Ordinal) == true)
                {
                    if (commonLog.LoggingEnabled && commonLog.CommonLogLevel >= 5)
                    {
                        commonLog.LogEntry("CHtmlMultiversalWindow.navigate(" + __url + ") is called multiple times for WIP URL. cancell");

                    }
                    return;
                }

            }

            if (this.___parentDocumentWeakReference != null)
            {
                CHtmlDocument __parentDocument = this.___parentDocumentWeakReference.Target as CHtmlDocument;
                if (__parentDocument != null)
                {
                    if (__parentDocument.___IsDisposing == true)
                    {
                        if (commonLog.LoggingEnabled && commonLog.CommonLogLevel >= 8)
                        {
                            commonLog.LogEntry("Navigation will be cancelled due to owner Document is disposing...");
                        }
                        return;
                    }
                    else
                    {
                        if (string.Equals(__parentDocument.___URL, __url, StringComparison.Ordinal) == true)
                        {
                            if (commonLog.LoggingEnabled && commonLog.CommonLogLevel >= 8)
                            {
                                commonLog.LogEntry("{0}.navigateUrl({1}) is same url of parentDocument URL. Abort!", this, __url);
                            }
                            throw new System.InvalidOperationException("Request URL is same orgin for Parent Document");
                        }
                        else
                        {
                            if (__parentDocument.___URL.Length - __url.Length <= 3)
                            {
                                string diffUrl = null;
                                if (__parentDocument.___URL.Length <= __url.Length)
                                {
                                    diffUrl = __parentDocument.___URL.Replace(__url, "");
                                }
                                else
                                {
                                    diffUrl = __url.Replace(__parentDocument.___URL, "");
                                }
                                if (string.IsNullOrEmpty(diffUrl) == false && diffUrl.Length < 3)
                                {
                                    if (commonLog.LoggingEnabled && commonLog.CommonLogLevel >= 8)
                                    {
                                        commonLog.LogEntry("=============[Akin URL]===================== ");
                                        commonLog.LogEntry("Owner Document URL : {0} ", __parentDocument.___URL);
                                        commonLog.LogEntry("Chlild  Requested URL : {0} ", __url);
                                        commonLog.LogEntry("URL Diff                     : {0} ", diffUrl);
                                        commonLog.LogEntry("======================================== ");
                                    }
                                }
                            }
                        }
                    }
                }
            }
            this.___isWindowNavigating = true;
            if (this.___childMultiversalWindows.Count > 0)
            {
                this.___setChildMultiversalWindowNavigatingStatus();

            }

            if (this.___NavigateMethodCallCount >= int.MaxValue)
            {
                this.___NavigateMethodCallCount = 1;
            }
            else
            {
                this.___NavigateMethodCallCount++;
            }
            CHtmlUri ___uriObject = new CHtmlUri(__url);
            if (___uriObject.ProtocolType == CHtmlUriProtocolType.javascript)
            {
                if (commonLog.LoggingEnabled && commonLog.CommonLogLevel >= 8)
                {

                    commonLog.LogEntry("Navigation will be cancelled due : " + __url);
                }
                return;
            }
            if (string.IsNullOrEmpty(___uriObject.Port) == true && ___uriObject.___IsUrlActuallyContainsPortNumberInString == true)
            {

                __url = string.Concat(___uriObject.Protocol, "//", ___uriObject.Hostname, ___uriObject.Pathname);
                if (commonLog.LoggingEnabled && commonLog.CommonLogLevel >= 8)
                {

                    commonLog.LogEntry("RequestedUrl Contains Port 80. removed one : {0}", __url);
                }
            }

            if (___asRedirect == false)
            {
                this.___URL_Request_Original = string.Copy(__url);
                if (this.UrlChanged != null)
                {
                    if (this.___WindowLevel == 1)
                    {
                        this.UrlChanged(this, __url);
                    }
                }
            }



        }

        private void ___setChildMultiversalWindowNavigatingStatus()
        {
            int childCount = this.___childMultiversalWindows.Count;
            foreach (int intKey1 in this.___childMultiversalWindows.Keys)
            {
                try
                {

                    CHtmlMultiversalWindow ___childWindow = this.___childMultiversalWindows[intKey1].Target as CHtmlMultiversalWindow;
                    if (___childWindow != null)
                    {
                        ___childWindow.___isWindowNavigating = true;
                        int childCount2 = ___childWindow.___childMultiversalWindows.Count;
                        if (childCount2 < 0)
                        {
                            foreach (int intKey2 in ___childWindow.___childMultiversalWindows.Keys)
                            {
                                CHtmlMultiversalWindow ___childWindow2 = ___childWindow.___childMultiversalWindows[intKey2].Target as CHtmlMultiversalWindow;
                                if (___childWindow2 != null)
                                {
                                    ___childWindow2.___isWindowNavigating = true;
                                    int childCount3 = ___childWindow2.___childMultiversalWindows.Count;
                                    if (childCount3 < 0)
                                    {
                                        foreach (int intKey3 in ___childWindow2.___childMultiversalWindows.Keys)
                                        {
                                            CHtmlMultiversalWindow ___childWindow3 = ___childWindow2.___childMultiversalWindows[intKey3].Target as CHtmlMultiversalWindow;
                                            if (___childWindow3 != null)
                                            {
                                                ___childWindow3.___isWindowNavigating = true;

                                            }

                                        }
                                    }
                                }

                            }
                        }
                    }
                }
                catch (Exception exNavigationg)
                {
                    if (commonLog.LoggingEnabled && commonLog.CommonLogLevel >= 8)
                    {

                        commonLog.LogEntry("___setChildMultiversalWindowNavigatingStatus() has exception. but cont...", exNavigationg);
                    }
                }
            }
        }

        /// <summary>
        /// If this window is navigation url is provided this flag is set TRUE
        /// After queue process complete, it this flag is FALSE.
        /// </summary>
        public bool isWindowNavigating
        {
            get
            {
                return this.___isWindowNavigating;
            }
        }

        private static string getCallingShortName(string ___language)
        {
            int pos = ___language.IndexOf('/');
            if (pos > -1)
            {
                ___language = ___language.Substring(pos);
            }
            return commonHTML.FasterToLower(___language);
        }
        public void execute(string strScript, string ___languate)
        {
            IMultiversalScriptProcessor ___processor = null;
            System.WeakReference ___weakref = null;
            if (string.IsNullOrEmpty(___languate))
            {
                ___processor = this.___MultiversalScriptScopeDefaultLanguage.getMultiversalScriptProcessor(); ;
                goto ProcessorObtained;
            }
            this.___MultiversalCallingNameList.TryGetValue(getCallingShortName(___languate), out ___weakref);
            if (___weakref != null)
            {
                IMultiversalScope iscope = ___weakref.Target as IMultiversalScope;
                ___processor = iscope.getMultiversalScriptProcessor();
            }
            ProcessorObtained:
            if (___processor != null)
            {
                if (___processor.multiversalscope.isInitCompleted() == false)
                {
                    ___processor.multiversalscope.initScriptEngine();
                }
                ___processor.execute(strScript);
            }
            else
            {
                throw new System.NotSupportedException(___languate + " is handler not reigstered");
            }
        }
        #region Function Execution Section
        public void ___executeElementEventFunction(string __eventName, CHtmlElement ___element, object ___objFunction, object[] ___args)
        {

            this.___executeEventFunction(__eventName, ___element, ___objFunction, ___args, 1);
        }
        public void ___executeDocumentEventFunction(string __eventName, object ___objFunction, object[] ___args)
        {
            this.___executeEventFunction(__eventName, null, ___objFunction, ___args, 10);
        }

        internal void ___setEventSrcElement(CHtmlWindowEvent ___eventWindow, object ___srcElement, object ___toElement)
        {
            if (___srcElement != null)
            {
                ___event.___srcElementWeakReference = new System.WeakReference(___srcElement, false);
                ___event.___currentTargetWeakReference = new WeakReference(___srcElement, false);
                if (___eventWindow != null)
                {
                    ___eventWindow.___srcElementWeakReference = new WeakReference(___srcElement, false);
                    ___eventWindow.___currentTargetWeakReference = new WeakReference(___srcElement, false);
                }
            }
            else
            {
                ___event.___srcElementWeakReference = null;
                ___event.___currentTargetWeakReference = null;
                if (___eventWindow != null)
                {
                    ___eventWindow.___currentTargetWeakReference = null;
                    ___eventWindow.___srcElementWeakReference = null;
                }
            }
            if (___toElement != null)
            {
                ___event.___toElementWeakReference = new WeakReference(___toElement, false);
                if (___eventWindow != null)
                {
                    ___eventWindow.___toElementWeakReference = new WeakReference(___toElement, false);
                }
            }
            else
            {
                ___event.___toElementWeakReference = null;
                if (___eventWindow != null)
                {
                    ___eventWindow.___toElementWeakReference = null;
                }
            }

        }
    

        public void ___executeEventFunction(string __eventName, CHtmlElement ___element, object ___objFunction, object[] ___args, int ___souceType)
        {
            if (this.___IsDispoing == true)
            {
                return;
            }
            if (this.isWindowNavigating == true)
            {
                return;
            }
            ___setEventSrcElement(this.___event, ___element, ___element);
            if (___objFunction == null)
            {
                if (commonLog.LoggingEnabled &&commonLog.CommonLogLevel > 8)
                {
                   commonLog.LogEntry("strange... executeEventFunction() is entered, but function is null. {0} escaping.... ", ___objFunction);
                }
                return;
            }
            CHtmlScriptResultElement ___scriptResult = null;
            try
            {
                if (this.___document != null && this.___document.___scriptEventList != null)
                {
                    ___scriptResult = new CHtmlScriptResultElement();
                    ___scriptResult.href = __eventName + " : " + ___objFunction.ToString();
                    this.___document.___scriptEventList.Add(___scriptResult);
                }
                if (commonHTML.IsObjectStringType(___objFunction) == true)
                {
                    string ___strFunction = commonHTML.GetStringValue(___objFunction);
                    int posColon = ___strFunction.IndexOf(':');
                    bool ___HasScriptName = false;
                    if (___HasScriptName) {; }
                    string ___strScriptTypeName = null;
                    if (posColon > -1)
                    {
                        ___strScriptTypeName = ___strFunction.Substring(0, posColon).Trim();
                        int ___strScriptTypeNameLength = ___strScriptTypeName.Length;
                        if (string.IsNullOrEmpty(___strScriptTypeName) == false)
                        {
                            for (int i = 0; i < ___strScriptTypeNameLength; i++)
                            {
                                if (char.IsLetterOrDigit(___strScriptTypeName[i]) == false)
                                {
                                    ___HasScriptName = false;
                                    ___strScriptTypeName = null;
                                    goto ExecuteStringFunction;
                                }
                            }
                        }
                        ___HasScriptName = true;
                        ___strFunction = ___strFunction.Substring(posColon + 1);

                    }
                    ExecuteStringFunction:
                    if (string.IsNullOrEmpty(___strFunction) == false)
                    {
                        if (commonLog.LoggingEnabled &&commonLog.CommonLogLevel > 8)
                        {
                           commonLog.LogEntry(" executeEventFunction() is executing {0} {1}  for {2}", ___strFunction, ___strScriptTypeName, ___element);
                        }
                        /*
                        this.___multiversalWindow.execute(___strFunction, ___strScriptTypeName);
                        */
                        IMultiversalScriptProcessor ___processor = this.getMultiversalScriptProcessorByScriptType("javascript");
                        if (___processor != null)
                        {
                            if (commonLog.LoggingEnabled &&commonLog.CommonLogLevel > 8)
                            {
                               commonLog.LogEntry(" executeEventFunction() is executing {0} {1}  for {2}", ___objFunction, ___args, ___element);
                            }

                        }

                    }


                }
                else
                {
                    /*
                    if (___objFunction is org.mozilla.javascript.Function)
                    {
                        IMultiversalScriptProcessor ___processor = this.getMultiversalScriptProcessorByScriptType("javascript");
                        if (___processor != null)
                        {
                            if (commonLog.LoggingEnabled &&commonLog.CommonLogLevel > 8)
                            {
                               commonLog.LogEntry(" executeEventFunction() is executing {0} {1}  for {2}", ___objFunction, ___args, ___element);
                            }
                             ___processor.callfunction(___objFunction, ___processor.multiversalscope, ___element, new Object[] { this.___event });
                           // ___processor.callfunction(___objFunction, ___processor.multiversalscope, this, new Object[] { this.___event });
                        }
                    }
                    */

                }
            }
            catch (Exception ex)
            {
                if (___scriptResult != null)
                {
                    ___scriptResult.resultText = __eventName + " execution error";
                    ___scriptResult.result = 500;
                    ___scriptResult.errorDetail =commonData.GetExceptionAsString(ex);
                }
                if (commonLog.LoggingEnabled)
                {
                    if (commonLog.CommonLogLevel <= 3)
                    {
                       commonLog.LogEntry("executeEventFunction()  has an exception : " + ex.Message);
                    }
                    else
                    {
                        if (___scriptResult == null)
                        {
                           commonLog.LogEntry(string.Format("calling executeEventFunction({0}, {1}, {2}, {3}, {4}) Exception", __eventName, ___element, ___objFunction, ___args, ___souceType), ex);
                        }
                        else
                        {
                           commonLog.LogEntry(___scriptResult.errorDetail);
                        }
                    }
                }
            }
            this.___event.___resetToDefaults();
        }
        /// <summary>
        /// Execute Function object raw
        /// </summary>
        /// <param name="___functionName"></param>
        /// <param name="___function_object"></param>
        internal void ___execute___functionObject(string ___functionName, object ___function_object, object[] __args)
        {

            CHtmlMultiversalWindow ___multiWindow = null;
           IMultiversalScriptProcessor ___processor = null;
            CHtmlScriptResultElement _scriptElement = null;


            bool ___IsMultiversalContainsDocument = false;

            if (___function_object != null)
            {
                ___multiWindow = this;
                if (___multiWindow != null)
                {
                    if (___multiWindow.___document != null)
                    {
                        ___IsMultiversalContainsDocument = true;
                        if (___multiWindow.___document != null && ___multiWindow.___document.___scriptEventList != null)
                        {
                            _scriptElement = new CHtmlScriptResultElement();
                            _scriptElement.text = "XHR load function " + ___function_object.ToString();
                            _scriptElement.IsCompiled = true;
                            ___multiWindow.___document.___scriptEventList.Add(_scriptElement);
                        }
                    }
                }
                try
                {
                    if (commonHTML.IsObjectStringType(___function_object) == true)
                    {
                        if (___multiWindow != null)
                        {
                            ___processor = ___multiWindow.getMultiversalScriptProcessorByScriptType("javasript");
                            object ___objFunction = ___processor.compile(___function_object.ToString());
                            ___processor.callfunction(___function_object, ___processor.multiversalscope, this, __args);
                            if (_scriptElement != null)
                            {
                                _scriptElement.result = 200;
                                _scriptElement.resultText = "XHR string function " + ___functionName + " processed successfully";
                            }
                        }
                    }
                    else
                    {

                    }
                }
                catch (Exception ex)
                {
                    if (_scriptElement != null)
                    {

                        if (___IsMultiversalContainsDocument == true)
                        {
                            _scriptElement.result = 500;
                            _scriptElement.resultText = "Execute " + ___functionName + " processed error : " + ex.Message;
                            _scriptElement.errorDetail =commonData.GetExceptionAsString(ex);

                        }
                    }
                    if (commonLog.LoggingEnabled &&commonLog.CommonLogLevel >= 8)
                    {
                       commonLog.LogEntry("___execute___functionObject exception", ex);
                    }
                }
                finally
                {

                }


            }
        }
        /// <summary>
        /// Execute Function object raw
        /// </summary>
        /// <param name="___functionName"></param>
        /// <param name="___function_object"></param>
        internal void ___execute___functionObject(string ___functionName, object ___function_object)
        {

            CHtmlMultiversalWindow ___multiWindow = null;
            IMultiversalScriptProcessor ___processor = null;
            CHtmlScriptResultElement _scriptElement = null;


                bool ___IsMultiversalContainsDocument = false;

                if (___function_object != null)
                {
                    ___multiWindow = this;
                    if (___multiWindow != null)
                    {
                        if (___multiWindow.___document != null)
                        {
                            ___IsMultiversalContainsDocument = true;
                            if (___multiWindow.___document != null && ___multiWindow.___document.___scriptEventList != null)
                            {
                                _scriptElement = new CHtmlScriptResultElement();
                                _scriptElement.text = "XHR load function " + ___function_object.ToString();
                                _scriptElement.IsCompiled = true;
                                ___multiWindow.___document.___scriptEventList.Add(_scriptElement);
                            }
                        }
                    }
                    try
                    {
                        if (commonHTML.IsObjectStringType(___function_object) == true)
                        {
                            if (___multiWindow != null)
                            {
                                ___processor = ___multiWindow.getMultiversalScriptProcessorByScriptType("javasript");
                                object ___objFunction = ___processor.compile(___function_object.ToString());
                                ___processor.callfunction(___function_object, ___processor.multiversalscope, this, null);
                                if (_scriptElement != null)
                                {
                                    _scriptElement.result = 200;
                                    _scriptElement.resultText = "XHR string function " + ___functionName + " processed successfully";
                                }
                            }
                        }
                        else
                        {

                        }
                    }
                    catch (Exception ex)
                    {
                        if (_scriptElement != null)
                        {

                            if (___IsMultiversalContainsDocument == true)
                            {
                                _scriptElement.result = 500;
                                _scriptElement.resultText = "Execute " + ___functionName + " processed error : " + ex.Message;
                                _scriptElement.errorDetail =commonData.GetExceptionAsString(ex);

                            }
                        }
                        if (commonLog.LoggingEnabled &&commonLog.CommonLogLevel >= 8)
                        {
                           commonLog.LogEntry("___execute___functionObject exception", ex);
                        }
                    }
                    finally
                    {

                    }

                
            }
        }

        #endregion

        public void setDocumentGlobalMultiversalWindow(CHtmlDocument ___doc)
        {

            this.___document = ___doc;
            this.___WindowsPropertiesList = ___doc.___WindowPropertiesList;
            if (commonLog.LoggingEnabled && commonLog.CommonLogLevel >= 8)
            {

                commonLog.LogEntry("{0} obtained {1} as main document using proprylist {2}", this, ___doc, this.___WindowsPropertiesList);
            }
        }
#if false
        private void ___onmultiversalWindowNavigateCompleted(object sender,Threading.PoolRequestEventArgs e)
        {
           Threading.ThreadSCQL ___queueWork = sender as Threading.ThreadSCQL;
            bool ___willDisponseAll = false;
            if (e.Aborted == true || this.___IsDispoing)
            {
                ___willDisponseAll = true;
                goto CleanUpPhase;
            }



            if (___queueWork.WorkObject.WebStatusCode == System.Net.HttpStatusCode.Redirect || ___queueWork.WorkObject.WebStatusCode == System.Net.HttpStatusCode.Moved || ___queueWork.WorkObject.WebStatusCode == System.Net.HttpStatusCode.MovedPermanently)
            {
                string ___strOriginalUrl = ___queueWork.WorkObject.Text;

                if (string.Equals(this.___URL_Request_Original, ___queueWork.WorkObject.HttpRedirectedLocation, StringComparison.Ordinal) == false)
                {
                    this.___RedirectCount++;
                    if (this.___multiversalRedirectURLList == null)
                    {
                        this.___multiversalRedirectURLList = new Dictionary<string, DateTime>();
                    }
                    if (this.___multiversalRedirectURLList.ContainsKey(___queueWork.WorkObject.HttpRedirectedLocation) == true)
                    {
                        if (commonLog.LoggingEnabled && commonLog.LogLevel >= 8)
                        {
                            commonLog.LogEntry("RedirectURL has been on the redirect list:  {0}", this.___document.___HttpResponseRedierctLocationURL);
                        }

                        this.___URL_WIP = null;
                        goto RedirectCheckDone;
                    }
                    if (this.___RedirectCount >= HTTP_REDIRECT_LIMIT)
                    {
                        if (commonLog.LoggingEnabled && commonLog.LogLevel >= 8)
                        {

                            commonLog.LogEntry("{0} will be redirect to {1}, but it is over rediect limit. abort.", this, ___queueWork.WorkObject.HttpRedirectedLocation);
                        }
                        this.___URL_WIP = null;
                        goto RedirectCheckDone;
                    }
                    else
                    {

                    }

                    //this.___document.StoreCookieListIfUpdated();


                    string strNewUrl = string.Copy(___queueWork.WorkObject.HttpRedirectedLocation);
                    this.___multiversalRedirectURLList[strNewUrl] = DateTime.Now;

                    MultiversalWindowNavigateDelegate5 redirectDelegate5 = new MultiversalWindowNavigateDelegate5(this.___navigateUrl);
                    this.___URL_WIP = null;

                    if (commonLog.LoggingEnabled && commonLog.LogLevel >= 8)
                    {

                        commonLog.LogEntry("{0} will be redirect from \'{1}\'  to \'{2}\'", this, ___strOriginalUrl, strNewUrl);
                    }
                    this.___navigateUrl(strNewUrl, ___strOriginalUrl);
                    goto CleanUpPhase;
                }
                return;
            }
            RedirectCheckDone:

            if (object.ReferenceEquals(this.___document, ___queueWork.ResultObject) == false)
            {
                if (___queueWork.ResultObject is CHtmlDocument)
                {
                    this.___document = ___queueWork.ResultObject as CHtmlDocument;
                }
            }
            // It is not redirect. Reset Redirect count to zero.
            this.___multiversalRedirectURLList = new Dictionary<string, DateTime>();
            this.___RedirectCount = 0;
            try
            {
                if (string.IsNullOrEmpty(this.___URL_WIP) == false)
                {
                    if (___queueWork != null && ___queueWork.WorkObject != null)
                    {
                        if (string.Equals(this.___URL_WIP, ___queueWork.WorkObject.Text, StringComparison.Ordinal) == true)
                        {
                            this.___URL_WIP = null;
                        }
                    }
                }
s               else
                {
                    if (this.___WindowLevel >= 2)
                    {
                        if (this.___document.___IsDocumentMultiversalCompleteProcessDoneAndReadyToPaint == false)
                        {
                            this.___document.___IsDocumentMultiversalCompleteProcessDoneAndReadyToPaint = true;
                        }
                        if (this.___parentMultiversalWindowWeakReference != null)
                        {
                            CHtmlMultiversalWindow ___parentWindow = this.___parentMultiversalWindowWeakReference.Target as CHtmlMultiversalWindow;
                            CHtmlElement __owner = null;
                            if (this.___ownerElementWeakReference != null)
                            {
                                __owner = this.___ownerElementWeakReference.Target as CHtmlElement;
                                if (__owner != null && __owner.___IsDisposing == true)
                                {
                                    if (commonLog.LoggingEnabled && commonLog.LogLevel >= 8)
                                    {
                                        commonLog.LogEntry("{0}.OnNavigateRequestCompleted but control is  not created for {1}. skipping ___addChildMultiversalWindowToCreateControl(), because owner seems de disposed", this, __owner);
                                    }
                                    goto CleanUpPhase;
                                }
                            }
                            if (___parentWindow != null && ___parentWindow.___document != null)
                            {
                                if (___parentWindow.___document.___ManagedControlPendingElementList != null)
                                {
                                    if (___parentWindow.___document.___ManagedControlPendingElementList.ContainsKey(__owner.___elementOID) == false)
                                    {
                                        if (___parentWindow.___document.___ManagedControlJobDoneList != null && ___parentWindow.___document.___ManagedControlJobDoneList.ContainsKey(__owner.___elementOID) == false)
                                        {
                                            ___parentWindow.___document.___ManagedControlPendingElementList[__owner.___elementOID] = __owner;
                                            goto CleanUpPhase;
                                        }
                                    }
                                }
                                // ___parentWindow.___addChildMultiversalWindowToCreateControl(this);
                            }
                            else
                            {
                                if (commonLog.LoggingEnabled && commonLog.LogLevel >= 8)
                                {
                                    commonLog.LogEntry("{0}.OnNavigateRequestCompleted but control is not created yet for {1}. skipping ___addChildMultiversalWindowToCreateControl()", this, this.___document);
                                }
                            }
                        }
                    }
                    else if (this.___WindowLevel <= 1)
                    {
                        if (commonLog.LoggingEnabled && commonLog.LogLevel >= 8)
                        {
                            commonLog.LogEntry("{0}.OnNavigateRequestCompleted but control windowLevel is less than 2 for {1}", this, this.___document);
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                if (commonLog.LoggingEnabled && commonLog.LogLevel >= 10)
                {
                    commonLog.LogEntry("OnNavigateRequestCompleted Draw Process Exception", ex);
                }
            }
            CleanUpPhase:
            if (this.___document != null)
            {
                this.___document.___IsOnLoadWindowDocumentCompletedCalled = true;
                if (this.___document.___cookieList != null && this.___document.___cookieList.Count > 0)
                {
                    try
                    {
                        this.___document.___storeDocumentDataIntoMCS();
                    }
                    catch (Exception ex)
                    {
                        if (commonLog.LoggingEnabled && commonLog.LogLevel >= 10)
                        {
                            commonLog.LogEntry("___document.___storeDocumentDataIntoMCS() Process Exception", ex);
                        }
                    }
                }
            }

            if (___queueWork != null)
            {
                if (___willDisponseAll)
                {
                    ___queueWork.Dispose();
                }
                else
                {
                    ___queueWork.ResultObject = null;
                    ___queueWork.ResultImage = null;
                    ___queueWork.Dispose();
                }
                ___queueWork = null;
            }
            // Finally Window Navigation Flag is set off.
            this.___isWindowNavigating = false;
        }
#endif
#region General Methods
        public object unescape(Object[] args)
        {
            if (args == null || args.Length == 0)
            {
                return "";
            }
            return commonURL.unescape(commonHTML.GetStringValue(args[0]));
        }
        public object atob(Object[] args)
        {
            if (args == null || args.Length == 0)
            {
                return "";
            }
            byte[] byteArray;
 byteArray = System.Convert.FromBase64String(commonHTML.GetStringValue(args[0]));
            

            string result = System.Text.Encoding.UTF8.GetString(byteArray);

            return result;
        }
        public object btoa(Object[] args)
        {
            if (args == null || args.Length == 0)
            {
                return "";
            }
            byte[] bytesD;

                bytesD = System.Text.Encoding.UTF8.GetBytes(commonHTML.GetStringValue(args[0]));
            

            string result;
            result = System.Convert.ToBase64String(bytesD);

            return result;

        }
        public object escape(Object[] args)
        {
            if (args == null || args.Length == 0)
            {
                return "";
            }
            return commonURL.escape(commonHTML.GetStringValue(args[0]));
        }
        public object decodeURI(Object[] args)
        {
            if (args == null || args.Length == 0)
            {
                return "";
            }
            return commonURL.decodeURI(commonHTML.GetStringValue(args[0]));
        }
        public object encodeURI(Object[] args)
        {
            if (args == null || args.Length == 0)
            {
                return "";
            }
            return commonURL.encodeURI(commonHTML.GetStringValue(args[0]));
        }
        public object encodeURIComponent(Object[] args)
        {
            if (args == null || args.Length == 0)
            {
                return "";
            }
            return commonURL.encodeURIComponent(commonHTML.GetStringValue(args[0]));
        }
        public object decodeURIComponent(Object[] args)
        {
            if (args == null || args.Length == 0)
            {
                return "";
            }
            return commonURL.decodeURIComponent(commonHTML.GetStringValue(args[0]));
        }
        public object scroll(Object[] args)
        {
            return null;
        }
        public object scrollTo(Object[] args)
        {
            return null;
        }
        public object scrollBy(Object[] args)
        {
            return null;
        }
        public object moveTo(Object[] args)
        {
            return null;
        }
        public object moveBy(Object[] args)
        {
            return null;
        }
        public object resizeBy(Object[] args)
        {
            return null;
        }
        public object resizeTo(Object[] args)
        {
            return null;
        }
        public object stop(Object[] args)
        {
            return null;
        }
        public object requestFileSystem(Object[] args)
        {
            if (commonLog.LoggingEnabled && commonLog.CommonLogLevel >= 5)
            {
                commonLog.LogEntry("TODO: {0}.requestFileSystem() needs to be processed", this);
            }
            return null;
        }
        public object navigate(Object[] args)
        {
            if (args == null || args.Length == 0)
            {
                return null;
            }
            string strURL = commonHTML.GetStringValue(args[0]);
            if (strURL.Length != 0)
            {
                if (commonLog.LoggingEnabled && commonLog.CommonLogLevel >= 5)
                {
                    commonLog.LogEntry("TODO: CHtmlMultiversalWindow.navigate(" + strURL + ") needs to be processed");

                }
            }

            return null;
        }

        public object open(Object[] args)
        {
            bool ___isgoodstaus = this.___checkWindowOperationAllowdAtCurrentStatus();

            if (___isgoodstaus == false)
            {
                throw new System.NotSupportedException("window.open() is not allowed for current window status");
            }
            else
            {
                if (commonLog.LoggingEnabled && commonLog.CommonLogLevel >= 5)
                {
                    commonLog.LogEntry("TODO: CHtmlMultiversalWindow.open(" + string.Concat(args) + ") needs to be processed");

                }
                return null;
            }
        }
        private bool ___checkWindowOperationAllowdAtCurrentStatus()
        {
            if (this.___IsDispoing == true)
            {
                return false;
            }

            if (this.___document == null)
            {
                return false;
            }
            else if (this.___document.___Disposing == true)
            {
                return false;
            }
            else if (this.___document.___readyStateType != CHtmlReadytStateType.complete)
            {
                return false;
            }

            return true;
        }

        public object alert(Object[] args)
        {
            bool ___isgoodstaus = this.___checkWindowOperationAllowdAtCurrentStatus();
            if (___isgoodstaus == false)
            {
                throw new System.NotSupportedException("window.alert() is not allowed for current window status");
            }
            else
            {
                if (commonLog.LoggingEnabled && commonLog.CommonLogLevel >= 5)
                {
                    commonLog.LogEntry("TODO: CHtmlMultiversalWindow.alert(" + string.Concat(args) + ") needs to be processed");

                }
                return null;
            }
        }
        public object blur(Object[] args)
        {
            return null;
        }
        public object focus(Object[] args)
        {
            return null;
        }
        public object print(Object[] args)
        {
            return null;
        }
        public object find(Object[] args)
        {
            return null;
        }
        public object dispatchEvent(Object[] args)
        {
            return null;
        }
        public object releaseEvents(Object[] args)
        {
            return null;
        }
        public object setTimeout(Object[] args)
        {
            if (this.___document != null && args != null)
            {
                switch (args.Length)
                {
                    case 3:
                        return this.___document.setTimeout_viaWindow(args[0], args[1], args[2]);

                    case 2:
                        return this.___document.setTimeout_viaWindow(args[0], args[1]);

                    case 1:

                        return this.___document.setTimeout_viaWindow(args[0], null);


                }
            }
            return null;
        }
        public object clearTimeout(Object[] args)
        {
            if (this.___document != null && args != null)
            {
                if (args.Length >= 1)
                {
                    this.___document.clearTimeout_viaWindow(args[0]);
                }
            }
            return null;
        }
        public object setInterval(Object[] args)
        {
            if (this.___document != null && args != null)
            {
                switch (args.Length)
                {
                    case 3:
                        return this.___document.setInterval_viaWindow(args[0], args[1], args[2]);

                    case 2:
                        return this.___document.setInterval_viaWindow(args[0], args[1]);

                    case 1:

                        return this.___document.setInterval_viaWindow(args[0], null);


                }
            }
            return null;
        }
        public object clearInterval(Object[] args)
        {
            if (this.___document != null && args != null)
            {
                if (args.Length >= 1)
                {
                    this.___document.clearInterval_viaWindow(args[0]);
                }
            }
            return null;
        }
        public object matchMedia(Object[] args)
        {
            if (args != null && args.Length > 0)
            {
                return new CHtmlMatchMedia(commonHTML.GetStringValue(args[0]));
            }
            else
            {
                return new CHtmlMatchMedia("");
            }
        }
        public object showModalDialog(Object[] args)
        {
            bool ___isgoodstaus = this.___checkWindowOperationAllowdAtCurrentStatus();
            if (___isgoodstaus == false)
            {
                throw new System.NotSupportedException("window.showModalDialog() is not allowed for current window status");
            }
            else
            {
                if (commonLog.LoggingEnabled && commonLog.CommonLogLevel >= 5)
                {
                    commonLog.LogEntry("TODO: CHtmlMultiversalWindow.showModalDialog(" + string.Concat(args) + ") needs to be processed");

                }
                return null;
            }
        }
        public object close(Object[] args)
        {
            return null;
        }
        public object prompt(Object[] args)
        {
            bool ___isgoodstaus = this.___checkWindowOperationAllowdAtCurrentStatus();
            if (___isgoodstaus == false)
            {
                throw new System.NotSupportedException("window.prompt() is not allowed for current window status");
            }
            else
            {
                if (commonLog.LoggingEnabled && commonLog.CommonLogLevel >= 5)
                {
                    commonLog.LogEntry("TODO: CHtmlMultiversalWindow.prompt(" + string.Concat(args) + ") needs to be processed");

                }
                return null;
            }
        }
        public object confirm(Object[] args)
        {
            bool ___isgoodstaus = this.___checkWindowOperationAllowdAtCurrentStatus();
            if (___isgoodstaus == false)
            {
                throw new System.NotSupportedException("window.confirm() is not allowed for current window status");
            }
            else
            {
                if (commonLog.LoggingEnabled && commonLog.CommonLogLevel >= 5)
                {
                    commonLog.LogEntry("TODO: CHtmlMultiversalWindow.confirm(" + string.Concat(args) + ") needs to be processed");

                }
                return null;
            }
        }

        public object capture(Object[] args)
        {
            return null;
        }
        public object captureEvents(Object[] args)
        {
            return null;
        }
        public object addEventListener(Object[] args)
        {
            if (args != null)
            {
                switch (this.___multiversalWindowType)
                {
                    case IMultiversalWindowType.Generic:
                    case IMultiversalWindowType.NormalWindow:
                        {
                            if (this.___document != null)
                            {
                                if (args.Length >= 3)
                                {
                                    this.___document.addEventListener_viaWindow(args[0], args[1], args[2]);
                                }
                                else if (args.Length == 2)
                                {
                                    this.___document.addEventListener_viaWindow(args[0], args[1], null);
                                }
                                else if (args.Length == 1)
                                {
                                    this.___document.addEventListener_viaWindow(args[0], null, null);
                                }
                            }

                        }
                        break;
                    case IMultiversalWindowType.WorkerWindow:
                        {
                        }
                        break;
                }

            }
            return null;
        }
        public object removeEventListener(string ___str, object ___obj)
        {
            this.___document.removeEventListener_viaWindow(___str, ___obj);
            return null;
        }
        public object removeEventListener(string ___str, object ___obj, object __bool)
        {
            this.___document.removeEventListener_viaWindow(___str, ___obj , __bool);
            return null;
        }
            public object removeEventListener(Object[] args)
        {
            if (args != null)
            {
                switch (this.___multiversalWindowType)
                {
                    case IMultiversalWindowType.Generic:
                    case IMultiversalWindowType.NormalWindow:
                        {
                            if (this.___document != null)
                            {
                                if (args.Length >= 3)
                                {
                                    this.___document.removeEventListener_viaWindow(args[0], args[1], args[2]);
                                }
                                else if (args.Length == 2)
                                {
                                    this.___document.removeEventListener_viaWindow(args[0], args[1], null);
                                }
                                else if (args.Length == 1)
                                {
                                    this.___document.removeEventListener_viaWindow(args[0], null, null);
                                }
                            }
                        }
                        break;
                }
            }


            return null;
        }
        public object cancelAnimationFrame(Object[] args)
        {
            if (this.___document != null && args != null && args.Length > 0)
            {
                this.___document.___cancelAnimationFrame_viaWindow(args[0]);
            }
            return null;
        }
        public object requestAnimationFrame(Object[] args)
        {
            if (this.___document != null && args != null && args.Length > 0)
            {
                return this.___document.___requestAnimationFrame_viaWindow(args[0]);
            }
            return null;
        }
        public object getComputedStyle(Object[] args)
        {
            if (this.___document != null)
            {
                if (args != null)
                {
                    switch (args.Length)
                    {
                        case 1:
                            return CHtmlDocument.___getComputedStyle_viaWindow(args[0], null);
                        case 0:
                            break;
                        case 2:
                        default:
                            return CHtmlDocument.___getComputedStyle_viaWindow(args[0], args[1]);

                    }
                }
            }
            if (commonLog.LoggingEnabled && commonLog.CommonLogLevel >= 7)
            {
                commonLog.LogEntry("Strange getComputedStyle() argument is 0 length...");
            }
            return null;
        }
        public object postMessage(Object[] args)
        {
            if (commonLog.LoggingEnabled && commonLog.CommonLogLevel >= 7)
            {
                if (args != null)
                {
                    if (args.Length > 2)
                    {
                        commonLog.LogEntry("calling {0}.postMessage({1}, {2}, {3})", this, args[0], args[1], args[2]);
                    }
                    else if (args.Length > 1)
                    {
                        commonLog.LogEntry("calling {0}.postMessage({1}, {2})", this, args[0], args[1]);
                    }
                    else if (args.Length > 0)
                    {
                        commonLog.LogEntry("calling {0}.postMessage({1})", this, args[0]);
                    }
                }
            }
            object ___documentWindowMessageFunction = null;
            IMultiversalWindow ___senderWindow = null;
            string ___sendData = "";
            string ___originStr = "";
            if (args != null && args.Length > 0)
            {
                if (args[0] is IMultiversalWindow)
                {
                    ___senderWindow = args[0] as IMultiversalWindow;
                    if (args.Length > 1)
                    {
                        ___sendData = string.Copy(commonHTML.GetStringValue(args[1]));
                        if (args.Length > 2)
                        {
                            ___originStr = string.Copy(commonHTML.GetStringValue(args[2]));
                        }
                    }
                }
                else
                {
                    ___sendData = string.Copy(commonHTML.GetStringValue(args[0]));
                    if (args.Length > 1)
                    {
                        ___originStr = string.Copy(commonHTML.GetStringValue(args[1]));
                    }
                }
            }
            switch (this.___multiversalWindowType)
            {
                case IMultiversalWindowType.NormalWindow:
                case IMultiversalWindowType.Generic:
                    if (this.___document != null)
                    {
                        if (this.___document.___WindowMessageFunctionWeakReference != null)
                        {
                            ___documentWindowMessageFunction = this.___document.___WindowMessageFunctionWeakReference.Target;

                        }
                    }
                    break;
                case IMultiversalWindowType.WorkerWindow:
                    break;
            }
            if (___documentWindowMessageFunction != null)
            {
                CHtmlWindowEvent ___messageArgumentEvent = new CHtmlWindowEvent();
                ___messageArgumentEvent.___eventSourceType = CHtmlWindowEvent.CHtmlWindowEventEventType.onmessage;

                ___messageArgumentEvent.___eventData = ___sendData;
                ___messageArgumentEvent.origin = ___originStr;
                ___messageArgumentEvent.___sourceObjectWeakReference = new WeakReference(___senderWindow, false);


                ___messageArgumentEvent = null;
            }
            return null;
        }
        #endregion
        #region Instance Creaator
        public object ___createAsActiveXObject(object[] __args)
        {
            string strTypeId = null;

            ActiveXTObjectType activeType = ActiveXTObjectType.none;

            if (__args == null || __args.Length == 0)
            {
                activeType = ActiveXTObjectType.none;
            }
            else
            {
                strTypeId = commonHTML.FasterToLower(commonHTML.GetStringValue(__args[0]));

                switch (strTypeId)
                {
                    case "msxml.xmldom":
                    case "msxml2.xmldom":
                    case "msxml3.xmldom":
                    case "microsoft.xmldom":
                        activeType = ActiveXTObjectType.XMLDOM;
                        break;
                    case "microsoft.xmlhttp":
                    case "msxml.xmlhttp":
                    case "msxml2.xmlhttp.10.0":
                    case "msxml2.xmlhttp.9.0":
                    case "msxml2.xmlhttp.8.0":
                    case "msxml2.xmlhttp.7.0":
                    case "msxml2.xmlhttp.6.0":
                    case "msxml2.xmlhttp.5.0":
                    case "msxml2.xmlhttp.4.0":
                    case "msxml2.xmlhttp.3.0":
                    case "msxml2.xmlhttp.2.0":
                    case "msxml2.xmlhttp.1.0":
                    case "msxml2.xmlhttp.10":
                    case "msxml2.xmlhttp.9":
                    case "msxml2.xmlhttp.8":
                    case "msxml2.xmlhttp.7":
                    case "msxml2.xmlhttp.6":
                    case "msxml2.xmlhttp.5":
                    case "msxml2.xmlhttp.4":
                    case "msxml2.xmlhttp.3":
                    case "msxml2.xmlhttp.2":
                    case "msxml2.xmlhttp.1":
                        activeType = ActiveXTObjectType.XMLHttp;
                        break;
                    case "shockwave.flash":
                    case "shockwaveflash":
                    case "shockwaveflash.flash":
                    case "shockwaveflash.shockwaveflash":
                    case "shockwaveflash.shockwaveflash.20":
                    case "shockwaveflash.shockwaveflash.19":
                    case "shockwaveflash.shockwaveflash.18":
                    case "shockwaveflash.shockwaveflash.17":
                    case "shockwaveflash.shockwaveflash.16":
                    case "shockwaveflash.shockwaveflash.15":
                    case "shockwaveflash.shockwaveflash.14":
                    case "shockwaveflash.shockwaveflash.13":
                    case "shockwaveflash.shockwaveflash.12":
                    case "shockwaveflash.shockwaveflash.11":
                    case "shockwaveflash.shockwaveflash.10":
                    case "shockwaveflash.shockwaveflash.9":
                    case "shockwaveflash.shockwaveflash.8":
                    case "shockwaveflash.shockwaveflash.7":
                    case "shockwaveflash.shockwaveflash.6":
                    case "shockwaveflash.shockwaveflash.5":
                    case "shockwaveflash.shockwaveflash.4":
                    case "shockwaveflash.shockwaveflash.3":
                    case "shockwaveflash.shockwaveflash.2":
                    case "shockwaveflash.shockwaveflash.1":
                        activeType = ActiveXTObjectType.ShockwaveFlash;
                        break;
                    default:
                        activeType = ActiveXTObjectType.Unkown;
                        break;
                }
            }
            if (commonLog.LoggingEnabled && commonLog.CommonLogLevel >= 5)
            {
                commonLog.LogEntry("calling Multiverasal.___createAsActiveXObject({0}) = {1}", strTypeId, activeType);
            }
            if (activeType == ActiveXTObjectType.Unkown || activeType == ActiveXTObjectType.none)
            {
                throw new Exception(string.Format("new ActiveXObject('{0}') is not supported : {1}", strTypeId, activeType));
            }
            switch (activeType)
            {
                case ActiveXTObjectType.XMLHttp:
                    CHtmlXMLHttpRequest ___httpreq = new CHtmlXMLHttpRequest();
                    ___httpreq.___MultiversalWindowWeakReference = new WeakReference(this, false);
                    ___httpreq.___baseThreadURL = string.Copy(this.___locationBase.href);
                    return ___httpreq;
                case ActiveXTObjectType.XMLDOM:
                    // when xmldom is selected it shoud create Object which as Load or LoadXML Methods
                    // which load XML into document.
                    CHtmlDOMParserMSXML ___xmldom = new CHtmlDOMParserMSXML();
                    ___xmldom.___threadBaseURL = string.Copy(this.___locationBase.href);
                    return ___xmldom;
                case ActiveXTObjectType.ShockwaveFlash:

                        CHtmlElement ___objectElement = new CHtmlElement();
                        ___objectElement.tagName = "OBJECT";
                        ___objectElement.___IsDynamicElement = true;
                        ___objectElement.___IsElementAsShockwaveFlashActiveXObject = true;
                        return ___objectElement;
    
                   
                default:
                    throw new Exception(string.Format("ActiveXObject('{0}') is not supported : {1}", strTypeId, activeType));
            }


        }
        public object ___createObject(string ___instanceName, params object[] __args)
        {
            if (commonLog.LoggingEnabled && commonLog.CommonLogLevel >= 5)
            {
                if (__args != null && __args.Length > 0)
                {
                    int argslen = __args.Length;
                    commonLog.LogEntry("calliing {0}.___createObject('{1}', args = {2})", this, ___instanceName, argslen);

                }
                else
                {
                    commonLog.LogEntry("calliing {0}.___createObject('{1}')", this, ___instanceName);
                }
            }
            switch (___instanceName)
            {
                // ___instanceName is Case Sensitive

                case "Image":
                    CHtmlElement imageElement = new CHtmlElement();
                    imageElement.tagName = "IMG";
                    imageElement.___IsDynamicElement = true;

                    if (this.___document != null)
                    {
                        this.___document.___ElementDynamicallyCreatedList.Add(imageElement);
                        if (this.___document.___ElementImgAudioVideoDynamicallyCreatedWorkingQueueList != null)
                        {
                            this.___document.___ElementImgAudioVideoDynamicallyCreatedWorkingQueueList.Add(new WeakReference(imageElement, false));
                        }
                        imageElement.___documentWeakRef = new WeakReference(this.___document, false);
                    }

                    imageElement.___MultiversalWindowWeakReference = new WeakReference(this, false);
                    if (__args != null)
                    {
                        if (__args.Length > 0)
                        {
                            try
                            {
                                double dblWidth = 0;
                                double dblHeight = 0;
                                if (__args.Length >= 2)
                                {
                                    dblWidth = commonData.GetDoubleFromObject(__args[0], 0);
                                    dblHeight = commonData.GetDoubleFromObject(__args[1], 0);
                                }
                                else if (__args.Length == 1)
                                {
                                    dblWidth = commonData.GetDoubleFromObject(__args[0], 0);
                                    dblHeight = dblWidth;
                                }
                                imageElement.___style.Width = dblWidth.ToString() + "px";
                                imageElement.___style.Height = dblHeight.ToString() + "px";

                            }
                            catch (Exception exImage)
                            {
                                if (commonLog.LoggingEnabled && commonLog.CommonLogLevel >= 5)
                                {
                                    commonLog.LogEntry("createObject Image Size Error. ", exImage);
                                }
                            }
                        }
                    }
                    this.___assignElementPrototype(imageElement);
                    return imageElement;
                case "Video":
                case "Audio":
                    CHtmlMediaElement mediaElement = new CHtmlMediaElement();
                    if (string.Equals(___instanceName, "Video", StringComparison.Ordinal) == true)
                    {
                        mediaElement.tagName = "VIDEO";
                    }
                    else if (string.Equals(___instanceName, "Audio", StringComparison.Ordinal) == true)
                    {
                        mediaElement.tagName = "AUDIO";
                    }
                    mediaElement.___IsDynamicElement = true;
                    mediaElement.___MultiversalWindowWeakReference = new WeakReference(this, false);
                    if (this.___document != null)
                    {
                        this.___document.___ElementDynamicallyCreatedList.Add(mediaElement);
                        if (this.___document.___ElementImgAudioVideoDynamicallyCreatedWorkingQueueList != null)
                        {
                            this.___document.___ElementImgAudioVideoDynamicallyCreatedWorkingQueueList.Add(new WeakReference(mediaElement, false));
                        }
                        mediaElement.___documentWeakRef = new WeakReference(this.___document, false);
                    }

                    if (__args != null)
                    {
                        if (__args.Length > 0)
                        {
                            if (commonHTML.IsObjectStringType(__args[0]) == true)
                            {
                                string strMediaSrc = commonHTML.GetStringValue(__args[0]);
                                if (strMediaSrc.Length > 0)
                                {
                                    mediaElement.src = strMediaSrc;
                                }
                            }
                        }
                    }
                    this.___assignElementPrototype(mediaElement);
                    return mediaElement;
                case "XMLHttpRequest":
                case "XMLHTTPRequest":
                    CHtmlXMLHttpRequest ___xmlhttpRequest = new CHtmlXMLHttpRequest();

                    if (this.___locationBase != null && this.___locationBase.href.Length != 0)
                    {
                        ___xmlhttpRequest.___baseThreadURL = string.Copy(this.___locationBase.href);
                    }
                    ___xmlhttpRequest.___MultiversalWindowWeakReference = new WeakReference(this, false);
                    return ___xmlhttpRequest;
                case "XDomainRequest":
                case "XDOMAINRequest":
                    // XDomainRequest is abondoned. 
                    return null;

                case "DOMParser":
                    CHtmlDOMParser ___domparser = new CHtmlDOMParser();
                    ___domparser.___MultiversalWindowWeakReference = new WeakReference(this, false);
                    return ___domparser;
                case "AudioContext":
                case "webkitAudioContext":
                    CHtmlAudioContext ___audioContext = new CHtmlAudioContext();
                    ___audioContext.___CanvasContextModeType = CanvasContextModeType.AudioContext;
                    ___audioContext.___MultiversalWindowWeakReference = new WeakReference(this, false);
                    ___audioContext.___audioDestinationNode = new CHtmlAudioDestinationNode();
                    ___audioContext.___audioDestinationNode.___ownerContextWeakReference = new WeakReference(___audioContext, false);
                    return ___audioContext;
                case "Worder":
                case "SharedWorker":
                    break;
                case "Float32Array":
                    return this.___createNumericArray(CHtmlNumericArrayType.Float32Array, __args);
                case "Float64Array":
                    return this.___createNumericArray(CHtmlNumericArrayType.Float64Array, __args);
                case "Int64Array":
                    return this.___createNumericArray(CHtmlNumericArrayType.Int64Array, __args);
                case "Int32Array":
                    return this.___createNumericArray(CHtmlNumericArrayType.Int32Array, __args);
                case "Int16Array":
                    return this.___createNumericArray(CHtmlNumericArrayType.Int16Array, __args);
                case "Int8Array":
                    return this.___createNumericArray(CHtmlNumericArrayType.Int8Array, __args);
                case "Uint32Array":
                    return this.___createNumericArray(CHtmlNumericArrayType.Uint32Array, __args);
                case "Uint16Array":
                    return this.___createNumericArray(CHtmlNumericArrayType.Uint16Array, __args);
                case "Uint8Array":
                    return this.___createNumericArray(CHtmlNumericArrayType.Uint8Array, __args);
                case "ArrayBuffer":
                    return this.___createNumericArray(CHtmlNumericArrayType.ArrayBuffer, __args);
                case "TypedArray":
                    return this.___createNumericArray(CHtmlNumericArrayType.TypedArray, __args);
                case "FileReader":
                    CHtmlFileReader ___fileReader = new CHtmlFileReader();

                    ___fileReader.___prototypeWeakReference = this.___WindowPrototypeRootNode.___FileReaderPrototypeWeakReference;
                    return ___fileReader;
                case "Blob":
                    CHtmlBlob ___newBlob = new CHtmlBlob(__args);
                    ___newBlob.___prototypeWeakReference = this.___WindowPrototypeRootNode.___BlobPrototypeWeakReference;
                    return ___newBlob;
                case "File":
                    CHtmlFile ___newFile = new CHtmlFile(__args);
                    ___newFile.___prototypeWeakReference = this.___WindowPrototypeRootNode.___FilePrototypeWeakReference;
                    return ___newFile;
                case "Element":
                case "HTMLElement":
                    CHtmlElement ___newElem = new CHtmlElement();
                    ___newElem.___IsDynamicElement = true;
                    ___newElem.___IsPrototype = false;
                    ___newElem.___SetTagNameOnly("div");
                    ___newElem.___elementTagType = CHtmlElementType.DIV;
                    // =============================================
                    // Since, "new Element()" needs to have appropriate prototype element
                    // for each objects, assin now.
                    // =============================================
                    switch (___instanceName)
                    {
                        case "Element":
                            ___newElem.___prototypeWeakReference = this.___WindowPrototypeRootNode.___ElementPrototypeWeakReference;
                            break;
                        case "HTMLElement":
                            ___newElem.___prototypeWeakReference = this.___WindowPrototypeRootNode.___HTMLElementPrototypeWeakReference;
                            break;
                    }

                    if (this.___document != null)
                    {
                        ___newElem.___documentWeakRef = new WeakReference(this.___document);
                        this.___document.___ElementDynamicallyCreatedList.Add(___newElem);
                    }
                    if (commonLog.LoggingEnabled && commonLog.CommonLogLevel >= 5)
                    {
                        commonLog.LogEntry("MultiversalWindow.___createObject({0}) will create Element as \"{1}\"", ___instanceName, ___newElem);
                    }
                    return ___newElem;
                #region Web Speech API set
                case "SpeechGrammar":
                    CHtmlWebSpeechGrammar ___speechgrammer = new CHtmlWebSpeechGrammar();
                    ___speechgrammer.___IsPrototype = true;
                    if(this.___document != null)
                    {
                        ___speechgrammer.___ownerDocumentWeakReference = new WeakReference(this.___document);
                        
                    }
                    if (commonLog.LoggingEnabled && commonLog.CommonLogLevel >= 5)
                    {
                        commonLog.LogEntry("MultiversalWindow.___createObject({0}) will create Element as \"{1}\"", ___instanceName, ___speechgrammer);
                    }
                    return ___speechgrammer;
                case "SpeechGrammarList":
                    CHtmlWebSpeechGrammarList ___speechgrammerlist = new CHtmlWebSpeechGrammarList();
                    ___speechgrammerlist.___IsPrototype = true;
                    if (this.___document != null)
                    {
                        ___speechgrammerlist.___ownerDocumentWeakReference = new WeakReference(this.___document);

                    }
                    if (commonLog.LoggingEnabled && commonLog.CommonLogLevel >= 5)
                    {
                        commonLog.LogEntry("MultiversalWindow.___createObject({0}) will create Element as \"{1}\"", ___instanceName, ___speechgrammerlist);
                    }
                    return ___speechgrammerlist;


                case "SpeechRecognition":
                    CHtmlWebSpeechRecognition ___speechRecognition = new CHtmlWebSpeechRecognition();
                    if (this.___document != null)
                    {
                        ___speechRecognition.___ownerDocumentWeakReference = new WeakReference(this.___document);

                    }
                    if (commonLog.LoggingEnabled && commonLog.CommonLogLevel >= 5)
                    {
                        commonLog.LogEntry("MultiversalWindow.___createObject({0}) will create Element as \"{1}\"", ___instanceName, ___speechRecognition);
                    }
                    return ___speechRecognition;


                case "SpeechRecognitionAlternative":
                    CHtmlWebSpeechRecognitionAlternative ___speechRecognitionAlternative = new CHtmlWebSpeechRecognitionAlternative();
                    if (this.___document != null)
                    {
                        ___speechRecognitionAlternative.___ownerDocumentWeakReference = new WeakReference(this.___document);

                    }
                    if (commonLog.LoggingEnabled && commonLog.CommonLogLevel >= 5)
                    {
                        commonLog.LogEntry("MultiversalWindow.___createObject({0}) will create Element as \"{1}\"", ___instanceName, ___speechRecognitionAlternative);
                    }
                    return ___speechRecognitionAlternative;


                case "SpeechRecognitionError":
                    CHtmlWebSpeechRecognitionError ___speechRecognitionError = new CHtmlWebSpeechRecognitionError();
                    if (this.___document != null)
                    {
                        ___speechRecognitionError.___ownerDocumentWeakReference = new WeakReference(this.___document);

                    }
                    if (commonLog.LoggingEnabled && commonLog.CommonLogLevel >= 5)
                    {
                        commonLog.LogEntry("MultiversalWindow.___createObject({0}) will create Element as \"{1}\"", ___instanceName, ___speechRecognitionError);
                    }
                    return ___speechRecognitionError;


                case "SpeechRecognitionEvent":
                    CHtmlWebSpeechRecognitionEvent ___speechRecognitionEvent = new CHtmlWebSpeechRecognitionEvent();
                    if (this.___document != null)
                    {
                        ___speechRecognitionEvent.___ownerDocumentWeakReference = new WeakReference(this.___document);

                    }
                    if (commonLog.LoggingEnabled && commonLog.CommonLogLevel >= 5)
                    {
                        commonLog.LogEntry("MultiversalWindow.___createObject({0}) will create Element as \"{1}\"", ___instanceName, ___speechRecognitionEvent);
                    }
                    return ___speechRecognitionEvent;
                case "SpeechRecognitionResult":
                    CHtmlWebSpeechRecognitionResult ___speechRecognitionResult = new CHtmlWebSpeechRecognitionResult();
                    if (this.___document != null)
                    {
                        ___speechRecognitionResult.___ownerDocumentWeakReference = new WeakReference(this.___document);

                    }
                    if (commonLog.LoggingEnabled && commonLog.CommonLogLevel >= 5)
                    {
                        commonLog.LogEntry("MultiversalWindow.___createObject({0}) will create Element as \"{1}\"", ___instanceName, ___speechRecognitionResult);
                    }
                    return ___speechRecognitionResult;
                case "SpeechRecognitionResultList":
                    CHtmlWebSpeechRecognitionResultList ___speechRecognitionResultList = new CHtmlWebSpeechRecognitionResultList();
                    ___speechRecognitionResultList.___IsPrototype = false;
                    if (this.___document != null)
                    {
                        ___speechRecognitionResultList.___ownerDocumentWeakReference = new WeakReference(this.___document);

                    }
                    if (commonLog.LoggingEnabled && commonLog.CommonLogLevel >= 5)
                    {
                        commonLog.LogEntry("MultiversalWindow.___createObject({0}) will create Element as \"{1}\"", ___instanceName, ___speechRecognitionResultList);
                    }
                    return ___speechRecognitionResultList;
                case "SpeechSynthesis":
                    CHtmlWebSpeechSynthehesis ___speechSynthehesis = new CHtmlWebSpeechSynthehesis();
                    ___speechSynthehesis.___IsPrototype = false;
                    if (this.___document != null)
                    {
                        ___speechSynthehesis.___ownerDocumentWeakReference = new WeakReference(this.___document);

                    }
                    if (commonLog.LoggingEnabled && commonLog.CommonLogLevel >= 5)
                    {
                        commonLog.LogEntry("MultiversalWindow.___createObject({0}) will create Element as \"{1}\"", ___instanceName, ___speechSynthehesis);
                    }
                    return ___speechSynthehesis;
                case "SpeechSynthesisErrorEvent":
                    CHtmlWebSpeechSynthesisErrorEvent  ___speechSynthehesisErrorEvent = new CHtmlWebSpeechSynthesisErrorEvent();
                    ___speechSynthehesisErrorEvent.___IsPrototype = false;
                    if (this.___document != null)
                    {
                        ___speechSynthehesisErrorEvent.___ownerDocumentWeakReference = new WeakReference(this.___document);

                    }
                    if (commonLog.LoggingEnabled && commonLog.CommonLogLevel >= 5)
                    {
                        commonLog.LogEntry("MultiversalWindow.___createObject({0}) will create Element as \"{1}\"", ___instanceName, ___speechSynthehesisErrorEvent);
                    }
                    return ___speechSynthehesisErrorEvent;
                    
                case "SpeechSynthesisEvent":
                    CHtmlWebSpeechSynthesisEvent ___speechSynthehesisEvent = new CHtmlWebSpeechSynthesisEvent();
                    ___speechSynthehesisEvent.___IsPrototype = false;
                    if (this.___document != null)
                    {
                        ___speechSynthehesisEvent.___ownerDocumentWeakReference = new WeakReference(this.___document);

                    }
                    if (commonLog.LoggingEnabled && commonLog.CommonLogLevel >= 5)
                    {
                        commonLog.LogEntry("MultiversalWindow.___createObject({0}) will create Element as \"{1}\"", ___instanceName, ___speechSynthehesisEvent);
                    }
                    return ___speechSynthehesisEvent;
                    
                case "SpeechSynthesisUtterance":
                    CHtmlWebSpeechSynthesisUtterance ___sppechUtterrance = new CHtmlWebSpeechSynthesisUtterance();
                    ___sppechUtterrance.___IsPrototype = false;
                    if (this.___document != null)
                    {
                        ___sppechUtterrance.___ownerDocumentWeakReference = new WeakReference(this.___document);

                    }
                    if (commonLog.LoggingEnabled && commonLog.CommonLogLevel >= 5)
                    {
                        commonLog.LogEntry("MultiversalWindow.___createObject({0}) will create Element as \"{1}\"", ___instanceName, ___sppechUtterrance );
                    }
                    return ___sppechUtterrance;

                case "SpeechSynthehesisVoice":
                    CHtmlWebSpeechSynthesisVoice ___speechSynthehesisVoice = new CHtmlWebSpeechSynthesisVoice();
                    ___speechSynthehesisVoice.___IsPrototype = false;
                    if (this.___document != null)
                    {
                        ___speechSynthehesisVoice.___ownerDocumentWeakReference = new WeakReference(this.___document);

                    }
                    if (commonLog.LoggingEnabled && commonLog.CommonLogLevel >= 5)
                    {
                        commonLog.LogEntry("MultiversalWindow.___createObject({0}) will create Element as \"{1}\"", ___instanceName, ___speechSynthehesisVoice);
                    }

                    return ___speechSynthehesisVoice;
                #endregion
            }


            if (this.___WindowsPropertiesList.ContainsKey(___instanceName))
            {
                object __winprop;
                if (this.___WindowsPropertiesList.TryGetValue(___instanceName, out __winprop))
                {

                    /*
                    if (__winprop is org.mozilla.javascript.BaseFunction)
                    {
                        try
                        {
                            org.mozilla.javascript.BaseFunction __funcObject = __winprop as org.mozilla.javascript.BaseFunction;
                            if (__funcObject != null)
                            {
                                if (commonLog.LoggingEnabled && commonLog.CommonLogLevel >= 5)
                                {
                                    commonLog.LogEntry("CHtmlMutilversalWindow found function which seems to be constructor. invoking : {0} {1}", ___instanceName, __funcObject);
                                }
                                org.mozilla.javascript.Context contxt = org.mozilla.javascript.Context.getCurrentContext();
                                return __funcObject.construct(contxt, this.getMultiversalScopeByName("Rhino.Net") as org.mozilla.javascript.Scriptable, __args);
                            }
                        }
                        catch (Exception ex)
                        {
                            if (commonLog.LoggingEnabled && commonLog.CommonLogLevel >= 5)
                            {
                                commonLog.LogEntry("___createObject constuctor failed.", ex);
                            }
                        }
                    }
                    */

                }
            }
            if (commonLog.LoggingEnabled && commonLog.CommonLogLevel >= 5)
            {
                commonLog.LogEntry("TODO: {0}.___createObject({1}) created nothing", this, ___instanceName);
            }
            return null;
        }
        private CHtmlNativeArray ___createNumericArray(CHtmlNumericArrayType numType, object[] args)
        {
            CHtmlNativeArray __arrayBase = null;
            if (args == null || args.Length == 0)
            {
                __arrayBase = new CHtmlNativeArray(numType);
            }
            else
            {
                if (commonHTML.isClrNumeric(args[0]))
                {
                    __arrayBase = new CHtmlNativeArray(numType, (int)args[0]);
                }
                else
                {
                    int ___arrayLength = 0;
                    if (args[0] is System.Array)
                    {
                        System.Array __argArray = args[0] as System.Array;
                        ___arrayLength = __argArray.Length;
                        if (commonLog.LoggingEnabled &&commonLog.CommonLogLevel >= 10)
                        {
                           commonLog.LogEntry("TODO: System.Array Convertion to float is required " + numType.ToString() + " : ");
                        }
                        __arrayBase = new CHtmlNativeArray(numType, (int)___arrayLength);
                    }

                    else if (args[0] is CHtmlNativeArray)
                    {
                        CHtmlNativeArray ___numericArrayBase = args[0] as CHtmlNativeArray;
                        if (___numericArrayBase != null)
                        {
                            ___arrayLength = (int)___numericArrayBase.length;
                            __arrayBase = new CHtmlNativeArray(numType, (int)___arrayLength);
                            __arrayBase.___copyArrayFromSourceArray(___numericArrayBase);
                        }
                    }
                    else if (commonHTML.isClrNumeric(args[0]))
                    {
                        __arrayBase = new CHtmlNativeArray(numType, (int)args[0]);
                    }
                    /*
                    else if (args[0] is RhinoNetProcessor.MultiversalWrapperObject)
                    {
                        RhinoNetProcessor.MultiversalWrapperObject nativeObject = args[0] as RhinoNetProcessor.MultiversalWrapperObject;
                        object unwrappedobject = nativeObject.unwrap();
                        if (unwrappedobject != null)
                        {
                            if (unwrappedobject is CHtmlNativeArray)
                            {
                                CHtmlNativeArray ___numericArrayBase = unwrappedobject as CHtmlNativeArray;
                                ___arrayLength = (int)___numericArrayBase.length;
                                __arrayBase = new CHtmlNativeArray(numType, (int)___arrayLength);
                                __arrayBase.___copyArrayFromSourceArray(___numericArrayBase);

                            }
                        }
                    }
                    */
                }
            }
            if (__arrayBase == null)
            {
                if (commonLog.LoggingEnabled &&commonLog.CommonLogLevel >= 10)
                {
                   commonLog.LogEntry("TODO: createNumericArray needs to process " + numType.ToString() + " : ");
                }
                __arrayBase = new CHtmlNativeArray(numType);
            }

            return __arrayBase;
        }
        #endregion
        #region StandardProperties
        /// <summary>
        /// set window.onXYZ function by name
        /// </summary>
        /// <param name="___name">name of function</param>
        /// <param name="___func">function object</param>
        public void ___set_onfunction_property(string ___name, object ___func)
        {
            if (this.___document != null)
            {
                this.___document.___set_onfunction_viaWindow(___name, ___func);
            }
        }
        /// <summary>
        /// get window.onXYZ function object by name
        /// </summary>
        /// <param name="___name">name of on function</param>
        /// <returns>function</returns>
        public object ___get_onfunction_property(string ___name)
        {
            if (this.___document != null)
            {
                return this.___document.___get_onfunction_viaWindow(___name);
            }
            return null;
        }

        public void registerTypeConvertDelegate(Type ___convertingType, Type ___returnType, Delegate ___delegate)
        {
            throw new NotImplementedException();
        }

        public object onload
        {
            get
            {
                return this.___document.onload_viaWindow;
            }
            set
            {
                this.___document.onload_viaWindow = value;
            }
        }
        public object onunload
        {
            get
            {
                return this.___document.onunload_viaWindow;
            }
            set
            {
                this.___document.onunload_viaWindow = value;
            }
        }
        public object onresize
        {
            get
            {
                return this.___document.onresize_viaWindow;
            }
            set
            {
                this.___document.onresize_viaWindow = value;
            }
        }
        public object onkeypress
        {
            get
            {
                return this.___document.onkeypress_viaWindow;
            }
            set
            {
                this.___document.onkeypress_viaWindow = value;
            }
        }
        public object onkeydown
        {
            get
            {
                return this.___document.onkeydown_viaWindow;
            }
            set
            {
                this.___document.onkeydown_viaWindow = value;
            }
        }
        public object onkeyup
        {
            get
            {
                return this.___document.onkeyup_viaWindow;
            }
            set
            {
                this.___document.onkeyup_viaWindow = value;
            }
        }
        public object onerror
        {
            get
            {
                return this.___document.onerror_viaWindow;
            }
            set
            {
                this.___document.onerror_viaWindow = value;
            }
        }
        public object onfocus
        {
            get
            {
                return this.___document.onfocus_viaWindow;
            }
            set
            {
                this.___document.onfocus_viaWindow = value;
            }
        }
        public object onmousemove
        {
            get
            {
                return this.___document.onmousemove_viaWindow;
            }
            set
            {
                this.___document.onmousemove_viaWindow = value;
            }
        }
        public object onmousedown
        {
            get
            {
                return this.___document.onmousedown_viaWindow;
            }
            set
            {
                this.___document.onmousedown_viaWindow = value;
            }
        }
        public object onmouseenter
        {
            get
            {
                return this.___document.onmouseenter_viaWindow;
            }
            set
            {
                this.___document.onmouseenter_viaWindow = value;
            }
        }
        public object onmouseover
        {
            get
            {
                return this.___document.onmouseover_viaWindow;
            }
            set
            {
                this.___document.onmouseover_viaWindow = value;
            }
        }
        public object onmouseleave
        {
            get
            {
                return this.___document.onmouseleave_viaWindow;
            }
            set
            {
                this.___document.onmouseleave_viaWindow = value;
            }
        }
        public object onmouseout
        {
            get
            {
                return this.___document.onmouseout_viaWindow;
            }
            set
            {
                this.___document.onmouseout_viaWindow = value;
            }
        }
        public object onmouseup
        {
            get
            {
                return this.___document.onmouseup_viaWindow;
            }
            set
            {
                this.___document.onmouseup_viaWindow = value;
            }
        }

        public object onwheel
        {
            get
            {
                return this.___document.onmousewheel_viaWindow;
            }
            set
            {
                this.___document.onmousewheel_viaWindow = value;
            }
        }
        public object onmousewheel
        {
            get
            {
                return this.___document.onmousewheel_viaWindow;
            }
            set
            {
                this.___document.onmousewheel_viaWindow = value;
            }
        }
        public object onscroll
        {
            get
            {
                return this.___document.onscroll_viaWindow;
            }
            set
            {
                this.___document.onscroll_viaWindow = value;
            }
        }
        public object oncanplay
        {
            get
            {
                return this.___document.oncanplay_viaWindow;
            }
            set
            {
                this.___document.oncanplay_viaWindow = value;
            }
        }
        public object onwebkittransitione
        {
            get
            {
                return this.___document.onwebkittransitione_viaWindow;
            }
            set
            {
                this.___document.onwebkittransitione_viaWindow = value;
            }
        }
        public object onwebkitanimationstart
        {
            get
            {
                return this.___document.onwebkitanimationstart_viaWindow;
            }
            set
            {
                this.___document.onwebkitanimationstart_viaWindow = value;
            }
        }
        public object onwebkitanimationend
        {
            get
            {
                return this.___document.onwebkitanimationend_viaWindow;
            }
            set
            {
                this.___document.onwebkitanimationend_viaWindow = value;
            }
        }
        public object onwebkitanimationiteration
        {
            get
            {
                return this.___document.onwebkitanimationiteration_viaWindow;
            }
            set
            {
                this.___document.onwebkitanimationiteration_viaWindow = value;
            }
        }
        public object onwaiting
        {
            get
            {
                return this.___document.onwaiting_viaWindow;
            }
            set
            {
                this.___document.onwaiting_viaWindow = value;
            }
        }
        public object onvolumechange
        {
            get
            {
                return this.___document.onvolumechange_viaWindow;
            }
            set
            {
                this.___document.onvolumechange_viaWindow = value;
            }
        }
        public object onuserproximity
        {
            get
            {
                return this.___document.onuserproximity_viaWindow;
            }
            set
            {
                this.___document.onuserproximity_viaWindow = value;
            }
        }
        public object ontransitionend
        {
            get
            {
                return this.___document.ontransitionend_viaWindow;
            }
            set
            {
                this.___document.ontransitionend_viaWindow = value;
            }
        }
        public object ontransitionstart
        {
            get
            {
                return this.___document.ontransitionstart_viaWindow;
            }
            set
            {
                this.___document.ontransitionstart_viaWindow = value;
            }
        }
        public object ontimeupdate
        {
            get
            {
                return this.___document.ontimeupdate_viaWindow;
            }
            set
            {
                this.___document.ontimeupdate_viaWindow = value;
            }
        }
        public object onsuspend
        {
            get
            {
                return this.___document.onsuspend_viaWindow;
            }
            set
            {
                this.___document.onsuspend_viaWindow = value;
            }
        }
        public object onprint
        {
            get
            {
                return this.___document.onprint_viaWindow;
            }
            set
            {
                this.___document.onprint_viaWindow = value;
            }
        }
        public object onsubmit
        {
            get
            {
                return this.___document.onsubmit_viaWindow;
            }
            set
            {
                this.___document.onsubmit_viaWindow = value;
            }
        }
        public object onstorage
        {
            get
            {
                return this.___document.onstorage_viaWindow;
            }
            set
            {
                this.___document.onstorage_viaWindow = value;
            }
        }
        public object onstalled
        {
            get
            {
                return this.___document.onstalled_viaWindow;
            }
            set
            {
                this.___document.onstalled_viaWindow = value;
            }
        }
        public object onshow
        {
            get
            {
                return this.___document.onshow_viaWindow;
            }
            set
            {
                this.___document.onshow_viaWindow = value;
            }
        }
        public object onselect
        {
            get
            {
                return this.___document.onselect_viaWindow;
            }
            set
            {
                this.___document.onselect_viaWindow = value;
            }
        }
        public object onseeking
        {
            get
            {
                return this.___document.onseeking_viaWindow;
            }
            set
            {
                this.___document.onseeking_viaWindow = value;
            }
        }
        public object onseeked
        {
            get
            {
                return this.___document.onseeked_viaWindow;
            }
            set
            {
                this.___document.onseeked_viaWindow = value;
            }
        }
        public object onsearch
        {
            get
            {
                return this.___document.onsearch_viaWindow;
            }
            set
            {
                this.___document.onsearch_viaWindow = value;
            }
        }
        public object onreset
        {
            get
            {
                return this.___document.onreset_viaWindow;
            }
            set
            {
                this.___document.onreset_viaWindow = value;
            }
        }
        public object onabort
        {
            get
            {
                return this.___document.onabort_viaWindow;
            }
            set
            {
                this.___document.onabort_viaWindow = value;
            }
        }
        public object onbeforeunload
        {
            get
            {
                return this.___document.onbeforeunload_viaWindow;
            }
            set
            {
                this.___document.onbeforeunload_viaWindow = value;
            }
        }
        public object onbeforescriptexecute
        {
            get
            {
                return this.___document.onbeforescriptexecute_viaWindow;
            }
            set
            {
                this.___document.onbeforescriptexecute_viaWindow = value;
            }
        }
        public object onafterscriptexecute
        {
            get
            {
                return this.___document.onafterscriptexecute_viaWindow;
            }
            set
            {
                this.___document.onafterscriptexecute_viaWindow = value;
            }
        }
        public object onratechange
        {
            get
            {
                return this.___document.onratechange_viaWindow;
            }
            set
            {
                this.___document.onratechange_viaWindow = value;
            }
        }
        public object onprogress
        {
            get
            {
                return this.___document.onprogress_viaWindow;
            }
            set
            {
                this.___document.onprogress_viaWindow = value;
            }
        }
        public object onpopstate
        {
            get
            {
                return this.___document.onpopstate_viaWindow;
            }
            set
            {
                this.___document.onpopstate_viaWindow = value;
            }
        }
        public object onpointerup
        {
            get
            {
                return this.___document.onpointerup_viaWindow;
            }
            set
            {
                this.___document.onpointerup_viaWindow = value;
            }
        }
        public object onpointerover
        {
            get
            {
                return this.___document.onpointerover_viaWindow;
            }
            set
            {
                this.___document.onpointerover_viaWindow = value;
            }
        }
        public object onpointerout
        {
            get
            {
                return this.___document.onpointerout_viaWindow;
            }
            set
            {
                this.___document.onpointerout_viaWindow = value;
            }
        }
        public object onpointermove
        {
            get
            {
                return this.___document.onpointermove_viaWindow;
            }
            set
            {
                this.___document.onpointermove_viaWindow = value;
            }
        }
        public object onpointerleave
        {
            get
            {
                return this.___document.onpointerleave_viaWindow;
            }
            set
            {
                this.___document.onpointerleave_viaWindow = value;
            }
        }
        public object onpointerenter
        {
            get
            {
                return this.___document.onpointerenter_viaWindow;
            }
            set
            {
                this.___document.onpointerenter_viaWindow = value;
            }
        }
        public object onpointerdown
        {
            get
            {
                return this.___document.onpointerdown_viaWindow;
            }
            set
            {
                this.___document.onpointerdown_viaWindow = value;
            }
        }
        public object onpointercancel
        {
            get
            {
                return this.___document.onpointercancel_viaWindow;
            }
            set
            {
                this.___document.onpointercancel_viaWindow = value;
            }
        }
        public object onblur
        {
            get
            {
                return this.___document.onblur_viaWindow;
            }
            set
            {
                this.___document.onblur_viaWindow = value;
            }
        }
        public object oncancel
        {
            get
            {
                return this.___document.oncancel_viaWindow;
            }
            set
            {
                this.___document.oncancel_viaWindow = value;
            }
        }
        public object onchange
        {
            get
            {
                return this.___document.onchange_viaWindow;
            }
            set
            {
                this.___document.onchange_viaWindow = value;
            }
        }
        public object onclick
        {
            get { return this.___document.onclick_viaWindow; }
            set { this.___document.onclick_viaWindow = value; }
        }
        public object ondblclick
        {
            get
            {
                return this.___document.ondblclick_viaWindow;
            }
            set
            {
                this.___document.ondblclick_viaWindow = value;
            }
        }
        public object ondevicelight
        {
            get
            {
                return this.___document.ondevicelight_viaWindow;
            }
            set
            {
                this.___document.ondevicelight_viaWindow = value;
            }
        }
        public object oncuechange
        {
            get
            {
                return this.___document.oncuechange_viaWindow;
            }
            set
            {
                this.___document.oncuechange_viaWindow = value;
            }
        }
        public object oncontextmenu
        {
            get
            {
                return this.___document.oncontextmenu_viaWindow;
            }
            set
            {
                this.___document.oncontextmenu_viaWindow = value;
            }
        }
        public object onclose
        {
            get
            {
                return this.___document.onclose_viaWindow;
            }
            set
            {
                this.___document.onclose_viaWindow = value;
            }
        }
        public object onplaying
        {
            get
            {
                return this.___document.onplaying_viaWindow;
            }
            set
            {
                this.___document.onplaying_viaWindow = value;
            }
        }
        public object onpause
        {
            get
            {
                return this.___document.onpause_viaWindow;
            }
            set
            {
                this.___document.onpause_viaWindow = value;
            }
        }
        public object oncanplaythrough
        {
            get
            {
                return this.___document.oncanplaythrough_viaWindow;
            }
            set
            {
                this.___document.oncanplaythrough_viaWindow = value;
            }
        }
        public object onplay
        {
            get
            {
                return this.___document.onplay_viaWindow;
            }
            set
            {
                this.___document.onplay_viaWindow = value;
            }
        }
        public object onpageshow
        {
            get
            {
                return this.___document.onpageshow_viaWindow;
            }
            set
            {
                this.___document.onpageshow_viaWindow = value;
            }
        }
        public object onpagehide
        {
            get
            {
                return this.___document.onpagehide_viaWindow;
            }
            set
            {
                this.___document.onpagehide_viaWindow = value;
            }
        }
        public object ononline
        {
            get
            {
                return this.___document.ononline_viaWindow;
            }
            set
            {
                this.___document.ononline_viaWindow = value;
            }
        }
        public object onoffline
        {
            get
            {
                return this.___document.onoffline_viaWindow;
            }
            set
            {
                this.___document.onoffline_viaWindow = value;
            }
        }
        public object onmspointerup
        {
            get
            {
                return this.___document.onpointerup_viaWindow;
            }
            set
            {
                this.___document.onpointerup_viaWindow = value;
            }
        }
        public object onmspointerdown
        {
            get
            {
                return this.___document.onpointerdown_viaWindow;
            }
            set
            {
                this.___document.onpointerdown_viaWindow = value;
            }
        }
        public object onmspointerout
        {
            get
            {
                return this.___document.onpointerout_viaWindow;
            }
            set
            {
                this.___document.onpointerout_viaWindow = value;
            }
        }
        public object onmspointerleave
        {
            get
            {
                return this.___document.onpointerleave_viaWindow;
            }
            set
            {
                this.___document.onpointerleave_viaWindow = value;
            }
        }
        public object onmspointerenter
        {
            get
            {
                return this.___document.onpointerenter_viaWindow;
            }
            set
            {
                this.___document.onpointerenter_viaWindow = value;
            }
        }
        public object onmspointermove
        {
            get
            {
                return this.___document.onpointermove_viaWindow;
            }
            set
            {
                this.___document.onpointermove_viaWindow = value;
            }
        }
        public object onmspointerover
        {
            get
            {
                return this.___document.onpointerover_viaWindow;
            }
            set
            {
                this.___document.onpointerover_viaWindow = value;
            }
        }
        public object onmspointercancel
        {
            get
            {
                return this.___document.onpointercancel_viaWindow;
            }
            set
            {
                this.___document.onpointercancel_viaWindow = value;
            }
        }
        public object ondevicemotion
        {
            get
            {
                return this.___document.ondevicemotion_viaWindow;
            }
            set
            {
                this.___document.ondevicemotion_viaWindow = value;
            }
        }
        public object ondeviceproximity
        {
            get
            {
                return this.___document.ondeviceproximity_viaWindow;
            }
            set
            {
                this.___document.ondeviceproximity_viaWindow = value;
            }
        }
        public object ondeviceorientation
        {
            get
            {
                return this.___document.ondeviceorientation_viaWindow;
            }
            set
            {
                this.___document.ondeviceorientation_viaWindow = value;
            }
        }
        public object ondragend
        {
            get
            {
                return this.___document.ondrag_viaWindow;
            }
            set
            {
                this.___document.ondrag_viaWindow = value;
            }
        }
        public object ondragleave
        {
            get
            {
                return this.___document.ondragleave_viaWindow;
            }
            set
            {
                this.___document.ondragleave_viaWindow = value;
            }
        }
        public object ondragover
        {
            get
            {
                return this.___document.ondragover_viaWindow;
            }
            set
            {
                this.___document.ondragover_viaWindow = value;
            }
        }
        public object ondragenter
        {
            get
            {
                return this.___document.ondragenter_viaWindow;
            }
            set
            {
                this.___document.ondragenter_viaWindow = value;
            }
        }
        public object ondragstart
        {
            get
            {
                return this.___document.ondragstart_viaWindow;
            }
            set
            {
                this.___document.ondragstart_viaWindow = value;
            }
        }
        public object ondrag
        {
            get
            {
                return this.___document.ondrag_viaWindow;
            }
            set
            {
                this.___document.ondrag_viaWindow = value;
            }
        }
        public object ondrop
        {
            get
            {
                return this.___document.ondrop_viaWindow;
            }
            set
            {
                this.___document.ondrop_viaWindow = value;
            }
        }

        public object onfocusin
        {
            get
            {
                return this.___document.onfocusin_viaWindow;
            }
            set
            {
                this.___document.onfocusin_viaWindow = value;
            }
        }
        public object onfocusout
        {
            get
            {
                return this.___document.onfocusout_viaWindow;
            }
            set
            {
                this.___document.onfocusout_viaWindow = value;
            }
        }
        public object onhashchange
        {
            get
            {
                return this.___document.onhashchange_viaWindow;
            }
            set
            {
                this.___document.onhashchange_viaWindow = value;
            }
        }
        public object onhelp
        {
            get
            {
                return this.___document.onhelp_viaWindow;
            }
            set
            {
                this.___document.onhelp_viaWindow = value;
            }
        }
        public object oninput
        {
            get
            {
                return this.___document.oninput_viaWindow;
            }
            set
            {
                this.___document.oninput_viaWindow = value;
            }
        }
        public object oninvalid
        {
            get
            {
                return this.___document.oninvalid_viaWindow;
            }
            set
            {
                this.___document.oninvalid_viaWindow = value;
            }
        }
        public object onended
        {
            get
            {
                return this.___document.onended_viaWindow;
            }
            set
            {
                this.___document.onended_viaWindow = value;
            }
        }
        public object onemptied
        {
            get
            {
                return this.___document.onemptied_viaWindow;
            }
            set
            {
                this.___document.onemptied_viaWindow = value;
            }
        }
        public object ondurationchange
        {
            get
            {
                return this.___document.ondurationchange_viaWindow;
            }
            set
            {
                this.___document.ondurationchange_viaWindow = value;
            }
        }
        public object onmessage
        {
            get
            {
                return this.___document.onmessage_viaWindow;
            }
            set
            {
                this.___document.onmessage_viaWindow = value;
            }
        }
        public object onmsinertiastart
        {
            get;
            set;
        }
        public object onmsgesturechange
        {
            get;
            set;
        }
        public object onmsgesturedoubletap
        {
            get;
            set;
        }
        public object onmsgestureend
        {
            get;
            set;
        }
        public object onmsgesturehold
        {
            get;
            set;
        }
        public object onmsgesturestart
        {
            get;
            set;
        }
        public object onmsgesturetap
        {
            get;
            set;
        }
        public object onmozpointerlockerror
        {
            get;
            set;
        }
        public object onmozpointerlockchange
        {
            get;
            set;
        }
        public object onmozfullscreenerror
        {
            get;
            set;
        }
        public object onmozfullscreenchange
        {
            get
            {
                return this.___document.onfullscreenchange_viaWindow;
            }
            set
            {
                this.___document.onfullscreenchange_viaWindow = value;
            }
        }
        public object onmozfullscreencapture
        {
            get;
            set;
        }
        public object onloadstart
        {
            get
            {
                return this.___document.onloadstart_viaWindow;
            }
            set
            {
                this.___document.onloadstart_viaWindow = value;
            }
        }
        public object onlostpointercapture
        {
            get
            {
                return this.___document.onlostpointercapture_viaWindow;
            }
            set
            {
                this.___document.onlostpointercapture_viaWindow = value;
            }
        }
        public object onloadeddata
        {
            get
            {
                return this.___document.onloadeddata_viaWindow;
            }
            set
            {
                this.___document.onloadeddata_viaWindow = value;
            }
        }
        public object onloadedmetadata
        {
            get
            {
                return this.___document.onloadedmetadata_viaWindow;
            }
            set
            {
                this.___document.onloadedmetadata_viaWindow = value;
            }
        }
        public object ongotpointercapture
        {
            get;
            set;
        }
        internal double ___getinnerHeight()
        {



            return (double)1000;
        }
        internal double ___getinnerWidth()
        {

            return 1000;
        }

        #endregion



    }

    
}