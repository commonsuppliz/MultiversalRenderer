﻿using System;
using System.Collections.Generic;
using System.Text;
using MultiversalRenderer.Interfaces;
using MultiversalRenderer.Interfaces;
namespace MultiversalRenderer.Core
{
    /// <summary>
    /// CHtmlNativeArray is ordinally designed when Rhino did not have native Array.
    /// (ES6 has nativearray in draft).
    /// Now, from Rhino 1.8 native array has been implemented offically.
    /// We use this class in some case for interoperability for script processor.
    /// </summary>

    public sealed class CHtmlNativeArray : ICommonObjectInterface
    {

        internal System.Int16[] ___int16Array;
        internal System.Byte[] ___byteArray;
        internal Int32[] ___int32Array;
        internal Int64[] ___int64Array;
        internal float[] ___floatArray;
        internal  double[] ___doubleArray;
        internal CHtmlNumericArrayType ___arrayType = CHtmlNumericArrayType.Float32Array;
        internal int ___arrayLength = 0;
        internal long ___bufferOffset = 0;
        internal bool ___IsPrototype = false;
        internal int ___BYTES_PER_ELEMENT = 4;
        /// <summary>
        /// Used for Image Type
        /// </summary>
        internal double ___width = 0;
        /// <summary>
        /// Used for Image Type
        /// </summary>
        internal double ___height = 0;
        public CHtmlNativeArray(bool  asPrototype)
        {
            this.___IsPrototype = asPrototype;
        }
        public CHtmlNativeArray(int len)
        {
            this.___arrayLength = len;
        }
        public CHtmlNativeArray(float[] arrayBase)
        {
            this.___arrayLength = arrayBase.Length;
            ___createArrayList(arrayBase);
        }
        public CHtmlNativeArray(CHtmlNumericArrayType arrayType)
        {
            this.___arrayType = arrayType;
            this.___BYTES_PER_ELEMENT = ___get_bytes_per_element(this.___arrayType);
            ___createArrayList(null);
        }
        public CHtmlNativeArray(CHtmlNumericArrayType arrayType, bool asProtype)
        {
            this.___arrayType = arrayType;
            this.___BYTES_PER_ELEMENT = ___get_bytes_per_element(this.___arrayType);
            this.___IsPrototype = asProtype;
        }
        public CHtmlNativeArray( CHtmlNumericArrayType arrayType, int len)
        {
            this.___arrayType = arrayType;
            this.___BYTES_PER_ELEMENT = ___get_bytes_per_element(this.___arrayType);
            this.___arrayLength = len;
            ___createArrayList(null);
        }
        public static int ___get_bytes_per_element(CHtmlNumericArrayType __arrayType)
        {
            switch (__arrayType)
            {
                case CHtmlNumericArrayType.ArrayBuffer:
                case CHtmlNumericArrayType.Uint8ClampedArray:
                case CHtmlNumericArrayType.Uint8Array:
                    return 1;
                case CHtmlNumericArrayType.Uint16Array:
                    return 2;
                case CHtmlNumericArrayType.Uint32Array:
                    return 4;
                case CHtmlNumericArrayType.Int8Array:
                    return 1;
                case CHtmlNumericArrayType.Int16Array:
                    return 2;
                case CHtmlNumericArrayType.Int32Array:
                    return 4;
                case CHtmlNumericArrayType.Float32Array:
                    return 4;
                case CHtmlNumericArrayType.Float64Array:
                    return 8;
            }
            return 4;
        }
        public int BYTES_PER_ELEMENT
        {
            get
            {
                return this.___BYTES_PER_ELEMENT;
            }
        }
        public void ___ZZZ_DUMMY()
        {
            ___doubleArray = new double[0];
            if(___doubleArray!= null)
            {
            }
        }
        public CHtmlNativeArray( CHtmlNumericArrayType arrayType, float[] arrayBase)
        {
            this.___arrayType = arrayType;
            this.___arrayLength = arrayBase.Length;
            ___createArrayList(arrayBase);
        }
        internal void ___copyArrayFromSourceArray(CHtmlNativeArray srcArray)
        {
            switch (this.___arrayType)
            {
                case CHtmlNumericArrayType.Int32Array:
                case CHtmlNumericArrayType.Int64Array:
                    if (srcArray.___int32Array != null)
                    {
                        ___copyArrayFromSourceArray(srcArray.___int32Array);
                    }
                    else if (srcArray.___int64Array != null)
                    {
                        ___copyArrayFromSourceArray(srcArray.___int64Array);
                    }
                    break;
                case CHtmlNumericArrayType.Int16Array:
                case CHtmlNumericArrayType.Int8Array:
                case CHtmlNumericArrayType.Uint16Array:
                case CHtmlNumericArrayType.Uint8Array:
                    ___copyArrayFromSourceArray(srcArray.___int16Array);
                    break;
            }
        }
        internal  void ___copyArrayFromSourceArray(System.Array srcArray)
        {
            if (srcArray == null)
                return;
            try
            {
                switch (this.___arrayType)
                {
                    case CHtmlNumericArrayType.Float32Array:
                    case CHtmlNumericArrayType.Float64Array:
                        if (srcArray.GetType().GetElementType() == typeof(float))
                        {
                            float[] floatArray = srcArray as float[];
                            if (this.___floatArray == null)
                            {
                                this.___floatArray = new float[floatArray.Length];
                            }
                            if (this.___floatArray.Length != floatArray.Length)
                            {
                                this.___floatArray = new float[floatArray.Length];
                            }
                            Array.Copy(floatArray, this.___floatArray, floatArray.Length);
                            this.___arrayLength = this.___floatArray.Length;
                        }
                        else
                        {
                            if (commonLog.LoggingEnabled &&commonLog.CommonLogLevel >= 5)
                            {
                               commonLog.LogEntry("TODO: ___copyArrayFromSourceArray({0}) work needs", srcArray);
                            }
                        }
                        break;
                    case CHtmlNumericArrayType.Int8Array:
                    case CHtmlNumericArrayType.Int16Array:
                    case CHtmlNumericArrayType.Uint16Array:
                    case CHtmlNumericArrayType.Uint8Array:
                        if (srcArray.GetType().GetElementType() == typeof(short))
                        {
                            short[] shortArray = srcArray as short[];
                            if (this.___int16Array == null)
                            {
                                this.___int16Array = new short[shortArray.Length];
                            }
                            if (this.___int16Array.Length != shortArray.Length)
                            {
                                this.___int16Array = new short[shortArray.Length];
                            }
                            Array.Copy(shortArray, this.___int16Array, shortArray.Length);
                            this.___arrayLength = this.___int16Array.Length;
                        }
                        else
                        {
                            if (commonLog.LoggingEnabled &&commonLog.CommonLogLevel >= 5)
                            {
                               commonLog.LogEntry("TODO: ___copyArrayFromSourceArray({0}) work needs", srcArray);
                            }
                        }

                        break;
                    case CHtmlNumericArrayType.Int32Array:
                    case CHtmlNumericArrayType.Uint32Array:
                        if (srcArray.GetType().GetElementType() == typeof(int))
                        {
                            int[] intArray = srcArray as int[];
                            if (this.___int32Array == null)
                            {
                                this.___int32Array = new int[intArray.Length];
                            }
                            if (this.___int32Array.Length != intArray.Length)
                            {
                                this.___int32Array = new int[intArray.Length];
                            }
                            Array.Copy(intArray, this.___int32Array, intArray.Length);
                            this.___arrayLength = this.___int32Array.Length;
                        }
                        else
                        {
                            if (commonLog.LoggingEnabled &&commonLog.CommonLogLevel >= 5)
                            {
                               commonLog.LogEntry("TODO: ___copyArrayFromSourceArray({0}) work needs", srcArray);
                            }
                        }

                        break;

                    case CHtmlNumericArrayType.Int64Array:
                        if (srcArray.GetType().GetElementType() == typeof(int))
                        {
                            int[] intArray = srcArray as int[];
                            if (this.___int32Array == null)
                            {
                                this.___int32Array = new int[intArray.Length];
                            }
                            if (this.___int32Array.Length != intArray.Length)
                            {
                                this.___int32Array = new int[intArray.Length];
                            }
                            Array.Copy(intArray, this.___int32Array, intArray.Length);
                            this.___arrayLength = this.___int32Array.Length;
                        }
                        else if (srcArray.GetType().GetElementType() == typeof(Int64))
                        {
                            System.Int64[] intArray = srcArray as System.Int64[];
                            if (this.___int64Array == null)
                            {
                                this.___int64Array = new System.Int64[intArray.Length];
                            }
                            if (this.___int64Array.Length != intArray.Length)
                            {
                                this.___int64Array = new System.Int64[intArray.Length];
                            }
                            Array.Copy(intArray, this.___int64Array, intArray.Length);
                            this.___arrayLength = this.___int64Array.Length;
                        }
                        else
                        {
                            if (commonLog.LoggingEnabled &&commonLog.CommonLogLevel >= 5)
                            {
                               commonLog.LogEntry("TODO: ___copyArrayFromSourceArray({0}) work needs", srcArray);
                            }
                        }
                        break;
                    case CHtmlNumericArrayType.ArrayBuffer:
                    case CHtmlNumericArrayType.Uint8ClampedArray:
                        if (srcArray.GetType().GetElementType() == typeof(byte))
                        {
                            byte[] byteArray = srcArray as byte[];
                            if (this.___byteArray == null)
                            {
                                this.___byteArray = new byte[byteArray.Length];
                            }
                            if (this.___byteArray.Length != byteArray.Length)
                            {
                                this.___byteArray = new byte[byteArray.Length];
                            }
                            Array.Copy(byteArray, this.___byteArray, byteArray.Length);
                            this.___arrayLength = this.___byteArray.Length;
                        }
                        else if (srcArray.GetType().GetElementType() == typeof(short))
                        {
                            short[] shortArray = srcArray as short[];
                            if (this.___byteArray == null)
                            {
                                this.___byteArray = new byte[shortArray.Length];
                            }
                            if (this.___byteArray.Length != shortArray.Length)
                            {
                                this.___byteArray = new byte[shortArray.Length];
                            }
                            this.___arrayLength = shortArray.Length;
                            int ___shortLen = shortArray.Length;
                            for (int i = 0; i < ___shortLen; i++)
                            {
                                this.___byteArray[i] = System.Convert.ToByte(shortArray[i]);
                            }
                        }
                        else
                        {
                            if (commonLog.LoggingEnabled &&commonLog.CommonLogLevel >= 5)
                            {
                               commonLog.LogEntry("TODO: ___copyArrayFromSourceArray({0}) work needs", srcArray);
                            }
                        }
                        break;
                    default:
                        if (commonLog.LoggingEnabled &&commonLog.CommonLogLevel >= 5)
                        {
                           commonLog.LogEntry("TODO: ___copyArrayFromSourceArray({0}) work needs", srcArray);
                        }
                        break;

                }
            }
            catch (Exception ex)
            {
                if (commonLog.LoggingEnabled &&commonLog.CommonLogLevel >= 5)
                {
                   commonLog.LogEntry("___copyArrayFromSourceArray() exception", ex);
                }
            }
        }
        private void ___createArrayList(float[] arrayBase)
        {
            int arrayBaseLen = 0;
            if (arrayBase != null)
            {
                arrayBaseLen = arrayBase.Length;
            }
            switch (this.___arrayType)
            {
                case CHtmlNumericArrayType.Float32Array:
                case CHtmlNumericArrayType.Float64Array:
                    if (arrayBase != null)
                    {
                        this.___floatArray = new float[arrayBaseLen];
                        System.Array.Copy(arrayBase, this.___floatArray, arrayBaseLen);
                    }
                    else
                    {
                        this.___floatArray = new float[this.___arrayLength];
                    }
                    break;
                case CHtmlNumericArrayType.Int8Array:
                case CHtmlNumericArrayType.Int16Array:
                case CHtmlNumericArrayType.Uint16Array:
                case CHtmlNumericArrayType.Uint8Array:
                    if (arrayBase != null)
                    {
                        this.___int16Array = new System.Int16[arrayBaseLen];
                        for (int i = 0; i < arrayBaseLen; i++)
                        {
                            this.___int16Array[i] = (System.Int16)arrayBase[i];
                        }
                    }
                    else
                    {
                        this.___int16Array = new System.Int16[this.___arrayLength];
                    }
                    break;
                case CHtmlNumericArrayType.Int32Array:
                case CHtmlNumericArrayType.Uint32Array:
                    if (arrayBase != null)
                    {
                        this.___int32Array = new System.Int32[arrayBaseLen];
                        for (int i = 0; i < arrayBaseLen; i++)
                        {
                            this.___int32Array[i] = (System.Int32)arrayBase[i];
                        }
                    }
                    else
                    {
                        this.___int32Array = new System.Int32[this.___arrayLength];
                    }
                    break;
                   
                case CHtmlNumericArrayType.Int64Array:
                    if (arrayBase != null)
                    {
                        this.___int64Array = new System.Int64[arrayBaseLen];
                        for (int i = 0; i < arrayBaseLen; i++)
                        {
                            this.___int64Array[i] = (System.Int64)arrayBase[i];
                        }
                    }
                    else
                    {
                        this.___int64Array = new System.Int64[this.___arrayLength];
                    }
                    break;
                   
                default:
             
                    if (arrayBase != null)
                    {
                        this.___floatArray = new float[arrayBaseLen];
                        System.Array.Copy(arrayBase, this.___floatArray, arrayBaseLen);
                    }
                    else
                    {
                        this.___floatArray = new float[this.___arrayLength];
                    }
                    break;


            }
        }


