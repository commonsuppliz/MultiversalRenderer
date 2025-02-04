
using System;
using System.Text;
using System.Net;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using MultiversalRenderer.Interfaces;
namespace MultiversalRenderer.Core
{

    public class CHtmlXMLHttpRequest : CHtmlNode, ICommonObjectInterface , IDisposable
    {
   


        internal System.WeakReference ___MultiversalWindowWeakReference = null;



        internal string ___functionName = null;


        internal string ___baseThreadURL = null;
        internal MultiversalRenderer.Interfaces.IMultiversalScope ___scope = null;
        internal string ___sessionGUID = null;
        public long OwnerHostHandle = 0;
        internal object ___loadfunctionobject = null;
        internal object ___loadstart_functionobject = null;
        internal object ___loadend_functionobject = null;
        internal object ___progressfunctionobject = null;
        internal object ___readystatechagefunctionObject = null;
        internal object ___abortfunctionobject = null;

        internal object ___timeoutfunctionobject = null;

        internal object ___onerror_function = null;

        internal bool ___withCredencials = false;

        internal string ___targetUrl = null;

        public CHtmlXMLHttpRequest()
        {

            base.___multiversalClassType = IMutilversalObjectType.XMLHttpRequest;

            this.___baseThreadURL = "";
            this.___functionName = "";
            this.___sessionGUID = "";

           
        }
        public void overrideMimeType(object ___mimeTypeObject)
        {
      
        }

        ~CHtmlXMLHttpRequest()
        {
            this.CleanUp();
        }
        private void CleanUp()
        {
            try
            {

            }
            catch { }
            

            this.___scope = null;
            this.___baseThreadURL = null;
            ___loadfunctionobject = null;
            this.___readystatechagefunctionObject = null;

        }

        public void Dispose()
        {
            this.CleanUp();
        }
        /*
        private object ProcRequsest(string procName, bool IsGet, params object[] args)
        {
            if (this.___unicusXmlHttp == null)
            {
                if (commonLog.LoggingEnabled &&commonLog.CommonLogLevel  >= 10)
                {
                   commonLog.LogEntry("Please init object first!");
                }
                return null;
            }
            if (XmlMethodList != null)
            {
                try
                {
                    switch (procName.ToLower())
                    {
                        case "open":
                            procName = "open5";
                            if (args == null || args.Length < 2)
                            {
                                return null;
                            }
                            break;
                        default:
                            break;
                    }
                    object o = XmlMethodList[procName];
                    if (o != null)
                    {
                        if (args != null && args.Length > 0)
                        {
                            if (commonLog.LoggingEnabled &&commonLog.CommonLogLevel  >= 10)
                            {
                               commonLog.LogEntry("ProcRequest Begin :{0} {1} : {2} {3}", procName, o, args.Length, args[0]);
                            }
                        }
                        else
                        {
                            if (commonLog.LoggingEnabled &&commonLog.CommonLogLevel >= 10)
                            {
                               commonLog.LogEntry("ProcRequest Begin :{0} {1} ", procName, o);
                            }
                        }
                        if (o is System.Reflection.MethodInfo)
                        {
                            MethodInfo methodInfo = o as MethodInfo;
                            return methodInfo.Invoke(this.___unicusXmlHttp, args);
                        }
                        else if (o is System.Reflection.PropertyInfo)
                        {
                            PropertyInfo pInfo = o as PropertyInfo;
                            if (IsGet)
                            {
                                return pInfo.GetValue(this.___unicusXmlHttp, null);

                            }
                            else
                            {
                                if (args.Length > 0)
                                {
                                    if (commonLog.LoggingEnabled &&commonLog.CommonLogLevel  >= 10)
                                    {
                                       commonLog.LogEntry("ProcRequest :{0} {1} ", procName, args[0]);
                                    }
                                    pInfo.SetValue(this.___unicusXmlHttp, args[0], null);
                                }
                                else
                                {
                                    pInfo.SetValue(this.___unicusXmlHttp, null, null);
                                }
                            }
                        }
                    }

                }
                catch (Exception ex)
                {
                    if (commonLog.LoggingEnabled &&commonLog.CommonLogLevel  >= 10)
                    {
                       commonLog.LogEntry("ProcRequest error {0}", ex.Message);
                    }
                }
            }
            return null;
        }
         */

