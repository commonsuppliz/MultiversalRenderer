using Microsoft.ClearScript;
using Microsoft.ClearScript.V8;
using MultiversalRenderer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MultiversalRenderer.ClearScriptV8Processor 
{

    public class V8Processor : IMultiversalScriptProcessor
    {
        private V8ProcsserScope? ___v8ProcsserScope = null;
        public IMultiversalScope? multiversalscope
        {
            get { return ___v8ProcsserScope; }
            set { ___v8ProcsserScope = value as V8ProcsserScope; }
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
                ___v8ProcsserScope.___v8ScriptEngine.Execute(script);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.ToString());
            };
            return null;
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



    /*
    public class ClearScriptV8Function : Microsoft.ClearScript.ScriptObject, IDisposable, IPrototypeFunction
    {
        

        public override object this[int index] { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public override object this[string name, params object[] args] { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override ScriptEngine Engine => throw new NotImplementedException();

        public override IEnumerable<string> PropertyNames => throw new NotImplementedException();

        public override IEnumerable<int> PropertyIndices => throw new NotImplementedException();

        public override bool DeleteProperty(string name)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteProperty(int index)
        {
            throw new NotImplementedException();
        }

        public override void Dispose()
        {
            throw new NotImplementedException();
        }

        public override object GetProperty(string name, params object[] args)
        {
            throw new NotImplementedException();
        }

        public override object GetProperty(int index)
        {
            throw new NotImplementedException();
        }

        public override object Invoke(bool asConstructor, params object[] args)
        {
            throw new NotImplementedException();
        }

        public override object InvokeMethod(string name, params object[] args)
        {
            throw new NotImplementedException();
        }

        public override void SetProperty(string name, params object[] args)
        {
            throw new NotImplementedException();
        }

        public override void SetProperty(int index, object value)
        {
            throw new NotImplementedException();
        }
    }
    */

}
