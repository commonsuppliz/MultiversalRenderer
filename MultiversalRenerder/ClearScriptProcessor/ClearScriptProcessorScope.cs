using System;
using System.Collections.Generic;
using Microsoft.ClearScript.JavaScript;
using Microsoft.ClearScript.V8;
using MultiversalRenderer.Interfaces;

namespace ClearScriptProcessor
{

    public class ClearScriptProcessorScope : IMultiversalScope, IDisposable
    {
        private V8ScriptEngine? _v8Engine = null;
        private bool _isInitCompleted = false;
        private bool _isDisposed = false;
        public void Dispose()
        {
            _v8Engine.Dispose();
            _isDisposed = true;
        }
        public V8ScriptEngine engine
        {
            get { return _v8Engine; }
        }
        public void disposeScriptEngine()
        {
            _v8Engine.Dispose();
            _isDisposed = true;
        }

        public string getMultivasalScopeName()
        {
            throw new NotImplementedException();
        }

        public string[] getMultiversalInvokeScriptNames()
        {
            throw new NotImplementedException();
        }

        public IMultiversalScriptProcessor getMultiversalScriptProcessor()
        {
            ClearScriptProcessor clearScriptProcessor = new ClearScriptProcessor();
            clearScriptProcessor.multiversalscope = this;
            clearScriptProcessor.engine = _v8Engine;
            return clearScriptProcessor;
        }

        public IMultiversalWindow getMultiversalWindow()
        {
            throw new NotImplementedException();
        }

        public IMultiversalWindowType getMutilversalWindowType()
        {
            throw new NotImplementedException();
        }

        public void initScriptEngine()
        {
            _v8Engine = new V8ScriptEngine();
            _isInitCompleted = true;
        }

        public bool isDefaultMultiversalProcessor()
        {
            return true;
        }

        public bool isInitCompleted()
        {
            return _isInitCompleted;
        }

        public void relaseMultiversal()
        {
            throw new NotImplementedException();
        }

        public void setMultiversalWindow(IMultiversalWindow window)
        {
            throw new NotImplementedException();
        }

        public void setMutilversalWindowType(IMultiversalWindowType windowType)
        {
            throw new NotImplementedException();
        }


    }
}