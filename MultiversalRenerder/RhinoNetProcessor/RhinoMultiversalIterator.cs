using System;
using System.Collections;
using System.Text;
using org.mozilla.javascript;
using System.Reflection;

namespace MultiversalRenderer.RhinoNetProcessor
{
    public class RhinoMultiversalIterator : org.mozilla.javascript.ScriptableObject
    {
        private static readonly long serialVersionUID = 19694425220L;
        private System.Collections.ArrayList _IteratorList;
        private int ___nextCount = 0;
        private MultiversalWrapperObject __InterpretedObject = null;
        private Type BindingType = null;

        internal System.WeakReference ___startObjectWeakReference = null;

        internal System.WeakReference ___targetObjectWeakReference = null;

        public  RhinoMultiversalIterator()
        {
            if (serialVersionUID>0) { }
            if (commonLog.LoggingEnabled && commonLog.LogLevel >= 10)
            {
                commonLog.LogEntry("RhinoMultiversalIterator Default Constructor()...");
            }
            this._IteratorList = new ArrayList();
            this.___nextCount = 0;
        }
        public  RhinoMultiversalIterator(MultiversalWrapperObject obj)
        {
            if (commonLog.LoggingEnabled && commonLog.LogLevel >= 10)
            {
                commonLog.LogEntry("RhinoMultiversalIterator Default Constructor()...");
            }
            __InterpretedObject = obj;
        }
        public RhinoMultiversalIterator(Scriptable obj) 
        {
            if (commonLog.LoggingEnabled && commonLog.LogLevel >= 10)
            {
                commonLog.LogEntry("RhinoMultiversalIterator Default Constructor with Scriptable()...");
            }
            
        }
        [org.mozilla.javascript.annotations.JSFunction]
        public bool hasNext()
        {
            if (commonLog.LoggingEnabled && commonLog.LogLevel >= 10)
            {
                commonLog.LogEntry("hasNext()...");
            }
            return true;
        }

        public override String getClassName() { return "RhinoMultiversalIterator"; }
         
        [org.mozilla.javascript.annotations.JSFunction]
        public static object jsConstructor(Context cx, Object[] args, Function functionObject, bool isNewExpr)
        {
            object unwrappedObject = null;
            RhinoMultiversalIterator it = new RhinoMultiversalIterator();
          if (args.Length > 0)
          {
              if (args[0] is MultiversalWrapperObject)
              {
                  it.__InterpretedObject = args[0] as MultiversalWrapperObject;

              }
              else
              {
                  it.___targetObjectWeakReference = new WeakReference(args[0], false);
                  unwrappedObject = args[0];
              }
          }
          else
          {
             
              if (commonLog.LoggingEnabled && commonLog.LogLevel >= 10)
              {
                  commonLog.LogEntry("RhinoMultiversalIterator called with {0} ", args);
              }

          }
            if (it.__InterpretedObject != null )
            {
                if (commonLog.LoggingEnabled && commonLog.LogLevel >= 10)
                {
                    commonLog.LogEntry("Building Properties for {0} {1}", it.__InterpretedObject, it.__InterpretedObject.GetType());
                }
                unwrappedObject = it.__InterpretedObject.unwrap();
                it.BindingType = unwrappedObject.GetType();
                if ((unwrappedObject is System.Collections.ICollection) == false &&  it.BindingType.IsArray == false)
                {
                    foreach (System.Reflection.PropertyInfo pInfo in it.BindingType.GetProperties(System.Reflection.BindingFlags.Public))
                    {
                        switch (pInfo.Name)
                        {
                            case "Item":
                            case "Capacity":
                                continue;
                        }
                        it._IteratorList.Add(pInfo.Name);
                    }
                }
                else if(unwrappedObject != null)
                {
                    //int ___ArrayLength = -1;
                    if (commonLog.LoggingEnabled && commonLog.LogLevel >= 10)
                    {
                        commonLog.LogEntry("TODO : Building Properties for {0} {1} requied.", it.__InterpretedObject, it.__InterpretedObject.GetType());
                    }
                    /*
                    if (unwrappedObject is HTML.CHtmlList)
                    {
                        HTML.CHtmlList _htmlList = unwrappedObject as HTML.CHtmlList;
                        ___ArrayLength = _htmlList.length;
                    }
                    else if(unwrappedObject is HTML.CHtmlSortedList)
                    {
                        HTML.CHtmlSortedList _htmlsortedList = unwrappedObject as HTML.CHtmlSortedList;
                        ___ArrayLength = _htmlsortedList.length;

                    }
                    else if (unwrappedObject is System.Collections.ArrayList)
                    {
                        System.Collections.ArrayList _arrayList = unwrappedObject as System.Collections.ArrayList;
                        ___ArrayLength = _arrayList.Count;

                    }
                    else if (unwrappedObject is System.Collections.SortedList)
                    {
                        System.Collections.SortedList _sortedList = unwrappedObject as System.Collections.SortedList;
                        ___ArrayLength = _sortedList.Count;
                    }
                    else if (unwrappedObject is HTML.CHtmlAttributeList)
                    {
                        HTML.CHtmlAttributeList attrList = unwrappedObject as HTML.CHtmlAttributeList;
                        ___ArrayLength = attrList.length;
                    }
                    else
                    {
                        if (commonLog.LoggingEnabled && commonLog.LogLevel > 10)
                        {
                            commonLog.LogEntry("BUGUBG Unknown list");
                        }

                    }

                    if (___ArrayLength >= 1)
                    {
                        for (int c = 0; c < ___ArrayLength; c++)
                        {
                            it._IteratorList.Add(c);
                        }
                    }
                    // .NET may have special fields. So we just returns "length" property 
                    it._IteratorList.Add("length");
                    */
                    

                }
                if (commonLog.LoggingEnabled && commonLog.LogLevel >= 10)
                {
                    commonLog.LogEntry("RhinoMultervalIterator jsConstructor() created for '{0}' with {1} properties", it.BindingType, it._IteratorList.Count);
                }
            }
            else if (unwrappedObject != null)
            {
                int ___ArrayLength = -1;

                if (unwrappedObject is System.Collections.ArrayList)
                {
                    System.Collections.ArrayList _arrayList = unwrappedObject as System.Collections.ArrayList;
                    ___ArrayLength = _arrayList.Count;

                }
                else if (unwrappedObject is System.Collections.SortedList)
                {
                    System.Collections.SortedList _sortedList = unwrappedObject as System.Collections.SortedList;
                    ___ArrayLength = _sortedList.Count;
                }
                else if (unwrappedObject is System.Array)
                {
                    System.Array ___array = unwrappedObject as System.Array;
                    ___ArrayLength = ___array.Length;
                }
                else
                {
                    if (commonLog.LoggingEnabled && commonLog.LogLevel >= 10)
                    {
                        commonLog.LogEntry("Iterator bill bind object using reflection...");
                    }
                    foreach (System.Reflection.PropertyInfo pInfo in unwrappedObject.GetType().GetProperties(System.Reflection.BindingFlags.Public))
                    {
                        switch (pInfo.Name)
                        {
                            case "Item":
                            case "Capacity":
                                continue;
                        }
                        it._IteratorList.Add(pInfo.Name);
                    }
                }
                if (___ArrayLength >= 1)
                {
                    for (int c = 0; c < ___ArrayLength; c++)
                    {
                        it._IteratorList.Add(c);
                    }
                }
                // .NET may have special fields. So we just returns "length" property 
                it._IteratorList.Add("length");
            }
            it.defineFunctionProperties(new string[] { "next", "hasNext" }, typeof(RhinoMultiversalIterator), ScriptableObject.DONTENUM);
            return it;
        }
       
         
        [org.mozilla.javascript.annotations.JSFunction]
        public object jsFunction_next()
        {
            if (commonLog.LoggingEnabled && commonLog.LogLevel >= 10)
            {
                commonLog.LogEntry("calling jsFunction_next()...");
            }
            return null;
        }
        
