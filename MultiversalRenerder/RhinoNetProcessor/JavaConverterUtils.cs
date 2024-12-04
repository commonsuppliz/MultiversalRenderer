using System;

using System.Collections.Generic;
using System.Text;
using org.mozilla.javascript;
using System.Diagnostics;
using MultiversalRenderer.Interfaces;

namespace MultiversalRenderer.RhinoNetProcessor
{
    public static class JavaTypeConverter
    {
        public static object multiversalUniqueTagConverter(object ___object, org.mozilla.javascript.Scriptable scope)
        {
            if (___object is org.mozilla.javascript.UniqueTag)
            {
                org.mozilla.javascript.UniqueTag mozUniqueTag = ___object as org.mozilla.javascript.UniqueTag;
                if (mozUniqueTag == org.mozilla.javascript.UniqueTag.NOT_FOUND)
                {
                    return org.mozilla.javascript.UniqueTag.NOT_FOUND;
                }
                if (mozUniqueTag == org.mozilla.javascript.UniqueTag.NULL_VALUE)
                {
                    return org.mozilla.javascript.UniqueTag.NULL_VALUE;
                }
                
   

            }
            return null;

            /*
            if (uniqueTag.value == MultiversalUniqueTag.UniqueType.Not_Found)
            {
                return org.mozilla.javascript.UniqueTag.NOT_FOUND;
            }
            else if (uniqueTag.value == MultiversalUniqueTag.UniqueType.Undefined)
            {
                return org.mozilla.javascript.Undefined.instance;
            }
            return org.mozilla.javascript.Undefined.instance;
            */
            return null;
        }
            /*
            MultiversalUniqueTag uniqueTag = (MultiversalUniqueTag)___object;
            if (uniqueTag.value == MultiversalUniqueTag.UniqueType.Not_Found)
            {
                return org.mozilla.javascript.UniqueTag.NOT_FOUND;
            }
            else if (uniqueTag.value == MultiversalUniqueTag.UniqueType.Undefined)
            {
                return org.mozilla.javascript.Undefined.instance;
            }
            return org.mozilla.javascript.Undefined.instance;
            */
        
        public static object nonConverter(object ___object,org.mozilla.javascript.Scriptable scope)
        {
            return ___object;
        }
        public static object jsToJavaMethodConverter(object netValue, org.mozilla.javascript.Scriptable scope)
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
        public static object stringConverter(object ___object, org.mozilla.javascript.Scriptable scope)
        {
            return ___object;
        }

        public static object javaConsStringConverter(object ___object,org.mozilla.javascript.Scriptable scope)
        {
            return ___object;
        }
        public static object javaDouleConverter(object netValue, org.mozilla.javascript.Scriptable scope)
        {
            return netValue;
        }
        public static object booleanConverter(object netValue, org.mozilla.javascript.Scriptable scope)
        {
            java.lang.Boolean bret;
            if (bool.Equals(netValue, true) == true)
            {
                bret = new java.lang.Boolean(true);
            }
            else
            {
                bret = new java.lang.Boolean(false);

            }
            return bret;
        }
        public static object charConverter(object netValue, org.mozilla.javascript.Scriptable scope)
        {
            char charValue = (char)netValue;
            return charValue.ToString();
        }
        public static object intConverter(object netValue, org.mozilla.javascript.Scriptable scope)
        {
             int oriInt = (int)(netValue);
            return new java.lang.Double((double)oriInt);
        }
        public static object int64Converter(object netValue, org.mozilla.javascript.Scriptable scope)
        {
            
            System.Int64 oriInt = (System.Int64)(netValue);
            return new java.lang.Double((double)oriInt);
        }
        public static object uintConverter(object netValue, org.mozilla.javascript.Scriptable scope)
        {
            
            uint oriInt = (uint)(netValue);
            return new java.lang.Double((double)oriInt);
        }
        public static object uint64Converter(object netValue, org.mozilla.javascript.Scriptable scope)
        {
           
            System.UInt64 oriInt = (System.UInt64)(netValue);
            return new java.lang.Double((double)oriInt);
        }
        public static object shortConverter(object netValue, org.mozilla.javascript.Scriptable scope)
        {
           
            short oriVal = (short)(netValue);
            return new java.lang.Double((double)oriVal);
        }
        public static object longConverter(object netValue, org.mozilla.javascript.Scriptable scope)
        {
            long oriVal = (long)(netValue);
            return new java.lang.Double((double)oriVal);
        }
        public static object ulongConverter(object netValue, org.mozilla.javascript.Scriptable scope)
        {
            ulong oriVal = (ulong)(netValue);
            return new java.lang.Double((double)oriVal);
        }
        public static object floatConverter(object netValue, org.mozilla.javascript.Scriptable scope)
        {
            float oriVal = (float)(netValue);
            return new java.lang.Double((double)oriVal);
        }

