using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Python.Runtime;
using MultiversalRenderer.Interfaces;
namespace PythonProcessor
{

    internal class PythonProcessor : IAsyncDisposable, IMultiversalScriptProcessor
    {
        public PythonProcessor() { }

        public IMultiversalScope multiversalscope { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

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

        public ValueTask DisposeAsync()
        {
            throw new NotImplementedException();
        }

        public object execute(string script)
        {
            throw new NotImplementedException();
        }

        public object get(string name)
        {
            throw new NotImplementedException();
        }

        public void put(string name, object val)
        {
            throw new NotImplementedException();
        }
    }
}
