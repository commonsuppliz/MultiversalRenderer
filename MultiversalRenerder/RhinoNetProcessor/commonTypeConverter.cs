using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using org.mozilla.javascript;
using MultiversalRenderer.Interfaces;

namespace MultiversalRenderer.RhinoNetProcessor
{
    public static class commonTypeConverter
    {
        public static org.mozilla.javascript.Function ___iterator___Function = null;
        public static object ConvertInterceptNativeObjectToCLRObject(MultiversalRenderer.RhinoNetProcessor.MultiversalWrapperObject __object)
        {
            MultiversalRenderer.RhinoNetProcessor.MultiversalWrapperObject __interceptObject = __object as MultiversalRenderer.RhinoNetProcessor.MultiversalWrapperObject;
            if (__interceptObject != null)
            {
                return __interceptObject.unwrap();
            }
            return null;

        }
        public static string Multiversal_Rhino_Name = "rhino.net";


        public static Scriptable ___convertCLRObjectArrayIntoScriptableNativeArray(object netValue, Scriptable scope)
        {
            Context ___context = Context.getCurrentContext();
            object objFirst = null;
            int objLen = -1;
            object[] objArray = null;
            try
            {
                if (netValue is object[])
                {
                    objArray = (object[])netValue;
                    objLen = objArray.Length;
                    if (objArray != null && objLen > 0)
                    {
                        objLen = objArray.Length;
                        objFirst = objArray[0];
                        if (isClrNumeric(objFirst))
                        {
                            return ___context.newArray(scope, objArray);
                        }
                        else if (objFirst is string)
                        {


                            org.mozilla.javascript.Scriptable newArray = ___context.newArray(scope, objLen);
                            for (int i = 0; i < objLen; i++)
                            {
                                newArray.put(i, newArray, ___convertStringToString(objArray[i]));
                            }
                            return newArray;
                            //return org.mozilla.javascript.ScriptRuntime.newArrayLiteral(objJavaArray, null, ___context, scope);


                        }
                        else if (isJavaLangReflectConstructor(objFirst) == true)
                        {

                            org.mozilla.javascript.Scriptable newArray = ___context.newArray(scope, objLen);
                            for (int i = 0; i < objLen; i++)
                            {

                                newArray.put(i, newArray, ConvertCLRValueToJavaValue(objArray[i], scope));
                            }
                            return newArray;
                        }
                        else
                        {
                            return ___context.newArray(scope, objArray);
                        }
                    }
                    else
                    {
                        if (isJavaSecurityPricipalObjectType(netValue))
                        {
                            if (commonLog.LoggingEnabled && commonLog.LogLevel >= 3)
                            {

                                commonLog.LogEntry("strange....___convertCLRObjectIntoScriptableNativeArray() has java.security.principal object and length is zero... returning null instead...");


                            }
                            //org.mozilla.javascript.Scriptable newArray = ___context.newArray(scope, 0);
                            return null;

                        }

                        return ___context.newArray(scope, objArray);
                    }
                }
                else
                {
                    org.mozilla.javascript.Scriptable newArray = ___context.newArray(scope, objLen);
                    if (isClrNumeric(objFirst) == true)
                    {
                        for (int i = 0; i < objLen; i++)
                        {

                            newArray.put(i, newArray, ConvertCLRValueToJavaValue(objArray[i], scope));
                        }
                    }
                    else
                    {
                        for (int i = 0; i < objLen; i++)
                        {

                            newArray.put(i, newArray, objArray[i]);
                        }
                    }
                    return newArray;

                }
            }
            catch (Exception exArrayConversion)
            {
                if (commonLog.LoggingEnabled && commonLog.LogLevel >= 3)
                {
                    if (objFirst != null)
                    {
                        commonLog.LogEntry(string.Format("___convertCLRObjectIntoScriptableNativeArray() has exception... 1st:{0} len:{1} Message:{2}"), objFirst, objLen, exArrayConversion.Message);
                    }
                    else
                    {

                        commonLog.LogEntry("___convertCLRObjectIntoScriptableNativeArray() has exception...", exArrayConversion);
                    }
                }


            }
            try
            {
                if (objArray != null)
                {
                    return ___context.newArray(scope, objArray);
                }

            }
            catch
            {
                if (commonLog.LoggingEnabled && commonLog.LogLevel >= 3)
                {
                    commonLog.LogEntry("___convertCLRObjectIntoScriptableNativeArray() finall retry has exeption...return null....");
                }

            }
            return null;

        }
        public static void CreateIteratorFunction(Context cxt, Scriptable scope)
        {
            if (commonTypeConverter.___iterator___Function == null)
            {
                string strIteratorJS = "function(){return new MediatorIterator(this);}";
                commonTypeConverter.___iterator___Function = cxt.compileFunction(scope, strIteratorJS, "", 1, null);
            }
        }