        public static object byteConverter(object netValue, org.mozilla.javascript.Scriptable scope)
        {

            byte oriVal = (byte)(netValue);
            return new java.lang.Double((double)oriVal);
        }
        public static object ushortConverter(object netValue, org.mozilla.javascript.Scriptable scope)
        {

            ushort  oriVal = (ushort)(netValue);
            return new java.lang.Double((double)oriVal);
        }
        public static object sbyteConverter(object netValue, org.mozilla.javascript.Scriptable scope)
        {

            sbyte oriVal = (sbyte)(netValue);
            return new java.lang.Double((double)oriVal);
        }
        public static object decimalConverter(object netValue, org.mozilla.javascript.Scriptable scope)
        {
            System.Decimal  oriVal = (System.Decimal)(netValue);
            return new java.lang.Double((double)oriVal);
        }
        public static object intPtrConverter(object netValue, org.mozilla.javascript.Scriptable scope)
        {
            System.IntPtr  oriVal = (System.IntPtr)(netValue);
            return new java.lang.Double((double)oriVal.ToInt64());
        }
        public static object uIntPtrConverter(object netValue, org.mozilla.javascript.Scriptable scope)
        {
            System.UIntPtr  oriVal = (System.UIntPtr)(netValue);
            return new java.lang.Double((double)oriVal.ToUInt64());
        }
        public static object doubleConverter(object netValue, org.mozilla.javascript.Scriptable scope)
        {
           
            double oriDouble = (double)(netValue);
            return new java.lang.Double(oriDouble);
        }
        internal static double ___getUnixStyyleTicksFromDateTime(DateTime dt)
        {
            DateTime d1 = new DateTime(1970, 1, 1);
            DateTime d2 = dt.ToUniversalTime();
            TimeSpan ts = new TimeSpan(d2.Ticks - d1.Ticks);

            return ts.TotalMilliseconds;
        }
        public static object systemArrayConverter(object netValue, org.mozilla.javascript.Scriptable scope)
        {
            return commonTypeConverter.___convertCLRObjectArrayIntoScriptableNativeArray(netValue, scope);
        }
        public static object javaCharacterConverter(object netValue, org.mozilla.javascript.Scriptable scope)
        {
            return java.lang.String.valueOf(((java.lang.Character)netValue).charValue());
        }
        public const string Multiversal_Rhino_Name = "rhino.net";
        public static object multiversalWindowConverter(object netValue, org.mozilla.javascript.Scriptable scope)
        {
            // =========================================================================
            //  IMultiversalWindow is container for IMulversalScopes
            //  At this point, we should have registered IMultiversalScope with
            //  MultiversalScopeName. Get global scope from it.
            // =========================================================================
            IMultiversalWindow ___multiversalWindow = netValue as IMultiversalWindow;
            RhinoMultiversalScope rhinoScope = ___multiversalWindow.getMultiversalScopeByName(Multiversal_Rhino_Name) as RhinoMultiversalScope;
            if (rhinoScope.___isInitCompleted() == false)
            {
                rhinoScope.___initScriptEngine();
            }
            return rhinoScope;
        }
        
        public static object  dateTimeConverter(object netValue, org.mozilla.javascript.Scriptable scope)
        {
            Context ___context3 = Context.getCurrentContext();
            org.mozilla.javascript.ScriptableObject ___jsDate = null;
            try
            {
                System.DateTime ___dtNetValue = (System.DateTime)netValue;
                java.lang.Long ___javaTimeLong = new java.lang.Long((long)___getUnixStyyleTicksFromDateTime(___dtNetValue));
                //___jsDate = ___context3.newObject(scope, "Date", new object[]{__javaDate.getTime()}) as org.mozilla.javascript.ScriptableObject;
                return org.mozilla.javascript.ScriptRuntime.newObject(___context3, scope, "Date", new Object[] { ___javaTimeLong });// as org.mozilla.javascript.ScriptableObject;
                /*
                if (commonLog.LoggingEnabled && commonLog.LogLevel > 8)
                {
                    commonLog.LogEntry("ConvertCLRValueToJavaValue DateTime Conversion Success : {0} Result : {1} ", ___dtNetValue, ___jsDate.toString());
                }
                */
            }
            catch (Exception ex)
            {
                ___jsDate = ___context3.newObject(scope, "Date", new Object[] { "" }) as org.mozilla.javascript.ScriptableObject;
                if (commonLog.LoggingEnabled && commonLog.LogLevel > 8)
                {
                    commonLog.LogEntry("ConvertCLRValueToJavaValue DateTime Conversion Error : " + netValue.ToString() , ex);
                }
            }
            return ___jsDate;
        }
    }

}


