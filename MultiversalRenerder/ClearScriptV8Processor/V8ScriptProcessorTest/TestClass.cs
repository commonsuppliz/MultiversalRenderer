using System;
using System.Diagnostics;
using System.Threading;
using Microsoft.ClearScript;

namespace V8ScriptProcessorTest
{
    public class MyCustomClass
    {

        public void Test1()
        {
            Console.WriteLine("Test1 is called");

        }
[NoScriptAccess]
        public void Test2() { Console.WriteLine("Test2 is called"); }
[NoScriptAccess]
        public void Test3() { Console.WriteLine("Test3 is called"); }
        public void Test4() { Console.WriteLine("Test4 is called"); }
        [NoScriptAccess]
        public void Test5() { Console.WriteLine("Test5 is called"); }
        [NoScriptAccess]
        public void Test6() { Console.WriteLine("Test6 is called"); }
        public void Test7() { Console.WriteLine("Test7 is called"); }
        public void Test8() { Console.WriteLine("Test8 is called"); }
        public void Test9() { Console.WriteLine("Test9 is called"); }
        public void Test10() { Console.WriteLine("Test10 is called"); }
        public void Test11() { }
        public void Test12() { }
        public void Test13() { }
        public void Test14() { }
        public void Test15() { }
        public void Test16() { }
        public void Test17() { }
        public void Test18() { }
        public void Test19() { }
        public void Test20() { }
    [NoScriptAccess]
        public override string ToString()
        {
            return base.ToString();
        }
            [NoScriptAccess]
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }
            [NoScriptAccess]
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        [NoScriptAccess]
        public Type GetType
        {
            [NoScriptAccess]
            get
            {
                return base.GetType();
            }

        }

    }

}