        public static bool IsUndefined(object ___object)
        {
            if (___object is org.mozilla.javascript.Undefined)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool IsUndefinedOrNuLL(object ___object)
        {
            if (___object is org.mozilla.javascript.Undefined)
            {
                return true;
            }
            else
            {
                if (___object == null)
                {
                    return true;
                }
                return false;
            }
        }
        private delegate double doubleHandler(object ___val);
        private static System.Collections.Generic.Dictionary<System.RuntimeTypeHandle, doubleHandler> ___doubleSwither = ___createDoubleSwither();
        private static System.Collections.Generic.Dictionary<System.RuntimeTypeHandle, doubleHandler> ___createDoubleSwither()
        {
            System.Collections.Generic.Dictionary<System.RuntimeTypeHandle, doubleHandler> list = new System.Collections.Generic.Dictionary<RuntimeTypeHandle, doubleHandler>();
            list[typeof(double).TypeHandle] = new doubleHandler(___convertSystemDoubleToDouble);
            list[typeof(int).TypeHandle] = new doubleHandler(___convertSystemIntegerToDouble);
            list[typeof(uint).TypeHandle] = new doubleHandler(___convertUInitToDouble);
            list[typeof(ushort).TypeHandle] = new doubleHandler(___convertUshortToDouble);
            list[typeof(short).TypeHandle] = new doubleHandler(___convertShortToDouble);
            list[typeof(long).TypeHandle] = new doubleHandler(___convertLongToDouble);
            list[typeof(ulong).TypeHandle] = new doubleHandler(___convertUlongToDouble);
            list[typeof(byte).TypeHandle] = new doubleHandler(___convertByteToDouble);
            list[typeof(sbyte).TypeHandle] = new doubleHandler(___convertSbyteToDouble);
            list[typeof(decimal).TypeHandle] = new doubleHandler(___convertDecimalToDouble);
            list[typeof(System.IntPtr).TypeHandle] = new doubleHandler(___convertSystemIntPtrToDouble);
            list[typeof(java.lang.Double).TypeHandle] = new doubleHandler(___convertJavaLangDoubleToDouble);

            return list;
        }
        private static double ___convertSystemDoubleToDouble(object ___val)
        {
            double d = (double)___val;
            return d;
        }
        private static double ___convertSystemIntegerToDouble(object ___val)
        {
            int i = (int)___val;
            return (double)i;
        }
        private static double ___convertUInitToDouble(object ___val)
        {
            uint i = (uint)___val;
            return (double)i;
        }
        private static double ___convertLongToDouble(object ___val)
        {
            long i = (long)___val;
            return (double)i;
        }
        private static double ___convertUlongToDouble(object ___val)
        {
            ulong i = (ulong)___val;
            return (double)i;
        }

        private static double ___convertShortToDouble(object ___val)
        {
            short i = (short)___val;
            return (double)i;
        }
        private static double ___convertUshortToDouble(object ___val)
        {
            ushort i = (ushort)___val;
            return (double)i;
        }
        private static double ___convertByteToDouble(object ___val)
        {
            byte i = (byte)___val;
            return (double)i;
        }
        private static double ___convertSbyteToDouble(object ___val)
        {
            sbyte i = (sbyte)___val;
            return (double)i;
        }
        private static double ___convertDecimalToDouble(object ___val)
        {
            decimal i = (decimal)___val;
            return (double)i;
        }
        private static double ___convertSystemIntPtrToDouble(object ___val)
        {
            System.IntPtr i = (System.IntPtr)___val;
            return (double)i.ToInt64();
        }
        private static double ___convertJavaLangDoubleToDouble(object ___val)
        {
            java.lang.Double i = (java.lang.Double)___val;
            return i.doubleValue();
        }
        public delegate string stringHandler(object ___val);
        private static System.Collections.Generic.Dictionary<System.RuntimeTypeHandle, stringHandler> ___stringSwitcher = ___createStringSwitcher();
        private static System.Collections.Generic.Dictionary<System.RuntimeTypeHandle, stringHandler> ___createStringSwitcher()
        {
            System.Collections.Generic.Dictionary<System.RuntimeTypeHandle, stringHandler> list = new System.Collections.Generic.Dictionary<System.RuntimeTypeHandle, stringHandler>();
            list[typeof(string).TypeHandle] = new stringHandler(___convertStringToString);
            list[typeof(org.mozilla.javascript.ConsString).TypeHandle] = new stringHandler(___convertOrgMozillaConStringToString);
            return list;
        }
        private static string ___convertStringToString(object ___val)
        {
            string s = ___val as string;
            return s;
        }
        private static string ___convertOrgMozillaConStringToString(object ___val)
        {
            org.mozilla.javascript.ConsString conString = ___val as org.mozilla.javascript.ConsString;
            return conString.toString();
        }


        public delegate object NodeHandler(object node, org.mozilla.javascript.Scriptable scope);
        public static System.Collections.Generic.Dictionary<System.RuntimeTypeHandle, NodeHandler> TypeHandleSwitcher =
     CreateSwitcher();
        public static System.Collections.Generic.Dictionary<System.RuntimeTypeHandle, NodeHandler> CreateSwitcher()
        {
            System.Collections.Generic.Dictionary<System.RuntimeTypeHandle, NodeHandler> ret =
              new System.Collections.Generic.Dictionary<System.RuntimeTypeHandle, NodeHandler>();
            ret[typeof(string).TypeHandle] = new NodeHandler(RhinoNetProcessor.JavaTypeConverter.stringConverter);
            ret[typeof(System.String).TypeHandle] = new NodeHandler(RhinoNetProcessor.JavaTypeConverter.stringConverter);
            ret[typeof(org.mozilla.javascript.ConsString).TypeHandle] = new NodeHandler(RhinoNetProcessor.JavaTypeConverter.stringConverter);
            ret[typeof(double).TypeHandle] = new NodeHandler(RhinoNetProcessor.JavaTypeConverter.doubleConverter);
            ret[typeof(java.lang.Double).TypeHandle] = new NodeHandler(RhinoNetProcessor.JavaTypeConverter.javaDouleConverter);
            ret[typeof(int).TypeHandle] = new NodeHandler(RhinoNetProcessor.JavaTypeConverter.intConverter);
            ret[typeof(System.Int32).TypeHandle] = new NodeHandler(RhinoNetProcessor.JavaTypeConverter.intConverter);
            ret[typeof(uint).TypeHandle] = new NodeHandler(RhinoNetProcessor.JavaTypeConverter.uintConverter);
            ret[typeof(short).TypeHandle] = new NodeHandler(RhinoNetProcessor.JavaTypeConverter.shortConverter);
            ret[typeof(long).TypeHandle] = new NodeHandler(RhinoNetProcessor.JavaTypeConverter.longConverter);
            ret[typeof(float).TypeHandle] = new NodeHandler(RhinoNetProcessor.JavaTypeConverter.floatConverter);
            ret[typeof(System.Int16).TypeHandle] = new NodeHandler(RhinoNetProcessor.JavaTypeConverter.intConverter);
            ret[typeof(Int32).TypeHandle] = new NodeHandler(RhinoNetProcessor.JavaTypeConverter.intConverter);
            ret[typeof(Int64).TypeHandle] = new NodeHandler(RhinoNetProcessor.JavaTypeConverter.int64Converter);
            ret[typeof(ulong).TypeHandle] = new NodeHandler(RhinoNetProcessor.JavaTypeConverter.ulongConverter);
            ret[typeof(bool).TypeHandle] = new NodeHandler(RhinoNetProcessor.JavaTypeConverter.booleanConverter);
            ret[typeof(ushort).TypeHandle] = new NodeHandler(RhinoNetProcessor.JavaTypeConverter.ushortConverter);
            ret[typeof(byte).TypeHandle] = new NodeHandler(RhinoNetProcessor.JavaTypeConverter.byteConverter);
            ret[typeof(sbyte).TypeHandle] = new NodeHandler(RhinoNetProcessor.JavaTypeConverter.sbyteConverter);
            ret[typeof(System.Decimal).TypeHandle] = new NodeHandler(RhinoNetProcessor.JavaTypeConverter.decimalConverter);
            ret[typeof(System.IntPtr).TypeHandle] = new NodeHandler(RhinoNetProcessor.JavaTypeConverter.intPtrConverter);
            ret[typeof(System.UIntPtr).TypeHandle] = new NodeHandler(RhinoNetProcessor.JavaTypeConverter.uIntPtrConverter);
            ret[typeof(System.Char).TypeHandle] = new NodeHandler(RhinoNetProcessor.JavaTypeConverter.charConverter);
            ret[typeof(org.mozilla.javascript.Scriptable).TypeHandle] = new NodeHandler(RhinoNetProcessor.JavaTypeConverter.nonConverter);
            ret[typeof(org.mozilla.javascript.NativeFunction).TypeHandle] = new NodeHandler(RhinoNetProcessor.JavaTypeConverter.nonConverter);
            ret[typeof(org.mozilla.javascript.NativeArray).TypeHandle] = new NodeHandler(RhinoNetProcessor.JavaTypeConverter.nonConverter);
            ret[typeof(org.mozilla.javascript.NativeJavaArray).TypeHandle] = new NodeHandler(RhinoNetProcessor.JavaTypeConverter.nonConverter);
            ret[typeof(org.mozilla.javascript.NativeObject).TypeHandle] = new NodeHandler(RhinoNetProcessor.JavaTypeConverter.nonConverter);
            ret[typeof(org.mozilla.javascript.NativeIterator).TypeHandle] = new NodeHandler(RhinoNetProcessor.JavaTypeConverter.nonConverter);
            ret[typeof(org.mozilla.javascript.NativeJavaMethod).TypeHandle] = new NodeHandler(RhinoNetProcessor.JavaTypeConverter.nonConverter);
            ret[typeof(org.mozilla.javascript.NativeJSON).TypeHandle] = new NodeHandler(RhinoNetProcessor.JavaTypeConverter.nonConverter);
            ret[typeof(org.mozilla.javascript.Undefined).TypeHandle] = new NodeHandler(RhinoNetProcessor.JavaTypeConverter.nonConverter);
            ret[typeof(org.mozilla.javascript.UniqueTag).TypeHandle] = new NodeHandler(RhinoNetProcessor.JavaTypeConverter.nonConverter);
            ret[typeof(org.mozilla.javascript.FunctionObject).TypeHandle] = new NodeHandler(RhinoNetProcessor.JavaTypeConverter.nonConverter);
            ret[typeof(org.mozilla.javascript.IdFunctionObject).TypeHandle] = new NodeHandler(RhinoNetProcessor.JavaTypeConverter.nonConverter);
            ret[typeof(org.mozilla.javascript.Script).TypeHandle] = new NodeHandler(RhinoNetProcessor.JavaTypeConverter.nonConverter);
            ret[typeof(org.mozilla.javascript.ScriptableObject).TypeHandle] = new NodeHandler(RhinoNetProcessor.JavaTypeConverter.nonConverter);
            ret[typeof(ICommonObjectInterface).TypeHandle] = new NodeHandler(RhinoNetProcessor.JavaTypeConverter.jsToJavaMethodConverter);
            ret[typeof(System.DateTime).TypeHandle] = new NodeHandler(RhinoNetProcessor.JavaTypeConverter.dateTimeConverter);
            ret[typeof(java.lang.Character).TypeHandle] = new NodeHandler(RhinoNetProcessor.JavaTypeConverter.javaCharacterConverter);
            ret[typeof(IMultiversalWindow).TypeHandle] = new NodeHandler(RhinoNetProcessor.JavaTypeConverter.multiversalWindowConverter);
            // java.lang.string
            ret[typeof(java.lang.String).TypeHandle] = new NodeHandler(RhinoNetProcessor.JavaTypeConverter.nonConverter);
            // java.util.Date
            ret[typeof(java.util.Date).TypeHandle] = new NodeHandler(RhinoNetProcessor.JavaTypeConverter.nonConverter);
            // java.lang.object
            // [note] true, or false sometimes java.lang.object. just returns
            ret[typeof(java.lang.Object).TypeHandle] = new NodeHandler(RhinoNetProcessor.JavaTypeConverter.nonConverter);
            ret[typeof(java.lang.Boolean).TypeHandle] = new NodeHandler(RhinoNetProcessor.JavaTypeConverter.nonConverter);
            ret[typeof(org.mozilla.javascript.typedarrays.NativeArrayBuffer).TypeHandle] = new NodeHandler(RhinoNetProcessor.JavaTypeConverter.nonConverter);
            ret[typeof(org.mozilla.javascript.typedarrays.NativeArrayBufferView).TypeHandle] = new NodeHandler(RhinoNetProcessor.JavaTypeConverter.nonConverter);
            ret[typeof(org.mozilla.javascript.typedarrays.NativeTypedArrayView).TypeHandle] = new NodeHandler(RhinoNetProcessor.JavaTypeConverter.nonConverter);
            ret[typeof(org.mozilla.javascript.typedarrays.NativeUint16Array).TypeHandle] = new NodeHandler(RhinoNetProcessor.JavaTypeConverter.nonConverter);
            ret[typeof(org.mozilla.javascript.typedarrays.NativeUint32Array).TypeHandle] = new NodeHandler(RhinoNetProcessor.JavaTypeConverter.nonConverter);
            ret[typeof(org.mozilla.javascript.typedarrays.NativeUint8Array).TypeHandle] = new NodeHandler(RhinoNetProcessor.JavaTypeConverter.nonConverter);
            ret[typeof(org.mozilla.javascript.typedarrays.NativeInt16Array).TypeHandle] = new NodeHandler(RhinoNetProcessor.JavaTypeConverter.nonConverter); ret[typeof(org.mozilla.javascript.typedarrays.NativeFloat64Array).TypeHandle] = new NodeHandler(RhinoNetProcessor.JavaTypeConverter.nonConverter);
            ret[typeof(org.mozilla.javascript.typedarrays.NativeFloat32Array).TypeHandle] = new NodeHandler(RhinoNetProcessor.JavaTypeConverter.nonConverter);
            ret[typeof(org.mozilla.javascript.typedarrays.NativeInt16Array).TypeHandle] = new NodeHandler(RhinoNetProcessor.JavaTypeConverter.nonConverter); ret[typeof(org.mozilla.javascript.typedarrays.NativeInt32Array).TypeHandle] = new NodeHandler(RhinoNetProcessor.JavaTypeConverter.nonConverter);
            ret[typeof(org.mozilla.javascript.typedarrays.NativeInt8Array).TypeHandle] = new NodeHandler(RhinoNetProcessor.JavaTypeConverter.nonConverter);
            ret[typeof(org.mozilla.javascript.UniqueTag).TypeHandle] = new NodeHandler(RhinoNetProcessor.JavaTypeConverter.multiversalUniqueTagConverter);
            return ret;
        }

        public static object ConvertCLRValueToJavaValue(object netValue, Scriptable scope)
        {
            if (netValue == null)
                return org.mozilla.javascript.Undefined.instance;
            NodeHandler handler;
            if (TypeHandleSwitcher.TryGetValue(netValue.GetType().TypeHandle, out handler))
            {
                return handler(netValue, scope);
            }
            else
            {
                if (netValue is org.mozilla.javascript.Scriptable)
                {
                    return netValue;
                }
                if (netValue is ICommonObjectInterface)
                {


                    Context context = Context.getCurrentContext();
                    if (context == null)
                    {
                        string arg_13_0 = "No Context associated with current Thread";
                        if (commonLog.LoggingEnabled && commonLog.LogLevel >= 10)
                        {
                            commonLog.LogEntry(arg_13_0);
                        }
                        throw new java.lang.RuntimeException(arg_13_0);
                    }
                    return context.getWrapFactory().wrap(context, scope, netValue, null);
                }
                else if (netValue is IMultiversalWindow)
                {
                    return RhinoNetProcessor.JavaTypeConverter.multiversalWindowConverter(netValue, scope);
                }
                else if (netValue is System.Array)
                {
                    return ___convertCLRObjectArrayIntoScriptableNativeArray(netValue, scope);
                }
            }
            return netValue;

        }

        public static double getDoubleValue(object ___object)
        {
            if (___object == null)
            {
                return 0;
            }
            else
            {
                doubleHandler ___doubleHandler = null;
                if (___doubleSwither.TryGetValue(___object.GetType().TypeHandle, out ___doubleHandler) == true)
                {
                    return ___doubleHandler(___object);
                }
                else
                {
                    if (commonLog.LoggingEnabled && commonLog.LogLevel >= 3)
                    {
                        commonLog.LogEntry("{0} doubleSwither is not registered. retuns 0", ___object);
                    }
                    return 0;
                }

            }

        }

        public static string getStringValue(object ___object)
        {
            if (___object == null)
            {
                return "";
            }
            else
            {
                stringHandler ___stringHandler = null;
                if (___stringSwitcher.TryGetValue(___object.GetType().TypeHandle, out ___stringHandler) == true)
                {
                    return ___stringHandler(___object);
                }
                else
                {
                    return ___object.ToString();
                }

            }

        }

        internal static double ___getUnixStyyleTicksFromDateTime(DateTime dt)
        {
            DateTime d1 = new DateTime(1970, 1, 1);
            DateTime d2 = dt.ToUniversalTime();
            TimeSpan ts = new TimeSpan(d2.Ticks - d1.Ticks);

            return ts.TotalMilliseconds;
        }
        public static double PeformStackFrameAnaysis(string _badname)
        {
            try
            {
                StackTrace stackTrace = new StackTrace();           // get call stack
                StackFrame[] stackFrames = stackTrace.GetFrames();
                int _Point = 0;
                System.Collections.Generic.SortedList<string, int> _scoreTable = new System.Collections.Generic.SortedList<string, int>(StringComparer.OrdinalIgnoreCase);
                int _CurrentStack = 0;
                int _SkipFrame = 3;
                bool _WillBadNameCheck = false;
                if (string.IsNullOrEmpty(_badname) == false)
                {
                    _WillBadNameCheck = true;

                }
                foreach (StackFrame sf in stackFrames)
                {
                    _CurrentStack++;
                    if (_CurrentStack <= _SkipFrame)
                        continue;
                    string _methodName = sf.GetMethod().Name;
                    if (_WillBadNameCheck && string.Equals(_badname, _methodName, StringComparison.Ordinal) == true)
                    {
                        _Point++;
                    }
                    if (_scoreTable.ContainsKey(_methodName) == false)
                    {
                        _scoreTable[_methodName] = 1;
                    }
                    else
                    {
                        _scoreTable[_methodName]++;
                    }
                }
                int _Max = 0;
                string _MaxMethodName = "";
                if (commonLog.LoggingEnabled && commonLog.LogLevel >= 8)
                {
                    commonLog.LogEntry("---------------PeformStackFrameAnaysis-----------------");
                }

                foreach (string _key in _scoreTable.Keys)
                {
                    int _score = _scoreTable[_key];
                    if (commonLog.LoggingEnabled && commonLog.LogLevel >= 8)
                    {
                        commonLog.LogEntry(_key.ToString() + " : " + _score.ToString());
                    }
                    _Max = Math.Max(_Max, _score);
                    if (_Max == _score)
                    {
                        _MaxMethodName = _key.ToString();
                    }
                }
                if (commonLog.LoggingEnabled && commonLog.LogLevel >= 8)
                {
                    commonLog.LogEntry("--------------------------------------------------------");
                }

                float _occurancePercentage = (float)_Max / (float)stackFrames.Length * 100;
                if (commonLog.LoggingEnabled && commonLog.LogLevel >= 8)
                {
                    commonLog.LogEntry(_MaxMethodName + " : Count " + _Max.ToString() + " " + _occurancePercentage.ToString("0.##\\%"));
                }
                if (commonLog.LoggingEnabled && commonLog.LogLevel >= 8)
                {
                    commonLog.LogEntry("--------------------------------------------------------");
                }


                return _occurancePercentage;
            }
            catch { }
            return -1;
        }
#pragma warning disable IDE1006 // 命名スタイル
        /// <summary>
        /// Faster CLR numeric type check
        /// only checks CLR numeric type
        /// </summary>
        /// <param name="___obj"></param>
        /// <returns></returns>
        public static bool isClrNumeric(object ___obj)
#pragma warning restore IDE1006 // 命名スタイル
        {
            if (___obj is int || ___obj is float || ___obj is double || ___obj is short || ___obj is byte || ___obj is uint || ___obj is sbyte || ___obj is ulong || ___obj is decimal)
            {
                return true;
            }

            return false;
        }
        public static bool isJavaNumeric(object ___obj)
        {
            if (___obj is java.lang.Integer || ___obj is java.lang.Float || ___obj is java.lang.Double)
            {
                return true;
            }
            return false;
        }
        public static bool isJavaLangReflectConstructor(object ___obj)
        {
            if (___obj is java.lang.reflect.Constructor)
            {
                return true;
            }
            return false;
        }
        public static bool isJavaSecurityPricipalObjectType(object ___obj)
        {
            if (___obj.GetType().IsArray == true)
            {
                if (___obj is java.security.Principal[])
                {
                    return true;
                }
            }
            if (___obj is java.security.Principal)
            {
                return true;
            }
            return false;
        }
        public static int RhinoOptimizationLevel
        {
            get {
                /*
                if (NLog.LogManager.Configuration.Variables.TryGetValue("RhinoOptimizationLevel", out NLog.Layouts.SimpleLayout simpValue) == true)
                {
                    if (int.TryParse(simpValue.Text, out int result) == true)
                    {
                        return result;
                    }
                }
                */
                return -1;
            }
            set {; }
        }
    }
}
