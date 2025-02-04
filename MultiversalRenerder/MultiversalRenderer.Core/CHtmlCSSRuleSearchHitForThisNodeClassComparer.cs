using System;
using System.Collections;
using System.Text;

namespace MultiversalRenderer.Core
{
	/// <summary>
	/// CHtmlStyleElementSearchHitForThisNodeKeyClassComparerer 
	/// </summary>
	public sealed class CHtmlCSSRuleSearchHitForThisNodeClassComparer : System.Collections.IComparer
	{
		#region IComparer �����o
		/*

		   0 ��菬�����l  : a �� b ��菬�����B 
		   0 a �� b �͓������B 
		   0 ���傫���l  :  a �� b ���傫���B 
		   
		*/
		/*
		 * After Sortring
		 * ~~~~~~~~~~~~~~
		 * [Hit]
		 * [*]  a
		 * [*]  div
		 * [*]  id.afdafd.
		 * [*]  dfare.reread
		 * [-]  p
		 * [-]  span.ssaa
		 * [-]  #areare 
		*/
		public int Compare(object x, object y)
		{
            CHtmlCSSRule styleX = x as CHtmlCSSRule;
            CHtmlCSSRule styleY = y as CHtmlCSSRule;
			if(styleX == null)
			{
				return -1;
			}
			if(styleY == null)
			{
				return 1;
			}
			int WorkingResult =  styleX.___styleKeyWorkingList.Count - styleY.___styleKeyWorkingList.Count;
			if(WorkingResult != 0)
			{
				return WorkingResult;
			}
			else
			{
				return styleX.SelectorID.Length - styleY.SelectorID.Length;
			}

		}
		#endregion
	}
}