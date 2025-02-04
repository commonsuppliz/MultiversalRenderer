using System;
using System.Collections.Generic;
using System.Collections;
using MultiversalRenderer.Interfaces;

namespace MultiversalRenderer.Core
{
    /// <summary>
    /// Input Element has select() method. this is special 
    /// </summary>
    public class CHtmlInputElement : CHtmlElement, System.IDisposable
    {
        public new void Dispose()
        {
            this.___cleanUp();
            base.Dispose();
            GC.SuppressFinalize(this);
        }
        private void ___cleanUp()
        {

        }
        public void select(string ___val)
        {
            if (commonLog.LoggingEnabled &&commonLog.CommonLogLevel >= 10)
            {
               commonLog.LogEntry("entering {0}.select({1})", this, ___val);
            }
        }
        public void select(object ___objtext)
        {
            this.select(commonHTML.GetStringValue(___objtext));
        }
        #region IPropertBox メンバ

        public override void ___setPropertyByName(string ___name, object val)
        {
            if (commonLog.LoggingEnabled &&commonLog.CommonLogLevel >= 10)
            {
               commonLog.LogEntry("entering {0}.setPropertyValue : {1} = {2}", this, ___name, val);
            }

            switch (___name)
            {

                default:
                    break;
            }
            base.___setPropertyByName(___name, val);
        }

        public override bool ___hasPropertyByName(string ___name)
        {
            return false;

        }
        public override bool ___hasPropertyByIndex(int ___index)
        {
            if (commonLog.LoggingEnabled &&commonLog.CommonLogLevel >= 5)
            {
               commonLog.LogEntry("calling HasPropertyValueIndex for {0} {1}  {2} ", this.GetType(), this, ___index);
            }
            return true;
        }

        public override void ___setPropertyByIndex(int ___index, object val)
        {
            if (commonLog.LoggingEnabled &&commonLog.CommonLogLevel >= 5)
            {
               commonLog.LogEntry("SetPropertyValueIndex for {0} {1}  {2} = {3} failed", this.GetType(), this, ___index, val);
            }
        }
        public override object ___getPropertyByIndex(int ___index)
        {
            if (commonLog.LoggingEnabled &&commonLog.CommonLogLevel >= 5)
            {
               commonLog.LogEntry("___getPropertyByName by index {0} {1} {2} failed", this.GetType(), this, ___index);
            }
            return null;
        }

        public override object ___getPropertyByName(string ___name)
        {
            if (commonLog.LoggingEnabled &&commonLog.CommonLogLevel >= 10)
            {
               commonLog.LogEntry("get : {0} for {1}", ___name, this.toLogString());
            }
            switch (___name)
            {

                default:
                    // ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
                    // Lookup for Prototype
                    // ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
                    if (this.___IsPrototype == false && this.___prototypeWeakReference != null)
                    {
                        CHtmlElement ___protoElement = null;
                        ___protoElement = this.___prototypeWeakReference.Target as CHtmlElement;
                        int __ProtoLookupCont = 0;
                        while (___protoElement != null)
                        {
                            __ProtoLookupCont++;
                            if (__ProtoLookupCont > 10)
                            {
                                if (commonLog.LoggingEnabled &&commonLog.CommonLogLevel >= 5)
                                {
                                   commonLog.LogEntry("GetPropertyValue for {0} {1} Prototype lookup loop", this.GetType(), this);
                                }
                                break;
                            }

                            object protoValue = null;
                            if (___protoElement.___properties.Count > 0 && ___protoElement.___properties.TryGetValue(___name, out protoValue))
                            {
                                return protoValue;
                            }
                            else
                            {
                                if (___protoElement.___elementTagType == CHtmlElementType._ELEMENT_PROTOTYPE)
                                {
                                    break;
                                }
                                if (___protoElement.parentNode != null)
                                {
                                    ___protoElement = ___protoElement.parentNode as CHtmlElement;
                                }
                                else
                                {
                                    break;
                                }

                            }
                        }
                    }

                    // ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
                    break;
            }
            object _obase = base.___getPropertyByName(___name);
            if (_obase != null)
            {
                return _obase;
            }

            if (commonLog.LoggingEnabled &&commonLog.CommonLogLevel >= 5)
            {
               commonLog.LogEntry("GetPropertyValue for {0} {1} {2} failed", this.GetType(), this, ___name);
            }
            return null;
        }
        public new IMutilversalObjectType multiversalClassType
        {
            get
            {

                return IMutilversalObjectType.HTMLInputElement;
            }
        }
        #endregion
    }
}