        public CHtmlNativeArray subarray(object begin, object end)
        {
            CHtmlNativeArray subarrayNew = new CHtmlNativeArray(0);
            subarrayNew.___arrayType = this.___arrayType;
            
            return subarrayNew;
        }
        public double length
        {
            get
            {
                return this.___arrayLength;
            }
        }
        public double byteLength
        {
            get
            {
                return this.___arrayLength * this.___BYTES_PER_ELEMENT;
            }
        }
        public double buuferOffset
        {
            get { return this.___bufferOffset; }
            set { this.___bufferOffset = (long)value; }
        }
        public object buffer
        {
            get
            {
                return this;
            }
        }



        /// <summary>
        /// set array
        /// </summary>
        /// <param name="___array"></param>
        public void set(object ___array)
        {
            this.___set_inner(___array, null, null);
        }
        /// <summary>
        /// set with 2 parameter
        /// </summary>
        /// <param name="___p1"></param>
        /// <param name="___p2"></param>
        public void set(object ___p1, object ___p2)
        {
            // note) ___array can be start index 
            //         we needs to check data type here
            if (___p1 != null)
            {
                if ( commonHTML.isClrNumeric(___p1))
                {
                    this.___set_inner( ___p2, commonData.GetDoubleFromObject(___p1,0), null);
                    return;
                }
                if (___p2 != null)
                {
                    if (commonHTML.isClrNumeric(___p2))
                    {
                        this.___set_inner(___p1, null, commonData.GetDoubleFromObject(___p2, 0));
                            return;
                    }
                }
            }
             if (commonLog.LoggingEnabled &&commonLog.CommonLogLevel >= 10)
            {
               commonLog.LogEntry("{0}.set() seems to be invald values. skip now.", this);
            }
        }
        private void ___set_inner(object ___array, object ___index, object ___offset)
        {
            if (commonLog.LoggingEnabled &&commonLog.CommonLogLevel >= 10)
            {
               commonLog.LogEntry("calling  {0}.set({1}, {2}, {3})", this, ___array, ___index, ___offset );
            }

            double ___indexDouble = -1;
            double ___offsetDouble = -1;
            bool ___isjArrayIsNotNull = false;
            float[] ___floatArray;
            try
            {
                if (___array != null)
                {
                    ___isjArrayIsNotNull = true;

                }
                if (___index != null)
                {
                    ___indexDouble = commonData.GetDoubleFromObject(___index, -1);
                }
                if (___offset != null)
                {
                    ___offsetDouble = commonData.GetDoubleFromObject(___offset, -1);
                }

            }
            catch (Exception ex1)
            {

                if (commonLog.LoggingEnabled &&commonLog.CommonLogLevel >= 10)
                {
                   commonLog.LogEntry("CHtmlNaviveArray set Inner Error ", ex1);
                }
            }
            try
            {

                if (___isjArrayIsNotNull == true)
                {
                    switch (___array) 
                    {

                        default:
                            ___floatArray = commonData.___convertObjectIntoFloatArray(___array, -1, -1);
                            ___createArrayList(___floatArray);
                            this.___byteArray = null;
                            this.___arrayLength = ___floatArray.Length;
                            return;
                            
                            
                    } 
                        

                }


                if (commonLog.LoggingEnabled &&commonLog.CommonLogLevel >= 10)
                {
                   commonLog.LogEntry("TODO: needs to works offset value set  {0}.set({1}, {2}, {3})", this, ___array, ___index, ___offset);
                }
                
            }catch(Exception ex2)
            {
                if (commonLog.LoggingEnabled &&commonLog.CommonLogLevel >= 8)
                {
                   commonLog.LogEntry("CHtmlNaviveArray set Inner Error ", ex2);
                }
            }

        
        }
        private static CHtmlNativeArray ____getSystemArrayIntoNewArray(object ___objArray, CHtmlNumericArrayType ___targetType)
        {
            if (commonLog.LoggingEnabled &&commonLog.CommonLogLevel >= 8)
            {
               commonLog.LogEntry("TODO: ____getCHtmlNativeArrayIntoNewArray Copy");
            }
            CHtmlNativeArray ___resultArray = new CHtmlNativeArray(___targetType);
            return ___resultArray;
        }
        private static CHtmlNativeArray ____getJavaArrayIntoNewArray(object ___objArray, CHtmlNumericArrayType ___targetType)
        {
            if (commonLog.LoggingEnabled &&commonLog.CommonLogLevel >= 8)
            {
               commonLog.LogEntry("TODO: ____getCHtmlNativeArrayIntoNewArray Copy");
            }
            CHtmlNativeArray ___resultArray = new CHtmlNativeArray(___targetType);
            return ___resultArray;
        }

