using System;
using System.Collections;
using System.Text;
using MultiversalRenderer.Interfaces;

namespace MultiversalRenderer.Core
{
	/// <summary>
	/// CHtmlConsole 
	/// console class
	/// </summary>
	
	public sealed class CHtmlConsole : CHtmlNode, ICommonObjectInterface
	{

		

		public CHtmlConsole()
		{
            this.___multiversalClassType = IMutilversalObjectType.Console;
			
		}
		~CHtmlConsole()
		{

		}
        private void ___log_inner(string str)
        {
            if (commonLog.LoggingEnabled || System.Diagnostics.Debugger.IsAttached)
            {
               commonLog.LogEntry(string.Concat("console.log('", str, "')"));
            }
        }

        public void log(params object[] args)
        {
            StringBuilder sb = new StringBuilder();
            foreach (object arg in args)
            {
                sb.Append(commonHTML.GetStringValue(arg));
            }
       
            if (commonLog.LoggingEnabled || System.Diagnostics.Debugger.IsAttached)
            {
                commonLog.LogEntry($"(console.log{sb.ToString()})");
            }
        }
   
    
        #region warn
        private void ___warn_inner(string str)
        {
            if (commonLog.LoggingEnabled)
            {
               commonLog.LogEntry(string.Concat("console.warn('", str, "')"));
            }
        }
   
