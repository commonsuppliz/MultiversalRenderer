using System;
using System.Collections.Generic;

using System.Text;

namespace MultiversalRenderer.Interfaces
{

    public interface IMultiversalScope
    {

        //IMultiversalScope ___constructorMultiversalScope(IMultiversalWindow multi);
        void   ___relaseMultiversal();
        string ___getMultivasalScopeName();
        void ___initScriptEngine();
        bool ___isInitCompleted();
        void ___disposeScriptEngine();
        string[] ___getMultiversalInvokeScriptNames();
        bool ___isDefaultMultiversalProcessor();
        IMultiversalScriptProcessor ___getMultiversalScriptProcessor();
        IMultiversalWindow ___getMultiversalWindow();
        void ___setMutilversalWindowType(IMultiversalWindowType windowType);
        IMultiversalWindowType ___getMutilversalWindowType();
        void ___setMultiversalWindow(IMultiversalWindow window);



    }
}
