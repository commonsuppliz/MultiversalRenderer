using System;
using System.Collections.Generic;


namespace MultiversalRenderer.Interfaces
{
    public delegate object createControlOnMultiversalWindowRendererDelegate(Type ___typeOfControl,string ___text, int ___width, int ___height, System.Drawing.Color ___backColor, System.Drawing.Color ___forecColor, bool ___showHBar, bool ___showVBar, bool ___isHiddenAsDefault, bool ___skipAddControl);

    public interface IMultiversalHostingControlInterface
    {
        object createControl(Type ___typeOfControl,string ___text, int ___width, int ___height, System.Drawing.Color ___backColor, System.Drawing.Color ___forecColor, bool ___showHBar, bool ___showVBar, bool ___isHiddenAsDefault, bool ___skipAddControl);
        void clearChildManagedControls();
        System.IntPtr getControlHandleThreadSafe();
    }
   
}
