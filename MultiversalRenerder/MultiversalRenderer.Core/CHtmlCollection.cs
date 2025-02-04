using System;
using System.Collections;
using System.Runtime.InteropServices;
using MultiversalRenderer.Interfaces;

namespace MultiversalRenderer.Core
{
	/// <summary>
	/// CHtmlCHtmlCollection 
	/// </summary>
	[ComVisible(true)]
	
	public class CHtmlCollection : System.Collections.ArrayList, ICommonObjectInterface
	{
        internal IMutilversalObjectType ___multiversalClassType;
		public bool IsEnumByIndex = false;
		public event System.EventHandler ChildrenAdded= null;
		public bool IsSearchResult = false;
		/// <summary>
		/// Secret Property 
		/// </summary>
		private DateTime _Z_ClearTime;
		private System.WeakReference ___ownerDocumentWeakReference = null;
		internal CHtmlNode ___parentNode = null;
		internal  CHtmlHTMLCollectionType ___CollectionType = CHtmlHTMLCollectionType.Unknown;
		private string ___queryString = null;
		public System.Collections.Comparer ___DefaultComparer = null;
        private System.Collections.Generic.Dictionary<int, int> ___objectIDList = null;

        internal bool ___IsPrototype = false;

        internal System.Collections.Generic.Dictionary<string, object> ___properties;

        internal bool ___isCollectionMustUseTryEnterOnAddOrRemove = false;
        
        /// <summary>
        /// List of Type Typs Count in this Collection
        /// ___TagTypeCountList[(int)___elementTagType]
        /// </summary>
        internal System.Collections.Generic.Dictionary<int, int> ___TagTypeCountList = null;

        internal System.WeakReference ___prototypeWeakReference = null;
        internal readonly object ___collectionLockingObject = new object();
		

		public CHtmlCollection()
		{
            this.___multiversalClassType = IMutilversalObjectType.HTMLCollection;
			this.IsEnumByIndex = false;
			this._Z_ClearTime = DateTime.Now;
            this.___properties = new System.Collections.Generic.Dictionary<string, object>(StringComparer.Ordinal);
		}
		~CHtmlCollection()
		{
			this.CleanUp();
		}
        /// <summary>
        /// Retuns Constuctor Function of HTMLCollection
        /// it should be Protype function
        /// </summary>
        public object constructor
        {
            get
            {
                if (this.___IsPrototype == false)
                {
                    if (this.___prototypeWeakReference != null)
                    {
                        return this.___prototypeWeakReference.Target;
                    }
                }
                return null;
            }
          
        }
        
		public string toLogString()
		{
			return string.Format("CHtmlCollection {0} {1} = {2} items", this.___CollectionType, this.___queryString , this.Count);
		}
        public override string ToString()
        {
            return "[object " + this.___multiversalClassType.ToString() + "]";
        }

		private void CleanUp()
		{
            if (this.ChildrenAdded != null)
            {
                this.ChildrenAdded = null;
            }
            if (this.___properties != null)
            {
                this.___properties = null;
            }
            if (this.___objectIDList != null)
            {
                this.___objectIDList = null;
            }
            if (this.___ownerDocumentWeakReference != null)
            {
                this.___ownerDocumentWeakReference = null;
            }
			if(this.___parentNode != null)
			{
				this.___parentNode = null;
			}
          
	
            this.___TagTypeCountList = null;
		}
		public int length
		{
			get{return this.Count;}
		}

		/// <summary>
		/// DHTML tags funtionality support
		/// e.x. myDocumentElements=document.allinernal.tags("meta")
		/// </summary>
		/// <param name="otag"></param>
		/// <returns></returns>
		