        /*
         public static void finishInit(Scriptable scope,
                                 FunctionObject constructor,
                                 Scriptable prototype)
         {

           
               
         }
         */





     
        public void setRequestHeader(object headerName, object value)
        {
         
        }

        public string getAllResponseHeaders()
        {
            return String.Empty;
        }
        public void addEventListener(object ___nameObj, object ___objFunction, object ___objParam)
        {
            this.___addEventListener_inner(___nameObj, ___objFunction, ___objParam);
        }
        public void addEventListener(object ___nameObj, object ___objFunction)
        {
            this.___addEventListener_inner(___nameObj, ___objFunction, null);
        }

        public void removeEventListener(string ___otype,object ___olistener,object ___ouseCapture)
        {
            this.___removeEventListenerInner(___otype, ___olistener, ___ouseCapture);
        }
        public void removeEventListener(string ___otype, object ___olistener)
        {
            this.___removeEventListenerInner(___otype, ___olistener, null);
        }

        internal void ___removeEventListenerInner(string ___otype, object ___olistener, object ___ouseCapture)
        {
            if (commonLog.LoggingEnabled &&commonLog.CommonLogLevel >= 10)
            {
               commonLog.LogEntry("entering {0}.removeEventListener({1}, {2}, {3})", this, ___otype, ___olistener,  ___ouseCapture);
            }
            if(string.IsNullOrEmpty(___otype) == false)
            {
                switch(___otype)
                {
                    case "load":
                        this.___loadfunctionobject = null;
                        break;
                    case "loadstart":
                        this.___loadstart_functionobject = null;
                        break;
                    case "loadend":
                        this.___loadend_functionobject = null;
                        break;
                    case "onerror":
                    case "error":
                        this.___onerror_function  = null;
                        break;
                    case "progress":
                        this.___progressfunctionobject  = null;
                        break;
                    case "abort":
                        this.___abortfunctionobject = null;
                        break;
                    case "timeout":
                        this.___timeoutfunctionobject  = null;
                        break;
                    case "readystatechange":
                        this.___readystatechagefunctionObject = null;
                        break;
                    default:
                        if (commonLog.LoggingEnabled &&commonLog.CommonLogLevel >= 10)
                        {
                           commonLog.LogEntry("TODO: {0}.removeEventListener({1}, {2}, {3})", this, ___otype, ___olistener, ___ouseCapture);
                        }
                        break;
                }
            }
                
        }
        /// <summary>
        /// Dispatches the specified event to the current element.
        /// </summary>
        /// <param name="___eventObject"></param>
        /// <returns>Returns true if the EventEvent.preventDefault() was not called by any of the event listeners that handled the event. The Event.preventDefault() method prevents the default action for the event from occurring. Otherwise, returns false.</returns>
        public bool dispatchEvent(object ___eventObject)
        {
            if (commonLog.LoggingEnabled &&commonLog.CommonLogLevel >= 10)
            {
               commonLog.LogEntry("TODO: {0}.dispatchEvent({1})", this, ___eventObject);
            }
            return false;
        }
        public bool dispatchEvent(object ___event1, object ___event2)
        {
            if (commonLog.LoggingEnabled &&commonLog.CommonLogLevel >= 10)
            {
               commonLog.LogEntry("TODO: {0}.dispatchEvent({1})", this, ___event1);
            }
            return false;
        }
        private void ___addEventListener_inner(object ___nameObj, object ___objFunction, object ___objParam)
        {
            if (commonLog.LoggingEnabled &&commonLog.CommonLogLevel >= 10)
            {
               commonLog.LogEntry("calling {0}.addEventListener({1}, {2}, {3})", this, ___nameObj, ___objFunction, ___objParam );
            }
            string ___strEventName = "";
            ___strEventName = commonHTML.GetStringValue(___nameObj);
            if (___strEventName.Length != 0)
            {
                switch (___strEventName)
                {
                    case "onload":
                    case "load":
                    case "Load":
                    case "LOAD":
                        this.onload = ___objFunction;
                        return;
                    case "progress":
                        this.onprogress = ___objFunction;
                        return;
                    case "error":
                        this.onerror = ___objFunction;
                        return;
                    case "onreadystatechange":
                    case "readystatechange":
                    case "ReadyStateChange":
                    case "Readystatechange":
                        this.onreadystatechange = ___objFunction;
                        return;
                    case "onloadend":
                        this.onloadend = ___objFunction;
                        return;

                    default:
                        if (commonLog.LoggingEnabled &&commonLog.CommonLogLevel >= 10)
                        {
                           commonLog.LogEntry("{0}.addEventListener({1}, {2}, {3}) failed", this, ___nameObj, ___objFunction, ___objParam);
                        }
                        return;

                }
            }

        }
        public string getResponseHeader(object ___objectName)
        {
            return String.Empty;
   
        }
        public void GetInstance()
        {



        }
        public void open(params object[] args)
        {
            if (commonLog.LoggingEnabled &&commonLog.CommonLogLevel >= 10)
            {
               commonLog.LogEntry(" XmlHttpRequest open enter with arguments: {0} : {1}", this, args);
            }
            int _isxhropenvalid = -1;
            bool _asyncbool = false;
            if (args != null && args.Length > 1)
            {
                switch(args.Length)
                {



                    default:
                        break;

                }
            }
            
            if (_isxhropenvalid == -1 &&commonLog.LoggingEnabled &&commonLog.CommonLogLevel >= 10)
            {
               commonLog.LogEntry(" XmlHttpRequest open called with illegal arguments: {0}", this, args);
            }
        }




