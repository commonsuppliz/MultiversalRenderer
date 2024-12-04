using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using sun.management.counter;
using javax.swing.@event;

namespace MultiversalRenderer.Core
{
    /// <summary>
    /// This class used for Type Conversion
    /// </summary>
    public static class commonTypeConverter
    {



        public static CHtmlElement convertObjectIntoCHtmlElement(object __object)
        {
            switch (__object)
            {
                case CHtmlMediaElement __mediaElement:
                    return __mediaElement;
                case CHtmlSVGElement __svgElement: return __svgElement;
                case CHtmlTemplateElement __svgTemplateElement: return __svgTemplateElement;

                case CHtmlElement cHtmlElement:
                    return cHtmlElement;

                case RhinoNetProcessor.MultiversalWrapperObject multiversalrhinoobj:
                    if (multiversalrhinoobj != null)
                    {
                        object ___unwrapedObject = multiversalrhinoobj.unwrap();
                        if (___unwrapedObject is CHtmlElement)
                        {
                            return ___unwrapedObject as CHtmlElement;
                        }
                    }
                    return null;
                case org.mozilla.javascript.NativeObject rhionoNativeObject:
                    ;
                    if (commonLog.LoggingEnabled && commonLog.LogLevel >= 5)
                    {
                        commonLog.LogEntry("TODO:___convertRhinoNativeObjectToElement({0})  fails.", rhionoNativeObject);
                    }
                    return null;

                case string stringobj:
                    if (commonLog.LoggingEnabled && commonLog.LogLevel >= 10)
                    {
                        commonLog.LogEntry("newElement is text...create one.");
                    }


                    if (string.IsNullOrEmpty(stringobj) == true || stringobj == "undefined")
                    {
                        return null;
                    }
                    CHtmlTextElement textElement = new CHtmlTextElement();
                    textElement.___IsDynamicElement = true;
                    textElement.value = stringobj;
                    return textElement;
                    break;

                case object objobject:
                    if (commonLog.LoggingEnabled && commonLog.LogLevel >= 10)
                    {

                        commonLog.LogEntry("ConvertObjectIntoElement() Unknown object Type to convert!  : {0}", objobject);


                    }
                    break;
            }

            if (commonLog.LoggingEnabled && commonLog.LogLevel >= 10)
            {
                if (__object != null)
                {

                    commonLog.LogEntry("ConvertObjectIntoElement() Unknown object Type to convert!  : {0} Type : {1}", __object, __object.GetType());
                }
                else
                {
                    commonLog.LogEntry("ConvertObjectIntoElement() Unknown object Type to convert!  : {0}", __object);

                }
            }



            return null;
        }
    


  
        public static bool convertObjectToBoolean(object _boolObj, bool defaultBool)
        {

            switch (_boolObj)
            {
                case bool __bool:
                    return __bool;
                case string __string:
                    return ConvertStringToBoolWithSwitch(__string);
                case java.lang.Boolean ___jbool:
                    return ___jbool.booleanValue();
            
            }
            if (commonLog.LoggingEnabled && commonLog.LogLevel >= 10)
            {
                commonLog.LogEntry("TypeConverter Unable to convert object to Boolean {0}", _boolObj);
            }

                return false;
        }
        /*
        private static bool ConvertOrgMozilaConStringToBool(object obj)
        {
            org.mozilla.javascript.ConsString conStr = (org.mozilla.javascript.ConsString)obj;
            return ConvertStringToBoolWithSwitch(conStr.toString());

        }
        */
        private static bool ConvertStringToBoolWithSwitch(string s)
        {
            switch (s)
            {
                case "T":
                case "t":
                case "Y":
                case "y":
                case "True":
                case "true":
                case "TRUE":
                case "Yes":
                case "yes":
                case "YES":
                case "always":
                case "Always":
                case "ALWAYS":
                case "1":
                case "on":
                case "On":
                case "ON":
                    return true;
                case "false":
                case "False":
                case "FALSE":
                case "0":
                case "-1":
                case "off":
                case "none":
                case "NONE":
                case "None":
                case "Never":
                case "never":
                case "NEVER":
                case "No":
                case "NO":
                case "OFF":
                case "Hidden":
                case "hidden":
                case "n":
                case "N":
                case "F":
                case "f":
                    return false;
            }
            return false;
        }


