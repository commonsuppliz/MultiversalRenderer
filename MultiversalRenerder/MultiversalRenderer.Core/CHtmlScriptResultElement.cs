using System;
using System.Collections;
using System.Text;
namespace MultiversalRenderer.Core
{
	/// <summary>
	/// CHtmlScriptResultElement is similar to IHtmlScriptElement
	/// Contains following Text
	/// [SCRIPT LANGUAGE="JScript"]
	///  **-- <= START
    ///
	///  **--> <=END
	///	[/SCRIPT]
	/// </summary>
	public sealed class CHtmlScriptResultElement
	{
        public int ___DocumentElementIndex = -1;
        public string text = null;
		public bool IsCompiled = false;
		public int result = -1;
		public bool IsAsyncScript = false;
        public bool IsDeferScript = false;
		public string resultText = null;
        public string errorDetail = null;
		public string charset = null;
		public string language = null;
        public string href = null;
        public System.WeakReference ElementReference = null;
        public System.WeakReference sourceWeakReference = null;

		public CHtmlScriptResultElement()
		{

		}


		#region ICloneable ÉÅÉìÉo

        public CHtmlScriptResultElement cloneScriptResult()
		{
			CHtmlScriptResultElement newScript = new CHtmlScriptResultElement();
			newScript.href  = this.href;
			newScript.result = this.result;
			newScript.resultText = this.resultText;
            if (string.IsNullOrEmpty(this.errorDetail) == false)
            {
                newScript.errorDetail = string.Copy(this.errorDetail);
            }
			newScript.IsCompiled = this.IsCompiled;
            newScript.ElementReference = this.ElementReference;
            newScript.___DocumentElementIndex = this.___DocumentElementIndex;
			return newScript;
		}

		#endregion
	}
}