        public void warn()
        {
            this.___warn_inner("");
        }

   
        public void warn(object _s1)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(commonHTML.GetStringValue(_s1));
            this.___warn_inner(sb.ToString());

        }

   
        public void warn(object _s1, object _s2)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(commonHTML.GetStringValue(_s1));
            sb.Append(commonHTML.GetStringValue(_s2));
            this.___warn_inner(sb.ToString());
        }
   
        public void warn(object _s1, object _s2, object _s3)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(commonHTML.GetStringValue(_s1));
            sb.Append(commonHTML.GetStringValue(_s2));
            sb.Append(commonHTML.GetStringValue(_s3));
            this.___warn_inner(sb.ToString());
        }
   
        public void warn(object _s1, object _s2, object _s3, object _s4)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(commonHTML.GetStringValue(_s1));
            sb.Append(commonHTML.GetStringValue(_s2));
            sb.Append(commonHTML.GetStringValue(_s3));
            sb.Append(commonHTML.GetStringValue(_s4));
            this.___warn_inner(sb.ToString());
        }
   
        public void warn(object _s1, object _s2, object _s3, object _s4, object _s5)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(commonHTML.GetStringValue(_s1));
            sb.Append(commonHTML.GetStringValue(_s2));
            sb.Append(commonHTML.GetStringValue(_s3));
            sb.Append(commonHTML.GetStringValue(_s4));
            sb.Append(commonHTML.GetStringValue(_s5));
            this.___warn_inner(sb.ToString());
        }
   
        public void warn(object _s1, object _s2, object _s3, object _s4, object _s5, object _s6)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(commonHTML.GetStringValue(_s1));
            sb.Append(commonHTML.GetStringValue(_s2));
            sb.Append(commonHTML.GetStringValue(_s3));
            sb.Append(commonHTML.GetStringValue(_s4));
            sb.Append(commonHTML.GetStringValue(_s5));
            sb.Append(commonHTML.GetStringValue(_s6));
            this.___warn_inner(sb.ToString());
        }
   
        public void warn(object _s1, object _s2, object _s3, object _s4, object _s5, object _s6, object _s7)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(commonHTML.GetStringValue(_s1));
            sb.Append(commonHTML.GetStringValue(_s2));
            sb.Append(commonHTML.GetStringValue(_s3));
            sb.Append(commonHTML.GetStringValue(_s4));
            sb.Append(commonHTML.GetStringValue(_s5));
            sb.Append(commonHTML.GetStringValue(_s6));
            sb.Append(commonHTML.GetStringValue(_s7));

            this.___warn_inner(sb.ToString());
        }
   
        public void warn(object _s1, object _s2, object _s3, object _s4, object _s5, object _s6, object _s7, object _s8)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(commonHTML.GetStringValue(_s1));
            sb.Append(commonHTML.GetStringValue(_s2));
            sb.Append(commonHTML.GetStringValue(_s3));
            sb.Append(commonHTML.GetStringValue(_s4));
            sb.Append(commonHTML.GetStringValue(_s5));
            sb.Append(commonHTML.GetStringValue(_s6));
            sb.Append(commonHTML.GetStringValue(_s7));
            sb.Append(commonHTML.GetStringValue(_s8));
            this.___warn_inner(sb.ToString());
        }
   
        public void warn(object _s1, object _s2, object _s3, object _s4, object _s5, object _s6, object _s7, object _s8, object _s9)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(commonHTML.GetStringValue(_s1));
            sb.Append(commonHTML.GetStringValue(_s2));
            sb.Append(commonHTML.GetStringValue(_s3));
            sb.Append(commonHTML.GetStringValue(_s4));
            sb.Append(commonHTML.GetStringValue(_s5));
            sb.Append(commonHTML.GetStringValue(_s6));
            sb.Append(commonHTML.GetStringValue(_s7));
            sb.Append(commonHTML.GetStringValue(_s8));
            sb.Append(commonHTML.GetStringValue(_s9));
            this.___warn_inner(sb.ToString());
        }
   
        public void warn(object _s1, object _s2, object _s3, object _s4, object _s5, object _s6, object _s7, object _s8, object _s9, object _s10)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(commonHTML.GetStringValue(_s1));
            sb.Append(commonHTML.GetStringValue(_s2));
            sb.Append(commonHTML.GetStringValue(_s3));
            sb.Append(commonHTML.GetStringValue(_s4));
            sb.Append(commonHTML.GetStringValue(_s5));
            sb.Append(commonHTML.GetStringValue(_s6));
            sb.Append(commonHTML.GetStringValue(_s7));
            sb.Append(commonHTML.GetStringValue(_s8));
            sb.Append(commonHTML.GetStringValue(_s9));
            sb.Append(commonHTML.GetStringValue(_s10));
            this.___warn_inner(sb.ToString());
        }
   
        public void warn(object _s1, object _s2, object _s3, object _s4, object _s5, object _s6, object _s7, object _s8, object _s9, object _s10, object _s11)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(commonHTML.GetStringValue(_s1));
            sb.Append(commonHTML.GetStringValue(_s2));
            sb.Append(commonHTML.GetStringValue(_s3));
            sb.Append(commonHTML.GetStringValue(_s4));
            sb.Append(commonHTML.GetStringValue(_s5));
            sb.Append(commonHTML.GetStringValue(_s6));
            sb.Append(commonHTML.GetStringValue(_s7));
            sb.Append(commonHTML.GetStringValue(_s8));
            sb.Append(commonHTML.GetStringValue(_s9));
            sb.Append(commonHTML.GetStringValue(_s10));
            sb.Append(commonHTML.GetStringValue(_s11));
            this.___warn_inner(sb.ToString());
        }

   
        public void warn(object _s1, object _s2, object _s3, object _s4, object _s5, object _s6, object _s7, object _s8, object _s9, object _s10, object _s11, object _s12)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(commonHTML.GetStringValue(_s1));
            sb.Append(commonHTML.GetStringValue(_s2));
            sb.Append(commonHTML.GetStringValue(_s3));
            sb.Append(commonHTML.GetStringValue(_s4));
            sb.Append(commonHTML.GetStringValue(_s5));
            sb.Append(commonHTML.GetStringValue(_s6));
            sb.Append(commonHTML.GetStringValue(_s7));
            sb.Append(commonHTML.GetStringValue(_s8));
            sb.Append(commonHTML.GetStringValue(_s9));
            sb.Append(commonHTML.GetStringValue(_s10));
            sb.Append(commonHTML.GetStringValue(_s11));
            sb.Append(commonHTML.GetStringValue(_s12));
            this.___warn_inner(sb.ToString());
        }
   
        public void warn(object _s1, object _s2, object _s3, object _s4, object _s5, object _s6, object _s7, object _s8, object _s9, object _s10, object _s11, object _s12, object _s13)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(commonHTML.GetStringValue(_s1));
            sb.Append(commonHTML.GetStringValue(_s2));
            sb.Append(commonHTML.GetStringValue(_s3));
            sb.Append(commonHTML.GetStringValue(_s4));
            sb.Append(commonHTML.GetStringValue(_s5));
            sb.Append(commonHTML.GetStringValue(_s6));
            sb.Append(commonHTML.GetStringValue(_s7));
            sb.Append(commonHTML.GetStringValue(_s8));
            sb.Append(commonHTML.GetStringValue(_s9));
            sb.Append(commonHTML.GetStringValue(_s10));
            sb.Append(commonHTML.GetStringValue(_s11));
            sb.Append(commonHTML.GetStringValue(_s12));
            sb.Append(commonHTML.GetStringValue(_s13));
            this.___warn_inner(sb.ToString());
        }
   
        public void warn(object _s1, object _s2, object _s3, object _s4, object _s5, object _s6, object _s7, object _s8, object _s9, object _s10, object _s11, object _s12, object _s13, object _s14)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(commonHTML.GetStringValue(_s1));
            sb.Append(commonHTML.GetStringValue(_s2));
            sb.Append(commonHTML.GetStringValue(_s3));
            sb.Append(commonHTML.GetStringValue(_s4));
            sb.Append(commonHTML.GetStringValue(_s5));
            sb.Append(commonHTML.GetStringValue(_s6));
            sb.Append(commonHTML.GetStringValue(_s7));
            sb.Append(commonHTML.GetStringValue(_s8));
            sb.Append(commonHTML.GetStringValue(_s9));
            sb.Append(commonHTML.GetStringValue(_s10));
            sb.Append(commonHTML.GetStringValue(_s11));
            sb.Append(commonHTML.GetStringValue(_s12));
            sb.Append(commonHTML.GetStringValue(_s13));
            sb.Append(commonHTML.GetStringValue(_s14));
            this.___warn_inner(sb.ToString());
        }
   
        public void warn(object _s1, object _s2, object _s3, object _s4, object _s5, object _s6, object _s7, object _s8, object _s9, object _s10, object _s11, object _s12, object _s13, object _s14, object _s15)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(commonHTML.GetStringValue(_s1));
            sb.Append(commonHTML.GetStringValue(_s2));
            sb.Append(commonHTML.GetStringValue(_s3));
            sb.Append(commonHTML.GetStringValue(_s4));
            sb.Append(commonHTML.GetStringValue(_s5));
            sb.Append(commonHTML.GetStringValue(_s6));
            sb.Append(commonHTML.GetStringValue(_s7));
            sb.Append(commonHTML.GetStringValue(_s8));
            sb.Append(commonHTML.GetStringValue(_s9));
            sb.Append(commonHTML.GetStringValue(_s10));
            sb.Append(commonHTML.GetStringValue(_s11));
            sb.Append(commonHTML.GetStringValue(_s12));
            sb.Append(commonHTML.GetStringValue(_s13));
            sb.Append(commonHTML.GetStringValue(_s14));
            sb.Append(commonHTML.GetStringValue(_s15));

            this.___warn_inner(sb.ToString());
        }
   
        public void warn(object _s1, object _s2, object _s3, object _s4, object _s5, object _s6, object _s7, object _s8, object _s9, object _s10, object _s11, object _s12, object _s13, object _s14, object _s15, object _s16)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(commonHTML.GetStringValue(_s1));
            sb.Append(commonHTML.GetStringValue(_s2));
            sb.Append(commonHTML.GetStringValue(_s3));
            sb.Append(commonHTML.GetStringValue(_s4));
            sb.Append(commonHTML.GetStringValue(_s5));
            sb.Append(commonHTML.GetStringValue(_s6));
            sb.Append(commonHTML.GetStringValue(_s7));
            sb.Append(commonHTML.GetStringValue(_s8));
            sb.Append(commonHTML.GetStringValue(_s9));
            sb.Append(commonHTML.GetStringValue(_s10));
            sb.Append(commonHTML.GetStringValue(_s11));
            sb.Append(commonHTML.GetStringValue(_s12));
            sb.Append(commonHTML.GetStringValue(_s13));
            sb.Append(commonHTML.GetStringValue(_s14));
            sb.Append(commonHTML.GetStringValue(_s15));
            sb.Append(commonHTML.GetStringValue(_s16));
            this.___warn_inner(sb.ToString());
        }
        #endregion

        #region debug_method
        private void ___debug_inner(string str)
        {
            if (commonLog.LoggingEnabled)
            {
               commonLog.LogEntry(string.Concat("console.debug('", str, "')"));
            }
        }

   
        public void debug()
        {
            this.___debug_inner("");
        }

        

        #endregion


        #region info
        private void ___info_inner(string str)
        {
            if (commonLog.LoggingEnabled)
            {
               commonLog.LogEntry(string.Concat("console.info('", str, "')"));
            }
        }
   
        public void info()
        {
            this.___info_inner("");
        }
   
        public void info(object _s1)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(commonHTML.GetStringValue(_s1));
            this.___log_inner(sb.ToString());

        }

   
        public void info(object _s1, object _s2)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(commonHTML.GetStringValue(_s1));
            sb.Append(commonHTML.GetStringValue(_s2));
            this.___info_inner(sb.ToString());
        }
   
        public void info(object _s1, object _s2, object _s3)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(commonHTML.GetStringValue(_s1));
            sb.Append(commonHTML.GetStringValue(_s2));
            sb.Append(commonHTML.GetStringValue(_s3));
            this.___info_inner(sb.ToString());
        }
   
        public void info(object _s1, object _s2, object _s3, object _s4)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(commonHTML.GetStringValue(_s1));
            sb.Append(commonHTML.GetStringValue(_s2));
            sb.Append(commonHTML.GetStringValue(_s3));
            sb.Append(commonHTML.GetStringValue(_s4));
            this.___info_inner(sb.ToString());
        }
   
        public void info(object _s1, object _s2, object _s3, object _s4, object _s5)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(commonHTML.GetStringValue(_s1));
            sb.Append(commonHTML.GetStringValue(_s2));
            sb.Append(commonHTML.GetStringValue(_s3));
            sb.Append(commonHTML.GetStringValue(_s4));
            sb.Append(commonHTML.GetStringValue(_s5));
            this.___info_inner(sb.ToString());
        }
   
        public void info(object _s1, object _s2, object _s3, object _s4, object _s5, object _s6)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(commonHTML.GetStringValue(_s1));
            sb.Append(commonHTML.GetStringValue(_s2));
            sb.Append(commonHTML.GetStringValue(_s3));
            sb.Append(commonHTML.GetStringValue(_s4));
            sb.Append(commonHTML.GetStringValue(_s5));
            sb.Append(commonHTML.GetStringValue(_s6));
            this.___info_inner(sb.ToString());
        }
   
        public void info(object _s1, object _s2, object _s3, object _s4, object _s5, object _s6, object _s7)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(commonHTML.GetStringValue(_s1));
            sb.Append(commonHTML.GetStringValue(_s2));
            sb.Append(commonHTML.GetStringValue(_s3));
            sb.Append(commonHTML.GetStringValue(_s4));
            sb.Append(commonHTML.GetStringValue(_s5));
            sb.Append(commonHTML.GetStringValue(_s6));
            sb.Append(commonHTML.GetStringValue(_s7));

            this.___info_inner(sb.ToString());
        }
   
        public void info(object _s1, object _s2, object _s3, object _s4, object _s5, object _s6, object _s7, object _s8)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(commonHTML.GetStringValue(_s1));
            sb.Append(commonHTML.GetStringValue(_s2));
            sb.Append(commonHTML.GetStringValue(_s3));
            sb.Append(commonHTML.GetStringValue(_s4));
            sb.Append(commonHTML.GetStringValue(_s5));
            sb.Append(commonHTML.GetStringValue(_s6));
            sb.Append(commonHTML.GetStringValue(_s7));
            sb.Append(commonHTML.GetStringValue(_s8));
            this.___info_inner(sb.ToString());
        }
   
        public void info(object _s1, object _s2, object _s3, object _s4, object _s5, object _s6, object _s7, object _s8, object _s9)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(commonHTML.GetStringValue(_s1));
            sb.Append(commonHTML.GetStringValue(_s2));
            sb.Append(commonHTML.GetStringValue(_s3));
            sb.Append(commonHTML.GetStringValue(_s4));
            sb.Append(commonHTML.GetStringValue(_s5));
            sb.Append(commonHTML.GetStringValue(_s6));
            sb.Append(commonHTML.GetStringValue(_s7));
            sb.Append(commonHTML.GetStringValue(_s8));
            sb.Append(commonHTML.GetStringValue(_s9));
            this.___info_inner(sb.ToString());
        }
   
        public void info(object _s1, object _s2, object _s3, object _s4, object _s5, object _s6, object _s7, object _s8, object _s9, object _s10)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(commonHTML.GetStringValue(_s1));
            sb.Append(commonHTML.GetStringValue(_s2));
            sb.Append(commonHTML.GetStringValue(_s3));
            sb.Append(commonHTML.GetStringValue(_s4));
            sb.Append(commonHTML.GetStringValue(_s5));
            sb.Append(commonHTML.GetStringValue(_s6));
            sb.Append(commonHTML.GetStringValue(_s7));
            sb.Append(commonHTML.GetStringValue(_s8));
            sb.Append(commonHTML.GetStringValue(_s9));
            sb.Append(commonHTML.GetStringValue(_s10));
            this.___info_inner(sb.ToString());
        }
   
        public void info(object _s1, object _s2, object _s3, object _s4, object _s5, object _s6, object _s7, object _s8, object _s9, object _s10, object _s11)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(commonHTML.GetStringValue(_s1));
            sb.Append(commonHTML.GetStringValue(_s2));
            sb.Append(commonHTML.GetStringValue(_s3));
            sb.Append(commonHTML.GetStringValue(_s4));
            sb.Append(commonHTML.GetStringValue(_s5));
            sb.Append(commonHTML.GetStringValue(_s6));
            sb.Append(commonHTML.GetStringValue(_s7));
            sb.Append(commonHTML.GetStringValue(_s8));
            sb.Append(commonHTML.GetStringValue(_s9));
            sb.Append(commonHTML.GetStringValue(_s10));
            sb.Append(commonHTML.GetStringValue(_s11));
            this.___info_inner(sb.ToString());
        }

   
        public void info(object _s1, object _s2, object _s3, object _s4, object _s5, object _s6, object _s7, object _s8, object _s9, object _s10, object _s11, object _s12)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(commonHTML.GetStringValue(_s1));
            sb.Append(commonHTML.GetStringValue(_s2));
            sb.Append(commonHTML.GetStringValue(_s3));
            sb.Append(commonHTML.GetStringValue(_s4));
            sb.Append(commonHTML.GetStringValue(_s5));
            sb.Append(commonHTML.GetStringValue(_s6));
            sb.Append(commonHTML.GetStringValue(_s7));
            sb.Append(commonHTML.GetStringValue(_s8));
            sb.Append(commonHTML.GetStringValue(_s9));
            sb.Append(commonHTML.GetStringValue(_s10));
            sb.Append(commonHTML.GetStringValue(_s11));
            sb.Append(commonHTML.GetStringValue(_s12));
            this.___info_inner(sb.ToString());
        }
   
        public void info(object _s1, object _s2, object _s3, object _s4, object _s5, object _s6, object _s7, object _s8, object _s9, object _s10, object _s11, object _s12, object _s13)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(commonHTML.GetStringValue(_s1));
            sb.Append(commonHTML.GetStringValue(_s2));
            sb.Append(commonHTML.GetStringValue(_s3));
            sb.Append(commonHTML.GetStringValue(_s4));
            sb.Append(commonHTML.GetStringValue(_s5));
            sb.Append(commonHTML.GetStringValue(_s6));
            sb.Append(commonHTML.GetStringValue(_s7));
            sb.Append(commonHTML.GetStringValue(_s8));
            sb.Append(commonHTML.GetStringValue(_s9));
            sb.Append(commonHTML.GetStringValue(_s10));
            sb.Append(commonHTML.GetStringValue(_s11));
            sb.Append(commonHTML.GetStringValue(_s12));
            sb.Append(commonHTML.GetStringValue(_s13));
            this.___info_inner(sb.ToString());
        }
   
        public void info(object _s1, object _s2, object _s3, object _s4, object _s5, object _s6, object _s7, object _s8, object _s9, object _s10, object _s11, object _s12, object _s13, object _s14)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(commonHTML.GetStringValue(_s1));
            sb.Append(commonHTML.GetStringValue(_s2));
            sb.Append(commonHTML.GetStringValue(_s3));
            sb.Append(commonHTML.GetStringValue(_s4));
            sb.Append(commonHTML.GetStringValue(_s5));
            sb.Append(commonHTML.GetStringValue(_s6));
            sb.Append(commonHTML.GetStringValue(_s7));
            sb.Append(commonHTML.GetStringValue(_s8));
            sb.Append(commonHTML.GetStringValue(_s9));
            sb.Append(commonHTML.GetStringValue(_s10));
            sb.Append(commonHTML.GetStringValue(_s11));
            sb.Append(commonHTML.GetStringValue(_s12));
            sb.Append(commonHTML.GetStringValue(_s13));
            sb.Append(commonHTML.GetStringValue(_s14));
            this.___info_inner(sb.ToString());
        }
   
        public void info(object _s1, object _s2, object _s3, object _s4, object _s5, object _s6, object _s7, object _s8, object _s9, object _s10, object _s11, object _s12, object _s13, object _s14, object _s15)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(commonHTML.GetStringValue(_s1));
            sb.Append(commonHTML.GetStringValue(_s2));
            sb.Append(commonHTML.GetStringValue(_s3));
            sb.Append(commonHTML.GetStringValue(_s4));
            sb.Append(commonHTML.GetStringValue(_s5));
            sb.Append(commonHTML.GetStringValue(_s6));
            sb.Append(commonHTML.GetStringValue(_s7));
            sb.Append(commonHTML.GetStringValue(_s8));
            sb.Append(commonHTML.GetStringValue(_s9));
            sb.Append(commonHTML.GetStringValue(_s10));
            sb.Append(commonHTML.GetStringValue(_s11));
            sb.Append(commonHTML.GetStringValue(_s12));
            sb.Append(commonHTML.GetStringValue(_s13));
            sb.Append(commonHTML.GetStringValue(_s14));
            sb.Append(commonHTML.GetStringValue(_s15));

            this.___info_inner(sb.ToString());
        }
   
        public void info(object _s1, object _s2, object _s3, object _s4, object _s5, object _s6, object _s7, object _s8, object _s9, object _s10, object _s11, object _s12, object _s13, object _s14, object _s15, object _s16)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(commonHTML.GetStringValue(_s1));
            sb.Append(commonHTML.GetStringValue(_s2));
            sb.Append(commonHTML.GetStringValue(_s3));
            sb.Append(commonHTML.GetStringValue(_s4));
            sb.Append(commonHTML.GetStringValue(_s5));
            sb.Append(commonHTML.GetStringValue(_s6));
            sb.Append(commonHTML.GetStringValue(_s7));
            sb.Append(commonHTML.GetStringValue(_s8));
            sb.Append(commonHTML.GetStringValue(_s9));
            sb.Append(commonHTML.GetStringValue(_s10));
            sb.Append(commonHTML.GetStringValue(_s11));
            sb.Append(commonHTML.GetStringValue(_s12));
            sb.Append(commonHTML.GetStringValue(_s13));
            sb.Append(commonHTML.GetStringValue(_s14));
            sb.Append(commonHTML.GetStringValue(_s15));
            sb.Append(commonHTML.GetStringValue(_s16));
            this.___info_inner(sb.ToString());
        }
        #endregion


        #region error
        private void ___error_inner(string str)
        {
            if (commonLog.LoggingEnabled)
            {
               commonLog.LogEntry(string.Concat("console.error('", str, "')"));
            }
        }
   
        public void error()
        {
            this.___error_inner("");
        }
   
        public void error(object _s1)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(commonHTML.GetStringValue(_s1));
            this.___error_inner(sb.ToString());

        }

   
        public void error(object _s1, object _s2)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(commonHTML.GetStringValue(_s1));
            sb.Append(commonHTML.GetStringValue(_s2));
            this.___error_inner(sb.ToString());
        }
   
        public void error(object _s1, object _s2, object _s3)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(commonHTML.GetStringValue(_s1));
            sb.Append(commonHTML.GetStringValue(_s2));
            sb.Append(commonHTML.GetStringValue(_s3));
            this.___error_inner(sb.ToString());
        }
   
        public void error(object _s1, object _s2, object _s3, object _s4)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(commonHTML.GetStringValue(_s1));
            sb.Append(commonHTML.GetStringValue(_s2));
            sb.Append(commonHTML.GetStringValue(_s3));
            sb.Append(commonHTML.GetStringValue(_s4));
            this.___error_inner(sb.ToString());
        }
   
        public void error(object _s1, object _s2, object _s3, object _s4, object _s5)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(commonHTML.GetStringValue(_s1));
            sb.Append(commonHTML.GetStringValue(_s2));
            sb.Append(commonHTML.GetStringValue(_s3));
            sb.Append(commonHTML.GetStringValue(_s4));
            sb.Append(commonHTML.GetStringValue(_s5));
            this.___error_inner(sb.ToString());
        }
   
        public void error(object _s1, object _s2, object _s3, object _s4, object _s5, object _s6)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(commonHTML.GetStringValue(_s1));
            sb.Append(commonHTML.GetStringValue(_s2));
            sb.Append(commonHTML.GetStringValue(_s3));
            sb.Append(commonHTML.GetStringValue(_s4));
            sb.Append(commonHTML.GetStringValue(_s5));
            sb.Append(commonHTML.GetStringValue(_s6));
            this.___error_inner(sb.ToString());
        }
   
        public void error(object _s1, object _s2, object _s3, object _s4, object _s5, object _s6, object _s7)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(commonHTML.GetStringValue(_s1));
            sb.Append(commonHTML.GetStringValue(_s2));
            sb.Append(commonHTML.GetStringValue(_s3));
            sb.Append(commonHTML.GetStringValue(_s4));
            sb.Append(commonHTML.GetStringValue(_s5));
            sb.Append(commonHTML.GetStringValue(_s6));
            sb.Append(commonHTML.GetStringValue(_s7));

            this.___error_inner(sb.ToString());
        }
   
        public void error(object _s1, object _s2, object _s3, object _s4, object _s5, object _s6, object _s7, object _s8)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(commonHTML.GetStringValue(_s1));
            sb.Append(commonHTML.GetStringValue(_s2));
            sb.Append(commonHTML.GetStringValue(_s3));
            sb.Append(commonHTML.GetStringValue(_s4));
            sb.Append(commonHTML.GetStringValue(_s5));
            sb.Append(commonHTML.GetStringValue(_s6));
            sb.Append(commonHTML.GetStringValue(_s7));
            sb.Append(commonHTML.GetStringValue(_s8));
            this.___error_inner(sb.ToString());
        }
   
        public void error(object _s1, object _s2, object _s3, object _s4, object _s5, object _s6, object _s7, object _s8, object _s9)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(commonHTML.GetStringValue(_s1));
            sb.Append(commonHTML.GetStringValue(_s2));
            sb.Append(commonHTML.GetStringValue(_s3));
            sb.Append(commonHTML.GetStringValue(_s4));
            sb.Append(commonHTML.GetStringValue(_s5));
            sb.Append(commonHTML.GetStringValue(_s6));
            sb.Append(commonHTML.GetStringValue(_s7));
            sb.Append(commonHTML.GetStringValue(_s8));
            sb.Append(commonHTML.GetStringValue(_s9));
            this.___error_inner(sb.ToString());
        }
   
        public void error(object _s1, object _s2, object _s3, object _s4, object _s5, object _s6, object _s7, object _s8, object _s9, object _s10)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(commonHTML.GetStringValue(_s1));
            sb.Append(commonHTML.GetStringValue(_s2));
            sb.Append(commonHTML.GetStringValue(_s3));
            sb.Append(commonHTML.GetStringValue(_s4));
            sb.Append(commonHTML.GetStringValue(_s5));
            sb.Append(commonHTML.GetStringValue(_s6));
            sb.Append(commonHTML.GetStringValue(_s7));
            sb.Append(commonHTML.GetStringValue(_s8));
            sb.Append(commonHTML.GetStringValue(_s9));
            sb.Append(commonHTML.GetStringValue(_s10));
            this.___error_inner(sb.ToString());
        }
   
        public void error(object _s1, object _s2, object _s3, object _s4, object _s5, object _s6, object _s7, object _s8, object _s9, object _s10, object _s11)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(commonHTML.GetStringValue(_s1));
            sb.Append(commonHTML.GetStringValue(_s2));
            sb.Append(commonHTML.GetStringValue(_s3));
            sb.Append(commonHTML.GetStringValue(_s4));
            sb.Append(commonHTML.GetStringValue(_s5));
            sb.Append(commonHTML.GetStringValue(_s6));
            sb.Append(commonHTML.GetStringValue(_s7));
            sb.Append(commonHTML.GetStringValue(_s8));
            sb.Append(commonHTML.GetStringValue(_s9));
            sb.Append(commonHTML.GetStringValue(_s10));
            sb.Append(commonHTML.GetStringValue(_s11));
            this.___error_inner(sb.ToString());
        }

   
        public void error(object _s1, object _s2, object _s3, object _s4, object _s5, object _s6, object _s7, object _s8, object _s9, object _s10, object _s11, object _s12)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(commonHTML.GetStringValue(_s1));
            sb.Append(commonHTML.GetStringValue(_s2));
            sb.Append(commonHTML.GetStringValue(_s3));
            sb.Append(commonHTML.GetStringValue(_s4));
            sb.Append(commonHTML.GetStringValue(_s5));
            sb.Append(commonHTML.GetStringValue(_s6));
            sb.Append(commonHTML.GetStringValue(_s7));
            sb.Append(commonHTML.GetStringValue(_s8));
            sb.Append(commonHTML.GetStringValue(_s9));
            sb.Append(commonHTML.GetStringValue(_s10));
            sb.Append(commonHTML.GetStringValue(_s11));
            sb.Append(commonHTML.GetStringValue(_s12));
            this.___error_inner(sb.ToString());
        }
   
        public void error(object _s1, object _s2, object _s3, object _s4, object _s5, object _s6, object _s7, object _s8, object _s9, object _s10, object _s11, object _s12, object _s13)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(commonHTML.GetStringValue(_s1));
            sb.Append(commonHTML.GetStringValue(_s2));
            sb.Append(commonHTML.GetStringValue(_s3));
            sb.Append(commonHTML.GetStringValue(_s4));
            sb.Append(commonHTML.GetStringValue(_s5));
            sb.Append(commonHTML.GetStringValue(_s6));
            sb.Append(commonHTML.GetStringValue(_s7));
            sb.Append(commonHTML.GetStringValue(_s8));
            sb.Append(commonHTML.GetStringValue(_s9));
            sb.Append(commonHTML.GetStringValue(_s10));
            sb.Append(commonHTML.GetStringValue(_s11));
            sb.Append(commonHTML.GetStringValue(_s12));
            sb.Append(commonHTML.GetStringValue(_s13));
            this.___error_inner(sb.ToString());
        }
   
        public void error(object _s1, object _s2, object _s3, object _s4, object _s5, object _s6, object _s7, object _s8, object _s9, object _s10, object _s11, object _s12, object _s13, object _s14)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(commonHTML.GetStringValue(_s1));
            sb.Append(commonHTML.GetStringValue(_s2));
            sb.Append(commonHTML.GetStringValue(_s3));
            sb.Append(commonHTML.GetStringValue(_s4));
            sb.Append(commonHTML.GetStringValue(_s5));
            sb.Append(commonHTML.GetStringValue(_s6));
            sb.Append(commonHTML.GetStringValue(_s7));
            sb.Append(commonHTML.GetStringValue(_s8));
            sb.Append(commonHTML.GetStringValue(_s9));
            sb.Append(commonHTML.GetStringValue(_s10));
            sb.Append(commonHTML.GetStringValue(_s11));
            sb.Append(commonHTML.GetStringValue(_s12));
            sb.Append(commonHTML.GetStringValue(_s13));
            sb.Append(commonHTML.GetStringValue(_s14));
            this.___error_inner(sb.ToString());
        }
   
        public void error(object _s1, object _s2, object _s3, object _s4, object _s5, object _s6, object _s7, object _s8, object _s9, object _s10, object _s11, object _s12, object _s13, object _s14, object _s15)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(commonHTML.GetStringValue(_s1));
            sb.Append(commonHTML.GetStringValue(_s2));
            sb.Append(commonHTML.GetStringValue(_s3));
            sb.Append(commonHTML.GetStringValue(_s4));
            sb.Append(commonHTML.GetStringValue(_s5));
            sb.Append(commonHTML.GetStringValue(_s6));
            sb.Append(commonHTML.GetStringValue(_s7));
            sb.Append(commonHTML.GetStringValue(_s8));
            sb.Append(commonHTML.GetStringValue(_s9));
            sb.Append(commonHTML.GetStringValue(_s10));
            sb.Append(commonHTML.GetStringValue(_s11));
            sb.Append(commonHTML.GetStringValue(_s12));
            sb.Append(commonHTML.GetStringValue(_s13));
            sb.Append(commonHTML.GetStringValue(_s14));
            sb.Append(commonHTML.GetStringValue(_s15));

            this.___error_inner(sb.ToString());
        }
   
        public void error(object _s1, object _s2, object _s3, object _s4, object _s5, object _s6, object _s7, object _s8, object _s9, object _s10, object _s11, object _s12, object _s13, object _s14, object _s15, object _s16)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(commonHTML.GetStringValue(_s1));
            sb.Append(commonHTML.GetStringValue(_s2));
            sb.Append(commonHTML.GetStringValue(_s3));
            sb.Append(commonHTML.GetStringValue(_s4));
            sb.Append(commonHTML.GetStringValue(_s5));
            sb.Append(commonHTML.GetStringValue(_s6));
            sb.Append(commonHTML.GetStringValue(_s7));
            sb.Append(commonHTML.GetStringValue(_s8));
            sb.Append(commonHTML.GetStringValue(_s9));
            sb.Append(commonHTML.GetStringValue(_s10));
            sb.Append(commonHTML.GetStringValue(_s11));
            sb.Append(commonHTML.GetStringValue(_s12));
            sb.Append(commonHTML.GetStringValue(_s13));
            sb.Append(commonHTML.GetStringValue(_s14));
            sb.Append(commonHTML.GetStringValue(_s15));
            sb.Append(commonHTML.GetStringValue(_s16));
            this.___error_inner(sb.ToString());
        }
        #endregion
        /// <summary>
        /// Displays an interactive list of the properties of the specified JavaScript object. The output is presented as a hierarchical listing with disclosure triangles that let you see the contents of child objects.
        /// </summary>
        /// <param name="_obj"></param>
   
		public void dir(object _obj)
		{

		}
		
		public void group()
		{
		}
		
		public void groupEnd()
		{
		}
   
        public double count()
        {
            return 0;
        
        }
    
        public void assert(object __arg1, object ___arg2, object __arg3)
        {
        }
    
        public void assert(object __arg1, object ___arg2)
        {
        }
   
        public void assert(object __arg1)
        {
        }
   
        public void assert()
        {

        }
   
        public void dirxml(object ___node)
        {
        }

   
        public void clear()
        {
            return;
        }
   
        public void profile()
        {
        }
   
        public void profileEnd()
        {

        }
        public void groupCollapsed()
        {
        }
        public void groupCollapsed(object __groupId)
        {
        }
    
        public void group(object ___groupObject)
        {
        }
    
        public void  group(object ___groupObject, object ___target)
        {
        }
   
        public void trace()
        {

        }
		/// <summary>
		/// Starts a timer you can use to track how long an operation takes. You give each timer a unique name, and may have up to 10,000 timers running on a given page. When you call console.timeEnd() with the same name, the browser will output the time, in milliseconds, that elapsed since the timer was started.
		/// </summary>
		/// <param name="timerName"></param>
		
		public void time(object timerName)
		{

		}
		/// <summary>
		/// Starts a timer you can use to track how long an operation takes. You give each timer a unique name, and may have up to 10,000 timers running on a given page. When you call console.timeEnd() with the same name, the browser will output the time, in milliseconds, that elapsed since the timer was started.
		/// </summary>
		/// <param name="timerName"></param>
		
		public void timeEnd(object timerName)
		{

		}
   
		public void markTimeline(object ____obj)
		{
		}
    
        public void timeStamp(object __time)
        {
        }
   
        public void timeStamp()
        {

        }

		#region IPropertyBox

        public object ___getPropertyByName(string __name)
		{
			string ___nameLow = commonHTML.FasterTrimAndToLower(__name);
			if(commonLog.LoggingEnabled &&commonLog.CommonLogLevel >= 10)
			{
				commonLog.LogEntry("{0} get {1}", this, __name);
			}
			switch(___nameLow)
			{
                case "__iterator__":
                    //return commonHTML.rhinoForLoopEnumratorFunction;
                    return null;
				
				default:
				
						if(this.___properties.ContainsKey(__name))
						{
							return this.___properties[__name];
						}
					
					break;
			}
			if(commonLog.LoggingEnabled &&commonLog.CommonLogLevel >= 10)
			{
				commonLog.LogEntry("GetPropertyValue for {0} {1} {2} failed",this.GetType(), this, __name);
			}
			return null;
		}

		public void ___setPropertyByName(string ___name, object val)
		{

			if(commonLog.LoggingEnabled &&commonLog.CommonLogLevel >= 10)
			{
				commonLog.LogEntry("{0} put {1}", this, ___name);
			}
            bool ___ValueStored = false;
            switch (___name)
            {

                default:


                    try
                    {
                        this.___properties[___name] = val;
                        ___ValueStored = true;
                    }
                    catch { }



                    if (commonLog.LoggingEnabled &&commonLog.CommonLogLevel >= 10)
                    {
                       commonLog.LogEntry("SetPropertyValue for {0} {1}  \"{2}\" = {3} Success : {4}", this.GetType(), this, ___name, val, ___ValueStored);
                    }
                    break;
            }
		}
		public void ___setPropertyByIndex(int ___index, object val)
		{
			if(commonLog.LoggingEnabled &&commonLog.CommonLogLevel >= 10)
			{
				commonLog.LogEntry("SetPropertyValueIndex for {0} {1} \"{2}\" = {3} failed",this.GetType(), this, ___index, val);
			}
			
		}
		public object ___getPropertyByIndex(int ___index)
		{
			if(commonLog.LoggingEnabled &&commonLog.CommonLogLevel >= 10)
			{
				commonLog.LogEntry("___getPropertyByName by index {0} {1} {2} failed",this.GetType(), this, ___index);
			}
			return null;
		}

		public bool ___hasPropertyByName(string __name)
		{
            return true;

		}
		public bool ___hasPropertyByIndex(int ___index)
		{
			if(commonLog.LoggingEnabled &&commonLog.CommonLogLevel >= 10)
			{
				commonLog.LogEntry("{0} HasPropertyIndex {1}", this, ___index);
			}
			return true;
		}
		public object ___common_object_clone()
		{
			if(commonLog.LoggingEnabled &&commonLog.CommonLogLevel >= 10)
			{
				commonLog.LogEntry("x__Clone {0} {1} called",this.GetType(), this);
			}
			return this;
		}
		public void ___deleteByIndex(int ___index)
		{
			if(commonLog.LoggingEnabled &&commonLog.CommonLogLevel >= 10)
			{
				commonLog.LogEntry("___deleteByIndex {0} {1} called : {2}",this.GetType(), this, ___index);
			}
		}
		public void ___deleteByName(string ___name)
		{
			if(commonLog.LoggingEnabled &&commonLog.CommonLogLevel >= 10)
			{
				commonLog.LogEntry("___deleteByName {0} {1} called : {2}",this.GetType(), this, ___name);
			}

		}
		public object[] ___getByIds()
		{
			if(commonLog.LoggingEnabled &&commonLog.CommonLogLevel >= 10)
			{
				commonLog.LogEntry("___getByIds() {0} {1} called",this.GetType(), this);
			}
			return null;

		}
		public string ___getClassName()
		{
			if(commonLog.LoggingEnabled &&commonLog.CommonLogLevel >= 10)
			{
				commonLog.LogEntry("___getClassName {0} {1} called",this.GetType(), this);
			}
			return this.GetType().Name;
		}
		public object ___getDefaultValue()
		{
			if(commonLog.LoggingEnabled &&commonLog.CommonLogLevel >= 10)
			{
				commonLog.LogEntry("___getDefaultValue {0} {1} called",this.GetType(), this);
			}
			return null;
		}
		public object ___getParentScope()
		{
			if(commonLog.LoggingEnabled &&commonLog.CommonLogLevel >= 10)
			{
				commonLog.LogEntry("___getParentScope {0} {1} called",this.GetType(), this);
			}
			return null;
		}
		public void ___setParentScope(object ___object)
		{
			if(commonLog.LoggingEnabled &&commonLog.CommonLogLevel >= 10)
			{
				commonLog.LogEntry("___setParentScope {0} {1} called : {2}",this.GetType(), this, ___object);
			}
		}
		public object ___getProtoType()
		{
			if(commonLog.LoggingEnabled &&commonLog.CommonLogLevel >= 10)
			{
				commonLog.LogEntry("___getProtoType {0} {1} called",this.GetType(), this);
			}
			return null;
		}
		public bool ___hasInstance(object ___object)
		{
			if(commonLog.LoggingEnabled &&commonLog.CommonLogLevel >= 10)
			{
				commonLog.LogEntry("___hasInstance {0} {1} called : {2}",this.GetType(), this, ___object);
			}
			return false;
		}
		public bool ___instanceEquals(object ___object)
		{
			if(commonLog.LoggingEnabled &&commonLog.CommonLogLevel >= 10)
			{
				commonLog.LogEntry("___instanceEquals {0} {1} called : {2}",this.GetType(), this, ___object);
			}
			return object.ReferenceEquals(this, ___object);
		}
		public void ___setProtoType(object ___object)
		{
			if(commonLog.LoggingEnabled &&commonLog.CommonLogLevel >= 10)
			{
				commonLog.LogEntry("___setProtoType {0} {1} called : {2}",this.GetType(), this, ___object);
			}
		}
        public override string ToString()
        {
            return "[object " + this.___multiversalClassType.ToString() + "]";
        }
        public IMutilversalObjectType multiversalObjectType
        {
            get { return this.___multiversalClassType; }
        }

		#endregion
	}
}