        public void send(Object o)
        {
            this.___send_innner(o);
        }
        public void Send()
        {
            this.___send_innner(null);
        }
        public void send()
        {
            this.___send_innner(null);
        }
        public void Send(object o)
        {

            this.___send_innner(o);
        }
        private void ___send_innner(object __oSend)
        {

        }

        public void abort()
        {
         
        }

        /**
         * @return Returns the readyState.
         */
        public double readyState
        {
            get
            {

                    return -1;
                

            }
        }
        public double status
        {
            get
            {
                return -1;
            }
        }
        public string statusText
        {
            get
            {
                return String.Empty;
            }
        }
        /**
         * @return Returns the responseText.
         */
        public string responseText
        {
            get
            {
                return String.Empty;

            }
        }

        /**
         * @return Returns the responseXML as a DOM Document.
         */
        public object responseXML
        {
            get
            {
                return String.Empty;
            }
        }
        /// <summary>
        /// Get response Type
        /// </summary>
        /// <returns></returns>
        public string responseType
        {
            get{
                return String.Empty;
            }
            set
            {
         
            }
        }


        /// <summary>
        /// May be returns response as desired type.
        /// </summary>
        /// <returns></returns>
        public object response
        {
            get
            {


                return null;
            }
        }


        /**
         * @return Returns the http status text.
         */

        /*
        * @param onreadystatechange The onreadystatechange to set.
         */
        //[org.mozilla.javascript.annotations.JSSetter]
        public object onprogress
        {
            get { return this.___progressfunctionobject; }
            set { this.___progressfunctionobject = value; }
        }
        public object onabort
        {
            get { return this.___abortfunctionobject; }
            set { this.___abortfunctionobject = value; }
        }
        public object ontimeout
        {
            get { return this.___timeoutfunctionobject; }
            set { this.___timeoutfunctionobject = value; }
        }
        public bool async
        {
            get { return false; }
            set {; }
        }

