using System;
using System.Drawing;

namespace MultiversalRenderer.Core
{
	
	/// <summary>
	/// CHtmlDrawingElement is drawingElement
	/// </summary>
	public sealed class CHtmlDrawingElement : CHtmlBase
	{
	
		public CHtmlElement ___parent = null;
		public string DrawingText = null;
		private string ___TextToString = null;
        public int ___DocumentElementIndex;

        public double maximumHeightForDrawLine = 0;
		/// <summary>
		/// Since DrawingElements are used internal only, make this as field not property
		/// </summary>
		public System.Drawing.RectangleF offsetBounds = System.Drawing.RectangleF.Empty;
		public System.Drawing.PointF ___offfsetParentPoint = commonHTML.MinusPoint;
		private RectangleF _BaseControlDisplayRectangle = RectangleF.Empty;
        internal RectangleF ___ScreenRectangle = RectangleF.Empty;
		public CHtmlDrawingElement()
		{

		}



		public RectangleF offsetParentBounds
		{
			get{return new RectangleF(this.___offfsetParentPoint, this.offsetBounds.Size);}
		}
		public RectangleF GetElementBoundsOnScreen()
		{

            return this.___ScreenRectangle;

		}
		private void CalucuateElementsBoundsOnScreeen()
		{
            this.___ScreenRectangle = new RectangleF(this.___offfsetParentPoint.X - this.BaseControlDisplayRectangle.Left,
				this.___offfsetParentPoint.Y   - this.BaseControlDisplayRectangle.Top,
				this.offsetBounds.Width,
				this.offsetBounds.Height);
		}
		public RectangleF BaseControlDisplayRectangle
		{
			get{return this._BaseControlDisplayRectangle;}
			set
			{
				if(this._BaseControlDisplayRectangle.Equals(value))
				{
					return;
				}
				else
				{
					this._BaseControlDisplayRectangle = value;
					CalucuateElementsBoundsOnScreeen();
				}
			}
		}
		public override string ToString()
		{
			if(___TextToString.Length == 0)
			{
				
				if(this.DrawingText.Length <= 20)
				{
					___TextToString = "<#DRAW value='" + this.DrawingText + "' bounds='" + this.offsetBounds.ToString() + "' />";
				}
				else
				{
					___TextToString = "<#DRAW value='" + this.DrawingText.Substring(0, 20) + "...' bounds='" + this.offsetBounds.ToString() + "' />";

				}
				return this.___TextToString;
			}
			else
			{
				return this.___TextToString;
			}
			
		}

		
        /// <summary>
        /// ---------------------------------------------------------
        /// do not change this type other than float offsetWidth, offsetHeight, offsetLeft, offsetRight should e use offsetBounds.
        /// ---------------------------------------------------------
        /// </summary>



    }
}
