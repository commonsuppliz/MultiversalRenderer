using System;
using System.Collections.Generic;
using System.Text;
using org.mozilla.javascript;
using System.Diagnostics;
using MultiversalRenderer.Interfaces;

namespace MultiversalRenderer.RhinoNetProcessor
{
    public sealed class MultiversalWrapperObject : NativeJavaObject
    {
        public MultiversalWrapperObject()
        {
        }


        public MultiversalWrapperObject(Scriptable scope, Object javaObject,
        java.lang.Class staticType)
            : base(scope, javaObject, staticType)
        {
        }

        /*
        public static object jsConstructor(Context cx, Object[] args, Function functionObject, bool isNewExpr)
        {
            return new MultiversalWrapperObject();
            //return null;
        }
         */

        /*
           NativeJavaObject prototype;
        public MultiversalWrapperObject(Scriptable scope, Object javaObject,  java.lang.Class staticType):base(scope,  javaObject, staticType)
        {
                
                this.prototype = (NativeJavaObject) this.getPrototype();
        }*/
       

        public override object get(int index, Scriptable start)
        {

            if (commonLog.LoggingEnabled && commonLog.LogLevel > 10000)
            {


                commonLog.LogEntry("get by index('{0}') : {1}", index, start);

            }
            ICommonObjectInterface __ipropbox = base.javaObject as ICommonObjectInterface;
            if (__ipropbox != null)
            {
                object ret = __ipropbox.___getPropertyByIndex(index);
                if (ret != null)
                {
                    return commonTypeConverter.ConvertCLRValueToJavaValue(ret, start);
                }
                else
                {
                    // ===============================================================
                    // Note)
                    // Some Scripts may fail, if we returns 'null'. Use Undefinded
                    // ===============================================================
                    return org.mozilla.javascript.Undefined.instance;
                }
            }
            return base.get(index, start);
        }

        public override Object get(String ___name, Scriptable start)
        {

            Object res = base.get(___name, start);
            if (commonLog.LoggingEnabled && commonLog.LogLevel >= 1000)
            {
                commonLog.LogEntry("get('{0}', {1}) = {2}", ___name, start, res);
            }
            if (res is NativeJavaMethod)
            {
                NativeJavaMethod method = res as NativeJavaMethod;
                return new RhinoMethodWrapFunction(method);
            }
            if (res == org.mozilla.javascript.UniqueTag.NOT_FOUND &&
                base.javaObject is ICommonObjectInterface)
            {
                ICommonObjectInterface ___nativeObject = base.javaObject as ICommonObjectInterface;

                if (___nativeObject != null)
                {
                    object ret;
                    if (___name.Length == 12 && ___name[0] == '_' && string.Equals(___name, RhinoNetProcessor.InterceptorContextFactory.___rhinoiteratorName, StringComparison.Ordinal) == true)
                    {
                        MultiversalIteratorDelegate ___interatorDelegate = new MultiversalIteratorDelegate(___name);
                        ___interatorDelegate.___startObjectWeakReference = new WeakReference(start, false);
                        ___interatorDelegate.___targetObjectWeakReference = new WeakReference(___nativeObject, false);
                        return ___interatorDelegate;
                    }
                    ret = ___nativeObject.___getPropertyByName(___name);
                    if (ret == null || ( ret != null && ___name.Length == 16 && ___name[0] == '_' && string.Equals(___name, "__noSuchMethod__", StringComparison.Ordinal) == true))
                    {
                        return org.mozilla.javascript.Undefined.instance;
                    }
                    //object ret = base.javaObject.GetType().GetProperty(name).GetValue(base.javaObject, null);

                    return commonTypeConverter.ConvertCLRValueToJavaValue(ret, start);
                }
            }
            else if (res is ICommonObjectInterface)
            {
                if (commonLog.LoggingEnabled && commonLog.LogLevel > 50)
                {
                    commonLog.LogEntry("may needs to convert? : {0}", res);
                }
            }
            return res;
        }
        /*
        public int current = 0;
        [org.mozilla.javascript.annotations.JSFunction]
        public int next()
        {
            Utils.Log("{0} next()  {1}", this, current);
            ++current;
            if (current > 100)
            {
                throw new JavaScriptException(
                        NativeIterator.getStopIterationObject(getParentScope()), null, 0);
            }
            return current;
        }
         */
        public override void put(int index, Scriptable start, object value)
        {
            if (commonLog.LoggingEnabled && commonLog.LogLevel > 500)
            {
                commonLog.LogEntry("enter put by index: {0} {1}", index, value);
            }
            if (base.javaObject is ICommonObjectInterface && base.javaObject != null)
            {
                ICommonObjectInterface __iproperybox = base.javaObject as ICommonObjectInterface;
                __iproperybox.___setPropertyByIndex(index, value);
                return;
            }
            base.put(index, start, value);
        }

