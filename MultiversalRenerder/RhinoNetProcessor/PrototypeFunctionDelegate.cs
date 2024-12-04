using System;
using System.Collections.Generic;
using System.Text;
using org.mozilla.javascript;
using MultiversalRenderer.Interfaces;

namespace MultiversalRenderer.RhinoNetProcessor
{

    public sealed class PrototypeFunctionDelegate : org.mozilla.javascript.BaseFunction, IPrototypeFunction
    {
        

        private string ___functionName = null;
        private System.WeakReference ___scopeReference = null;
        internal bool isActiveXObjectMethod = false;
        internal bool hasGeneralNodeConstatVariables = false;
        internal bool isArrayTypePrototype = false;
        public static org.mozilla.javascript.FunctionObject ___valueOfFunction = null;
       
        public PrototypeFunctionDelegate(string ___funcName, ScriptableObject scope)
        {
            this.___functionName = ___funcName;
            this.___scopeReference = new WeakReference(scope, false);
           // this.___DelegateVoid = ___delegate;
           
        }
        private object ___multiversal_prototype_object = null;
        public object multiversal_prototype_object
        {
            get { return this.___multiversal_prototype_object; }
            set { this.___multiversal_prototype_object = value; }
        }
        public string name
        {
            get { return this.___functionName; }
            set { this.___functionName = value; }
        }
        public override void put(string name, Scriptable start, object value)
        {
            base.put(name, start, value);
        }
        public override void defineConst(string name, Scriptable start)
        {
            base.defineConst(name, start);
        }
        public override object getDefaultValue(java.lang.Class typeHint)
        {
            object objDefault = base.getDefaultValue(typeHint);
            return objDefault;
        }
        protected override Scriptable getClassPrototype()
        {
            return base.getClassPrototype();
        }
        /// <summary>
        /// Value of shoud returns this object itself.
        /// </summary>
        /// <returns></returns>
        public object ___valueOf()
        {
            return this;
        }
        
        public override object get(string ___name, Scriptable ___start)
        {
            object ___getresult = base.get(___name, ___start);
            if (___getresult == org.mozilla.javascript.UniqueTag.NOT_FOUND)
            {
                switch (___name)
                {
                    case "isNamespace":
                        return false;
                    case "valueOf":
                        // 
                        if (PrototypeFunctionDelegate.___valueOfFunction == null)
                        {
                            java.lang.Class __thisClass = typeof(PrototypeFunctionDelegate);
                            java.lang.reflect.Method valueOfMethod = __thisClass.getMethod("___valueOf");
                           PrototypeFunctionDelegate.___valueOfFunction = new FunctionObject("valueOf", valueOfMethod, this);
                        }
                        return PrototypeFunctionDelegate.___valueOfFunction;
                        
                    case "prototype":
                        {
                            if (this.___multiversal_prototype_object != null)
                            {
                                ScriptableObject oscope = this.___scopeReference.Target as ScriptableObject;
                                if (this.___multiversal_prototype_object is Scriptable)
                                {
                                    return this.___multiversal_prototype_object;
                                }
                                else
                                {
                                    return commonTypeConverter.ConvertCLRValueToJavaValue(___multiversal_prototype_object, oscope);
                                }
                            }
                            else
                            {
                                if (commonLog.LoggingEnabled)
                                {
                                    commonLog.LogEntry(this.___functionName + " prototype is null");
                                }
                                return org.mozilla.javascript.Undefined.instance;
                            }
                        }
                        
                    case "implement":
                        return org.mozilla.javascript.Undefined.instance;
                }
                if (this.hasGeneralNodeConstatVariables == true)
                {
                    switch (___name)
                    {
                        case "ELEMENT_NODE":
                            return 1;
                        case "ATTRIBUTE_NODE":
                            return 2;
                        case "TEXT_NODE":
                            return 3;
                        case "CDATA_SECTION_NODE":
                            return 4;
                        case "ENTITY_REFERENCE_NODE":
                            return 5;
                        case "ENTITY_NODE":
                            return 6;
                        case "PROCESSING_INSTRUCTION_NODE":
                            return 7;
                        case "COMMENT_NODE":
                            return 8;
                        case "DOCUMENT_NODE":
                            return 9;
                        case "DOCUMENT_TYPE_NODE":
                            return 10;
                        case "DOCUMENT_FRAGMENT_NODE":
                            return 11;
                        case "NOTATION_NODE":
                            return 12;
                    }
                }
                if (this.isArrayTypePrototype == true)
                {
                    if (string.Equals(___name, "BYTES_PER_ELEMENT", StringComparison.Ordinal) == true)
                    {
                        switch (this.___functionName)
                        {
                            case "ArrayBuffer":
                            case "TypedArray":
                            case "Uint8Array":
                            case "Int8Array":
                                return 1;
                            case "Uint16Array":
                            case "Int16Array":
                                return 2;
                            case "Float64Array":
                                return 8;
                            default:
                                return 4;
                        }
                    }
                }
            }
            if (RhinoNetProcessor.commonLog.LoggingEnabled && RhinoNetProcessor.commonLog.LogLevel > 1)
            {
                RhinoNetProcessor.commonLog.LogEntry("Prototype Interface {0}.get({1}) returns null", this.___functionName , ___name);
            }
            if (___getresult == org.mozilla.javascript.UniqueTag.NOT_FOUND)
            {
                return org.mozilla.javascript.Undefined.instance;
            }
            return ___getresult;
        }
        public override bool has(string name, Scriptable start)
        {
            return base.has(name, start);
        }