        private static CHtmlNativeArray ____getOrgMozillaJavascriptNativeArrayIntoNewArray(object ___objArray, CHtmlNumericArrayType ___targetType)
    {
        bool isTargetTypeChanged = false;
        if (___targetType == CHtmlNumericArrayType.None)
        {
            ___targetType = CHtmlNumericArrayType.Float64Array;
        }
        object[] objArray = null;



        if (objArray == null)
        {
            if (commonLog.LoggingEnabled &&commonLog.CommonLogLevel >= 8)
            {
               commonLog.LogEntry("BUGBUG!!! __getOrgMozillaJavascriptNativeArrayIntoNewArray failed to create array : {0}  ", ___objArray);
            }
            objArray = new object[] { };
        }
        if (isTargetTypeChanged)
        {
            if (commonLog.LoggingEnabled &&commonLog.CommonLogLevel >= 8)
            {
               commonLog.LogEntry("NativeArray TargetType is changed to {0}", ___targetType);
            }
        }
        int ___arrayLen = 0;
        ___arrayLen = (int)objArray.Length;

        CHtmlNativeArray ___byteArrayList = new CHtmlNativeArray(___targetType);

        ___byteArrayList.___arrayLength = ___arrayLen;
        switch (___targetType)
        {
            case CHtmlNumericArrayType.Uint8ClampedArray:
            case CHtmlNumericArrayType.ArrayBuffer:
            case CHtmlNumericArrayType.ByteArray:
                ___byteArrayList.___byteArray = new byte[___arrayLen];
                // =============================================================================================
                for (int i = 0; i < objArray.Length; i++)
                {
                    object test = objArray[i];
                    int intval = new int();
                        ___byteArrayList.___byteArray[i] = System.Convert.ToByte(intval);
                }

                // =============================================================================================

                break;
            case CHtmlNumericArrayType.Float32Array:
            case CHtmlNumericArrayType.Float64Array:
                ___byteArrayList.___floatArray = new float[___arrayLen];
                // =============================================================================================
                for (int i = 0; i < ___arrayLen; i++)
                {

                    ___byteArrayList.___floatArray[i] = (float)commonData.GetDoubleFromObject(objArray[i], 0);
                }

                // =============================================================================================
                break;
            case CHtmlNumericArrayType.Int8Array:
            case CHtmlNumericArrayType.Uint8Array:
            case CHtmlNumericArrayType.Uint16Array:
            case CHtmlNumericArrayType.Int16Array:

                ___byteArrayList.___int16Array = new short[___arrayLen];
                // =============================================================================================
                for (int i = 0; i < ___arrayLen; i++)
                {
                    ___byteArrayList.___int16Array[i] = (short)commonData.GetDoubleFromObject(objArray[i], 0);
                }

                // =============================================================================================
                break;
            case CHtmlNumericArrayType.Int32Array:
            case CHtmlNumericArrayType.Int64Array:
            case CHtmlNumericArrayType.Uint32Array:
            case CHtmlNumericArrayType.Uint64Array:
                ___byteArrayList.___int32Array = new int[___arrayLen];
                // =============================================================================================
                for (int i = 0; i < ___arrayLen; i++)
                {
                    ___byteArrayList.___int32Array[i] = (int)commonData.GetDoubleFromObject(objArray[i], 0);
                }

                // =============================================================================================
                break;

            default:
                if (commonLog.LoggingEnabled &&commonLog.CommonLogLevel >= 8)
                {
                   commonLog.LogEntry("TODO: ____getCHtmlNativeArrayIntoNewArray Copy");
                }
                break;

        }

        return ___byteArrayList;
    }
    #region IPropertBox メンバ

