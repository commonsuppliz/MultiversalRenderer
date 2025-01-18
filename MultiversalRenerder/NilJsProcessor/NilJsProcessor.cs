using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
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
