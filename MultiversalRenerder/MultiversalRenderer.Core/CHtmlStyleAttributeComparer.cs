using System;
using System.Collections;
using System.Text;

namespace MultiversalRenderer.Core
{
    /// <summary>
    /// CHtmlStyleElementKeyClassComparerer 
    /// </summary>
    public sealed class CHtmlStyleAttributeComparer : System.Collections.Generic.IComparer<CHtmlStyleAttribute?>
    {

        /*

               0 ��菬�����l a �� b ��菬�����B 
               0 a �� b �͓������B 
               0 ���傫���l a �� b ���傫���B 
		   
            */
        /*
		
		public int Compare(object x, object y)
		{
			if(x is CHtmlStyleAttribute && y is CHtmlStyleAttribute)
			{
				CHtmlStyleAttribute attrX = x as CHtmlStyleAttribute;
				CHtmlStyleAttribute attrY = y as CHtmlStyleAttribute;
				return string.CompareOrdinal(attrX.Name, attrY.Name);
			}
			string _nameX = null;
			string _nameY = null;

			if(x is string)
			{
				_nameX = x as string;
			}
			else if(x is CHtmlStyleAttribute)
			{
				CHtmlStyleAttribute attrX = x as CHtmlStyleAttribute;
					_nameX = attrX.Name;
			}
			else
			{
				return -1;

			}
			
			if(y is string)
			{
				_nameY = y as string;
			}
			else if(y is CHtmlStyleAttribute)
			{
				CHtmlStyleAttribute attrY = y as CHtmlStyleAttribute;
				_nameY = attrY.Name;
			}
			else
			{
				return 1;
			}
			return  string.Compare(_nameX  , _nameY, StringComparison.Ordinal);
		}
         */


        /*

               0 ��菬�����l a �� b ��菬�����B 
               0 a �� b �͓������B 
               0 ���傫���l a �� b ���傫���B 
		   
            */

   
        public int Compare(CHtmlStyleAttribute? x, CHtmlStyleAttribute? y)
        {
            if (x == null)
            {
                return -1;
            }
            if (y == null)
            {
                return 1;
            }
            CHtmlStyleAttribute attrX = x.Value;
            CHtmlStyleAttribute attrY = y.Value;
            return string.CompareOrdinal(attrX.Name, attrY.Name);
        }

    }
}