using System;
using System.Collections;

namespace MultiversalRenderer.Core
{
	/// <summary>
	/// CHtmlArrayKeyList Has Key SortedList
	/// </summary>
	public class CHtmlArrayKeyList : System.Collections.ArrayList
	{
		public SortedList KeyList = null;
		public CHtmlArrayKeyList()
		{
			// 
			// 
			//
			KeyList = new SortedList();
		}

	}
}