        public object onerror
        {
            get
            {
                return this.___onerror_function;
            }set
            {
                this.___onerror_function = value;
            }
        }
        public bool withCredentials
        {
            get { return this.___withCredencials; }
            set { this.___withCredencials = value; }
        }
        public object onload
        {
            set
            {
                ___set_load_functionchange(value);
            }
            get
            {
                return this.___loadfunctionobject;
            }

        }
        internal void ___set_load_functionchange(object _value)
        {
            try
            {
                this.___functionName = "load";
                this.___loadfunctionobject = _value;

            }
            catch (Exception ex)
            {
                if (commonLog.LoggingEnabled &&commonLog.CommonLogLevel >= 10)
                {
                   commonLog.LogEntry("ERROR onreadystatechange : " + ex.Message);
                }
            }

        }
        public object onloadend
        {
            set
            {
                try
                {
                    this.___functionName = "loadend";
                    this.___loadend_functionobject = value;

                }
                catch (Exception ex)
                {
                    if (commonLog.LoggingEnabled &&commonLog.CommonLogLevel >= 10)
                    {
                       commonLog.LogEntry("ERROR onreadystatechange : " + ex.Message);
                    }
                }
            }
            get
            {
                return this.___loadend_functionobject;
            }

        }
        internal void ___set_onreadystatechange(object _val)
        {
            if (commonLog.LoggingEnabled &&commonLog.CommonLogLevel >= 10)
            {
               commonLog.LogEntry("setting {0}.onreadystatechange = {1} ", this, _val);
            }
            try
                {
                    this.___functionName = "readystatechange";
                    this.___readystatechagefunctionObject = _val;

                }
                catch (Exception exFinal)
                {
                    if (commonLog.LoggingEnabled &&commonLog.CommonLogLevel >= 10)
                    {
                       commonLog.LogEntry("ERROR onreadystatechange : ", exFinal);
                    }
                }
            
        }
        internal void ___set_onloadchange(object _val)
        {
            if (commonLog.LoggingEnabled &&commonLog.CommonLogLevel >= 10)
            {
               commonLog.LogEntry("setting {0}.onload = {1} ", this, _val);
            }
            try
            {
                this.___functionName = "load";
                this.___loadfunctionobject = _val;
                

                
            }
            catch (Exception exFinal)
            {
                if (commonLog.LoggingEnabled &&commonLog.CommonLogLevel >= 10)
                {
                   commonLog.LogEntry("ERROR setting onload : ", exFinal);
                }
            }

        }


        public Object onreadystatechange
        {
            get
            {
                return this.___readystatechagefunctionObject;
            }
            set
            {
                this.___set_onreadystatechange(value);
            }

        }
        internal void ___execute_onload_Inner(object sender, EventArgs args)
        {

            object ___function_object = this.___loadfunctionobject;
            if (___function_object == null)
            {
                ___function_object = this.___loadend_functionobject;
            }
            this.___execute_function_inner("onload", ___function_object);
        }


        private void ___execute_onstatechange_Inner(object sender, EventArgs args)
        {
            object ___function_object = ___readystatechagefunctionObject;

            if (___function_object != null)
            {
                this.___execute_function_inner("onstatechange", ___function_object);
            }

        }
        internal void ___execute_function_inner(string statusName, object ___function_object)
        {

            CHtmlMultiversalWindow ___multiWindow = null;
            IMultiversalScriptProcessor ___processor = null;
            CHtmlScriptResultElement _scriptElement = null;
    
        }

        private CHtmlMultiversalWindow ___getMultiversalWindow()
        {
            if (this.___MultiversalWindowWeakReference != null)
            {
                return this.___MultiversalWindowWeakReference.Target as CHtmlMultiversalWindow;
            }
            return null;
        }

#region IPropertBox メンバ



