using System;
using System.Collections;
using MultiversalRenderer.Interfaces;
namespace MultiversalRenderer.Core
{
	/// <summary>
	/// CHtmlAttribute is equivalent to 
	/// </summary>
	
	public sealed class CHtmlAttribute : CHtmlBase, ICommonObjectInterface
	{
		private bool _specified = true; // attribute specified is always true
		private CHtmlCollection _childNodes = null;



		public CHtmlAttribute()
		{

			this._childNodes = new CHtmlCollection();
			this.___SetNodeType(CHtmlNodeType.ATTRIBUTE_NODE);
		
		}

   
        public bool hasOwnProperty(object _oname)
        {

            return false;
        }
		private void CleanUp()
		{
			if(this._childNodes != null)
			{
		
				this._childNodes = null;
			}
			if(this.___parentNode != null)
			{
				this.___parentNode = null;
			}
		}

		/// <summary>
		/// Retrieves whether an attribute has been specified.
		/// </summary>
		
		public bool specifid
		{
			get{return this._specified;}
			set{this._specified = value;}
		}
		
		public object nodeValue
		{
			get{return base.value;}
			set{base.value = value;}
		}

		public override string ToString()
		{
			return string.Format("{0}", base.value);
		}
		/// <summary>
		/// Copies a reference to the object from the document hierarchy. 
		/// </summary>
		/// <returns></returns>
		
		public CHtmlAttribute cloneNode()
		{
			CHtmlAttribute newAttr = new CHtmlAttribute();
            if (string.IsNullOrEmpty(this.___name) == false)
            {
                newAttr.___name = string.Copy(this.___name);
            }
            if (string.IsNullOrEmpty(this.___type) == false)
            {
                newAttr.___type = string.Copy(this.___type);
            }
            if (string.IsNullOrEmpty(this.___tagName) == false)
            {
                newAttr.___tagName = string.Copy(this.___tagName);
            }
            if (string.IsNullOrEmpty(this.___title) == false)
            {
                newAttr.___title = string.Copy(this.___title);
            }
			newAttr.specifid = this.specifid;
            if(string.IsNullOrEmpty(this.___class) == false)
            {
			    newAttr.className = string.Copy(this.___class);
            }
			if(this.value != null)
			{
				if(this.value is string)
				{
					newAttr.value = string.Copy(this.value as string);
				}
				else if(this.value.GetType().IsPrimitive ==true)
				{
					newAttr.value = this.value;
				}
				else
				{
					newAttr.value = this.value;
				}
			}
			else
			{
				newAttr.value = null;
			}
			return newAttr;
		}
        /// <summary>
        /// Make Clone of Value
        /// </summary>
        /// <returns></returns>
        internal object ____GetValueClone()
        {
            if (this.value != null)
            {
                if (this.value.GetType().IsPrimitive == true)
                {
                    return this.value;
                }
                else if(this.value is string)
                {
                    return string.Copy(this.value as string);
                }
                else
                {
                    return this.value;
                }
            }
            return null;
        }
		
		public void appendChild(object newNode)
		{
			if(newNode is CHtmlBase)
			{
				CHtmlAttribute newAttr = new CHtmlAttribute();
                CHtmlBase newNodeBase = newNode as CHtmlBase;
				newAttr.name = newNodeBase.name;
				newAttr.___tagName = newNodeBase.___tagName;
				newAttr.value = newNodeBase.value;
				this._childNodes.Add(newAttr);
			}
		}
		
		public void removeChild(object removeChild)
		{
			if(this._childNodes.Contains(removeChild))
			{
				this._childNodes.Remove(removeChild);
			}
		}




        public new string name
        {
            get { return base.name; }
            set {
                base.name = value;
            
            }
        }

	

		#region IPropertBox ƒƒ“ƒo


		
		public object ___getPropertyByName(string ___name)
		{
            switch (___name)
			{
                case "textContent":
                case "textcontent":
                    if (base.@value == null)
                    {
                        return "";
                    }
                    else
                    {
                        if (base.@value is string)
                        {
                            return base.@value;
                        }
                        else
                        {
                            return base.@value.ToString();
                        }
                    }
                case "nodeValue":
				case "nodevalue":
				case "value":
					return base.@value;
				case "name":
				case "nodename":
                case "nodeName":
					return commonHTML.___convertNullToEmpty(base.name);
				case "childnodes":
                case "childNodes":
				case "attributes":
					return this._childNodes;
				case "specified":
                    return true;
				case "tagname":
                case "tagName":
					return commonHTML.___convertNullToEmpty(base.___tagName);
				case "nodeType":
					return (double)this.nodeType;

				case "ownerelement":
                case "ownerElement":
					if(this.___parentNode == null)
					{
						if(commonLog.LoggingEnabled &&commonLog.CommonLogLevel >= 8)
						{
							commonLog.LogEntry("CHtmlAttribute of ownerElement is null {0}", this);
						}
					}
					return this.___parentNode;
				default:
					break;
			}
			if(commonLog.LoggingEnabled &&commonLog.CommonLogLevel >= 8)
			{
				commonLog.LogEntry("GetPropertyValue for {0} {1} '{2}' failed",this.GetType(), this, ___name);
			}
			return null;
		}

		
		public void ___setPropertyByName(string ___name, object val)
		{
            if (commonLog.LoggingEnabled &&commonLog.CommonLogLevel >= 8)
            {
               commonLog.LogEntry("calling SetPropertyValue for {0} {1}  '{2}' = {3}", this.GetType(), this, ___name, val);
            }
			switch(___name)
			{
				case "value":
				case "nodeValue":
                case "nodevalue":
                case "textcontent":
                case "textContent":
					base.value = val;
					return;
				case "nodeName":
				case "name":
					this.name = commonHTML.GetStringValue(val);
					break;
				case "tagName":
                case "tagname":
                    base.___tagName = commonHTML.GetStringValue(val);
					break;

                    
                case "specified":
                    this._specified = commonData.convertObjectToBoolean(val);
                    break;
				default:
					bool ___ValueStored = false;
					if(commonLog.LoggingEnabled &&commonLog.CommonLogLevel >= 8)
					{
						commonLog.LogEntry("TODO: SetPropertyValue for {0} {1}  '{2}' = {3} failed : {4}",this.GetType(), this, ___name, val, ___ValueStored );
					}
					break;
			}
		}
		
		public void ___setPropertyByIndex(int ___index, object val)
		{
			if(commonLog.LoggingEnabled &&commonLog.CommonLogLevel >= 8)
			{
				commonLog.LogEntry("TODO : SetPropertyValueIndex for {0} \'{1}\' {2} = {3} failed",this.GetType(), this, ___index, val);
			}
			
		}
		
		public object ___getPropertyByIndex(int ___index)
		{
			if(commonLog.LoggingEnabled &&commonLog.CommonLogLevel >= 8)
			{
				commonLog.LogEntry("TODO : ___getPropertyByName by index {0} {1} {2} failed",this.GetType(), this, ___index);
			}
			return null;
		}

		
		public bool ___hasPropertyByName(string ___name)
		{

			return false;
		}
		
		public bool ___hasPropertyByIndex(int ___index)
		{
			
			return true;
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
            return this.value;
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

		#endregion
	}
}
