using System;
using System.Collections.Generic;
using System.Text;

using org.mozilla.javascript;
using MultiversalRenderer.Interfaces;

namespace MultiversalRenderer.RhinoNetProcessor
{

    public class BaseFunctionDelegate : org.mozilla.javascript.BaseFunction, IPrototypeFunction
    {

        public static org.mozilla.javascript.FunctionObject ___valueOfFunction = null;
        public static org.mozilla.javascript.FunctionObject ___toStringFunction = null;
        public static org.mozilla.javascript.FunctionObject ___call_inner_Function = null;
        public static org.mozilla.javascript.FunctionObject ___apply_inner_Function = null;
        public static org.mozilla.javascript.FunctionObject ___bind_inner_Function = null;
        internal bool ___requiresCallerWindowInformationToBeCalled = false;
        internal System.WeakReference ___callerMultiversalWindowWeakReference = null;
  
        public delegate object Delegate4Object(Object[] args);
        public delegate object DelegateStandardObject(Context cxt, object[] args, Function ___func, bool ___NewExpr);

        private string ___functionName = "";
        private Delegate4Object ___Delegate4Object = null;
        private DelegateStandardObject ___Delegate4StandardObject = null;

        public string name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public object multiversal_prototype_object { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public IMutilversalObjectType multiversalClassType { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public BaseFunctionDelegate(string ___funcName, Delegate4Object ___delegate)
        {
            this.___Delegate4Object = ___delegate;


            this.___functionName = ___funcName;
            // this.___DelegateVoid = ___delegate;

        }

        public override object getDefaultValue(java.lang.Class typeHint)
        {
            object objDefault =  base.getDefaultValue(typeHint);
            return objDefault;
        }
        public BaseFunctionDelegate(string ___funcName, DelegateStandardObject ___delegate)
        {
            this.___Delegate4StandardObject = ___delegate;
            this.___functionName = ___funcName;
        }

        public BaseFunctionDelegate(string ___funcName)
        {
            this.___functionName = ___funcName;
        }
        public override object call(org.mozilla.javascript.Context cx, org.mozilla.javascript.Scriptable scope, org.mozilla.javascript.Scriptable thisObj, object[] args)
        {
            if (this.___Delegate4Object != null)
            {
                object ___objreturn = null;
                if (this.___requiresCallerWindowInformationToBeCalled == false)
                {
                    ___objreturn = this.___Delegate4Object.Invoke(args);
                }
                else
                {
                    if (this.___callerMultiversalWindowWeakReference != null)
                    {
                        object[] newArgs = new object[args.Length + 1];
                        newArgs[0] = this.___callerMultiversalWindowWeakReference.Target;
                        int x = 1;
                        int argLength = args.Length;
                        for (int i = 0; i < argLength; i ++ )
                        {
                            newArgs[x] = args[i];
                            x++;
                        }
                        ___objreturn = this.___Delegate4Object.Invoke(newArgs);
                        newArgs = null;
                    }
                    else
                    {
                        ___objreturn = this.___Delegate4Object.Invoke(args);
                    }
                }
                if (commonTypeConverter.IsUndefinedOrNuLL(___objreturn) == false)
                {
                    return commonTypeConverter.ConvertCLRValueToJavaValue(___objreturn, scope);
                }
                return ___objreturn;
            }

            return null;
        }
        public object ___bind___inner(object ___thisObj, object ___p1, object ___p2)
        {
            if (commonLog.LoggingEnabled && commonLog.LogLevel >= 8)
            {
                commonLog.LogEntry("calling {0}.___bind__inner({1}, {2}, {3})", this.___functionName, ___thisObj, ___p1, ___p2);
            }
            org.mozilla.javascript.Scriptable scope = ___thisObj as org.mozilla.javascript.Scriptable;
            if (this.___Delegate4Object != null)
            {
                object ___objreturn = this.___Delegate4Object.Invoke(new object[] { ___p1, ___p2 });
                if (commonTypeConverter.IsUndefinedOrNuLL(___objreturn) == false)
                {
                    return commonTypeConverter.ConvertCLRValueToJavaValue(___objreturn, scope);
                }
                return ___objreturn;
            }

            return null;
        }
        /// <summary>
        /// Keep this 
        /// </summary>
        /// <param name="cx"></param>
        /// <param name="scope"></param>
        /// <param name="thisObj"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public object ___call___inner(object ___thisObj, object ___p1, object ___p2)
        {
            if (commonLog.LoggingEnabled && commonLog.LogLevel >= 8)
            {
                commonLog.LogEntry("calling {0}.___call__inner({1}, {2}, {3})", this.___functionName, ___thisObj, ___p1, ___p2);
            }
            org.mozilla.javascript.Scriptable scope = ___thisObj as org.mozilla.javascript.Scriptable;
            if (this.___Delegate4Object != null)
            {
                object ___objreturn = this.___Delegate4Object.Invoke(new object[]{___p1, ___p2});
                if (commonTypeConverter.IsUndefinedOrNuLL(___objreturn) == false)
                {
                    return commonTypeConverter.ConvertCLRValueToJavaValue(___objreturn, scope);
                }
                return ___objreturn;
            }

            return null;
        }
        /// <summary>
        /// function.apply() is to call function with parameter as array
        /// 
        /// </summary>
        /// <param name="___thisObj">this instance</param>
        /// <param name="___p1">Calling Parameter As Array</param>
        /// <returns>result array</returns>
        public object ___apply___inner(object ___thisObj, object ___p1)
        {
            if (commonLog.LoggingEnabled && commonLog.LogLevel >= 8)
            {
                commonLog.LogEntry("calling {0}.___apply__inner({1}, {2})", this.___functionName, ___thisObj, ___p1);
            }
            object[] ___p1Array = null;
            bool ___isParamConvetedArray = false;
            if (___p1 is org.mozilla.javascript.NativeArray)
            {
                org.mozilla.javascript.NativeArray ___p1NativeArray = ___p1 as org.mozilla.javascript.NativeArray;
                if (___p1NativeArray != null)
                {
                    ___p1Array = ___p1NativeArray.toArray();
                    ___isParamConvetedArray = true;
                }
            }
            if( ___isParamConvetedArray == false)
            {
                ___p1Array = new  object[]{};
            }
            org.mozilla.javascript.Scriptable scope = ___thisObj as org.mozilla.javascript.Scriptable;

            if (this.___Delegate4Object != null)
            {
                object ___objreturn = this.___Delegate4Object.Invoke( ___p1Array);
                if (commonTypeConverter.IsUndefinedOrNuLL(___objreturn) == false)
                {
                    return commonTypeConverter.ConvertCLRValueToJavaValue(___objreturn, scope);
                }
                return ___objreturn;
            }

            return null;
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
        public override void put(string ___name, Scriptable start, object ___value)
        {
            if (commonLog.LoggingEnabled && commonLog.LogLevel >= 10)
            {
                commonLog.LogEntry(this.toString() + " pub (" + ___name + ")");
            }
            base.put(___name, start, ___value);
        }
        public override object get(string ___name, Scriptable ___start)
        {
            object ___getresult = base.get(___name, ___start);
            if (___getresult == org.mozilla.javascript.UniqueTag.NOT_FOUND)
            {
                switch (___name)
                {
                    case "bind":
                        if (BaseFunctionDelegate.___bind_inner_Function == null)
                        {
                            java.lang.Class __thisClass = typeof(BaseFunctionDelegate);
                            /*
                            java.lang.Class[] callParams = new java.lang.Class[] { typeof(org.mozilla.javascript.Context), typeof(org.mozilla.javascript.Scriptable), typeof(org.mozilla.javascript.Scriptable), typeof(object[]) };
                            java.lang.reflect.Method callInnerMethod = __thisClass.getMethod("___call___inner", callParams);
                             */
                            java.lang.Class[] bindParams = new java.lang.Class[] { typeof(object), typeof(object), typeof(object) };
                            java.lang.reflect.Method bindInnerMethod = __thisClass.getMethod("___bind___inner", bindParams);

                            BaseFunctionDelegate.___bind_inner_Function = new FunctionObject("bind", bindInnerMethod, this);
                        }
                        return BaseFunctionDelegate.___bind_inner_Function;
                    case "call":
                        // 
                        if (BaseFunctionDelegate.___call_inner_Function  == null)
                        {
                            java.lang.Class __thisClass = typeof(BaseFunctionDelegate);
                            /*
                            java.lang.Class[] callParams = new java.lang.Class[] { typeof(org.mozilla.javascript.Context), typeof(org.mozilla.javascript.Scriptable), typeof(org.mozilla.javascript.Scriptable), typeof(object[]) };
                            java.lang.reflect.Method callInnerMethod = __thisClass.getMethod("___call___inner", callParams);
                             */
                            java.lang.Class[] callParams = new java.lang.Class[] { typeof(object), typeof(object), typeof(object) };
                            java.lang.reflect.Method callInnerMethod = __thisClass.getMethod("___call___inner", callParams);

                            BaseFunctionDelegate.___call_inner_Function = new FunctionObject("call", callInnerMethod, this);
                        }
                        return BaseFunctionDelegate.___call_inner_Function;
                    case "apply":
                        if (BaseFunctionDelegate.___apply_inner_Function  == null)
                        {
                            java.lang.Class __thisClass = typeof(BaseFunctionDelegate);
                            /*
                            java.lang.Class[] callParams = new java.lang.Class[] { typeof(org.mozilla.javascript.Context), typeof(org.mozilla.javascript.Scriptable), typeof(org.mozilla.javascript.Scriptable), typeof(object[]) };
                            java.lang.reflect.Method callInnerMethod = __thisClass.getMethod("___call___inner", callParams);
                             */
                            java.lang.Class[] callParams = new java.lang.Class[] { typeof(object), typeof(object)};
                            java.lang.reflect.Method callInnerMethod = __thisClass.getMethod("___apply___inner", callParams);

                            BaseFunctionDelegate.___apply_inner_Function = new FunctionObject("apply", callInnerMethod, this);
                        }
                        return BaseFunctionDelegate.___apply_inner_Function;
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
                    case "isNamespace":
                        return false;
                        
                    default:
                        if (commonLog.LoggingEnabled && commonLog.LogLevel >= 10)
                        {
                            commonLog.LogEntry(this.toString() + " " + this.___functionName + " get (" + ___name + ") may be failed.");
                        }
                        break;


                }
                
            }
            return ___getresult;
        }
        public object apply(object ___p1, object ___p2)
        {
            if (commonLog.LoggingEnabled && commonLog.LogLevel >= 10)
            {
                commonLog.LogEntry("Strange {0}.apply({1}, {2}) is called ignored...." , this, ___p1, ___p2);
            }
            return null;
        }
    }
}
