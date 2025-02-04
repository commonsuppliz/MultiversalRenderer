﻿using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;

namespace MultiversalRenderer.Core
{
    /// <summary>
    /// Store Font Face informations and Fonts
    /// </summary>
    public  class CHtmlFontFaceStotage : System.IDisposable 
    {

        public static string localTempPath = getLocalTempPath();
        public static int tempFileNamePrefixNumber = (int)Math.Abs(DateTime.Now.Ticks);
        private object ____storageLockingObject = new object();
        private object ____fontFamilyLockingObject = new object();
        private System.Collections.Generic.Dictionary<string, int> currentFontFamilyNameList;
        private delegate System.IO.Stream convertStreamDelegate(System.IO.Stream instream);
        public System.Drawing.Text.PrivateFontCollection ___privateFontCollection = null;
        public System.Collections.Generic.Dictionary<string, System.Drawing.FontFamily> loadedFontList;
        private System.Collections.Generic.List<string> tempFilesToDelete = null;
        internal static System.Collections.Generic.Dictionary<CSSFontFaceFormatType, int> externalFormatLoaderList = null;

        private const int BUFFER_LENGTH = 8 * 1024;
        public delegate void enqueueFontFaceDelegate(string strUrl, CSSFontFaceFormatType format, CHtmlCSSRule ___rule);
        public TemporaryFontStringCollection adHocFontInformationList = null;
        internal object adHocFontInformationListLockingObject = new object();
        internal System.WeakReference ___ownerDocumentWeakReference = null;
        public CHtmlFontFaceStotage(CHtmlDocument ___ownerDocument)
        {
            if(___ownerDocument != null)
            {
                this.___ownerDocumentWeakReference = new WeakReference(___ownerDocument);
            }
 
            this.___privateFontCollection = new System.Drawing.Text.PrivateFontCollection();
            loadedFontList = new Dictionary<string, System.Drawing.FontFamily>();
            if (externalFormatLoaderList == null)
            {
                externalFormatLoaderList = new Dictionary<CSSFontFaceFormatType, int>();
                externalFormatLoaderList[CSSFontFaceFormatType.Embedded_OpenType] = -1;
                externalFormatLoaderList[CSSFontFaceFormatType.Svg] = -1;
                externalFormatLoaderList[CSSFontFaceFormatType.Svgz] = -1;

                externalFormatLoaderList[CSSFontFaceFormatType.Woff10] = 1;
                externalFormatLoaderList[CSSFontFaceFormatType.Woff20] = -1;
            }
            this.currentFontFamilyNameList = new Dictionary<string, int>();
            this.tempFilesToDelete = new List<string>();
            this.adHocFontInformationList = new TemporaryFontStringCollection();

        }
        ~CHtmlFontFaceStotage()
        {
            this.___cleanUp();
        }

