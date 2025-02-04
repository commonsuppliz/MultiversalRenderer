using System;
using System.Drawing;

namespace MultiversalRenderer.Core
{
	
	/// <summary>
	/// CHtmlDrawingObject is drawingElement
	/// </summary>
	public class CHtmlDrawingObject 
	{
        public CHtmlDrawingObjectType DrawElementType;
        /// <summary>
        /// Weak Refence to ownerObject
        /// </summary>
		public System.WeakReference ___parentWeakReference;
		public string DrawingText;
		private string ___TextToString;
        public int ___DocumentElementIndex;
		public double maximumHeightForDrawLine;
		/// <summary>
		/// Since DrawingElements are used internal only, make this as field not property
		/// </summary>
		public System.Drawing.RectangleF offsetBounds;

        public System.Drawing.PointF ___offfsetParentPoint;

        //public System.Drawing.PointF ___offfsetParentPoint;
		private RectangleF _BaseControlDisplayRectangle;
        internal RectangleF ___ScreenRectangle;
        public CHtmlDrawingObject()
        {
            ___offfsetParentPoint = commonHTML.MinusPoint;
            offsetBounds = System.Drawing.RectangleF.Empty;
            _BaseControlDisplayRectangle = System.Drawing.RectangleF.Empty;
            ___ScreenRectangle = System.Drawing.RectangleF.Empty;
            maximumHeightForDrawLine = 0;
            ___DocumentElementIndex = -1;
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
			if(string.IsNullOrEmpty(___TextToString) == true )
			{
                if (string.IsNullOrEmpty(DrawingText) == true)
                    return "<#DRAW value=''>";
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