    public object ___getPropertyByName(string ___name)
        {
            if (commonLog.LoggingEnabled &&commonLog.CommonLogLevel >= 1000)
            {
               commonLog.LogEntry("calling  {0}.{1}", this, ___name);
            }
            switch (___name)
            {
                case "length":
                    return this.___arrayLength;
                case "BYTES_PER_ELEMENT":
                    return this.___BYTES_PER_ELEMENT;
                case "data":
                    
                    switch (this.___arrayType)
                    { 
                        case CHtmlNumericArrayType.Uint8ClampedArray:
                        case CHtmlNumericArrayType.ArrayBuffer:
                        case CHtmlNumericArrayType.ByteArray:
                        case CHtmlNumericArrayType.Int8Array:

                            if (commonLog.LoggingEnabled &&commonLog.CommonLogLevel >= 1000)
                            {
                               commonLog.LogEntry("{0}{1} returning itself to {2}", this, ___name , this.___arrayType);
                            }
                            return this;
                        default:
                            if (commonLog.LoggingEnabled &&commonLog.CommonLogLevel >= 1000)
                            {
                               commonLog.LogEntry("BUGBUG ! {0} returning data as null to {1} {2}", this, ___name, this.___arrayType);
                            }
                            return null;
                    }

                case "buffer":
                    switch (this.___arrayType)
                    {
                        case CHtmlNumericArrayType.Uint8ClampedArray:
                        case CHtmlNumericArrayType.ByteArray:
                        case CHtmlNumericArrayType.Int8Array:
                        case CHtmlNumericArrayType.ArrayBuffer:
                            CHtmlNativeArray ___nativeArray = new CHtmlNativeArray(this.___arrayLength);
                            ___nativeArray.___arrayType = CHtmlNumericArrayType.ArrayBuffer;
                            ___nativeArray.___byteArray = this.___byteArray;
                            return ___nativeArray;

                        default:
                            if (commonLog.LoggingEnabled &&commonLog.CommonLogLevel >= 10)
                            {
                               commonLog.LogEntry("BUGBUG {0} buffer property is not defined for this array type {1} to buffer, returns null", this, this.___arrayType);

                            }
                            
                        return null;
                    }
                case "width":
                    if (this.___arrayType == CHtmlNumericArrayType.Uint8ClampedArray)
                    {
                        return this.___width;
                    }
                    else
                    {
                        return 0;
                    }
                case "height":
                    if (this.___arrayType == CHtmlNumericArrayType.Uint8ClampedArray)
                    {
                        return this.___height;
                    }
                    else
                    {
                        return 0;
                    }
                case "byteLength":
                    return this.byteLength;
                case "toJSON":
                    // ==================================================================
                    // normal browser returns undefined if toJSON is called. but 
                    // rhino may result in stackoverflow if undefined returned.
                    // throw an exception is may be good for addthis.js and core130.js
                    // ==================================================================
                    throw new System.NotImplementedException("CHtmlNativeArray does not have toJSON method");
            }
            if (commonLog.LoggingEnabled &&commonLog.CommonLogLevel >= 8)
            {
               commonLog.LogEntry("calling  {0}.{1} failed...", this, ___name);
            }
            return null;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="____typeString"></param>
        /// <returns></returns>
        public string toJSON(object ____arrayObject)
        {
            if (commonLog.LoggingEnabled &&commonLog.CommonLogLevel >= 1000)
            {
               commonLog.LogEntry("calling  {0}.toJSON()", this, ____arrayObject);
            }
            System.Text.StringBuilder sbJSON = new StringBuilder();
            sbJSON.Append("[");
            sbJSON.Append(____arrayObject);
            sbJSON.Append("]");
            return sbJSON.ToString();
        }
        /// <summary>
        /// when CHtmlElement is accessed by like document.body[1], it should return the input selement. not child nodes
        /// </summary>
        /// <param name="___index"></param>
        /// <returns></returns>
        public object ___getPropertyByIndex(int ___index)
        {
            // ------------------------------------------------------
            if (commonLog.LoggingEnabled &&commonLog.CommonLogLevel >= 1000)
            {
               commonLog.LogEntry("calling  {0} get by index {1}", this, ___index);
            }
            try
            {
                if (___index >= 0 && ___index < this.___arrayLength)
                {
                    switch (this.___arrayType)
                    {
                        case CHtmlNumericArrayType.Uint8ClampedArray:
                            return (double)this.___byteArray[___index];
                        case CHtmlNumericArrayType.Float64Array:
                        case CHtmlNumericArrayType.Float32Array:
                            return (double)this.___floatArray[___index];
                        case CHtmlNumericArrayType.Int8Array:
                        case CHtmlNumericArrayType.Int16Array:
                            return (double)this.___int16Array[___index];
                        case CHtmlNumericArrayType.Int32Array:
                            return (double)this.___int32Array[___index];
                        case CHtmlNumericArrayType.Int64Array:
                            return (double)this.___int64Array[___index];
                        case CHtmlNumericArrayType.Uint8Array:
                        case CHtmlNumericArrayType.Uint16Array:
                            return (double)this.___int16Array[___index];
                        case CHtmlNumericArrayType.Uint32Array:
                            return (double)this.___int32Array[___index];
                        case CHtmlNumericArrayType.Uint64Array:
                            return (double)this.___int64Array[___index];

                    }
                }
            }
            catch (Exception ex)
            {
                if (commonLog.LoggingEnabled &&commonLog.CommonLogLevel >= 8)
                {
                   commonLog.LogEntry("CHtmlNativeArray Exception.", ex);
                }
            }


