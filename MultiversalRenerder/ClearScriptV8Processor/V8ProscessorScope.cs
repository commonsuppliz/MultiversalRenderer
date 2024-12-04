using Microsoft.ClearScript.V8;
using MultiversalRenderer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MultiversalRenderer.ClearScriptV8Processor 
{

    public class V8ProcsserScope : IMultiversalScope
    {
        public V8ScriptEngine ___v8ScriptEngine;
        internal V8Processor ___v8Processor;
        internal bool ___isV8EngineInitCompleted = false;
        private IMultiversalWindow ___Multiversal = null;
        public void ___disposeScriptEngine()
        {
            if(___v8ScriptEngine != null) { ___v8ScriptEngine.Dispose(); }
            
        }
        public class XmlHttpRequest
        {
            public XmlHttpRequest() {
                Console.WriteLine($"XmlHttpRequest is created with Thread Id {System.Threading.Thread.CurrentThread.ManagedThreadId}");
            }
        }

        public void ___initScriptEngine()
        {
            ___v8ScriptEngine = new V8ScriptEngine();


       
            ___v8Processor = new V8Processor();

            ___v8Processor.multiversalscope = this;
            ___isV8EngineInitCompleted = true;

        }

        public void ___enableActiveXObjectSupport(bool ___level)
        {
            throw new NotImplementedException();
        }

        public string ___getMultivasalScopeName()
        {
            throw new NotImplementedException();
        }

        public string[] ___getMultiversalInvokeScriptNames()
        {
            throw new NotImplementedException();
        }

        public IMultiversalScriptProcessor ___getMultiversalScriptProcessor()
        {
            return this.___v8Processor;
        }

        public IMultiversalWindow ___getMultiversalWindow()
        {
            throw new NotImplementedException();
        }

        public IMultiversalWindowType ___getMutilversalWindowType()
        {
            throw new NotImplementedException();
        }

        public bool ___isDefaultMultiversalProcessor()
        {
            throw new NotImplementedException();
        }

        public bool ___isInitCompleted()
        {
            return ___isV8EngineInitCompleted;
        }

        public void ___relaseMultiversal()
        {
            throw new NotImplementedException();
        }

        public void ___setMutilversalWindowType(IMultiversalWindowType windowType)
        {
            throw new NotImplementedException();
        }

        public void ___setMultiversalWindow(IMultiversalWindow window)
        {
            this.___Multiversal = window;
        }
    }
}
