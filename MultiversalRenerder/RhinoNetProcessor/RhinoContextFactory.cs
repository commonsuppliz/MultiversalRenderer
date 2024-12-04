using System;
using System.Collections.Generic;

using System.Text;
using org.mozilla.javascript;
using System.Collections;

namespace MultiversalRenderer.RhinoNetProcessor
{

    public sealed class InterceptorContextFactory : ContextFactory
    {

        internal const string ___rhinoiteratorName = "__iterator__";

        internal const int RhinoDefaultObserverThreashold = 150000000; // about  1 timer check / per 3-4 sec
        //internal const int RhinoDefaultObserverThreashold = 50000000; // about  1 timer check / per 1 sec
        //  internal const int RhinoDefaultObserverThreashold = 1000000; // about  .5 timer check / per 3-4 sec
        /// <summary>
        /// This List is contains Type ist should inited at first time.
        /// WrappingClassList has been abondoned to performance. use 'is'
        /// </summary>
        //public static SortedList WrappingClassList = new SortedList(new HTML.CHtmlOrdinalIgnoreCaseComparer());
        private static readonly object ___factoryLockingObject = new object();

        public static void InitInterceptorContextFactory()
        {
            bool _IsLocked = System.Threading.Monitor.TryEnter(___factoryLockingObject, 1000);
            if (_IsLocked)
            {
                try
                {

                    if (ContextFactory.hasExplicitGlobal() == false)
                    {
                        ContextFactory.initGlobal(new InterceptorContextFactory());
                    }
                }
                catch { }
                finally
                {
                    if (_IsLocked)
                    {
                        System.Threading.Monitor.Exit(___factoryLockingObject);
                    }
                }
            }
        }
        private static int RHINO_DEFAULT_MAX_STACK_DEPTH = 2147483647;


        protected override Context makeContext()
        {

            InterceptorContext ctx = new InterceptorContext(this);
            // 17R6 no java calls by    con.initSafeStandardObjects(this, false);
            ctx.setClassShutter(new RhinoNetProcessor.RhinoClassShutter());
            // Use pure interpreter mode to allow for
            // observeInstructionCount(Context, int) to work
            try
            {
                ctx.setOptimizationLevel(commonTypeConverter.RhinoOptimizationLevel);
            }
            catch (Exception ex)
            {
                if (commonLog.LoggingEnabled && commonLog.LogLevel > 15)
                {
                    commonLog.LogEntry("setOptimizationLevel failed.use default value", ex);
                }
            }
            // Make Rhino runtime to call observeInstructionCount
            // each x bytecode instructions.
            // 10000 is less than 1 msecs on Core 2 Duo.
            // ctx.setInstructionObserverThreshold(10 * 1000 * 1000); // ~200 msecs.

            ctx.setLanguageVersion(Context.VERSION_ES6);

            if (commonTypeConverter.RhinoOptimizationLevel == -1)
            {
                ctx.setInstructionObserverThreshold(RhinoDefaultObserverThreashold);
                ctx.setGenerateObserverCount(true);
                ctx.setMaximumInterpreterStackDepth(RHINO_DEFAULT_MAX_STACK_DEPTH);
            }
            else
            {
                // ----------------------------------------------------------------------------------------------------
                // we can not use setMaximumInterpreterStackDepth(), if Optimization Level != -1
                // ----------------------------------------------------------------------------------------------------
                //ctx.setMaximumInterpreterStackDepth(1000000);
            }



            if (commonLog.LoggingEnabled)
            {
                if (commonTypeConverter.RhinoOptimizationLevel == -1)
                {
                    ctx.setGeneratingDebug(true);
                    ctx.setGeneratingSource(true); // we always allow toSource() working

                }
                else
                {
                    ctx.setGeneratingDebug(false);
                    ctx.setGeneratingSource(false); // we always allow toSource() working

                }
            }
            else
            {
                if (commonTypeConverter.RhinoOptimizationLevel == -1)
                {
                    ctx.setGeneratingDebug(true);
                    ctx.setGeneratingSource(true); // we always allow toSource() working

                }
                else
                {
                    ctx.setGeneratingDebug(false);
                    ctx.setGeneratingSource(false); // we always allow toSource() working
                }
            }



            RhinoWrapFactory fact = new RhinoWrapFactory();

            ctx.setWrapFactory(fact);


            //ctx.generateObserverCount = true;
            return ctx;
        }



        protected override void observeInstructionCount(Context cx, int instructionCount)
        {
            //Console.WriteLine(DateTime.Now.ToLongTimeString() + " observeInstuctionCount Hit!");
            // InterceptorContext tcx = (InterceptorContext)cx;
            // tcx.observeElapsedMilliseconds();
            InterceptorContext tcx = cx as InterceptorContext;
            tcx.observeElapsedMilliseconds();
        }




    }
    public sealed class InterceptorContext : Context
    {
        System.Diagnostics.Stopwatch __stopWatch = null;

        System.WeakReference ____ActiveScopeWeakReference = null;

        string ___CurrentURL = null;
        private bool ____IsScriptTimeoutSpecified = true;
        private int ____ScriptTimeoutMilliseconds = 30000;


        public InterceptorContext(ContextFactory contextFactory)
            : base(contextFactory)
        {
            // Rhino 1.7R2pre needed for protected super constructor with factory g.
            //base(contextFactory);
            __stopWatch = new System.Diagnostics.Stopwatch();
            this.__stopWatch.Start();
        }

        public void observeElapsedMilliseconds()
        {

            if (this.____IsScriptTimeoutSpecified == true && this.__stopWatch.ElapsedMilliseconds > this.____ScriptTimeoutMilliseconds)
            {

                long __elaptedInMilliseconds = this.__stopWatch.ElapsedMilliseconds;

                throw new org.mozilla.javascript.EvaluatorException("JavaScriptTimeout " + __elaptedInMilliseconds.ToString() + " ms");
            }

        }
        internal void ____SetActiveScriptScope(org.mozilla.javascript.Scriptable _scope)
        {
            this.____ActiveScopeWeakReference = new WeakReference(_scope, false);
        }
        internal void ___SetCurrentURL(string ___url)
        {
            this.___CurrentURL = ___url;
        }
        internal Scriptable ___GetActiveScriptScope()
        {
            if (this.____ActiveScopeWeakReference != null)
            {
                return this.____ActiveScopeWeakReference.Target as Scriptable;
            }
            else
            {
                return null;
            }
        }
        public string ___GetCurrentUrl()
        {
            return this.___CurrentURL;
        }
        public void ___SetScriptTimeout(int __milliseconds)
        {

            this.____IsScriptTimeoutSpecified = true;
            this.____ScriptTimeoutMilliseconds = __milliseconds;

        }
        public override bool hasFeature(int featureIndex)
        {
            switch (featureIndex)
            {
                case Context.FEATURE_THREAD_SAFE_OBJECTS:
                case Context.FEATURE_V8_EXTENSIONS:
                    return true;
            }
            return base.hasFeature(featureIndex);
        }


    }
}
