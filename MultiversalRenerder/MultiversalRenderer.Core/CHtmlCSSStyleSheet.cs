using System;
using System.Collections;
using System.Drawing;
using System.Xml;
using System.IO;

using System.Runtime.InteropServices;
using MultiversalRenderer.Interfaces;
namespace MultiversalRenderer.Core
{

    [ComVisible(true)]
    
    public sealed class CHtmlCSSStyleSheet : ICommonObjectInterface
    {

        public CSSStyleConditionType ___styleConditionType;
        public CHtmlFontInfo ___StyleFontInfo = null;
        public int ___style_unique_id = 0;

        public bool ___isApplyElemenetStyleSheetsForElementDone = false;


        /// <summary>
        /// This Flag is true if tail key is 
        /// TRUE : "*", "*:after", "*:before"
        /// FALSE : *[name="hogehoge]"
        /// </summary>
        public bool ___isFinalStyleKeyWildCardOnly = false;
        /// <summary>
        /// CHtmlCSSStyleSheet is created dynamically by script
        /// </summary>
        public bool ___IsDynamicElement = false;
        /// <summary>
        /// Dynamic CHtmlCSSStyleSheet Process Done  Calcuate etc
        /// </summary>
        public bool ___IsDynamicProcessDone = false;

        /// <summary>
        /// After SortedList Field has copyed to each property this is set to be true.
        /// </summary>
        public bool IsSortedListFieldsHasCopiedToProperty = false;

        /// <summary>
        /// How many times this css values are relaclated
        /// </summary>
        public uint ___cssReclacationCount = 0;

        /// <summary>
        /// ID ex. .cheetan_sql_log {} #archives{}
        /// </summary>
        internal System.WeakReference ___ownerElementWeakReference = null;

        /// <summary>
        /// Ad hoc ownerDocument
        /// </summary>
        internal System.WeakReference ___documentWeakReference = null;

        internal CHtmlCollection ___cssRules = null;
        /// <summary>
        /// Holds Important Key
        /// </summary>
        internal System.Collections.Generic.Dictionary<CSSAttributeType, sbyte> ___StyleImportantKeyList = null;
        public CHtmlCSSStyleSheet(CHtmlElementStyleType targetType)
        {
            this.___StyleType = targetType;
            this.___styleAttributeList = new System.Collections.Generic.List<CHtmlStyleAttribute?>();
            if (targetType != CHtmlElementStyleType.None)
            {
                this.___StyleImportantKeyList = new System.Collections.Generic.Dictionary<CSSAttributeType, sbyte>();
                this.___multipleBackgroundImageDataSet = new System.Collections.Generic.List<CHtmlStyleElementMultpleImageData>();
                this.___cssRules = new CHtmlCollection();
                this.___cssRules.___CollectionType = CHtmlHTMLCollectionType.CSSRuleList;
                this.___cssRules.___createObjectIDTable();
            }

        }
        internal CHtmlSizeModeType ___styleSizeMode = CHtmlSizeModeType.Undefined;

        internal CHtmlCollection ___styleCHtmlCollection = null;

