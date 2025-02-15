using Microsoft.ClearScript.V8;
using MultiversalRenderer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClearScriptProcessor
{
    public class ClearScriptProcessor : IMultiversalScriptProcessor, IDisposable
    {
        private IMultiversalScope? _scope = null;
        private V8ScriptEngine _v8ScriptEngine = null;
        private bool _isDisposed = false;
        public IMultiversalScope multiversalscope
        {
            get
            {
                return _scope;
            }
            set
            {
                _scope = value;
            }
        }
        public V8ScriptEngine engine
        {
            get
            {
                return _v8ScriptEngine;

            }
            set
            {
                _v8ScriptEngine = value;
            }
        }

        public object callfunction(object functionobject)
        {
            throw new NotImplementedException();
        }

        public object callfunction(object functionobject, object scope, object thisObj, object[] args)
        {
            throw new NotImplementedException();
        }

        public object compile(string script)
        {
            throw new NotImplementedException();
        }

        public object execute(string script)
        {
            return  _v8ScriptEngine.Evaluate(script);
        }

        public object get(string name)
        {
            throw new NotImplementedException();
        }

        public void put(string name, object val)
        {
            throw new NotImplementedException();
        }

        void IDisposable.Dispose()
        {
            
        }
    }
}