		public  CHtmlCollection tags(object otag)
		{
            CHtmlCollection arResult = new CHtmlCollection();
            arResult.___CollectionType = CHtmlHTMLCollectionType.DocumentAllTagsList;
            if (commonLog.LoggingEnabled &commonLog.CommonLogLevel >= 10)
            {
               commonLog.LogEntry("calling CHtmlCollection {0}.tags({1})", this, otag);
            }

            string sTag = commonHTML.FasterToUpper(commonHTML.GetStringValue(otag));
            CHtmlElementType tagType = commonHTML.GetTagNameType(sTag);

            int allElementCount = base.Count;
            for (int i = 0; i < allElementCount; i++)
            {
                CHtmlElement objElement = base[i] as CHtmlElement;
                if (objElement != null)
                {

                    CHtmlElement element = objElement;
                    if (element == null || element.___parentWeakRef == null || element.___IsSystemHidden == true)
                    {
                        continue;
                    }
                    if (tagType != CHtmlElementType.UNKNOWN)
                    {
                        if (element.___elementTagType == tagType)
                        {
                            arResult.Add(element);
                            continue;
                        }
                    }
                    else
                    {
                        if (string.Equals(element.___tagName, sTag, StringComparison.Ordinal)== true)
                        {
                            arResult.Add(element);
                            continue;
                        }
                    }
                }

            }
            if (commonLog.LoggingEnabled &commonLog.CommonLogLevel >= 10)
            {
               commonLog.LogEntry("calling CHtmlCollection {0}.tags({1}) returns {2}...", this, otag, arResult.Count);
            }
			return arResult;
		}
		/*
		public object item(int i)
		{
			return this[i];
		}
		public object item(string s)
		{
			return this[s];
		}
		*/
		public new object this[int o]
		{
            get
            {
                if (o >= 0 && o < this.Count)
                {
                    return base[o];
                }
                else
                {
                    return null;
                }
            }
			set
			{

					base[o] = value;
				
			}
		}


	
		
		/// <summary>
		/// To support Append Child Support for List Element
		/// document.getElementById(id).appendChild(this.target)
		/// </summary>
		/// <param name="_obj"></param>
		/// <returns></returns>
		/*
		public CHtmlElement appendChild(object _obj)
		{
			if(this.Count > 0)
			{
				if(this[this.Count -1] is CHtmlElement)
				{
					commonLog.LogEntry("Calling appendChild From CHtmlCollection");
					return (( CHtmlElement)this[this.Count -1]).appendChild(_obj);
				}
				else
				{
					commonLog.LogEntry("List element is not CHtmlElement");
					return null;
				}
			}
			else
			{
				commonLog.LogEntry("appendChild Failed due to no list elements");
				return null;
			}

		}
		*/
		/// <summary>
		/// Non StanardMethod Returns object in n 
		/// </summary>
		/// <param name="i"></param>
		/// <returns></returns>
		public object __GetByIndex(int i)
		{
			try
			{
				return base[i];
			}
			catch{}
			return null;
		}
		public object item(string s)
		{
			if(commonLog.LoggingEnabled &commonLog.CommonLogLevel >= 5)
			{
				commonLog.LogEntry("TODO: CHtmlCollection trying seek item(string: ({0})", s);
			}

			return null;
		}

        public object item(int i)
        {
            if (commonLog.LoggingEnabled &commonLog.CommonLogLevel >= 10)
            {
               commonLog.LogEntry("CHtmlCollection trying item(int : ({0})", i);
            }

            try
            {

                    if (i >= 0 && i < this.Count)
                    {
                        return base[i];
                    }
                    else
                    {
                        goto EndReturn;

                    }
                
            }
            catch (Exception ex)
            {
                if (commonLog.LoggingEnabled &&commonLog.CommonLogLevel >= 8)
                {
                   commonLog.LogEntry("CHtmlCollection.item({0}) returns null {1}", i, ex.Message);

                }
                return null;
            }
        EndReturn:
            if (commonLog.LoggingEnabled &&commonLog.CommonLogLevel >= 8)
            {
               commonLog.LogEntry("CHtmlCollection.item({0}) returns null {1}", i);

            }
            return null;
        }

			
    