        public static string getLocalTempPath()
        {
            if (localTempPath == null)
            {
                localTempPath = System.Environment.GetEnvironmentVariable("TMP");
                if (string.IsNullOrEmpty(localTempPath) == true)
                {
                    //localTempPath =commonData.UserInfoStatus.ApplicationTemporayPath;
                }
                if (localTempPath[localTempPath.Length - 1] == System.IO.Path.DirectorySeparatorChar)
                {
                    localTempPath = localTempPath.Substring(0, localTempPath.Length - 1);
                }
                if (System.IO.Directory.Exists(localTempPath) == false)
                {

                }
                else
                {
                    localTempPath = string.Concat(localTempPath, System.IO.Path.DirectorySeparatorChar, "fair_dll_fair_font_cache");
                    if (System.IO.Directory.Exists(localTempPath) == false)
                    {
                        System.IO.Directory.CreateDirectory(localTempPath);
                    }else
                    {
                        try
                        {
                            System.IO.Directory.Delete(localTempPath);
                        }catch
                        {

                        }
                        System.IO.Directory.CreateDirectory(localTempPath);

                    }


                }

            }
            return localTempPath;
        }
        public void loadFontFaceFont(string strFileLocation, CSSFontFaceFormatType format, CHtmlCSSRule ___rule)
        {
            if(System.IO.File.Exists(strFileLocation) == true)
            {
                bool isLocking = false;
                bool isFontFamiyLocking = false;
                try
                {
                    int ruleAttrCount = ___rule.___styleAttributeList.Count;
                    bool ___isFontFamilyFound = false;
                    string fontFamilyLow = null;
                    for (int i = 0; i < ruleAttrCount; i++)
                    {
                        CHtmlStyleAttribute? ___attr = ___rule.___styleAttributeList[i];
                        if (___attr.HasValue == true)
                        {
                            CHtmlStyleAttribute ___attr2 = ___attr.Value;
                            if(string.Equals(___attr2.Name, "font-family", StringComparison.OrdinalIgnoreCase) == true)
                            {
                                ___isFontFamilyFound = true;
                                fontFamilyLow = ___attr2.value.ToLower();
                                break;
                            }
                        }
                    }
                    if(___isFontFamilyFound == false)
                    {
                        if (commonLog.LoggingEnabled &&commonLog.CommonLogLevel >= 8)
                        {
                           commonLog.LogEntry("CHtmlFontFaceStogage loadFontFaceFont() Font-Family entry is missiing ");
                        }
                    }
                    System.IO.FileInfo originalLocation = new System.IO.FileInfo(strFileLocation);
                    string strOriginalFileName = originalLocation.Name;
                    System.Threading.Interlocked.Increment(ref tempFileNamePrefixNumber);
                    if(tempFileNamePrefixNumber >= int.MaxValue)
                    {
                        tempFileNamePrefixNumber = 1000;
                    }
                    bool dontAddFontFile = false;
                    string strTempFileName = null;
                    switch (format)
                    {
                        case CSSFontFaceFormatType.TrueType:
                        case CSSFontFaceFormatType.OpenType:
                            strTempFileName = string.Concat(localTempPath, System.IO.Path.DirectorySeparatorChar, tempFileNamePrefixNumber, '_', strOriginalFileName);
                            System.IO.File.Copy(strFileLocation, strTempFileName, true);
                            break;

                        default:
                            int externalLoaderCondition;
                            if (externalFormatLoaderList.TryGetValue(format, out externalLoaderCondition))
                            {
                          
                                switch (externalLoaderCondition)
                                {
                                    case 0:
                                        if (System.Threading.Monitor.TryEnter(this.____storageLockingObject, 1))
                                        {
                                            
                                            //___callConversionDelegate(format, strFileLocation, fontFamilyLow);

                                            dontAddFontFile = true;
                                            System.Threading.Monitor.Exit(this.____storageLockingObject);
                                        }
                                     

                                        break;
                                    case 1:

                                        //___callConversionDelegate(format, strFileLocation, fontFamilyLow);
                                        dontAddFontFile = true;
                                        break;
                                    case -1:
                                    case 99:
                                        dontAddFontFile = true;
                                        break;
                                }
                            }
                            else
                            {
                                dontAddFontFile = true;
                            }
                            break;
                    }
                    if(dontAddFontFile == false)
                    {

                        if (System.Threading.Monitor.TryEnter(this.____storageLockingObject, 1000))
                        {
                            isLocking = true;
                            if (System.Threading.Monitor.TryEnter(this.____fontFamilyLockingObject, 1000) == true)
                            {
                                isFontFamiyLocking = true;
                                ___createExistingFamiyEntry();
                                if (System.IO.File.Exists(strTempFileName))
                                {
                                    this.___privateFontCollection.AddFontFile(strTempFileName);
                                }
                                if (loadedFontList != null)
                                {
                                    System.Drawing.FontFamily newFontFamily = this.___getNewFontFamiyEntry(fontFamilyLow);
                                    this.loadedFontList[fontFamilyLow] = newFontFamily;
                                    if (commonLog.LoggingEnabled &&commonLog.CommonLogLevel >= 8)
                                    {
                                       commonLog.LogEntry("CHtmlFontFaceStogage has load font {0} : {1} ", fontFamilyLow, newFontFamily);
                                    }
                                }

                            }
                            if (tempFilesToDelete != null)
                            {
                                tempFilesToDelete.Add(strTempFileName);
                            }
                            ___convertDocumentAdHocFontIntoWebFont(fontFamilyLow);
                        }
                    }
                }catch(Exception ex)
                {
                    if (commonLog.LoggingEnabled &&commonLog.CommonLogLevel >= 8)
                    {
                       commonLog.LogEntry("CHtmlFontFaceStogage loadFontFaceFont() Exception. ", ex);
                    }
                }
                if(isLocking == true)
                {
                    System.Threading.Monitor.Exit(this.____storageLockingObject);
                }
                if(isFontFamiyLocking == true)
                {
                    System.Threading.Monitor.Exit(this.____fontFamilyLockingObject);
                }
            }
        }
        private void ___convertDocumentAdHocFontIntoWebFont(string fontFamilyLow)
        {
            bool ___isLocked = false;
            int refreshedFontCount = 0;
            CHtmlDocument targetDoc = null;
            if (this.___ownerDocumentWeakReference != null)
            {
                try
                {
                    targetDoc = this.___ownerDocumentWeakReference.Target as CHtmlDocument;
                    if (targetDoc != null)
                    {
                        if (targetDoc.___fontfaceDocumentStorage != null && targetDoc.___fontfaceDocumentStorage.adHocFontInformationList != null)
                        {
                            System.Collections.ArrayList arAdHocFontList = targetDoc.___fontfaceDocumentStorage.adHocFontInformationList.getEntriesByFontName(fontFamilyLow);
                            if (arAdHocFontList != null)
                            {
                               
                                if (System.Threading.Monitor.TryEnter(targetDoc.___FontCacheLockingObject, 5000) == true)
                                {
                                    int arLen = arAdHocFontList.Count;
                                    ___isLocked = true;
                                    try
                                    {
                                        /*
                                  for (int i = arLen - 1; i >= 0; i--)
                                  {
                                      CHtmlFontFaceStotage.FontTempInfo tempInfo = arAdHocFontList[i] as CHtmlFontFaceStotage.FontTempInfo;
                                      if (tempInfo != null)
                                      {
                                          /*
                                          System.Drawing.Font oldFont;
                                          if (targetDoc.___FontCacheList.TryGetValue(tempInfo.FontSizeString, out oldFont) == true)
                                          {
                                              if (oldFont != null)
                                              {
                                                  oldFont.Dispose();
                                                  oldFont = null;
                                              }
                                          }
                                          System.Drawing.FontFamily ___newFamily;
                                          if (this.loadedFontList.TryGetValue(fontFamilyLow, out ___newFamily) == true)
                                          {
                                              if (___newFamily != null)
                                              {
                                                  targetDoc.___FontCacheList[tempInfo.FontSizeString] = new System.Drawing.Font(___newFamily, tempInfo.FontSize, tempInfo.FontStyle);
                                                  refreshedFontCount++;
                                              }
                                          }
                                          


                                    }
                                    */

                                    
                                    }catch (Exception exPrimary)
                                    {
                                        if (commonLog.LoggingEnabled &&commonLog.CommonLogLevel >= 8)
                                        {
                                           commonLog.LogEntry("CHtmlFontFaceStogage ___convertDocumentAdHocFontIntoWebFont Exception. ", exPrimary);
                                        }
                                    }
                                    if(___isLocked)
                                    {
                                        System.Threading.Monitor.Exit(targetDoc.___FontCacheLockingObject);
                                        ___isLocked = false;
                                    }
                             

                                }
                            }
                        }
                    }
                }catch (Exception ex)
                {
                    if (commonLog.LoggingEnabled &&commonLog.CommonLogLevel >= 8)
                    {
                       commonLog.LogEntry("CHtmlFontFaceStogage ___convertDocumentAdHocFontIntoWebFont Exception. ", ex);
                    }

                }
                if (commonLog.LoggingEnabled &&commonLog.CommonLogLevel >= 8)
                {
                   commonLog.LogEntry("CHtmlFontFaceStogage ___convertDocumentAdHocFontIntoWebFont converted {0} fonts for {1} ", refreshedFontCount, fontFamilyLow);
                }
                if (___isLocked && targetDoc != null )
                {
                    System.Threading.Monitor.Exit(targetDoc.___FontCacheLockingObject);
                    ___isLocked = false;
                }

            }
        }
#if false
        private void ___callConversionDelegate(CSSFontFaceFormatType format, string filePath, string fontFamilyLow)
        {
            convertStreamDelegate ___convertDelegate;
            bool isFontFamilyLocked = false;
            if (convertDelegateList.TryGetValue(format, out ___convertDelegate) == true)
            {
                try
                {
                    System.IO.Stream instream = System.IO.File.OpenRead(filePath) as System.IO.Stream;
                    System.IO.Stream outStream = ___convertDelegate(instream);
                    instream.Dispose();
                    instream = null;
                    if(outStream != null)
                    {
                        string extenstion = null;
                        switch(format)
                        {
                            case CSSFontFaceFormatType.Woff10:
                                extenstion = ".otf";
                                break;
                            case CSSFontFaceFormatType.Woff20:
                                extenstion = ".otf";
                                break;
                            default:
                                extenstion = ".otf";
                                break;


                        }
                        string strTempFileName = null;
                        int lastPathPos = filePath.LastIndexOf(System.IO.Path.DirectorySeparatorChar);
                        System.Threading.Interlocked.Increment(ref tempFileNamePrefixNumber);
                        if (tempFileNamePrefixNumber >= int.MaxValue)
                        {
                            tempFileNamePrefixNumber = 1000;
                        }
                        if (lastPathPos > -1)
                        {
                            string strFileName = filePath.Substring(lastPathPos + 1);
                            strTempFileName = string.Concat(localTempPath, System.IO.Path.DirectorySeparatorChar,tempFileNamePrefixNumber, '_', strFileName, extenstion);
                            outStream.Seek(0, System.IO.SeekOrigin.Begin);
                            System.IO.FileStream fileStream = System.IO.File.Create(strTempFileName);
                            byte[] buffer = new byte[BUFFER_LENGTH];
                            int len;
                            while ((len = outStream.Read(buffer, 0, BUFFER_LENGTH)) > 0)
                            {
                                fileStream.Write(buffer, 0, len);
                            }

                            fileStream.Dispose();
                            fileStream = null;
                            outStream.Dispose();
                            outStream = null;
                            if (System.Threading.Monitor.TryEnter(this.____fontFamilyLockingObject, 5000))
                            {
                                isFontFamilyLocked = true;
                                this.___createExistingFamiyEntry();
                                this.___privateFontCollection.AddFontFile(strTempFileName);
                                System.Drawing.FontFamily newFontFamily = this.___getNewFontFamiyEntry(fontFamilyLow);
                                this.loadedFontList[fontFamilyLow] =  newFontFamily;
                                if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
                                {
                                   commonLog.LogEntry("CHtmlFontFaceStogage has load font {0} : {1} ", fontFamilyLow, newFontFamily);
                                }

                            }
                            this.tempFilesToDelete.Add(strTempFileName);
                            ___convertDocumentAdHocFontIntoWebFont(fontFamilyLow);

                        }

                    }
                }catch(Exception ex)
                {
                    if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
                    {
                       commonLog.LogEntry("CHtmlFontFaceStogage ___callConversionDelegate Exception. ", ex);
                    }
                }

            }
            if(isFontFamilyLocked == true)
            {
                System.Threading.Monitor.Exit(this.____fontFamilyLockingObject);
            }
        }
#endif

