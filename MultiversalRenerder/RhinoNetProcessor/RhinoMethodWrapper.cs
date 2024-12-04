using System;
using org.mozilla.javascript;
using System.Diagnostics;
/*
using org.mozilla.javascript.Context;
using org.mozilla.javascript.Function;
using org.mozilla.javascript.NativeJavaMethod;
using org.mozilla.javascript.Scriptable;
 */
namespace MultiversalRenderer.RhinoNetProcessor
{


public class RhinoMethodWrapFunction : Function {
    private NativeJavaMethod method;
    public RhinoMethodWrapFunction(NativeJavaMethod method)
    {
        this.method = method;
    }
    public bool hasInstance(Scriptable instance) {
        return method.hasInstance(instance);
    }

    public Object call(Context cx, Scriptable scope, Scriptable thisObj, Object[] args) 
    {
      
        if (commonLog.LoggingEnabled && commonLog.LogLevel >= 10)
        {
            string funcName = method.getFunctionName();
            commonLog.LogEntry(string.Concat("calling : ", thisObj, " ", funcName));
        }
        /*
        if (funcName != null && funcName.Length == 8 && string.Equals(funcName, "toString", StringComparison.Ordinal) == true && thisObj is MultiversalWrapperObject)
        {
            // we do not want direct .net ToString() Method
            MultiversalWrapperObject wrapperObj = (MultiversalWrapperObject)thisObj;
            ICommonObjectInterface interfacedObject = wrapperObj.unwrap() as ICommonObjectInterface;
            if (interfacedObject != null)
            {
                // Javascript toString() will returns "[object HTMLDocument]" for DOM
                return JS_OBJECT_TYPE_HEADER + interfacedObject.multiversalClassType.ToString() + "]";
            }
        }
         * */
        

        Object ret =null;

        ret = method.call(cx, scope, thisObj, args);
        if (ret is MultiversalRenderer.RhinoNetProcessor.MultiversalWrapperObject)
        {
            return ret;
        }
      
        if (ret == null)
        {
            //org.mozilla.javascript.Undefined.instance;
            return null;
        }
        if (ret is NativeJavaObject)
        {
            try
            {
                NativeJavaObject javaResult = ret as NativeJavaObject;
                if (javaResult != null)
                {
                    object unwrappedObject = javaResult.unwrap();
                    //Utils.Log("Unwrapped Result : {0}", ret);
                    if (unwrappedObject != null)
                    {
                 
                        return commonTypeConverter.ConvertCLRValueToJavaValue(unwrappedObject, scope);
                    }
                    else
                    {

                        return org.mozilla.javascript.Undefined.instance; // this is just test.
                    }
                }
                else
                {
                    //return null;
                }
            }
            catch (Exception ex)
            {
                if (commonLog.LoggingEnabled && commonLog.LogLevel > 15)
                {
                    commonLog.LogEntry("Call Convert Error {0} {1} Ret {2}", ex.Message, method, ret);
                }
            }
        }
        return ret;
    }
    public bool has(int index, Scriptable start) {
        if (commonLog.LoggingEnabled && commonLog.LogLevel > 100)
        {
            commonLog.LogEntry("has: {0}", index);
        }
        return method.has(index, start);
    }
    public Scriptable construct(Context cx, Scriptable scope, Object[] args) {
        if (commonLog.LoggingEnabled && commonLog.LogLevel > 100)
        {
            commonLog.LogEntry("construct: {0}", scope);
        }
        return method.construct(cx, scope, args);
    }
    public void put(int index, Scriptable start, Object value) {
        if (commonLog.LoggingEnabled && commonLog.LogLevel > 100)
        {
            commonLog.LogEntry("put: {0}", index );
        }
        method.put(index, start, value);
    }
    public void delete(int index) {
        if (commonLog.LoggingEnabled && commonLog.LogLevel > 100)
        {
            commonLog.LogEntry("delete: {0}", index);
        }
        method.delete(index);
    }
    public Scriptable createObject(Context cx, Scriptable scope) {
        if (commonLog.LoggingEnabled && commonLog.LogLevel > 100)
        {
            commonLog.LogEntry("createObject: {0}", scope);
        }
        return method.createObject(cx, scope);
    }
    public bool has(String name, Scriptable start) {
        if (commonLog.LoggingEnabled && commonLog.LogLevel > 15)
        {
            commonLog.LogEntry("Has method: {0}", name);
        }
        return method.has(name, start);
    }
    public void defineConst(String name, Scriptable start) {
        method.defineConst(name, start);
    }

    public void put(String name, Scriptable start, Object value)
    {

        StackTrace stackTrace = new StackTrace();           // get call stack
        // get method calls (frames)

        if (commonLog.LoggingEnabled && commonLog.LogLevel >= 30)
        {
            commonLog.LogEntry("Interceptor put method: {0}, {1}, {2}", name, start, value);
            // write call stack method names
        }
        if (name.Length == 4 && stackTrace.FrameCount >= 16)
        {
            if (string.Equals(name, "guid", StringComparison.Ordinal) == true)
            {
                if (commonLog.LoggingEnabled && commonLog.LogLevel >= 10)
                {
                    commonLog.LogEntry("Interceptor illgal put('guid', function) abort.");
                    // write call stack method names
                }
                return;
            }
        }
        if (stackTrace.FrameCount >= 100)
        {


            if (commonTypeConverter.PeformStackFrameAnaysis(name) > 30)
            {
                return;
            }

        }
        

        method.put(name, start, value);
    }
    
    public override bool Equals(object obj)
    {
           return base.Equals(obj);
    }
    
    public override int GetHashCode()
    {
        return base.GetHashCode();
    }
    
    
    public void delete(String name) {
        method.delete(name);
    }
    
    public Scriptable getPrototype() {
        return method.getPrototype();
    }
    public void setPrototype(Scriptable m) {
        if (commonLog.LoggingEnabled && commonLog.LogLevel > 100)
        {
            commonLog.LogEntry("setProptype: {0}", m);
        }
        method.setPrototype(m);
    }
    public Scriptable getParentScope() {
        if (commonLog.LoggingEnabled && commonLog.LogLevel > 100)
        {
            commonLog.LogEntry("getParentScope()");
        }
        return method.getParentScope();
    }
    public void setParentScope(Scriptable m) {
        if (commonLog.LoggingEnabled && commonLog.LogLevel > 100)
        {
            commonLog.LogEntry("setParentScope()",m);
        }
        method.setParentScope(m);
    }
    public Object[] getIds() {
        if (commonLog.LoggingEnabled && commonLog.LogLevel > 100)
        {
            commonLog.LogEntry("getParentScope()");
        }

        return method.getIds();
    }

    public Object get(int index, Scriptable start) {
        if (commonLog.LoggingEnabled && commonLog.LogLevel > 100)
        {
            commonLog.LogEntry("get by index : {0}", index);
        }
        return method.get(index, start);
    }
    public Object get(String name, Scriptable start) {
        if (commonLog.LoggingEnabled && commonLog.LogLevel > 100)
        {
            commonLog.LogEntry("get : {0}", name);
        }
       
        return method.get(name, start);
    }
    public String getClassName() {
        if (commonLog.LoggingEnabled && commonLog.LogLevel > 100)
        {
            commonLog.LogEntry("getClassName()");
        }
        return method.getClassName();
    }
    public Object getDefaultValue(java.lang.Class typeHint) {
        if (commonLog.LoggingEnabled && commonLog.LogLevel > 15)
        {
            commonLog.LogEntry("getDefaultValue({0})", typeHint);
        }
        return method.getDefaultValue(typeHint);
    }
    
}
}
