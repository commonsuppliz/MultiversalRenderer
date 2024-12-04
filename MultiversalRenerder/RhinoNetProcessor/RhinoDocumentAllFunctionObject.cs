using System;
using System.Collections.Generic;
using System.Text;
using org.mozilla.javascript;
using MultiversalRenderer.Interfaces;

namespace MultiversalRenderer.RhinoNetProcessor
{
    public class RhinoDocumentAllFunctionObject : org.mozilla.javascript.BaseFunction 
    {
        internal System.Collections.ArrayList  ___innerCollection = new System.Collections.ArrayList();
        internal string ___functionName = "all";
        internal static org.mozilla.javascript.BaseFunction ___tagsFunction = null;
        internal static org.mozilla.javascript.BaseFunction ___itemFunction = null;
        internal static System.Collections.Generic.Dictionary<System.RuntimeTypeHandle, ___filterConverter> ___itemFunctionSwitcher = ___createitemFunctionSwitcher();
        public delegate MultiversalRenderer.Interfaces.ICHtmlElementInterface  ___filterConverter(object ___filter, RhinoDocumentAllFunctionObject ___thisObject);
        public static System.Collections.Generic.Dictionary<System.RuntimeTypeHandle, ___filterConverter> ___createitemFunctionSwitcher()
        {
            System.Collections.Generic.Dictionary<System.RuntimeTypeHandle, ___filterConverter> ___list = new Dictionary<RuntimeTypeHandle, ___filterConverter>();
            ___list[typeof(double).TypeHandle] = new ___filterConverter(____filterElementByNumber);
            ___list[typeof(int).TypeHandle] = new ___filterConverter(____filterElementByNumber);
            ___list[typeof(float).TypeHandle] = new ___filterConverter(____filterElementByNumber);
            ___list[typeof(short).TypeHandle] = new ___filterConverter(____filterElementByNumber);
            ___list[typeof(decimal).TypeHandle] = new ___filterConverter(____filterElementByNumber);
            ___list[typeof(uint).TypeHandle] = new ___filterConverter(____filterElementByNumber);
            ___list[typeof(java.lang.Double).TypeHandle] = new ___filterConverter(____filterElementByNumber);
            ___list[typeof(string).TypeHandle] = new ___filterConverter(____filterElementByString);
            ___list[typeof(org.mozilla.javascript.ConsString).TypeHandle] = new ___filterConverter(____filterElementByString);

            return ___list;
        }
        public RhinoDocumentAllFunctionObject tags(object ___obj)
        {
            string ___strFilter = commonTypeConverter.getStringValue(___obj);
            RhinoDocumentAllFunctionObject ___tagsResult = new RhinoDocumentAllFunctionObject();
            ___tagsResult.___innerCollection.AddRange(this.___innerCollection as System.Collections.ICollection);
            if (string.IsNullOrEmpty(___strFilter) == false)
            {
                int ___currentElementCount = ___tagsResult.___innerCollection.Count;
                for (int i = ___currentElementCount - 1; i >= 0; i--)
                {
                    ICHtmlElementInterface ___elem = ___tagsResult.___innerCollection[i] as ICHtmlElementInterface;
                    if (___elem != null)
                    {
                        if (string.Equals(___elem.tagName, ___strFilter, StringComparison.OrdinalIgnoreCase) == false)
                        {
                            ___tagsResult.___innerCollection.RemoveAt(i);
                            continue;
                        }
                    }
                }

            }
            return ___tagsResult;
        }
        public ICHtmlElementInterface  item(object ___objFilter)
        {
            if (___objFilter != null)
            {
                ___filterConverter ___filter = null;
                if (___itemFunctionSwitcher.TryGetValue(___objFilter.GetType().TypeHandle, out ___filter) == true)
                {
                    return ___filter(___objFilter, this);
                }
            }
            return null;
        }
        private static ICHtmlElementInterface ____filterElementByString(object ___objFillter, RhinoDocumentAllFunctionObject ___thisObj)
        {
            if (commonLog.LoggingEnabled && commonLog.LogLevel >= 10)
            {
                commonLog.LogEntry("entering document.____filterElementByString({0}) by string.", ___objFillter);
            }
            string strFilter = commonTypeConverter.getStringValue(___objFillter);
            if (string.IsNullOrEmpty(strFilter) == false)
            {
                int __collectionItemCount = ___thisObj.___innerCollection.Count;
                for (int i = 0; i < __collectionItemCount; i++)
                {
                    ICHtmlElementInterface ___elem = ___thisObj.___innerCollection[i] as ICHtmlElementInterface;
                    if (___elem != null)
                    {
                        if (string.Equals(___elem.id, strFilter, StringComparison.OrdinalIgnoreCase) == true || string.Equals(___elem.name, strFilter, StringComparison.OrdinalIgnoreCase) == true)
                        {
                            if (commonLog.LoggingEnabled && commonLog.LogLevel >= 10)
                            {
                                commonLog.LogEntry("calling document.all.____filterElementByString({0}) found {1}.", strFilter, ___elem);
                            }
                            return ___elem;
                        }
                        else
                        {
                            continue;
                        }
                    }
                }

            }
            if (commonLog.LoggingEnabled && commonLog.LogLevel >= 10)
            {
                commonLog.LogEntry("calling document.all.____filterElementByString({0}) cound not find element... returns null.", strFilter);
            }

            return null;

        }
        private static ICHtmlElementInterface ____filterElementByNumber(object ___objFillter, RhinoDocumentAllFunctionObject ___thisObj)
        {

            int ___index = (int)commonTypeConverter.getDoubleValue(___objFillter);
            if (commonLog.LoggingEnabled && commonLog.LogLevel >= 10)
            {
                commonLog.LogEntry("calling document.all.item({0}) by number.", ___index);
            }
            return ___thisObj.___getByIndex(___index);
        }
        private ICHtmlElementInterface  ___getByIndex(int ___index)
        {
            if (___index >= 0 && ___index < this.___innerCollection.Count)
            {
                return this.___innerCollection[___index] as ICHtmlElementInterface;
            }
            else
            {
                return null;
            }

        }
        private java.lang.Double ___getLength()
        {
            int ___len = this.___innerCollection.Count;
            return new java.lang.Double((double)___len);
        }
        public override object get(string ___name, org.mozilla.javascript.Scriptable start)
        {
            if (commonLog.LoggingEnabled && commonLog.LogLevel >= 10)
            {
                commonLog.LogEntry("entering document.get({0})...", ___name);
            }
            switch (___name)
            {
                case "length":
                    return ___getLength();
                case "tags":
                    if (RhinoDocumentAllFunctionObject.___tagsFunction == null)
                    {
                        java.lang.Class __thisClass = typeof(RhinoDocumentAllFunctionObject);
                        java.lang.Class[] callParams1 = new java.lang.Class[] { typeof(object) };
                        java.lang.reflect.Method tagsMethod = __thisClass.getMethod("tags", callParams1);
                        RhinoDocumentAllFunctionObject.___tagsFunction = new FunctionObject("tags", tagsMethod, this);
                    }
                    return RhinoDocumentAllFunctionObject.___tagsFunction;
                case "item":
                    if (RhinoDocumentAllFunctionObject.___itemFunction == null)
                    {
                        java.lang.Class __thisClass = typeof(RhinoDocumentAllFunctionObject);
                        java.lang.Class[] callParams2 = new java.lang.Class[] { typeof(object) };
                        java.lang.reflect.Method itemMethod = __thisClass.getMethod("item", callParams2);
                        RhinoDocumentAllFunctionObject.___itemFunction = new FunctionObject("item", itemMethod, this);
                    }
                    return RhinoDocumentAllFunctionObject.___itemFunction;


            }
            return RhinoDocumentAllFunctionObject.____filterElementByString(___name, this);

        }

