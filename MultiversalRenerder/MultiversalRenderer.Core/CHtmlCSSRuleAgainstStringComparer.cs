using System;
using System.Collections;
using System.Text;

namespace MultiversalRenderer.Core
{
	/// <summary>
	/// CHtmlStyleElementKeyClassComparerer 
	/// </summary>
	
	public sealed class CHtmlWorkingCSSRuleAgainstStringComparer:  System.Collections.Generic.IComparer<CHtmlCSSRule>
	{
		//
		//public enum ICHtmlStyleElementCompareType{WorkingListTop=0, WorkingListEnd=1, OriginalListTop=10, OriginalListEnd=11}; 
		//
		//public ICHtmlStyleElementCompareType CompareType = ICHtmlStyleElementCompareType.OriginalListTop;
		#region IComparer �����o
		/*

		   0 ��菬�����l a �� b ��菬�����B 
		   0 a �� b �͓������B 
		   0 ���傫���l a �� b ���傫���B 
		   
		*/
   
        public int Compare(CHtmlCSSRule styleX, CHtmlCSSRule styleY)
        {
            try
            {

                return string.CompareOrdinal(styleX.___WorkingKey, styleY.___WorkingKey);
            }
            catch (Exception ex)
            {
                if (commonLog.LoggingEnabled)
                {
                   commonLog.LogEntry("CHtmlWorkingCSSRuleAgainstStringComparerabnormal error!", ex);
                }
                //CHtmlStyleKey yKey = null;
                if (styleX == null && styleY == null)
                {
                    return 0;
                }
                if (styleX == null)
                {
                    return -1;
                }
                if (styleY == null)
                {
                    return 1;
                }
                return string.CompareOrdinal(styleX.___WorkingKey, styleY.___WorkingKey);
            }

        }
        /*
		
		public int Compare(object x, object y)
		{
			string xKey = null;
			string yKey = null;
			if(x is CHtmlCSSStyleSheet)
			{
				CHtmlCSSStyleSheet styleX = x as CHtmlCSSStyleSheet;
				xKey = styleX.___WorkingKey;
			}
			else if(x is String)
			{
				xKey = x as string;
			}
			//CHtmlStyleKey xKey = null;
			CHtmlCSSStyleSheet styleY = null;
			if(y is CHtmlCSSStyleSheet)
			{
				styleY = y as CHtmlCSSStyleSheet;
				yKey = styleY.___WorkingKey;
			} 
			else if(y is string)
			{
				yKey = y as string;
			}
			//CHtmlStyleKey yKey = null;
			if(xKey == null && yKey == null)
			{
				return 0;
			}
			if(xKey == null)
			{
				return -1;
			}
			if(yKey == null)
			{
				return 1;
			}
			return string.CompareOrdinal(xKey, yKey);

		}
        */
        #endregion

    }


}