        public override int IndexOf(object ___value)
        {
            int ___objPos = -1;
            CHtmlElement ___targetSeach = commonData.convertObjectIntoCHtmlElement(___value);
            if (commonLog.LoggingEnabled &&commonLog.CommonLogLevel >= 10)
            {
               commonLog.LogEntry("calling {0}.IndexOf({1})", this, ___targetSeach);
            }
            if (___targetSeach != null)
            {
                if (___targetSeach != null && this.___objectIDList != null)
                {
                    if (commonLog.LoggingEnabled &&commonLog.CommonLogLevel >= 10)
                    {
                       commonLog.LogEntry("calling Performing faster object search IndexOf({1})", this, ___targetSeach);
                    }
                    int objHash = ___targetSeach.GetHashCode();

                    if (this.___objectIDList.TryGetValue(objHash, out ___objPos))
                    {
                        goto ReturnPhase;
                    }
                    else
                    {
                        goto ReturnPhase;
                    }
                }
                if (commonLog.LoggingEnabled &&commonLog.CommonLogLevel >= 10)
                {
                   commonLog.LogEntry("{0} Performing slow object search IndexOf({1})", this, ___targetSeach);
                }
                ___objPos =  base.IndexOf(___targetSeach);
            }
        ReturnPhase:
            if (commonLog.LoggingEnabled &&commonLog.CommonLogLevel >= 10)
            {
               commonLog.LogEntry("{0}.IndexOf({1}) Result : {2}", this, ___targetSeach, ___objPos);
            }
            return ___objPos;
        }
        public int IndexOf(object ___objSeach, bool __nowarning)
        {
            return base.IndexOf(___objSeach);
        }
        public override bool Contains(object ___item)
        {
            if (___item != null && this.___objectIDList != null)
            {
                if (this.___objectIDList.ContainsKey(___item.GetHashCode()) == true)
                {
                    return true;
                }
                else
                {
                    return false;
                }
                
            }
            if (commonLog.LoggingEnabled &&commonLog.CommonLogLevel >= 10)
            {
               commonLog.LogEntry("{0} Performing slow object search Contains({1})", this, ___item);
            }
            return base.Contains(___item);
        }
        public override void Insert(int index, object value)
        {

            base.Insert(index, value);
            if (value != null && this.___objectIDList != null)
            {
                this.___objectIDList[value.GetHashCode()] = index;
            }
            if (this.___CollectionType == CHtmlHTMLCollectionType.ElementChildNodes || this.___CollectionType == CHtmlHTMLCollectionType.ElementCSSQuickChildNodes)
            {
                if (this.___TagTypeCountList == null)
                {
                    this.___TagTypeCountList = new System.Collections.Generic.Dictionary<int, int>();
                }
                if ((value is CHtmlTextElement) == false)
                {
                    if (value is CHtmlElement)
                    {
                        CHtmlElement elemValue = value as CHtmlElement;
                        if (elemValue != null)
                        {
                            if (commonHTML.IsElemeneITextOrIDraw(elemValue) == false && elemValue.___isInactivativeElementNodeChild == false)
                            {
                                int tagTypeInt = (int)elemValue.___elementTagType;
                                int tagNthOfType = 0;
                                if (this.___TagTypeCountList.TryGetValue(tagTypeInt, out tagNthOfType) == false)
                                {
                                    this.___TagTypeCountList[tagTypeInt] = 1;
                                    tagNthOfType = 1;
                                }
                                else
                                {
                                    tagNthOfType++;
                                    this.___TagTypeCountList[tagTypeInt] = tagNthOfType;
                                }
                                elemValue.___ElementNthOfNameType = tagNthOfType;
                            }
                        }
                    }
                }
            }
        }

        
		public override int Add(object value)
		{

            int r = -1;
            if (___isCollectionMustUseTryEnterOnAddOrRemove == false)
            {
                 r = base.Add(value);
            }
            else
            {
                if(System.Threading.Monitor.TryEnter(this.___collectionLockingObject,100))
                {
                    r = base.Add(value);
                    System.Threading.Monitor.Exit(this.___collectionLockingObject);
                }
            }
            if (value != null && this.___objectIDList != null)
            {
                this.___objectIDList[value.GetHashCode()] = r;
            }
            if (this.___CollectionType == CHtmlHTMLCollectionType.ElementChildNodes || this.___CollectionType == CHtmlHTMLCollectionType.ElementCSSQuickChildNodes)
            {
                if (this.___TagTypeCountList == null)
                {
                    this.___TagTypeCountList = new System.Collections.Generic.Dictionary<int, int>();
                }
                CHtmlElement elemValue = value as CHtmlElement;
                if (elemValue != null)
                {
                    if ( elemValue.___isInactivativeElementNodeChild == false)
                    {
                        int tagTypeInt = (int)elemValue.___elementTagType;
                        int tagNthOfType;
                        if (this.___TagTypeCountList.TryGetValue(tagTypeInt, out tagNthOfType) == false)
                        {
                            this.___TagTypeCountList[tagTypeInt] = 1;
                            tagNthOfType = 1;
                        }
                        else
                        {
                            tagNthOfType++;
                            this.___TagTypeCountList[tagTypeInt] = tagNthOfType;
                        }
                        elemValue.___ElementNthOfNameType = tagNthOfType;
                    }
                }


            }
			try
			{
				if(this.ChildrenAdded != null)
				{
					this.ChildrenAdded(value, EventArgs.Empty);
				}
			}
			catch{}
			return r;
		}
        public override void RemoveAt(int index)
        {
            if (this.___objectIDList != null)
            {
                object ___object = base[index];
                if (___object != null)
                {
                    this.___objectIDList.Remove(___object.GetHashCode());
                }
            }
            if (___isCollectionMustUseTryEnterOnAddOrRemove == false)
            {
                base.RemoveAt(index);
            }
            else
            {
                if (System.Threading.Monitor.TryEnter(this.___collectionLockingObject, 100))
                {
                    base.RemoveAt(index);
                    System.Threading.Monitor.Exit(this.___collectionLockingObject);
                }
            }
        }
        public override void Remove(object obj)
        {
            bool ___IsObjectRemoveWithHashIndex = false;
            try
            {
                if (this.___objectIDList != null && obj != null)
                {
                    int ___objHash = obj.GetHashCode();
                    int objIndex = -1;
                    if (this.___objectIDList.TryGetValue(___objHash, out objIndex))
                    {
                        if (objIndex >= 0 && objIndex < base.Count)
                        {
                            if (___isCollectionMustUseTryEnterOnAddOrRemove == false)
                            {
                                base.RemoveAt(objIndex);
                            }
                            else
                            {
                                if (System.Threading.Monitor.TryEnter(this.___collectionLockingObject, 100))
                                {
                                    base.RemoveAt(objIndex);
                                    System.Threading.Monitor.Exit(this.___collectionLockingObject);
                                }
                            }
                            ___IsObjectRemoveWithHashIndex = true;
                        }

                    }
                    this.___objectIDList.Remove(___objHash);
                }
            }
            catch (Exception ex)
            {
                if (commonLog.LoggingEnabled &&commonLog.CommonLogLevel >= 10)
                {
                   commonLog.LogEntry("BUGBUG! CHtmlCollection Remove() Exception " + ex.Message);
                }
            }
            if (___IsObjectRemoveWithHashIndex == false)
            {
                base.Remove(obj);
            }
        }
        /// <summary>
        /// Create HashTable for this CHtmlCollection
        /// </summary>
        internal void ___createObjectIDTable()
        {
            if (this.___objectIDList == null)
            {
                this.___objectIDList = new System.Collections.Generic.Dictionary<int, int>();
            }
        }
        /// <summary>
        /// Checks if this list contains particular elemenent hash
        /// </summary>
        /// <param name="___elem"></param>
        /// <returns></returns>
        public bool ___containsObjectHash(int objecthash)
        {
            if (this.___objectIDList != null)
            {
                if(this.___objectIDList.ContainsKey(objecthash))
                {
                    return true;
                }
            }
            return false;
        }
		public override void Clear()
		{
			base.Clear ();
			this._Z_ClearTime = DateTime.Now;
		}
		/// <summary>
		/// Secret Property Item Clear Time
		/// </summary>
		internal DateTime Z_ClearTime
		{
			get
			{
				return this._Z_ClearTime;
			}
		}
		internal CHtmlDocument ownerDocument
		{
			set{this.___ownerDocumentWeakReference  =new WeakReference( value, false);}
			get{
                if (this.___ownerDocumentWeakReference != null)
                {
                   return this.___ownerDocumentWeakReference.Target as CHtmlDocument;
                }
                return null;
            }
		}
		public CHtmlNode parentNode
		{
            set { this.___parentNode = value; }
			get{return this.___parentNode;}
		}