        public virtual object ___getPropertyByName(string ___name)
        {
            if (commonLog.LoggingEnabled &&commonLog.CommonLogLevel >= 8)
            {
               commonLog.LogEntry("GetPropertyValue for {0} {1} ", this, ___name);
            }
            switch (___name)
            {
                case "onprogress":
                    return this.onprogress;
                case "onload":
                    return this.___loadfunctionobject;
                case "onreadystatechange":
                    return this.___readystatechagefunctionObject;
                case "onerror":
                    return this.onerror;
                case "responseText":
                case "responsetext":
                    return this.responseText;
                case "responseType":
                case "responsetype":
                    return this.responseType;
                case "responseXML":
                case "responseXml":
                case "responsexml":
                    return this.responseXML;
                case "status":
                    return this.status;
                case "statusText":
                case "statustext":
                    return this.statusText;
                case "readyState":
                case "readystate":
                    return this.readyState;
                case "async":
                    return false;
                case "ontimeout":
                    return this.ontimeout;
                case "response":
                    return null;
                case "withCredentials":
                    return this.___withCredencials;
                case "onloadend":
                    return this.___loadend_functionobject;
                case "length":

                        return 0;
                    
                default:
                break;


            }
            object ___propValue;
            if (this.___properties.TryGetValue(___name, out ___propValue))
            {
                return ___propValue;
            }
            if (commonLog.LoggingEnabled &&commonLog.CommonLogLevel >= 8)
            {
               commonLog.LogEntry("getPropertyValue for {0} {1} failed", this, ___name);
            }
            return null;
        }

        public virtual  void ___setPropertyByName(string ___name, object ___val)
        {
            if (commonLog.LoggingEnabled &&commonLog.CommonLogLevel >= 8)
            {
               commonLog.LogEntry("entring setPropertyValue for {0} : {1} = {2} ...", this, ___name, ___val);
            }
            switch (___name)
            {
                case "onload":
                case "onLoad":
                     this.___set_load_functionchange(___val);
                    break;
                case "onloadend":
                    this.onloadend = ___val;
                    break;
                case "onprogress":
                    this.onprogress = ___val;
                    break;
                case "onreadystatechange":
                    this.___set_onreadystatechange(___val);
                    break;
                case "timeout":

                    break;
                case "responsetype":
                case "responseType":
                    this.responseType = commonHTML.GetStringValue(___val);
                    break;
                case "abort":
                case "onabort":
                    this.onabort = ___val;
                    break;
                case "onerror":
                    this.onerror = ___val;
                    break;
                case "ontimeout":
                    this.ontimeout  = ___val;
                    break;
                case "async":
                case "Async":
                    this.async = commonData.convertObjectToBoolean(___val);
                    break;
                case "withCredentials":
                    this.___withCredencials = commonData.convertObjectToBoolean(___val);
                    break;
                    
                default:
                    if (commonLog.LoggingEnabled &&commonLog.CommonLogLevel >= 8)
                    {
                       commonLog.LogEntry("SetPropertyValue for {0} {1}  {2} = {3} failed", this.GetType(), this, ___name, ___val);
                    }
                    this.___properties[___name] = ___val;
                    break;
            }
         
        }
        public virtual  void ___setPropertyByIndex(int ___index, object val)
        {
            if (commonLog.LoggingEnabled &&commonLog.CommonLogLevel >= 8)
            {
               commonLog.LogEntry("SetPropertyValueIndex for {0} {1}  {2} = {3} failed", this.GetType(), this, ___index, val);
            }
        }
        public virtual object ___getPropertyByIndex(int ___index)
        {
            if (commonLog.LoggingEnabled &&commonLog.CommonLogLevel >= 8)
            {
               commonLog.LogEntry("GetPropertyValueInex for {0} {1} {2} failed", this.GetType(), this, ___index);
            }
            return null;
        }