        public override void put(string name, Scriptable start, object value)
        {
            if (commonLog.LoggingEnabled && commonLog.LogLevel > 500)
            {
                commonLog.LogEntry("enter put : {0}", name);
            }
            if (base.javaObject is ICommonObjectInterface && base.javaObject != null)
            {
                //((IPropertBox)base.javaObject)._x__SetPropertyValue(name, value);
                ICommonObjectInterface __iproperybox = base.javaObject as ICommonObjectInterface;
                __iproperybox.___setPropertyByName(name, value);
                return;
            }
            base.put(name, start, value);
        }
        public override object[] getIds()
        {
            if (commonLog.LoggingEnabled && commonLog.LogLevel > 500)
            {
                commonLog.LogEntry("enter getids()");
            }
            return base.getIds();
        }
        public override bool has(int index, Scriptable start)
        {
            if (commonLog.LoggingEnabled && commonLog.LogLevel > 500)
            {
                commonLog.LogEntry("enter has({0}, {1})", index, start);
            }
            bool b = base.has(index, start);
            if (b == false)
            {
                if (base.javaObject is ICommonObjectInterface)
                {
                    ICommonObjectInterface __iproperybox = base.javaObject as ICommonObjectInterface;
                    return __iproperybox.___hasPropertyByIndex(index);
                }
            }
            return b;
        }
        public override object getDefaultValue(java.lang.Class hint)
        {
            if (commonLog.LoggingEnabled && commonLog.LogLevel > 500)
            {
                commonLog.LogEntry("enter getDefaultValue({0})", hint);
            }
            return base.getDefaultValue(hint);
        }
        private const string RHINO_ITERATOR_OBJECT_NAME = "__iterator__";

        public override bool has(string name, Scriptable start)
        {
            if (commonLog.LoggingEnabled && commonLog.LogLevel > 500)
            {
                commonLog.LogEntry("enter has({0})", name);
            }
            bool b = base.has(name, start);
            if (b == false)
            {
                if (base.javaObject is ICommonObjectInterface)
                {
                    if (name.Length == 12 && name[0] == '_' && string.Equals(name, RHINO_ITERATOR_OBJECT_NAME, StringComparison.OrdinalIgnoreCase) == true)
                    {
                        return true;
                    }
                    ICommonObjectInterface __iproperybox = base.javaObject as ICommonObjectInterface;
                    return __iproperybox.___hasPropertyByName(name);
                }
            }
            return b;
        }
        public override void delete(string name)
        {
            if (commonLog.LoggingEnabled && commonLog.LogLevel > 500)
            {
                commonLog.LogEntry("enter delete({0})", name);
            }
            base.delete(name);
        }

        public override void delete(int index)
        {
            if (commonLog.LoggingEnabled && commonLog.LogLevel > 500)
            {
                commonLog.LogEntry("enter delete({0})", index);
            }
            base.delete(index);
        }
        public override Scriptable getPrototype()
        {
            if (commonLog.LoggingEnabled && commonLog.LogLevel >= 50)
            {
                commonLog.LogEntry("enter getProtoType()");
            }

            return base.getPrototype();
        }
        /*
        protected override void GetObjectData(System.Runtime.Serialization.SerializationInfo __value1, System.Runtime.Serialization.StreamingContext __value2)
        {
            if (commonLog.LoggingEnabled && commonLog.LogLevel > 500)
            {
                commonLog.LogEntry("enter getObjectData()");
            }
            base.GetObjectData(__value1, __value2);
        }
        */
        public override bool equals(object obj)
        {
            if (commonLog.LoggingEnabled && commonLog.LogLevel > 500)
            {
                commonLog.LogEntry("enter equals()");
            }
            return base.equals(obj);
        }
        public override string getClassName()
        {
            return base.getClassName();
        }



        public JavaScriptException __getStopIteratin()
        {
            Context cx = Context.getCurrentContext();
            Scriptable scope = cx.initStandardObjects();
            return new JavaScriptException(
                NativeIterator.getStopIterationObject(scope), null, 0);
        }




    }
}
