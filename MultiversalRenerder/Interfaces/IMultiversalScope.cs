using System;
using System.Collections.Generic;

using System.Text;

namespace MultiversalRenderer.Interfaces
{

    public interface IMultiversalScope
    {

        //IMultiversalScope constructorMultiversalScope(IMultiversalWindow multi);
        void   relaseMultiversal();
        string getMultivasalScopeName();
        void initScriptEngine();
        bool isInitCompleted();
        void disposeScriptEngine();
        string[] getMultiversalInvokeScriptNames();
        bool isDefaultMultiversalProcessor();
        IMultiversalScriptProcessor getMultiversalScriptProcessor();
        IMultiversalWindow getMultiversalWindow();
        void setMutilversalWindowType(IMultiversalWindowType windowType);
        IMultiversalWindowType getMutilversalWindowType();
        void setMultiversalWindow(IMultiversalWindow window);



    }
}
