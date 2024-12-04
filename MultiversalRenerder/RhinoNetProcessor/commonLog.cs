using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MultiversalRenderer.RhinoNetProcessor
{
	using System;
	using System.IO;
	using NLog;
#if DEBUG
	using System.Diagnostics;
#endif


		/// <summary>
		/// commonLog 
		/// </summary>
#pragma warning disable IDE1006 // 命名スタイル
		public static class commonLog
#pragma warning restore IDE1006 // 命名スタイル
		{
			private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();

		    public static bool LoggingEnabled
		{
			get { return NLog.LogManager.IsLoggingEnabled(); }

		}
		
		public static int LogLevel
		{
			get
			{
				/*
                if (NLog.LogManager.Configuration.Variables.TryGetValue("LogLevel", out NLog.Layouts.Layout simpValue) == true)
                {
                    if (int.TryParse(simpValue., out int result) == true)
                    {
                        return result;
                    }
                }
				*/
                return 0;
			}
		}

			public static void LogEntry(string str, params object[] args)
			{
				Logger.Info(string.Format(str, args));
			}
			public static void LogEntry(string str)
			{
				Logger.Info(str);
			}
			public static void LogEntry(System.Exception ex)
			{
				Logger.Error(ex);
			}
			public static void LogEntry(string strName, Exception ex)
			{
				Logger.Error(ex, strName);
			}
		}
	}


