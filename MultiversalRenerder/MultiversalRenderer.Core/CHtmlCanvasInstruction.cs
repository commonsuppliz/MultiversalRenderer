using System;
using System.Collections.Generic;
using System.Text;

namespace MultiversalRenderer.Core
{
    
    public enum CanvasInstructionType : byte
    {
        None,
        Save,
        Scale,
        Translate,
        Rotate,
        Transform,
        SetTransform,
        Clip,
        ResetTransform
    }
    public sealed class CHtmlCanvasContextInstruction 
    {
        public CanvasInstructionType InstructionType;
        public float floatValue;
        public System.Drawing.PointF point;
        public System.Drawing.RectangleF rectangle;
        public CHtmlCanvasInstructionMatrix matrix;
    }
}
