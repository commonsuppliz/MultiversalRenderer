using System;
using System.Collections.Generic;
using System.Text;
using MultiversalRenderer.Interfaces;

namespace MultiversalRenderer.RhinoNetProcessor
{
    public sealed class RhinoScriptProcessor : IMultiversalScriptProcessor
    {
        internal MultiversalRenderer.RhinoNetProcessor.RhinoMultiversalScope ___globalScope = null;
        public void put(string __name, Object __val)
        {
        }
        public object get(string ___name)
        {
            return null;
        }
        public object execute(string ___script)
        {
            org.mozilla.javascript.Context context = org.mozilla.javascript.Context.enter();
            bool IsContextExited = false;
            object objResult = null;
            try
            {
                // <!-------- Compile Version ------------------------------------------
                //org.mozilla.javascript.Script compiledScript = context.compileString(___script, "", 1, null);
                //objResult  = compiledScript.exec(context, this.___globalScope);
                // -------------------------------------------------------------------->

                objResult = context.evaluateString(this.___globalScope as org.mozilla.javascript.ScriptableObject, ___script, "", 1, null);
            }
            catch (Exception ex)
            {
                org.mozilla.javascript.Context.exit();
                IsContextExited = true;
                throw ex;
            }
            if (IsContextExited == false)
            {
                org.mozilla.javascript.Context.exit();
            }
            return objResult;
        }
        public object compile(string ___script)
        {
            org.mozilla.javascript.Context context = org.mozilla.javascript.Context.enter();

            object objResult = null;
            try
            {
                objResult = context.compileString(___script, "", 1, null);
            }
            catch (Exception ex)
            {
                org.mozilla.javascript.Context.exit();
                throw ex;
            }
            org.mozilla.javascript.Context.exit();
            return objResult;
        }
        public object callfunction(object ___function)
        {
            org.mozilla.javascript.Context context = org.mozilla.javascript.Context.enter();
            org.mozilla.javascript.Scriptable compilescope = context.newObject(this.___globalScope);
            compilescope.setPrototype(null);
            compilescope.setParentScope(this.___globalScope);
            object objResult = null;
            try
            {
                org.mozilla.javascript.IdFunctionObject ___funcObj = ___function as org.mozilla.javascript.IdFunctionObject;
                if (___funcObj != null)
                {
                   objResult =  ___funcObj.call(context, this.___globalScope, compilescope, new object[] { });
                }
                else if (___function is org.mozilla.javascript.BaseFunction)
                {
                    org.mozilla.javascript.BaseFunction __baseFunction = ___function as org.mozilla.javascript.BaseFunction;
                    objResult =  __baseFunction.call(context, this.___globalScope, compilescope, new object[] { });
                }
                else if (___function is org.mozilla.javascript.Script)
                {
                    org.mozilla.javascript.Script ___scripObj = ___function as org.mozilla.javascript.Script;
                    if (___scripObj != null)
                    {
                        objResult = ___scripObj.exec(context, compilescope);
                    }

                }
            }
            catch (Exception ex)
            {
                org.mozilla.javascript.Context.exit();
                throw ex;
            }
            org.mozilla.javascript.Context.exit();
            return objResult;
        }

        public object callfunction(object ___function, Object ___scope, Object ___thisObj, Object[] ___args)
        {
            org.mozilla.javascript.Context context = org.mozilla.javascript.Context.enter();
            object objResult = null;
            try
            {
                org.mozilla.javascript.BaseFunction   ___funcObj = ___function as org.mozilla.javascript.BaseFunction;
                if (___funcObj != null)
                {
                    if (___args == null)
                    {
                        // Rhino does not like null arguments.
                        ___args = new object[] { };
                    }
                    else
                    {
                        int argLen = ___args.Length;
                        for (int apos = 0; apos < argLen; apos++)
                        {
                            if (___args[apos] is org.mozilla.javascript.Scriptable)
                            {
                                continue;
                            }
                            else if (___args[apos] is RhinoNetProcessor.MultiversalWrapperObject)
                            {
                                continue;
                            }
                            else
                            {
                                ___args[apos] = org.mozilla.javascript.Context.javaToJS(___args[apos], this.___globalScope);
                            }
                        }
                    }
                    if (___thisObj == null)
                    {
                        objResult = ___funcObj.call(context, this.___globalScope, this.___globalScope, ___args);
                    }
                    else if (___thisObj is org.mozilla.javascript.Scriptable)
                    {

                        objResult = ___funcObj.call(context, this.___globalScope, ___thisObj as org.mozilla.javascript.Scriptable, ___args);
                    }
                    else
                    {
                        object ___wrappedThis = org.mozilla.javascript.Context.javaToJS(___thisObj, this.___globalScope);
                        org.mozilla.javascript.Scriptable __wrappedScriptable = ___wrappedThis as org.mozilla.javascript.Scriptable;
                   
                       
                        objResult = ___funcObj.call(context, this.___globalScope, __wrappedScriptable, ___args);


                    }
                }
            }
            catch 
            {
                org.mozilla.javascript.Context.exit();
                throw;
            }
            org.mozilla.javascript.Context.exit();
            return objResult;
        }

        public IMultiversalScope  multiversalscope
        {
            get{return this.___globalScope;}
            set { this.___globalScope = value as RhinoMultiversalScope; }
        }

  

    }
}
