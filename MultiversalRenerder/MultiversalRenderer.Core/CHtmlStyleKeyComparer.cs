using System;
using System.Collections;
using System.Text;

namespace MultiversalRenderer.Core
{
	/// <summary>
	/// CHtmlStyleElementKeyClassComparerer 
	/// </summary>
	public sealed class CHtmlStyleKeyComparer : System.Collections.IComparer, System.Collections.Generic.IComparer<CHtmlStyleKey>
	{
		#region IComparer �����o
		/*

		   0 ��菬�����l a �� b ��菬�����B 
		   0 a �� b �͓������B 
		   0 ���傫���l a �� b ���傫���B 
		   
		*/
        public int Compare(CHtmlStyleKey sKeyX, CHtmlStyleKey sKeyY)
        {
            if (sKeyX == null && sKeyY == null)
            {
                return 0;
            }
            if (sKeyX == null)
            {
                return -1;
            }
            if (sKeyY == null)
            {
                return 1;
            }
            return string.Compare(sKeyX.SortShortName, sKeyY.SortShortName, StringComparison.OrdinalIgnoreCase);

        }
		public int Compare(object x, object y)
		{
			CHtmlStyleKey  sKeyX = x as CHtmlStyleKey;
			CHtmlStyleKey  sKeyY = y as CHtmlStyleKey;
			if(sKeyX == null && sKeyY == null)
			{
				return 0;
			}
			if(sKeyX == null)
			{
				return -1;
			}
			if(sKeyY == null)
			{
				return 1;
			}
			return string.Compare(sKeyX.SortShortName, sKeyY.SortShortName,StringComparison.OrdinalIgnoreCase);
		}
		#endregion
	}
}
