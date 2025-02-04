using System;
using System.Collections;
using System.Text;

namespace MultiversalRenderer.Core
{
	/// <summary>
	/// CHtmlStyleElementKeyClassComparerer Just Looks GroundSortKey
	/// </summary>
	
    public sealed class CHtmlCSSRuleGroundKeyComparer : System.Collections.Generic.IComparer<CHtmlCSSRule>, System.Collections.IComparer 
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

            // ==============================================================================================
            // Key is Case Sensitive and this should be ok.
            // .Net 2.0 has problem on slow compare using OrdinalIgnoreCase which is fixed upon 4.5.
            // use Ordinal should be ok for most of scenario.
            // ==============================================================================================
            try
            {
                if (styleX == null && styleY == null)
                {
                    return 0;
                }
                if (styleX == null || styleX.___GroundSortKey == null)
                {
                    return -1;
                }
                if (styleY == null || styleY.___GroundSortKey == null)
                {
                    return 1;
                }
                return string.Compare(styleX.___GroundSortKey, styleY.___GroundSortKey, StringComparison.OrdinalIgnoreCase);
            }
            catch 
            {
                throw;
            }
        }
        
		
		public int Compare(object x, object y)
		{

            CHtmlCSSRule styleX = x as CHtmlCSSRule;
			//CHtmlStyleKey xKey = null;
            CHtmlCSSRule styleY = y as CHtmlCSSRule;
			//CHtmlStyleKey yKey = null;
			if(styleX == null && styleY == null)
			{
				return 0;
			}
			if(styleX == null)
			{
				return -1;
			}
			if(styleY == null)
			{
				return 1;
			}


            // ==============================================================================================
            // Key is Case Sensitive and this should be ok.
            // .Net 2.0 has problem on slow compare using OrdinalIgnoreCase which is fixed upon 4.5.
            // use Ordinal should be ok for most of scenario.
            // ==============================================================================================

			return string.Compare(styleX.___GroundSortKey, styleY.___GroundSortKey,StringComparison.OrdinalIgnoreCase );

		}
         
		#endregion
	}

    
    public sealed class CHtmlCSSRuleGroundKeyNonGenericComparer : System.Collections.IComparer
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


   
        public int Compare(object x, object y)
        {

            CHtmlCSSRule styleX = x as CHtmlCSSRule;
            //CHtmlStyleKey xKey = null;
            CHtmlCSSRule styleY = y as CHtmlCSSRule;
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


            // ==============================================================================================
            // Key is Case Sensitive and this should be ok.
            // .Net 2.0 has problem on slow compare using OrdinalIgnoreCase which is fixed upon 4.5.
            // use Ordinal should be ok for most of scenario.
            // ==============================================================================================

            return string.Compare(styleX.___GroundSortKey, styleY.___GroundSortKey, StringComparison.OrdinalIgnoreCase);

        }

        #endregion
    }
}