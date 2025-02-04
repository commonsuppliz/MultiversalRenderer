using System;

namespace MultiversalRenderer.Core
{
	/// <summary>
	/// CHtmlCSSRuleWorkingKeyStringComparer 
	/// </summary>
	
	public sealed class CHtmlCSSRuleWorkingKeyStringComparer : System.Collections.IComparer, System.Collections.Generic.IComparer<CHtmlCSSRule>
	{
   
        public int Compare(CHtmlCSSRule styleX, CHtmlCSSRule styleY)
        {
            try
            {

                return string.Compare(styleX.___WorkingKey, styleY.___WorkingKey, StringComparison.OrdinalIgnoreCase);
            }
            catch (Exception ex)
            {
                if (commonLog.LoggingEnabled)
                {
                   commonLog.LogEntry("CHtmlCSSRuleWorkingKeyStringComparer abnormal error", ex);
                }
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
                return string.Compare(styleX.___WorkingKey, styleY.___WorkingKey, StringComparison.OrdinalIgnoreCase);
            }
        }

		#region IComparer �����o
		/*

			   0 ��菬�����l a �� b ��菬�����B 
			   0 a �� b �͓������B 
			   0 ���傫���l a �� b ���傫���B 
		   
			*/
		
		public int Compare(object x, object y)
		{
            CHtmlCSSRule styleX = x as CHtmlCSSRule;
            CHtmlCSSRule styleY = y as CHtmlCSSRule;
			
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

			return string.Compare(styleX.___WorkingKey, styleY.___WorkingKey, StringComparison.OrdinalIgnoreCase);

		}
		#endregion
	}
}