        public override Scriptable construct(Context cx, Scriptable scope, object[] args)
        {
            IMultiversalScope ___scope = null;
            ___scope = this.___scopeReference.Target as IMultiversalScope;
            if (___scope != null)
            {
                IMultiversalWindow ___multiversalWindow = ___scope.___getMultiversalWindow();

                object ___objInstance = null;
                try
                {
                    if (this.isActiveXObjectMethod == true)
                    {
                        ___objInstance = ___multiversalWindow.___createAsActiveXObject(args);

                    }
                    else
                    {
                        ___objInstance = ___multiversalWindow.___createObject(this.___functionName, args);

                    }
                    if (___objInstance != null)
                    {

                        if (___objInstance is org.mozilla.javascript.Scriptable)
                        {
                            return ___objInstance as org.mozilla.javascript.Scriptable;
                        }
                        else
                        {

                            object oreturn = commonTypeConverter.ConvertCLRValueToJavaValue(___objInstance, scope);
                            return oreturn as Scriptable;
                        }
                    }
                }
                catch (Exception ex)
                {
                    org.mozilla.javascript.JavaScriptException jsex = new JavaScriptException(ex.Message, "", -1);
                    throw jsex;
                }
            }
            return null;
        }


        
        public override string getClassName()
        {
            return this.___functionName;
        }
        protected override int findInstanceIdInfo(string s)
        {
            return base.findInstanceIdInfo(s);
        }
        public override bool hasInstance(Scriptable instance)
        {
            return ___perforormPrototypeFunctionInstanceOfCheck(instance);
           
        }
        private IMutilversalObjectType   ___targetType;
        public IMutilversalObjectType  multiversalClassType
        {
            get { return ___targetType; }
            set { this.___targetType = value; }
        }
      