        public virtual  bool ___hasPropertyByName(string ___name)
        {

            return false;
        }
        public virtual bool ___hasPropertyByIndex(int ___index)
        {
            return true;
        }
        public virtual object ___common_object_clone()
        {
            if (commonLog.LoggingEnabled &&commonLog.CommonLogLevel >= 10)
            {
               commonLog.LogEntry("x__Clone {0} {1} called", this.GetType(), this);
            }
            return this;
        }
        public virtual  void ___deleteByIndex(int ___index)
        {
            if (commonLog.LoggingEnabled &&commonLog.CommonLogLevel >= 10)
            {
               commonLog.LogEntry("___deleteByIndex {0} {1} called : {2}", this.GetType(), this, ___index);
            }
        }
        public virtual  void ___deleteByName(string ___name)
        {
            if (commonLog.LoggingEnabled &&commonLog.CommonLogLevel >= 10)
            {
               commonLog.LogEntry("___deleteByName {0} {1} called : {2}", this.GetType(), this, ___name);
            }

        }
        public virtual  object[] ___getByIds()
        {
            if (commonLog.LoggingEnabled &&commonLog.CommonLogLevel >= 10)
            {
               commonLog.LogEntry("___getByIds() {0} {1} called", this.GetType(), this);
            }
            return null;

        }
        public virtual  string ___getClassName()
        {
            return "XMLHttpRequest";
        }
        public virtual  object ___getDefaultValue()
        {
            if (commonLog.LoggingEnabled &&commonLog.CommonLogLevel >= 10)
            {
               commonLog.LogEntry("___getDefaultValue {0} {1} called", this.GetType(), this);
            }
            return null;
        }
        public virtual object ___getParentScope()
        {
            if (commonLog.LoggingEnabled &&commonLog.CommonLogLevel >= 10)
            {
               commonLog.LogEntry("___getParentScope {0} {1} called", this.GetType(), this);
            }
            return null;
        }
        public virtual  void ___setParentScope(object ___object)
        {
            if (commonLog.LoggingEnabled &&commonLog.CommonLogLevel >= 10)
            {
               commonLog.LogEntry("___setParentScope {0} {1} called : {2}", this.GetType(), this, ___object);
            }
        }
        public virtual  object ___getProtoType()
        {
            if (commonLog.LoggingEnabled &&commonLog.CommonLogLevel >= 10)
            {
               commonLog.LogEntry("___getProtoType {0} {1} called", this.GetType(), this);
            }
            return null;
        }
        public virtual bool ___hasInstance(object ___object)
        {
            if (commonLog.LoggingEnabled &&commonLog.CommonLogLevel >= 10)
            {
               commonLog.LogEntry("___hasInstance {0} {1} called : {2}", this.GetType(), this, ___object);
            }
            return false;
        }
        public virtual bool ___instanceEquals(object ___object)
        {
            if (commonLog.LoggingEnabled &&commonLog.CommonLogLevel >= 10)
            {
               commonLog.LogEntry("___instanceEquals {0} {1} called : {2}", this.GetType(), this, ___object);
            }
            return object.ReferenceEquals(this, ___object);
        }
        public virtual void ___setProtoType(object ___object)
        {
            if (commonLog.LoggingEnabled &&commonLog.CommonLogLevel >= 10)
            {
               commonLog.LogEntry("___setProtoType {0} {1} called : {2}", this.GetType(), this, ___object);
            }
        }
        public new IMutilversalObjectType multiversalClassType
        {
            get
            {
                return IMutilversalObjectType.XMLHttpRequest;
            }
        }

#endregion
        public bool isPrototypeOf(object ___protoObject)
        {
            if (commonLog.LoggingEnabled &&commonLog.CommonLogLevel >= 8)
            {
               commonLog.LogEntry("calling {0}.isPrototpyeOf('{1}') ", this, ___protoObject);
            }

            return true;
        }

    }
}