		/*

		/// <summary>
		/// In order to Support For ... in Loop Jscript
		/// JavaScript should return index number for list
		/// not properties.
		/// ex. 
		/// Jscript
		/// ~~~~~~~
		/// for i in document.getElementsByTagName('a')
		/// {
		///     // i should be number. not properties
		/// }
		/// 
		/// </summary>
		private class IndexEnumerator : IEnumerator
		{
			private int position = -1;
			private CHtmlCollection _list = null;
			public IndexEnumerator(CHtmlCollection list)
			{
				this._list = list;

			}

			// Declare the MoveNext method required by IEnumerator:
			public bool MoveNext()
			{
				if (position < this._list.Count - 1)
				{
					position++;
					return true;
				}
				else
				{
					return false;
				}
			}

			// Declare the Reset method required by IEnumerator:
			public void Reset()
			{
				position = -1;
			}

			// Declare the Current property required by IEnumerator:
			public object Current
			{
				get
				{
					return position;
				}
			}
		}
		*/
   
        public bool hasOwnProperty(string _oname)
        {

            return false;
        }
        private object[] ToHtmlListArrayInner()
        {

            if (commonLog.LoggingEnabled &&commonLog.CommonLogLevel >= 7)
            {
               commonLog.LogEntry("Converting CHtmlCollection from {0} to to object[] ", this);
            }

