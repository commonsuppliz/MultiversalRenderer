using System;
using System.Collections.Generic;
using MultiversalRenderer.Interfaces;
using NiL.JS.Core;
namespace NilJsProcessor
{
    public class NilJsProcessor : IMultiversalScriptProcessor
    {
        public NilJsScope scope = null;
        public IMultiversalScope multiversalscope
        {
            get { return scope; }
            set { scope = (NilJsScope)value; }
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
            try
            {
                return scope.context.Eval(script);
            }
            catch (NiL.JS.Core.JSException ex)
            {
                // Log the exception details
                Console.WriteLine($"JSException: {ex.Message}");
                throw;
            }
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