      //  [org.mozilla.javascript.annotations.JSFunction]
        public Object next()
        {
            if (commonLog.LoggingEnabled && commonLog.LogLevel >= 10)
            {
                commonLog.LogEntry("calling RhinoMultiversalIterator.next()... current : {0}", ___nextCount);
            }
            if (___nextCount >= this._IteratorList.Count)
            {
                //throw new JavaScriptException(NativeIterator.getStopIterationObject(getParentScope()), null, 0);
                Scriptable ___parentScope = this.___startObjectWeakReference.Target as Scriptable;
                throw new JavaScriptException(NativeIterator.getStopIterationObject(___parentScope), null, 0);
            }
            object current = this._IteratorList[this.___nextCount];
            //Utils.Log("{0} next() {1} : {2}", BindingType, this.___nextCount, current);
            ___nextCount++;
            return current;
        }
         
        public void jsFunction_remove() { throw new Exception("Unsupport"); }
        /*
        [org.mozilla.javascript.annotations.JSFunction]
        public bool hasNext()
        {
            Utils.Log("hasnext()...");
            return true;
        }
         */
        /*
        public object next()
        {
            return null;
        }
         */
        public object move()
        {
            if (commonLog.LoggingEnabled && commonLog.LogLevel >= 10)
            {
                commonLog.LogEntry("move()...");
            }
            return null;
        }
        public override object get(string name, Scriptable start)
        {
            object objResult = base.get(name, start);
            if (objResult == org.mozilla.javascript.UniqueTag.NOT_FOUND)
            {
                if (commonLog.LoggingEnabled && commonLog.LogLevel >= 10)
                {
                    commonLog.LogEntry("MultiversalIterator looking for " + name);
                }
                switch (name)
                {
                    case "":
                        break;

                }
            }
            return objResult;
        }

        public void remove() { throw new Exception("Unsupport"); }
        [org.mozilla.javascript.annotations.JSFunction]
        public Object __iterator__(bool b)
        {
            if (commonLog.LoggingEnabled && commonLog.LogLevel >= 10)
            {
                commonLog.LogEntry("{0}", "__iterator___");
            }
            return this;
        }
    }
}
