using System;
using System.Collections.Generic;
using System.Text;
using org.mozilla.javascript;

namespace MultiversalRenderer.RhinoNetProcessor
{

    public sealed class MultiversalIteratorDelegate : org.mozilla.javascript.BaseFunction
    {
        public System.WeakReference ___targetObjectWeakReference = null;
        public System.WeakReference ___startObjectWeakReference = null;
        public static org.mozilla.javascript.FunctionObject ___valueOfFunction = null;
        public static org.mozilla.javascript.FunctionObject ___toStringFunction = null;
        private string ___functionName = "";
        public MultiversalIteratorDelegate(string ___funcName)
        {
         

            this.___functionName = ___funcName;
            // this.___DelegateVoid = ___delegate;

        }

        public override object call(org.mozilla.javascript.Context cx, org.mozilla.javascript.Scriptable scope, org.mozilla.javascript.Scriptable thisObj, object[] args)
        {
            RhinoNetProcessor.RhinoMultiversalIterator __iterator__ = RhinoNetProcessor.RhinoMultiversalIterator.jsConstructor(cx, new object[] { this.___targetObjectWeakReference.Target }, this, false) as RhinoNetProcessor.RhinoMultiversalIterator;
            __iterator__.___startObjectWeakReference = this.___startObjectWeakReference;
            return __iterator__;
        }
        public override Scriptable construct(Context cx, Scriptable scope, object[] args)
        {
            return base.construct(cx, scope, args);
        }
        /// <summary>
        /// Value of shoud returns this object itself.
        /// </summary>
        /// <returns></returns>
        public object ___valueOf()
        {
            return this;
        }
        
        public override string getClassName()
        {
            return this.___functionName;
        }
        public override object get(string ___name, Scriptable ___start)
        {
            object ___getresult = base.get(___name, ___start);
            if (___getresult == org.mozilla.javascript.UniqueTag.NOT_FOUND)
            {
                switch (___name)
                {
                    case "valueOf":
                        // 
                        if (BaseFunctionDelegate.___valueOfFunction == null)
                        {
                            java.lang.Class __thisClass = typeof(BaseFunctionDelegate);
                            java.lang.reflect.Method valueOfMethod = __thisClass.getMethod("___valueOf");
                            BaseFunctionDelegate.___valueOfFunction = new FunctionObject("valueOf", valueOfMethod, this);
                        }
                        return BaseFunctionDelegate.___valueOfFunction;
                    case "toString":
                        if (BaseFunctionDelegate.___toStringFunction == null)
                        {
                            java.lang.Class __thisClass2 = typeof(BaseFunctionDelegate);
                            java.lang.reflect.Method classNameMethod = __thisClass2.getMethod("getClassName");
                            BaseFunctionDelegate.___toStringFunction = new FunctionObject(___name, classNameMethod, this);
                        }
                        return BaseFunctionDelegate.___toStringFunction;
                        
                    default:
                        if (commonLog.LoggingEnabled && commonLog.LogLevel >= 10)
                        {
                            commonLog.LogEntry(this.toString() + " get (" + ___name + ") may be failed.");
                        }
                        break;


                }
                
            }
            return ___getresult;
        }
    }
}
