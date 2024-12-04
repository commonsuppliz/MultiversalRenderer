using System;
using System.Runtime.InteropServices;
using MultiversalRenderer.Interfaces;
namespace MultiversalRenderer.Core
{
	/// <summary>
	/// CHtmlTextElement 
	/// </summary>
	[ComVisible(true)]
	
	public class CHtmlTextElement : CHtmlElement
	{
		/// <summary>
		/// Sum of Drawing Area Rectanle Bounds
		/// </summary>
		public System.Drawing.RectangleF DrawingElementsTotalBounds = System.Drawing.RectangleF.Empty;
		


		public CHtmlTextElement()
		{
            this.___multiversalClassType = IMutilversalObjectType.Text;
			// 
			// 
			//
			this.___SetTagNameOnly("#TEXT");
			this.___elementTagType = CHtmlElementType._ITEXT;
			this.___SetNodeType(CHtmlNodeType.TEXT_NODE);
            this.___IsSystemHidden = true;
		}
        public IMutilversalObjectType multiversalObjectType
        {
            get { return base.___multiversalClassType; }
        }
        public override string ToString()
        {
            return "[object " + base.___multiversalClassType.ToString() + "]";
        }


	}
}