        #region ImageHanderSection
        private delegate System.Drawing.Image ImageContentTypeHander(byte[] bts, int contentLength);
        private static System.Collections.Generic.Dictionary<string, ImageContentTypeHander> imageGenereteSwitcher = createImageSwitcher();
        private static System.Collections.Generic.Dictionary<string, ImageContentTypeHander> createImageSwitcher()
        {
            System.Collections.Generic.Dictionary<string, ImageContentTypeHander> list = new System.Collections.Generic.Dictionary<string, ImageContentTypeHander>();
            list["image/png"] = new ImageContentTypeHander(___convertBytesToImageGeneric);
            list["image/gif"] = new ImageContentTypeHander(___convertBytesToImageGeneric);
            list["image/jpeg"] = new ImageContentTypeHander(___convertBytesToImageGeneric);
            list["image/jpg"] = new ImageContentTypeHander(___convertBytesToImageGeneric);
            list["image/bmp"] = new ImageContentTypeHander(___convertBytesToImageGeneric);
            list["image/svg"] = new ImageContentTypeHander(___convertBytesToSVGImage);
            list["image/svg+xml"] = new ImageContentTypeHander(___convertBytesToSVGImage);
            list["image/svgxml"] = new ImageContentTypeHander(___convertBytesToSVGImage);
            list["image/svg xml"] = new ImageContentTypeHander(___convertBytesToSVGImage);
            list["application/svg"] = new ImageContentTypeHander(___convertBytesToSVGImage);
            list["application/svg+xml"] = new ImageContentTypeHander(___convertBytesToSVGImage);
            list["image/webp"] = new ImageContentTypeHander(___convertBytesToWebpImage);
            return list;
        }

        private static System.Drawing.Image ___convertBytesToImageGeneric(byte[] bts, int ContentLength)
        {
            if (bts == null || bts.Length == 0)
            {
                return null;
            }
            System.IO.MemoryStream mStream = null;
            System.Drawing.Image img = null;
            try
            {
                mStream = new MemoryStream(bts);
                img = Image.FromStream(mStream, false, true); // image Validation is requred.
                // ============================================================
                // DO NOT DISPOSE memory stream!!! IT WILL AUTOMALLY DISPOSED When image.dispose().
                /// ============================================================
                return img;
            }
            catch (Exception exImage)
            {
                if (commonLog.LoggingEnabled && commonLog.LogLevel >= 8)
                {
                    commonLog.LogEntry("___convertBytesToImageGeneric() Exception. return null.", exImage);
                }
            }
            return null;
        }
        private static System.Drawing.Image ___convertBytesToSVGImage(byte[] bts, int ContentLength)
        {
            Image bmp = null;
            try
            {
       
            }
            catch (Exception exSvg)
            {
                if (commonLog.LoggingEnabled && commonLog.LogLevel >= 30)
                {
                    commonLog.LogEntry(string.Format("reateSVGImageFromString SVG Rendering Error", exSvg));

                }
            }
            return bmp;
        }
        private static System.Drawing.Image ___convertBytesToWebpImage(byte[] bts, int ContentLength)
        {
            Image bmp = null;
            try
            {

            }
            catch (Exception exSvg)
            {
                if (commonLog.LoggingEnabled && commonLog.LogLevel >= 30)
                {
                    commonLog.LogEntry(string.Format("reateSVGImageFromString WebP Rendering Error", exSvg));

                }
            }
            return bmp;
        }
        public static System.Drawing.Image convertBytesIntoImage(byte[] bts, string contentType, int contentLength)
        {
            ImageContentTypeHander handler = null;
            try
            {
                if (imageGenereteSwitcher.TryGetValue(contentType, out handler) == true)
                {
                    return handler(bts, contentLength);
                }
                else
                {
                    if (commonLog.LoggingEnabled && commonLog.LogLevel > 8)
                    {
                        commonLog.LogEntry("convertBytesIntoImage(bytes, {0}, {1}) image handler is not set", contentType, contentLength);
                    }
                }
            }
            catch (Exception ex)
            {
                if (commonLog.LoggingEnabled && commonLog.LogLevel > 8)
                {
                    commonLog.LogEntry("convertBytesIntoImage(bytes, {0}, {1}) image exception Reason : {2}", contentType, contentLength, ex.Message);
                }
            }
            return null;
        }
        #endregion