        internal bool ___IsOwnerElementAssigned()
        {
            if (this.___ownerElementWeakReference != null && this.___ownerElementWeakReference.IsAlive == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        internal bool ___IsDocumentAssigned()
        {
            if (this.___documentWeakReference != null && this.___documentWeakReference.IsAlive == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// Size of Rem Size of HTML Element
        /// default : -1
        /// </summary>
        internal double ___HTMLTagRemUnitSize = -1;

        /// <summary>
        /// Flags indicates this object is prototypoe mather.
        /// </summary>
        public bool ___IsPrototype = false;


   


        public CHtmlElement ownerElement
        {
            get
            {
                if (this.___ownerElementWeakReference != null)
                {
                    return this.___ownerElementWeakReference.Target as CHtmlElement;
                }
                else
                {
                    return null;
                }
            }
        }
        public CHtmlMediaQueryNode ___MediaQueryNodeInstance = null;
        public System.WeakReference ___MediaQueryNodeWeakReference = null;
        public CHtmlPseudoClassType ___PseudoClassType = CHtmlPseudoClassType.None;

        /// <summary>
        /// Sets or retrieves the media type. 
        /// ex. screen, all, print
        /// Keep This Feild As Public
        /// </summary>
        public string ___media = null;
        internal System.Text.StringBuilder ___StyleCommentBuilder = null;

        internal bool ___disabled = false;

        //internal CHtmlWebGradation ___WebGradation = null;



        internal CHtmlElementStyleType ___StyleType = CHtmlElementStyleType.None;
        // keep this field as internal
        internal string ___SelectorID = null;
        /// <summary>
        /// Sort Key Which is used for Ground Sort. LEAVE AS 'Field'
        /// </summary>
        public string ___GroundSortKey = null;

        /// <summary>
        /// Working Selector Sorting Key
        /// </summary>
        public string ___WorkingKey = null;
        /// <summary>
        /// Working Selector Sorting Key
        /// </summary>
        public char ___WorkingKeyCombinatorChar = '\0';

        public CHtmlClassList ___WorkingKeyClassList = null;

        public System.Collections.Generic.Dictionary<CHtmlPseudoClassType, CHtmlStyleElementPseudoClassValue?> ___WorkingKeyPseudoTitleList = null;

        public System.Collections.Generic.Dictionary<string, CHtmlStyleElementSelectorKeyAttributeClass?> ___WorkingKeyAttributeKeyList = null;


        /// <summary>
        /// List of Multiple BackgroundImage List for CSS3 support.
        /// </summary>
        internal System.Collections.Generic.List<CHtmlStyleElementMultpleImageData> ___multipleBackgroundImageDataSet = null;
        public CHtmlStyleKey ___WorkingSelectorClassKey = null;
        /// <summary>
        /// Length of WorkingSelectorList Items When ___ReCreateWorkingKey() has run last Time.
        /// </summary>
   
        public int ___LastReCreateWorkingKeyCompleteListLength = 0;

        internal bool ___IsCssTopValueDefined = false;
        internal bool ___IsCssRightValueDefined = false;
        internal bool ___IsCssLeftValueDefined = false;
        internal bool ___IsCssBottomValueDefined = false;
        /// <summary>
        /// CSS Import usage only
        /// </summary>
        internal System.WeakReference ___srcElementReference = null;

        /// <summary>
        /// Property Populated Count through  ___applyElemenetStyleSheets(CHtmlElement htmlElement, bool _ForceReset, bool SkipTagAttributes, bool SkipStylesheet) methods
        /// </summary>

        /// <summary>
        /// Foreground Color (System.Color)
        /// </summary>
        public System.Drawing.Color ___ForegroundSysColor = System.Drawing.Color.Black;
        public bool ___IsForegroundSysColorSpecified = false;

        /// <summary>
        /// Background Color (System.Color)
        /// </summary>
        public System.Drawing.Color ___BackgroundSysColor = commonHTML.HTMLEmptyColor;


        public bool ___IsBackgroundColorSpecified = false;
        /// <summary>
        /// How many style information has been moved to properties
        /// </summary>
        internal int ___PropertyMeargedCount = 0;

        /// <summary>
        /// How many font related properties has been set (except for color)
        /// </summary>
        internal int ___FontRelatedCount = 0;
        /// <summary>
        /// Original Selector Text
        /// </summary>
        public string ___SelectorTextOriginal = null;


        public int ___MaximumOfWorkingSelectorList = 0;

        /// <summary>
        /// Indicates ElementStyle Has Combinator
        /// </summary>
   
        public bool ___HasCombinatorChar = false;
        /// <summary>
        /// Selector Ranking indicates how important this style is.
        /// ID -----)) CLASS ----)) TAG
        /// </summary>
   
        public int ___SelectorRanking = 0;

   
        public double ___SelectorMediaQueryRanking = STYLE_MEDIA_RANKING_LOWEST;
        public static double STYLE_MEDIA_RANKING_LOWEST = -99999;

   
        public int ___SelectorConmaCount = 0;

        /// <summary>
        /// Character postion where this value appears on css.
        /// </summary>
   
        public int ___CSSPosition = int.MaxValue;








        public void SetSelectorIDDirect(string val)
        {
            this.___SelectorID = val;

        }


        /// <summary>
        /// Just For Debugger GUI Readablitiy
        /// </summary>
        public string ___AAA
        {
            get { return this.___SelectorID; }
        }
        public string SelectorID
        {
            get { return this.___SelectorID; }
            set
            {
                this.___SelectorID = value;
            }
        }
        /*
        public double addRule(object ___selector, object ___style, object ___id)
        {
            return this.___addRuleInner(___selector, ___style, ___id);
        }
        public double addRule(object ___selector, object ___style)
        {
            return this.___addRuleInner(___selector, ___style, null);
        }
         * 
        /// <summary>
        /// Add Rules to document
        /// </summary>
        /// <param name="___selectorObject">SelectorKey</param>
        /// <param name="___styleObject">styleData</param>
        /// <param name="___idObject">Position (ignored)</param>
        /// <returns>always -1</returns>
        private double ___addRuleInner(object ___selectorObject, object ___styleObject, object ___idObject)
        {
            if (commonLog.LoggingEnabled &&commonLog.CommonLogLevel > 10)
            {
               commonLog.LogEntry("entering {0}.addRuleInner(\'{1}\', \'{2}\', \'{3}\')", this, ___selectorObject, ___styleObject, ___idObject);
            }
            System.Text.StringBuilder sbNewStyle = new System.Text.StringBuilder();
            bool HasCuryBrucket = false;
            string selectorValue = commonHTML.GetStringValue(___selectorObject);
            if (string.IsNullOrEmpty(selectorValue) == false)
            {
                // ==============================================================
                // Some Selector Key may be "DD_belatedPNG\\:shape, DD_belatedPNG\\:fill"
                // 
                if (selectorValue.IndexOf('\\') > -1)
                {
                    selectorValue = selectorValue.Replace("\\", "");
                }
            }
            string styleValue = commonHTML.GetStringValue(___styleObject);
            if (string.IsNullOrEmpty(styleValue) == false)
            {
                if (styleValue[0] == '{')
                {
                    HasCuryBrucket = true;
                }

            }
            sbNewStyle.Append(selectorValue);

            sbNewStyle.Append(' ');
            if (HasCuryBrucket == false)
            {
                sbNewStyle.Append('{');
            }
            sbNewStyle.Append(styleValue);
            if (HasCuryBrucket == false)
            {
                sbNewStyle.Append('}');
            }
            this.cssTextSetter(sbNewStyle.ToString());

            return -1;

        }
         */
        /// <summary>
        /// false if the style sheet is applied to the document. true if it is not. Modifying this attribute may cause a new resolution of style for the document. A stylesheet only applies if both an appropriate medium definition is present and the disabled attribute is false. So, if the media doesn't apply to the current user agent, the disabled attribute is ignored.
        /// </summary>
        public bool disabled
        {
            set { this.___disabled = value; }
            get { return this.___disabled; }
        }
        public bool Disabled
        {
            set { this.___disabled = value; }
            get { return this.___disabled; }
        }


   
        public void setAttribute(string sName, string sValue)
        {
            this.setAttributeInner(sName, sValue, true, false);
        }
   
        public void setAttribute(string sName, string sValue, bool bOverWrite)
        {
            this.setAttributeInner(sName, sValue, bOverWrite, false);

        }
   
        public void setAttribute(string sName, string sValue, double ___casesensitive)
        {
            this.setAttributeInner(sName, sValue, true, false);

        }
        /// <summary>
        /// Just Merge CHtmlStyleAttribute into StyleLists.
        /// </summary>
        /// <param name="attribute"></param>
   
        internal void ___AddCHtmlStyleAttributeIntoStyleLists(CHtmlStyleAttribute attribute)
        {
            this.___styleAttributeList.Add(attribute);
        }
   
        internal void setAttributeInner(string sName, string sValue, bool bOverWrite, bool CaseSensitiveValue)
        {
            try
            {
                if (this.___HasStyleListSorted == false)
                {
                    this.___StyleListSort();
                }
                string sLow = "";
                if (sName != null)
                {
                    sLow = commonHTML.FasterTrimAndToLower(sName);
                }
                string sValueLow = "";
                if (CaseSensitiveValue == false)
                {
                    sValueLow = commonHTML.FasterToLower(sValue);
                }
                else
                {
                    sValueLow = sValue;
                }
                CHtmlStyleAttribute attrValue = new CHtmlStyleAttribute();
                attrValue.Name = sLow;
                attrValue.value = sValueLow;
                int pos = this.___styleAttributeList.BinarySearch(attrValue, new CHtmlStyleAttributeComparer());
                if (pos >= 0)
                {
                    if (bOverWrite)
                    {
                        this.___styleAttributeList[pos] = attrValue;
                    }
                }
                else
                {
                    pos = ~pos;
                    this.___styleAttributeList.Insert(pos, attrValue);
                }
            }
            catch (Exception ex)
            {
                if (commonLog.LoggingEnabled &&commonLog.CommonLogLevel > 5)
                {
                   commonLog.LogEntry("CHtmlCSSStyleSheet setAttributeInner({0}) Error : {1}", sName, ex.Message);
                }
            }
        }
   
        public void removeAttribute(string sName, long flag)
        {
            try
            {
                if (this.___HasStyleListSorted == false)
                {
                    this.___StyleListSort();
                }
                string sLow = "";
                if (sName != null)
                {
                    sLow = commonHTML.FasterTrimAndToLower(sName);
                }
                CHtmlStyleAttribute? attr = null;
                CHtmlStyleAttribute attrVal = (CHtmlStyleAttribute)attr;
                attrVal.Name = sLow;
                int pos = this.___styleAttributeList.BinarySearch(attr, new CHtmlStyleAttributeComparer());
                if (pos > -1)
                {
                    this.___styleAttributeList.RemoveAt(pos);

                }
                // There may be propery has been moved to fields. use 	this.___setPropertyByIndex() to clear fields.
                if (this.___IsOwnerElementAssigned() == true)
                {
                    if (this.ownerElement.___isApplyElemenetStyleSheetCalled == true)
                    {
                        this.___setPropertyByName(sName, "");
                    }
                }
            }
            catch (Exception ex)
            {
                if (commonLog.LoggingEnabled &&commonLog.CommonLogLevel > 5)
                {
                   commonLog.LogEntry("CHtmlCSSStyleSheet removeAttribute({0}) Error : {1}", sName, ex.Message);
                }
            }
        }
        /// <summary>
        /// Reset stylesheet values prior to css recaluculations.
        /// </summary>
        internal void ___clearCriticalStyleAttributesBeforeRecalulations()
        {
            this.___cssReclacationCount++;
            //this.___Display = null;
            // do not clear cssFloat values...now
            //this.___cssDisplayComputedValueType = CSSDisplayType.UNKNOWN;
            //this.___cssClearType = CSSElelemntFloatClearType.NotSet;
            //this.___styleSizeMode = CHtmlSizeModeType.Undefined;
            //this.___Visibility = null;
            //this.___cssVisibilityComputedValueType = CSSVisibilityType.visible;
        }
   
        public void removeAttribute(string sName)
        {
            this.removeAttribute(sName, 0);
        }
   
        public string getAttribute(string sName, long flag)
        {
            try
            {
                if (this.___HasStyleListSorted == false)
                {
                    this.___StyleListSort();
                }
                string sLow = "";
                if (sName != null)
                {
                    sLow = commonHTML.FasterTrimAndToLower(sName);
                }
                CHtmlStyleAttribute? attr = null;
                CHtmlStyleAttribute attrVal = (CHtmlStyleAttribute)attr;
                attrVal.Name = sLow;
                int pos = this.___styleAttributeList.BinarySearch(attr, new CHtmlStyleAttributeComparer());
                if (pos > -1)
                {
                    CHtmlStyleAttribute? xattr = this.___styleAttributeList[pos];
                    if (xattr != null)
                    {
                        CHtmlStyleAttribute styleAttribute = (CHtmlStyleAttribute)xattr;
                        return styleAttribute.value;
                    }
                    else
                    {
                        return "";
                    }

                }
                else
                {
                    return "";

                }
            }
            catch (Exception ex)
            {
                if (commonLog.LoggingEnabled &&commonLog.CommonLogLevel > 5)
                {
                   commonLog.LogEntry("CHtmlCSSStyleSheet getAttribute({0}) Error : {1}", sName, ex.Message);
                }
            }
            return "";

        }
        internal bool ___HasStyleListSorted = false;
        /// <summary>
        /// Sort StyleLists Elements by name
        /// As Default StyleLists are not sorted.
        /// It is sorted when jscript access with special methods.
        /// </summary>
        internal void ___StyleListSort()
        {
            try
            {

                this.___styleAttributeList.Sort(new CHtmlStyleAttributeComparer());
                this.___HasStyleListSorted = true;

            }
            catch (Exception ex)
            {
                if (commonLog.LoggingEnabled &&commonLog.CommonLogLevel > 3)
                {
                   commonLog.LogEntry("StyleListSort Exception", ex);
                }
            }
        }
        public CHtmlStyleAttribute? getStyleElemenetAttributeClassByName(string _name)
        {
            try
            {
                if (this.___HasStyleListSorted == false)
                {
                    this.___StyleListSort();
                }
                CHtmlStyleAttribute? attr = null;
                CHtmlStyleAttribute attrVal = (CHtmlStyleAttribute)attr;
                attrVal.Name = _name;
                int pos = this.___styleAttributeList.BinarySearch(attr, new CHtmlStyleAttributeComparer());
                if (pos > -1)
                {
                    return this.___styleAttributeList[pos];
                }
            }
            catch (Exception ex)
            {
                if (commonLog.LoggingEnabled &&commonLog.CommonLogLevel > 5)
                {
                   commonLog.LogEntry("CHtmlCSSStyleSheet getStyleElemenetAttributeClassByName({0}) Error : {1}", _name, ex.Message);
                }
            }
            return null;
        }
        
        /// <summary>
        /// Create CHtmlCSSStylesheet instance for this node as ".___sheet".
        /// it can be access as element.sheet by script.
        /// This methods can be called multiple times for dynamic elements.
        /// </summary>
        internal static void ___createCHtmlCSSStylesheetForElement(CHtmlElement ___elem)
        {
            if (___elem.___elementTagType  == CHtmlElementType.STYLE || ___elem.___elementTagType  == CHtmlElementType.LINK)
            {

                if (___elem.___sheet == null)
                {
                    ___elem.___sheet = new CHtmlCSSStyleSheet(CHtmlElementStyleType.Element);
                }


                ___elem.___sheet.___disabled = ___elem.disabled;


                if (string.IsNullOrEmpty(___elem.___type) == false)
                {
                    ___elem.___sheet.___type = string.Copy(___elem.___type);
                }
                if (___elem.___attributes.ContainsKey("media") == true)
                {
                    ___elem.___sheet.___media = string.Copy(commonHTML.GetElementAttributeInString(___elem, "media"));
                }
            }
        }
        

   
        public object getPropertyValue(object _nameObject)
        {
            try
            {

                string sName = commonHTML.GetStringValue(_nameObject);
                if (sName.IndexOf('-') > -1)
                {
                    sName = sName.Replace("-", "");
                }
                return this.___getPropertyByName(sName);
            }
            catch (Exception ex)
            {
                if (commonLog.LoggingEnabled &&commonLog.CommonLogLevel > 5)
                {
                   commonLog.LogEntry("CHtmlCSSStyleSheet getPropertyValue({0}) Error : {1}", _nameObject, ex.Message);
                }
            }
            return "";
        }
   
        public void setProperty(object _nameObject, object __oValue)
        {
            this.___setPropertyInner(_nameObject, __oValue, null);
        }
   
        public void setProperty(object _nameObject, object __oValue, object __oPriority)
        {
            this.___setPropertyInner(_nameObject, __oValue, __oPriority);
        }
   
        private void ___setPropertyInner(object _nameObject, object __oValue, object __oPriority)
        {
            try
            {
                // style.setProperty() can use 'background-color', not 'backgroundColor'
                // we remove '-' to set.
                string sName = commonHTML.GetStringValue(_nameObject);
                if (sName.IndexOf('-') > -1)
                {
                    sName = sName.Replace("-", "");
                }
                this.___setPropertyByName(sName, __oValue);
            }
            catch (Exception ex)
            {
                if (commonLog.LoggingEnabled &&commonLog.CommonLogLevel > 5)
                {
                   commonLog.LogEntry("CHtmlCSSStyleSheet setProperty({0}) Error : {1}", _nameObject, ex.Message);
                }
            }

        }
   
        public object getPropertyCSSValue(object _nameObject)
        {
            try
            {
                return this.___getPropertyByName(commonHTML.GetStringValue(_nameObject));
            }
            catch (Exception ex)
            {
                if (commonLog.LoggingEnabled &&commonLog.CommonLogLevel > 5)
                {
                   commonLog.LogEntry("CHtmlCSSStyleSheet getPropertyCSSValue({0}) Error : {1}", _nameObject, ex.Message);
                }
            }
            return "";
        }
        public string title
        {
            set
            {
                this.___SelectorID = value;
            }
            get
            {
                return this.___SelectorID;
            }
        }
        public string Title
        {
            set
            {
                this.___SelectorID = value;
            }
            get
            {
                return this.___SelectorID;
            }
        }

        internal string ___baseUrl = null;

        internal string ___ImageUrlHint = null;


        public string media
        {
            set { this.___media = value; }
            get { return this.___media; }
        }
        public string Media
        {
            set { this.___media = value; }
            get { return this.___media; }
        }
        internal string ___Align = null;
        public string Align
        {
            set { this.___Align = value; }
            get { return this.___Align; }
        }
        public string align
        {
            set { this.___Align = value; }
            get { return this.___Align; }
        }
        internal string ___AlignItems = null;
        /// <summary>
        /// Flex Related Parameter
        /// </summary>
        public string AlignItems
        {
            get { return this.___AlignItems; }
            set { this.___AlignItems = value; }
        }
        /// <summary>
        /// Flex Related Parameter
        /// </summary>
        public string alignitems
        {
            get { return this.___AlignItems; }
            set { this.___AlignItems = value; }
        }
        /// <summary>
        /// Flex Related Parameter
        /// </summary>
        public string alignItems
        {
            get { return this.___AlignItems; }
            set { this.___AlignItems = value; }
        }
        internal string ___Appearance = null;
        public string appearance
        {
            set { this.___Appearance = value; }
            get { return this.___Appearance; }
        }
        public string Appearance
        {
            set { this.___Appearance = value; }
            get { return this.___Appearance; }
        }
        public string mozAppearance
        {
            set { this.___Appearance = value; }
            get { return this.___Appearance; }
        }
        public string MozAppearance
        {
            set { this.___Appearance = value; }
            get { return this.___Appearance; }
        }
        public string webkitAppearance
        {
            set { this.___Appearance = value; }
            get { return this.___Appearance; }
        }
        public string WebkitAppearance
        {
            set { this.___Appearance = value; }
            get { return this.___Appearance; }
        }
        public string msAppearance
        {
            set { this.___Appearance = value; }
            get { return this.___Appearance; }
        }
        public string oAppearance
        {
            set { this.___Appearance = value; }
            get { return this.___Appearance; }
        }
        internal string ___FrameBorder = null;
        public string FrameBorder
        {
            get { return this.___FrameBorder; }
            set { this.___FrameBorder = value; }
        }
        public string frameBorder
        {
            get { return this.___FrameBorder; }
            set { this.___FrameBorder = value; }
        }
        private string ___fullscreen = null;
        /// <summary>
        /// fullscreen. possible values are like . 'width: 100%; height: 100%'
        /// </summary>
        public string fullscreen
        {
            get { return this.___fullscreen; }
            set { this.___fullscreen = value; }
        }
        /// <summary>
        /// fullscreen. possible values are like . 'width: 100%; height: 100%'
        /// </summary>
        public string mozfullscreen
        {
            get { return this.___fullscreen; }
            set { this.___fullscreen = value; }
        }
        /// <summary>
        /// fullscreen. possible values are like . 'width: 100%; height: 100%'
        /// </summary>
        public string webkitfullscreen
        {
            get { return ___convertNullToEmpty(this.___fullscreen); }
            set { this.___fullscreen = value; }
        }
        /// <summary>
        /// fullscreen. possible values are like . 'width: 100%; height: 100%'
        /// </summary>
        public string msfullscreen
        {
            get { return ___convertNullToEmpty(this.___fullscreen); }
            set { this.___fullscreen = value; }
        }
        /// <summary>
        /// fullscreen. possible values are like . 'width: 100%; height: 100%'
        /// </summary>
        public string ofullscreen
        {
            get { return ___convertNullToEmpty(this.___fullscreen); }
            set { this.___fullscreen = value; }
        }
        public string frameborder
        {
            get { return ___convertNullToEmpty(this.___FrameBorder); }
            set { this.___FrameBorder = value; }
        }

        private string ___Font = null;
        public string Font
        {
            set
            {
                this.___Font = value;
                this.___FontRelatedCount++;
            }
            get { return ___convertNullToEmpty(this.___Font); }
        }
        public string font
        {
            set
            {
                this.___Font = value;
                this.___FontRelatedCount++;
            }
            get { return ___convertNullToEmpty(this.___Font); }
        }
        private string ___FontSize = null;

        public string FontSize
        {
            set
            {
                this.___FontSize = value;
                this.___FontRelatedCount++;
            }
            get { return ___convertNullToEmpty(this.___FontSize); }
        }
        public string fontsize
        {
            set
            {
                this.___FontSize = value;
                this.___FontRelatedCount++;
            }
            get { return ___convertNullToEmpty(this.___FontSize); }
        }
        public string fontSize
        {
            set
            {
                this.___FontSize = value;
                this.___FontRelatedCount++;
            }
            get { return ___convertNullToEmpty(this.___FontSize); }
        }


        private string ___FontStyle = null;
        internal CSSFontStyleType ___FontStyleComputedValueType = CSSFontStyleType.normal;
        private void ___GetFontStyleType()
        {
            switch (this.___FontStyle)
            {
                case "normal":
                    this.___FontStyleComputedValueType = CSSFontStyleType.normal;
                    break;
                case "italic":
                    this.___FontStyleComputedValueType = CSSFontStyleType.italic;
                    break;
                case "oblique":
                    this.___FontStyleComputedValueType = CSSFontStyleType.oblique;
                    break;
            }
        }
        public string FontStyle
        {
            set
            {
                this.___FontStyle = value;
                this.___GetFontStyleType();
                this.___FontRelatedCount++;
            }
            get { return ___convertNullToEmpty(this.___FontStyle); }
        }
        public string fontstyle
        {
            set
            {
                this.___FontStyle = value;
                this.___GetFontStyleType();
                this.___FontRelatedCount++;
            }
            get { return ___convertNullToEmpty(this.___FontStyle); }
        }
        /// <summary>
        /// Obsolute Use Font Color Use 'Color' 
        /// </summary>

        private string ___FontColor = null;

        public string FontColor
        {
            set { this.___FontColor = value; }
            get { return ___convertNullToEmpty(this.___FontColor); }
        }
        public string fontcolor
        {
            set { this.___FontColor = value; }
            get { return ___convertNullToEmpty(this.___FontColor); }
        }

        internal string ___FontFamilyComputedStringValue = null;
        internal string ___FontKerning = null;
        public string fontKerning
        {
            set { this.___FontKerning = value; }
            get { return ___convertNullToEmpty(this.___FontKerning); }
        }
        public string FontKerning
        {
            set { this.___FontKerning = value; }
            get { return ___convertNullToEmpty(this.___FontKerning); }
        }
        internal string ___FontFamily = null;

        public string FontFamily
        {
            set
            {
                this.___FontFamily = value;
                this.___FontRelatedCount++;
            }
            get { return ___convertNullToEmpty(this.___FontFamily); }
        }
        public string fontfamily
        {
            set
            {
                this.___FontFamily = value;
                this.___FontRelatedCount++;
            }
            get { return ___convertNullToEmpty(this.___FontFamily); }
        }
        public string fontFamily
        {
            set
            {
                this.___FontFamily = value;
                this.___FontRelatedCount++;
            }
            get { return ___convertNullToEmpty(this.___FontFamily); }
        }

        private string ___FontWeight = null;
        internal CSSFontWeightType ___FontWeightComputedValueType = CSSFontWeightType.normal;
        private void ___GetFontWeightType()
        {
            switch (this.___FontWeight)
            {
                case null:
                case "none":
                case "":
                    this.___FontWeightComputedValueType = CSSFontWeightType.normal;
                    break;
                case "bold":
                    this.___FontWeightComputedValueType = CSSFontWeightType.bold;
                    break;
                case "bolder":
                    this.___FontWeightComputedValueType = CSSFontWeightType.bolder;
                    break;
                case "light":
                    this.___FontWeightComputedValueType = CSSFontWeightType.light;
                    break;
                case "lighter":
                    this.___FontWeightComputedValueType = CSSFontWeightType.lighter;
                    break;
                case "100":
                    this.___FontWeightComputedValueType = CSSFontWeightType.n100;
                    break;
                case "200":
                    this.___FontWeightComputedValueType = CSSFontWeightType.n200;
                    break;
                case "300":
                    this.___FontWeightComputedValueType = CSSFontWeightType.n300;
                    break;
                case "400":
                    this.___FontWeightComputedValueType = CSSFontWeightType.n400;
                    break;
                case "500":
                    this.___FontWeightComputedValueType = CSSFontWeightType.n500;
                    break;
                case "600":
                    this.___FontWeightComputedValueType = CSSFontWeightType.n600;
                    break;
                case "700":
                    this.___FontWeightComputedValueType = CSSFontWeightType.n700;
                    break;
                case "800":
                    this.___FontWeightComputedValueType = CSSFontWeightType.n800;
                    break;
                case "900":
                    this.___FontWeightComputedValueType = CSSFontWeightType.n900;
                    break;

            }
        }
        public string FontWeight
        {
            set
            {
                this.___FontWeight = value;
                ___GetFontWeightType();
                this.___FontRelatedCount++;
            }
            get { return this.___FontWeight; }
        }
        public string fontweight
        {
            set
            {
                this.___FontWeight = value;
                ___GetFontWeightType();
                this.___FontRelatedCount++;
            }
            get { return this.___FontWeight; }
        }
        public string fontWeight
        {
            set
            {
                this.___FontWeight = value;
                ___GetFontWeightType();
                this.___FontRelatedCount++;
            }
            get { return this.___FontWeight; }
        }
        private string ___FontVariant = null;
        public string FontVariant
        {
            set { this.___FontVariant = value; }
            get { return ___convertNullToEmpty(this.___FontVariant); }
        }
        public string fontvariant
        {
            set { this.___FontVariant = value; }
            get { return this.___FontVariant; }
        }
        public string fontVariant
        {
            set { this.___FontVariant = value; }
            get { return this.___FontVariant; }
        }
        private string ___FontFeatureSettings = null;
        public string fontfeaturesettings
        {
            set { this.___FontFeatureSettings = value; }
            get { return this.___FontFeatureSettings; }
        }
        public string fontFeatureSettings
        {
            set { this.___FontFeatureSettings = value; }
            get { return this.___FontFeatureSettings; }
        }
        public string fontfeatureSettings
        {
            set { this.___FontFeatureSettings = value; }
            get { return this.___FontFeatureSettings; }
        }
        internal string ___FontSmoothing = null;
        public string fontSmoothing
        {
            set { this.___FontSmoothing = value; }
            get { return ___convertNullToEmpty(this.___FontSmoothing); }
        }
        public string FontSmoothing
        {
            set { this.___FontSmoothing = value; }
            get { return ___convertNullToEmpty(this.___FontSmoothing); }
        }

        internal string ___FontSizeAdjust = null;
        public string FontSizeAdjust
        {
            set { this.___FontSizeAdjust = value; }
            get { return ___convertNullToEmpty(this.___FontSizeAdjust); }
        }
        public string fontSizeAdjust
        {
            set { this.___FontSizeAdjust = value; }
            get { return this.___FontSizeAdjust; }
        }
        public string fontsizeadjust
        {
            set { this.___FontSizeAdjust = value; }
            get { return this.___FontSizeAdjust; }
        }
        internal string ___GridColumns = null;
        /// <summary>
        /// Do not confuse with GridColumn
        /// </summary>
        public string GridColumns
        {
            get { return this.___GridColumns; }
            set { this.___GridColumns = value; }
        }
        /// <summary>
        /// Do not confuse with GridColumn
        /// </summary>
        public string gridColumns
        {
            get { return this.___GridColumns; }
            set { this.___GridColumns = value; }
        }
        /// <summary>
        /// Do not confuse with GridColumn
        /// </summary>
        public string gridcolumns
        {
            get { return this.___GridColumns; }
            set { this.___GridColumns = value; }
        }
        internal string ___GridColumn = null;
        /// <summary>
        /// Do not confuse with GridColumns
        /// </summary>
        public string GridColumn
        {
            get { return this.___GridColumn; }
            set { this.___GridColumn = value; }
        }
        /// <summary>
        /// Do not confuse with GridColumns
        /// </summary>
        public string gridColumn
        {
            get { return this.___GridColumn; }
            set { this.___GridColumn = value; }
        }
        /// <summary>
        /// Do not confuse with GridColumns
        /// </summary>
        public string gridcolumn
        {
            get { return this.___GridColumn; }
            set { this.___GridColumn = value; }
        }
        internal string ___GridColumnAlign = null;
        public string GridColumnAlign
        {
            get { return this.___GridColumnAlign; }
            set { this.___GridColumnAlign = value; }
        }
        public string gridcolumnalign
        {
            get { return this.___GridColumnAlign; }
            set { this.___GridColumnAlign = value; }
        }
        public string gridColumnAlign
        {
            get { return this.___GridColumnAlign; }
            set { this.___GridColumnAlign = value; }
        }
        internal string ___GridColumnSpan = null;
        public string GridColumnSpan
        {
            set { this.___GridColumnSpan = value; }
            get { return this.___GridColumnSpan; }
        }
        public string gridcolumnspan
        {
            set { this.___GridColumnSpan = value; }
            get { return this.___GridColumnSpan; }
        }
        public string gridColumnSpan
        {
            set { this.___GridColumnSpan = value; }
            get { return this.___GridColumnSpan; }
        }
        internal string ___GridRows = null;
        /// <summary>
        /// Dont Confuse with GridRow
        /// </summary>
        public string GridRows
        {
            get { return this.___GridRows; }
            set { this.___GridRows = value; }
        }
        /// <summary>
        /// Dont Confuse with GridRow
        /// </summary>
        public string gridrows
        {
            get { return this.___GridRows; }
            set { this.___GridRows = value; }
        }

        internal string ___GridRow = null;
        public string GridRow
        {
            get { return this.___GridRow; }
            set { this.___GridRow = value; }
        }
        public string gridrow
        {
            get { return this.___GridRow; }
            set { this.___GridRow = value; }
        }
        internal string ___GridRowAlign = null;
        public string GridRowAlign
        {
            get { return this.___GridRowAlign; }
            set { this.___GridRowAlign = value; }
        }
        public string gridrowalign
        {
            get { return this.___GridRowAlign; }
            set { this.___GridRowAlign = value; }
        }
        internal string ___GridRowSpan = null;
        public string GridRowSpan
        {
            get { return this.___GridRowSpan; }
            set { this.___GridRowSpan = value; }
        }
        public string gridrowspan
        {
            get { return this.___GridRowSpan; }
            set { this.___GridRowSpan = value; }
        }

        internal string ___tapHighlightColor = null;
        public string tapHighlightColor
        {
            set { this.___tapHighlightColor = value; }
            get { return this.___tapHighlightColor; }
        }
        public string TapHighlightColor
        {
            set { this.___tapHighlightColor = value; }
            get { return this.___tapHighlightColor; }
        }
        public string taphighlightcolor
        {
            set { this.___tapHighlightColor = value; }
            get { return this.___tapHighlightColor; }
        }
        internal string ___TabStops = null;
        public string TabStops
        {
            set { this.___TabStops = value; }
            get { return this.___TabStops; }
        }
        public string tabStops
        {
            set { this.___TabStops = value; }
            get { return this.___TabStops; }
        }
        public string tabstops
        {
            set { this.___TabStops = value; }
            get { return this.___TabStops; }
        }
        internal string ___TextJustify = null;
        public string TextJustify
        {
            set { this.___TextJustify = value; }
            get { return this.___TextJustify; }
        }
        public string textJustify
        {
            set { this.___TextJustify = value; }
            get { return this.___TextJustify; }
        }
        public string textjustify
        {
            set { this.___TextJustify = value; }
            get { return this.___TextJustify; }
        }
        internal string ___TextSizeAdjust = null;
        public string TextSizeAdjust
        {
            set { this.___TextSizeAdjust = value; }
            get { return this.___TextSizeAdjust; }
        }
        public string textSizeAdjust
        {
            set { this.___TextSizeAdjust = value; }
            get { return this.___TextSizeAdjust; }
        }
        public string textsizeadjust
        {
            set { this.___TextSizeAdjust = value; }
            get { return this.___TextSizeAdjust; }
        }

        internal string ___TextUnderLine = null;
        public string TextUnderLine
        {
            set { this.___TextUnderLine = value; }
            get { return this.___TextUnderLine; }
        }
        public string textUnderLine
        {
            set { this.___TextUnderLine = value; }
            get { return this.___TextUnderLine; }
        }
        public string textunderLine
        {
            set { this.___TextUnderLine = value; }
            get { return this.___TextUnderLine; }
        }

        internal string ___Page = null;
        public string Page
        {
            set { this.___Page = value; }
            get { return this.___Page; }
        }
        public string page
        {
            set { this.___Page = value; }
            get { return this.___Page; }
        }
        internal string ___PageBreakAfter = null;
        public string PageBreakAfter
        {
            set { this.___PageBreakAfter = value; }
            get { return this.___PageBreakAfter; }
        }
        public string pageBreakAfter
        {
            set { this.___PageBreakAfter = value; }
            get { return this.___PageBreakAfter; }
        }
        internal string ___PageBreakBefore = null;
        public string PageBreakBefore
        {
            set { this.___PageBreakBefore = value; }
            get { return this.___PageBreakBefore; }
        }
        public string pageBreakBefore
        {
            set { this.___PageBreakBefore = value; }
            get { return this.___PageBreakBefore; }
        }
        internal string ___PageBreakInside = null;
        public string PageBreakInside
        {
            get { return this.___PageBreakInside; }
            set { this.___PageBreakInside = value; }
        }
        public string pageBreakInside
        {
            get { return this.___PageBreakInside; }
            set { this.___PageBreakInside = value; }
        }
        public string pagebreakinside
        {
            get { return this.___PageBreakInside; }
            set { this.___PageBreakInside = value; }
        }
        internal string ___Perspective = null;
        public string Perspective
        {
            get { return this.___Perspective; }
            set { this.___Perspective = value; }
        }
        public string perspective
        {
            get { return this.___Perspective; }
            set { this.___Perspective = value; }
        }
        public string msPerspective
        {
            get { return this.___Perspective; }
            set { this.___Perspective = value; }
        }
        public string mozPerspective
        {
            get { return this.___Perspective; }
            set { this.___Perspective = value; }
        }
        public string webkitPerspective
        {
            get { return this.___Perspective; }
            set { this.___Perspective = value; }
        }
        internal string ___PerspectiveOrigin = null;
        public string PerspectiveOrigin
        {
            get { return this.___PerspectiveOrigin; }
            set { this.___PerspectiveOrigin = value; }
        }
        public string perspectiveOrigin
        {
            get { return this.___PerspectiveOrigin; }
            set { this.___PerspectiveOrigin = value; }
        }
        public string perspectiveorigin
        {
            get { return this.___PerspectiveOrigin; }
            set { this.___PerspectiveOrigin = value; }
        }
        internal string ___TransformStyle = null;
        public string TransformStyle
        {
            get { return this.___TransformStyle; }
            set { this.___TransformStyle = value; }
        }
        internal string ___LineHeight = null;
        internal double ___LineHeightComputedValue = -1;
        public string LineHeight
        {
            set { this.___LineHeight = value; }
            get { return this.___LineHeight; }
        }
        public string lineHeight
        {
            set { this.___LineHeight = value; }
            get { return this.___LineHeight; }
        }
        public string lineheight
        {
            set { this.___LineHeight = value; }
            get { return this.___LineHeight; }
        }

        internal string ___LineBreak = null;
        public string LineBreak
        {
            set { this.___LineBreak = value; }
            get { return this.___LineBreak; }
        }
        public string lineBreak
        {
            set { this.___LineBreak = value; }
            get { return this.___LineBreak; }
        }
        public string linebreak
        {
            set { this.___LineBreak = value; }
            get { return this.___LineBreak; }
        }
        internal string ___Clear = null;
        internal CSSElelemntFloatClearType ___cssClearType = CSSElelemntFloatClearType.NotSet;
        public string clear
        {
            set
            {
                this.___Clear = value;
                ___CheckCSSClear();
            }
            get { return ___convertNullToEmpty(this.___Clear); }
        }
        public string Clear
        {
            set
            {
                this.___Clear = value;
                ___CheckCSSClear();
            }
            get { return ___convertNullToEmpty(this.___Clear); }
        }
        private void ___CheckCSSClear()
        {
            if (string.IsNullOrEmpty(this.___Clear) == true)
            {
                this.___cssClearType = CSSElelemntFloatClearType.NotSet;
            }
            else if (string.Equals(this.___Clear, "left", StringComparison.OrdinalIgnoreCase) == true)
            {
                this.___cssClearType = CSSElelemntFloatClearType.Left;
            }
            else if (string.Equals(this.___Clear, "right", StringComparison.OrdinalIgnoreCase) == true)
            {
                this.___cssClearType = CSSElelemntFloatClearType.Right;
            }
            else if (string.Equals(this.___Clear, "both", StringComparison.OrdinalIgnoreCase) == true)
            {
                this.___cssClearType = CSSElelemntFloatClearType.Both;
            }
            else
            {
                this.___cssClearType = CSSElelemntFloatClearType.NotSet;
            }
        }

        internal CSSDisplayType ___cssDisplayComputedValueType = CSSDisplayType.UNKNOWN;
        /// <summary>
        /// Node Style Display is critcal for layout. Use Properties Always.
        /// </summary>
        internal string ___Display = null;
        public string Display
        {
            set
            {
                this.___Display = value;
                ___GetDisplayType();
            }
            get { return ___convertNullToEmpty(this.___Display); }
        }
        public string display
        {
            set
            {
                this.___Display = value;

                ___GetDisplayType();
            }
            get { return ___convertNullToEmpty(this.___Display); }
        }
        private static string ___convertNullToEmpty(string ___value)
        {
            if (___value == null)
                return "";
            return ___value;
        }
        internal void ___GetDisplayType()
        {
            switch (this.___Display)
            {
                case null:
                case "":
                case " ":
                    ___cssDisplayComputedValueType = CSSDisplayType.Block;
                    if (this.___StyleType == CHtmlElementStyleType.Element)
                    {
                        ____switchOwnerElementVisibilityByDisplayType(false, true);
                    }

                    return;
                case "relative": // bug but handle as block

                    ___cssDisplayComputedValueType = CSSDisplayType.Block;
                    return;
                case "none":
                    ___cssDisplayComputedValueType = CSSDisplayType.None;
                    if (this.___StyleType == CHtmlElementStyleType.Element)
                    {
                        ____switchOwnerElementVisibilityByDisplayType(true, false);
                    }
                    return;
                case "inline":
                    ___cssDisplayComputedValueType = CSSDisplayType.Inline;
                    if (this.___StyleType == CHtmlElementStyleType.Element)
                    {
                        ____switchOwnerElementVisibilityByDisplayType(true, true);
                    }
                    return;
                case "block":
                    ___cssDisplayComputedValueType = CSSDisplayType.Block;
                    if (this.___StyleType == CHtmlElementStyleType.Element)
                    {
                        ____switchOwnerElementVisibilityByDisplayType(true, true);
                    }
                    return;
                case "inline-block":
                case "inlne-block":
                case "inlineblock":
                    ___cssDisplayComputedValueType = CSSDisplayType.InlineBlock;
                    if (this.___StyleType == CHtmlElementStyleType.Element)
                    {
                        ____switchOwnerElementVisibilityByDisplayType(false, true);
                    }
                    return;
                case "inline-stack":
                case "inlinestack":
                    ___cssDisplayComputedValueType = CSSDisplayType.InlineStack;
                    if (this.___StyleType == CHtmlElementStyleType.Element)
                    {
                        ____switchOwnerElementVisibilityByDisplayType(false, true);
                    }
                    return;
                case "inline-box":
                    ___cssDisplayComputedValueType = CSSDisplayType.InlineBox;
                    if (this.___StyleType == CHtmlElementStyleType.Element)
                    {
                        ____switchOwnerElementVisibilityByDisplayType(false, true);
                    }
                    return;
                case "box":
                    ___cssDisplayComputedValueType = CSSDisplayType.Box;
                    if (this.___StyleType == CHtmlElementStyleType.Element)
                    {
                        ____switchOwnerElementVisibilityByDisplayType(false, true);
                    }
                    return;
                case "flex":
                    ___cssDisplayComputedValueType = CSSDisplayType.Flex;
                    if (this.___StyleType == CHtmlElementStyleType.Element)
                    {
                        ____switchOwnerElementVisibilityByDisplayType(false, true);
                    }
                    return;
                case "flex-box":
                case "flexbox":
                    ___cssDisplayComputedValueType = CSSDisplayType.FlexBox;
                    if (this.___StyleType == CHtmlElementStyleType.Element)
                    {
                        ____switchOwnerElementVisibilityByDisplayType(false, true);
                    }
                    return;
                case "compact":
                    ___cssDisplayComputedValueType = CSSDisplayType.Compact;
                    if (this.___StyleType == CHtmlElementStyleType.Element)
                    {
                        ____switchOwnerElementVisibilityByDisplayType(false, true);
                    }
                    return;
                case "grid":
                    ___cssDisplayComputedValueType = CSSDisplayType.Grid;
                    if (this.___StyleType == CHtmlElementStyleType.Element)
                    {
                        ____switchOwnerElementVisibilityByDisplayType(false, true);
                    }
                    return;
                case "inlinegrid":
                case "inline-grid":
                    ___cssDisplayComputedValueType = CSSDisplayType.InlineGrid;
                    if (this.___StyleType == CHtmlElementStyleType.Element)
                    {
                        ____switchOwnerElementVisibilityByDisplayType(false, true);
                    }
                    return;
                case "list-item":
                    ___cssDisplayComputedValueType = CSSDisplayType.ListItem;
                    if (this.___StyleType == CHtmlElementStyleType.Element)
                    {
                        ____switchOwnerElementVisibilityByDisplayType(false, true);
                    }
                    return;
                case "run-in":
                    ___cssDisplayComputedValueType = CSSDisplayType.RunIn;
                    if (this.___StyleType == CHtmlElementStyleType.Element)
                    {
                        ____switchOwnerElementVisibilityByDisplayType(false, true);
                    }
                    return;
                case "marker":
                    ___cssDisplayComputedValueType = CSSDisplayType.Marker;
                    if (this.___StyleType == CHtmlElementStyleType.Element)
                    {
                        ____switchOwnerElementVisibilityByDisplayType(false, true);
                    }
                    return;
                case "inline-table":
                    ___cssDisplayComputedValueType = CSSDisplayType.InlineTable;
                    if (this.___StyleType == CHtmlElementStyleType.Element)
                    {
                        ____switchOwnerElementVisibilityByDisplayType(false, true);
                    }
                    return;
                case "table":
                    ___cssDisplayComputedValueType = CSSDisplayType.Table;
                    if (this.___StyleType == CHtmlElementStyleType.Element)
                    {
                        ____switchOwnerElementVisibilityByDisplayType(false, true);
                    }
                    return;
                case "table-cell":
                    ___cssDisplayComputedValueType = CSSDisplayType.TableCell;
                    if (this.___StyleType == CHtmlElementStyleType.Element)
                    {
                        ____switchOwnerElementVisibilityByDisplayType(false, true);
                    }
                    return;
                case "table-row":
                    ___cssDisplayComputedValueType = CSSDisplayType.TableRow;
                    if (this.___StyleType == CHtmlElementStyleType.Element)
                    {
                        ____switchOwnerElementVisibilityByDisplayType(false, true);
                    }
                    return;
                case "table-caption":
                    ___cssDisplayComputedValueType = CSSDisplayType.TableCaption;
                    if (this.___StyleType == CHtmlElementStyleType.Element)
                    {
                        ____switchOwnerElementVisibilityByDisplayType(false, true);
                    }
                    return;
                case "table-header-group":
                    ___cssDisplayComputedValueType = CSSDisplayType.TableHeaderGroup;
                    if (this.___StyleType == CHtmlElementStyleType.Element)
                    {
                        ____switchOwnerElementVisibilityByDisplayType(false, true);
                    }
                    return;
                case "table-column-group":
                    ___cssDisplayComputedValueType = CSSDisplayType.TableColumnGroup;
                    if (this.___StyleType == CHtmlElementStyleType.Element)
                    {
                        ____switchOwnerElementVisibilityByDisplayType(false, true);
                    }
                    return;
                case "table-footer-group":
                    ___cssDisplayComputedValueType = CSSDisplayType.TableFooterGroup;
                    if (this.___StyleType == CHtmlElementStyleType.Element)
                    {
                        ____switchOwnerElementVisibilityByDisplayType(false, true);
                    }
                    return;
                case "ruby":
                    ___cssDisplayComputedValueType = CSSDisplayType.Ruby;
                    if (this.___StyleType == CHtmlElementStyleType.Element)
                    {
                        ____switchOwnerElementVisibilityByDisplayType(false, true);
                    }
                    return;
                case "ruby-text":
                    ___cssDisplayComputedValueType = CSSDisplayType.RubyText;
                    if (this.___StyleType == CHtmlElementStyleType.Element)
                    {
                        ____switchOwnerElementVisibilityByDisplayType(false, true);
                    }
                    return;
                case "ruby-text-group":
                    ___cssDisplayComputedValueType = CSSDisplayType.RubyTextGroup;
                    if (this.___StyleType == CHtmlElementStyleType.Element)
                    {
                        ____switchOwnerElementVisibilityByDisplayType(false, true);
                    }
                    return;
                case "ruby-base-group":
                    ___cssDisplayComputedValueType = CSSDisplayType.RubyBaseGroup;
                    if (this.___StyleType == CHtmlElementStyleType.Element)
                    {
                        ____switchOwnerElementVisibilityByDisplayType(false, true);
                    }
                    return;
                case "inherit":
                    ___cssDisplayComputedValueType = CSSDisplayType.Inherit;
                    if (this.___StyleType == CHtmlElementStyleType.Element)
                    {
                        ____switchOwnerElementVisibilityByDisplayType(false, true);
                    }
                    return;

            }
            if (commonLog.LoggingEnabled &&commonLog.CommonLogLevel >= 5)
            {
               commonLog.LogEntry("Unknown Style Display Type : " + this.___Display);
            }
            this.___cssDisplayComputedValueType = CSSDisplayType.Block;
        }
        private void ____switchOwnerElementVisibilityByDisplayType(bool ___originalVisible, bool ___targetVisible)
        {
            if (this.___StyleType == CHtmlElementStyleType.Element && this.___IsOwnerElementAssigned() == true)
            {
                CHtmlElement ___owner = this.ownerElement;
                if (___owner != null)
                {
                    if (___owner.___IsElementVisible == ___originalVisible && ___owner.___isApplyElemenetStyleSheetCalled == true)
                    {
                        if (commonLog.LoggingEnabled &&commonLog.CommonLogLevel >= 10)
                        {
                           commonLog.LogEntry("Style Display has switched to '{0}' for {1}. Element Visibility switch {2} -> {3}", this.___Display, ___owner, ___originalVisible, ___targetVisible);
                        }
                        ___cssDisplayComputedValueType = CSSDisplayType.Block;
                        ___owner.___IsElementVisible = ___targetVisible;
                    }
                    ___owner.___IsElementVisible = ___targetVisible;
                }
            }
        }
        internal string ___Orphans;
        public string orphans
        {
            get { return ___convertNullToEmpty(this.___Orphans); }
            set { this.___Orphans = value; }
        }
        public string Orphans
        {
            get { return ___convertNullToEmpty(this.___Orphans); }
            set { this.___Orphans = value; }
        }
        internal string ___MarginStart = null;
        public string MarginStart
        {
            get { return ___convertNullToEmpty(this.___MarginStart); }
            set { this.___MarginStart = value; }
        }
        public string marginstart
        {
            get { return ___convertNullToEmpty(this.___MarginStart); }
            set { this.___MarginStart = value; }
        }
        internal string ___MarginEnd = null;
        public string MarginEnd
        {
            get { return ___convertNullToEmpty(this.___MarginEnd); }
            set { this.___MarginEnd = value; }
        }
        public string marginEnd
        {
            get { return ___convertNullToEmpty(this.___MarginEnd); }
            set { this.___MarginEnd = value; }
        }
        public string marginend
        {
            get { return ___convertNullToEmpty(this.___MarginEnd); }
            set { this.___MarginEnd = value; }
        }

        internal string ___Width = null;
        internal double ___WidthComputedValue = 0;
        internal bool ___isWidthValueSet = false;
        internal bool ___isWidthValuePercent = false;
        internal bool ___isWidthDynamicCalculationRequired = false;
        public double posWidth
        {
            set
            {
                this.___Width = value.ToString();
            }
            get
            {
                return commonHTML.GetDoubleValueFromString(this.___Width, 0, this.___HTMLTagRemUnitSize);
            }
        }
        internal string ___Widows = null;
        /// <summary>
        /// The widows property sets or returns the minimum number of lines for an element that must be visible at the top of a page (for printing or print preview).		The widows property only affects block-level elements.		Tip: widows:5 means that at least 5 lines must be visible below the page break.
        ///Tip: See the orphans property to set or return the minimum number of lines for an element that must be visible at the bottom of a page.
        /// </summary>
        public string widows
        {
            get { return this.___Widows; }
            set { this.___Widows = value; }
        }
        /// <summary>
        /// The widows property sets or returns the minimum number of lines for an element that must be visible at the top of a page (for printing or print preview).		The widows property only affects block-level elements.		Tip: widows:5 means that at least 5 lines must be visible below the page break.
        ///Tip: See the orphans property to set or return the minimum number of lines for an element that must be visible at the bottom of a page.
        /// </summary>
        public string Widows
        {
            get { return this.___Widows; }
            set { this.___Widows = value; }
        }
        public double poswidth
        {
            set
            {
                this.posWidth = value;

            }
            get
            {
                return this.posWidth;
            }
        }
        public double pixelWidth
        {
            set { this.posWidth = value; }
            get { return this.posWidth; }
        }

        public string width
        {
            get { return this.___Width; }
            set
            {
                this.___Width = value;
                ___checkStringValue(this.___Width, ref this.___WidthComputedValue, ref  this.___isWidthValueSet, ref this.___isWidthValuePercent, true, false);
                if (this.___isWidthValueSet == true)
                {
                    this.___setStyleSizingMode(CHtmlSizeModeType.Width);
                }
                if (this.___isApplyElemenetStyleSheetsForElementDone == true)
                {
                    GetRecaluclateWidth();
                }
            }
        }
        public string Width
        {
            get { return this.___Width; }
            set
            {
                this.___Width = value;
                ___checkStringValue(this.___Width, ref this.___WidthComputedValue, ref  this.___isWidthValueSet, ref this.___isWidthValuePercent, true, false);
                if (this.___isWidthValueSet == true && this.___isWidthValuePercent == false)
                {
                    this.___setStyleSizingMode(CHtmlSizeModeType.Width);
                }
                if (this.___isApplyElemenetStyleSheetsForElementDone == true)
                {
                    GetRecaluclateWidth();
                }
            }
        }


        internal void GetRecaluclateWidth()
        {
            if (this.___IsOwnerElementAssigned() == true)
            {
                CHtmlElement ___owner = this.ownerElement;
                if (___owner != null && ___owner.___isApplyElemenetStyleSheetCalled == true)
                {
                    if (this.___StyleType == CHtmlElementStyleType.Element)
                    {
                        if (___owner.___parentWeakRef != null && ___owner.___parentWeakRef.Target is CHtmlElement)
                        {
                            ___owner.___offsetWidth = commonHTML.GetDoubleValueFromString(this.___Width, ___owner.___getParentElement().___availWidth, this.___HTMLTagRemUnitSize);
                        }
                        else
                        {
                            ___owner.___offsetWidth = commonHTML.GetDoubleValueFromString(this.___Width, ___owner.___availWidth, this.___HTMLTagRemUnitSize);

                        }
                    }
                }
            }
        }
        internal void GetRecaluclateHeight()
        {
            try
            {
                if (this.___IsOwnerElementAssigned() == true)
                {
                    CHtmlElement ___owner = this.ownerElement;
                    if (___owner != null && ___owner.___isApplyElemenetStyleSheetCalled == true)
                    {
                        if (this.___StyleType == CHtmlElementStyleType.Element)
                        {


                            CHtmlElement ___parentElement = ___owner.___getParentElement();
                            if (___parentElement != null)
                            {
                                ___owner.___offsetHeight = commonHTML.GetDoubleValueFromString(this.___Height, ___parentElement.___availHeight, this.___HTMLTagRemUnitSize);
                            }
                            else
                            {
                                ___owner.___offsetHeight = commonHTML.GetDoubleValueFromString(this.___Height, ___owner.___availHeight, this.___HTMLTagRemUnitSize);
                            }

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                if (commonLog.LoggingEnabled &&commonLog.CommonLogLevel >= 8)
                {
                   commonLog.LogEntry("CHtmlCSSStyleSheet GetRecalculateHeight()", ex);
                }
            }
        }
        internal string ___Height = null;
        internal double ___HeightComputedValue = 0;
        internal bool ___isHeightValueSet = false;
        internal bool ___isHeightValuePercent = false;
        internal bool ___isHeightDynamicCalculationRequired = false;
        public double posHeight
        {
            set
            {
                this.___Height = value.ToString();
            }
            get
            {
                return commonHTML.GetDoubleValueFromString(this.___Height, 0, this.___HTMLTagRemUnitSize);
            }
        }
        public double posheight
        {
            set
            {
                this.posHeight = value;
            }
            get
            {
                return this.posHeight;
            }
        }

        public string height
        {
            get { return ___convertNullToEmpty(this.___Height); }
            set
            {
                this.___Height = value;
                ___checkStringValue(this.___Height, ref this.___HeightComputedValue, ref  this.___isHeightValueSet, ref this.___isHeightValuePercent, true, false);
                if (this.___isHeightValueSet == true && this.___isHeightValuePercent == false)
                {
                    this.___setStyleSizingMode(CHtmlSizeModeType.Height);
                }
                if (this.___isApplyElemenetStyleSheetsForElementDone == true)
                {
                    GetRecaluclateHeight();
                }
            }
        }
        internal void ___setStyleSizingMode(CHtmlSizeModeType ___targetSize)
        {
            if (___targetSize == CHtmlSizeModeType.Height)
            {
                if (this.___styleSizeMode == CHtmlSizeModeType.Undefined)
                {
                    this.___styleSizeMode = CHtmlSizeModeType.Height;
                }
                else if (this.___styleSizeMode == CHtmlSizeModeType.Width)
                {
                    this.___styleSizeMode = CHtmlSizeModeType.Both;
                }
            }
            else if (___targetSize == CHtmlSizeModeType.Width)
            {
                if (this.___styleSizeMode == CHtmlSizeModeType.Undefined)
                {
                    this.___styleSizeMode = CHtmlSizeModeType.Width;
                }
                else if (this.___styleSizeMode == CHtmlSizeModeType.Height)
                {
                    this.___styleSizeMode = CHtmlSizeModeType.Both;
                }
            }
        }
        public string Height
        {
            get { return ___convertNullToEmpty(this.___Height); }
            set
            {
                this.___Height = value;
                ___checkStringValue(this.___Height, ref this.___HeightComputedValue, ref  this.___isHeightValueSet, ref this.___isHeightValuePercent, true, false);
                if (this.___isHeightValueSet == true && this.___isHeightValuePercent == false)
                {
                    this.___setStyleSizingMode(CHtmlSizeModeType.Height);
                }
                if (this.___isApplyElemenetStyleSheetsForElementDone == true)
                {
                    GetRecaluclateHeight();
                }
            }
        }

        internal string ___HoverColor = null;
        public string HoverColor
        {
            set { this.___HoverColor = value; }
            get { return this.___HoverColor; }
        }
        public string hoverColor
        {
            set { this.___HoverColor = value; }
            get { return this.___HoverColor; }
        }
        public string hovercolor
        {
            set { this.___HoverColor = value; }
            get { return this.___HoverColor; }
        }
        internal string ___Hyphens = null;
        public string hyphens
        {
            set { this.___Hyphens = value; }
            get { return this.___Hyphens; }
        }
        public string Hyphens
        {
            set { this.___Hyphens = value; }
            get { return this.___Hyphens; }
        }
        public string ___HyphenateLines = null;
        public string HyphenateLines
        {
            get { return this.___HyphenateLines; }
            set { this.___HyphenateLines = value; }
        }
        public string hyphenatelines
        {
            get { return this.___HyphenateLines; }
            set { this.___HyphenateLines = value; }
        }
        public string hyphenateLines
        {
            get { return this.___HyphenateLines; }
            set { this.___HyphenateLines = value; }
        }
        internal string ___HyphenateLimitLines = null;
        public string hyphenatelimitlines
        {
            get { return this.___HyphenateLimitLines; }
            set { this.___HyphenateLimitLines = value; }
        }
        public string HyphenateLimitLines
        {
            get { return this.___HyphenateLimitLines; }
            set { this.___HyphenateLimitLines = value; }
        }
        public string hyphenateLimitLines
        {
            get { return this.___HyphenateLimitLines; }
            set { this.___HyphenateLimitLines = value; }
        }
        internal string ___HyphenateLimitZone = null;
        public string HyphenateLimitZone
        {
            get { return this.___HyphenateLimitZone; }
            set { this.___HyphenateLimitZone = value; }
        }
        public string hyphenateLimitZone
        {
            get { return this.___HyphenateLimitZone; }
            set { this.___HyphenateLimitZone = value; }
        }
        public string hyphenatelimitzone
        {
            get { return this.___HyphenateLimitZone; }
            set { this.___HyphenateLimitZone = value; }
        }

        internal string ___MsoList = null;
        public string MsoList
        {
            get { return this.___MsoList; }
            set { this.___MsoList = value; }
        }
        public string msolist
        {
            get { return this.___MsoList; }
            set { this.___MsoList = value; }
        }


        internal string ___Scrolling = null;
        public string Scrolling
        {
            get { return ___convertNullToEmpty(this.___Scrolling); }
            set { this.___Scrolling = value; }
        }
        public string scrolling
        {
            get { return ___convertNullToEmpty(this.___Scrolling); }
            set { this.___Scrolling = value; }
        }
        internal string ___ScrollBarArrowColor = null;
        public string ScrollBarArrowColor
        {
            set { this.___ScrollBarArrowColor = value; }
            get { return this.___ScrollBarArrowColor; }
        }
        public string scrollBarArrowColor
        {
            set { this.___ScrollBarArrowColor = value; }
            get { return this.___ScrollBarArrowColor; }
        }
        public string scrollbararrowcolor
        {
            set { this.___ScrollBarArrowColor = value; }
            get { return this.___ScrollBarArrowColor; }
        }
        internal string ___ScrollBarTrackColor = null;
        public string ScrollBarTrackColor
        {
            set { this.___ScrollBarTrackColor = value; }
            get { return this.___ScrollBarTrackColor; }
        }
        public string scrollBarTrackColor
        {
            set { this.___ScrollBarTrackColor = value; }
            get { return this.___ScrollBarTrackColor; }
        }
        public string scrollbartrackcolor
        {
            set { this.___ScrollBarTrackColor = value; }
            get { return this.___ScrollBarTrackColor; }
        }
        internal string ___ScrollBarDarkShadowColor = null;
        public string ScrollBarDarkShadowColor
        {
            set { this.___ScrollBarDarkShadowColor = value; }
            get { return this.___ScrollBarDarkShadowColor; }
        }
        public string scrollBarDarkShadowColor
        {
            set { this.___ScrollBarDarkShadowColor = value; }
            get { return this.___ScrollBarDarkShadowColor; }
        }
        public string scrollbardarkshadowcolor
        {
            set { this.___ScrollBarDarkShadowColor = value; }
            get { return this.___ScrollBarDarkShadowColor; }
        }
        internal string ___ScrollBarShadowColor = null;
        public string scrollbarShdowColor
        {
            get { return this.___ScrollBarShadowColor; }
            set { this.___ScrollBarShadowColor = value; }
        }
        internal string ___ScrollBarHighLightColor = null;
        public string ScrollBarHighLightColor
        {
            set { this.___ScrollBarHighLightColor = value; }
            get { return this.___ScrollBarHighLightColor; }
        }
        public string scrollBarHighLightColor
        {
            set { this.___ScrollBarHighLightColor = value; }
            get { return this.___ScrollBarHighLightColor; }
        }
        public string scrollbarhighlightcolor
        {
            set { this.___ScrollBarHighLightColor = value; }
            get { return this.___ScrollBarHighLightColor; }
        }
        internal string ___ScrollBar3DLightColor = null;
        public string ScrollBar3DLightColor
        {
            set { this.___ScrollBar3DLightColor = value; }
            get { return this.___ScrollBar3DLightColor; }
        }
        public string scrollBar3DLightColor
        {
            set { this.___ScrollBar3DLightColor = value; }
            get { return this.___ScrollBar3DLightColor; }
        }
        public string scrollbar3dlightcolor
        {
            set { this.___ScrollBar3DLightColor = value; }
            get { return this.___ScrollBar3DLightColor; }
        }
        internal string ___ScrollBarBaseColor = null;
        public string ScrollBarBaseColor
        {
            get { return this.___ScrollBarBaseColor; }
            set { this.___ScrollBarBaseColor = value; }
        }
        public string scrollBarBaseColor
        {
            get { return this.___ScrollBarBaseColor; }
            set { this.___ScrollBarBaseColor = value; }
        }
        public string scrollbarbasecolor
        {
            get { return this.___ScrollBarBaseColor; }
            set { this.___ScrollBarBaseColor = value; }
        }

        internal string ___ScrollBarFaceColor = null;
        public string ScrollBarFaceColor
        {
            set { this.___ScrollBarFaceColor = value; }
            get { return this.___ScrollBarFaceColor; }
        }
        public string scrollBarFaceColor
        {
            set { this.___ScrollBarFaceColor = value; }
            get { return this.___ScrollBarFaceColor; }
        }
        public string scrollbarfacecolor
        {
            set { this.___ScrollBarFaceColor = value; }
            get { return this.___ScrollBarFaceColor; }
        }
        internal string ___Margin = null;

        public string Margin
        {
            get { return this.___Margin; }
            set { this.___Margin = value; }
        }
        public string margin
        {
            get { return this.___Margin; }
            set { this.___Margin = value; }
        }

        internal string ___MarginAfter = null;
        public string MarginAfter
        {
            set { this.___MarginAfter = value; }
            get { return this.___MarginAfter; }
        }
        public string marginAfter
        {
            set { this.___MarginAfter = value; }
            get { return this.___MarginAfter; }
        }
        public string marginafter
        {
            set { this.___MarginAfter = value; }
            get { return this.___MarginAfter; }
        }
        internal string ___MarginBefore = null;
        public string MarginBefore
        {
            get { return this.___MarginBefore; }
            set { this.___MarginBefore = value; }
        }
        public string marginBefore
        {
            get { return this.___MarginBefore; }
            set { this.___MarginBefore = value; }
        }
        public string marginbefore
        {
            get { return this.___MarginBefore; }
            set { this.___MarginBefore = value; }
        }
        private string ___MarginLeft = null;
        internal double ___MarginLeftComputedValue = 0;
        public string MarginLeft
        {
            get { return this.___MarginLeft; }
            set
            {
                this.___MarginLeft = value;
                this.___GetMarginLeftComputedValue();
            }
        }
        public string marginleft
        {
            get { return this.___MarginLeft; }
            set
            {
                this.___MarginLeft = value;
                this.___GetMarginLeftComputedValue();
            }
        }
        public string marginLeft
        {
            get { return this.___MarginLeft; }
            set
            {
                this.___MarginLeft = value;
                this.___GetMarginLeftComputedValue();
            }
        }
        private string ___MarginRight = null;
        internal double ___MarginRightComputedValue = 0;
        public string MarginRight
        {
            get { return this.___MarginRight; }
            set
            {
                this.___MarginRight = value;
                this.___GetMarginRightComputedValue();
            }
        }
        public string marginRight
        {
            get { return this.___MarginRight; }
            set
            {
                this.___MarginRight = value;
                this.___GetMarginRightComputedValue();
            }
        }

        public string marginright
        {
            get { return this.___MarginRight; }
            set
            {
                this.___MarginRight = value;
                this.___GetMarginRightComputedValue();
            }
        }
        private string ___MarginTop = null;
        internal double ___MarginTopComputedValue = 0;
        public string MarginTop
        {
            get { return this.___MarginTop; }
            set
            {
                this.___MarginTop = value;
                this.___GetMarginTopComputedValue();
            }
        }
        private void ___GetMarginTopComputedValue()
        {
            try
            {
                if (commonHTML.IsStringAutoOrInheritOrZeroOrNone(this.___MarginTop))
                {
                    this.___MarginTopComputedValue = 0;
                }
                else
                {
                    double.TryParse(this.___MarginTop, out this.___MarginTopComputedValue);
                }
            }
            catch { }
        }
        private void ___GetMarginLeftComputedValue()
        {
            try
            {
                if (commonHTML.IsStringAutoOrInheritOrZeroOrNone(this.___MarginLeft))
                {
                    this.___MarginLeftComputedValue = 0;
                }
                else
                {
                    double.TryParse(this.___MarginLeft, out this.___MarginLeftComputedValue);
                }
            }
            catch { }
        }
        private void ___GetMarginRightComputedValue()
        {
            try
            {
                if (commonHTML.IsStringAutoOrInheritOrZeroOrNone(this.___MarginRight))
                {
                    this.___MarginRightComputedValue = 0;
                }
                else
                {
                    double.TryParse(this.___MarginRight, out this.___MarginRightComputedValue);
                }
            }
            catch { }
        }
        private void ___GetMarginBottomComputedValue()
        {
            try
            {
                if (commonHTML.IsStringAutoOrInheritOrZeroOrNone(this.___MarginBottom))
                {
                    this.___MarginBottomComputedValue = 0;
                }
                else
                {
                    double.TryParse(this.___MarginBottom, out this.___MarginBottomComputedValue);
                }
            }
            catch { }
        }
        public string marginTop
        {
            get { return this.___MarginTop; }
            set
            {
                this.___MarginTop = value;
                this.___GetMarginTopComputedValue();
            }
        }
        public string margintop
        {
            get { return this.___MarginTop; }
            set
            {
                this.___MarginTop = value;
                this.___GetMarginTopComputedValue();

            }
        }
        internal string ___MarginWidth = null;
        public string MarginWidth
        {
            set { this.___MarginWidth = value; }
            get { return this.___MarginWidth; }
        }
        public string marginWidth
        {
            set { this.___MarginWidth = value; }
            get { return this.___MarginWidth; }
        }
        public string marginwidth
        {
            set { this.___MarginWidth = value; }
            get { return this.___MarginWidth; }
        }
        internal string ___MarginHeight = null;
        public string MarginHeight
        {
            get { return this.___MarginHeight; }
            set { this.___MarginHeight = value; }
        }
        public string marginHeight
        {
            get { return this.___MarginHeight; }
            set { this.___MarginHeight = value; }
        }
        public string marginheight
        {
            get { return this.___MarginHeight; }
            set { this.___MarginHeight = value; }
        }


        private string ___MarginBottom = null;
        internal double ___MarginBottomComputedValue = 0;
        public string MarginBottom
        {
            get { return this.___MarginBottom; }
            set
            {
                this.___MarginBottom = value;
                this.___GetMarginBottomComputedValue();
            }
        }
        public string marginBottom
        {
            get { return this.___MarginBottom; }
            set
            {
                this.___MarginBottom = value;
                this.___GetMarginBottomComputedValue();
            }
        }
        public string marginbottom
        {
            get { return this.___MarginBottom; }
            set
            {
                this.___MarginBottom = value;
                this.___GetMarginBottomComputedValue();
            }
        }
        internal string ___Padding = null;
        public string Padding
        {
            get { return this.___Padding; }
            set { this.___Padding = value; }
        }
        public string padding
        {
            get { return this.___Padding; }
            set { this.___Padding = value; }
        }

        internal string ___PaddingStart = null;
        public string PaddingStart
        {
            get { return this.___PaddingStart; }
            set { this.___PaddingStart = value; }
        }
        public string paddingStart
        {
            get { return this.___PaddingStart; }
            set { this.___PaddingStart = value; }
        }
        public string paddingstart
        {
            get { return this.___PaddingStart; }
            set { this.___PaddingStart = value; }
        }

        internal string ___PaddingEnd = null;
        public string PaddingEnd
        {
            get { return this.___PaddingEnd; }
            set { this.___PaddingEnd = value; }
        }
        public string paddingEnd
        {
            get { return this.___PaddingEnd; }
            set { this.___PaddingEnd = value; }
        }
        public string paddingend
        {
            get { return this.___PaddingEnd; }
            set { this.___PaddingEnd = value; }
        }



        internal string ___PaddingLeft = null;
        public string PaddingLeft
        {
            get { return this.___PaddingLeft; }
            set { this.___PaddingLeft = value; }
        }
        public string paddingLeft
        {
            get { return this.___PaddingLeft; }
            set { this.___PaddingLeft = value; }
        }
        public string paddingleft
        {
            get { return this.___PaddingLeft; }
            set { this.___PaddingLeft = value; }
        }
        internal string ___PaddingRight = null;
        public string PaddingRight
        {
            get { return this.___PaddingRight; }
            set { this.___PaddingRight = value; }
        }
        public string paddingRight
        {
            get { return this.___PaddingRight; }
            set { this.___PaddingRight = value; }
        }
        public string paddingright
        {
            get { return this.___PaddingRight; }
            set { this.___PaddingRight = value; }
        }

        internal string ___PaddingTop = null;
        public string PaddingTop
        {
            get { return this.___PaddingTop; }
            set
            {
                this.___PaddingTop = value;

            }
        }
        public string paddingTop
        {
            get { return this.___PaddingTop; }
            set
            {
                this.___PaddingTop = value;
            }
        }
        public string paddingtop
        {
            get { return this.___PaddingTop; }
            set
            {
                this.___PaddingTop = value;

            }
        }
        internal string ___PaddingBottom = null;
        public string PaddingBottom
        {
            get { return this.___PaddingBottom; }
            set { this.___PaddingBottom = value; }
        }
        public string paddingBottom
        {
            get { return this.___PaddingBottom; }
            set { this.___PaddingBottom = value; }
        }
        public string paddingbottom
        {
            get { return this.___PaddingBottom; }
            set { this.___PaddingBottom = value; }
        }
        internal string ___Pitch = null;
        public string Pitch
        {
            get { return this.___Pitch; }
            set { this.___Pitch = value; }
        }
        public string pitch
        {
            get { return this.___Pitch; }
            set { this.___Pitch = value; }
        }
        internal string ___PitchRange = null;
        public string PitchRange
        {
            get { return this.___PitchRange; }
            set { this.___PitchRange = value; }
        }
        internal string ___Richness = null;
        public string Richness
        {
            get { return this.___Richness; }
            set { this.___Richness = value; }
        }
        public string richness
        {
            get { return this.___Richness; }
            set { this.___Richness = value; }
        }
        internal string ___Stress = null;
        public string Stress
        {
            get { return this.___Stress; }
            set { this.___Stress = value; }
        }
        public string stress
        {
            get { return this.___Stress; }
            set { this.___Stress = value; }
        }
        internal string ___Border = null;
        public string Border
        {
            get { return this.___Border; }
            set { this.___Border = value; }
        }
        public string border
        {
            get { return this.___Border; }
            set { this.___Border = value; }
        }
        internal string ___BorderStyle = null;
        public string BorderStyle
        {
            get { return this.___BorderStyle; }
            set { this.___BorderStyle = value; }
        }
        public string borderstyle
        {
            get { return this.___BorderStyle; }
            set { this.___BorderStyle = value; }
        }
        public string borderStyle
        {
            get { return this.___BorderStyle; }
            set { this.___BorderStyle = value; }
        }
        internal string ___BorderSpacing = null;
        public string BorderSpacing
        {
            get { return this.___BorderSpacing; }
            set { this.___BorderSpacing = value; }
        }
        public string borderspacing
        {
            get { return this.___BorderSpacing; }
            set { this.___BorderSpacing = value; }
        }
        public string borderSpacing
        {
            get { return this.___BorderSpacing; }
            set { this.___BorderSpacing = value; }
        }
        internal string ___BorderWidth = null;
        public string BorderWidth
        {
            get { return this.___BorderWidth; }
            set { this.___BorderWidth = value; }
        }
        public string borderwidth
        {
            get { return this.___BorderWidth; }
            set { this.___BorderWidth = value; }
        }
        public string borderWidth
        {
            get { return this.___BorderWidth; }
            set { this.___BorderWidth = value; }
        }
        internal string ___BorderCollapse = null;
        public string BorderCollapse
        {
            set { this.___BorderCollapse = value; }
            get { return this.___BorderCollapse; }
        }
        public string borderCollapse
        {
            set { this.___BorderCollapse = value; }
            get { return this.___BorderCollapse; }
        }
        public string bordercollapse
        {
            set { this.___BorderCollapse = value; }
            get { return this.___BorderCollapse; }
        }
        internal string ___BorderTop = null;
        internal double ___BorderTopWidthComputedValue = 0;
        internal CSSBorderStyleType ___BorderTopStyleComputedValue = CSSBorderStyleType.unknown;
        internal System.Drawing.Color ___BorderTopColorComputedValue = System.Drawing.Color.Transparent;
        internal bool ___BorderTopColorComputedValueSpecified = false;
        public string BorderTop
        {
            set { this.___BorderTop = value; }
            get { return this.___BorderTop; }
        }
        public string borderTop
        {
            set { this.___BorderTop = value; }
            get { return this.___BorderTop; }
        }
        public string bordertop
        {
            set { this.___BorderTop = value; }
            get { return this.___BorderTop; }
        }
        internal string ___BorderTopColor = null;
        public string BorderTopColor
        {
            set { this.___BorderTopColor = value; }
            get { return this.___BorderTopColor; }
        }
        public string borderTopColor
        {
            set { this.___BorderTopColor = value; }
            get { return this.___BorderTopColor; }
        }
        public string bordertopcolor
        {
            set { this.___BorderTopColor = value; }
            get { return this.___BorderTopColor; }
        }
        internal string ___BorderTopColors = null;
        public string BorderTopColors
        {
            set { this.___BorderTopColors = value; }
            get { return this.___BorderTopColors; }
        }
        public string borderTopColors
        {
            set { this.___BorderTopColors = value; }
            get { return this.___BorderTopColors; }
        }
        public string bordertopcolors
        {
            set { this.___BorderTopColors = value; }
            get { return this.___BorderTopColors; }
        }
        internal string ___BorderBottomColors = null;
        public string BorderBottomColors
        {
            set { this.___BorderBottomColors = value; }
            get { return this.___BorderBottomColors; }
        }
        public string borderBottomColors
        {
            set { this.___BorderBottomColors = value; }
            get { return this.___BorderBottomColors; }
        }
        public string borderbottombcolors
        {
            set { this.___BorderBottomColors = value; }
            get { return this.___BorderBottomColors; }
        }
        internal string ___BorderLeftColors = null;
        public string BorderLeftColors
        {
            get { return this.___BorderLeftColors; }
            set { this.___BorderLeftColors = value; }
        }
        public string borderLeftColors
        {
            get { return this.___BorderLeftColors; }
            set { this.___BorderLeftColors = value; }
        }
        public string borderleftcolors
        {
            get { return this.___BorderLeftColors; }
            set { this.___BorderLeftColors = value; }
        }
        internal string ___BorderRightColors = null;
        public string BorderRightColors
        {
            set { this.___BorderRightColors = value; }
            get { return this.___BorderRightColors; }
        }
        public string borderRightColors
        {
            set { this.___BorderRightColors = value; }
            get { return this.___BorderRightColors; }
        }
        public string borderrightcolors
        {
            set { this.___BorderRightColors = value; }
            get { return this.___BorderRightColors; }
        }

        internal string ___BorderTopStyle = null;
        public string BorderTopStyle
        {
            set { this.___BorderTopStyle = value; }
            get { return this.___BorderTopStyle; }
        }
        public string bordertopstyle
        {
            set { this.___BorderTopStyle = value; }
            get { return this.___BorderTopStyle; }
        }
        internal string ___BorderTopWidth = null;
        public string BorderTopWidth
        {
            set { this.___BorderTopWidth = value; }
            get { return this.___BorderTopWidth; }
        }
        public string borderTopWidth
        {
            set { this.___BorderTopWidth = value; }
            get { return this.___BorderTopWidth; }
        }
        public string bordertopwidth
        {
            set { this.___BorderTopWidth = value; }
            get { return this.___BorderTopWidth; }
        }
        internal string ___BorderLeft = null;
        internal double ___BorderLeftWidthComputedValue = 0;
        internal CSSBorderStyleType ___BorderLeftStyleComputedValue = CSSBorderStyleType.unknown;
        internal System.Drawing.Color ___BorderLeftColorComputedValue = System.Drawing.Color.Transparent;
        internal bool ___BorderLeftColorComputedValueSpecified = false;
        public string BorderLeft
        {
            set { this.___BorderLeft = value; }
            get { return this.___BorderLeft; }
        }
        public string borderLeft
        {
            set { this.___BorderLeft = value; }
            get { return this.___BorderLeft; }
        }
        public string borderleft
        {
            set { this.___BorderLeft = value; }
            get { return this.___BorderLeft; }
        }
        internal string ___BorderLeftColor = null;
        public string BorderLeftColor
        {
            set { this.___BorderLeftColor = value; }
            get { return this.___BorderLeftColor; }
        }
        public string borderLeftColor
        {
            set { this.___BorderLeftColor = value; }
            get { return this.___BorderLeftColor; }
        }
        public string borderleftcolor
        {
            set { this.___BorderLeftColor = value; }
            get { return this.___BorderLeftColor; }
        }
        internal string ___BorderLeftStyle = null;
        public string BorderLeftStyle
        {
            set { this.___BorderLeftStyle = value; }
            get { return this.___BorderLeftStyle; }
        }
        public string borderLeftStyle
        {
            set { this.___BorderLeftStyle = value; }
            get { return this.___BorderLeftStyle; }
        }
        internal string ___BorderLeftWidth = null;
        public string BorderLeftWidth
        {
            set { this.___BorderLeftWidth = value; }
            get { return this.___BorderLeftWidth; }
        }
        public string borderLeftWidth
        {
            set { this.___BorderLeftWidth = value; }
            get { return this.___BorderLeftWidth; }
        }
        public string borderleftwidth
        {
            set { this.___BorderLeftWidth = value; }
            get { return this.___BorderLeftWidth; }
        }
        internal string ___BorderRight = null;
        internal double ___BorderRightWidthComputedValue = 0;
        internal CSSBorderStyleType ___BorderRightStyleComputedValue = CSSBorderStyleType.unknown;
        internal System.Drawing.Color ___BorderRightColorComputedValue = System.Drawing.Color.Transparent;
        internal bool ___BorderRightColorComputedValueSpecified = false;
        public string BorderRight
        {
            set { this.___BorderRight = value; }
            get { return this.___BorderRight; }
        }
        public string borderRight
        {
            set { this.___BorderRight = value; }
            get { return this.___BorderRight; }
        }
        public string borderright
        {
            set { this.___BorderRight = value; }
            get { return this.___BorderRight; }
        }
        internal string ___BorderRightColor = null;
        public string BorderRightColor
        {
            set { this.___BorderRightColor = value; }
            get { return this.___BorderRightColor; }
        }
        public string borderRightColor
        {
            set { this.___BorderRightColor = value; }
            get { return this.___BorderRightColor; }
        }
        public string borderrightcolor
        {
            set { this.___BorderRightColor = value; }
            get { return this.___BorderRightColor; }
        }
        internal string ___BorderRightStyle = null;
        public string BorderRightStyle
        {
            set { this.___BorderRightStyle = value; }
            get { return this.___BorderRightStyle; }
        }
        public string borderRightStyle
        {
            set { this.___BorderRightStyle = value; }
            get { return this.___BorderRightStyle; }
        }
        public string borderrightstyle
        {
            set { this.___BorderRightStyle = value; }
            get { return this.___BorderRightStyle; }
        }
        internal string ___BorderRightWidth = null;
        public string BorderRightWidth
        {
            set { this.___BorderRightWidth = value; }
            get { return this.___BorderRightWidth; }
        }
        public string borderRightWidth
        {
            set { this.___BorderRightWidth = value; }
            get { return this.___BorderRightWidth; }
        }
        public string borderrightwidth
        {
            set { this.___BorderRightWidth = value; }
            get { return this.___BorderRightWidth; }
        }
        internal string ___BorderBottom = null;
        internal double ___BorderBottomWidthComputedValue = 0;
        internal CSSBorderStyleType ___BorderBottomStyleComputedValue = CSSBorderStyleType.unknown;
        internal System.Drawing.Color ___BorderBottomColorComputedValue = System.Drawing.Color.Transparent;
        internal bool ___BorderBottomColorComputedValueSpecified = false;
        public string BorderBottom
        {
            set { this.___BorderBottom = value; }
            get { return this.___BorderBottom; }
        }
        public string borderBottom
        {
            set { this.___BorderBottom = value; }
            get { return this.___BorderBottom; }
        }
        public string borderbottom
        {
            set { this.___BorderBottom = value; }
            get { return this.___BorderBottom; }
        }
        internal string ___BorderBottomColor = null;
        public string BorderBottomColor
        {
            set { this.___BorderBottomColor = value; }
            get { return this.___BorderBottomColor; }
        }
        public string borderBottomColor
        {
            set { this.___BorderBottomColor = value; }
            get { return this.___BorderBottomColor; }
        }
        public string borderbottomcolor
        {
            set { this.___BorderBottomColor = value; }
            get { return this.___BorderBottomColor; }
        }
        internal string ___BorderBottomStyle = null;
        public string BorderBottomStyle
        {
            set { this.___BorderBottomStyle = value; }
            get { return this.___BorderBottomStyle; }
        }
        public string borderBottomStyle
        {
            set { this.___BorderBottomStyle = value; }
            get { return this.___BorderBottomStyle; }
        }
        public string borderbottomstyle
        {
            set { this.___BorderBottomStyle = value; }
            get { return this.___BorderBottomStyle; }
        }
        internal string ___BorderBottomWidth = null;
        public string BorderBottomWidth
        {
            set { this.___BorderBottomWidth = value; }
            get { return this.___BorderBottomWidth; }
        }
        public string borderBottomWidth
        {
            set { this.___BorderBottomWidth = value; }
            get { return this.___BorderBottomWidth; }
        }
        public string borderbottomwidth
        {
            set { this.___BorderBottomWidth = value; }
            get { return this.___BorderBottomWidth; }
        }
        internal string ___BorderColor = null;
        public string BorderColor
        {
            set { this.___BorderColor = value; }
            get { return this.___BorderColor; }
        }
        public string bordercolor
        {
            set { this.___BorderColor = value; }
            get { return this.___BorderColor; }
        }
        public string borderColor
        {
            set { this.___BorderColor = value; }
            get { return this.___BorderColor; }
        }
        internal string ___BorderImage = null;
        public string borderImage
        {
            set { this.___BorderImage = value; }
            get { return this.___BorderImage; }
        }
        public string borderimage
        {
            set { this.___BorderImage = value; }
            get { return this.___BorderImage; }
        }
        public string BorderImage
        {
            set { this.___BorderImage = value; }
            get { return this.___BorderImage; }
        }

        /* ================================================
         * Background Image is moveto MultipleImageDataList Do cnot use
         * ================================================
         */
        /// <summary>
        /// BackgroundImageFullUrl (Keep this as public)
        /// </summary>
        //public  string ___BackgroundImage_FullURL = null;

        //internal System.WeakReference ___BackgroundImage_ImageWeakReference = null;




        internal string ___BorderLightColor = null;
        public string BorderLightColor
        {
            set { this.___BorderLightColor = value; }
            get { return this.___BorderLightColor; }
        }
        public string borderLightColor
        {
            set { this.___BorderLightColor = value; }
            get { return this.___BorderLightColor; }
        }
        public string borderlightcolor
        {
            set { this.___BorderLightColor = value; }
            get { return this.___BorderLightColor; }
        }
        public string borderlightColor
        {
            set { this.___BorderLightColor = value; }
            get { return this.___BorderLightColor; }
        }
        internal string ___BorderDarkColor = null;
        public string BorderDarkColor
        {
            set { this.___BorderDarkColor = value; }
            get { return this.___BorderDarkColor; }
        }
        public string borderDarkColor
        {
            set { this.___BorderDarkColor = value; }
            get { return this.___BorderDarkColor; }
        }
        public string borderdarkcolor
        {
            set { this.___BorderDarkColor = value; }
            get { return this.___BorderDarkColor; }
        }



        /// <summary>
        /// Border Radius
        /// </summary>
        internal string ___BorderBottomLeftRadius = null;
        internal double ___BorderBottomLeftRadiusHorizontalComputedValue = 0;
        internal double ___BorderBottomLeftRadiusVerticalComputedValue = 0;
        public string BorderBottomLeftRadius
        {
            set { this.___BorderBottomLeftRadius = value; }
            get { return this.___BorderBottomLeftRadius; }
        }
        public string borderBottomLeftRadius
        {
            set { this.___BorderBottomLeftRadius = value; }
            get { return this.___BorderBottomLeftRadius; }
        }

        public string borderbottomleftradius
        {
            set { this.___BorderBottomLeftRadius = value; }
            get { return this.___BorderBottomLeftRadius; }
        }
        internal string ___BorderBottomRightRadius = null;
        internal double ___BorderBottomRightRadiusHorizontalComputedValue = 0;
        internal double ___BorderBottomRightRadiusVerticalComputedValue = 0;
        public string BorderBottomRightRadius
        {
            set { this.___BorderBottomRightRadius = value; }
            get { return this.___BorderBottomRightRadius; }
        }
        public string borderBottomRightRadius
        {
            set { this.___BorderBottomRightRadius = value; }
            get { return this.___BorderBottomRightRadius; }
        }

        public string borderbottomrightradius
        {
            set { this.___BorderBottomRightRadius = value; }
            get { return this.___BorderBottomRightRadius; }
        }
        internal string ___BorderTopLeftRadius = null;
        internal double ___BorderTopLeftRadiusHorizontalComputedValue = 0;
        internal double ___BorderTopLeftRadiusVerticalComputedValue = 0;

        public string BorderTopLeftRadius
        {
            set { this.___BorderTopLeftRadius = value; }
            get { return this.___BorderTopLeftRadius; }
        }
        public string borderTopLeftRadius
        {
            set { this.___BorderTopLeftRadius = value; }
            get { return this.___BorderTopLeftRadius; }
        }

        internal string ___BorderTopRightRadius = null;
        internal double ___BorderTopRightRadiusHorizontalComputedValue = 0;
        internal double ___BorderTopRightRadiusVerticalComputedValue = 0;
        public string BorderTopRightRadius
        {
            set { this.___BorderTopRightRadius = value; }
            get { return this.___BorderTopRightRadius; }
        }
        public string borderTopRightRadius
        {
            set { this.___BorderTopRightRadius = value; }
            get { return this.___BorderTopRightRadius; }
        }
        internal string ___BackgroundColor = null;
        public string BackgroundColor
        {
            set
            {
                this.___BackgroundColor = value;

                SetElementBackgroundColor();

            }
            get { return ___convertNullToEmpty(this.___BackgroundColor); }
        }
   
     
        public string fill
        {
            set { this.___BackgroundColor = value;
                SetElementBackgroundColor();
            }

            get { return this.backgroundColor; }
        }
        public string backgroundColor
        {
            set
            {
                this.___BackgroundColor = value;


                SetElementBackgroundColor();

            }
            get { return ___convertNullToEmpty(this.___BackgroundColor); }
        }
        public string backgroundcolor
        {
            set
            {
                this.___BackgroundColor = value;

                SetElementBackgroundColor();

            }
            get { return ___convertNullToEmpty(this.___BackgroundColor); }
        }
   
        public bool hasOwnProperty(object _oname)
        {
            string sName = _oname as string;
            if (string.IsNullOrEmpty(sName) == true)
                return false;
            return this.___hasPropertyByName(sName);
        }
        internal void SetElementBackgroundColor()
        {
            if (string.IsNullOrEmpty(this.___BackgroundColor) == false)
            {
                if(this.___BackgroundColor.StartsWith("url(", StringComparison.Ordinal) == true)
                {
                    this.___IsBackgroundColorSpecified = false;
                    return;
                }
                    
                this.___BackgroundSysColor = commonHTML.GetColorFromHTMLColorExtend(this.___BackgroundColor);
                this.___IsBackgroundColorSpecified = true;
                switch (this.___StyleType)
                {
                    case CHtmlElementStyleType.Element:
                    case CHtmlElementStyleType.Active:
                    case CHtmlElementStyleType.Hover:
                        if (this.___multipleBackgroundImageDataSet.Count == 0)
                        {
                            CHtmlStyleElementMultpleImageData __multiData = new CHtmlStyleElementMultpleImageData();
                            this.___multipleBackgroundImageDataSet.Add(__multiData);
                            __multiData.backgroundColorString = string.Copy(___BackgroundColor);
                            __multiData.backgroundColorComputedValue = this.___BackgroundSysColor;
                        }
                        else
                        {
                            this.___multipleBackgroundImageDataSet[0].backgroundColorComputedValue = this.___BackgroundSysColor;
                        }
                        break;
                }
                if (this.___StyleType == CHtmlElementStyleType.Element && this.___IsOwnerElementAssigned() == true)
                {
                    CHtmlElement ___owner = this.ownerElement;
                    if (___owner != null && ___owner.___isApplyElemenetStyleSheetCalled == true || this.___StyleType == CHtmlElementStyleType.Element)
                    {
                        ___owner.___BackgroundSysColor = this.___BackgroundSysColor;
                        ___owner.___IsBackgroundColorSpecified = true;
                        if (___owner.___elementTagType == CHtmlElementType.HTML)
                        {
                            if (commonHTML.IsEqualColor(___owner.___BackgroundSysColor, System.Drawing.Color.Transparent))
                            {
                                ___owner.___BackgroundSysColor = System.Drawing.Color.White;
                            }
                        }
                    }
                }
            }
            else
            {
                this.___IsBackgroundColorSpecified = false;
            }
        }
        internal string ___BackgroundSize = null;

        public string BackgroundSize
        {
            set
            {
                this.___BackgroundSize = value;
            }
            get { return this.___BackgroundSize; }
        }
        public string backgroundSize
        {
            set
            {
                this.___BackgroundSize = value;

            }
            get { return this.___BackgroundSize; }
        }
        public string backgroundsize
        {
            set
            {
                this.___BackgroundSize = value;

            }
            get { return this.___BackgroundSize; }
        }



        internal string ___BackgroundClip = null;
        public string BackgroundClip
        {
            set { this.___BackgroundClip = value; }
            get { return this.___BackgroundClip; }
        }
        public string backgroundclip
        {
            set { this.___BackgroundClip = value; }
            get { return this.___BackgroundClip; }
        }
        public string backgroundClip
        {
            set { this.___BackgroundClip = value; }
            get { return this.___BackgroundClip; }
        }

        internal string ___BackgroundInlinePolicy = null;
        public string BackgroundInlinePolicy
        {
            set { this.___BackgroundInlinePolicy = value; }
            get { return this.___BackgroundInlinePolicy; }
        }
        public string backgroundInlinePolicy
        {
            set { this.___BackgroundInlinePolicy = value; }
            get { return this.___BackgroundInlinePolicy; }
        }
        public string backgroundinlinepolicy
        {
            set { this.___BackgroundInlinePolicy = value; }
            get { return this.___BackgroundInlinePolicy; }
        }

        internal string ___BackgroundOrigin = null;
        public string BackgroundOrigin
        {
            set { this.___BackgroundOrigin = value; }
            get { return this.___BackgroundOrigin; }
        }
        public string backgroundorigin
        {
            set { this.___BackgroundOrigin = value; }
            get { return this.___BackgroundOrigin; }
        }
        internal string ___Clip = null;
        /// <summary>
        /// If Clip Value is specified or not.
        /// </summary>
        internal bool ___IsClipSpedified = false;
        internal System.Drawing.Rectangle ___ClipComputedValue = System.Drawing.Rectangle.Empty;
        public string Clip
        {
            set { this.___Clip = value; }
            get { return this.___Clip; }
        }
        public string clip
        {
            set { this.___Clip = value; }
            get { return this.___Clip; }
        }
        internal string ___PointerEvents = null;
        public string PointerEvents
        {
            set { this.___PointerEvents = value; }
            get { return this.___PointerEvents; }
        }
        public string pointerEvents
        {
            set { this.___PointerEvents = value; }
            get { return this.___PointerEvents; }
        }
        public string pointerevents
        {
            set { this.___PointerEvents = value; }
            get { return this.___PointerEvents; }
        }
        internal string ___MarkerOffset = null;
        public string MarkerOffset
        {
            set { this.___MarkerOffset = value; }
            get { return this.___MarkerOffset; }
        }
        public string markerOffset
        {
            set { this.___MarkerOffset = value; }
            get { return this.___MarkerOffset; }
        }
        public string markeroffset
        {
            set { this.___MarkerOffset = value; }
            get { return this.___MarkerOffset; }
        }

        internal string ___BackgroundImage = null;

        public string BackgroundImage
        {
            set
            {
                this.___BackgroundImage = value;
                if (this.___StyleType == CHtmlElementStyleType.Element)
                {
                    ___checkBackgroundImageStringForElement();
                }
            }
            get { return this.___BackgroundImage; }
        }
        public string backgroundImage
        {
            set
            {
                this.___BackgroundImage = value;
                if (this.___StyleType == CHtmlElementStyleType.Element)
                {
                    ___checkBackgroundImageStringForElement();
                }
            }
            get { return ___convertNullToEmpty(this.___BackgroundImage); }
        }
        public string backgroundimage
        {
            set
            {
                this.___BackgroundImage = value;
                if (this.___StyleType == CHtmlElementStyleType.Element)
                {
                    ___checkBackgroundImageStringForElement();
                }
            }
            get { return ___convertNullToEmpty(this.___BackgroundImage); }
        }
        /*
		internal string ___BackgroundGradation = null;
        public string x_BackgroundGradation
		{
			get{return this.___BackgroundGradation;}
			set
			{
				this.___BackgroundGradation = value;
				if(string.IsNullOrEmpty(this.___BackgroundGradation) == false)
				{
					this.___WebGradation = commonCreateGradationData(this.___BackgroundGradation, this.___HTMLTagRemUnitSize);
				}
				else
				{
					this.___WebGradation = null;
				}
			}
		}
         */
        /// <summary>
        /// StyleElement.nodeType is undefined, but some script searches this object.
        /// </summary>
        internal object ___nodeTypeDummy
        {
            get { return null; }
        }

        internal string ___BackfaceVisibility = null;
        public string BackfaceVisibility
        {
            get { return this.___BackfaceVisibility; }
            set { this.___BackfaceVisibility = value; }
        }
        public string backfaceVisibility
        {
            get { return this.___BackfaceVisibility; }
            set { this.___BackfaceVisibility = value; }
        }
        public string backfacevisibility
        {
            get { return this.___BackfaceVisibility; }
            set { this.___BackfaceVisibility = value; }
        }

        internal string ___Background = null;

        public string Background
        {
            set
            {
                this.___Background = value;
                if (this.___StyleType == CHtmlElementStyleType.Element)
                {
                    ___checkBackgroundStringForElement();
                }
            }
            get { return ___convertNullToEmpty(this.___Background); }
        }
        public string background
        {
            set
            {
                this.___Background = value;
                if (this.___StyleType == CHtmlElementStyleType.Element)
                {
                    ___checkBackgroundStringForElement();
                }
            }
            get { return ___convertNullToEmpty(this.___Background); }
        }
        internal void ___checkBackgroundStringForElement()
        {
            if (string.IsNullOrEmpty(this.___Background) == false)
            {
                if (this.___StyleType == CHtmlElementStyleType.Element)
                {
                    commonHTML.parseCSSBackgroundString(this.___Background, this);
                    if (this.___isApplyElemenetStyleSheetsForElementDone == true)
                    {
                      
                        if (this.___multipleBackgroundImageDataSet != null && this.___multipleBackgroundImageDataSet.Count > 0)
                        {
                            ___confirmMultipleBackgrondImagesHasBeenCachedIntoDocument();
                        }
                    }
                }
            }
        }
        internal void ___checkBackgroundImageStringForElement()
        {
            if (string.IsNullOrEmpty(this.___BackgroundImage) == false)
            {
                if (this.___StyleType == CHtmlElementStyleType.Element)
                {
                    if (this.___isApplyElemenetStyleSheetsForElementDone == true)
                    {
                        commonHTML.parseCSSBackgroundImageIntoMultipleImageData(this, 0);
                        if (this.___multipleBackgroundImageDataSet != null && this.___multipleBackgroundImageDataSet.Count > 0)
                        {
                            ___confirmMultipleBackgrondImagesHasBeenCachedIntoDocument();
                        }
                    }
                }
            }
        }
        internal void ___confirmMultipleBackgrondImagesHasBeenCachedIntoDocument()
        {
            CHtmlDocument ___currentDocument = null;
            if (this.___ownerElementWeakReference != null)
            {
                CHtmlElement __elem = this.___ownerElementWeakReference.Target as CHtmlElement;
                if (__elem.___documentWeakRef != null)
                {
                    ___currentDocument = __elem.___getDocument();
                }
            }
            if (___currentDocument == null)
            {
                return;
            }
            try
            {
                int __iCount = this.___multipleBackgroundImageDataSet.Count;
                for (int i = 0; i < __iCount; i++)
                {
                    CHtmlStyleElementMultpleImageData multiData = this.___multipleBackgroundImageDataSet[i];
                    if (multiData != null && multiData.ImageType == CSSMultipleImageDataType.Image)
                    {
                        if (string.IsNullOrEmpty(multiData.background_image_origin) == false)
                        {
                            if (string.IsNullOrEmpty(multiData.background_image_fullUrl) == false)
                            {
                                if (___currentDocument.___images.ContainsKey(multiData.background_image_fullUrl) == false)
                                {
                                    if (___currentDocument.___PageRequestedUrlList.ContainsKey(multiData.background_image_fullUrl) == false)
                                    {
                                        if (commonLog.LoggingEnabled &&commonLog.CommonLogLevel >= 5)
                                        {
                                           commonLog.LogEntry("___confirmMultipleBackgrondImagesHasBeenCachedIntoDocument() detected url needs to be requeststed {0}. pool it now..." + multiData.background_image_fullUrl);
                                        }
                                        /*
                                        ___currentDocument.___downloadviaQueue(multiData.background_image_fullUrl, "Image", null, null, ___currentDocument.___URL, null,CHtmlThreadPoolQueueObjectType.UrlImage, null, null, 0, CHtmlUrlSourceType.BackgroundImage_of_DefaultStyle, true);
                                        */

                                    }
                                }
                            }
                            else
                            {
                                if (commonLog.LoggingEnabled &&commonLog.CommonLogLevel >= 5)
                                {
                                   commonLog.LogEntry("TODO: ___confirmMultipleBackgrondImagesHasBeenCachedIntoDocument() detected partical url needs to be requeststed." + multiData.background_image_origin);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                if (commonLog.LoggingEnabled &&commonLog.CommonLogLevel >= 5)
                {
                   commonLog.LogEntry("___confirmMultipleBackgrondImagesHasBeenCachedIntoDocument() has exception. ", ex);
                }
            }
        }


        internal string ___BackgroundRepeat = null;

        public string BackgroundRepeat
        {
            set { this.___BackgroundRepeat = value; }
            get { return ___convertNullToEmpty(this.___BackgroundRepeat); }
        }
        public string backgroundRepeat
        {
            set { this.___BackgroundRepeat = value; }
            get { return ___convertNullToEmpty(this.___BackgroundRepeat); }
        }
        public string backgroundrepeat
        {
            set { this.___BackgroundRepeat = value; }
            get { return ___convertNullToEmpty(this.___BackgroundRepeat); }
        }

        internal string ___BackgroundOpacity = null;
        public string BackgroundOpacity
        {
            set { this.___BackgroundOpacity = value; }
            get { return ___convertNullToEmpty(this.___BackgroundOpacity); }
        }
        public string backgroundOpacity
        {
            set { this.___BackgroundOpacity = value; }
            get { return ___convertNullToEmpty(this.___BackgroundOpacity); }
        }
        public string backgroundopacity
        {
            set { this.___BackgroundOpacity = value; }
            get { return this.___BackgroundOpacity; }
        }


        internal string ___BackgroundPosition = null;
        public string BackgroundPosition
        {
            set { this.___BackgroundPosition = value; }
            get { return this.___BackgroundPosition; }
        }
        public string backgroundposition
        {
            set { this.___BackgroundPosition = value; }
            get { return ___convertNullToEmpty(this.___BackgroundPosition); }
        }
        public string backgroundPosition
        {
            set { this.___BackgroundPosition = value; }
            get { return ___convertNullToEmpty(this.___BackgroundPosition); }
        }
        internal string ___BackgroundPositionX = null;
        public string backgroundpositionx
        {
            set { this.___BackgroundPositionX = value; }
            get { return ___convertNullToEmpty(this.___BackgroundPositionX); }
        }
        public string BackgroundPositionX
        {
            set { this.___BackgroundPositionX = value; }
            get { return ___convertNullToEmpty(this.___BackgroundPositionX); }
        }
        public string backgroundPositionX
        {
            set { this.___BackgroundPositionX = value; }
            get { return ___convertNullToEmpty(this.___BackgroundPositionX); }
        }
        internal string ___BackgroundPositionY = null;
        public string backgroundpositiony
        {
            set { this.___BackgroundPositionY = value; }
            get { return this.___BackgroundPositionY; }
        }
        public string BackgroundPositionY
        {
            set { this.___BackgroundPositionY = value; }
            get { return this.___BackgroundPositionY; }
        }
        public string backgroundPositionY
        {
            set { this.___BackgroundPositionY = value; }
            get { return ___convertNullToEmpty(this.___BackgroundPositionY); }
        }
        internal string ___BackgroundAttachment = null;
        public string BackgroundAttachment
        {
            set { this.___BackgroundAttachment = value; }
            get { return this.___BackgroundAttachment; }
        }
        public string backgroundattachment
        {
            set { this.___BackgroundAttachment = value; }
            get { return this.___BackgroundAttachment; }
        }
        public string backgroundAttachment
        {
            set { this.___BackgroundAttachment = value; }
            get { return this.___BackgroundAttachment; }
        }

        private string ___Color = null;
        public string color
        {
            set
            {
                this.___Color = value;
                ___ParseColorValue();
                this.___FontRelatedCount++;
            }
            get { return ___convertNullToEmpty(this.___Color); }
        }
        public string Color
        {
            set
            {
                this.___Color = value; ___ParseColorValue();
                this.___FontRelatedCount++;
            }
            get { return ___convertNullToEmpty(this.___Color); }
        }
        private void ___ParseColorValue()
        {
            if (string.IsNullOrEmpty(this.___Color) == false)
            {
                try
                {
                    this.___IsForegroundSysColorSpecified = true;
                    this.___ForegroundSysColor = commonHTML.GetColorFromHTMLColorExtend(this.___Color);
                }
                catch (Exception ex)
                {
                    if (commonLog.LoggingEnabled &&commonLog.CommonLogLevel >= 10)
                    {
                       commonLog.LogEntry("___ParseColorValue()", ex);
                    }
                }

            }
            else
            {
                this.___IsForegroundSysColorSpecified = false;
                this.___ForegroundSysColor = System.Drawing.Color.Black;
            }
        }
        internal string ___TextStroke = null;
        public string TextStroke
        {
            set { this.___TextStroke = value; }
            get { return this.___TextStroke; }
        }
        public string textstroke
        {
            set { this.___TextStroke = value; }
            get { return this.___TextStroke; }
        }
        internal string ___MaskImage = null;
        public string maskImage
        {
            set { this.___MaskImage = value; }
            get { return this.___MaskImage; }
        }
        public string MaskBoxImage
        {
            set { this.___MaskBoxImage = value; }
            get { return this.___MaskBoxImage; }
        }
        internal string ___MaskBoxImage = null;
        public string maskBoxImage
        {
            set { this.___MaskBoxImage = value; }
            get { return this.___MaskBoxImage; }
        }
        public string maskboxImage
        {
            set { this.___MaskBoxImage = value; }
            get { return this.___MaskBoxImage; }
        }


        internal string ___TableLayout = null;
        public string TableLayout
        {
            set { this.___TableLayout = value; }
            get { return this.___TableLayout; }
        }
        public string tablelayout
        {
            set { this.___TableLayout = value; }
            get { return this.___TableLayout; }
        }
        public string tableLayout
        {
            set { this.___TableLayout = value; }
            get { return ___convertNullToEmpty(this.___TableLayout); }
        }
        internal string ___WordBreak = null;
        public string WordBreak
        {
            set { this.___WordBreak = value; }
            get { return ___convertNullToEmpty(this.___WordBreak); }
        }
        public string wordBreak
        {
            set { this.___WordBreak = value; }
            get { return ___convertNullToEmpty(this.___WordBreak); }
        }
        public string wordbreak
        {
            set { this.___WordBreak = value; }
            get { return ___convertNullToEmpty(this.___WordBreak); }
        }
        /// <summary>
        /// [normal] Default. Content exceeds the boundaries of its container. 
        /// [break-word] Content wraps to next line, and a word-break occurs when necessary. 
        /// Refer To WhiteSpace for line-breaking
        /// </summary>
        internal string ___WordWrap = null;
        public string WordWrap
        {
            get { return ___convertNullToEmpty(this.___WordWrap); }
            set { this.___WordWrap = value; }
        }
        public string wordWrap
        {
            get { return ___convertNullToEmpty(this.___WordWrap); }
            set { this.___WordWrap = value; }
        }
        public string wordwrap
        {
            get { return ___convertNullToEmpty(this.___WordWrap); }
            set { this.___WordWrap = value; }
        }

        internal string ___ListStyleType = null;
        public string ListStyleType
        {
            get { return ___convertNullToEmpty(this.___ListStyleType); }
            set { this.___ListStyleType = value; }
        }

        internal string ___cssFloat = null;
        internal CSSFloatType ___cssFloatType = CSSFloatType.NotSet;
        public string styleFloat
        {
            get { return this.___cssFloat; }
            set
            {
                this.___cssFloat = value;
                ___CheckCSSFloatType();
            }
        }
        public string stylefloat
        {
            get { return this.___cssFloat; }
            set
            {
                this.___cssFloat = value;
                ___CheckCSSFloatType();
            }
        }
        public string cssFloat
        {
            get { return this.___cssFloat; }
            set
            {
                this.___cssFloat = value;
                ___CheckCSSFloatType();
            }
        }
        public string Float
        {
            get { return this.___cssFloat; }
            set
            {
                this.___cssFloat = value;
                ___CheckCSSFloatType();
            }
        }
        public string @float
        {
            get
            {
                return this.___cssFloat;
            }
            set
            {
                this.___cssFloat = value;
                ___CheckCSSFloatType();
            }
        }
        private void ___CheckCSSFloatType()
        {
            switch (___cssFloat)
            {
                case "left":
                case "Left":
                case "LEFT":
                    this.___cssFloatType = CSSFloatType.Left;
                    break;
                case "right":
                case "Right":
                case "RIGHT":
                    this.___cssFloatType = CSSFloatType.Right;
                    break;
                case "both":
                case "Both":
                case "BOTH":
                    this.___cssFloatType = CSSFloatType.Both;
                    break;
                default:

                    this.___cssFloatType = CSSFloatType.NotSet;
                    break;
            }
        }

        internal string ___VerticalAlign = null;
        public string verticalalign
        {
            set { this.___VerticalAlign = value; }
            get { return ___convertNullToEmpty(this.___VerticalAlign); }
        }
        public string verticalAlign
        {
            set { this.___VerticalAlign = value; }
            get { return ___convertNullToEmpty(this.___VerticalAlign); }
        }
        public string VerticalAlign
        {
            set { this.___VerticalAlign = value; }
            get { return ___convertNullToEmpty(this.___VerticalAlign); }
        }
        internal string ___TextJustification = null;
        public string TextJustification
        {
            get
            {
                return ___convertNullToEmpty(this.___TextJustification);
            }
            set { this.___TextJustification = value; }
        }
        public string textJustification
        {
            get
            {
                return ___convertNullToEmpty(this.___TextJustification);
            }
            set { this.___TextJustification = value; }
        }
        internal string ___TextAlign = null;
        public string TextAlign
        {
            set { this.___TextAlign = value; }
            get { return ___convertNullToEmpty(this.___TextAlign); }
        }
        public string textalign
        {
            set { this.___TextAlign = value; }
            get { return ___convertNullToEmpty(this.___TextAlign); }
        }
        public string textAlign
        {
            set { this.___TextAlign = value; }
            get { return ___convertNullToEmpty(this.___TextAlign); }
        }
        internal string ___TouchAction = null;
        public string TouchAction
        {
            get { return ___convertNullToEmpty(this.___TouchAction); }
            set { this.___TouchAction = value; }
        }
        public string touchAction
        {
            get { return ___convertNullToEmpty(this.___TouchAction); }
            set { this.___TouchAction = value; }
        }
        public string touchaction
        {
            get { return ___convertNullToEmpty(this.___TouchAction); }
            set { this.___TouchAction = value; }
        }
        public string msTouchAction
        {
            get { return ___convertNullToEmpty(this.___TouchAction); }
            set { this.___TouchAction = value; }
        }
        public string mozTouchAction
        {
            get { return ___convertNullToEmpty(this.___TouchAction); }
            set { this.___TouchAction = value; }
        }
        public string webkitTouchAction
        {
            get { return ___convertNullToEmpty(this.___TouchAction); }
            set { this.___TouchAction = value; }
        }
        public string mstouchaction
        {
            get { return ___convertNullToEmpty(this.___TouchAction); }
            set { this.___TouchAction = value; }
        }
        public string moztouchaction
        {
            get { return ___convertNullToEmpty(this.___TouchAction); }
            set { this.___TouchAction = value; }
        }
        public string webkittouchaction
        {
            get { return ___convertNullToEmpty(this.___TouchAction); }
            set { this.___TouchAction = value; }
        }
        internal string ___TextLineThrough = null;
        public string TextLineThrough
        {
            set { this.___TextLineThrough = value; }
            get { return ___convertNullToEmpty(this.___TextLineThrough); }
        }
        public string textLineThrough
        {
            set { this.___TextLineThrough = value; }
            get { return ___convertNullToEmpty(this.___TextLineThrough); }
        }
        public string textDecorationLineThrough
        {
            set { this.___TextLineThrough = value; }
            get { return ___convertNullToEmpty(this.___TextLineThrough); }

        }
        public string textlinethrough
        {
            set { this.___TextLineThrough = value; }
            get { return ___convertNullToEmpty(this.___TextLineThrough); }
        }
        internal string ___TextOverFlow = null;
        public string TextOverFlow
        {
            set { this.___TextOverFlow = value; }
            get { return ___convertNullToEmpty(this.___TextOverFlow); }
        }
        public string textOverFlow
        {
            set { this.___TextOverFlow = value; }
            get { return ___convertNullToEmpty(this.___TextOverFlow); }
        }
        public string textoverflow
        {
            set { this.___TextOverFlow = value; }
            get { return ___convertNullToEmpty(this.___TextOverFlow); }
        }
        internal string ___TextTransform = null;
        public string TextTransform
        {
            set { this.___TextTransform = value; }
            get { return ___convertNullToEmpty(this.___TextTransform); }
        }
        private string ___TextDecoration = null;
        internal CSSTextDecorationType ___TextDecorationComputedValueType = CSSTextDecorationType.none;
        /// <summary>
        /// Parse TextDecoration Type.
        /// </summary>
        private void ___GetTextDecorationType()
        {
            if (string.IsNullOrEmpty(this.___TextDecorationNone) == false && string.Equals(this.___TextDecorationNone, "true", StringComparison.OrdinalIgnoreCase) == true)
            {
                this.___TextDecoration = "none";
            }
            if (string.IsNullOrEmpty(this.___TextDecorationUnderline) == false && string.Equals(this.___TextDecorationUnderline, "true", StringComparison.OrdinalIgnoreCase) == true)
            {
                this.___TextDecoration = "underline";
            }
            if (string.IsNullOrEmpty(this.___TextDecorationOverline) == false && string.Equals(this.___TextDecorationOverline, "true", StringComparison.OrdinalIgnoreCase) == true)
            {
                this.___TextDecoration = "overline";
            }
            if (string.IsNullOrEmpty(this.___TextDecorationBlink) == false && string.Equals(this.___TextDecorationBlink, "true", StringComparison.OrdinalIgnoreCase) == true)
            {
                this.___TextDecoration = "blink";
            }
            switch (this.___TextDecoration)
            {
                case null:
                case "":
                case "none":
                case "None":
                case "NONE":
                    this.___TextDecorationComputedValueType = CSSTextDecorationType.none;
                    break;
                case "Underline":
                case "underline":
                    this.___TextDecorationComputedValueType = CSSTextDecorationType.underline;
                    break;
                case "line-through":
                case "linethrough":
                    this.___TextDecorationComputedValueType = CSSTextDecorationType.linethrough;
                    break;
                case "Overline":
                case "overline":
                    this.___TextDecorationComputedValueType = CSSTextDecorationType.overline;
                    break;
                case "Blink":
                case "blink":
                    this.___TextDecorationComputedValueType = CSSTextDecorationType.blink;
                    break;
            }
        }
        internal string ___TextDecorationNone = null;
        internal string ___TextDecorationOverline = null;
        internal string ___TextDecorationUnderline = null;

        public string TextDecorationNone
        {
            set
            {
                this.___TextDecorationNone = value;
                this.___GetTextDecorationType();
                this.___FontRelatedCount++;
            }
            get { return this.___TextDecorationNone; }
        }
        public string textDecorationNone
        {
            set
            {
                this.___TextDecorationNone = value;
                this.___GetTextDecorationType();
                this.___FontRelatedCount++;
            }
            get { return this.___TextDecorationNone; }
        }
        public string TextDecorationOverline
        {
            set
            {
                this.___TextDecorationOverline = value;
                this.___GetTextDecorationType();
                this.___FontRelatedCount++;
            }
            get { return this.___TextDecorationOverline; }
        }
        public string textDecorationOverline
        {
            set
            {
                this.___TextDecorationOverline = value;
                this.___GetTextDecorationType();
                this.___FontRelatedCount++;
            }
            get { return this.___TextDecorationOverline; }
        }
        public string textDecorationUnderline
        {
            set
            {
                this.___TextDecorationUnderline = value;
                this.___GetTextDecorationType();
                this.___FontRelatedCount++;
            }
            get { return this.___TextDecorationUnderline; }
        }
        public string textdecorationunderline
        {
            set
            {
                this.___TextDecorationUnderline = value;
                this.___GetTextDecorationType();
                this.___FontRelatedCount++;
            }
            get { return this.___TextDecorationUnderline; }
        }
        public string TextDecoration
        {
            set
            {
                this.___TextDecoration = value;
                this.___GetTextDecorationType();
                this.___FontRelatedCount++;
            }
            get { return this.___TextDecoration; }
        }
        public string textDecoration
        {
            set
            {
                this.___TextDecoration = value;
                this.___GetTextDecorationType();
                this.___FontRelatedCount++;
            }
            get { return this.___TextDecoration; }
        }
        public string textdecoration
        {
            set
            {
                this.___TextDecoration = value;
                this.___GetTextDecorationType();
                this.___FontRelatedCount++;
            }
            get { return this.___TextDecoration; }
        }

        internal string ___TextDecorationBlink = null;
        public string TextDecorationBlink
        {
            set
            {
                this.___TextDecorationBlink = value;
                this.___GetTextDecorationType();
                this.___FontRelatedCount++;
            }
            get { return this.___TextDecorationBlink; }
        }
        public string textDecorationBlink
        {
            set
            {
                this.___TextDecorationBlink = value;
                this.___GetTextDecorationType();
                this.___FontRelatedCount++;
            }
            get { return this.___TextDecorationBlink; }
        }
        public string textdecorationblink
        {
            set
            {
                this.___TextDecorationBlink = value;
                this.___GetTextDecorationType();
                this.___FontRelatedCount++;
            }
            get { return this.___TextDecorationBlink; }
        }
        internal double ___TextIndentComputedValue = 0;
        private string ___TextIndent = null;
        public string TextIndent
        {
            set
            {
                this.___TextIndent = value;
                ___GetTextIndentComputedValue();
            }
            get { return this.___TextIndent; }
        }
        private void ___GetTextIndentComputedValue()
        {
            try
            {
                this.___TextIndentComputedValue = commonHTML.GetDoubleValueFromString(this.___TextIndent, 0, this.___HTMLTagRemUnitSize);
                if (this.___StyleType == CHtmlElementStyleType.Element)
                {

                    this.ownerElement.___TextIndentStyleParsed = this.___TextIndentComputedValue;
                    if (this.___TextIndentComputedValue < commonHTML.Text_Indent_Lowest_Value_Limit)
                    {
                        this.ownerElement.___IsTextRenderSkip = true;
                    }
                    else
                    {
                        if (ownerElement.___IsTextRenderSkip == true)
                        {
                            ownerElement.___IsTextRenderSkip = false;
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                if (commonLog.LoggingEnabled &&commonLog.CommonLogLevel >= 10)
                {
                   commonLog.LogEntry(" ___GetTextIndentComputedValue()", ex);
                }
            }
        }
        public string textindent
        {
            set
            {
                this.___TextIndent = value;
                ___GetTextIndentComputedValue();
            }
            get
            {
                return this.___TextIndent;
            }
        }
        public string textIndent
        {
            set
            {
                this.___TextIndent = value;
                ___GetTextIndentComputedValue();
            }
            get { return this.___TextIndent; }
        }
        internal string ___TextIndex = null;
        public string TextIndex
        {
            set { this.___TextIndex = value; }
            get { return this.___TextIndex; }
        }
        public string textindex
        {
            set { this.___TextIndex = value; }
            get { return this.___TextIndex; }
        }
        public string textIndex
        {
            set { this.___TextIndex = value; }
            get { return this.___TextIndex; }
        }


        internal string ___Transform = null;
        public string oTransform
        {
            set { this.___Transform = value; }
            get { return this.___Transform; }
        }
        public string Transform
        {
            set { this.___Transform = value; }
            get { return this.___Transform; }
        }
        public string transform
        {
            set { this.___Transform = value; }
            get { return this.___Transform; }
        }
        public string webkitTransform
        {
            set { this.___Transform = value; }
            get { return this.___Transform; }
        }
        public string mozTransform
        {
            set { this.___Transform = value; }
            get { return this.___Transform; }
        }
        public string msTransform
        {
            set { this.___Transform = value; }
            get { return this.___Transform; }
        }
        public string WebkitTransform
        {
            set { this.___Transform = value; }
            get { return this.___Transform; }
        }
        public string MozTransform
        {
            set { this.___Transform = value; }
            get { return this.___Transform; }
        }
        public string MsTransform
        {
            set { this.___Transform = value; }
            get { return this.___Transform; }
        }
        public string OTransform
        {
            set { this.___Transform = value; }
            get { return this.___Transform; }
        }
        internal string ___TransformOrigin = null;
        public string TransformOrigin
        {
            set { this.___TransformOrigin = value; }
            get { return this.___TransformOrigin; }
        }
        public string transformOrigin
        {
            set { this.___TransformOrigin = value; }
            get { return this.___TransformOrigin; }
        }
        public string transformorigin
        {
            set { this.___TransformOrigin = value; }
            get { return this.___TransformOrigin; }
        }


        internal string ___TransformDuration = null;
        public string TransformDuration
        {
            set { this.___TransformDuration = value; }
            get { return this.___TransformDuration; }
        }
        public string transformDuration
        {
            set { this.___TransformDuration = value; }
            get { return this.___TransformDuration; }
        }
        public string transformduration
        {
            set { this.___TransformDuration = value; }
            get { return this.___TransformDuration; }
        }
        internal string ___TransitionDuration = null;
        public string TransitionDuration
        {
            set { this.___TransitionDuration = value; }
            get { return this.___TransitionDuration; }
        }
        public string transitionDuration
        {
            set { this.___TransitionDuration = value; }
            get { return this.___TransitionDuration; }
        }
        public string transitionduration
        {
            set { this.___TransitionDuration = value; }
            get { return this.___TransitionDuration; }
        }

        internal string ___TransitionProperty = null;
        public string TransitionProperty
        {
            set { this.___TransitionProperty = value; }
            get { return ___convertNullToEmpty(this.___TransitionProperty); }
        }
        public string webkitTransitionProperty
        {
            set { this.___TransitionProperty = value; }
            get { return ___convertNullToEmpty(this.___TransitionProperty); }
        }

        public string WebkitTransitionProperty
        {
            set { this.___TransitionProperty = value; }
            get { return ___convertNullToEmpty(this.___TransitionProperty); }
        }
        public string mozTransitionProperty
        {
            set { this.___TransitionProperty = value; }
            get { return ___convertNullToEmpty(this.___TransitionProperty); }
        }
        public string transitionProperty
        {
            set { this.___TransitionProperty = value; }
            get { return ___convertNullToEmpty(this.___TransitionProperty); }
        }
        public string transitionproperty
        {
            set { this.___TransitionProperty = value; }
            get { return ___convertNullToEmpty(this.___TransitionProperty); }
        }

        internal string ___TransitionTimingFunction = null;
        public string TransitionTimingFunction
        {
            set { this.___TransitionTimingFunction = value; }
            get { return this.___TransitionTimingFunction; }
        }
        public string transitionTimingFunction
        {
            set { this.___TransitionTimingFunction = value; }
            get { return this.___TransitionTimingFunction; }
        }
        public string transitiontimingfunction
        {
            set { this.___TransitionTimingFunction = value; }
            get { return this.___TransitionTimingFunction; }
        }

        internal string ___TransitionDelay = null;
        public string TransitionDelay
        {
            set { this.___TransitionDelay = value; }
            get { return this.___TransitionDelay; }
        }
        public string transitionDelay
        {
            set { this.___TransitionDelay = value; }
            get { return this.___TransitionDelay; }
        }
        public string transitiondelay
        {
            set { this.___TransitionDelay = value; }
            get { return this.___TransitionDelay; }
        }
        internal string ___TouchCallout = null;
        public string TouchCallout
        {
            set { this.___TouchCallout = value; }
            get { return this.___TouchCallout; }
        }
        public string touchcallout
        {
            set { this.___TouchCallout = value; }
            get { return this.___TouchCallout; }
        }
        internal string ___Speak = null;
        public string Speak
        {
            get { return this.___Speak; }
            set { this.___Speak = value; }
        }
        public string speak
        {
            get { return this.___Speak; }
            set { this.___Speak = value; }
        }
        internal string ___StopColor = null;
        public string StopColor
        {
            get { return this.___StopColor; }
            set { this.___StopColor = value; }
        }
        internal string ___StopOpacity;
        public string stopOpacity
        {
            get { return this.___StopOpacity; }
            set { this.___StopOpacity = value; }
        }
        public string StopOpacity
        {
            get { return this.___StopOpacity; }
            set { this.___StopOpacity = value; }
        }
        public string stopColor
        {
            get { return this.___StopColor; }
            set { this.___StopColor = value; }
        }
        public string stopcolor
        {
            get { return this.___StopColor; }
            set { this.___StopColor = value; }
        }

        internal string ___Stroke = null;
        public string Stroke
        {
            get { return this.___Stroke; }
            set { this.___Stroke = value; }
        }
        public string stroke
        {
            get { return this.___Stroke; }
            set { this.___Stroke = value; }
        }

        internal string ___StrokeWidth = null;
        public string StrokeWidth
        {
            get { return this.___StrokeWidth; }
            set { this.___StrokeWidth = value; }
        }
        public string strokeWidth
        {
            get { return this.___StrokeWidth; }
            set { this.___StrokeWidth = value; }
        }
        public string strokewidth
        {
            get { return this.___StrokeWidth; }
            set { this.___StrokeWidth = value; }
        }

        internal string ___TextShadow = null;
        public string TextShadow
        {
            set { this.___TextShadow = value; }
            get { return this.___TextShadow; }

        }
        public string textShadow
        {
            set { this.___TextShadow = value; }
            get { return this.___TextShadow; }

        }
        public string ___rotate = null;
        public string rotate
        {
            get { return this.___rotate; }
            set { this.___rotate = value; }
        }
        public string webkitRotate
        {
            get { return this.___rotate; }
            set { this.___rotate = value; }
        }
        public string msRotate
        {
            get { return this.___rotate; }
            set { this.___rotate = value; }
        }
        public string mozRotate
        {
            get { return this.___rotate; }
            set { this.___rotate = value; }
        }
        private string ___animationPlayState = null;
        public string animationPlayState
        {
            get { return this.___animationPlayState; }
            set { this.___animationPlayState = value; }
        }
        public string msAnimationPlayState
        {
            get { return this.___animationPlayState; }
            set { this.___animationPlayState = value; }
        }
        public string mozAnimationPlayState
        {
            get { return this.___animationPlayState; }
            set { this.___animationPlayState = value; }
        }
        public string webkitAnimationPlayState
        {
            get { return this.___animationPlayState; }
            set { this.___animationPlayState = value; }
        }
        public string OAnimationPlayState
        {
            get { return this.___animationPlayState; }
            set { this.___animationPlayState = value; }
        }
        internal string ___Animation = null;

        public string animation
        {
            get { return this.___Animation; }
            set { this.___Animation = value; }
        }
        public string Animation
        {
            get { return this.___Animation; }
            set { this.___Animation = value; }
        }
        internal string ___animationduration = null;
        public string animationduration
        {
            get { return this.___animationduration; }
            set { this.___animationduration = value; }
        }
        public string AnimationDuration
        {
            get { return this.___animationduration; }
            set { this.___animationduration = value; }
        }
        public string animationDuration
        {
            get { return this.___animationduration; }
            set { this.___animationduration = value; }
        }

        internal string ___animationDelay = null;
        public string animationDelay
        {
            get { return this.___animationDelay; }
            set { this.___animationDelay = value; }
        }
        public string AnimationDelay
        {
            get { return this.___animationDelay; }
            set { this.___animationDelay = value; }
        }
        public string mozAnimationDelay
        {
            get { return this.___animationDelay; }
            set { this.___animationDelay = value; }
        }
        internal string ___animationName = null;
        public string animationName
        {
            get { return this.___animationName; }
            set { this.___animationName = value; }
        }
        public string animationname
        {
            get { return this.___animationName; }
            set { this.___animationName = value; }
        }
        private string ___Visibility = null;
        internal CSSVisibilityType ___cssVisibilityComputedValueType = CSSVisibilityType.visible;
        public string Visibility
        {
            set
            {
                this.___Visibility = value;
                ___getVisibilityTye();
            }
            get { return this.___Visibility; }
        }
        public string visibility
        {
            set
            {
                this.___Visibility = value;
                ___getVisibilityTye();
            }
            get { return this.___Visibility; }
        }
        /// <summary>
        /// viewbox field is svg related normally not used.
        /// </summary>
        internal string ___viewbox = null;
        public string viewbox
        {
            set { this.___viewbox = value; }
            get { return commonHTML.___convertNullToEmpty(this.___viewbox); }
        }
        
        public string viewBox
        {
            set { this.___viewbox = value; }
            get { return commonHTML.___convertNullToEmpty(this.___viewbox); }
        }
        private void ___getVisibilityTye()
        {
            switch (this.___Visibility)
            {
                case "hidden":
                case "Hidden":
                case "HIDDEN":
                case "none":
                case "None":
                case "NONE":
                    this.___cssVisibilityComputedValueType = CSSVisibilityType.hidden;
                    break;
                case "":
                case null:
                case "visible":
                case "Visible":
                case "VISIBLE":
                    this.___cssVisibilityComputedValueType = CSSVisibilityType.visible;
                    break;
                case "collapse":
                case "Collapse":
                case "COLLAPSE":
                    this.___cssVisibilityComputedValueType = CSSVisibilityType.collapse;
                    break;
                default:
                    this.___cssVisibilityComputedValueType = CSSVisibilityType.visible;
                    break;
            }
        }
        private string ___Position = null;
        public string Position
        {
            set
            {
                this.___Position = value;
                ___parsePositionValue();
            }
            get { return this.___Position; }
        }
        public string position
        {
            set
            {
                this.___Position = value;
                ___parsePositionValue();
            }
            get { return this.___Position; }
        }
        internal CSSPositionType ___cssPositionComputedValueType = CSSPositionType.relative;
        internal bool ___isPositionMustbeRelativeFix = false;
        private void ___parsePositionValue()
        {
            if (___isPositionMustbeRelativeFix == true)
            {
                this.___cssPositionComputedValueType = CSSPositionType.relative;
            }
            else
            {
                switch (this.___Position)
                {
                    case "absolute":
                    case "Absolute":
                    case "ABSOLUTE":
                        this.___cssPositionComputedValueType = CSSPositionType.absolute;
                        break;
                    case "static":
                    case "Static":
                    case "STATIC":
                        this.___cssPositionComputedValueType = CSSPositionType.@static;
                        break;
                    default:
                        this.___cssPositionComputedValueType = CSSPositionType.relative;
                        break;
                }
            }
        }

        internal string ___TextRendering = null;
        public string TextRendering
        {
            set { this.___TextRendering = value; }
            get { return this.___TextRendering; }
        }
        public string textRendering
        {
            set { this.___TextRendering = value; }
            get { return this.___TextRendering; }
        }
        public string textrendering
        {
            set { this.___TextRendering = value; }
            get { return this.___TextRendering; }
        }
        internal string ___FontStretch = null;
        public string FontStretch
        {
            set { this.___FontStretch = value; }
            get { return this.___FontStretch; }
        }
        internal string ___Transition = null;
        public string Transition
        {
            set { this.___Transition = value; }
            get { return this.___Transition; }

        }
        public string transition
        {
            set { this.___Transition = value; }
            get { return this.___Transition; }

        }
        public string WebkitTransition
        {
            set { this.___Transition = value; }
            get { return this.___Transition; }
        }
        internal string ___InterpolationMode = null;
        public string InterpolationMode
        {
            set { this.___InterpolationMode = value; }
            get { return this.___InterpolationMode; }
        }
        public string msInterpolationMode
        {
            set { this.___InterpolationMode = value; }
            get { return this.___InterpolationMode; }
        }
        public string mozInterpolationMode
        {
            set { this.___InterpolationMode = value; }
            get { return this.___InterpolationMode; }
        }
        public string webkitInterpolationMode
        {
            set { this.___InterpolationMode = value; }
            get { return this.___InterpolationMode; }
        }
        public string interpolationMode
        {
            set { this.___InterpolationMode = value; }
            get { return this.___InterpolationMode; }
        }
        public string interpolationmode
        {
            set { this.___InterpolationMode = value; }
            get { return this.___InterpolationMode; }
        }
        internal string ___CounterIncrement = null;
        public string CounterIncrement
        {
            get { return this.___CounterIncrement; }
            set { this.___CounterIncrement = value; }
        }
        public string counterIncrement
        {
            get { return this.___CounterIncrement; }
            set { this.___CounterIncrement = value; }
        }
        public string counterincrement
        {
            get { return this.___CounterIncrement; }
            set { this.___CounterIncrement = value; }
        }
        internal string ___CounterReset = null;
        public string CounterReset
        {
            get { return this.___CounterReset; }
            set { this.___CounterReset = value; }
        }
        public string counterReset
        {
            get { return this.___CounterReset; }
            set { this.___CounterReset = value; }
        }
        public string counterreset
        {
            get { return this.___CounterReset; }
            set { this.___CounterReset = value; }
        }



        internal string ___Content = null;
        public string Content
        {
            get { return ___convertNullToEmpty(this.___Content); }
            set { this.___Content = value; }
        }
        public string content
        {
            get { return ___convertNullToEmpty(this.___Content); }
            set { this.___Content = value; }
        }
        internal string ___WhiteSpace = null;
        internal CSSWhiteSpaceType ___whiteSpaceComputedValue = CSSWhiteSpaceType.Normal;
        public string WhiteSpace
        {
            get { return ___convertNullToEmpty(this.___WhiteSpace); }
            set
            {
                this.___WhiteSpace = value;
                ___parseWhiteSpaceType();
            }
        }
        public string whitespace
        {
            get { return ___convertNullToEmpty(this.___WhiteSpace); }
            set
            {
                this.___WhiteSpace = value;
                ___parseWhiteSpaceType();
            }
        }
        public string whiteSpace
        {
            get { return this.___WhiteSpace; }
            set
            {
                this.___WhiteSpace = value;
                ___parseWhiteSpaceType();
            }
        }
        private void ___parseWhiteSpaceType()
        {
            switch (this.___WhiteSpace)
            {
                case "":
                case "normal":
                    this.___whiteSpaceComputedValue = CSSWhiteSpaceType.Normal;
                    return;
                case "nowrap":
                case "noWrap":
                case "NoWrap":
                    this.___whiteSpaceComputedValue = CSSWhiteSpaceType.NoWrap;
                    return;
                case "pre":
                    this.___whiteSpaceComputedValue = CSSWhiteSpaceType.Pre;
                    return;
                case "pre-line":
                case "preline":
                    this.___whiteSpaceComputedValue = CSSWhiteSpaceType.PreLine;
                    return;
                case "pre-wrap":
                case "prewrap":
                    this.___whiteSpaceComputedValue = CSSWhiteSpaceType.PreWrap;
                    return;
                case "inherit":
                    this.___whiteSpaceComputedValue = CSSWhiteSpaceType.Inherit;
                    return;
                case "inital":
                    this.___whiteSpaceComputedValue = CSSWhiteSpaceType.Inital;
                    return;
            }
        }
        internal string ___LayoutGridLine = null;
        public string LayoutGridLine
        {
            get { return this.___LayoutGridLine; }
            set { this.___LayoutGridLine = value; }
        }
        public string layoutgridline
        {
            get { return this.___LayoutGridLine; }
            set { this.___LayoutGridLine = value; }
        }
        public string layoutGridLine
        {
            get { return this.___LayoutGridLine; }
            set { this.___LayoutGridLine = value; }
        }
        internal string ___Left = null;
        public double posLeft
        {
            set
            {
                this.___Left = value.ToString();
            }
            get
            {
                return commonHTML.GetDoubleValueFromString(this.___Left, 0, this.___HTMLTagRemUnitSize);
            }
        }
        public double posleft
        {
            set { this.posLeft = value; }
            get { return this.posLeft; }
        }
        public double pixelLeft
        {
            set { this.posLeft = value; }
            get { return this.posLeft; }
        }
        public string Left
        {
            get { return ___convertNullToEmpty(this.___Left); }
            set { this.___Left = value; }
        }
        public string left
        {
            get { return ___convertNullToEmpty(this.___Left); }
            set { this.___Left = value; }
        }
        internal string ___Top = null;
        public double posTop
        {
            set
            {
                this.___Top = value.ToString();
            }
            get
            {
                return commonHTML.GetDoubleValueFromString(this.___Top, 0, this.___HTMLTagRemUnitSize);
            }
        }
        public double postop
        {
            set { this.posTop = value; }
            get { return this.posTop; }
        }
        public double pixelTop
        {
            set { this.posTop = value; }
            get { return this.posTop; }
        }
        public string top
        {
            set { this.___Top = value; }
            get { return ___convertNullToEmpty(this.___Top); }
        }
        public string Top
        {
            set { this.___Top = value; }
            get { return ___convertNullToEmpty(this.___Top); }
        }
        internal string ___Bottom = null;
        public double posBottom
        {
            set
            {
                this.___Bottom = value.ToString();
            }
            get
            {
                return commonHTML.GetDoubleValueFromString(this.___Bottom, 0, this.___HTMLTagRemUnitSize);
            }
        }
        public double pixelBottom
        {
            set { this.posBottom = value; }
            get { return this.posBottom; }
        }
        public string bottom
        {
            set { this.___Bottom = value; }
            get { return ___convertNullToEmpty(this.___Bottom); }
        }
        public string Bottom
        {
            set { this.___Bottom = value; }
            get { return ___convertNullToEmpty(this.___Bottom); }
        }
        internal string ___Right = null;
        public double posRight
        {
            set
            {
                this.___Right = value.ToString();
            }
            get
            {
                return commonHTML.GetDoubleValueFromString(this.___Right, 0, this.___HTMLTagRemUnitSize);
            }
        }
        public double pixelRight
        {
            set { this.posRight = value; }
            get { return this.posRight; }
        }
        public string right
        {
            set { this.___Right = value; }
            get { return ___convertNullToEmpty(this.___Right); }
        }
        public string Right
        {
            set { this.___Right = value; }
            get { return ___convertNullToEmpty(this.___Right); }
        }
        internal string ___MinHeight = null;

        internal double ___MinHeightComputedValue = 0;
        internal bool ___isMinHeightValueSet = false;
        internal bool ___isMinHeightValuePercent = false;

        public string MinHeight
        {
            get { return this.___MinHeight; }
            set
            {
                this.___MinHeight = value;
                ___checkStringValue(this.___MinHeight, ref this.___MinHeightComputedValue, ref  this.___isMinHeightValueSet, ref this.___isMinHeightValuePercent, true, false);
            }
        }
        public string minHeight
        {
            get { return ___convertNullToEmpty(this.___MinHeight); }
            set
            {
                this.___MinHeight = value;
                ___checkStringValue(this.___MinHeight, ref this.___MinHeightComputedValue, ref  this.___isMinHeightValueSet, ref this.___isMinHeightValuePercent, true, false);
            }
        }
        public string minheight
        {
            get { return ___convertNullToEmpty(this.___MinHeight); }
            set
            {
                this.___MinHeight = value;
                ___checkStringValue(this.___MinHeight, ref this.___MinHeightComputedValue, ref  this.___isMinHeightValueSet, ref this.___isMinHeightValuePercent, true, false);
            }
        }

        internal string ___MinWidth = null;
        internal double ___MinWidthComputedValue = 0;
        internal bool ___isMinWidthValueSet = false;
        internal bool ___isMinWidthValuePercent = false;

        public string MinWidth
        {
            get { return ___convertNullToEmpty(this.___MinWidth); }
            set
            {
                this.___MinWidth = value;
                ___checkStringValue(this.___MinWidth, ref this.___MinWidthComputedValue, ref  this.___isMinWidthValueSet, ref this.___isMinWidthValuePercent, true, false);
            }
        }
        public string minwidth
        {
            get { return ___convertNullToEmpty(this.___MinWidth); }
            set
            {
                this.___MinWidth = value;
                ___checkStringValue(this.___MinWidth, ref this.___MinWidthComputedValue, ref  this.___isMinWidthValueSet, ref this.___isMinWidthValuePercent, true, false);
            }
        }
        public string minWidth
        {
            get { return ___convertNullToEmpty(this.___MinWidth); }
            set
            {
                this.___MinWidth = value;
                ___checkStringValue(this.___MinWidth, ref this.___MinWidthComputedValue, ref  this.___isMinWidthValueSet, ref this.___isMinWidthValuePercent, true, false);
            }
        }
        internal void ___checkStringValue(string ___str, ref double ____targetValue, ref bool ___IsTargetValueSet, ref bool ___isPercentValue, bool ___ignoreAuto, bool ___ignoreInherit)
        {
            try
            {

                if (string.IsNullOrEmpty(___str) == false)
                {
                    if (commonHTML.FasterIsWhiteSpaceLimited(___str[___str.Length - 1]) == true)
                    {
                        ___str = ___str.Trim();
                    }
                    if (___str[___str.Length - 1] == '%')
                    {
                        string strPercentValue = ___str.Substring(0, ___str.Length - 1);
                        double doublePercentValue = 0;
                        if (double.TryParse(strPercentValue, out doublePercentValue) == true)
                        {
                            ___isPercentValue = true;
                            ___IsTargetValueSet = true;
                            ____targetValue = doublePercentValue / 100f;
                        }
                    }
                    else
                    {
                        if (string.Equals(___str, "auto", StringComparison.OrdinalIgnoreCase) == true)
                        {
                            if (___ignoreAuto == false)
                            {
                                ___IsTargetValueSet = true;
                                ___isPercentValue = true;
                                ____targetValue = 1F;
                            }
                            else
                            {
                                ___IsTargetValueSet = false;
                                ___isPercentValue = false;
                                ____targetValue = 0;
                            }

                        }
                        else if (string.Equals(___str, "inherit", StringComparison.OrdinalIgnoreCase) == true)
                        {
                            if (___ignoreInherit == false)
                            {
                                ___IsTargetValueSet = true;
                                ___isPercentValue = true;
                                ____targetValue = 1F;
                            }
                            else
                            {
                                ___IsTargetValueSet = false;
                                ___isPercentValue = false;
                                ____targetValue = 0;
                            }
                        }
                        else
                        {
                            ___isPercentValue = false;
                            ___IsTargetValueSet = true;
                            ____targetValue = commonHTML.GetDoubleValueFromString(___str, 0, this.___HTMLTagRemUnitSize);
                        }
                    }
                }
                else
                {
                    ____targetValue = 0;
                    ___IsTargetValueSet = false;
                    ___isPercentValue = false;
                }
            }
            catch (Exception ex)
            {
                if (commonLog.LoggingEnabled)
                {
                   commonLog.LogEntry("___checkStringValue Exception", ex);
                }
            }
        }

        internal string ___MaxHeight = null;
        internal double ___MaxHeightComputedValue = 0;
        internal bool ___isMaxHeightValueSet = false;
        internal bool ___isMaxHeightValuePercent = false;

        public string MaxHeight
        {
            get { return ___convertNullToEmpty(this.___MaxHeight); }
            set
            {
                this.___MaxHeight = value;
                ___checkStringValue(this.___MaxHeight, ref this.___MaxHeightComputedValue, ref  this.___isMaxHeightValueSet, ref this.___isMaxHeightValuePercent, true, false);
            }
        }
        public string maxHeight
        {
            get { return ___convertNullToEmpty(this.___MaxHeight); }
            set
            {
                this.___MaxHeight = value;
                ___checkStringValue(this.___MaxHeight, ref this.___MaxHeightComputedValue, ref  this.___isMaxHeightValueSet, ref this.___isMaxHeightValuePercent, true, false);
            }
        }
        public string maxheight
        {
            get { return ___convertNullToEmpty(this.___MaxHeight); }
            set
            {
                this.___MaxHeight = value;
                ___checkStringValue(this.___MaxHeight, ref this.___MaxHeightComputedValue, ref  this.___isMaxHeightValueSet, ref this.___isMaxHeightValuePercent, true, false);
            }
        }

        internal string ___MaxWidth = null;
        internal double ___MaxWidthComputedValue = -1;
        internal bool ___isMaxWidthValueSet = false;
        internal bool ___isMaxWidthValuePercent = false;

        public string MaxWidth
        {
            get { return ___convertNullToEmpty(this.___MaxWidth); }
            set
            {
                this.___MaxWidth = value;
                ___checkStringValue(this.___MaxWidth, ref this.___MaxWidthComputedValue, ref  this.___isMaxWidthValueSet, ref this.___isMaxWidthValuePercent, true, false);
            }
        }
        public string maxwidth
        {
            get { return ___convertNullToEmpty(this.___MaxWidth); }
            set
            {
                this.___MaxWidth = value;
                ___checkStringValue(this.___MaxWidth, ref this.___MaxWidthComputedValue, ref  this.___isMaxWidthValueSet, ref this.___isMaxWidthValuePercent, true, false);
            }
        }

        public string maxWidth
        {
            get { return ___convertNullToEmpty(this.___MaxWidth); }
            set
            {
                this.___MaxWidth = value;
                ___checkStringValue(this.___MaxWidth, ref this.___MaxWidthComputedValue, ref  this.___isMaxWidthValueSet, ref this.___isMaxWidthValuePercent, true, false);
            }
        }

        internal string ___Cursor = null;
        public string Cursor
        {
            get { return ___convertNullToEmpty(this.___Cursor); }
            set { this.___Cursor = value; }
        }
        public string cursor
        {
            get { return ___convertNullToEmpty(this.___Cursor); }
            set { this.___Cursor = value; }
        }

        internal string ___Zoom = null;
        public string Zoom
        {
            get { return this.___Zoom; }
            set { this.___Zoom = value; }
        }
        public string zoom
        {
            get { return ___convertNullToEmpty(this.___Zoom); }
            set { this.___Zoom = value; }
        }
        internal string ___Resize = null;
        public string Resize
        {
            get { return ___convertNullToEmpty(this.___Resize); }
            set { this.___Resize = value; }
        }
        public string resize
        {
            get { return ___convertNullToEmpty(this.___Resize); }
            set { this.___Resize = value; }
        }

        private string ___zIndex = null;
        internal int ___zIndexValue = 0;
        public string zIndex
        {
            get { return this.___zIndex; }
            set
            {
                this.___zIndex = value;
                ___GetZIndexValue();
            }
        }
        public string zindex
        {
            get { return ___convertNullToEmpty(this.___zIndex); }
            set
            {
                this.___zIndex = value;
                ___GetZIndexValue();
            }
        }
        private void ___GetZIndexValue()
        {
            if (string.IsNullOrEmpty(this.___zIndex) == false)
            {
                if (commonHTML.IsStringAutoOrInheritOrZeroOrNone(this.___zIndex) == false)
                {
                    this.___zIndexValue = commonHTML.GetIntValueFromString(this.___zIndex, 0);
                }
                else
                {
                    this.___zIndexValue = 0;
                }
            }
            else
            {
                this.___zIndexValue = 0;
            }
        }


        internal string ___ListStyle = null;
        public string ListStyle
        {
            get { return this.___ListStyle; }
            set { this.___ListStyle = value; }
        }
        public string liststyle
        {
            get { return this.___ListStyle; }
            set { this.___ListStyle = value; }
        }
        public string listStyle
        {
            get { return this.___ListStyle; }
            set { this.___ListStyle = value; }
        }
        internal string ___ListStyleImage = null;
        public string ListStyleImage
        {
            get { return ___convertNullToEmpty(this.___ListStyleImage); }
            set { this.___ListStyleImage = value; }
        }
        public string liststyleimage
        {
            get { return ___convertNullToEmpty(this.___ListStyleImage); }
            set { this.___ListStyleImage = value; }
        }
        public string listStyleImage
        {
            get { return ___convertNullToEmpty(this.___ListStyleImage); }
            set { this.___ListStyleImage = value; }
        }
        /* +++++++++++ ListStyleImage is moved to ___styleElement.___multi.... ++++++*/

        /*
        public string ___ListStyleImage_FullURL = null;
        internal System.WeakReference ___ListStyleImage_ImageWeakReference = null;
         */




        public string ___IMG_FullURL = null;

        /// <summary>
        /// Index of Image oin List
        /// </summary>
        internal System.WeakReference ___IMG_ImageWeakReference = null;

        internal string ___ListStylePosition = null;
        public string ListStylePosition
        {
            get { return this.___ListStylePosition; }
            set { this.___ListStylePosition = value; }
        }
        public string liststyleposition
        {
            get { return this.___ListStylePosition; }
            set { this.___ListStylePosition = value; }
        }
        public string listStylePosition
        {
            get { return this.___ListStylePosition; }
            set { this.___ListStylePosition = value; }
        }

        public string liststyletype
        {
            get { return ___convertNullToEmpty(this.___ListStyleType); }
            set { this.___ListStyleType = value; }
        }
        public string listStyleType
        {
            get { return ___convertNullToEmpty(this.___ListStyleType); }
            set { this.___ListStyleType = value; }
        }

        internal string ___OverFlow = null;
        public string OverFlow
        {
            get { return ___convertNullToEmpty(this.___OverFlow); }
            set { this.___OverFlow = value; }
        }
        public string overflow
        {
            get { return ___convertNullToEmpty(this.___OverFlow); }
            set { this.___OverFlow = value; }
        }
        /// <summary>
        /// Non-Standard
        /// This is to use over flow informations not to copy or dupicate.
        /// </summary>
        internal string ___OverFlowFromParent = null;

        /// <summary>
        /// Non-Standard
        /// Width which style overflow has declared.
        /// </summary>
        internal int ___OverFlowFromParentWidth = 0;
        /*
		public int OverFlowFromParentWidth
		{
			set{this.___OverFlowFromParentWidth = value;}
			get{return this.___OverFlowFromParentWidth;}
		}
         */
        /// <summary>
        /// Non-Standard
        /// Height which style overflow has declared.
        /// </summary>
        internal int ___OverFlowFromParentHeight = 0;
        /*
		public int OverFlowFromParentHeight
		{
			set{this.___OverFlowFromParentHeight = value;}
			get{return this.___OverFlowFromParentHeight;}
		}
        */
        /// <summary>
        /// Non-Standard
        /// Node which declared overflow.
        /// </summary>
        internal string ___OverFlowElementStart = null;
        /*
		public string OverFlowElementStart
		{
			set{this.___OverFlowElementStart = value;}
			get{return this.___OverFlowElementStart;}
		}
         */
        internal string ___IEOnlyWidth = null;
        public string IeOnlyWidth
        {
            get { return this.___IEOnlyWidth; }
            set { this.___IEOnlyWidth = value; }
        }
        public string ieonlywidth
        {
            get { return this.___IEOnlyWidth; }
            set { this.___IEOnlyWidth = value; }
        }
        public string ieOnlyWidth
        {
            get { return this.___IEOnlyWidth; }
            set { this.___IEOnlyWidth = value; }
        }
        internal string ___ImageRendering = null;
        public string ImageRendering
        {
            get { return this.___ImageRendering; }
            set { this.___ImageRendering = value; }
        }
        public string imageRendering
        {
            get { return this.___ImageRendering; }
            set { this.___ImageRendering = value; }
        }
        public string imagerendering
        {
            get { return this.___ImageRendering; }
            set { this.___ImageRendering = value; }
        }

        internal string ___ImeMode = null;
        public string ImeMode
        {
            get { return this.___ImeMode; }
            set { this.___ImeMode = value; }
        }
        public string imeMode
        {
            get { return ___convertNullToEmpty(this.___ImeMode); }
            set { this.___ImeMode = value; }
        }
        public string imemode
        {
            get { return ___convertNullToEmpty(this.___ImeMode); }
            set { this.___ImeMode = value; }
        }
        internal string ___LetterSpacing = null;
        public string LetterSpacing
        {
            get { return ___convertNullToEmpty(this.___LetterSpacing); }
            set { this.___LetterSpacing = value; }
        }
        public string letterSpacing
        {
            get { return ___convertNullToEmpty(this.___LetterSpacing); }
            set { this.___LetterSpacing = value; }
        }
        public string letterspacing
        {
            get { return this.___LetterSpacing; }
            set { this.___LetterSpacing = value; }
        }
        internal string ___OutlineOffset = null;
        public string OutlineOffset
        {
            get { return this.___OutlineOffset; }
            set { this.___OutlineOffset = value; }
        }
        public string outlineOffset
        {
            get { return this.___OutlineOffset; }
            set { this.___OutlineOffset = value; }
        }
        public string outlineoffset
        {
            get { return this.___OutlineOffset; }
            set { this.___OutlineOffset = value; }
        }
        internal string ___Outline = null;
        public string Outline
        {
            get { return this.___Outline; }
            set { this.___Outline = value; }
        }
        public string outline
        {
            get { return this.___Outline; }
            set { this.___Outline = value; }
        }
        internal string ___OutlineColor = null;
        public string OutlineColor
        {
            get { return this.___OutlineColor; }
            set { this.___OutlineColor = value; }
        }
        internal string ___OutlineStyle = null;
        public string OutlineStyle
        {
            get { return this.___OutlineStyle; }
            set { this.___OutlineStyle = value; }
        }
        public string outlinestyle
        {
            get { return this.___OutlineStyle; }
            set { this.___OutlineStyle = value; }
        }
        internal string ___OutlineWidth = null;
        public string OutlineWidth
        {
            get { return this.___OutlineWidth; }
            set { this.___OutlineWidth = value; }
        }

        internal string ___OutlineHeight = null;
        public string OutlineHeight
        {
            get { return this.___OutlineHeight; }
            set { this.___OutlineHeight = value; }
        }
        public string outlineheight
        {
            get { return this.___OutlineHeight; }
            set { this.___OutlineHeight = value; }
        }
        internal string ___UserSelect = null;
        public string UserSelect
        {
            set { this.___UserSelect = value; }
            get { return this.___UserSelect; }
        }
        public string userSelect
        {
            set { this.___UserSelect = value; }
            get { return this.___UserSelect; }
        }
        public string webkitUserSelect
        {
            set { this.___UserSelect = value; }
            get { return this.___UserSelect; }
        }

        public string userselect
        {
            set { this.___UserSelect = value; }
            get { return this.___UserSelect; }
        }
        public string KhtmlUserSelect
        {
            set { this.___UserSelect = value; }
            get { return this.___UserSelect; }
        }
        public string khtmluserselect
        {
            set { this.___UserSelect = value; }
            get { return this.___UserSelect; }
        }

        public string webkituserselect
        {
            set { this.___UserSelect = value; }
            get { return this.___UserSelect; }
        }
        public string msUserSelect
        {
            set { this.___UserSelect = value; }
            get { return this.___UserSelect; }
        }
        public string msuserselect
        {
            set { this.___UserSelect = value; }
            get { return this.___UserSelect; }
        }
        public string mozuserselect
        {
            set { this.___UserSelect = value; }
            get { return this.___UserSelect; }
        }
        public string mozUserSelect
        {
            set { this.___UserSelect = value; }
            get { return this.___UserSelect; }
        }
        internal string ___Flex = null;
        public string Flex
        {
            get { return this.___Flex; }
            set { this.___Flex = value; }
        }
        public string flex
        {
            get { return this.___Flex; }
            set { this.___Flex = value; }
        }
        internal string ___FlexDirection = null;
        public string FlexDirection
        {
            get { return this.___FlexDirection; }
            set { this.___FlexDirection = value; }
        }
        public string flexDirection
        {
            get { return this.___FlexDirection; }
            set { this.___FlexDirection = value; }
        }
        public string flexdirection
        {
            get { return this.___FlexDirection; }
            set { this.___FlexDirection = value; }
        }
        internal string ___flexWrap = null;
        public string flexWrap
        {
            get { return ___convertNullToEmpty(this.___flexWrap); }
            set { this.___flexWrap = value; }
        }
        public string FlexWrap
        {
            get { return ___convertNullToEmpty(this.___flexWrap); }
            set { this.___flexWrap = value; }
        }
        public string flexwrap
        {
            get { return ___convertNullToEmpty(this.___flexWrap); }
            set { this.___flexWrap = value; }
        }
        internal string ___flexFlow = null;
        public string flexFlow
        {
            get { return ___convertNullToEmpty(this.___flexFlow); }
            set { this.___flexFlow = value; }
        }
        internal string ___alignContent = null;
        public string alignContent
        {
            get { return ___convertNullToEmpty(this.___alignContent); }
            set { this.___alignContent = value; }
        }
        internal string ___flexOrder = null;
        public string flexOrder
        {
            get { return ___convertNullToEmpty(this.___flexOrder); }
            set { this.___flexOrder = value; }
        }
        internal string ___Filter = null;
        public string Filter
        {
            get { return ___convertNullToEmpty(this.___Filter); }
            set { this.___Filter = value; }
        }
        internal string ___flexLinePack = null;
        public string flexLinePack
        {
            get { return ___convertNullToEmpty(this.___flexLinePack); }
            set { this.___flexLinePack = value; }
        }
        public string filter
        {
            get { return ___convertNullToEmpty(this.___Filter); }
            set { this.___Filter = value; }
        }
        internal string ___contentZooming = null;
        public string contentZooming
        {
            get { return ___convertNullToEmpty(this.___contentZooming); }
            set { this.___contentZooming = value; }
        }
        public string mscontentzooming
        {
            get { return ___convertNullToEmpty(this.___contentZooming); }
            set { this.___contentZooming = value; }
        }
        public string mozcontentzooming
        {
            get { return ___convertNullToEmpty(this.___contentZooming); }
            set { this.___contentZooming = value; }
        }
        public string webkitcontentzooming
        {
            get { return ___convertNullToEmpty(this.___contentZooming); }
            set { this.___contentZooming = value; }
        }
        public string khtmlcontentzooming
        {
            get { return ___convertNullToEmpty(this.___contentZooming); }
            set { this.___contentZooming = value; }
        }
        public string contentzooming
        {
            get { return ___convertNullToEmpty(this.___contentZooming); }
            set { this.___contentZooming = value; }
        }
        internal string ___OverFlowY = null;
        internal CSSOverFlowType ___OverFlowYComputedType = CSSOverFlowType.NotSet;
        public string OverFlowY
        {
            get { return ___convertNullToEmpty(this.___OverFlowY); }
            set { this.___OverFlowY = value; }
        }
        public string overflowy
        {
            get { return ___convertNullToEmpty(this.___OverFlowY); }
            set { this.___OverFlowY = value; }
        }
        internal string ___OverFlowX = null;
        internal CSSOverFlowType ___OverFlowXComputedType = CSSOverFlowType.NotSet;
        public string OverFlowX
        {
            get { return ___convertNullToEmpty(this.___OverFlowX); }
            set { this.___OverFlowX = value; }
        }
        public string overflowx
        {
            get { return ___convertNullToEmpty(this.___OverFlowX); }
            set { this.___OverFlowX = value; }
        }
        internal string ___OverFlowWrap = null;
        public string OverFlowWrap
        {
            get { return ___convertNullToEmpty(this.___OverFlowWrap); }
            set { this.___OverFlowWrap = value; }
        }
        public string overflowwrap
        {
            get { return ___convertNullToEmpty(this.___OverFlowWrap); }
            set { this.___OverFlowWrap = value; }
        }
        public string overflowWrap
        {
            get { return ___convertNullToEmpty(this.___OverFlowWrap); }
            set { this.___OverFlowWrap = value; }
        }
        internal string ___OverFlowScrolling = null;
        public string OverflowScrolling
        {
            set { this.___OverFlowScrolling = value; }
            get { return this.___OverFlowScrolling; }
        }
        public string overflowScrolling
        {
            set { this.___OverFlowScrolling = value; }
            get { return this.___OverFlowScrolling; }
        }
        public string overflowscrolling
        {
            set { this.___OverFlowScrolling = value; }
            get { return this.___OverFlowScrolling; }
        }
        internal string ___OverFlowStyle = null;
        public string OverflowStyle
        {
            get { return this.___OverFlowStyle; }
            set { this.___OverFlowStyle = value; }
        }
        public string overflowStyle
        {
            get { return this.___OverFlowStyle; }
            set { this.___OverFlowStyle = value; }
        }
        public string overflowstyle
        {
            get { return this.___OverFlowStyle; }
            set { this.___OverFlowStyle = value; }
        }
        internal string ___PrintColorAjdust = null;
        public string PrintColorAdjust
        {
            get { return this.___PrintColorAjdust; }
            set { this.___PrintColorAjdust = value; }
        }

        private string ___Opacity = null;
        internal double ___OpacityPasedValue = 1;
        internal void ___ParseOpacity()
        {
            try
            {
                if (string.IsNullOrEmpty(this.___Opacity) == false)
                {
                    if (commonHTML.IsStringAutoOrInheritOrZeroOrNone(this.___Opacity) == false)
                    {
                        double.TryParse(this.___Opacity, out  this.___OpacityPasedValue);
                    }
                }
                else
                {
                    this.___OpacityPasedValue = 1;
                }
            }
            catch (Exception)
            {
                if (commonLog.LoggingEnabled &&commonLog.CommonLogLevel >= 8)
                {
                   commonLog.LogEntry(" ___ParseOpacity() Error : " + this.___Opacity);
                }
            }
        }
        public string Opacity
        {
            get { return this.___Opacity; }
            set
            {
                this.___Opacity = value;
                this.___ParseOpacity();
            }
        }
        public string opacity
        {
            get { return this.___Opacity; }
            set
            {
                this.___Opacity = value;
                this.___ParseOpacity();
            }
        }
        public string MozOpacity
        {
            get { return this.___Opacity; }
            set
            {
                this.___Opacity = value;
                this.___ParseOpacity();
            }
        }
        public string KhtmlOpacity
        {
            get { return this.___Opacity; }
            set
            {
                this.___Opacity = value;
                this.___ParseOpacity();
            }
        }
        internal string ___Behavior = null;
        public string behavior
        {
            get { return this.___Behavior; }
            set { this.___Behavior = value; }
        }
        public string Behavior
        {
            get { return this.___Behavior; }
            set { this.___Behavior = value; }
        }
        internal string ___VoiceFamily = null;
        public string VoiceFamily
        {
            set { this.___VoiceFamily = value; }
            get { return this.___VoiceFamily; }
        }
        public string voicefamily
        {
            set { this.___VoiceFamily = value; }
            get { return this.___VoiceFamily; }
        }
        internal string ___WordSpacing = null;
        public string WordSpacing
        {
            set { this.___WordSpacing = value; }
            get { return this.___WordSpacing; }
        }
        public string wordspacing
        {
            set { this.___WordSpacing = value; }
            get { return this.___WordSpacing; }
        }
        public string wordSpacing
        {
            set { this.___WordSpacing = value; }
            get { return this.___WordSpacing; }
        }

        internal string ___EmptyCells = null;
        public string EmptyCells
        {
            set { this.___EmptyCells = value; }
            get { return this.___EmptyCells; }
        }
        public string emptyCells
        {
            set { this.___EmptyCells = value; }
            get { return this.___EmptyCells; }
        }
        public string emptycells
        {
            set { this.___EmptyCells = value; }
            get { return this.___EmptyCells; }
        }
        internal string ___CellPadding = null;
        public string CellPadding
        {
            set { this.___CellPadding = value; }
            get { return this.___CellPadding; }
        }
        public string cellPadding
        {
            set { this.___CellPadding = value; }
            get { return this.___CellPadding; }
        }
        public string cellpadding
        {
            set { this.___CellPadding = value; }
            get { return this.___CellPadding; }
        }
        internal string ___CellSpacing = null;
        public string CellSpacing
        {
            set { this.___CellSpacing = value; }
            get { return this.___CellSpacing; }
        }
        public string cellSpacing
        {
            set { this.___CellSpacing = value; }
            get { return this.___CellSpacing; }
        }
        public string cellspacing
        {
            set { this.___CellSpacing = value; }
            get { return this.___CellSpacing; }
        }

        internal string ___Relative = null;
        public string Relative
        {
            set { this.___Relative = value; }
            get { return this.___Relative; }
        }

        public string relative
        {
            set { this.___Relative = value; }
            get { return this.___Relative; }
        }
        internal string ___Quotes = null;
        public string Quotes
        {
            set { this.___Quotes = value; }
            get { return this.___Quotes; }
        }
        public string quotes
        {
            set { this.___Quotes = value; }
            get { return this.___Quotes; }
        }
        internal string ___BorderRadius = null;
        internal bool ___BorderRadiusOneOfValuePositive = false;
        public string BorderRadius
        {
            set { this.___BorderRadius = value; }
            get { return this.___BorderRadius; }
        }
        public string borderRadius
        {
            set { this.___BorderRadius = value; }
            get { return this.___BorderRadius; }
        }
        public string borderradius
        {
            set { this.___BorderRadius = value; }
            get { return this.___BorderRadius; }
        }
        internal void ___parseBorderRadiusSideCornerString(int CornerVal, double ___remSize)
        {
            string strValue = null;
            switch (CornerVal)
            {
                case 1:
                    strValue = this.___BorderTopLeftRadius;
                    break;
                case 2:
                    strValue = this.___BorderTopRightRadius;
                    break;
                case 3:
                    strValue = this.___BorderBottomRightRadius;
                    break;
                case 4:
                    strValue = this.___BorderBottomLeftRadius;
                    break;
            }
            if (string.IsNullOrEmpty(strValue) == false)
            {
                string[] spRadiusValue = strValue.Split(commonHTML.CharSpaceCrLfTab);
                int spLen = spRadiusValue.Length;
                for (int i = 0; i < spLen; i++)
                {
                    string strRadiusValue = spRadiusValue[i];
                    if (strRadiusValue.Length != 0)
                    {
                        double doubleEachRadiusValue = commonHTML.GetDoubleValueFromString(strRadiusValue, 0, ___remSize);
                        switch (CornerVal)
                        {
                            case 1:
                                this.___BorderTopLeftRadiusHorizontalComputedValue = doubleEachRadiusValue;
                                this.___BorderTopLeftRadiusVerticalComputedValue = doubleEachRadiusValue;
                                this.___BorderRadiusOneOfValuePositive = true;
                                break;
                            case 2:
                                this.___BorderTopRightRadiusHorizontalComputedValue = doubleEachRadiusValue;
                                this.___BorderTopRightRadiusVerticalComputedValue = doubleEachRadiusValue;
                                this.___BorderRadiusOneOfValuePositive = true;
                                break;
                            case 3:
                                this.___BorderBottomRightRadiusHorizontalComputedValue = doubleEachRadiusValue;
                                this.___BorderBottomRightRadiusVerticalComputedValue = doubleEachRadiusValue;
                                this.___BorderRadiusOneOfValuePositive = true;
                                break;
                            case 4:
                                this.___BorderBottomLeftRadiusHorizontalComputedValue = doubleEachRadiusValue;
                                this.___BorderBottomLeftRadiusVerticalComputedValue = doubleEachRadiusValue;
                                this.___BorderRadiusOneOfValuePositive = true;
                                break;
                        }

                    }
                }


            }
            else
            {
                switch (CornerVal)
                {
                    case 1:
                        this.___BorderTopLeftRadiusHorizontalComputedValue = 0;
                        this.___BorderTopLeftRadiusVerticalComputedValue = 0;
                        break;
                    case 2:
                        this.___BorderTopRightRadiusHorizontalComputedValue = 0;
                        this.___BorderTopRightRadiusVerticalComputedValue = 0;
                        break;
                    case 3:
                        this.___BorderBottomRightRadiusHorizontalComputedValue = 0;
                        this.___BorderBottomRightRadiusVerticalComputedValue = 0;
                        break;
                    case 4:
                        this.___BorderBottomLeftRadiusHorizontalComputedValue = 0;
                        this.___BorderBottomLeftRadiusVerticalComputedValue = 0;
                        break;
                }
            }
        }
        /// <summary>
        /// BorderRadius will set values each corner
        /// </summary>
        internal void ___parseBorderRadiusMain()
        {
            int slashPos = this.___BorderRadius.IndexOf('/');
            /* (Possile Values)
             *  100px 25px 50px 50px / 50px 25px 50px 25px; (horizonta/vertical)
             *  0.5em;
             */
            string[] spLeftValues = null;
            try
            {
                if (slashPos != -1)
                {
                    spLeftValues = this.___BorderRadius.Substring(0, slashPos).Split(commonHTML.CharSpaceCrLfTab);
                    ___parseBorderRadiusMain2nd(spLeftValues, true, true, this.___HTMLTagRemUnitSize);
                    string[] spRightValues = this.___BorderRadius.Substring(slashPos + 1).Split(commonHTML.CharSpaceCrLfTab);
                    ___parseBorderRadiusMain2nd(spRightValues, false, true, this.___HTMLTagRemUnitSize);
                }
                else
                {
                    spLeftValues = this.___BorderRadius.Split(commonHTML.CharSpaceCrLfTab);
                    ___parseBorderRadiusMain2nd(spLeftValues, true, false, this.___HTMLTagRemUnitSize);
                }
            }
            catch (Exception ex)
            {
                if (commonLog.LoggingEnabled &&commonLog.CommonLogLevel >= 8)
                {
                   commonLog.LogEntry("___parseBorderRadiusMain() Error", ex);
                }
            }
        }
        private void ___parseBorderRadiusMain2nd(string[] spValues, bool IsLeft, bool hasVertical, double ___remSize)
        {
            int spLen = spValues.Length;
            string s;
            if (spLen == 1)
            {
                double doubleValueAll = commonHTML.GetDoubleValueFromString(spValues[0], 0, ___remSize);
                if (hasVertical == false)
                {
                    this.___BorderBottomLeftRadiusHorizontalComputedValue = doubleValueAll;
                    this.___BorderBottomLeftRadiusVerticalComputedValue = doubleValueAll;
                    this.___BorderBottomRightRadiusHorizontalComputedValue = doubleValueAll;
                    this.___BorderBottomRightRadiusVerticalComputedValue = doubleValueAll;
                    this.___BorderTopLeftRadiusHorizontalComputedValue = doubleValueAll;
                    this.___BorderTopLeftRadiusVerticalComputedValue = doubleValueAll;
                    this.___BorderTopRightRadiusHorizontalComputedValue = doubleValueAll;
                    this.___BorderTopRightRadiusVerticalComputedValue = doubleValueAll;
                }
                else
                {
                    if (IsLeft)
                    {
                        this.___BorderBottomLeftRadiusHorizontalComputedValue = doubleValueAll;
                        this.___BorderBottomRightRadiusHorizontalComputedValue = doubleValueAll;
                        this.___BorderTopLeftRadiusHorizontalComputedValue = doubleValueAll;
                        this.___BorderTopRightRadiusHorizontalComputedValue = doubleValueAll;
                    }
                    else
                    {
                        this.___BorderBottomLeftRadiusVerticalComputedValue = doubleValueAll;
                        this.___BorderBottomRightRadiusVerticalComputedValue = doubleValueAll;
                        this.___BorderTopLeftRadiusVerticalComputedValue = doubleValueAll;
                        this.___BorderTopRightRadiusVerticalComputedValue = doubleValueAll;
                    }

                }
            }
            else
            {
                int ___StringValuesCount = 0;
                for (int i = 0; i < spLen; i++)
                {
                    s = spValues[i];
                    if (s.Length != 0)
                    {
                        ___StringValuesCount++;
                        double ___doubleEachValue = commonHTML.GetDoubleValueFromString(s, 0, ___remSize);
                        switch (___StringValuesCount)
                        {
                            // TopLeft
                            case 1:
                                if (hasVertical == false)
                                {
                                    this.___BorderTopLeftRadiusHorizontalComputedValue = ___doubleEachValue;
                                    this.___BorderTopLeftRadiusVerticalComputedValue = ___doubleEachValue;
                                }
                                else
                                {
                                    if (IsLeft)
                                    {
                                        this.___BorderTopLeftRadiusHorizontalComputedValue = ___doubleEachValue;
                                    }
                                    else
                                    {
                                        this.___BorderTopLeftRadiusVerticalComputedValue = ___doubleEachValue;
                                    }
                                }
                                break;
                            // TopRight
                            case 2:
                                if (hasVertical == false)
                                {
                                    this.___BorderTopRightRadiusHorizontalComputedValue = ___doubleEachValue;
                                    this.___BorderTopRightRadiusVerticalComputedValue = ___doubleEachValue;
                                }
                                else
                                {
                                    if (IsLeft)
                                    {
                                        this.___BorderTopRightRadiusHorizontalComputedValue = ___doubleEachValue;
                                    }
                                    else
                                    {
                                        this.___BorderTopRightRadiusVerticalComputedValue = ___doubleEachValue;
                                    }
                                }
                                break;
                            // BottomRight
                            case 3:
                                if (hasVertical == false)
                                {
                                    this.___BorderBottomRightRadiusHorizontalComputedValue = ___doubleEachValue;
                                    this.___BorderBottomRightRadiusVerticalComputedValue = ___doubleEachValue;
                                }
                                else
                                {
                                    if (IsLeft)
                                    {
                                        this.___BorderBottomRightRadiusHorizontalComputedValue = ___doubleEachValue;
                                    }
                                    else
                                    {
                                        this.___BorderBottomRightRadiusVerticalComputedValue = ___doubleEachValue;
                                    }
                                }
                                break;
                            // BottomLeft
                            case 4:
                                if (hasVertical == false)
                                {
                                    this.___BorderBottomLeftRadiusHorizontalComputedValue = ___doubleEachValue;
                                    this.___BorderBottomLeftRadiusVerticalComputedValue = ___doubleEachValue;
                                }
                                else
                                {
                                    if (IsLeft)
                                    {
                                        this.___BorderBottomLeftRadiusHorizontalComputedValue = ___doubleEachValue;
                                    }
                                    else
                                    {
                                        this.___BorderBottomLeftRadiusVerticalComputedValue = ___doubleEachValue;
                                    }
                                }
                                break;
                        }

                    }
                }
            }
            this.___parseBorderRadiusCheckOneOfValuesIsPositive();
        }
        /// <summary>
        /// Checks if any of Border-Radius values positive.
        /// </summary>
        private void ___parseBorderRadiusCheckOneOfValuesIsPositive()
        {
            this.___BorderRadiusOneOfValuePositive = false;

            if (this.___BorderBottomLeftRadiusHorizontalComputedValue > 0)
            {
                this.___BorderRadiusOneOfValuePositive = true;
                return;
            }

            if (this.___BorderBottomLeftRadiusVerticalComputedValue > 0)
            {
                this.___BorderRadiusOneOfValuePositive = true;
                return;
            }

            if (this.___BorderBottomRightRadiusHorizontalComputedValue > 0)
            {
                this.___BorderRadiusOneOfValuePositive = true;
                return;
            }

            if (this.___BorderBottomRightRadiusVerticalComputedValue > 0)
            {
                this.___BorderRadiusOneOfValuePositive = true;
                return;
            }

            if (this.___BorderTopLeftRadiusHorizontalComputedValue > 0)
            {
                this.___BorderRadiusOneOfValuePositive = true;
                return;
            }
            if (this.___BorderTopLeftRadiusVerticalComputedValue > 0)
            {
                this.___BorderRadiusOneOfValuePositive = true;
                return;
            }
            if (this.___BorderTopRightRadiusHorizontalComputedValue > 0)
            {
                this.___BorderRadiusOneOfValuePositive = true;
                return;
            }
            if (this.___BorderTopRightRadiusVerticalComputedValue > 0)
            {
                this.___BorderRadiusOneOfValuePositive = true;
                return;
            }
        }
        internal string ___Direction = null;
        public string Direction
        {
            set { this.___Direction = value; }
            get { return this.___Direction; }
        }
        public string direction
        {
            set { this.___Direction = value; }
            get { return this.___Direction; }
        }

        internal string ___BoxShadow = null;
        public string BoxShadow
        {
            get { return this.___BoxShadow; }
            set { this.___BoxShadow = value; }
        }
        public string boxShadow
        {
            get { return this.___BoxShadow; }
            set { this.___BoxShadow = value; }
        }
        public string boxshadow
        {
            get { return this.___BoxShadow; }
            set { this.___BoxShadow = value; }
        }
        internal string ___BoxShadowBoxShadow;
        public string BoxShadowBoxShadow
        {
            get { return this.___BoxShadowBoxShadow; }
            set { this.___BoxShadowBoxShadow = value; }
        }
        public string boxShadowBoxShadow
        {
            get { return this.___BoxShadowBoxShadow; }
            set { this.___BoxShadowBoxShadow = value; }
        }
        internal string ___BoxSizing = null;
        public string BoxSizing
        {
            get { return this.___BoxSizing; }
            set { this.___BoxSizing = value; }
        }
        public string boxSizing
        {
            get { return this.___BoxSizing; }
            set { this.___BoxSizing = value; }
        }
        public string boxsizing
        {
            get { return this.___BoxSizing; }
            set { this.___BoxSizing = value; }
        }
        internal string ___BoxDirection = null;
        public string BoxDirection
        {
            get { return this.___BoxDirection; }
            set { this.___BoxDirection = value; }
        }
        public string boxDirection
        {
            get { return this.___BoxDirection; }
            set { this.___BoxDirection = value; }
        }
        public string boxdirection
        {
            get { return this.___BoxDirection; }
            set { this.___BoxDirection = value; }
        }
        internal string ___BoxOrient = null;
        public string BoxOrient
        {
            set { this.___BoxOrient = value; }
            get { return this.___BoxOrient; }
        }
        public string boxOrient
        {
            set { this.___BoxOrient = value; }
            get { return this.___BoxOrient; }
        }
        internal string ___BoxReflect = null;
        public string boxReflect
        {
            get { return this.___BoxReflect; }
            set { this.___BoxReflect = value; }
        }
        public string boxfeflect
        {
            get { return this.___BoxReflect; }
            set { this.___BoxReflect = value; }
        }
        public string BoxReflect
        {
            get { return this.___BoxReflect; }
            set { this.___BoxReflect = value; }
        }
        internal string ___BreakInside = null;
        public string BreakInside
        {
            get { return this.___BreakInside; }
            set { this.___BreakInside = value; }
        }
        public string breakinside
        {
            get { return this.___BreakInside; }
            set { this.___BreakInside = value; }
        }
        internal string ___ColumnCount = null;
        public string columnCount
        {
            get { return this.___ColumnCount; }
            set { this.___ColumnCount = value; }
        }
        public string columncount
        {
            get { return this.___ColumnCount; }
            set { this.___ColumnCount = value; }
        }
        public string ColumnCount
        {
            get { return this.___ColumnCount; }
            set { this.___ColumnCount = value; }
        }
        internal string ___ColumnSpan = null;
        public string ColumnSpan
        {
            get { return this.___ColumnSpan; }
            set { this.___ColumnSpan = value; }
        }
        internal string ___ColumnGap = null;
        public string ColumnGap
        {
            get { return this.___ColumnGap; }
            set { this.___ColumnGap = value; }
        }
        internal string ___ColumnWidth = null;
        public string ColumnWidth
        {
            get { return this.___ColumnWidth; }
            set { this.___ColumnWidth = value; }
        }
        public string columnwidth
        {
            get { return this.___ColumnWidth; }
            set { this.___ColumnWidth = value; }
        }
        internal string ___LineClamp = null;
        public string lineClamp
        {
            set { this.___LineClamp = value; }
            get { return this.___LineClamp; }
        }
        public string lineclamp
        {
            set { this.___LineClamp = value; }
            get { return this.___LineClamp; }
        }

        internal string ___BoxModel = null;
        public string BoxModel
        {
            get { return this.___BoxModel; }
            set { this.___BoxModel = value; }
        }
        public string boxModel
        {
            get { return this.___BoxModel; }
            set { this.___BoxModel = value; }
        }
        public string boxmodel
        {
            get { return this.___BoxModel; }
            set { this.___BoxModel = value; }
        }
        internal string ___BoxPack = null;
        public string BoxPack
        {
            set { this.___BoxPack = value; }
            get { return this.___BoxPack; }
        }
        public string boxpack
        {
            set { this.___BoxPack = value; }
            get { return this.___BoxPack; }
        }
        public string boxPack
        {
            set { this.___BoxPack = value; }
            get { return this.___BoxPack; }
        }
        internal string ___BoxAlign = null;
        public string BoxAlign
        {
            get { return this.___BoxAlign; }
            set { this.___BoxAlign = value; }
        }
        public string boxalign
        {
            get { return this.___BoxAlign; }
            set { this.___BoxAlign = value; }
        }
        internal string ___BoxFlex = null;
        public string BoxFlex
        {
            set { this.___BoxFlex = value; }
            get { return this.___BoxFlex; }
        }
        public string boxflex
        {
            set { this.___BoxFlex = value; }
            get { return this.___BoxFlex; }
        }
        public string boxFlex
        {
            set { this.___BoxFlex = value; }
            get { return this.___BoxFlex; }
        }
        internal string ___BoxOrdinalGroup = null;
        public string BoxOrdinalGroup
        {
            set { this.___BoxOrdinalGroup = value; }
            get { return this.___BoxOrdinalGroup; }
        }
        public string boxordinalgroup
        {
            set { this.___BoxOrdinalGroup = value; }
            get { return this.___BoxOrdinalGroup; }
        }


        internal CHtmlUri ___AHrefBase = null;


        internal string ___type = null;
        public string type
        {
            get { return commonHTML.___convertNullToEmpty(this.___type); }
            set { this.___type = value; }
        }
        internal string ___highContrastAdjust = null;
        public string highContrastAdjust
        {
            get { return this.___highContrastAdjust; }
            set { this.___highContrastAdjust = value; }
        }
        public string HighContrastAdjust
        {
            get { return this.___highContrastAdjust; }
            set { this.___highContrastAdjust = value; }
        }
        /// <summary>
        /// Style Field value list (nullable)
        /// </summary>
        internal System.Collections.Generic.List<CHtmlStyleAttribute?> ___styleAttributeList;


        public string columnWidth
        {
            get { return this.___ColumnWidth; }
            set { this.___ColumnWidth = value; }
        }
        internal string ___TextEmphasisStyle = null;
        public string TextEmphasisStyle
        {
            get { return this.___TextEmphasisStyle; }
        }




        public bool ___isCSSRuleForThisNode = false;

        public void StyleCommentAdd(object s)
        {
            if (s == null)
            {
                return;
            }
            if (this.___StyleCommentBuilder == null)
            {
                this.___StyleCommentBuilder = new System.Text.StringBuilder();
            }
            this.___StyleCommentBuilder.Append(s);
        }
        public string StyleComment
        {
            get
            {
                if (this.___StyleCommentBuilder == null)
                {
                    return "";
                }
                return this.___StyleCommentBuilder.ToString();
            }

        }

        /*
		public void Dispose()
		{
			this.CleanUp();
			GC.SuppressFinalize(this);
		}
		~CHtmlCSSStyleSheet()
		{
			this.CleanUp();
		}
         */


        internal void CleanUp()
        {
            try
            {

                if (this.___styleAttributeList != null)
                {
                    this.___styleAttributeList = null;
                }

                if (this.___ownerElementWeakReference != null)
                {
                    this.___ownerElementWeakReference = null;
                }
                if (this.___MediaQueryNodeInstance != null)
                {
                    this.___MediaQueryNodeInstance = null;
                }
                this.___WorkingKeyClassList = null;
                this.___WorkingKeyPseudoTitleList = null;
                this.___WorkingKeyAttributeKeyList = null;
                this.___WorkingSelectorClassKey = null;
                this.___multipleBackgroundImageDataSet = null;
            }
            catch (Exception ex)
            {
                if (commonLog.LoggingEnabled)
                {
                   commonLog.LogEntry("CHtmlCSSStyleSheet Dispose : " + ex.Message);
                }
            }
        }

        public override string ToString()
        {
            if (this.___IsPrototype == false)
            {
                if (this.___IsOwnerElementAssigned() == true)
                {
                    return string.Format("CHtmlCSSStyleSheet {0} for {1}", this.___StyleType, this.ownerElement);
                }
                else
                {
                    return "CHtmlCSSStyleSheet " + this.___SelectorID;
                }
            }
            else
            {
                return "CHtmlCSSStyleSheet Prototype";
            }
        }
        public bool StyleListsContainsKey(string _name)
        {
            if (this.___HasStyleListSorted == false)
            {
                this.___StyleListSort();
            }
            string sLow = null;
            if (_name != null)
            {
                sLow = commonHTML.FasterTrimAndToLower(_name);
            }
            CHtmlStyleAttribute? attr = null;
            CHtmlStyleAttribute attrVal = (CHtmlStyleAttribute)attr;
            attrVal.Name = sLow;
            int pos = this.___styleAttributeList.BinarySearch(attr, new CHtmlStyleAttributeComparer());
            if (pos > -1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #region ICloneable �����o

        public CHtmlCSSStyleSheet CloneCHtmlStyleElement()
        {
            CHtmlCSSStyleSheet sNew = new CHtmlCSSStyleSheet(this.___StyleType);
            try
            {
                if (this.___styleAttributeList != null && this.___styleAttributeList.Count > 0)
                {

                    sNew.___styleAttributeList.AddRange(this.___styleAttributeList);
                }
                // Checking Value is good!
                if (string.IsNullOrEmpty(this.___baseUrl) == false)
                {
                    sNew.___baseUrl = string.Copy(this.___baseUrl);
                }
                if (string.IsNullOrEmpty(this.___ImageUrlHint) == false)
                {
                    sNew.___ImageUrlHint = string.Copy(this.___ImageUrlHint);
                }
                if (string.IsNullOrEmpty(this.___SelectorID) == false)
                {
                    sNew.___SelectorID = string.Copy(this.___SelectorID);
                }

                sNew.___HasCombinatorChar = this.___HasCombinatorChar;

                if (this.___MediaQueryNodeInstance != null)
                {
                    sNew.___MediaQueryNodeWeakReference = new WeakReference(this.___MediaQueryNodeInstance, false);
                }
                if (this.___MediaQueryNodeWeakReference != null)
                {
                    sNew.___MediaQueryNodeWeakReference = this.___MediaQueryNodeWeakReference;
                }


                /*
                if(this.___styleKeyWorkingList.Count > 0)
                {
		
                    sNew.___styleKeyWorkingList = this.___styleKeyWorkingList.Clone() as System.Collections.ArrayList;
                }
                if(this.___styleKeyOrignalList.Count > 0)
                {
                    sNew.___styleKeyOrignalList = null;
                    sNew.___styleKeyOrignalList = this.___styleKeyOrignalList.Clone() as System.Collections.ArrayList;
                }
                */


                sNew.___isCSSRuleForThisNode = this.___isCSSRuleForThisNode;
                // ==========================================================
                if (this.IsSortedListFieldsHasCopiedToProperty == true)
                {
                    if (this.___StyleType != CHtmlElementStyleType.None && this.___StyleType != CHtmlElementStyleType.Prototype)
                    {
                        this.___copyStyleElementFields(sNew, false, false);
                    }
                    sNew.IsSortedListFieldsHasCopiedToProperty = this.IsSortedListFieldsHasCopiedToProperty;
                }
                if (this.___StyleCommentBuilder != null)
                {
                    sNew.StyleCommentAdd(this.___StyleCommentBuilder.ToString());
                }

                sNew.___style_unique_id = ___style_unique_id;

                sNew.___SelectorRanking = this.___SelectorRanking;
                if (string.IsNullOrEmpty(this.___WorkingKey) == false)
                {
                    sNew.___WorkingKey = string.Copy(this.___WorkingKey);
                }
                if (string.IsNullOrEmpty(this.___GroundSortKey) == false)
                {
                    sNew.___GroundSortKey = string.Copy(this.___GroundSortKey);
                }
                sNew.___StyleType = this.___StyleType;



                sNew.___WorkingKeyCombinatorChar = this.___WorkingKeyCombinatorChar;
                sNew.___WorkingKeyClassList = this.___WorkingKeyClassList;
                sNew.___WorkingKeyPseudoTitleList = this.___WorkingKeyPseudoTitleList;
                sNew.___WorkingKeyAttributeKeyList = this.___WorkingKeyAttributeKeyList;
                sNew.___WorkingSelectorClassKey = this.___WorkingSelectorClassKey;
                sNew.___LastReCreateWorkingKeyCompleteListLength = this.___LastReCreateWorkingKeyCompleteListLength;
                sNew.___CSSPosition = this.___CSSPosition;
                sNew.___PseudoClassType = this.___PseudoClassType;
                sNew.___FontRelatedCount = this.___FontRelatedCount;
                sNew.___isFinalStyleKeyWildCardOnly = this.___isFinalStyleKeyWildCardOnly;

                if (string.IsNullOrEmpty(this.___SelectorTextOriginal) == false)
                {
                    sNew.___SelectorTextOriginal = string.Copy(this.___SelectorTextOriginal);
                }
                sNew.___SelectorRanking = this.___SelectorRanking;
                sNew.___SelectorMediaQueryRanking = this.___SelectorMediaQueryRanking;
                sNew.___SelectorConmaCount = this.___SelectorConmaCount;
            }
            catch (Exception exStyleCopy)
            {
                if (commonLog.LoggingEnabled &&commonLog.CommonLogLevel > 8)
                {
                   commonLog.LogEntry("CLoneCHtmlStyleElement Exception", exStyleCopy);
                }
            }
            return sNew;
        }



        public string csstext
        {
            set
            {
                this.cssTextSetter(value);
            }
            get
            {
                return this.cssTextGetter();
            }
        }

        public string cssText
        {
            set
            {
                this.cssTextSetter(value);
            }
            get
            {
                return this.cssTextGetter();
            }
        }

        public string cssTextGetter()
        {
            // assuming all in lists
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            try
            {
                foreach (CHtmlStyleAttribute st in this.___styleAttributeList)
                {
                    sb.Append(st.Name);
                    sb.Append(": ");
                    sb.Append(st.value);
                    sb.Append(" ");
                    sb.Append(";");
                }
            }
            catch
            {
                if (commonLog.LoggingEnabled &&commonLog.CommonLogLevel >= 10)
                {
                   commonLog.LogEntry("Error During creating cssText");
                }
            }
            return sb.ToString();

        }
        private string ___getPossibleBaseURLString()
        {
            if (string.IsNullOrEmpty(this.___baseUrl) == false)
            {
                return this.___baseUrl;
            }
            if (this.___ownerElementWeakReference != null)
            {
                CHtmlElement __parentElement = this.___ownerElementWeakReference.Target as CHtmlElement;
                if (__parentElement != null)
                {
                    if (__parentElement.___documentWeakRef != null)
                    {
                        return string.Copy(__parentElement.___getDocument().___URL);
                    }
                    if (__parentElement.___locationBase != null)
                    {
                        if (string.IsNullOrEmpty(__parentElement.___locationBase.href) == false)
                        {
                            return string.Copy(__parentElement.___locationBase.href);
                        }
                    }
                }
            }
            return "";
        }
   
        internal void cssTextSetter(string ___Text)
        {
            CHtmlCollection ___styleCHtmlCollection = null;
            CHtmlStopWatch __stopWatch = null;
            bool ___IsStyleMerged = false;
            System.Collections.Generic.List<CHtmlStyleAttribute?> attributeList = null;
            try
            {
                if (commonLog.LoggingEnabled &&commonLog.CommonLogLevel >= 7)
                {
                    __stopWatch = new CHtmlStopWatch();
                }
                if (___Text != null && ___Text.Length > 0)
                {
                    bool ___IsCSssTextContainsTitle = false;

                    if (___Text.IndexOf('{') == -1)
                    {
                        if (commonLog.LoggingEnabled &&commonLog.CommonLogLevel >= 7)
                        {
                           commonLog.LogEntry("set cssText is about to processing with GetProcessStyleSheetStringIntoCHtmlCollection() '{0}'  '{1}'", this, ___Text);
                        }
                        //___styleCHtmlCollection = commonGetProcessStyleSheetStringIntoCHtmlCollection(___Text);
                        attributeList = commonHTML.GetProcessStyleSheetStringIntoCHtmlCollection(___Text);
                        if (___styleCHtmlCollection == null)
                        {
                            ___styleCHtmlCollection = new CHtmlCollection();
                        }
                        ___styleCHtmlCollection.AddRange(attributeList);
                    }
                    else
                    {
                        ___IsCSssTextContainsTitle = true;
                        if (commonLog.LoggingEnabled &&commonLog.CommonLogLevel >= 7)
                        {
                           commonLog.LogEntry("set cssText is about to processing with CreateCSSRuleCollectionFromStyleSheetString() '{0}'  '{1}'", this, ___Text);
                        }
                        ___styleCHtmlCollection = commonHTML.CreateCSSRuleCollectionFromStyleSheetString(___Text, this.___getPossibleBaseURLString());
                    }
                    if (___styleCHtmlCollection != null && ___styleCHtmlCollection.Count > 0)
                    {
                        if (___IsCSssTextContainsTitle == false && this.___IsOwnerElementAssigned() == true)
                        {
                            string ___baseUrl = null;
                            CHtmlElement ___owner = this.ownerElement;
                            if (___owner != null && ___owner.___documentWeakRef != null)
                            {
                                if (string.IsNullOrEmpty(___owner.___getDocument().___URL) == false)
                                {
                                    ___baseUrl = string.Copy(___owner.___getDocument().___URL);
                                    goto SetPhase1;
                                }
                            }
                            if (this.___StyleType == CHtmlElementStyleType.Element && ___owner != null && ___owner.___locationBase != null)
                            {
                                ___baseUrl = string.Copy(___owner.___locationBase.href);
                            }
                        SetPhase1:

                            commonHTML.SetValuesInCHtmlStyleElement(this, null, attributeList, false, ___baseUrl);
                            if (this.___StyleType == CHtmlElementStyleType.Element && ___owner != null && ___owner.___documentWeakRef != null && ___owner.___isApplyElemenetStyleSheetCalled == true)
                            {
                                ___owner.___getDocument().___applyElemenetStyleSheets(___owner, false, true, false);
                            }
                            if (commonLog.LoggingEnabled &&commonLog.CommonLogLevel >= 7)
                            {
                               commonLog.LogEntry("style for '{0}' cssText '{1}' completed {2} items {3}", ___owner, ___Text, ___styleCHtmlCollection.Count, __stopWatch);
                            }
                            ___IsStyleMerged = true;
                        }
                        else
                        {
                            if (___IsCSssTextContainsTitle == true && this.___IsDocumentAssigned() == true)
                            {
                                CHtmlDocument ___Document = this.___documentWeakReference.Target as CHtmlDocument;
                                if (___Document != null && ___Document.___Disposing == false && ___Document.___documentDomType == CHtmlDomModeType.HTMLDOM)
                                {
                                    this.___MergeCHtmlStyleElementListIntoDocument(___styleCHtmlCollection, ___Document);
                                    ___IsStyleMerged = true;
                                    if (commonLog.LoggingEnabled &&commonLog.CommonLogLevel >= 7)
                                    {
                                       commonLog.LogEntry("set cssText  merged to document '{0}' items: {1} {2}", this, ___styleCHtmlCollection.Count, __stopWatch);
                                    }

                                }
                                else
                                {
                                    CHtmlElement ___owner = this.ownerElement;
                                    if (___owner != null && ___owner.___Document != null && ___owner.___Document.___documentDomType == CHtmlDomModeType.HTMLDOM && ___owner.___Document.___Disposing == false)
                                    {
                                        this.___MergeCHtmlStyleElementListIntoDocument(___styleCHtmlCollection, ___owner.___Document);
                                        ___IsStyleMerged = true;
                                    }

                                    if (commonLog.LoggingEnabled &&commonLog.CommonLogLevel >= 7)
                                    {
                                       commonLog.LogEntry("set cssText is about to merge dynamic style, bot document referece not found, do it latter on. '{0}' items: {1}", this, ___styleCHtmlCollection.Count);
                                       commonLog.LogEntry("=== Set CssText Analysis ===");
                                       commonLog.LogEntry("IsDynamicStyle : {0}", this.___IsDynamicElement);
                                       commonLog.LogEntry("ownerElement   : {0}", ___owner);
                                        if (___owner != null)
                                        {
                                           commonLog.LogEntry("ownerElement Dynamic: {0}", ___owner.___IsDynamicElement);
                                           commonLog.LogEntry("ownerElement CalcBounds: {0}", ___owner.___isCalculateElementBoundsCalled);
                                        }

                                       commonLog.LogEntry("==========================");
                                    }
                                }
                            }
                            else
                            {
                                if (commonLog.LoggingEnabled &&commonLog.CommonLogLevel >= 7)
                                {
                                   commonLog.LogEntry("set cssText is about to merge dynamic style, but no title keys '{0}' items: {1}", this, ___styleCHtmlCollection.Count);
                                }

                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                if (commonLog.LoggingEnabled &&commonLog.CommonLogLevel >= 8)
                {
                   commonLog.LogEntry("cssTextInner: " + ___Text, ex);
                }
            }
            if (___IsStyleMerged == true)
            {
                if (___styleCHtmlCollection != null)
                {

                    ___styleCHtmlCollection = null;
                }
            }
        }

        internal void ___MergeCHtmlStyleElementListIntoDocument(CHtmlCollection arStyleLists, CHtmlDocument ___targetDocument)
        {
            if (___targetDocument == null || arStyleLists == null)
            {
                return;
            }
            if (___targetDocument.___Disposing)
            {
                return;
            }
            int arStyleListsCount = arStyleLists.Count;
            for (int i = 0; i < arStyleListsCount; i++)
            {
                CHtmlCSSRule ___sPart = arStyleLists[i] as CHtmlCSSRule;
                if (___sPart == null)
                    continue;

                if (___sPart.___ruleType  == CHtmlCSSRule.CSSRuleType.Import_Rule && string.IsNullOrEmpty(___sPart.___baseUrl) == false)
                {
                    /*
                    bool __IsEnqueued = ___targetDocument.___downloadviaQueue(___sPart.___baseUrl, "StyleSheet", null, null, null, ___targetDocument.___charset, Unicus.CHtmlThreadPoolQueueObjectType.UrlStyleSheet, ___sPart.___baseUrl, null, 0, CHtmlUrlSourceType.Unknown, false);
                    */
                    bool __IsEnqueued = false;
                    if (__IsEnqueued)
                    {
                        /*
                        System.Threading.Interlocked.Increment(ref this.StyleSheetOnlyFileDownloadPendingCount);
										
                        System.Threading.Interlocked.Increment(ref this.StyleScriptFileDownloadRequestedTotalCount);
                        */
                    }
                    continue;
                }
                if (___sPart.___NonSearchableStyleSheet == true)
                {
                    continue;
                }
                ___targetDocument.___mergeCHtmlStyleElementIntoDocumentStyleSheet(___sPart);
            }
        }



        #endregion

        public object this[object ___nameObject]
        {
            get
            {
                string ___name = commonHTML.GetStringValue(___nameObject);
                if (commonLog.LoggingEnabled &&commonLog.CommonLogLevel >= 10)
                {
                   commonLog.LogEntry("CHtmlCSSStyleSheet {0} this['{1}'] getter", this, ___name);
                }
                try
                {
                    return this.___getPropertyByName(___name);
                }
                catch
                {

                }
                //commonLog.LogEntry("CHtmlSortedList this[{0}] failed", s);
                return "";

            }
            set
            {
                string ___name = commonHTML.GetStringValue(___nameObject);
                if (commonLog.LoggingEnabled &&commonLog.CommonLogLevel >= 10)
                {
                   commonLog.LogEntry("CHtmlCSSStyleSheet {0} this['{1}'] = '{2}' setter", this, ___name, value);
                }
                try
                {
                    this.___setPropertyByName(___name, value);
                }
                catch { }
            }
        }
        #region IPropertBox �����o

        /// <summary>
        /// IE Spacific addRule Function
        /// </summary>
        /// <param name="strSelector"></param>
        /// <param name="strStyle"></param>
        /// <param name="objInsertPos">always returns -1</param>
        /// <returns></returns>
        public double addRule(string strSelector, string strStyle, object objInsertPos)
        {
            //new_rule = document.styleSheets[0].addRule("div strong", "color:blue", 0);
            if (commonLog.LoggingEnabled &&commonLog.CommonLogLevel >= 10)
            {

               commonLog.LogEntry("calling {0}.addRule({0}, {1}, {2})", this, strSelector, strStyle, objInsertPos);

            }
            System.Text.StringBuilder sbNewStyle = new System.Text.StringBuilder(100);
            sbNewStyle.Append(strSelector);
            sbNewStyle.Append(" {");
            sbNewStyle.Append(strStyle);
            sbNewStyle.Append('}');
            this.cssTextSetter(sbNewStyle.ToString());
            return -1;
        }
        public double addRule(string strSelector, string strStyle)
        {
            // new_rule = document.styleSheets[0].addRule("div strong", "color:blue", 0);
            if (commonLog.LoggingEnabled &&commonLog.CommonLogLevel >= 10)
            {

               commonLog.LogEntry("calling {0}.addRule({0}, {1})", this, strSelector, strStyle);

            }
            System.Text.StringBuilder sbNewStyle = new System.Text.StringBuilder(100);
            sbNewStyle.Append(strSelector);
            sbNewStyle.Append(" {");
            sbNewStyle.Append(strStyle);
            sbNewStyle.Append('}');
            this.cssTextSetter(sbNewStyle.ToString());
            return -1;
        }
        /// <summary>
        /// will be called as myStyle.insertRule("#blanc { color: white }", 0);
        /// </summary>
        /// <param name="strSelectorandStyle"></param>
        /// <param name="objInsertPos"></param>
        /// <returns></returns>
        public double insertRule(string strSelectorandStyle, object objInsertPos)
        {
            if (commonLog.LoggingEnabled &&commonLog.CommonLogLevel >= 10)
            {

               commonLog.LogEntry("calling {0}.insertRule({0}, {1})", this,strSelectorandStyle ,objInsertPos);

            }
            this.cssTextSetter(strSelectorandStyle);
            return 0;
        }
        public double insertRule(string strSelectorandStyle)
        {
            if (commonLog.LoggingEnabled &&commonLog.CommonLogLevel >= 10)
            {

               commonLog.LogEntry("calling {0}.insertRule({0})", this, strSelectorandStyle);

            }
            this.cssTextSetter(strSelectorandStyle);
            return 0;
        }


        public object ___getPropertyByName(string ___name)
        {
            string ___nameLow = null;
            if (___name != null)
            {
                ___nameLow = commonHTML.FasterTrimAndToLower(___name);
            }
            if (commonLog.LoggingEnabled &&commonLog.CommonLogLevel >= 10)
            {
                if (this.___IsOwnerElementAssigned() == true)
                {
                   commonLog.LogEntry("StyleGet: {0} {1}", this.ownerElement, ___name);
                }
                else
                {
                   commonLog.LogEntry("StyleGet: {0} {1}", "", ___name);
                }
            }
            switch (___nameLow)
            {
                case "insertrule":
                case "addrule":
                    return MultiversalUniqueTag.UniqueType.Undefined;
                case "__nosuchmethod__":
                    return MultiversalUniqueTag.UniqueType.Undefined;
                case "nodeType":
                case "nodetype":
                    return this.___nodeTypeDummy;
                case "pointerevents":
                    return ___convertNullToEmpty(this.___PointerEvents);
                case "content":
                    return ___convertNullToEmpty(this.___Content);
                case "outlineoffset":
                case "outline-offset":
                    return ___convertNullToEmpty(this.___OutlineOffset);
                case "marginafter":
                    return ___convertNullToEmpty(this.___MarginAfter);
                case "marginbefore":
                    return ___convertNullToEmpty(this.___MarginBefore);
                case "overflowy":
                case "overflow-y":
                    return ___convertNullToEmpty(this.___OverFlowY);
                case "overflowx":
                case "overflow-x":
                    return ___convertNullToEmpty(this.___OverFlowX);
                case "interpolationmode":
                case "interpolationMode":
                case "InterpolationMode":
                case "msInterpolationMode":
                case "mozInterpolationMode":
                case "webkitInterpolationMode":
                    return ___convertNullToEmpty(this.___InterpolationMode);
                case "perspective":
                case "msPerspective":
                case "msperspective":
                case "webkitPerspective":
                case "webkitperspective":
                case "WebkitPerspective":
                case "Perspective":
                case "mozPerspective":
                case "mozperspective":
                    return ___convertNullToEmpty(this.___Perspective);
                case "perspectiveorigin":
                    return ___convertNullToEmpty(this.___PerspectiveOrigin);
                case "box-directon":
                case "boxdirecton":
                    return ___convertNullToEmpty(this.___BoxDirection);
                case "boxflex":
                case "box-flex":
                    return ___convertNullToEmpty(this.___BoxFlex);
                case "counter-increment":
                case "counterincrement":
                    return ___convertNullToEmpty(this.___CounterIncrement);
                case "counter-reset":
                case "counterreset":
                    return ___convertNullToEmpty(this.___CounterReset);
                case "backface-visibility":
                case "backfacevisibility":
                    return ___convertNullToEmpty(this.___BackfaceVisibility);
                case "layoutgridline":
                case "layout-grid-line":
                    return ___convertNullToEmpty(this.___LayoutGridLine);
                case "borderbottom":
                case "backgroundbottom":
                    return ___convertNullToEmpty(this.___BorderBottom);
                case "borderleft":
                case "backgroundleft":
                    return ___convertNullToEmpty(this.___BorderLeft);
                case "borderright":
                case "backgroundright":
                    return ___convertNullToEmpty(this.___BorderRight);
                case "bordertop":
                case "backgroundtop":
                    return ___convertNullToEmpty(this.___BorderTop);
                case "imagerendering":
                case "image-rendering":
                    return ___convertNullToEmpty(this.___ImageRendering);
                case "ieonlywidth":
                    return ___convertNullToEmpty(this.___IEOnlyWidth);
                case "transformorigin":
                    return ___convertNullToEmpty(this.___TransformOrigin);

                case "textindex":
                    return ___convertNullToEmpty(this.___TextIndex);
                case "content-zooming":
                case "contentzooming":
                case "-ms-content-zooming":
                case "-khtml-content-zooming":
                case "-webkit-content-zooming":
                case "-moz-content-zooming":
                case "-o-content-zooming":
                    return ___convertNullToEmpty(this.___contentZooming);

                case "overflowwrap":
                case "overflow-wrap":
                    return ___convertNullToEmpty(this.___OverFlowWrap);
                case "overflow-scrolling":
                case "overflowscrolling":
                    return ___convertNullToEmpty(this.___OverFlowScrolling);
                case "animationduration":
                case "animation-duration":
                    return ___convertNullToEmpty(this.___animationduration);
                case "stopcolor":
                case "stop-color":
                    return ___convertNullToEmpty(this.___StopColor);
                case "speak":
                    return ___convertNullToEmpty(this.___Speak);
                case "touch-callout":
                case "touchcallout":
                    return ___convertNullToEmpty(this.___TouchCallout);
                case "touch-action":
                case "touchaction":
                case "-moz-touch-action":
                case "-webkit-touch-action":
                case "-o-touch-action":
                case "-ms-touch-action":
                case "-khtml-touch-action":
                case "ms-touch-action":
                case "khtml-touch-action":
                case "moz-touch-action":
                case "webkit-touch-action":
                    return ___convertNullToEmpty(this.___TouchAction);
                case "userselect":
                case "mozuserselect":
                case "WebKitUserselect":
                case "webkitUserSelect":
                case "webkituserselect":
                case "khtmluserselect":
                case "-khtml-user-select":
                case "user-select":
                case "-ms-user-select":
                case "-o-user-select":
                case "-webkit-user-select":
                case "-moz-user-select":
                    return ___convertNullToEmpty(this.___UserSelect);
                case "bordercolor":
                    return ___convertNullToEmpty(this.___BorderColor);
                case "letterspacing":
                    return ___convertNullToEmpty(this.___LetterSpacing);
                case "textalign":
                    return ___convertNullToEmpty(this.___TextAlign);
                case "color":
                    return ___convertNullToEmpty(this.___Color);
                case "liststyle":
                    return ___convertNullToEmpty(this.___ListStyle);
                case "liststyleimage":
                    return ___convertNullToEmpty(this.___ListStyleImage);
                case "liststyletype":
                    return ___convertNullToEmpty(this.___ListStyleType);
                case "liststyleposition":
                    return ___convertNullToEmpty(this.___ListStylePosition);
                case "cursor":
                    return ___convertNullToEmpty(this.___Cursor);
                case "lineheight":
                    return ___convertNullToEmpty(this.___LineHeight);
                case "lineclamp":
                    return ___convertNullToEmpty(this.___LineClamp);
                case "linebreak":
                    return ___convertNullToEmpty(this.___LineBreak);
                case "transitionduration":
                    return ___convertNullToEmpty(this.___TransitionDuration);
                case "transitiondelay":
                    return ___convertNullToEmpty(this.___TransitionDelay);
                case "backgroundclip":
                    return ___convertNullToEmpty(this.___BackgroundClip);
                case "transitionproperty":
                case "webkittransitionproperty":
                case "moztransitionproperty":
                case "mstransitionproperty":
                case "khtmltransitionproperty":
                    return ___convertNullToEmpty(this.___TransitionProperty);
                case "direction":
                    return ___convertNullToEmpty(this.___Direction);
                case "outline":
                    return ___convertNullToEmpty(this.___Outline);
                case "borderwidth":
                    return ___convertNullToEmpty(this.___BorderWidth);
                case "selectortext":
                    return ___convertNullToEmpty(this.___SelectorID);
                case "csstext":
                    return this.cssTextGetter();
                case "background":
                case "xbackground":
                    return ___convertNullToEmpty(this.___Background);
                case "fullscreen":
                case "full-screen":
                case "mozfullscreen":
                case "msfullscreen":
                case "ofullscreen":
                case "webkitfullscreen":
                case "-webkit-full-screen":
                    return ___convertNullToEmpty(this.___fullscreen);
                case "backgroundcolor":
                    return ___convertNullToEmpty(this.___BackgroundColor);
                case "backgroundimage":
                    return ___convertNullToEmpty(this.___BackgroundImage);
                case "width":
                    return ___convertNullToEmpty(this.___Width);
                case "height":
                    return ___convertNullToEmpty(this.___Height);
                case "top":
                    return ___convertNullToEmpty(this.___Top);
                case "right":
                    return ___convertNullToEmpty(this.___Right);
                case "bottom":
                    return ___convertNullToEmpty(this.___Bottom);
                case "left":
                    return ___convertNullToEmpty(this.___Left);
                case "display":
                    return ___convertNullToEmpty(this.___Display);
                case "float":
                case "cssfloat":
                case "stylefloat":
                    return ___convertNullToEmpty(this.___cssFloat);
                case "visible":
                case "visibility":
                    return ___convertNullToEmpty(this.___Visibility);
                case "highcontrastadjust":
                    return ___convertNullToEmpty(this.___highContrastAdjust);
                case "opacity":
                case "mozopacity":
                case "khtmlopacity":
                case "webkitopacity":
                    return ___convertNullToEmpty(this.___Opacity);
                case "flex-flow":
                case "flexflow":
                    return ___convertNullToEmpty(this.___flexFlow);
                case "text-justification":
                case "textjustification":
                    return ___convertNullToEmpty(this.___TextJustification);
                case "align-content":
                case "aligncontent":
                    return ___convertNullToEmpty(this.___alignContent);
                case "boxreflect":
                    return ___convertNullToEmpty(this.___BoxReflect);
                case "columncount":
                    return ___convertNullToEmpty(this.___ColumnCount);
                case "animationname":
                case "mozanimationname":
                case "webkitanimationname":
                    return ___convertNullToEmpty(this.___animationName);
                case "flexWrap":
                case "flexwrap":
                case "webkitflexwrap":
                    return ___convertNullToEmpty(this.___flexWrap);
                case "animationdelay":
                case "animation-delay":
                case "mozanimationdelay":
                case "webkitanimationdelay":
                    return ___convertNullToEmpty(this.___animationDelay);
                case "animationplaystate":
                case "msanimationplaystate":
                case "mozanimationplaystate":
                case "oanimationplaystate":
                case "webkitanimationplaystate":
                    return ___convertNullToEmpty(this.___animationPlayState);
                case "rotate":
                case "mozrotate":
                case "webkitrotate":
                case "orotate":
                case "msrotate":
                    return ___convertNullToEmpty(this.___rotate);
                case "type":
                    return ___convertNullToEmpty(this.@type);
                case "media":
                    return ___convertNullToEmpty(this.___media);
                case "href":
                    return ___convertNullToEmpty(this.___baseUrl);
                case "title":
                    return this.title;
                case "disabled":
                    return this.___disabled;
                case "zindex":
                case "z-index":
                    return ___convertNullToEmpty(this.___zIndex);
                case "orphans":
                    return ___convertNullToEmpty(this.___Orphans);
                case "pagebreakinside":
                    return ___convertNullToEmpty(this.___PageBreakInside);
                case "widows":
                    return ___convertNullToEmpty(this.___Widows);
                case "mozcolumnwidth":
                case "columnwidth":
                    return ___convertNullToEmpty(this.___ColumnWidth);
                case "moztextemphasisStyle":
                    return ___convertNullToEmpty(this.___TextEmphasisStyle);
                case "textshadow":
                    return ___convertNullToEmpty(this.___TextShadow);
                case "animation":
                    return ___convertNullToEmpty(this.___Animation);
                case "position":
                    return ___convertNullToEmpty(this.___Position);
                case "margin":
                    return ___convertNullToEmpty(this.___Margin);
                case "marginleft":
                    return ___convertNullToEmpty(this.___MarginLeft);
                case "marginright":
                    return ___convertNullToEmpty(this.___MarginRight);
                case "margintop":
                    return ___convertNullToEmpty(this.___MarginTop);
                case "marginbottom":
                    return ___convertNullToEmpty(this.___MarginBottom);
                case "font":
                    return ___convertNullToEmpty(this.___Font);
                case "fontweight":
                case "font-weight":
                    return ___convertNullToEmpty(this.___FontWeight);
                case "fontfamily":
                case "font-family":
                    return ___convertNullToEmpty(this.___FontFamily);
                case "fontvariant":
                    return ___convertNullToEmpty(this.___FontVariant);
                case "fontsize":
                case "font-size":
                    return ___convertNullToEmpty(this.___FontSize);
                case "fontstyle":
                case "font-style":
                    return ___convertNullToEmpty(this.___FontStyle);
                case "fontstretch":
                case "font-stretch":
                    return ___convertNullToEmpty(this.___FontStretch);
                case "fontsmoothing":
                case "font-smoothing":
                    return ___convertNullToEmpty(this.___FontSmoothing);
                case "zoom":
                    return ___convertNullToEmpty(this.___Zoom);
                case "overflow":
                    return ___convertNullToEmpty(this.___OverFlow);
                case "whitespace":
                    return ___convertNullToEmpty(this.___WhiteSpace);
                case "padding":
                    return ___convertNullToEmpty(this.___Padding);
                case "paddingleft":
                case "padding-left":
                    return ___convertNullToEmpty(this.___PaddingLeft);
                case "paddingtop":
                case "padding-top":
                    return ___convertNullToEmpty(this.___PaddingTop);
                case "paddingright":
                case "padding-right":
                    return ___convertNullToEmpty(this.___PaddingRight);
                case "behavior":
                    return ___convertNullToEmpty(this.___Behavior);

                case "backgroundsize":
                    return ___convertNullToEmpty(this.___BackgroundSize);
                case "boxshadow":
                case "box-shadow":
                    return ___convertNullToEmpty(this.___BoxShadow);
                case "boxshadowboxshadow":
                case "box-shadow-boxshadow":
                    return ___convertNullToEmpty(this.___BoxShadowBoxShadow);
                case "boxsizing":
                    return ___convertNullToEmpty(this.___BoxSizing);
                case "borderimage":
                    return ___convertNullToEmpty(this.___BorderImage);
                case "borderradius":
                case "ieborderradius":
                case "khtmlborderradius":
                case "radius":
                    return ___convertNullToEmpty(this.___BorderRadius);
                case "transform":
                case "transformproperty":
                case "webkittransform":
                case "moztransform":
                case "mstransform":
                case "otransform":
                    return ___convertNullToEmpty(this.___Transform);
                case "transition":
                case "webkittransition":
                case "moztransition":
                case "mstransition":
                case "khtmltransition":
                case "webkit-transition":
                case "moz-transition":
                case "ms-transition":
                case "khtm-ltransition":
                    return ___convertNullToEmpty(this.___Transition);
                case "border":
                    return ___convertNullToEmpty(this.___Border);
                case "filter":
                    return this.___Filter;
                case "bordertopwidth":
                case "border-top-width":
                    return ___convertNullToEmpty(this.___BorderTopWidth);
                case "borderleftwidth":
                case "borderl-eft-width":
                    return ___convertNullToEmpty(this.___BorderLeftWidth);
                case "borderrightwidth":
                case "border-right-width":
                    return ___convertNullToEmpty(this.___BorderRightWidth);
                case "borderbottomwidth":
                case "border-bottom-width":
                    return ___convertNullToEmpty(this.___BorderBottomWidth);
                case "bordercollapse":
                case "border-collapse":
                    return ___convertNullToEmpty(this.___BorderCollapse);
                case "borderleftstyle":
                    return ___convertNullToEmpty(this.___BorderLeftStyle);
                case "paddingbottom":
                case "padding-bottom":
                    return ___convertNullToEmpty(this.___PaddingBottom);
                case "maxheight":
                    return ___convertNullToEmpty(this.___MaxHeight);
                case "minheight":
                    return ___convertNullToEmpty(this.___MinHeight);
                case "maxwidth":
                    return ___convertNullToEmpty(this.___MaxWidth);
                case "minwidth":
                    return ___convertNullToEmpty(this.___MinWidth);
                case "textdecoration":
                    return ___convertNullToEmpty(this.___TextDecoration);
                case "textindent":
                    return ___convertNullToEmpty(this.___TextIndent);
                case "textjustify":
                    return ___convertNullToEmpty(this.___TextJustify);
                case "texttransform":
                    return ___convertNullToEmpty(this.___TextTransform);
                case "textrendering":
                    return ___convertNullToEmpty(this.___TextRendering);
                case "textoverflow":
                    return ___convertNullToEmpty(this.___TextOverFlow);
                case "boxdirection":
                    return ___convertNullToEmpty(this.___BoxDirection);
                case "appearance":
                case "mozappearance":
                case "webkitappearance":
                case "oappearance":
                    return this.___Appearance;
                case "tap-highlight-color":
                case "taphighlightcolor":
                case "-webkit-tap-highlight-color":
                case "-ms-tap-highlight-color":
                case "-khtml-tap-highlight-color":
                    return this.___tapHighlightColor;
                case "__iterator__":
                    //return commonHTML.rhinoForLoopEnumratorFunction;
                    return null;

                default:

                    break;
            }
            if (commonLog.LoggingEnabled &&commonLog.CommonLogLevel >= 8)
            {
               commonLog.LogEntry("TODO: GetPropertyValue for {0} {1} '{2}'", this.GetType(), this, ___name);
            }
            return ""; // style property access always returns "" if not found.
        }
       
        public void ___setPropertyByName(string ___name, object val)
        {
            try
            {
                string lowName = null;
                if (___name != null)
                {
                    lowName = commonHTML.FasterTrimAndToLower(___name);
                }

                if (lowName.Length > 7 && lowName[0] == '-')
                {
                    if (lowName.StartsWith("-webkit-", StringComparison.OrdinalIgnoreCase))
                    {
                        lowName = lowName.Substring(8);
                    }
                }
                if (commonLog.LoggingEnabled &&commonLog.CommonLogLevel >= 10)
                {
                    if (this.___IsOwnerElementAssigned() == true)
                    {
                       commonLog.LogEntry("StyleSet: {0} {1} = \'{2}\'", this.ownerElement, ___name, val);
                    }
                    else
                    {
                       commonLog.LogEntry("StyleSet: {0} {1} = \'{2}\'", "", ___name, val);
                    }
                }
                string styleValue = commonHTML.GetStringValue(val);
                if (string.IsNullOrEmpty(styleValue) == false)
                {
                    char c0 = styleValue[0];
                    char ce0 = styleValue[styleValue.Length - 1];
                    if (commonHTML.FasterIsWhiteSpaceLimited(c0) == true || commonHTML.FasterIsWhiteSpaceLimited(ce0) == true)
                    {
                        styleValue = styleValue.Trim();
                        c0 = styleValue[0];
                        ce0 = styleValue[styleValue.Length - 1];
                    }
                    if ((c0 > 'A' && c0 < 'Z') || (ce0 > 'A' && ce0 < 'Z'))
                    {
                        if (commonHTML.StyleElementFieldsCaseSensitveSortedList.ContainsKey(lowName) == false)
                        {
                            styleValue = commonHTML.FasterToLower(styleValue);
                        }
                    }
                }
                switch (lowName)
                {
                    case "flexwrap":
                        this.___flexWrap = styleValue;
                        return;
                    case "direction":
                        this.___Direction = styleValue;
                        return;
                    case "pointerevents":
                        this.___PointerEvents = styleValue;
                        return;
                    case "content":
                        this.___Content = styleValue;
                        return;
                    case "boxdirection":
                        this.___BoxDirection = styleValue;
                        return;
                    case "orphans":
                        this.___Orphans = styleValue;
                        return;
                    case "pagebreakinside":
                        this.___PageBreakInside = styleValue;
                        return;
                    case "perspective":
                    case "msPerspective":
                    case "webkitPerspective":
                    case "WebkitPerspective":
                    case "Perspective":
                    case "mozPerspective":
                        this.___Perspective = styleValue;
                        return;
                    case "interpolationmode":
                    case "interpolationMode":
                    case "InterpolationMode":
                    case "msInterpolationMode":
                    case "msinterpolationmode":
                    case "mozInterpolationMode":
                    case "webkitInterpolationMode":
                        this.___InterpolationMode = styleValue;
                        return;
                    case "perspectiveorigin":
                        this.___PerspectiveOrigin = styleValue;
                        return;
                    case "backface-visibility":
                    case "backfacevisibility":
                        this.___BackfaceVisibility = styleValue;
                        return;
                    case "touch-action":
                    case "touchaction":
                    case "-moz-touch-action":
                    case "-webkit-touch-action":
                    case "-o-touch-action":
                    case "-ms-touch-action":
                    case "-khtml-touch-action":
                    case "ms-touch-action":
                    case "khtml-touch-action":
                    case "moz-touch-action":
                    case "webkit-touch-action":
                        this.___TouchAction = styleValue;
                        return;
                    case "touch-callout":
                    case "touchcallout":
                    case "-moz-touch-callout":
                    case "-webkit-touch-callout":
                    case "-o-touch-callout":
                    case "-ms-touch-callout":
                    case "-khtml-touch-callout":
                        this.___TouchCallout = styleValue;
                        return;


                    case "transformorigin":
                    case "transform-origin":
                        this.___TransformOrigin = styleValue;
                        return;
                    case "layoutgridline":
                        this.___LayoutGridLine = styleValue;
                        return;
                    case "imagerendering":
                    case "image-rendering":
                        this.___ImageRendering = styleValue;
                        return;
                    case "ieonlywidth":
                        this.___IEOnlyWidth = styleValue;
                        return;
                    case "textindex":
                        this.___TextIndex = styleValue;
                        return;
                    case "overflowwrap":
                    case "overflow-wrap":
                        this.___OverFlowWrap = styleValue;
                        return;
                    case "overflowscrolling":
                        this.___OverFlowScrolling = styleValue;
                        return;
                    case "animationduration":
                    case "animation-duration":
                        this.___animationduration = styleValue;
                        return;
                    case "stopcolor":
                    case "stop-color":
                        this.___StopColor = styleValue;
                        return;
                    case "speak":
                        this.___Speak = styleValue;
                        return;
                    case "userelect":
                    case "mozuserselect":
                    case "webkituserselect":
                    case "webkitUserSelect":
                    case "ouserselect":
                    case "msuserselect":
                    case "khtmluserselect":
                    case "user-select":
                    case "-ms-user-select":
                    case "-o-user-select":
                    case "-webkit-user-select":
                    case "-khtml-user-select":
                    case "-moz-user-select":
                        this.___UserSelect = styleValue;
                        return;
                    case "bordercolor":
                        this.___BorderColor = styleValue;
                        return;
                    case "letterspacing":
                        this.___LetterSpacing = styleValue;
                        return;
                    case "clear":
                        this.Clear = styleValue;
                        return;
                    case "textdecoration":
                        this.___TextDecoration = styleValue;
                        return;
                    case "tap-highlight-color":
                    case "taphighlightcolor":
                    case "-webkit-tap-highlight-color":
                    case "-ms-tap-highlight-color":
                    case "-khtml-tap-highlight-color":
                        this.___tapHighlightColor = styleValue;
                        return;
                    case "fullscreen":
                    case "full-screen":
                    case "mozfullscreen":
                    case "msfullscreen":
                    case "ofullscreen":
                    case "webkitfullscreen":
                    case "-webkit-full-screen":
                        this.___fullscreen = styleValue;
                        return;
                    case "textindent":
                        this.TextIndent = styleValue;
                        return;
                    case "textjustify":
                        this.___TextJustify = styleValue;
                        return;
                    case "texttransform":
                        this.___TextTransform = styleValue;
                        return;
                    case "textrendering":
                        this.___TextRendering = styleValue;
                        return;
                    case "textoverflow":
                        this.___TextOverFlow = styleValue;
                        return;
                    case "appearance":
                    case "mozappearance":
                    case "webkitappearance":
                        this.___Appearance = styleValue;
                        return;

                    case "minheight":
                        this.___MinHeight = styleValue;
                        return;
                    case "bottom":
                        this.___Bottom = styleValue;
                        return;
                    case "backgroundclip":
                        this.___BackgroundClip = styleValue;
                        return;
                    case "liststyletype":
                        this.___ListStyleType = styleValue;
                        return;
                    case "liststyle":
                        this.___ListStyle = styleValue;
                        return;
                    case "liststyleimage":
                    case "list-style-image":
                        this.___ListStyleImage = styleValue;
                        return;
                    case "backgroundimage":
                    case "background-image":
                        if (string.Equals(this.___BackgroundImage, styleValue, StringComparison.Ordinal) == false)
                        {
                            this.___BackgroundImage = styleValue;
                            if (this.___StyleType == CHtmlElementStyleType.Element)
                            {
                                this.___checkBackgroundImageStringForElement();
                            }
                        }
                        return;
                    case "backgroundrepeat":
                    case "background-repeat":
                        this.___BackgroundRepeat = styleValue;
                        return;
                    case "backgroundattachment":
                    case "background-attachment":
                        this.___BackgroundAttachment = styleValue;
                        return;
                    case "backgroundposition":
                    case "background-position":
                        this.___BackgroundPosition = styleValue;
                        return;
                    case "backgroundpositionx":
                        this.___BackgroundPositionX = styleValue;
                        return;
                    case "backgroundpositiony":
                        this.___BackgroundPositionY = styleValue;
                        return;
                    case "backgrounclip":
                        this.___BackgroundClip = styleValue;
                        return;
                    case "cursor":
                        this.___Cursor = styleValue;
                        return;
                    case "lineheight":
                        this.___LineHeight = styleValue;
                        return;
                    case "lineclamp":
                        this.___LineClamp = styleValue;
                        return;
                    case "linebreak":
                        this.___LineBreak = styleValue;
                        return;
                    case "backcgroundclip":
                        this.___BackgroundClip = styleValue;
                        return;
                    case "verticalalign":
                    case "verticalalignment":
                    case "valign":
                        this.___VerticalAlign = styleValue;
                        return;
                    case "transitionproperty":
                        this.___TransitionProperty = styleValue;
                        return;
                    case "transitionduration":
                        this.___TransitionDuration = styleValue;
                        return;
                    case "transitiondelay":
                        this.___TransitionDelay = styleValue;
                        return;
                    case "maxwidth":
                        this.___MaxWidth = styleValue;
                        return;
                    case "right":
                        this.___Right = styleValue;
                        return;
                    case "outline":
                        this.___Outline = styleValue;
                        return;
                    case "csstext":
                        this.cssTextSetter(commonHTML.GetStringValue(val));
                        return;
                    case "cssfloat":
                    case "float":
                    case "stylefloat":
                        this.cssFloat = styleValue;
                        return;
                    case "left":
                        this.___Left = styleValue;
                        return;
                    case "height":
                        this.___Height = styleValue;
                        return;
                    case "width":
                        this.___Width = styleValue;
                        return;
                    case "transition":
                    case "webkittransition":
                    case "moztransition":
                    case "ottransition":
                    case "msttransition":
                        this.___Transition = styleValue;
                        return;
                    case "color":
                    case "fontcolor":
                    case "foregroundcolor":
                    case "foreground-color":
                        this.Color = styleValue;  // Must use property
                        return;
                    case "backgroundcolor":
                    case "background-color":
                        this.backgroundColor = styleValue; // Must use property
                        return;
                    case "background":
                    case "xbackground":
                        if (string.Equals(this.___Background, styleValue, StringComparison.Ordinal) == false)
                        {
                            this.___Background = styleValue;
                            if (this.___StyleType == CHtmlElementStyleType.Element)
                            {
                                ___checkBackgroundStringForElement();
                            }
                        }
                        else
                        {

                        }
                        return;
                    case "display":
                        this.Display = styleValue;
                        return;
                    case "textshadow":
                        this.___TextShadow = styleValue;
                        return;
                    case "animation":
                        this.___Animation = styleValue;
                        return;
                    case "overflow":
                        this.___OverFlow = styleValue;
                        return;
                    case "z-index":
                    case "zindex":
                        this.zIndex = styleValue;
                        return;
                    case "position":
                        this.___Position = styleValue;
                        return;
                    case "top":
                        this.___Top = styleValue;
                        return;
                    case "margin":
                        this.___Margin = styleValue;
                        return;
                    case "marginleft":
                        this.___MarginLeft = styleValue;
                        return;
                    case "marginright":
                        this.___MarginRight = styleValue;
                        return;
                    case "margintop":
                        this.___MarginTop = styleValue;
                        return;
                    case "marginbottom":
                        this.___MarginBottom = styleValue;
                        return;
                    case "font":
                        this.Font = styleValue;
                        return;
                    case "fontweignt":
                        this.FontWeight = styleValue;
                        return;
                    case "fontstyle":
                        this.FontStyle = styleValue;
                        return;
                    case "fontvariant":
                        this.FontVariant = styleValue;
                        return;
                    case "fontstretch":
                        this.___FontStretch = styleValue;
                        return;
                    case "fontsize":
                        this.FontSize = styleValue;
                        return;
                    case "fontsmoothing":
                        this.FontSmoothing = styleValue;
                        return;
                    case "zoom":
                        this.___Zoom = styleValue;
                        return;
                    case "whitespace":
                    case "white-space":
                        this.WhiteSpace = styleValue;
                        return;
                    case "padding":
                        this.___Padding = styleValue;
                        return;
                    case "paddingtop":
                    case "padding-top":
                        this.___PaddingTop = styleValue;
                        return;
                    case "paddingleft":
                    case "padding-left":
                        this.___PaddingLeft = styleValue;
                        return;
                    case "paddingright":
                    case "padding-right":
                        this.___PaddingRight = styleValue;
                        return;
                    case "paddingbottom":
                    case "padding-bottom":
                        this.___PaddingBottom = styleValue;
                        return;
                    case "paddingstart":
                        this.___PaddingStart = styleValue;
                        return;
                    case "borderstyle":
                    case "border-style":
                        this.___BorderStyle = styleValue;
                        return;
                    case "borderwidth":
                    case "border-width":
                        this.___BorderWidth = styleValue;
                        return;
                    case "bordertopwidth":
                        this.___BorderTopWidth = styleValue;
                        return;
                    case "borderleftwidth":
                        this.___BorderLeftWidth = styleValue;
                        return;
                    case "borderrightwidth":
                        this.___BorderRightWidth = styleValue;
                        return;
                    case "borderright":
                        this.___BorderRight = styleValue;
                        return;
                    case "borderbottomwidth":
                        this.___BorderBottomWidth = styleValue;
                        return;
                    case "behavior":
                        this.___Behavior = styleValue;
                        return;
                    case "visibility":
                        this.visibility = styleValue;
                        return;
                    case "backgroundsize":
                    case "background-size":
                        this.___BackgroundSize = styleValue;
                        return;
                    case "borderimage":
                        this.___BorderImage = styleValue;
                        return;
                    case "borderradius":
                    case "khtmlborderradius":
                    case "radius":
                        this.___BorderRadius = styleValue;
                        return;
                    case "boxshadow":
                        this.___BoxShadow = styleValue;
                        return;
                    case "boxshadowboxshadow":
                    case "box-shadowbox-shadow":
                        this.___BoxShadowBoxShadow = styleValue;
                        return;
                    case "boxsizing":
                        this.___BoxShadow = styleValue;
                        return;
                    case "transform":
                    case "transformproperty":
                    case "webkittransform":
                    case "moztransform":
                    case "mstransform":
                    case "otransform":
                        this.___Transform = styleValue;
                        return;
                    case "fontweight":
                        this.___FontWeight = styleValue;
                        return;
                    case "border":
                        this.___Border = styleValue;
                        return;
                    case "filter":
                        this.___Filter = styleValue;
                        return;
                    case "opacity":
                    case "khtmlopacity":
                    case "mozopacity":
                        this.___Opacity = styleValue;
                        this.___ParseOpacity();
                        return;
                    case "text-justification":
                    case "textjustification":
                        this.___TextJustification = styleValue;
                        return;
                    case "columncount":
                        this.___ColumnCount = styleValue;
                        return;
                    case "boxreflect":
                        this.___BoxReflect = styleValue;
                        return;
                    case "animationname":
                    case "mozanimationname":
                        this.___animationName = styleValue;
                        return;
                    case "animationdelay":
                    case "animation-delay":
                    case "mozanimationdelay":
                    case "webkitanimationdelay":
                        this.___animationDelay = styleValue;
                        return;
                    case "animationplaystate":
                    case "msanimationplaystate":
                    case "mozanimationplaystate":
                    case "oanimationplaystate":
                    case "webkitanimationplaystate":
                        this.___animationPlayState = styleValue;
                        return;
                    case "rotate":
                    case "mozrotate":
                    case "webkitrotate":
                    case "orotate":
                    case "msrotate":
                        this.___rotate = styleValue;
                        return;
                    case "overflow-style":
                    case "overflowstyle":
                        this.___OverFlowStyle = styleValue;
                        return;
                    case "outlineoffset":
                    case "outline-offset":
                        this.___OutlineOffset = styleValue;
                        return;
                    case "bordercollapse":
                        this.___BorderCollapse = styleValue;
                        return;
                    case "textalign":
                        this.___TextAlign = styleValue;
                        return;
                    case "maxheight":
                        this.___MaxHeight = styleValue;
                        return;
                    case "minwidth":
                        this.___MinWidth = styleValue;
                        return;
                    case "fontfamily":
                        this.___FontFamily = styleValue;
                        return;
                    case "overflowy":
                    case "overflow-y":
                        this.___OverFlowY = styleValue;
                        return;
                    case "text-stroke":
                    case "textstroke":
                    case "textStroke":
                        this.___TextStroke = styleValue;
                        return;
                    case "flex-flow":
                    case "flexflow":
                        this.___flexFlow = styleValue;
                        return;
                    case "flex-order":
                    case "order":
                        this.___flexOrder = styleValue;
                        return;
                    case "align-content":
                    case "aligncontent":
                        this.___alignContent = styleValue;
                        return;
                    case "flex-line-pack":
                    case "flexlinepack":
                        this.___flexLinePack = styleValue;
                        return;
                    case "content-zooming":
                    case "contentzooming":
                    case "-ms-content-zooming":
                    case "-khtml-content-zooming":
                    case "-webkit-content-zooming":
                    case "-moz-content-zooming":
                    case "-o-content-zooming":
                        this.___contentZooming = styleValue;
                        return;

                }

            }
            catch (Exception ex)
            {
                if (commonLog.LoggingEnabled &&commonLog.CommonLogLevel >= 7)
                {
                   commonLog.LogEntry("CHtmlCSSStyleSheet Set Value Failed for {0} {1} = {2} failed : {3}", this, ___name, val, ex.Message);
                }
            }
            if (commonLog.LoggingEnabled &&commonLog.CommonLogLevel >= 7)
            {
               commonLog.LogEntry("[Style Skip] SetPropertyValue Value Failed for {0} {1} = {2} failed. May be Not defined.", this, ___name, val);
            }
        }
        public void ___setPropertyByIndex(int ___index, object val)
        {
            if (commonLog.LoggingEnabled &&commonLog.CommonLogLevel >= 8)
            {
               commonLog.LogEntry("SetPropertyValueIndex for {0} {1}  {2} = {3} failed", this.GetType(), this, ___index, val);
            }
        }

        public object ___getPropertyByIndex(int ___index)
        {
            if (commonLog.LoggingEnabled &&commonLog.CommonLogLevel >= 8)
            {
               commonLog.LogEntry("___getPropertyByName by index {0} {1} {2} failed", this.GetType(), this, ___index);
            }
            return null;
        }

        public bool ___hasPropertyByName(string ___name)
        {

            if (___name.Length > 5)
            {
                // ------------------------------------------------------------
                // Only string change for following prefix.
                // ------------------------------------------------------------
                // -webkit-
                // webkit
                // moz 
                // 
                if (___name[0] == '-')
                {
                    if (___name.StartsWith("-webkit-", StringComparison.Ordinal) == true)
                    {
                        ___name = ___name.Substring(8);
                    }
                }
                else
                {
                    if (___name[0] == 'w')
                    {
                        if (___name.StartsWith("webkit", StringComparison.Ordinal) == true)
                        {
                            ___name = ___name.Substring(6);
                            goto SearchSection;
                        }
                    }
                    else if (___name[0] == 'm' || ___name[0] == 'M')
                    {
                        if (___name.StartsWith("moz", StringComparison.Ordinal) == true)
                        {
                            ___name = ___name.Substring(3);
                            goto SearchSection;
                        }
                    }
                }
            }
        SearchSection:
            bool ___HasResult = false;
            if (___name.IndexOf('-') > -1)
            {
                ___name = ___name.Replace("-", "");
            }

            if (commonLog.LoggingEnabled &&commonLog.CommonLogLevel >= 10)
            {
               commonLog.LogEntry("{0}.hasProperty(\'{1}\') = {2}", this, ___name, ___HasResult);
            }
            return ___HasResult;

        }
        public bool ___hasPropertyByIndex(int ___index)
        {
            return true;
        }
        public object ___common_object_clone()
        {
            if (commonLog.LoggingEnabled &&commonLog.CommonLogLevel >= 10)
            {
               commonLog.LogEntry("x__Clone {0} {1} called", this.GetType(), this);
            }
            return this;
        }
        public void ___deleteByIndex(int ___index)
        {
            if (commonLog.LoggingEnabled &&commonLog.CommonLogLevel >= 10)
            {
               commonLog.LogEntry("___deleteByIndex {0} {1} called : {2}", this.GetType(), this, ___index);
            }
        }
        public void ___deleteByName(string ___name)
        {
            if (commonLog.LoggingEnabled &&commonLog.CommonLogLevel >= 10)
            {
               commonLog.LogEntry("___deleteByName {0} {1} called : {2}", this.GetType(), this, ___name);
            }

        }
        public object[] ___getByIds()
        {
            if (commonLog.LoggingEnabled &&commonLog.CommonLogLevel >= 10)
            {
               commonLog.LogEntry("___getByIds() {0} {1} called", this.GetType(), this);
            }
            return null;

        }

        public string ___getClassName()
        {
            if (commonLog.LoggingEnabled &&commonLog.CommonLogLevel >= 10)
            {
               commonLog.LogEntry("___getClassName {0} {1} called", this.GetType(), this);
            }
            return this.GetType().Name;
        }
        public object ___getDefaultValue()
        {
            if (commonLog.LoggingEnabled &&commonLog.CommonLogLevel >= 10)
            {
               commonLog.LogEntry("___getDefaultValue {0} {1} called", this.GetType(), this);
            }
            return null;
        }
        public object ___getParentScope()
        {
            if (commonLog.LoggingEnabled &&commonLog.CommonLogLevel >= 10)
            {
               commonLog.LogEntry("___getParentScope {0} {1} called", this.GetType(), this);
            }
            return null;
        }
        public void ___setParentScope(object ___object)
        {
            if (commonLog.LoggingEnabled &&commonLog.CommonLogLevel >= 10)
            {
               commonLog.LogEntry("___setParentScope {0} {1} called : {2}", this.GetType(), this, ___object);
            }
        }
        public object ___getProtoType()
        {
            if (commonLog.LoggingEnabled &&commonLog.CommonLogLevel >= 10)
            {
               commonLog.LogEntry("___getProtoType {0} {1} called", this.GetType(), this);
            }
            return null;
        }
        public bool ___hasInstance(object ___object)
        {
            if (commonLog.LoggingEnabled &&commonLog.CommonLogLevel >= 10)
            {
               commonLog.LogEntry("___hasInstance {0} {1} called : {2}", this.GetType(), this, ___object);
            }
            return false;
        }
        public bool ___instanceEquals(object ___object)
        {
            if (commonLog.LoggingEnabled &&commonLog.CommonLogLevel >= 10)
            {
               commonLog.LogEntry("___instanceEquals {0} {1} called : {2}", this.GetType(), this, ___object);
            }
            return object.ReferenceEquals(this, ___object);
        }
        public void ___setProtoType(object ___object)
        {
            if (commonLog.LoggingEnabled &&commonLog.CommonLogLevel >= 10)
            {
               commonLog.LogEntry("___setProtoType {0} {1} called : {2}", this.GetType(), this, ___object);
            }
        }

        #endregion
        internal void ___copyStyleElementFields(CHtmlCSSStyleSheet tS, bool SkipForNonInheritance, bool AsParentChildRelationShip)
        {
            if (tS == null)
                return;

            if (!SkipForNonInheritance)
            {
                tS.___Left = this.___Left;
                tS.___Width = this.___Width;
                tS.___Height = this.___Height;
                tS.___Left = this.___Left;
                tS.___Top = this.___Top;
                tS.___Right = this.___Right;
                tS.___MinHeight = this.___MinHeight;
                tS.___MinWidth = this.___MinWidth;
            }
            if (!SkipForNonInheritance)
            {
                //tS.StyleComment = this.StyleComment;
            }

            if (string.IsNullOrEmpty(this.___baseUrl) == false)
            {
                tS.___baseUrl = string.Copy(this.___baseUrl);
            }
            if (this.___AHrefBase != null)
            {
                tS.___AHrefBase = this.___AHrefBase.CloneUri();
            }
            //tS.BackgroundColor		= this.BackgroundColor;
            if (!SkipForNonInheritance)
            {
                tS.___Align = this.___Align;
                if (AsParentChildRelationShip == false)
                {
                    tS.___Background = this.___Background;
                }
                if (AsParentChildRelationShip == false)
                {
                    tS.___BackgroundAttachment = this.___BackgroundAttachment;
                }
                if (this.___IsBackgroundColorSpecified == true)
                {
                    tS.___BackgroundColor = this.___BackgroundColor;
                    tS.___IsBackgroundColorSpecified = this.___IsBackgroundColorSpecified;
                    tS.___BackgroundSysColor = this.___BackgroundSysColor;
                }
                if (AsParentChildRelationShip == false)
                {
                    tS.___BackgroundImage = this.___BackgroundImage;
                    tS.___BackgroundOrigin = this.___BackgroundOrigin;
                    tS.___BackgroundSize = this.___BackgroundSize;
                    tS.___BackgroundPositionX = this.___BackgroundPositionX;
                    tS.___BackgroundPositionY = this.___BackgroundPositionY;

                }
                if (string.IsNullOrEmpty(this.___BackgroundRepeat) == false)
                {
                    tS.___BackgroundRepeat = string.Copy(this.___BackgroundRepeat);
                }
                tS.___BackgroundInlinePolicy = this.___BackgroundInlinePolicy;
                tS.___BackgroundClip = this.___BackgroundClip;
                tS.___BackgroundPosition = this.___BackgroundPosition;



                tS.___Behavior = this.___Behavior;
                tS.___Border = this.___Border;
                tS.___BorderBottom = this.___BorderBottom;
                tS.___BorderTop = this.___BorderTop;
                tS.___BorderTopColor = this.___BorderTopColor;
                tS.___BorderTopStyle = this.___BorderTopStyle;
                tS.___BorderTopWidth = this.___BorderTopWidth;
                tS.___BorderBottomColor = this.___BorderBottomColor;
                tS.___BorderBottomStyle = this.___BorderBottomStyle;
                tS.___BorderBottomWidth = this.___BorderBottomWidth;
                tS.___BorderCollapse = this.___BorderCollapse;
                tS.___BorderColor = this.___BorderColor;
                tS.___BorderLeft = this.___BorderLeft;
                tS.___BorderLeftColor = this.___BorderLeftColor;
                tS.___BorderLeftStyle = this.___BorderLeftStyle;
                tS.___BorderLeftWidth = this.___BorderLeftWidth;
                tS.___BorderWidth = this.___BorderWidth;
                tS.___BorderRight = this.___BorderRight;
                tS.___BorderRightColor = this.___BorderRightColor;
                tS.___BorderRightStyle = this.___BorderRightStyle;
                tS.___BorderRightWidth = this.___BorderRightWidth;
            }

            if (!SkipForNonInheritance)
            {
                tS.___CellPadding = this.___CellPadding;
                tS.___CellSpacing = this.___CellSpacing;
                tS.___Cursor = this.___Cursor;
                tS.___Content = this.___Content;
            }

            if (this.___StyleType != CHtmlElementStyleType.None)
            {
                if (string.IsNullOrEmpty(this.___Color) == false)
                {
                    tS.___Color = this.___Color;
                    tS.___IsForegroundSysColorSpecified = this.___IsForegroundSysColorSpecified;
                    tS.___ForegroundSysColor = this.___ForegroundSysColor;
                }
                if (string.IsNullOrEmpty(this.___Filter) == false)
                {
                    tS.___Filter = this.___Filter;
                }
                if (string.IsNullOrEmpty(this.___Font) == false)
                {
                    tS.___Font = this.___Font;
                }
                //tS.FontColor			= this.FontColor;
                if (string.IsNullOrEmpty(this.___FontSize) == false)
                {
                    tS.___FontSize = this.___FontSize;
                }
                if (string.IsNullOrEmpty(this.___FontFamily) == false)
                {
                    tS.___FontFamily = this.___FontFamily;
                }
                if (string.IsNullOrEmpty(this.___FontSizeAdjust) == false)
                {
                    tS.___FontSizeAdjust = this.___FontSizeAdjust;
                }
                if (string.IsNullOrEmpty(this.___FontStyle) == false)
                {
                    tS.___FontStyle = this.___FontStyle;
                    tS.___FontStyleComputedValueType = this.___FontStyleComputedValueType;
                }
                if (string.IsNullOrEmpty(this.___FontVariant) == false)
                {
                    tS.___FontVariant = this.___FontVariant;
                }
                if (string.IsNullOrEmpty(this.___FontWeight) == false)
                {
                    tS.___FontWeight = this.___FontWeight;
                    tS.___FontWeightComputedValueType = this.___FontWeightComputedValueType;
                }
                if (string.IsNullOrEmpty(this.___LineHeight) == false)
                {
                    tS.___LineHeight = this.___LineHeight;
                }
                if (string.IsNullOrEmpty(this.___LetterSpacing) == false)
                {
                    tS.___LetterSpacing = this.___LetterSpacing;
                }

                if (!SkipForNonInheritance)
                {
                    if (string.IsNullOrEmpty(this.___ListStyle) == false)
                    {
                        tS.___ListStyle = this.___ListStyle;
                    }
                    if (string.IsNullOrEmpty(this.___ListStyleType) == false)
                    {
                        tS.___ListStyleType = this.___ListStyleType;
                    }
                    if (string.IsNullOrEmpty(this.___ListStyleImage) == false)
                    {
                        tS.___ListStyleImage = this.___ListStyleImage;
                    }

                    if (string.IsNullOrEmpty(this.___ListStylePosition) == false)
                    {
                        tS.___ListStylePosition = this.___ListStylePosition;
                    }
                }
                if (string.IsNullOrEmpty(this.___TextIndent) == false)
                {
                    tS.___TextIndent = this.___TextIndent;
                    tS.___TextIndentComputedValue = this.___TextIndentComputedValue;
                }
                if (string.IsNullOrEmpty(this.___TextOverFlow) == false)
                {
                    tS.___TextOverFlow = this.___TextOverFlow;
                }
                if (string.IsNullOrEmpty(this.___TextShadow) == false)
                {
                    tS.___TextShadow = this.___TextShadow;
                }
                if (string.IsNullOrEmpty(this.___TextTransform) == false)
                {
                    tS.___TextTransform = this.___TextTransform;
                }
                if (string.IsNullOrEmpty(this.___TextUnderLine) == false)
                {
                    tS.___TextUnderLine = this.___TextUnderLine;
                }
                if (string.IsNullOrEmpty(this.___LetterSpacing) == false)
                {
                    tS.___LetterSpacing = this.___LetterSpacing;
                }
                if (string.IsNullOrEmpty(this.___WhiteSpace) == false)
                {
                    tS.___WhiteSpace = this.___WhiteSpace;
                    tS.___whiteSpaceComputedValue = this.___whiteSpaceComputedValue;
                }
                if (string.IsNullOrEmpty(this.___WordWrap) == false)
                {
                    tS.___WordWrap = this.___WordWrap;
                }
                if (this.___AHrefBase != null && string.IsNullOrEmpty(___AHrefBase.___Href) == false)
                {
                    tS.___AHrefBase = this.___AHrefBase.CloneUri();
                }


                if (!SkipForNonInheritance)
                {
                    tS.___Clear = this.___Clear;
                    tS.___cssClearType = this.___cssClearType;
                    tS.___cssFloat = this.___cssFloat;
                    tS.___cssFloatType = this.___cssFloatType;
                    if (string.IsNullOrEmpty(this.___Display) == false)
                    {
                        if (tS.___StyleType == CHtmlElementStyleType.Element && this.___StyleType == CHtmlElementStyleType.Element)
                        {
                            tS.___Display = string.Copy(this.___Display);
                            tS.___cssDisplayComputedValueType = this.___cssDisplayComputedValueType;
                        }
                    }

                    tS.___LineBreak = this.___LineBreak;

                    tS.___Margin = this.___Margin;
                    tS.___MarginBottom = this.___MarginBottom;
                    tS.___MarginLeft = this.___MarginLeft;
                    tS.___MarginRight = this.___MarginRight;
                    tS.___MarginTop = this.___MarginTop;
                    tS.___OverFlow = this.___OverFlow;
                    tS.___OverFlowX = this.___OverFlowX;
                    tS.___OverFlowY = this.___OverFlowY;

                    tS.___OverFlowFromParent = this.___OverFlowFromParent;
                    tS.___OverFlowFromParentHeight = this.___OverFlowFromParentHeight;
                    tS.___OverFlowFromParentWidth = this.___OverFlowFromParentWidth;
                    tS.___OverFlowElementStart = this.___OverFlowElementStart;

                    tS.___Opacity = this.___Opacity;
                    tS.___OpacityPasedValue = this.___OpacityPasedValue;
                    tS.___Outline = this.___Outline;
                    tS.___Padding = this.___Padding;
                    tS.___PaddingBottom = this.___PaddingBottom;
                    tS.___PaddingLeft = this.___PaddingLeft;
                    tS.___PaddingRight = this.___PaddingRight;
                    tS.___PaddingTop = this.___PaddingTop;
                    tS.___Page = this.___Page;
                    tS.___PageBreakAfter = this.___PageBreakAfter;
                    tS.___Position = this.___Position;
                    tS.___TabStops = this.___TabStops;
                    tS.___TextAlign = this.___TextAlign;
                    tS.___TextJustification = this.___TextJustification;
                    tS.___TextDecoration = this.___TextDecoration;
                    tS.___TextDecorationComputedValueType = this.___TextDecorationComputedValueType;
                    tS.___VerticalAlign = this.___VerticalAlign;
                    if (string.IsNullOrEmpty(this.___Visibility) == false)
                    {
                        tS.___Visibility = this.___Visibility;
                        tS.___cssVisibilityComputedValueType = this.___cssVisibilityComputedValueType;
                    }
                    tS.___VoiceFamily = this.___VoiceFamily;
                    tS.___VerticalAlign = this.___VerticalAlign;
                    tS.___WordBreak = this.___WordBreak;
                    tS.___WordSpacing = this.___WordSpacing;
                    tS.___zIndex = this.___zIndex;
                    tS.___Zoom = this.___Zoom;
                    tS.___Transition = this.___Transition;
                    tS.___InterpolationMode = this.___InterpolationMode;
                    tS.___TextRendering = this.___TextRendering;
                    tS.___BoxShadow = this.___BoxShadow;
                    if (string.IsNullOrEmpty(this.___fullscreen) == false)
                    {
                        tS.___fullscreen = string.Copy(this.___fullscreen);
                    }
                    if (string.IsNullOrEmpty(this.___animationPlayState) == false)
                    {
                        tS.___animationPlayState = string.Copy(this.___animationPlayState);
                    }
                    if (string.IsNullOrEmpty(this.___rotate) == false)
                    {
                        tS.___rotate = string.Copy(this.___rotate);
                    }
                }
            }


        }


        /// <summary>
        /// Element.style type is CSSStyleDeclaration
        /// </summary>
        public IMutilversalObjectType multiversalClassType
        {
            get
            {
                return IMutilversalObjectType.CSSStyleDeclaration;
            }

        }
    }
}
