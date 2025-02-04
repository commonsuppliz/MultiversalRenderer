﻿using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;


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




                case string stringobj:
                    if (commonLog.LoggingEnabled && commonLog.CommonLogLevel >= 10)
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
                    if (commonLog.LoggingEnabled && commonLog.CommonLogLevel >= 10)
                    {

                        commonLog.LogEntry("ConvertObjectIntoElement() Unknown object Type to convert!  : {0}", objobject);


                    }
                    break;
            }

            if (commonLog.LoggingEnabled && commonLog.CommonLogLevel >= 10)
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

            
            }
            if (commonLog.LoggingEnabled && commonLog.CommonLogLevel >= 10)
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
                if (commonLog.LoggingEnabled && commonLog.CommonLogLevel >= 8)
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
                if (commonLog.LoggingEnabled && commonLog.CommonLogLevel >= 30)
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
                if (commonLog.LoggingEnabled && commonLog.CommonLogLevel >= 30)
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
                    if (commonLog.LoggingEnabled && commonLog.CommonLogLevel > 8)
                    {
                        commonLog.LogEntry("convertBytesIntoImage(bytes, {0}, {1}) image handler is not set", contentType, contentLength);
                    }
                }
            }
            catch (Exception ex)
            {
                if (commonLog.LoggingEnabled && commonLog.CommonLogLevel > 8)
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

                    }
                    // ===============================================================
                    // org.mozilla.javascript.NativeDate is not public.
                    // it seems hander solution does not work this type.
                    // Therefore, use "As" to convert at first.
                    // ===============================================================

                }
                catch (Exception ex)
                {
                    if (commonLog.LoggingEnabled && commonLog.CommonLogLevel > 10)
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


        #endregion




        #region ConvertNativeArrayToFloatArray

        public delegate float[] NativeArrayConvertHander(object ___arrayObject, int ____offset, int ___length);
        public static System.Collections.Generic.Dictionary<System.RuntimeTypeHandle, NativeArrayConvertHander> ___nativeArrayTypeSwitcher = ___createNativeArrayConvertSwither();
        public static System.Collections.Generic.Dictionary<System.RuntimeTypeHandle, NativeArrayConvertHander> ___createNativeArrayConvertSwither()
        {
            System.Collections.Generic.Dictionary<System.RuntimeTypeHandle, NativeArrayConvertHander> list = new Dictionary<RuntimeTypeHandle, NativeArrayConvertHander>();
            list[typeof(System.Array).TypeHandle] = new NativeArrayConvertHander(___convertSystemArrayToFloatArray);
            list[typeof(CHtmlNativeArray).TypeHandle] = new NativeArrayConvertHander(___convertCHtmlNativeArrayToFloatArray);
            // ============================================================================================================
            // Rhino Javascript NativeTypedArray Class Conversion

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

        #endregion




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
                if (commonLog.LoggingEnabled && commonLog.CommonLogLevel > 3)
                {
                    commonLog.LogEntry("TODO Needs Type Swicher for ___convertObjectIntoFloatArray({0} , {1},  {2}) : Type {3}", ___object, ___offset, __length, ___object.GetType());
                }
                return new float[] { };
            }




            #endregion
        }
    }
}