        private bool ___perforormPrototypeFunctionInstanceOfCheck(Scriptable ___objectScriptable)
        {
            if (this.___targetType == IMutilversalObjectType.Unkown || this.___targetType == IMutilversalObjectType.Node)
            {
                if (commonLog.LoggingEnabled)
                {
                    commonLog.LogEntry("BUGUGU!!!,  ___perforormPrototypeFunctionInstanceOfCheck is attempting umknown class prototype : {0} " + ___functionName );
                }
            }
            bool ___perforormPrototypeFunctionInstanceOfCheckResult = false;
            Type ___UnwrappedType = null;
            string ___UnwrappedTypeClassName = null;
            string ___elementTagName = null;
            ICommonObjectInterface  ___commonObject = null;
            IMutilversalObjectType __mutiversalType = IMutilversalObjectType.Unkown;
            if (___objectScriptable != null)
            {
                MultiversalRenderer.RhinoNetProcessor.MultiversalWrapperObject ___nativeObject = ___objectScriptable as MultiversalRenderer.RhinoNetProcessor.MultiversalWrapperObject;
                if(___nativeObject != null)
                {
                    ___commonObject = commonTypeConverter.ConvertInterceptNativeObjectToCLRObject(___nativeObject) as ICommonObjectInterface;
                    if (___commonObject != null)
                    {
                        ___UnwrappedType = ___commonObject.GetType();
                        ___UnwrappedTypeClassName = ___UnwrappedType.Name;
                        
                      
                            __mutiversalType = ___commonObject.multiversalClassType;
                        

                        
                        


                        goto JudgementPhase;
                    }
                }
                else
                {
 
                    ___UnwrappedType = ___objectScriptable.GetType();
                    ___UnwrappedTypeClassName = ___UnwrappedType.Name;
                    goto JudgementPhase;
                }
            }
            JudgementPhase:
            if (commonLog.LoggingEnabled)
            {
                if (__mutiversalType == IMutilversalObjectType.Node || __mutiversalType == IMutilversalObjectType.Unkown)
                {
                    commonLog.LogEntry("TODO: ___perforormPrototypeFunctionInstanceOfCheck is performing umknown this :  {0}   multiversal type : {1} : {2} " , this.___targetType, __mutiversalType, ___objectScriptable);
                }
            }


            
            if (__mutiversalType != IMutilversalObjectType.Unkown)
            {
                if (__mutiversalType == ___targetType)
                {
                    ___perforormPrototypeFunctionInstanceOfCheckResult = true;
                    goto ResultPhase;
                }
                switch (__mutiversalType)
                {
                    case IMutilversalObjectType.HTMLCanvasElement:
                        if (this.___targetType == IMutilversalObjectType.HTMLCanvasElement)
                            ___perforormPrototypeFunctionInstanceOfCheckResult = true;
                        goto ResultPhase;
                    default:
                        if (__mutiversalType.ToString().StartsWith("HTML", StringComparison.Ordinal) == true)
                        {
                            if (this.___targetType == IMutilversalObjectType.HTMLElement || this.___targetType == IMutilversalObjectType.Element || this.___targetType == IMutilversalObjectType.Node)
                            {
                                ___perforormPrototypeFunctionInstanceOfCheckResult = true;
                                goto ResultPhase;
                            }
                        }
                        break;
                }
            }
            switch (___UnwrappedTypeClassName)
            {
                case "CHtmlElement":
                    if (string.Equals(this.___functionName, "Element", StringComparison.Ordinal) == true)
                    {
                        ___perforormPrototypeFunctionInstanceOfCheckResult = true;
                        goto ResultPhase;
                    }
                    else if (string.Equals(this.___functionName, "HtmlElement", StringComparison.Ordinal) == true)
                    {
                        ___perforormPrototypeFunctionInstanceOfCheckResult = true;
                        goto ResultPhase;
                    }
                    if (string.IsNullOrEmpty(___elementTagName) == false)
                    {
                        switch (___elementTagName)
                        {
                            case "IMG":
                                if (string.Equals(this.___functionName, "HTMLImageElement", StringComparison.Ordinal) == true)
                                {
                                    ___perforormPrototypeFunctionInstanceOfCheckResult = true;
                                    goto ResultPhase;
                                }
                                break;
                            default:
                                if (commonLog.LoggingEnabled)
                                {
                                    commonLog.LogEntry("TODO: ___perforormPrototypeFunctionInstanceOfCheck for " + ___elementTagName);
                                }
                                break;
                        }
                    }
                    break;
                case "CHtmlCanvasElement":
                case "HTMLCanvasElement":
                    if (this.___targetType == IMutilversalObjectType.HTMLCanvasElement)
                    {
                        ___perforormPrototypeFunctionInstanceOfCheckResult = true;
                        goto ResultPhase;
                    }
                    break;
                case "CHtmlCanvasContext":
                    if (this.___targetType == IMutilversalObjectType.CanvasRenderingContext2D)
                    {
                        ___perforormPrototypeFunctionInstanceOfCheckResult = true;
                        goto ResultPhase;
                    }
                    else if (this.___targetType == IMutilversalObjectType.WebGLRenderingContext)
                    {
                        ___perforormPrototypeFunctionInstanceOfCheckResult = true;
                        goto ResultPhase;
                    }
                    break;
                case "CHtmlMediaElement":
                case "HTMLAudioElement":
                case "HTMLVideoElement":
                    if (string.Equals(___functionName, "HTMLAudioElement", StringComparison.Ordinal) == true)
                    {
                        ___perforormPrototypeFunctionInstanceOfCheckResult = true;
                        goto ResultPhase;

                    }
                    else if (string.Equals(___functionName, "HTMLVideoElement", StringComparison.Ordinal) == true)
                    {
                        ___perforormPrototypeFunctionInstanceOfCheckResult = true;
                        goto ResultPhase;

                    }
                    break;
                case "CHtmlSVGElement":
                    if (string.Equals(___functionName, "HTMLSvgElement", StringComparison.OrdinalIgnoreCase) == true)
                    {
                        ___perforormPrototypeFunctionInstanceOfCheckResult = true;
                        goto ResultPhase;
                    }
                    
                    break;
                case "HTMLCollection":
                case "CHtmlCollection":
                    if (string.Equals(___functionName, "HTMLCollection", StringComparison.Ordinal) == true)
                    {
                        ___perforormPrototypeFunctionInstanceOfCheckResult = true;
                        goto ResultPhase;
                    }
                    else
                    {
                        ___perforormPrototypeFunctionInstanceOfCheckResult = false;
                        goto ResultPhase;
                    }
                case "NodeList":
                case "CHtmlNodeList":
                    if (string.Equals(___functionName, "NodeList", StringComparison.Ordinal) == true)
                    {
                        ___perforormPrototypeFunctionInstanceOfCheckResult = true;
                        goto ResultPhase;
                    }
                    else
                    {
                        ___perforormPrototypeFunctionInstanceOfCheckResult = false;
                        goto ResultPhase;
                    }

                case "NativeObject":
                    
                    switch (this.___targetType)
                    {
                        case IMutilversalObjectType.Object:
                            ___perforormPrototypeFunctionInstanceOfCheckResult = true;
                            break;

                        default:
                        ___perforormPrototypeFunctionInstanceOfCheckResult = false;
                            break;
                    }
                        goto ResultPhase;
                case "NativeArray":
 
                    switch (this.___targetType)
                    {
                        case IMutilversalObjectType.Array:
                            ___perforormPrototypeFunctionInstanceOfCheckResult = true;
                            break;

                        default:
                            ___perforormPrototypeFunctionInstanceOfCheckResult = false;
                            break;
                    }
                    goto ResultPhase;

                case  "InterpretedFunction":
                         ___perforormPrototypeFunctionInstanceOfCheckResult = true;
                        goto ResultPhase;
                        

            }
            ResultPhase:
            if (commonLog.LoggingEnabled && commonLog.LogLevel >= 10)
            {
                commonLog.LogEntry(this.___functionName + " ___perforormPrototypeFunctionInstanceOfCheck for {0} {1} {2} >>= {3} Result :  {4}", __mutiversalType, ___UnwrappedTypeClassName, ___elementTagName, this.___targetType, ___perforormPrototypeFunctionInstanceOfCheckResult);
            }
            
            
            return ___perforormPrototypeFunctionInstanceOfCheckResult;
        }
    }
}
