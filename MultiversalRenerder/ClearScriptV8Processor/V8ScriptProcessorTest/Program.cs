using System;
using System.Diagnostics;
using System.Threading;
using Microsoft.ClearScript;
using MultiversalRenderer.ClearScriptV8Processor;
using MultiversalRenderer.Interfaces;
using static MultiversalRenderer.ClearScriptV8Processor.V8ProcsserScope;

namespace V8ScriptProcessorTest
{
    
    internal class Program
    {
        public static V8ProcsserScope scope1 = new V8ProcsserScope();
        public static IMultiversalScriptProcessor processor1 = null;
        public static V8ProcsserScope scope2 = new V8ProcsserScope();
        public static IMultiversalScriptProcessor processor2 = null;
        public static V8ProcsserScope scope3 = new V8ProcsserScope();
        public static IMultiversalScriptProcessor processor3 = null;
        
        static void Main(string[] args)
        {
            Console.WriteLine("Invoking V8EngineProcessor...");
            
            scope1.___initScriptEngine();
            scope2.___initScriptEngine();
            Console.WriteLine($"Init Thread Id is {System.Threading.Thread.CurrentThread.ManagedThreadId}");
            processor1 =  scope1.___getMultiversalScriptProcessor();
            processor2 = scope2.___getMultiversalScriptProcessor();
            //scope1.___v8ScriptEngine.AddHostType("XmlHttpRequest", typeof(XmlHttpRequest));
            MyCustomClass myCustomClass = new MyCustomClass();
            scope1.___v8ScriptEngine.AddHostObject("myClass", myCustomClass);
            scope1.___v8ScriptEngine.AddHostType("Console", typeof(Console));
            //scope2.___v8ScriptEngine.AddHostType("XmlHttpRequest", typeof(XmlHttpRequest));
            //processor1.execute("load('run.js');");
            processor1.execute("var hogehoge1 = 99999;");
           // processor1.execute("var xmh = new XmlHttpRequest();");
            processor1.execute("for(let prop in myClass){Console.WriteLine(prop);};");
            /*
            ThreadStart sh1 = new ThreadStart(Test1);
            Thread th1 = new Thread(sh1);
            th1.Start();
            ThreadStart sh2 = new ThreadStart(Test2);
            Thread th2 = new Thread(sh2);
            th2.Start();
            System.Threading.Thread.Sleep(100);
            Test2();
            */
        }
        public static void Test1()
        {
            Console.WriteLine($"Test 1 Thread Id is {System.Threading.Thread.CurrentThread.ManagedThreadId}");

            processor1.execute("load('run.js');");
            //processor1.execute("var xmh = new XmlHttpRequest();");
            var obj = scope1.___v8ScriptEngine.Global["hogehoge1"];
            Console.WriteLine($"Test 1 hogehoge1 is {obj}");

        }
        public static void Test2()
        {
            Console.WriteLine($"Test 2 Thread Id is {System.Threading.Thread.CurrentThread.ManagedThreadId}");
            processor2.execute("load('run.js');");
            //processor2.execute("var xmh = new XmlHttpRequest();");
            processor2.execute("var hogehoge1 = 99999;");
            var obj = scope2.___v8ScriptEngine.Global["hogehoge1"];
            processor2.execute("var hogehoge1 = 99999;");
            Console.WriteLine($"Test 2 hogehoge1 is {obj}");
        }
    }
}
