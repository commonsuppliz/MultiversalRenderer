using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using MultiversalRenderer.Interfaces;
using NiL.JS.Core;
using NiL.JS.BaseLibrary;
using NiL.JS.Core.Interop;
using NiL.JS.Expressions;
using System.Linq;

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

            if (functionobject is Function)
            {
                return ((Function)functionobject).Call(new Arguments());
            }
            else
            {
                throw new ArgumentException("functionobject is not a NilJs Function");
            }
        }

        public object callfunction(object functionobject, object scope, object thisObj, object[] args)
        {
            if (functionobject is Function)
            {
                Arguments nlArgs = new Arguments();
                if (args != null)
                {
                    for (int i = 0; i < args.Length; i++)
                    {
                        nlArgs.Add(JSValue.Marshal(args[i]));
                    }
                }
                return ((Function)functionobject).Call(nlArgs);


            }
            else
            {
                throw new ArgumentException("functionobject is not a NilJs Function");
            }
        }

        public object compile(string script)
        {
            int pos = script.IndexOf("function");
            if (pos == -1)
            {
                throw new ArgumentException("script is not a function");
            }
            else
            {
                string funcName = script.Substring(pos + 8, script.IndexOf("(", pos) - pos - 8).Trim();
                scope.context.Eval(script);
                return  scope.context.GetVariable(funcName);

            }
      
        }

        [Hidden]
        public object execute(string script)
        {
            return ExecuteWithTimeout(script, TimeSpan.FromSeconds(30)).GetAwaiter().GetResult();
        }

        private async Task<object> ExecuteWithTimeout(string script, TimeSpan timeout)
        {
            using (var cts = new CancellationTokenSource())
            {
                var task = Task.Run(() => scope.context.Eval(script), cts.Token);

                if (await Task.WhenAny(task, Task.Delay(timeout, cts.Token)) == task)
                {
                    // スクリプトの評価が完了した場合
                    return task.Result;
                }
                else
                {
                    // タイムアウトが発生した場合
                    cts.Cancel();
                    throw new TimeoutException("スクリプトの評価がタイムアウトしました。");
                }
            }
        }

        public object get(string name)
        {
            return scope.context.GetVariable(name);
        }

        public void put(string name, object val)
        {
            scope.context.DefineVariable(name).Assign(JSValue.Marshal(val));
        }

    }
}
