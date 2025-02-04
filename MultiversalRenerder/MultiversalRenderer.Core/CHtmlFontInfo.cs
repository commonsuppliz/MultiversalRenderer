using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using MultiversalRenderer.Interfaces;

namespace MultiversalRenderer.Core
{
    public class CHtmlFontInfo
    {
        public float FontSize;
        public string FontName;
        public int FontStyle;
        internal bool ___isBold;
        internal bool ___isItalic;
        internal bool ___isStrikeout;
        internal bool ___isUnderline;

        public Color ForegroundColor = Color.Black;

        public Color BackgroundColor = Color.Transparent;

        public string SizeString;
        /// <summary>
        /// This field is used for FontCache.
        /// </summary>

        public string ___FontNameSizeStyleString;


        public bool Bold
        {
            get { return this.___isBold; }
        }

        public bool Italic
        {
            get { return this.___isItalic; }
        }

        public bool Strikeout
        {
            get { return this.___isStrikeout; }
        }

        public bool Underline
        {
            get { return this.___isUnderline; }
        }
        public CHtmlFontInfo()
        {
            FontSize = 10;
            FontName = "Microsoft Sans Serif";
            SizeString = "";
            this.ForegroundColor = Color.Black;
            this.BackgroundColor = Color.Transparent;
            this.___FontNameSizeStyleString = "";
        }



        public CHtmlFontInfo(string _FontName, float _Size)
        {
            this.FontName = _FontName;
            this.FontSize = _Size;
        }
        public CHtmlFontInfo Clone()
        {
            var newInfo = new CHtmlFontInfo();
            newInfo.FontName = this.FontName;
            newInfo.FontSize = this.FontSize;
            newInfo.FontStyle = this.FontStyle;
            newInfo.BackgroundColor = this.BackgroundColor;
            newInfo.ForegroundColor = this.ForegroundColor;
            return newInfo;

        }
        public System.Drawing.Font ToFont()
        {
            System.Drawing.Font gdiFont = new Font(this.FontName, this.FontSize);
            return gdiFont;
        }
        public System.Drawing.Font ToHtmlRendererFont()
        {
            System.Drawing.Font gdiFont = new Font(this.FontName, this.FontSize);
            return gdiFont;
        }

    }


}
