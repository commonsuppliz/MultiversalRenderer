using System;
using System.Collections;
using System.Collections.Generic;
using org.mozilla.javascript;
using MultiversalRenderer.Interfaces;


namespace MultiversalRenderer.RhinoNetProcessor
{
    
    public sealed class RhinoWrapFactory : WrapFactory
    {
        //private System.Collections.Hashtable  _TypeTable = new  Hashtable();
        public static System.Collections.Generic.Dictionary<System.RuntimeTypeHandle, RhinoNetProcessor.commonTypeConverter.NodeHandler> wrapObjectTypeSwitcher = createWrapSwitcher();
        public static System.Collections.Generic.Dictionary<System.RuntimeTypeHandle, RhinoNetProcessor.commonTypeConverter.NodeHandler> createWrapSwitcher()
        {
            System.Collections.Generic.Dictionary<System.RuntimeTypeHandle, RhinoNetProcessor.commonTypeConverter.NodeHandler> list = new Dictionary<RuntimeTypeHandle, commonTypeConverter.NodeHandler>();
            list[typeof(org.mozilla.javascript.Scriptable).TypeHandle] = new commonTypeConverter.NodeHandler(wrapNonConverter);
            list[typeof(string).TypeHandle] = new commonTypeConverter.NodeHandler(wrapNonConverter);
            list[typeof(java.lang.String).TypeHandle] = new commonTypeConverter.NodeHandler(wrapNonConverter);
            list[typeof(System.String).TypeHandle] = new commonTypeConverter.NodeHandler(wrapNonConverter);
            list[typeof(org.mozilla.javascript.ConsString).TypeHandle] = new commonTypeConverter.NodeHandler(wrapNonConverter);
            list[typeof(org.mozilla.javascript.UniqueTag).TypeHandle] = new commonTypeConverter.NodeHandler(wrapNonConverter);
            list[typeof(org.mozilla.javascript.Undefined).TypeHandle] = new commonTypeConverter.NodeHandler(wrapNonConverter);
            list[typeof(bool).TypeHandle] = new commonTypeConverter.NodeHandler(wrapNonConverter);
            list[typeof(java.lang.Boolean).TypeHandle] = new commonTypeConverter.NodeHandler(wrapNonConverter);
            list[typeof(org.mozilla.javascript.LazilyLoadedCtor).TypeHandle] = new commonTypeConverter.NodeHandler(wrapNonConverter);
            list[typeof(org.mozilla.javascript.NativeObject).TypeHandle] = new commonTypeConverter.NodeHandler(wrapNonConverter);
            list[typeof(org.mozilla.javascript.UintMap).TypeHandle] = new commonTypeConverter.NodeHandler(wrapNonConverter);
            list[typeof(org.mozilla.javascript.xml.XMLObject).TypeHandle] = new commonTypeConverter.NodeHandler(wrapNonConverter);
            list[typeof(org.mozilla.javascript.xml.XMLLib.Factory).TypeHandle] = new commonTypeConverter.NodeHandler(wrapNonConverter);
            list[typeof(org.mozilla.javascript.xmlimpl.XMLLibImpl).TypeHandle] = new commonTypeConverter.NodeHandler(wrapNonConverter);
            list[typeof(org.mozilla.javascript.v8dtoa.FastDtoa).TypeHandle] = new commonTypeConverter.NodeHandler(wrapNonConverter);
            list[typeof(org.mozilla.javascript.v8dtoa.CachedPowers).TypeHandle] = new commonTypeConverter.NodeHandler(wrapNonConverter);
            list[typeof(org.mozilla.javascript.Script).TypeHandle] = new commonTypeConverter.NodeHandler(wrapNonConverter);
            list[typeof(org.mozilla.javascript.NativeJavaClass).TypeHandle] = new commonTypeConverter.NodeHandler(wrapNonConverter);
           list[typeof(org.mozilla.javascript.NativeJSON).TypeHandle]= new commonTypeConverter.NodeHandler(wrapNonConverter);
            list[typeof(java.lang.Double).TypeHandle] = new commonTypeConverter.NodeHandler(wrapJavaLangDoubleConverter);
            // numeric type is below
            list[typeof(double).TypeHandle] = new commonTypeConverter.NodeHandler(RhinoNetProcessor.JavaTypeConverter.doubleConverter);
           // list[typeof(java.lang.Double).TypeHandle] = new commonTypeConverter.NodeHandler(Rhino.JavaTypeConverter.javaDouleConverter);
            list[typeof(int).TypeHandle] = new commonTypeConverter.NodeHandler(RhinoNetProcessor.JavaTypeConverter.intConverter);
            list[typeof(System.Int32).TypeHandle] = new commonTypeConverter.NodeHandler(RhinoNetProcessor.JavaTypeConverter.intConverter);
            list[typeof(uint).TypeHandle] = new commonTypeConverter.NodeHandler(RhinoNetProcessor.JavaTypeConverter.uintConverter);
            list[typeof(short).TypeHandle] = new commonTypeConverter.NodeHandler(RhinoNetProcessor.JavaTypeConverter.shortConverter);
            list[typeof(long).TypeHandle] = new commonTypeConverter.NodeHandler(RhinoNetProcessor.JavaTypeConverter.longConverter);
            list[typeof(float).TypeHandle] = new commonTypeConverter.NodeHandler(RhinoNetProcessor.JavaTypeConverter.floatConverter);
            list[typeof(System.Int16).TypeHandle] = new commonTypeConverter.NodeHandler(RhinoNetProcessor.JavaTypeConverter.intConverter);
            list[typeof(Int32).TypeHandle] = new commonTypeConverter.NodeHandler(RhinoNetProcessor.JavaTypeConverter.intConverter);
            list[typeof(Int64).TypeHandle] = new commonTypeConverter.NodeHandler(RhinoNetProcessor.JavaTypeConverter.int64Converter);
            list[typeof(ulong).TypeHandle] = new commonTypeConverter.NodeHandler(RhinoNetProcessor.JavaTypeConverter.ulongConverter);
            list[typeof(bool).TypeHandle] = new commonTypeConverter.NodeHandler(RhinoNetProcessor.JavaTypeConverter.booleanConverter);
            list[typeof(ushort).TypeHandle] = new commonTypeConverter.NodeHandler(RhinoNetProcessor.JavaTypeConverter.ushortConverter);
            list[typeof(byte).TypeHandle] = new commonTypeConverter.NodeHandler(RhinoNetProcessor.JavaTypeConverter.byteConverter);
            list[typeof(sbyte).TypeHandle] = new commonTypeConverter.NodeHandler(RhinoNetProcessor.JavaTypeConverter.sbyteConverter);
            list[typeof(System.Decimal).TypeHandle] = new commonTypeConverter.NodeHandler(RhinoNetProcessor.JavaTypeConverter.decimalConverter);
            list[typeof(System.IntPtr).TypeHandle] = new commonTypeConverter.NodeHandler(RhinoNetProcessor.JavaTypeConverter.intPtrConverter);
            list[typeof(System.UIntPtr).TypeHandle] = new commonTypeConverter.NodeHandler(RhinoNetProcessor.JavaTypeConverter.uIntPtrConverter);
            return list;
        }