            return base.ToArray();

        }

		public object[] toArray()
		{
			return this.ToHtmlListArrayInner();

		}
		public object[] ToDataArray()
		{
			return this.ToHtmlListArrayInner();
		}
		public object[] toDataArray()
		{
			return this.ToHtmlListArrayInner();
		}

		internal string QueryString
		{
			set{this.___queryString = value;}
			get{return this.___queryString;}
		}
		/// <summary>
		/// Returns Maximum Value from list
		/// </summary>
		/// <returns></returns>
		public float GetMaximumValueFromList()
		{
			float _max = 0;
			int ___thisCount = this.Count;
			for(int c = 0; c < ___thisCount; c ++)
			{
				object obj = base[c];
				if(obj != null)
				{
					if(obj is float)
					{
						_max = Math.Max(_max, (float)obj);
						continue;
					}
					else if(commonHTML.isClrNumeric (obj) == true)
					{
						_max = Math.Max(_max, (float)obj);
						continue;
					}
				}
			}
			return _max;
		}
        /// <summary>
        /// Search forEach Function Object from Prototype Weak Reference
        /// </summary>
        /// <returns></returns>
        public object ___getForEachFunctionFromPrototype()
        {
            object ___forEachFunctionObject = null;
            if (this.___properties.TryGetValue("forEach", out ___forEachFunctionObject))
            {
                return ___forEachFunctionObject;
            }
            if (this.___IsPrototype == false)
            {
                if (this.___prototypeWeakReference != null)
                {
                    CHtmlCollection ___prototypeCollection = this.___prototypeWeakReference.Target as CHtmlCollection;
                    if (___prototypeCollection != null)
                    {
                        if (___prototypeCollection.___properties.TryGetValue("forEach", out ___forEachFunctionObject))
                        {
                            return ___forEachFunctionObject;
                        }
                    }
                }
            }
            return ___forEachFunctionObject;
        }

