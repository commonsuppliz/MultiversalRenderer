using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace MultiversalRenderer.Core
{
    /// <summary>
    /// GraphicContainer 
    /// </summary>
    public class GraphicCotainer
    {
        public Graphics Graphic = null;
        public Font Font = null;
        public Color BackgroundColor;
        public Color ForegroundColor;
        public RectangleF PaintRectangle;
        public RectangleF DisplayRectangle;
        public RectangleF ClientRectangle;
        public RectangleF ScreenRectangle;
        public RectangleF ControlBounds;
        public Image ImageNA = null;
        public int CurrentPos = -1;
        public int StartingPos = -1;
        public int EndingPos = -1;
        public float TotalOffsetLeft = 0;
        public float TotalOffsetTop = 0;
        public bool IsUIThreadPaint = false;
        public System.Drawing.StringFormat StandardStringFormat = null;
        public bool IsDrawLayoutPanel = false;
        public RectangleF ScreenMaximunBounds = RectangleF.Empty;
        public int CurrentElementDepth = 0;
        public bool IsHoverPaintMode = false;


        public GraphicCotainer()
        {
            this.Graphic = null;
            this.Font = null;
            this.BackgroundColor = Color.Empty;
            this.ForegroundColor = Color.Empty;
            this.DisplayRectangle = RectangleF.Empty;
            this.ClientRectangle = RectangleF.Empty;
            this.ScreenRectangle = RectangleF.Empty;
            this.PaintRectangle = RectangleF.Empty;
            this.ControlBounds = RectangleF.Empty;
        }
        #region IDisposable メンバ

        public void Dispose(bool DisposeGrahicObject)
        {
            if (this.StandardStringFormat != null)
            {
                this.StandardStringFormat.Dispose();
                this.StandardStringFormat = null;
            }
            if (this.Font != null)
            {
                this.Font.Dispose();
                this.Font = null;
            }
            if (DisposeGrahicObject)
            {
                if (this.Graphic != null)
                {
                    this.Graphic.Dispose();
                    this.Graphic = null;
                }
            }
            this.ImageNA = null;
        }

        #endregion
    }
}