        private void ___createExistingFamiyEntry()
        {

            System.Drawing.FontFamily[] newCollection = this.___privateFontCollection.Families;
            int ___newCollectionLen = newCollection.Length;
            for (int i = 0; i < ___newCollectionLen; i++)
            {
                System.Drawing.FontFamily curFont = newCollection[i];
                this.currentFontFamilyNameList[curFont.Name] = 1;
            }

        }
        private System.Drawing.FontFamily  ___getNewFontFamiyEntry(string fontFamilyLow)
        {

            System.Drawing.FontFamily[] newCollection = this.___privateFontCollection.Families;
            int ___newCollectionLen = newCollection.Length;
            for(int i = 0; i < ___newCollectionLen; i ++)
            {
                System.Drawing.FontFamily curFont = newCollection[i];
                string strFontName = curFont.Name;
                int isfound;
                if (currentFontFamilyNameList.TryGetValue(strFontName,  out isfound) == false)
                {
                    return curFont;
                }
            }
            System.Drawing.FontFamily ___fontFamilyCached;
            if(this.loadedFontList.TryGetValue(fontFamilyLow, out ___fontFamilyCached))
            {
                return ___fontFamilyCached;
            }
            return System.Drawing.FontFamily.GenericSansSerif;

        }
        

        public void Dispose()
        {
            this.___cleanUp();
            GC.SuppressFinalize(this);
        }
        private void ___cleanUp()
        {
            if (this.___privateFontCollection != null)
            {
                this.___privateFontCollection.Dispose();
                this.___privateFontCollection = null;
            }
            if(this.loadedFontList != null)
            {
                this.loadedFontList = null;
            }
            if (tempFilesToDelete != null)
            {

                /* System Loaded Font is hard to delete. just delete directory when it is possible.
                if (System.Threading.Monitor.TryEnter(this.____storageLockingObject, 3000))
                {
                    int fileCount = tempFilesToDelete.Count;
                    for (int delCount = fileCount - 1; delCount > 0; delCount--)
                    {
                        try
                        {
                            System.IO.File.Delete(tempFilesToDelete[delCount]);
                        }
                        catch (Exception ex)
                        {
                            if (commonLog.LoggingEnabled &&commonLog.CommonLogLevel >= 8)
                            {
                               commonLog.LogEntry("CHtmlFontFaceStogage tempFileDelete minor error. but count..." + ex.Message);
                            }
                        }
                    }
                    System.Threading.Monitor.Exit(this.____storageLockingObject);
                }
                */
                tempFilesToDelete = null;
                if(this.adHocFontInformationList != null)
                {
                    this.adHocFontInformationList = null;
                }
            }

        }
        public class TemporaryFontStringCollection : System.Collections.SortedList
        {
            public void AddEntry(string FontName, float FontSize, System.Drawing.FontStyle fontStyle, string ___fontStringCombination)
            {
                ArrayList arList = base[FontName] as ArrayList;
                if (arList == null)
                {
                    arList = new ArrayList();
                    FontTempInfo adHoc = new FontTempInfo();
                    adHoc.FontName = FontName;
                    adHoc.FontSize = FontSize;
                    adHoc.FontStyle = fontStyle;
                    adHoc.FontSizeString = ___fontStringCombination;
                    arList.Add(adHoc);
                    base[FontName] = arList;
                }
                else
                {
                    FontTempInfo adHoc = new FontTempInfo();
                    adHoc.FontName = FontName;
                    adHoc.FontSize = FontSize;
                    adHoc.FontStyle = fontStyle;
                    arList.Add(adHoc);
                }
            }
            public ArrayList getEntriesByFontName(string FontName)
            {
                ArrayList arList = base[FontName] as ArrayList;
                return arList;
            }
        }
        public class FontTempInfo
        {
            public string FontName;
            public float FontSize;
            public System.Drawing.FontStyle FontStyle;
            public string FontSizeString;
        }
    }
}