		#region IPropertBox �����o

		public object ___getPropertyByName(string ___name)
		{
            if (commonLog.LoggingEnabled &&commonLog.CommonLogLevel >= 10)
            {
               commonLog.LogEntry("entering {0}.___getPropertyByName({1})", this, ___name);
            }
			switch(___name)
			{
                case "constructor":
                    return this.constructor;
                case "nodeType":
                case "window":
                    // some scripts access nodeType but it normally not defined
                    return null;
				case "length":
				case "count":
                case "Count":
                    
                    
                        return base.Count; // returns as int
                    
                case "forEach":
                       return this.___getForEachFunctionFromPrototype();
                case "__iterator__":
                       return commonHTML.rhinoForLoopEnumratorFunction;
				default:
					break;
			}
            if (this.___CollectionType == CHtmlHTMLCollectionType.ElementChildNodes)
            {
                try
                {
                    int ___thisCount = this.Count;
                    for (int i = 0; i < ___thisCount; i++)
                    {
                        CHtmlElement element = this[i] as CHtmlElement;
                        if (element != null)
                        {


                            if (string.IsNullOrEmpty(element.___idLowSimple) == false && string.Equals(element.___idLowSimple, ___name, StringComparison.Ordinal) == true)
                            {
                                return element;
                            }
                            if (string.IsNullOrEmpty(element.___name) == false && string.Equals(element.___name, ___name, StringComparison.OrdinalIgnoreCase) == true)
                            {
                                return element;
                            }

                        }
                    }
                }
                catch (Exception exForm)
                {
                    if (commonLog.LoggingEnabled &&commonLog.CommonLogLevel >= 10)
                    {
                       commonLog.LogEntry("CHtmlCollection.GetPropertyValue() Exception", exForm);
                    }
                }
            }else if (this.___CollectionType == CHtmlHTMLCollectionType.DocumentImageElements || this.___CollectionType == CHtmlHTMLCollectionType.DocumentLayers || this.___CollectionType == CHtmlHTMLCollectionType.DocumentLinks || this.___CollectionType == CHtmlHTMLCollectionType.DocumentStyleSheets || this.___CollectionType == CHtmlHTMLCollectionType.DocumentFrames || this.___CollectionType == CHtmlHTMLCollectionType.DocumentForms || this.___CollectionType == CHtmlHTMLCollectionType.DocumentEmbeds || this.___CollectionType == CHtmlHTMLCollectionType.DocumentAnckors || this.___CollectionType == CHtmlHTMLCollectionType.FormElementsList )
            {
                try
                {
                    int ___thisCount = this.Count;
                    for (int i = 0; i < ___thisCount; i++)
                    {
                        CHtmlElement element = this[i] as CHtmlElement;
                        if (element != null)
                        {


                            if (string.IsNullOrEmpty(element.___idLowSimple) == false && string.Equals(element.___idLowSimple, ___name, StringComparison.Ordinal) == true)
                            {
                                return element;
                            }
                            if (string.IsNullOrEmpty(element.___name) == false && string.Equals(element.___name, ___name, StringComparison.OrdinalIgnoreCase) == true)
                            {
                                return element;
                            }

                        }
                    }
                }
                catch (Exception exForm)
                {
                    if (commonLog.LoggingEnabled &&commonLog.CommonLogLevel >= 10)
                    {
                       commonLog.LogEntry("CHtmlCollection.GetPropertyValue() Exception", exForm);
                    }
                }
            }
			
			if(commonLog.LoggingEnabled &&commonLog.CommonLogLevel >= 10)
			{
				commonLog.LogEntry("GetPropertyValue for {0} {1} {2} {3} failed",this.GetType(), this.___CollectionType, this, ___name);
			}
			return null;
		}