        public override object call(Context cx, Scriptable scope, Scriptable thisObj, object[] args)
        {
            if (commonLog.LoggingEnabled && commonLog.LogLevel >= 10)
            {
                commonLog.LogEntry("entering document.all({0})...", args);
            }
            if (args != null)
            {
                switch (args.Length)
                {
                    case 1:
                        if (commonTypeConverter.isClrNumeric(args[0]) == true || args[0] is java.lang.Double)
                        {
                            int ___index = (int)commonTypeConverter.getDoubleValue(args[0]);
                            return this.___getByIndex(___index);
                        }
                        else if (args[0] is string || args[0] is org.mozilla.javascript.ConsString)
                        {
                            string ___strFilter = commonTypeConverter.getStringValue(args[0]);
                            return RhinoDocumentAllFunctionObject.____filterElementByString(___strFilter, this);
                        }
                        else
                        {
                            if (commonLog.LoggingEnabled && commonLog.LogLevel >= 10)
                            {
                                commonLog.LogEntry("TODO:  document.all({0}) needs more handle...", args);
                            }
                        }
                        break;
                    default:
                        if (commonLog.LoggingEnabled && commonLog.LogLevel >= 10)
                        {
                            commonLog.LogEntry("TODO:  document.all({0}) needs more handle...", args);
                        }
                        break;
                }
            }
            return base.call(cx, scope, thisObj, args);
        }
        public override string getFunctionName()
        {
            return this.___functionName;
        }
    }
}
