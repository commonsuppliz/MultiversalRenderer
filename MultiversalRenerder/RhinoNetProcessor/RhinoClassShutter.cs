using System;
using System.Collections.Generic;
using System.Text;

namespace MultiversalRenderer.RhinoNetProcessor
{
    /// <summary>
    /// Obsolute:
    /// 17R6 has safe way of    con.initSafeStandardObjects(this, false);
    /// </summary>
    public sealed class RhinoClassShutter : org.mozilla.javascript.ClassShutter
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="fullClassName"></param>
        /// <returns>Return true iff the Java class with the given name should be exposed to scripts.</returns>

        public bool visibleToScripts(string fullClassName)
        {
            if (System.Diagnostics.Debugger.IsAttached && commonLog.LogLevel >= 100)
            {
                commonLog.LogEntry("Rhino ClassShutter trying to access class : {0}", fullClassName);
            }
            if (commonLog.LoggingEnabled && commonLog.LogLevel >= 100)
            {
                commonLog.LogEntry("Rhino ClassShutter trying to access class : {0}", fullClassName);
            }
           
            if (fullClassName.Length > 3)
            {
                if (fullClassName.Length == 4)
                {
                    if (string.Equals(fullClassName, "void", StringComparison.Ordinal) == true)
                    {
                        return true;
                    }
                }
                if (fullClassName.Length >= 5 && fullClassName[3] == '.')
                {
                    if (fullClassName[4] == 'C' && fullClassName[5] == 'o')
                    {
                        return true;
                    }
                    else if (fullClassName[4] == 'm' && fullClassName[5] == 'o')
                    {
                        return true;
                    }

                }
            }

            int posPeriod = fullClassName.LastIndexOf('.');
            string strObject = null;
            if (posPeriod > -1)
            {
                strObject = fullClassName.Substring(posPeriod + 1);
                switch (strObject)
                {
                    case "Object":
                        return true;
                    case "Integer":
                        return true;
                    case "String":
                    case "String;":
                        return true;
                    case "Date":
                    case "DateTime":
                        return true;
                    case "NullPointerException":
                        return true;
                    case "WebException":
                        return true;
                    case "EcmaError":
                        return true;
                }
            }
            else
            {
                // No "." may be just namespace. returns true always.
                return true;
            }



            if (commonLog.LoggingEnabled && commonLog.LogLevel >= 8)
            {
                commonLog.LogEntry("Rhino ClassShutter disallows access to : {0}", fullClassName);
            }
            return false;
        }
    }
}