		public void ___setPropertyByName(string ___name, object val)
		{
            if (commonLog.LoggingEnabled &&commonLog.CommonLogLevel >= 8)
            {
               commonLog.LogEntry("{0}.setPropertyValue for {1} = {2} ",  this, ___name, val);
            }
            this.___properties[___name] = val;
		}

		/// <summary>
		/// when CHtmlElement is accessed by like document.body[1], it should return the input selement. not child nodes
		/// </summary>
		/// <param name="___index"></param>
		/// <returns></returns>
		public object ___getPropertyByIndex(int ___index)
		{
			// ------------------------------------------------------
			//                   Array Loop Support
			// ------------------------------------------------------
			// for(i = 0; (a = array[i]); i ++) 
			//   /* Should return null when it over the limit */
			// {
			//            DoSomething();
			// }
			// ------------------------------------------------------
			//commonLog.LogEntry("CHtmlCollection Accessed {0} in {1}", ___index, this.Count);
            if (commonLog.LoggingEnabled &&commonLog.CommonLogLevel >= 10)
            {
               commonLog.LogEntry("calling {0}.GetPropertyValueByIndex({1})", this, ___index);
            }

            if (___index >= 0 && ___index < this.Count)
            {
                object ___objReturn = base[___index];
                if (___objReturn != null)
                {
                    if (commonLog.LoggingEnabled &&commonLog.CommonLogLevel >= 10)
                    {
                       commonLog.LogEntry("{0}.GetPropertyValueByIndex({1}) returns {2}", this, ___index, ___objReturn);
                    }
                    /*
#if DEBUG
                    if (commonLog.LoggingEnabled &&commonLog.CommonLogLevel > 100)
                    {
                        if (___objReturn != null)
                        {
                            if (___objReturn is CHtmlElement)
                            {
                                CHtmlElement elem = ___objReturn as CHtmlElement;
                                if (elem.___elementTagType == CHtmlElementType.META)
                                {
                                   commonLog.LogEntry("HERE");
                                }
                            }
                        }
                    }
#endif
                     */
                    return ___objReturn;
                }
            }
			

            if (commonLog.LoggingEnabled &&commonLog.CommonLogLevel >= 10)
            {
               commonLog.LogEntry("{0}.GetPropertyValueByIndex({1}) has failed", this, ___index);
            }
			return null;
			
		}
        public void ___setPropertyByIndex(int ___index, object val)
        {

            if (commonLog.LoggingEnabled &&commonLog.CommonLogLevel >= 10)
            {
               commonLog.LogEntry("calling {0}.setPropertyValueByIndex({1}) ", this, ___index);
            }
            this[___index] = val;

        }