        #region DateTimeSection


        public static DateTime convertObjectIntoDateTime(object objDate)
        {
            if (objDate != null)
            {
                try
                {
                    switch(objDate)
                    {
                        case DateTime dtTime:
                            return dtTime;
                        case org.mozilla.javascript.ScriptableObject rhinoDatet:
                            return ___convertRhinoDateTimeToDateTime(objDate);
                        case java.util.Date jDate:
                            return ___convertJavaUtilDateToDateTime(objDate);
                    }
                    // ===============================================================
                    // org.mozilla.javascript.NativeDate is not public.
                    // it seems hander solution does not work this type.
                    // Therefore, use "As" to convert at first.
                    // ===============================================================

                }
                catch (Exception ex)
                {
                    if (commonLog.LoggingEnabled && commonLog.LogLevel > 10)
                    {
                        commonLog.LogEntry("commonTypeConverter.convertObjectIntoDateTime() Exception", ex);
                    }
                }
                return DateTime.Now;
            }
            else
            {
                return DateTime.Now;
            }
        }

        private static DateTime ___convertObjectToDateTime(object ___obj)
        {
            return (DateTime)___obj;
        }
        private static DateTime ___convertJavaUtilDateToDateTime(object ___obj)
        {
            java.util.Date javaDate = ___obj as java.util.Date;
            java.time.LocalDateTime localDateTime = javaDate.toInstant().atZone(java.time.ZoneId.systemDefault()).toLocalDateTime();
            /*
            DateTime date = new DateTime(javaDate.getYear() + 1900,
                                         javaDate.getMonth() + 1,
                                         javaDate.getDate(),
                                         javaDate.getHours(),
                                         javaDate.getMinutes(),
                                         javaDate.getSeconds());
            return date;
            */
            return new DateTime(localDateTime.getYear(),
                 localDateTime.getYear(),
                 localDateTime.getDayOfMonth(),
                 localDateTime.getHour(),
                 localDateTime.getMinute(),
                 localDateTime.getSecond());

        }
        private static DateTime ___convertRhinoDateTimeToDateTime(object ___obj)
        {
            org.mozilla.javascript.Scriptable scriptableDate = ___obj as org.mozilla.javascript.Scriptable;
            java.util.Date javaDate = org.mozilla.javascript.Context.jsToJava(scriptableDate, typeof(java.util.Date)) as java.util.Date;
            if (javaDate != null)
            {
                return new DateTime((javaDate.getTime() + 62135596800000L) * 10000, DateTimeKind.Utc);
            }
            else
            {
                return DateTime.Now;
            }
        }
        #endregion




        #region ConvertNativeArrayToFloatArray