        public static object wrapNonConverter(object o, Scriptable scope)
        {
            return o;
        }

        public static object wrapCharConverter(object obj, Scriptable scope)
        {
            char cvalue = (char)obj;
            return cvalue.ToString();
        }
        public static object wrapJavaLangDoubleConverter(object obj, Scriptable scope)
        {
            return obj;
        }

        public override Object wrap(Context cx, Scriptable scope, Object obj, java.lang.Class staticType)
        {
            if (obj != null)
            {
                commonTypeConverter.NodeHandler handler = null;
                if (wrapObjectTypeSwitcher.TryGetValue(obj.GetType().TypeHandle, out handler) == true)
                {
                    return handler(obj, null);
                }

                 if (obj is ICommonObjectInterface)
                 {
                     MultiversalWrapperObject interceptor = new MultiversalWrapperObject(scope, obj, staticType);
                     /*
                     try
                     {
                         interceptor.put("srcx", scope, interceptor);
                     }
                     catch (Exception ex)
                     {
                         Console.WriteLine(ex.Message);

                     }
                      */
                     return interceptor;
                 }
                    /*
                 else if ( obj is Scriptable || obj is string || obj is bool || obj is org.mozilla.javascript.ConsString || obj is java.lang.Boolean)
                {
                    return obj;
                }

                 else if (obj is char)
                 {
                     char cvalue = (char)obj;
                     return cvalue.ToString();
                 }
                 else if (obj is java.lang.Double)
                 {
                     return obj;
                 }
                 else if (commonLog.IsNumericType(ref obj))
                 {
                     java.lang.Double dr = new java.lang.Double(0);
                     try
                     {
                         dr = new java.lang.Double(System.Convert.ToDouble(obj));
                     }
                     catch (Exception)
                     {
                         if (commonLog.LoggingEnabled && commonLog.LogLevel > 5)
                         {
                             commonLog.LogEntry("java.lang.double convertion failed");
                         }

                     }
                     return dr;
                 }
                  */
                 else if (obj is System.Exception)
                 {
                     System.Exception objException = obj as System.Exception;
                     org.mozilla.javascript.JavaScriptException ___scriptException = new JavaScriptException(objException, "", -1);

                     return ___scriptException;
                 }
                 else if(obj is System.Array)
                 {
                     return commonTypeConverter.___convertCLRObjectArrayIntoScriptableNativeArray(obj, scope);

                 }
            }
            if (obj != null)
            {
                if (obj is IMultiversalScope)
                {
                    return obj;
                }
                return base.wrapAsJavaObject(cx, scope, obj, staticType);
            }
            else
            {
                return null;
            }
            // -------------------------------------
            // Orignal Wrapp
            // -------------------------------------
            // return new MultiversalWrapperObject(scope, obj, staticType);
        }

    }

  

}
