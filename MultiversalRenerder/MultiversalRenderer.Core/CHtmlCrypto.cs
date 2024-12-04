using System;
using System.Collections.Generic;
using System.Text;
using MultiversalRenderer.Interfaces;
namespace MultiversalRenderer.Core
{
    public sealed class CHtmlCrypto : CHtmlNode , ICommonObjectInterface 
    {
        internal System.WeakReference ___ownerDocumentWeakReference = null;


        internal CHtmlCryptoSubtle ___subtle = null;
        public CHtmlCrypto()
        {
            this.___subtle = new CHtmlCryptoSubtle();
        }
        public CHtmlCryptoSubtle subtle
        {
            get
            {
                return this.___subtle;
            }
        }

        public string getClassName()
        {
            return "crypto";
        }
        public override string ToString()
        {
            return "crypto";
        }
        public bool hasOwnProperty(string ___name)
        {
            return this.___hasPropertyByName(___name);
        }
        /// <summary>
        /// This method uses the Windows system Random Number Generator algorithm. An RNG algorithm is a deterministic algorithm that, given a seed, outputs pseudo-random bytes. A Random Number Generator consists of an RNG algorithm and a way of seeding that algorithm. Note that the seeding is actually the harder part, and it is what provides the security value of this method
        /// called as "var array = new Uint32Array(10);
        /// window.crypto.getRandomValues(array);"
        /// </summary>
        /// <param name="___arrayObject">array</param>
        /// <returns>void</returns>
        public void getRandomValues(object ___arrayObject)
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 5)
            {
               commonLog.LogEntry("entering entering {0}.getRandomValues({1})", this, ___arrayObject);
            }
            System.Random rdn = new Random((int)DateTime.Now.Ticks);
            try
            {
                if (___arrayObject is org.mozilla.javascript.typedarrays.NativeTypedArrayView)
                {
                    org.mozilla.javascript.typedarrays.NativeTypedArrayView ___nativeArrayView = (org.mozilla.javascript.typedarrays.NativeTypedArrayView)___arrayObject;
                    if (___nativeArrayView != null)
                    {
                        int arrayLen = 0;
                        string arrayTypeString = ___arrayObject.GetType().Name;
                        java.lang.Integer javaInteger = new java.lang.Integer(0);
                        java.lang.Float javaFloat = new java.lang.Float(0);
                        switch (arrayTypeString)
                        {
                            case "NativeInt32Array":
                                org.mozilla.javascript.typedarrays.NativeInt32Array nativeInt32Array = (org.mozilla.javascript.typedarrays.NativeInt32Array)___arrayObject;
                                arrayLen = nativeInt32Array.getArrayLength();
                                for (int i = 0; i < arrayLen; i++)
                                {
                                    javaInteger  = new java.lang.Integer (rdn.Next(-2147483648, 2147483647)); // same as int32
                                    while ((javaInteger.intValue() >= -2147483648 && javaInteger.intValue() <= 2147483647) == false)
                                    {
                                        javaInteger = new java.lang.Integer(rdn.Next(-2147483648, 2147483647));
                                    }
                                    nativeInt32Array.set(i, javaInteger);
                                }
                                break;
                            case "NativeInt16Array":
                                org.mozilla.javascript.typedarrays.NativeInt16Array nativeInt16Array = (org.mozilla.javascript.typedarrays.NativeInt16Array)___arrayObject;
                                arrayLen = nativeInt16Array.getArrayLength();
                                for (int i = 0; i < arrayLen; i++)
                                {
                                    javaInteger = new java.lang.Integer(rdn.Next(-32768, 32767)); // same as int16
                                    while ((javaInteger.intValue() >= -32768 && javaInteger.intValue() <= 32767) == false)
                                    {
                                        javaInteger = new java.lang.Integer(rdn.Next(-32768, 32767)); // same as int16
                                    }
                                    nativeInt16Array.set(i, javaInteger);
                                }
                                break;
                            case "NativeInt8Array":
                                org.mozilla.javascript.typedarrays.NativeInt8Array nativeInt8Array = (org.mozilla.javascript.typedarrays.NativeInt8Array)___arrayObject;
                                arrayLen = nativeInt8Array.getArrayLength();
                                for (int i = 0; i < arrayLen; i++)
                                {
                                    javaInteger = new java.lang.Integer(rdn.Next(-128, 127)); // same as SByte
                                    while ((javaInteger.intValue() >= -128 && javaInteger.intValue() <= 127) == false)
                                    {
                                        javaInteger = new java.lang.Integer(rdn.Next(-128, 127)); //
                                    }
                                    nativeInt8Array.set(i, javaInteger);
                                }
                                break;
                            case "NativeUint8Array":
                            case "NativeUint8ClampedArray":
                                org.mozilla.javascript.typedarrays.NativeUint8Array  nativeUint8Array = (org.mozilla.javascript.typedarrays.NativeUint8Array)___arrayObject;
                                arrayLen = nativeUint8Array.getArrayLength();
                                for (int i = 0; i < arrayLen; i++)
                                {
                                    // uint8 : 0 to 255
                                    java.lang.Integer  javaInt8 = new java.lang.Integer(rdn.Next(0, 255)); 

                                    nativeUint8Array.set(i, javaInt8);
                                }
                                break;
                            case "NativeUint16Array":
                                org.mozilla.javascript.typedarrays.NativeUint16Array nativeUint16Array = (org.mozilla.javascript.typedarrays.NativeUint16Array)___arrayObject;
                                arrayLen = nativeUint16Array.getArrayLength();
                                for (int i = 0; i < arrayLen; i++)
                                {
                                    java.lang.Integer  javaUInt16= new java.lang.Integer(rdn.Next(0, 255 * 2));
                                    while ((javaUInt16.intValue() >= 0 && javaUInt16.intValue() <= 255 * 2) == false)
                                    {
                                        javaUInt16 = new java.lang.Integer(rdn.Next(0, 255 * 2));
                                    }
                                    nativeUint16Array.set(i, javaUInt16);
                                }
                                break;
                            case "NativeUint32Array":
                                org.mozilla.javascript.typedarrays.NativeUint32Array nativeUint32Array = (org.mozilla.javascript.typedarrays.NativeUint32Array)___arrayObject;
                                arrayLen = nativeUint32Array.getArrayLength();
                                for (int i = 0; i < arrayLen; i++)
                                {
                                    java.lang.Long javaLong = new java.lang.Long(rdn.Next(0,  255*3));
                                    while ((javaLong.doubleValue()  >= 0 && javaLong.doubleValue() <= 255 *3) == false)
                                    {
                                        javaLong = new java.lang.Long(rdn.Next(0, 255*3));
                                    }
                                    nativeUint32Array.set(i, javaLong);
                                }
                                break;
                            case "NativeFloat32Array":
                                org.mozilla.javascript.typedarrays.NativeFloat32Array nativeFloat32Array = (org.mozilla.javascript.typedarrays.NativeFloat32Array)___arrayObject;
                                arrayLen = nativeFloat32Array.getArrayLength();
                                for (int i = 0; i < arrayLen; i++)
                                {
                                    float floatValue = (float)rdn.NextDouble();
                                    java.lang.Long javaLong = new java.lang.Long((long)floatValue); // same as 'float'
                                    while ((javaLong.doubleValue()  >= float.MinValue && javaLong.doubleValue() <= float.MaxValue) == false)
                                    {
                                        floatValue = (float)rdn.NextDouble();
                                         javaLong = new java.lang.Long((long)floatValue); //
                                    }
                                    nativeFloat32Array.set(i, javaLong);
                                }
                                break;
                            case "NativeFloat64Array":
                                  org.mozilla.javascript.typedarrays.NativeFloat64Array nativeFloat64Array = (org.mozilla.javascript.typedarrays.NativeFloat64Array)___arrayObject;
                                arrayLen = nativeFloat64Array.getArrayLength();
                                for (int i = 0; i < arrayLen; i++)
                                {
                                    double  doubleValue = rdn.NextDouble();
                                    java.lang.Double javaDouble = new java.lang.Double(doubleValue); // same as 'double'
                                    while ((javaDouble.doubleValue()  >= double.MinValue  && javaDouble.doubleValue() <= double.MaxValue) == false)
                                    {
                                        doubleValue = rdn.NextDouble();
                                        javaDouble = new java.lang.Double(doubleValue); // same as 'double'
                                    }
                                    nativeFloat64Array.set(i, javaDouble);
                                }
                                break;
                            default:
                                if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 5)
                                {
                                   commonLog.LogEntry("TODO: Needs to handle  {0}.getRandomValues({1})", this, ___arrayObject);
                                }
                                break;

                        }
                    }

                }
                else
                {

                }
            }
            catch (Exception ex)
            {
                if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 5)
                {
                   commonLog.LogEntry("crypto.getRandomValues() Exception. But cont...", ex);
                }
            }
            return;
        }


        

        #region IPropertBox メンバ

        public object ___getPropertyByName(string ___name)
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
            {
               commonLog.LogEntry("GetPropertyValue for {0} {1} ", this, ___name);
            }
            switch (___name)
            {
                case "subtle":
                    return this.___subtle;
                default:
                    break;
            }
            object propValue;
            if (___properties.TryGetValue(___name, out propValue))
            {
                return propValue;
            }
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
            {
               commonLog.LogEntry("GetPropertyValue for {0} {1} failed", this, ___name);
            }
            return null;
        }

        public void ___setPropertyByName(string ___name, object val)
        {
            switch (___name)
            {
                default:
                    if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
                    {
                       commonLog.LogEntry("SetPropertyValue for {0} {1}  {2} = {3} failed", this.GetType(), this, ___name, val);
                    }
                    this.___properties[___name] = val;
                    break;
            }
        }
        public void ___setPropertyByIndex(int ___index, object val)
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
            {
               commonLog.LogEntry("SetPropertyValueIndex for {0} {1}  {2} = {3} failed", this.GetType(), this, ___index, val);
            }
        }
        public object ___getPropertyByIndex(int ___index)
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
            {
               commonLog.LogEntry("GetPropertyValueInex for {0} {1} {2} failed", this.GetType(), this, ___index);
            }
            return null;
        }

        public bool ___hasPropertyByName(string ___name)
        {

            return false;
        }
        public bool ___hasPropertyByIndex(int ___index)
        {
            return true;
        }
        public object ___common_object_clone()
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
            {
               commonLog.LogEntry("x__Clone {0} {1} called", this.GetType(), this);
            }
            return this;
        }
        public void ___deleteByIndex(int ___index)
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
            {
               commonLog.LogEntry("___deleteByIndex {0} {1} called : {2}", this.GetType(), this, ___index);
            }
        }
        public void ___deleteByName(string ___name)
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
            {
               commonLog.LogEntry("___deleteByName {0} {1} called : {2}", this.GetType(), this, ___name);
            }

        }
        public object[] ___getByIds()
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
            {
               commonLog.LogEntry("___getByIds() {0} {1} called", this.GetType(), this);
            }
            return null;

        }
        public string ___getClassName()
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
            {
               commonLog.LogEntry("___getClassName {0} {1} called", this.GetType(), this);
            }
            return this.GetType().Name;
        }
        public object ___getDefaultValue()
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
            {
               commonLog.LogEntry("___getDefaultValue {0} {1} called", this.GetType(), this);
            }
            return null;
        }
        public object ___getParentScope()
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
            {
               commonLog.LogEntry("___getParentScope {0} {1} called", this.GetType(), this);
            }
            return null;
        }
        public void ___setParentScope(object ___object)
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
            {
               commonLog.LogEntry("___setParentScope {0} {1} called : {2}", this.GetType(), this, ___object);
            }
        }
        public object ___getProtoType()
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
            {
               commonLog.LogEntry("___getProtoType {0} {1} called", this.GetType(), this);
            }
            return null;
        }
        public bool ___hasInstance(object ___object)
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
            {
               commonLog.LogEntry("___hasInstance {0} {1} called : {2}", this.GetType(), this, ___object);
            }
            return false;
        }
        public bool ___instanceEquals(object ___object)
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
            {
               commonLog.LogEntry("___instanceEquals {0} {1} called : {2}", this.GetType(), this, ___object);
            }
            return object.ReferenceEquals(this, ___object);
        }
        public void ___setProtoType(object ___object)
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
            {
               commonLog.LogEntry("___setProtoType {0} {1} called : {2}", this.GetType(), this, ___object);
            }
        }

        #endregion
    }
}