        public delegate float[] NativeArrayConvertHander(object ___arrayObject, int ____offset, int ___length);
        public static System.Collections.Generic.Dictionary<System.RuntimeTypeHandle, NativeArrayConvertHander> ___nativeArrayTypeSwitcher = ___createNativeArrayConvertSwither();
        public static System.Collections.Generic.Dictionary<System.RuntimeTypeHandle, NativeArrayConvertHander> ___createNativeArrayConvertSwither()
        {
            System.Collections.Generic.Dictionary<System.RuntimeTypeHandle, NativeArrayConvertHander> list = new Dictionary<RuntimeTypeHandle, NativeArrayConvertHander>();
            list[typeof(System.Array).TypeHandle] = new NativeArrayConvertHander(___convertSystemArrayToFloatArray);
            list[typeof(org.mozilla.javascript.NativeArray).TypeHandle] = new NativeArrayConvertHander(___convertOrgMozillaNativeArrayToFloatArray);
            list[typeof(CHtmlNativeArray).TypeHandle] = new NativeArrayConvertHander(___convertCHtmlNativeArrayToFloatArray);
            // ============================================================================================================
            // Rhino Javascript NativeTypedArray Class Conversion
            // ============================================================================================================
            list[typeof(org.mozilla.javascript.typedarrays.NativeArrayBuffer).TypeHandle] = new NativeArrayConvertHander(___convertOrgMozillaJavascriptNativeTypedArrayToFloatArray);
            list[typeof(org.mozilla.javascript.typedarrays.NativeDataView).TypeHandle] = new NativeArrayConvertHander(___convertOrgMozillaJavascriptNativeTypedArrayToFloatArray);
            list[typeof(org.mozilla.javascript.typedarrays.NativeInt8Array).TypeHandle] = new NativeArrayConvertHander(___convertOrgMozillaJavascriptNativeTypedArrayToFloatArray);
            list[typeof(org.mozilla.javascript.typedarrays.NativeInt16Array).TypeHandle] = new NativeArrayConvertHander(___convertOrgMozillaJavascriptNativeTypedArrayToFloatArray);
            list[typeof(org.mozilla.javascript.typedarrays.NativeInt32Array).TypeHandle] = new NativeArrayConvertHander(___convertOrgMozillaJavascriptNativeTypedArrayToFloatArray);
            list[typeof(org.mozilla.javascript.typedarrays.NativeUint8Array).TypeHandle] = new NativeArrayConvertHander(___convertOrgMozillaJavascriptNativeTypedArrayToFloatArray);
            list[typeof(org.mozilla.javascript.typedarrays.NativeUint16Array).TypeHandle] = new NativeArrayConvertHander(___convertOrgMozillaJavascriptNativeTypedArrayToFloatArray);
            list[typeof(org.mozilla.javascript.typedarrays.NativeUint32Array).TypeHandle] = new NativeArrayConvertHander(___convertOrgMozillaJavascriptNativeTypedArrayToFloatArray);
            list[typeof(org.mozilla.javascript.typedarrays.NativeUint8ClampedArray).TypeHandle] = new NativeArrayConvertHander(___convertOrgMozillaJavascriptNativeTypedArrayToFloatArray);
            list[typeof(org.mozilla.javascript.typedarrays.NativeFloat32Array).TypeHandle] = new NativeArrayConvertHander(___convertOrgMozillaJavascriptNativeTypedArrayToFloatArray);
            list[typeof(org.mozilla.javascript.typedarrays.NativeFloat64Array).TypeHandle] = new NativeArrayConvertHander(___convertOrgMozillaJavascriptNativeTypedArrayToFloatArray);
            list[typeof(org.mozilla.javascript.typedarrays.NativeTypedArrayView).TypeHandle] = new NativeArrayConvertHander(___convertOrgMozillaJavascriptNativeTypedArrayToFloatArray);
            // ==============================================================================================================
            // ==============================================================================================================
            return list;
        }
        #region ConvertionUtils
        public static float[] ___convertSystemArrayToFloatArray(object ___object, int ____offset, int ___length)
        {
            float[] ___floatArray;
            System.Array ___objectArray = (System.Array)___object;

            int ___intLen = ___objectArray.Length;
            ___floatArray = new float[___intLen];
            for (int i = 0; i < ___intLen; i++)
            {
                ___floatArray[i] = (float)___objectArray.GetValue(i);
            }


            return ___floatArray;
        }
        public static float[] ___convertCHtmlNativeArrayToFloatArray(object ___object, int ____offset, int ___length)
        {
            CHtmlNativeArray ___numBase = ___object as CHtmlNativeArray;
            float[] ___floatArray;
            ___floatArray = new float[___length];
            if (___numBase.___floatArray != null)
            {
                Array.Copy(___numBase.___floatArray, ___floatArray, ___numBase.___floatArray.Length);
                return ___floatArray;
            }
            int ___int16ArrayLen = ___numBase.___int16Array.Length;
            if (___numBase.___int16Array != null)
            {
                for (int i = 0; i < ___int16ArrayLen; i++)
                {
                    ___floatArray[i] = (float)___numBase.___int16Array[i];
                }
                return ___floatArray;
            }
            if (___numBase.___int32Array != null)
            {
                int ___numBaseint32ArrayLength = ___numBase.___int32Array.Length;
                for (int i = 0; i < ___numBaseint32ArrayLength; i++)
                {
                    ___floatArray[i] = (float)___numBase.___int32Array[i];
                }
                return ___floatArray;
            }
            if (___numBase.___int64Array != null)
            {
                int ___numBaseint64ArrayLen = ___numBase.___int64Array.Length;
                for (int i = 0; i < ___numBaseint64ArrayLen; i++)
                {
                    ___floatArray[i] = (float)___numBase.___int64Array[i];
                }
                return ___floatArray;
            }


            return ___floatArray;
        }
        public static float[] ___convertOrgMozillaNativeArrayToFloatArray(object ___object, int ____offset, int ___length)
        {
            org.mozilla.javascript.NativeArray jarray = (org.mozilla.javascript.NativeArray)___object;
            object[] objectArray = jarray.toArray();
            float[] ___floatArray = new float[objectArray.Length];
            int ___DataType = -1;
            if (objectArray.Length > 0)
            {
                if (objectArray[0] is java.lang.Number)
                {
                    ___DataType = 10;
                }
                else
                {
                    ___DataType = 99;
                }
            }
            int objectArrayLen = objectArray.Length;
            for (int i = 0; i < objectArrayLen; i++)
            {
                switch (___DataType)
                {
                    case 10:
                        java.lang.Number number = objectArray[i] as java.lang.Number;
                        ___floatArray[i] = number.floatValue();

                        break;
                    case 99:
                        ___floatArray[i] = (float)objectArray[i];
                        break;

                }
            }
            return ___floatArray;
        }
        #endregion