            return 0;

        }
        public  void ___setPropertyByName(string ___name, object val)
        {
            if (commonLog.LoggingEnabled &&commonLog.CommonLogLevel >= 8)
            {
               commonLog.LogEntry("set : {0} = {1} for {2}", ___name, val, this);
            }
          
        }

        public  void ___setPropertyByIndex(int ___index, object ___val)
        {
            if (commonLog.LoggingEnabled &&commonLog.CommonLogLevel >= 1000)
            {
               commonLog.LogEntry("calling  {0} set by index {1} =  {2}", this, ___index, ___val);
            }
            try
            {
                switch (this.___arrayType)
                {
                    case CHtmlNumericArrayType.Uint8ClampedArray:
                        if (___index >= 0 && ___index < this.___byteArray.Length)
                        {
                            double doubleValue = commonData.GetDoubleFromObject(___val, 0);
                            this.___byteArray[___index] = System.Convert.ToByte(doubleValue);
                        }
                        break;
                    case CHtmlNumericArrayType.Float32Array:
                    case CHtmlNumericArrayType.Float64Array:
                        if (___index >= 0 && ___index < this.___floatArray.Length)
                        {
                            this.___floatArray[___index] = (float)commonData.GetDoubleFromObject(___val, 0);
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                if (commonLog.LoggingEnabled &&commonLog.CommonLogLevel >= 8)
                {
                   commonLog.LogEntry("CHtmlNativeArray Set by Index Error", ex);
                }
            }
        }

        public  bool ___hasPropertyByName(string ___name)
        {

                return false;
        }
        public  bool ___hasPropertyByIndex(int ___index)
        {
            return true;
        }
        public object ___common_object_clone()
        {
            if (commonLog.LoggingEnabled &&commonLog.CommonLogLevel >= 10)
            {
               commonLog.LogEntry("x__Clone {0} {1} called", this.GetType(), this);
            }
            return this;
        }
        public  void ___deleteByIndex(int ___index)
        {
            if (commonLog.LoggingEnabled &&commonLog.CommonLogLevel >= 10)
            {
               commonLog.LogEntry("___deleteByIndex {0} {1} called : {2}", this.GetType(), this, ___index);
            }
        }
        public  void ___deleteByName(string ___name)
        {
            if (commonLog.LoggingEnabled &&commonLog.CommonLogLevel >= 10)
            {
               commonLog.LogEntry("___deleteByName {0} {1} called : {2}", this.GetType(), this, ___name);
            }

        }
        public  object[] ___getByIds()
        {
            if (commonLog.LoggingEnabled &&commonLog.CommonLogLevel >= 10)
            {
               commonLog.LogEntry("___getByIds() {0} {1} called", this.GetType(), this);
            }
            return null;

        }
        public string ___getClassName()
        {
            if (commonLog.LoggingEnabled &&commonLog.CommonLogLevel >= 10)
            {
               commonLog.LogEntry("___getClassName {0} {1} called", this.GetType(), this);
            }
            return this.GetType().Name;
        }
        public  object ___getDefaultValue()
        {
            if (commonLog.LoggingEnabled &&commonLog.CommonLogLevel >= 10)
            {
               commonLog.LogEntry("___getDefaultValue {0} {1} called", this.GetType(), this);
            }
            return null;
        }
        public  object ___getParentScope()
        {
            if (commonLog.LoggingEnabled &&commonLog.CommonLogLevel >= 10)
            {
               commonLog.LogEntry("___getParentScope {0} {1} called", this.GetType(), this);
            }
            return null;
        }
        public void ___setParentScope(object ___object)
        {
            if (commonLog.LoggingEnabled &&commonLog.CommonLogLevel >= 10)
            {
               commonLog.LogEntry("___setParentScope {0} {1} called : {2}", this.GetType(), this, ___object);
            }
        }
        public  object ___getProtoType()
        {
            if (commonLog.LoggingEnabled &&commonLog.CommonLogLevel >= 10)
            {
               commonLog.LogEntry("___getProtoType {0} {1} called", this.GetType(), this);
            }
            return null;
        }
        public  bool ___hasInstance(object ___object)
        {
            if (commonLog.LoggingEnabled &&commonLog.CommonLogLevel >= 10)
            {
               commonLog.LogEntry("___hasInstance {0} {1} called : {2}", this.GetType(), this, ___object);
            }
            return false;
        }
        public bool ___instanceEquals(object ___object)
        {
            if (commonLog.LoggingEnabled &&commonLog.CommonLogLevel >= 10)
            {
               commonLog.LogEntry("___instanceEquals {0} {1} called : {2}", this.GetType(), this, ___object);
            }
            return object.ReferenceEquals(this, ___object);
        }
        public  void ___setProtoType(object ___object)
        {
            if (commonLog.LoggingEnabled &&commonLog.CommonLogLevel >= 10)
            {
               commonLog.LogEntry("___setProtoType {0} {1} called : {2}", this.GetType(), this, ___object);
            }
        }
        public override string ToString()
        {
            return "[object " + this.multiversalClassType.ToString() + "]";
        }
        public IMutilversalObjectType multiversalClassType
        {
            get
            {
                switch (this.___arrayType)
                {
                    case CHtmlNumericArrayType.ArrayBuffer:
                        return IMutilversalObjectType.ArrayBuffer;
                    case CHtmlNumericArrayType.Float64Array:
                        return IMutilversalObjectType.Float64Array;
                    case CHtmlNumericArrayType.Float32Array:
                        return IMutilversalObjectType.Float32Array;
                    case CHtmlNumericArrayType.Int8Array:
                        return IMutilversalObjectType.Int8Array;
                    case CHtmlNumericArrayType.Int16Array:
                        return IMutilversalObjectType.Int16Array;
                    case CHtmlNumericArrayType.Int32Array:
                        return IMutilversalObjectType.Int32Array;
                    case CHtmlNumericArrayType.Uint8Array:
                        return IMutilversalObjectType.Uint8Array;
                    case CHtmlNumericArrayType.Uint16Array:
                        return IMutilversalObjectType.Uint16Array;
                    case CHtmlNumericArrayType.Uint32Array:
                        return IMutilversalObjectType.Uint32Array;
                    case CHtmlNumericArrayType.TypedArray:
                        return IMutilversalObjectType.TypedArray;
                    case CHtmlNumericArrayType.ByteArray:
                        return IMutilversalObjectType.Array;
                }
                return IMutilversalObjectType.Unkown;
            }
        }

        #endregion
        public bool isPrototypeOf(object ___protoObject)
        {
            if (commonLog.LoggingEnabled &&commonLog.CommonLogLevel >= 8)
            {
               commonLog.LogEntry("calling {0}.isPrototpyeOf('{1}') ", this, ___protoObject);
            }
            switch (commonHTML.isPrototypeOf_precheck(this, ___protoObject))
            {
                case 0:
                default:
                    if (commonLog.LoggingEnabled &&commonLog.CommonLogLevel >= 8)
                    {
                       commonLog.LogEntry("TODO:  {0}.isPrototpyeOf('{1}') test needs more test. returns true for now... ", this, ___protoObject);
                    }
                    break;
                case 1:
                    return true;
                case 2:
                    return false;
            }
            return true;
        }

        #region Convert Array Into CHtmlNaveiArray
        internal delegate CHtmlNativeArray NativeArrayHandler(object ___objArray, CHtmlNumericArrayType ___targetType);
        internal static System.Collections.Generic.Dictionary<System.RuntimeTypeHandle, NativeArrayHandler> ___objectToCHtmlNativeArraySwitcher = ___createCHmlNativeArraySwitcher();
        private static System.Collections.Generic.Dictionary<System.RuntimeTypeHandle, NativeArrayHandler> ___createCHmlNativeArraySwitcher()
        {
            System.Collections.Generic.Dictionary<System.RuntimeTypeHandle, NativeArrayHandler> __list = new System.Collections.Generic.Dictionary<System.RuntimeTypeHandle, NativeArrayHandler>();
            __list[typeof(CHtmlNativeArray).TypeHandle] = new NativeArrayHandler(____getCHtmlNativeArrayIntoNewArray);


            __list[typeof(System.Array).TypeHandle] = new NativeArrayHandler(____getSystemArrayIntoNewArray);
            __list[typeof(System.Array).TypeHandle] = new NativeArrayHandler(____getJavaArrayIntoNewArray);
            return __list;

        }
        public static CHtmlNativeArray convertArrayObjectIntoCHtmlNativeArray(object ___objArray, CHtmlNumericArrayType ___targetType)
        {
            NativeArrayHandler __handler = null;
            Type ___currentArrayType = null;
            try
            {
                if (___objArray != null)
                {
                    ___currentArrayType = ___objArray.GetType();
                    if (___objectToCHtmlNativeArraySwitcher.TryGetValue(___currentArrayType.TypeHandle, out __handler))
                    {
                        return __handler(___objArray, ___targetType);
                    }
                }
            }
            catch (Exception exConvert)
            {
                if (commonLog.LoggingEnabled && commonLog.CommonLogLevel > 8)
                {
                    commonLog.LogEntry("convertArrayObjectIntoCHtmlNativeArray exception", exConvert);
                }
            }
            if (commonLog.LoggingEnabled && commonLog.CommonLogLevel > 3)
            {
                commonLog.LogEntry("TODO : convertArrayObjectIntoCHtmlNativeArray failed : {0}, returning empty array...", ___currentArrayType);
            }
            CHtmlNativeArray ___resultArray = new CHtmlNativeArray(___targetType);
            return ___resultArray;


        }
        private static CHtmlNativeArray ____getCHtmlNativeArrayIntoNewArray(object ___objArray, CHtmlNumericArrayType ___targetType)
        {
            CHtmlNativeArray __originalBytesList = ___objArray as CHtmlNativeArray;
            if (___targetType == CHtmlNumericArrayType.None)
            {
                ___targetType = __originalBytesList.___arrayType;
            }
            CHtmlNativeArray ___byteArrayList = new CHtmlNativeArray(___targetType);

            ___byteArrayList.___arrayLength = __originalBytesList.___arrayLength;
            switch (___targetType)
            {
                case CHtmlNumericArrayType.Uint8ClampedArray:
                case CHtmlNumericArrayType.ByteArray:
                    ___byteArrayList.___byteArray = new byte[__originalBytesList.___byteArray.Length];
                    Array.Copy(__originalBytesList.___byteArray, ___byteArrayList.___byteArray, __originalBytesList.___byteArray.Length);
                    ___byteArrayList.___width = __originalBytesList.___width;
                    ___byteArrayList.___height = __originalBytesList.___height;
                    break;
                case CHtmlNumericArrayType.Float32Array:
                case CHtmlNumericArrayType.Float64Array:
                    ___byteArrayList.___floatArray = new float[__originalBytesList.___floatArray.Length];
                    Array.Copy(__originalBytesList.___floatArray, ___byteArrayList.___floatArray, __originalBytesList.___floatArray.Length);
                    break;
                default:
                    if (commonLog.LoggingEnabled &&commonLog.CommonLogLevel >= 8)
                    {
                       commonLog.LogEntry("TODO: ____getCHtmlNativeArrayIntoNewArray Copy");
                    }
                    break;

            }

            return ___byteArrayList;

        }
        #endregion


    }
}
