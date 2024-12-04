using System;
using System.Collections.Generic;
using System.Text;

namespace MultiversalRenderer.RhinoNetProcessor
{
    /// <summary>
    /// This class is not related to Rhino interpreter.
    /// .Mono 4.0 still has problem decode PNG image correctly, I decide to use Java API to decode PNG under Linux or MAC
    /// This is just ad hoc api.
    /// </summary>
    public sealed class JavaImageIOReader
    {
        public static System.Reflection.MethodInfo ___getBitmapMethodInfo = null;
        public object readImage(string ___strPath)
        {
            java.awt.image.BufferedImage bufferedImage = null;
            try
            {
                bufferedImage = javax.imageio.ImageIO.read(new java.io.File(___strPath));
                if ( ___getBitmapMethodInfo == null)
                {
                    Type typeBufferImageIO = typeof(java.awt.image.BufferedImage);
                    if (typeBufferImageIO != null)
                    {
                        ___getBitmapMethodInfo = typeBufferImageIO.GetMethod("getBitmap");
                    }
                                        
                }
                if (___getBitmapMethodInfo != null && bufferedImage != null)
                {
                    return ___getBitmapMethodInfo.Invoke(bufferedImage, null);
                }
            }
            catch (Exception ex)
            {
                if (commonLog.LoggingEnabled && commonLog.LogLevel >= 10)
                {
                    commonLog.LogEntry("RhinoUtils.readImageFile() Exception.", ex);
                }
            }
            return null;
        }
        public object readImage(byte[] bts)
        {
            java.awt.image.BufferedImage bufferedImage = null;
            try
            {
                java.io.InputStream inputStream = new java.io.ByteArrayInputStream(bts);
                bufferedImage = javax.imageio.ImageIO.read(inputStream);
                if (___getBitmapMethodInfo == null)
                {
                    Type typeBufferImageIO = typeof(java.awt.image.BufferedImage);
                    if (typeBufferImageIO != null)
                    {
                        ___getBitmapMethodInfo = typeBufferImageIO.GetMethod("getBitmap");
                    }

                }
                if (___getBitmapMethodInfo != null && bufferedImage != null)
                {
                    return ___getBitmapMethodInfo.Invoke(bufferedImage, null);
                }
            }
            catch (Exception ex)
            {
                if (commonLog.LoggingEnabled && commonLog.LogLevel >= 10)
                {
                    commonLog.LogEntry("RhinoUtils.readImageFile() Exception.", ex);
                }
            }
            return null;
        }
    }
}