        internal static byte[] ___convertOrgMozillaJavascriptNativeArrayBufferToByteArray(object ___object, int ___offset, int __length)
        {
            org.mozilla.javascript.typedarrays.NativeArrayBuffer nativeArrayBuffer = ___object as org.mozilla.javascript.typedarrays.NativeArrayBuffer;
            return nativeArrayBuffer.getBuffer();
        }
        internal static byte[] ___convertOrgMozillaJavascriptNativeInt8ArrayToByteArray(object ___object, int ___offset, int __length)
        {
            org.mozilla.javascript.typedarrays.NativeInt8Array nativeInt8Array = ___object as org.mozilla.javascript.typedarrays.NativeInt8Array;
            return nativeInt8Array.getBuffer().getBuffer();
        }
        internal static byte[] ___convertOrgMozillaJavascriptNativeUint8ClapedArrayToByteArray(object ___object, int ___offset, int __length)
        {
            org.mozilla.javascript.typedarrays.NativeUint8ClampedArray  clampedArray = ___object as org.mozilla.javascript.typedarrays.NativeUint8ClampedArray;
            return clampedArray.getBuffer().getBuffer();
        }



        internal static float[] ___convertOrgMozillaJavascriptNativeTypedArrayToFloatArray(object ___object, int ___offset, int __length)
        {
            bool isConverted = false;
            List<float> resultList = new List<float>();
            long arrayLen = 0;
            try
            {
                switch (___object)
                {
                    case org.mozilla.javascript.typedarrays.NativeArrayBuffer nativeArrayBuffer:
                        byte[] byteArray1 = nativeArrayBuffer.getBuffer();
                        for (int i = 0; i < byteArray1.Length; i++)
                        {
                            resultList.Add(byteArray1[i]);
                        }
                        isConverted = true;
                        break;
                    case org.mozilla.javascript.typedarrays.NativeFloat32Array nativeFloat32Array:
                        arrayLen = nativeFloat32Array.getArrayLength();
                        for(int i = 0; i < arrayLen; i++)
                        {
                            resultList.Add((float)nativeFloat32Array.get(i).doubleValue());
                        }
                        isConverted = true;
                        break;
                    case org.mozilla.javascript.typedarrays.NativeFloat64Array nativeFloat64Array:
                        arrayLen = nativeFloat64Array.getArrayLength();
                        for (int i = 0; i < arrayLen; i++)
                        {
                            resultList.Add((float)nativeFloat64Array.get(i).doubleValue());
                        }
                        isConverted = true;
                        break;
                    case org.mozilla.javascript.typedarrays.NativeInt8Array nativeInt8Array:
                        arrayLen = nativeInt8Array.getArrayLength();
                        for(int i = 0; i < arrayLen; i ++)
                        {
                            resultList.Add(nativeInt8Array.get(i).floatValue());
                        }
                        isConverted = true;
                        break;
                    case org.mozilla.javascript.typedarrays.NativeInt16Array nativeInt16Array:
                        arrayLen = nativeInt16Array.getArrayLength();
                        for (int i = 0; i < arrayLen; i++)
                        {
                            resultList.Add(nativeInt16Array.get(i).floatValue());
                        }
                        isConverted = true;
                        break;
                    case org.mozilla.javascript.typedarrays.NativeInt32Array nativeInt32Array:
                        arrayLen = nativeInt32Array.getArrayLength();
                        for (int i = 0; i < arrayLen; i++)
                        {
                            resultList.Add(nativeInt32Array.get(i).floatValue());
                        }
                        isConverted = true;
                        break;
                    case org.mozilla.javascript.typedarrays.NativeUint8Array nativeUint8Array:
                        org.mozilla.javascript.typedarrays.NativeArrayBuffer arrayBuffer1 = nativeUint8Array.getBuffer();
                        byte[] byteArray3 = arrayBuffer1.getBuffer();
                        for (int i = 0; i < byteArray3.Length; i++)
                        {
                            resultList.Add(byteArray3[i]);
                        }
                        isConverted = true;
                        break;
                    case org.mozilla.javascript.typedarrays.NativeUint16Array nativeUint16Array:
                        arrayLen = nativeUint16Array.getArrayLength();
                        for (int i = 0; i < arrayLen; i++)
                        {
                            java.lang.Integer uint16 = nativeUint16Array.get(i);
                            resultList.Add(uint16.floatValue());
                        }
                        isConverted = true;
                        break;
                    case org.mozilla.javascript.typedarrays.NativeUint32Array nativeUint32Array:
                        arrayLen = nativeUint32Array.getArrayLength();
                        for (int i = 0; i < arrayLen; i++)
                        {
                            java.lang.Long long32 = nativeUint32Array.get(i);
                            resultList.Add(long32.floatValue());
                        }
                        isConverted = true;
                        break;
                    case org.mozilla.javascript.typedarrays.NativeUint8ClampedArray nativeUint8ClapedArray:
                        org.mozilla.javascript.typedarrays.NativeArrayBuffer arrayBuffer = nativeUint8ClapedArray.getBuffer();
                        byte[] byteArray2 = arrayBuffer.getBuffer();

                        for (int i = 0; i < byteArray2.Length; i++)
                        {
                            resultList.Add(byteArray2[i]);
                        }
                        isConverted = true;
                        break;
                }
            }catch(Exception ex)
            {
                isConverted = false;
                if (commonLog.LoggingEnabled && commonLog.LogLevel > 10)
                {
                    commonLog.LogEntry("___convertOrgMozillaJavascritNativeTypedArrayToFloatArray() Error", ex);
                }
            }
            if(!isConverted)
            {
                if (commonLog.LoggingEnabled && commonLog.LogLevel > 8)
                {
                    commonLog.LogEntry("TODO: ___convertOrgMozillaJavascritNativeTypedArrayToFloatArray()  conversion missing");
                }
            }
            else
            {
                if (commonLog.LoggingEnabled && commonLog.LogLevel > 8)
                {
                    commonLog.LogEntry(" ___convertOrgMozillaJavascritNativeTypedArrayToFloatArray() created array length : {0}", resultList.Count);
                }
            }
            return resultList.ToArray();
        }

        internal static float[] ___convertObjectIntoFloatArray(object ___object, int ___offset, int __length)
        {
            NativeArrayConvertHander handler;
            if (___object == null)
            {
                return new float[0];
            }
            if (___nativeArrayTypeSwitcher.TryGetValue(___object.GetType().TypeHandle, out handler))
            {
                return handler(___object, ___offset, ___offset);
            }
            else
            {
                if (commonLog.LoggingEnabled && commonLog.LogLevel > 3)
                {
                    commonLog.LogEntry("TODO Needs Type Swicher for ___convertObjectIntoFloatArray({0} , {1},  {2}) : Type {3}", ___object, ___offset, __length, ___object.GetType());
                }
                return new float[] { };
            }




            #endregion
        }
    }
}