		public bool ___hasPropertyByName(string ___name)
		{

				return false;
		}
        public bool ___hasPropertyByIndex(int ___index)
        {
            if (commonLog.LoggingEnabled &&commonLog.CommonLogLevel >= 10)
            {
               commonLog.LogEntry("calling {0}.hasProperty({1})...", this, ___index);
            }

            if (base.Count == 0)
            {
                if (commonLog.LoggingEnabled &&commonLog.CommonLogLevel >= 10)
                {
                   commonLog.LogEntry("{0}.hasProperty({1}) returns false.", this, ___index);
                }
                return false;
            }
            else if (___index < base.Count && ___index >= 0)
            {
                return true;
            }

            if (commonLog.LoggingEnabled &&commonLog.CommonLogLevel >= 10)
            {
               commonLog.LogEntry("{0}.hasProperty({1}) returns false.", this, ___index);
            }
            return false;
        }
		public object ___common_object_clone()
		{
			if(commonLog.LoggingEnabled &&commonLog.CommonLogLevel >= 10)
			{
				commonLog.LogEntry("x__Clone {0} {1} called",this.GetType(), this);
			}
			return this;
		}
		public void ___deleteByIndex(int ___index)
		{
			if(commonLog.LoggingEnabled &&commonLog.CommonLogLevel >= 10)
			{
				commonLog.LogEntry("___deleteByIndex {0} {1} called : {2}",this.GetType(), this, ___index);
			}
		}
		public void ___deleteByName(string ___name)
		{
			if(commonLog.LoggingEnabled &&commonLog.CommonLogLevel >= 10)
			{
				commonLog.LogEntry("___deleteByName {0} {1} called : {2}",this.GetType(), this, ___name);
			}

		}
		public object[] ___getByIds()
		{
			if(commonLog.LoggingEnabled &&commonLog.CommonLogLevel >= 10)
			{
				commonLog.LogEntry("___getByIds() {0} {1} called",this.GetType(), this);
			}
				return null;

		}
		public string ___getClassName()
		{
			if(commonLog.LoggingEnabled &&commonLog.CommonLogLevel >= 10)
			{
				commonLog.LogEntry("___getClassName {0} {1} called",this.GetType(), this);
			}
			return this.GetType().Name;
		}
		public object ___getDefaultValue()
		{
			if(commonLog.LoggingEnabled &&commonLog.CommonLogLevel >= 10)
			{
				commonLog.LogEntry("___getDefaultValue {0} {1} called",this.GetType(), this);
			}
			return null;
		}
		public object ___getParentScope()
		{
			if(commonLog.LoggingEnabled &&commonLog.CommonLogLevel >= 10)
			{
				commonLog.LogEntry("___getParentScope {0} {1} called",this.GetType(), this);
			}
			return null;
		}
		public void ___setParentScope(object ___object)
		{
			if(commonLog.LoggingEnabled &&commonLog.CommonLogLevel >= 10)
			{
				commonLog.LogEntry("___setParentScope {0} {1} called : {2}",this.GetType(), this, ___object);
			}
		}
		public object ___getProtoType()
		{
			if(commonLog.LoggingEnabled &&commonLog.CommonLogLevel >= 10)
			{
				commonLog.LogEntry("___getProtoType {0} {1} called",this.GetType(), this);
			}
			return null;
		}
		public bool ___hasInstance(object ___object)
		{
			if(commonLog.LoggingEnabled &&commonLog.CommonLogLevel >= 10)
			{
				commonLog.LogEntry("___hasInstance {0} {1} called : {2}",this.GetType(), this, ___object);
			}
			return false;
		}
		public bool ___instanceEquals(object ___object)
		{
			if(commonLog.LoggingEnabled &&commonLog.CommonLogLevel >= 10)
			{
				commonLog.LogEntry("___instanceEquals {0} {1} called : {2}",this.GetType(), this, ___object);
			}
			return object.ReferenceEquals(this, ___object);
		}
		public void ___setProtoType(object ___object)
		{
			if(commonLog.LoggingEnabled &&commonLog.CommonLogLevel >= 10)
			{
				commonLog.LogEntry("___setProtoType {0} {1} called : {2}",this.GetType(), this, ___object);
			}
		}
        public IMutilversalObjectType multiversalClassType
        {
            get
            {
                return IMutilversalObjectType.HTMLCollection;
            }
        }

		#endregion

        public bool isPrototypeOf(object ___protoObject)
        {
            if (commonLog.LoggingEnabled &&commonLog.CommonLogLevel >= 8)
            {
               commonLog.LogEntry("calling {0}.isPrototpyeOf('{1}') ", this, ___protoObject);
            }
            switch (commonHTML.isPrototypeOf_precheck(this, ___protoObject))
            {
                case 0:
                default:
                    if (commonLog.LoggingEnabled &&commonLog.CommonLogLevel >= 8)
                    {
                       commonLog.LogEntry("TODO:  {0}.isPrototpyeOf('{1}') test needs more test. returns true for now... ", this, ___protoObject);
                    }
                    break;
                case 1:
                    return true;
                case 2:
                    return false;
            }
            return true;
        }
	}
}
