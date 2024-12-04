using System;
using System.Collections.Generic;

using System.Text;
using org.mozilla.javascript;
using MultiversalRenderer.Interfaces;

namespace MultiversalRenderer.RhinoNetProcessor
{
    public sealed class RhinoMultiversalScope : ScriptableObject, IMultiversalScope
    {
        
        private static java.lang.reflect.Method onhashchangeGetMethod = null;
        private static java.lang.reflect.Method onhashchangeSetMethod = null;

        private static java.lang.reflect.Method onpopstateGetMethod = null;
        private static java.lang.reflect.Method onpopstateSetMethod = null;
         
        public static bool ___IsContextFactoryInited  = false;
        private static System.Collections.Generic.Dictionary<string, byte> ___PropertiesNeedsToBeBaseScope = null;
        private static bool ___isPropertiesNeedsToBeBaseScopeListInited = false;
        private IMultiversalWindowType ___MutilversalWindowType = IMultiversalWindowType.Unknown;
        private object ___ScopeLockingObject = new object();
        internal bool ___isActiveXObjectSupported = false;
      //  private uint ____ScriptExecuteCount = 0;
        //private string ___LastMultivasalReturnedObjectName = null;
        private static readonly string[] ___javascriptNames = new string[] { "javascript", "x-javascript" };
        private static readonly string[] ___defineFunctionNames = new string[] { "___set_onfunction_property", "___get_onfunction_property"};
        public string[] ___getMultiversalInvokeScriptNames()
        {
            return ___javascriptNames;
        }
        public bool ___isDefaultMultiversalProcessor()
        {
            return true;
        }
        public void ___enableActiveXObjectSupport(bool ___enabled)
        {
            this.___isActiveXObjectSupported = ___enabled;
        }
        public IMultiversalScriptProcessor ___getMultiversalScriptProcessor()
        {
            RhinoScriptProcessor __rhinoProcessor = new RhinoScriptProcessor();
            __rhinoProcessor.multiversalscope = this;
            return __rhinoProcessor;
        }
 
        internal bool ___hasInitializeCompleted = false;

        public RhinoMultiversalScope()
        {

        }
        private static System.Collections.Generic.SortedList<string, org.mozilla.javascript.Script> CompiledOnFunctionList = new System.Collections.Generic.SortedList<string, Script>(StringComparer.Ordinal);

        internal static System.Collections.Generic.SortedList<string, ushort> ___WindowOnFunctionNamedList = ___createWindowFunctionSortedList();
        private static System.Collections.Generic.SortedList<string, ushort> ___createWindowFunctionSortedList()
        {
            System.Collections.Generic.SortedList<string, ushort > list = new SortedList<string, ushort>(StringComparer.Ordinal);
            list["ondeviceorientation"] = 0;
            list["ondevicemotion"] = 0;
            list["onunload"] = 0;
            list["onstorage"] = 0;
            list["onpopstate"] = 0;
            list["onhashchange"] = 0;
            list["onpageshow"] = 0;
            list["onpagehide"] = 0;
            list["ononline"] = 0;
            list["onoffline"] = 0;
            list["onmessage"] = 0;
            list["onbeforeunload"] = 0;
            list["onwaiting"] = 0;
            list["onvolumechange"] = 0;
            list["ontimeupdate"] = 0;
            list["onsuspend"] = 0;
            list["onsubmit"] = 0;
            list["onstalled"] = 0;
            list["onshow"] = 0;
            list["onselect"] = 0;
            list["onseeking"] = 0;
            list["onseeked"] = 0;
            list["onscroll"] = 0;
            list["onresize"] = 0;
            list["onreset"] = 0;
            list["onratechange"] = 0;
            list["onprogress"] = 0;
            list["onplaying"] = 0;
            list["onplay"] = 0;
            list["onpause"] = 0;
            list["onmousewheel"] = 0;
            list["onmouseup"] = 0;
            list["onmouseover"] = 0;
            list["onmouseout"] = 0;
            list["onmousemove"] = 0;
            list["onmouseleave"] = 0;
            list["onmouseenter"] = 0;
            list["onmousedown"] = 0;
            list["onloadstart"] = 0;
            list["onloadedmetadata"] = 0;
            list["onloadeddata"] = 0;
            list["onload"] = 0;
            list["onkeyup"] = 0;
            list["onkeypress"] = 0;
            list["onkeydown"] = 0;
            list["oninvalid"] = 0;
            list["oninput"] = 0;
            list["onfocus"] = 0;
            list["onfocusin"] = 0;
            list["onfocusout"] = 0;
            list["onerror"] = 0;
            list["onended"] = 0;
            list["onemptied"] = 0;
            list["ondurationchange"] = 0;
            list["ondrop"] = 0;
            list["ondragstart"] = 0;
            list["ondragover"] = 0;
            list["ondragleave"] = 0;
            list["ondragenter"] = 0;
            list["ondragend"] = 0;
            list["ondrag"] = 0;
            list["ondblclick"] = 0;
            list["oncuechange"] = 0;
            list["oncontextmenu"] = 0;
            list["onclose"] = 0;
            list["onclick"] = 0;
            list["onchange"] = 0;
            list["oncanplaythrough"] = 0;
            list["oncanplay"] = 0;
            list["oncancel"] = 0;
            list["onblur"] = 0;
            list["onabort"] = 0;
            list["onwheel"] = 0;
            list["onwebkittransitione"] = 0;
            list["onwebkitanimationstart"] = 0;
            list["onwebkitanimationiteration"] = 0;
            list["onwebkitanimationend"] = 0;
            list["ontransitionend"] = 0;
            list["onsearch"] = 0;
            list["onhelp"] = 0;
            list["onpointercancel"] = 0;
            list["onpointerdown"] = 0;
            list["onpointerenter"] = 0;
            list["onpointerleave"] = 0;
            list["onpointermove"] = 0;
            list["onpointerout"] = 0;
            list["onpointerover"] = 0;
            list["onpointerup"] = 0;
            list["onmsgesturechange"] = 0;
            list["onmsgesturedoubletap"] = 0;
            list["onmsgestureend"] = 0;
            list["onmsgesturehold"] = 0;
            list["onmsgesturestart"] = 0;
            list["onmsgesturetap"] = 0;
            list["onmsinertiastart"] = 0;
            list["onmspointercancel"] = 0;
            list["onmspointerdown"] = 0;
            list["onmspointerenter"] = 0;
            list["onmspointerleave"] = 0;
            list["onmspointermove"] = 0;
            list["onmspointerout"] = 0;
            list["onmspointerover"] = 0;
            list["onmspointerup"] = 0;
            list["ongotpointercapture"] = 0;
            list["onlostpointercapture"] = 0;
            list["onbeforescriptexecute"] = 0;
            list["onafterscriptexecute"] = 0;
            list["onmozfullscreenchange"] = 0;
            list["onmozfullscreenerror"] = 0;
            list["onmozpointerlockchange"] = 0;
            list["onmozpointerlockerror"] = 0;
            list["ondeviceproximity"] = 0;
            list["onuserproximity"] = 0;
            list["ondevicelight"] = 0;
            return list;
        }
        private IMultiversalWindow ___Multiversal;
        const string ___getClassNameString = "object";
        public override string getClassName()
        {
            return ___getClassNameString; // Chrome returns "object"
        }
        public bool ___isInitCompleted()
        {
            return this.___hasInitializeCompleted;
        }
        public IMultiversalWindow ___getMultiversalWindow()
        {
            return this.___Multiversal;
        }
        public void ___setMutilversalWindowType(IMultiversalWindowType ___windowType)
        {
            this.___MutilversalWindowType = ___windowType;
        }
        public IMultiversalWindowType ___getMutilversalWindowType()
        {
            return this.___MutilversalWindowType;
        }

        public void ___initScriptEngine()
        {
            bool ___IsFirstRun = false;
            Context con = null;
            if (System.Threading.Monitor.TryEnter(this.___ScopeLockingObject, 5000))
            {
                try
                {
                    if (___IsContextFactoryInited == false)
                    {
                        ___IsFirstRun = true;
                        InterceptorContextFactory.InitInterceptorContextFactory();


                        ___IsContextFactoryInited = true;
                    }

                    con = Context.enter();


                }
                finally
                {
                    System.Threading.Monitor.Exit(this.___ScopeLockingObject);
                }
            }
            if (___isPropertiesNeedsToBeBaseScopeListInited == false)
            {
                if (___PropertiesNeedsToBeBaseScope == null)
                {
                    ___PropertiesNeedsToBeBaseScope = new Dictionary<string, byte>();
                }
            }

            // until 17R5
            //con.initStandardObjects(this, false);
            // from 17R6

            con.initSafeStandardObjects(this, false);


            this.defineFunctionProperties(___defineFunctionNames, typeof(RhinoMultiversalScope), ScriptableObject.DONTENUM);
            java.lang.Class thisClass = typeof(RhinoMultiversalScope);


            if (onhashchangeGetMethod == null)
            {
                onhashchangeGetMethod = thisClass.getMethod("___get___onhashchange");
            }
            if (onhashchangeSetMethod == null)
            {
                onhashchangeSetMethod = thisClass.getMethod("___set___onhashchange", new java.lang.Class[] { typeof(object) });
            }
            this.defineProperty("onhashchange", null, onhashchangeGetMethod, onhashchangeSetMethod, ScriptableObject.PERMANENT);

            if (onpopstateGetMethod == null)
            {
                onpopstateGetMethod = thisClass.getMethod("___get___onpopstate");
            }
            if (onpopstateSetMethod == null)
            {
                onpopstateSetMethod = thisClass.getMethod("___set___onpopstate", new java.lang.Class[] { typeof(object) });
            }
            this.defineProperty("onpopstate", null, onpopstateGetMethod, onpopstateSetMethod, ScriptableObject.PERMANENT);


            if (this.___Multiversal != null)
            {

            
            this.defineProperty("removeEventListener", new BaseFunctionDelegate("removeEventListener", new BaseFunctionDelegate.Delegate4Object(this.___Multiversal.removeEventListener)), ScriptableObject.PERMANENT);

            this.defineProperty("addEventListener", new BaseFunctionDelegate("addEventListener", new BaseFunctionDelegate.Delegate4Object(this.___Multiversal.addEventListener)), ScriptableObject.PERMANENT);

            this.defineProperty("attachEvent", new BaseFunctionDelegate("attachEvent", new BaseFunctionDelegate.Delegate4Object(this.___Multiversal.addEventListener)), ScriptableObject.PERMANENT);

            this.defineProperty("detachEvent", new BaseFunctionDelegate("detachEvent", new BaseFunctionDelegate.Delegate4Object(this.___Multiversal.removeEventListener)), ScriptableObject.PERMANENT);

            BaseFunctionDelegate postMessageDelegate = new BaseFunctionDelegate("postMessage", new BaseFunctionDelegate.Delegate4Object(this.___Multiversal.postMessage));
            postMessageDelegate.___requiresCallerWindowInformationToBeCalled = true;
            postMessageDelegate.___callerMultiversalWindowWeakReference = new WeakReference(this.___Multiversal, false);
            this.defineProperty("postMessage", postMessageDelegate, ScriptableObject.PERMANENT);

            this.defineProperty("setTimeout", new BaseFunctionDelegate("setTimeout", new BaseFunctionDelegate.Delegate4Object(this.___Multiversal.setTimeout)), ScriptableObject.PERMANENT);
            this.defineProperty("setInterval", new BaseFunctionDelegate("setInterval", new BaseFunctionDelegate.Delegate4Object(this.___Multiversal.setInterval)), ScriptableObject.PERMANENT);

            this.defineProperty("clearInterval", new BaseFunctionDelegate("clearInteval", new BaseFunctionDelegate.Delegate4Object(this.___Multiversal.clearInterval)), ScriptableObject.PERMANENT);

            this.defineProperty("clearTimeout", new BaseFunctionDelegate("clearTimeout", new BaseFunctionDelegate.Delegate4Object(this.___Multiversal.clearTimeout)), ScriptableObject.PERMANENT);

            this.defineProperty("captureEvents", new BaseFunctionDelegate("captureEvents", new BaseFunctionDelegate.Delegate4Object(this.___Multiversal.captureEvents)), ScriptableObject.PERMANENT);
            this.defineProperty("releaseEvents", new BaseFunctionDelegate("releaseEvents", new BaseFunctionDelegate.Delegate4Object(this.___Multiversal.releaseEvents)), ScriptableObject.PERMANENT);
            this.defineProperty("dispatchEvent", new BaseFunctionDelegate("dispatchEvent", new BaseFunctionDelegate.Delegate4Object(this.___Multiversal.dispatchEvent)), ScriptableObject.PERMANENT);

            BaseFunctionDelegate ___requestAnimationFrameDelegate = new BaseFunctionDelegate("requestAnimationFrame", new BaseFunctionDelegate.Delegate4Object(this.___Multiversal.requestAnimationFrame));
            this.defineProperty("requestAnimationFrame", ___requestAnimationFrameDelegate, ScriptableObject.PERMANENT);
            this.defineProperty("webkitRequestAnimationFrame", ___requestAnimationFrameDelegate, ScriptableObject.PERMANENT);
            this.defineProperty("mozRequestAnimationFrame", ___requestAnimationFrameDelegate, ScriptableObject.PERMANENT);
            this.defineProperty("oRequestAnimationFrame", ___requestAnimationFrameDelegate, ScriptableObject.PERMANENT);
            this.defineProperty("msRequestAnimationFrame", ___requestAnimationFrameDelegate, ScriptableObject.PERMANENT);



            this.defineProperty("cancelAnimationFrame", new BaseFunctionDelegate("cancelAnimationFrame", new BaseFunctionDelegate.Delegate4Object(this.___Multiversal.cancelAnimationFrame)), ScriptableObject.PERMANENT);



            this.defineProperty("open", new BaseFunctionDelegate("open", new BaseFunctionDelegate.Delegate4Object(this.___Multiversal.open)), ScriptableObject.PERMANENT);


            this.defineProperty("navigate", new BaseFunctionDelegate("navigate", new BaseFunctionDelegate.Delegate4Object(this.___Multiversal.navigate)), ScriptableObject.PERMANENT);


            this.defineProperty("stop", new BaseFunctionDelegate("stop", new BaseFunctionDelegate.Delegate4Object(this.___Multiversal.stop)), ScriptableObject.PERMANENT);


            this.defineProperty("close", new BaseFunctionDelegate("close", new BaseFunctionDelegate.Delegate4Object(this.___Multiversal.close)), ScriptableObject.PERMANENT);

            this.defineProperty("alert", new BaseFunctionDelegate("alert", new BaseFunctionDelegate.Delegate4Object(this.___Multiversal.alert)), ScriptableObject.PERMANENT);
            this.defineProperty("prompt", new BaseFunctionDelegate("prompt", new BaseFunctionDelegate.Delegate4Object(this.___Multiversal.prompt)), ScriptableObject.PERMANENT);
            this.defineProperty("print", new BaseFunctionDelegate("print", new BaseFunctionDelegate.Delegate4Object(this.___Multiversal.print)), ScriptableObject.PERMANENT);

            this.defineProperty("showModalDialog", new BaseFunctionDelegate("showModalDialog", new BaseFunctionDelegate.Delegate4Object(this.___Multiversal.showModalDialog)), ScriptableObject.PERMANENT);

            this.defineProperty("matchMedia", new BaseFunctionDelegate("matchMedia", new BaseFunctionDelegate.Delegate4Object(this.___Multiversal.matchMedia)), ScriptableObject.PERMANENT);

            this.defineProperty("msMatchMedia", new BaseFunctionDelegate("matchMedia", new BaseFunctionDelegate.Delegate4Object(this.___Multiversal.matchMedia)), ScriptableObject.PERMANENT);

            this.defineProperty("webkitMatchMedia", new BaseFunctionDelegate("matchMedia", new BaseFunctionDelegate.Delegate4Object(this.___Multiversal.matchMedia)), ScriptableObject.PERMANENT);

            this.defineProperty("mozMatchMedia", new BaseFunctionDelegate("matchMedia", new BaseFunctionDelegate.Delegate4Object(this.___Multiversal.matchMedia)), ScriptableObject.PERMANENT);

            this.defineProperty("blur", new BaseFunctionDelegate("blur", new BaseFunctionDelegate.Delegate4Object(this.___Multiversal.blur)), ScriptableObject.PERMANENT);


            this.defineProperty("focus", new BaseFunctionDelegate("focus", new BaseFunctionDelegate.Delegate4Object(this.___Multiversal.focus)), ScriptableObject.PERMANENT);

            this.defineProperty("escape", new BaseFunctionDelegate("escape", new BaseFunctionDelegate.Delegate4Object(this.___Multiversal.escape)), ScriptableObject.PERMANENT);

            this.defineProperty("unescape", new BaseFunctionDelegate("unescape", new BaseFunctionDelegate.Delegate4Object(this.___Multiversal.unescape)), ScriptableObject.PERMANENT);

            this.defineProperty("encodeURI", new BaseFunctionDelegate("encodeURI", new BaseFunctionDelegate.Delegate4Object(this.___Multiversal.encodeURI)), ScriptableObject.PERMANENT);
            this.defineProperty("decodeURI", new BaseFunctionDelegate("decodeURI", new BaseFunctionDelegate.Delegate4Object(this.___Multiversal.decodeURI)), ScriptableObject.PERMANENT);
            this.defineProperty("encodeURIComponent", new BaseFunctionDelegate("encodeURIComponent", new BaseFunctionDelegate.Delegate4Object(this.___Multiversal.encodeURIComponent)), ScriptableObject.PERMANENT);
            this.defineProperty("decodeURIComponent", new BaseFunctionDelegate("decodeURIComponent", new BaseFunctionDelegate.Delegate4Object(this.___Multiversal.decodeURIComponent)), ScriptableObject.PERMANENT);
            this.defineProperty("atob", new BaseFunctionDelegate("atob", new BaseFunctionDelegate.Delegate4Object(this.___Multiversal.atob)), ScriptableObject.PERMANENT);
            this.defineProperty("btoa", new BaseFunctionDelegate("btoa", new BaseFunctionDelegate.Delegate4Object(this.___Multiversal.btoa)), ScriptableObject.PERMANENT);


            this.defineProperty("resizeTo", new BaseFunctionDelegate("resizeTo", new BaseFunctionDelegate.Delegate4Object(this.___Multiversal.resizeTo)), ScriptableObject.PERMANENT);


            this.defineProperty("resizeBy", new BaseFunctionDelegate("resizeBy", new BaseFunctionDelegate.Delegate4Object(this.___Multiversal.resizeBy)), ScriptableObject.PERMANENT);


            this.defineProperty("scrollTo", new BaseFunctionDelegate("scrollTo", new BaseFunctionDelegate.Delegate4Object(this.___Multiversal.scrollTo)), ScriptableObject.PERMANENT);
            this.defineProperty("scroll", new BaseFunctionDelegate("scroll", new BaseFunctionDelegate.Delegate4Object(this.___Multiversal.scroll)), ScriptableObject.PERMANENT);

            this.defineProperty("scrollBy", new BaseFunctionDelegate("scrollBy", new BaseFunctionDelegate.Delegate4Object(this.___Multiversal.scrollBy)), ScriptableObject.PERMANENT);

            this.defineProperty("moveTo", new BaseFunctionDelegate("moveTo", new BaseFunctionDelegate.Delegate4Object(this.___Multiversal.moveTo)), ScriptableObject.PERMANENT);

            this.defineProperty("moveBy", new BaseFunctionDelegate("moveBy", new BaseFunctionDelegate.Delegate4Object(this.___Multiversal.moveBy)), ScriptableObject.PERMANENT);

            this.defineProperty("getComputedStyle", new BaseFunctionDelegate("getComputedStyle", new BaseFunctionDelegate.Delegate4Object(this.___Multiversal.getComputedStyle)), ScriptableObject.PERMANENT);

            this.defineProperty("requestFileSystem", new BaseFunctionDelegate("requestFileSystem", new BaseFunctionDelegate.Delegate4Object(this.___Multiversal.requestFileSystem)), ScriptableObject.PERMANENT);

            // ==================================================================================================
            // DO NOT PUT 'hasOwnProperty'. It is covered by Rhino       
            // ==================================================================================================
            //this.defineProperty("hasOwnProperty", new BaseFunctionDelegate("hasOwnProperty", new// BaseFunctionDelegate.Delegate4Object(this.___hasOwnProperty)), ScriptableObject.PERMANENT);

            PrototypeFunctionDelegate imageDelegate = new PrototypeFunctionDelegate("Image", this);
            imageDelegate.multiversalClassType = IMutilversalObjectType.Image;
            ___Multiversal.registerPrototypeObject(imageDelegate);
            this.defineProperty("Image", imageDelegate, ScriptableObject.PERMANENT);

            PrototypeFunctionDelegate audioDelegate = new PrototypeFunctionDelegate("Audio", this);
            audioDelegate.multiversalClassType = IMutilversalObjectType.HTMLAudioElement;
            ___Multiversal.registerPrototypeObject(audioDelegate);
            this.defineProperty("Audio", audioDelegate, ScriptableObject.PERMANENT);

            PrototypeFunctionDelegate videoDelegate = new PrototypeFunctionDelegate("Video", this);
            videoDelegate.multiversalClassType = IMutilversalObjectType.HTMLVideoElement;
            ___Multiversal.registerPrototypeObject(videoDelegate);
            this.defineProperty("Video", videoDelegate, ScriptableObject.PERMANENT);




            PrototypeFunctionDelegate workerDelegate = new PrototypeFunctionDelegate("Worker", this);
            workerDelegate.multiversalClassType = IMutilversalObjectType.Worker;
            ___Multiversal.registerPrototypeObject(workerDelegate);
            this.defineProperty("Worker", workerDelegate, ScriptableObject.PERMANENT);

            PrototypeFunctionDelegate sharedworkerDelegate = new PrototypeFunctionDelegate("SharedWorker", this);
            sharedworkerDelegate.multiversalClassType = IMutilversalObjectType.SharedWorker;
            ___Multiversal.registerPrototypeObject(sharedworkerDelegate);
            this.defineProperty("SharedWorker", sharedworkerDelegate, ScriptableObject.PERMANENT);


            PrototypeFunctionDelegate xmlhttpReqeustDelegate = new PrototypeFunctionDelegate("XMLHttpRequest", this);
            xmlhttpReqeustDelegate.multiversalClassType = IMutilversalObjectType.XMLHttpRequest;
            ___Multiversal.registerPrototypeObject(xmlhttpReqeustDelegate);
            this.defineProperty("XMLHttpRequest", xmlhttpReqeustDelegate, ScriptableObject.PERMANENT);


            PrototypeFunctionDelegate domparserDelegate = new PrototypeFunctionDelegate("DOMParser", this);
            domparserDelegate.multiversalClassType = IMutilversalObjectType.DOMParser;
            ___Multiversal.registerPrototypeObject(domparserDelegate);
            this.defineProperty("DOMParser", domparserDelegate, ScriptableObject.PERMANENT);

            PrototypeFunctionDelegate blobDelegate = new PrototypeFunctionDelegate("Blob", this);
            blobDelegate.multiversalClassType = IMutilversalObjectType.Blob;
            ___Multiversal.registerPrototypeObject(blobDelegate);
            this.defineProperty("Blob", blobDelegate, ScriptableObject.PERMANENT);

            if (this.___isActiveXObjectSupported)
            {
                PrototypeFunctionDelegate activeXObjectDelegate = new PrototypeFunctionDelegate("ActiveXObject", this);
                activeXObjectDelegate.multiversalClassType = IMutilversalObjectType.ActiveXObject;
                activeXObjectDelegate.isActiveXObjectMethod = true;
                ___Multiversal.registerPrototypeObject(activeXObjectDelegate);
                this.defineProperty("ActiveXObject", activeXObjectDelegate, ScriptableObject.PERMANENT);
            }


            PrototypeFunctionDelegate windowEventProtototype = new PrototypeFunctionDelegate("Event", this);
            windowEventProtototype.multiversalClassType = IMutilversalObjectType.Event;
            ___Multiversal.registerPrototypeObject(windowEventProtototype);
            // this.put("Event", this, windowEventProtototype);
            ScriptableObject.putProperty(this, "Event", windowEventProtototype);


            PrototypeFunctionDelegate windowMouseEventProtototype = new PrototypeFunctionDelegate("MouseEvent", this);
            windowMouseEventProtototype.multiversalClassType = IMutilversalObjectType.MouseEvent;
            ___Multiversal.registerPrototypeObject(windowMouseEventProtototype);
            // this.put("Event", this, windowEventProtototype);
            ScriptableObject.putProperty(this, "MouseEvent", windowMouseEventProtototype);

            PrototypeFunctionDelegate windowHistoryProtototype = new PrototypeFunctionDelegate("History", this);
            windowHistoryProtototype.multiversalClassType = IMutilversalObjectType.History;
            ___Multiversal.registerPrototypeObject(windowHistoryProtototype);

            //this.defineProperty("History", windowEventProtototype, ScriptableObject.DONTENUM);
            ScriptableObject.putProperty(this, "History", windowHistoryProtototype);

            PrototypeFunctionDelegate windowAttrProtototype = new PrototypeFunctionDelegate("Attr", this);
            windowAttrProtototype.multiversalClassType = IMutilversalObjectType.Attr;
            windowAttrProtototype.hasGeneralNodeConstatVariables = true;
            ___Multiversal.registerPrototypeObject(windowAttrProtototype);
            // this.defineProperty("Attr", windowAttrProtototype, ScriptableObject.DONTENUM);
            ScriptableObject.putProperty(this, "Attr", windowAttrProtototype);


            PrototypeFunctionDelegate htmlCollectionPrototype = new PrototypeFunctionDelegate("HTMLCollection", this);
            htmlCollectionPrototype.multiversalClassType = IMutilversalObjectType.HTMLCollection;
            htmlCollectionPrototype.hasGeneralNodeConstatVariables = false;
            ___Multiversal.registerPrototypeObject(htmlCollectionPrototype);
            ScriptableObject.putProperty(this, "HTMLCollection", htmlCollectionPrototype);

            PrototypeFunctionDelegate nodeListPrototype = new PrototypeFunctionDelegate("NodeList", this);
            nodeListPrototype.multiversalClassType = IMutilversalObjectType.NodeList;
            nodeListPrototype.hasGeneralNodeConstatVariables = false;
            ___Multiversal.registerPrototypeObject(htmlCollectionPrototype);
            ScriptableObject.putProperty(this, "NodeList", nodeListPrototype);

            PrototypeFunctionDelegate windowCanvas2DPrototype = new PrototypeFunctionDelegate("CanvasRenderingContext2D", this);
            windowCanvas2DPrototype.multiversalClassType = IMutilversalObjectType.CanvasRenderingContext2D;
            windowCanvas2DPrototype.hasGeneralNodeConstatVariables = false;
            ___Multiversal.registerPrototypeObject(windowCanvas2DPrototype);
            this.defineProperty("CanvasRenderingContext2D", windowCanvas2DPrototype, ScriptableObject.DONTENUM);

            PrototypeFunctionDelegate windowWebGLPrototype = new PrototypeFunctionDelegate("WebGLRenderingContext", this);
            windowWebGLPrototype.multiversalClassType = IMutilversalObjectType.WebGLRenderingContext;
            windowWebGLPrototype.hasGeneralNodeConstatVariables = false;
            ___Multiversal.registerPrototypeObject(windowWebGLPrototype);
            this.defineProperty("WebGLRenderingContext", windowWebGLPrototype, ScriptableObject.DONTENUM);

            PrototypeFunctionDelegate windowAudioContextPrototype = new PrototypeFunctionDelegate("AudioContext", this);
            windowAudioContextPrototype.multiversalClassType = IMutilversalObjectType.AudioContext;
            windowAudioContextPrototype.hasGeneralNodeConstatVariables = false;
            ___Multiversal.registerPrototypeObject(windowAudioContextPrototype);
            this.defineProperty("AudioContext", windowAudioContextPrototype, ScriptableObject.DONTENUM);
            this.defineProperty("webkitAudioContext", windowAudioContextPrototype, ScriptableObject.DONTENUM);

            PrototypeFunctionDelegate windowAudioBufferSourceNodePrototype = new PrototypeFunctionDelegate("AudioBufferSourceNode", this);
            windowAudioBufferSourceNodePrototype.multiversalClassType = IMutilversalObjectType.AudioBufferSourceNode;
            windowAudioBufferSourceNodePrototype.hasGeneralNodeConstatVariables = false;
            ___Multiversal.registerPrototypeObject(windowAudioBufferSourceNodePrototype);
            this.defineProperty("AudioBufferSourceNode", windowAudioContextPrototype, ScriptableObject.DONTENUM);

            PrototypeFunctionDelegate windowAudioOscillatorNodePrototype = new PrototypeFunctionDelegate("OscillatorNode", this);
            windowAudioOscillatorNodePrototype.multiversalClassType = IMutilversalObjectType.OscillatorNode;
            windowAudioOscillatorNodePrototype.hasGeneralNodeConstatVariables = false;
            ___Multiversal.registerPrototypeObject(windowAudioOscillatorNodePrototype);
            this.defineProperty("OscillatorNode", windowAudioOscillatorNodePrototype, ScriptableObject.DONTENUM);

            PrototypeFunctionDelegate windowFilePrototype = new PrototypeFunctionDelegate("File", this);
            windowFilePrototype.multiversalClassType = IMutilversalObjectType.File;
            windowFilePrototype.hasGeneralNodeConstatVariables = false;
            ___Multiversal.registerPrototypeObject(windowFilePrototype);
            this.defineProperty("File", windowFilePrototype, ScriptableObject.DONTENUM);

            PrototypeFunctionDelegate windowFileReaderPrototype = new PrototypeFunctionDelegate("FileReader", this);
            windowFileReaderPrototype.multiversalClassType = IMutilversalObjectType.FileReader;
            windowFileReaderPrototype.hasGeneralNodeConstatVariables = false;
            ___Multiversal.registerPrototypeObject(windowFileReaderPrototype);
            this.defineProperty("FileReader", windowFileReaderPrototype, ScriptableObject.DONTENUM);

            PrototypeFunctionDelegate windowFileListPrototype = new PrototypeFunctionDelegate("FileList", this);
            windowFileListPrototype.multiversalClassType = IMutilversalObjectType.FileList;
            windowFileListPrototype.hasGeneralNodeConstatVariables = false;
            ___Multiversal.registerPrototypeObject(windowFileListPrototype);
            this.defineProperty("FileList", windowFileReaderPrototype, ScriptableObject.DONTENUM);


            PrototypeFunctionDelegate windowScreenProtototype = new PrototypeFunctionDelegate("Screen", this);
            windowScreenProtototype.multiversalClassType = IMutilversalObjectType.Screen;
            ___Multiversal.registerPrototypeObject(windowScreenProtototype);
            //this.defineProperty("Screen", windowScreenProtototype, ScriptableObject.DONTENUM);
            ScriptableObject.putProperty(this, "Screen", windowScreenProtototype);

            PrototypeFunctionDelegate windowNavigatorProtototype = new PrototypeFunctionDelegate("Navigator", this);
            windowNavigatorProtototype.multiversalClassType = IMutilversalObjectType.Navigator;
            ___Multiversal.registerPrototypeObject(windowNavigatorProtototype);
            //this.defineProperty("Navigator", windowNavigatorProtototype, ScriptableObject.DONTENUM);
            ScriptableObject.putProperty(this, "Navigator", windowNavigatorProtototype);


            PrototypeFunctionDelegate windowConsoleProtototype = new PrototypeFunctionDelegate("Console", this);
            windowConsoleProtototype.multiversalClassType = IMutilversalObjectType.Console;
            ___Multiversal.registerPrototypeObject(windowConsoleProtototype);
            //this.defineProperty("Console", windowConsoleProtototype, ScriptableObject.DONTENUM);
            ScriptableObject.putProperty(this, "Console", windowConsoleProtototype);

            PrototypeFunctionDelegate windowKeyboardEventProtototype = new PrototypeFunctionDelegate("KeyboardEvent", this);
            windowKeyboardEventProtototype.multiversalClassType = IMutilversalObjectType.KeyboardEvent;
            ___Multiversal.registerPrototypeObject(windowKeyboardEventProtototype);
            //this.defineProperty("Console", windowConsoleProtototype, ScriptableObject.DONTENUM);
            ScriptableObject.putProperty(this, "KeyboardEvent", windowKeyboardEventProtototype);

            PrototypeFunctionDelegate windowClipboardProtototype = new PrototypeFunctionDelegate("Clipboard", this);
            windowClipboardProtototype.multiversalClassType = IMutilversalObjectType.Clipboard;
            ___Multiversal.registerPrototypeObject(windowClipboardProtototype);
            // this.defineProperty("Clipboard", windowClipboardProtototype, ScriptableObject.DONTENUM);
            ScriptableObject.putProperty(this, "Clipboard", windowClipboardProtototype);

            // window.Window is not common. it should be one instance.
            PrototypeFunctionDelegate windowWindowProtototype = new PrototypeFunctionDelegate("Window", this);
            windowWindowProtototype.multiversalClassType = IMutilversalObjectType.Window;
            windowWindowProtototype.multiversal_prototype_object = this.___Multiversal;
            // this.defineProperty("Window", windowWindowProtototype, ScriptableObject.DONTENUM);
            ScriptableObject.putProperty(this, "Window", windowWindowProtototype);

            PrototypeFunctionDelegate windowDocumentPrototype = new PrototypeFunctionDelegate("Document", this);
            windowDocumentPrototype.multiversalClassType = IMutilversalObjectType.Document;
            ___Multiversal.registerPrototypeObject(windowDocumentPrototype);
            windowDocumentPrototype.hasGeneralNodeConstatVariables = true;
            ScriptableObject.putProperty(this, "Document", windowDocumentPrototype);




            PrototypeFunctionDelegate windowNodeProtototype = new PrototypeFunctionDelegate("Node", this);
            windowNodeProtototype.multiversalClassType = IMutilversalObjectType.Node;
            ___Multiversal.registerPrototypeObject(windowNodeProtototype);
            windowNodeProtototype.hasGeneralNodeConstatVariables = true;
            // this.defineProperty("Node", windowNodeProtototype, ScriptableObject.DONTENUM);
            ScriptableObject.putProperty(this, "Node", windowNodeProtototype);

            PrototypeFunctionDelegate domTokenListProtototype = new PrototypeFunctionDelegate("DOMTokenList", this);
            domTokenListProtototype.multiversalClassType = IMutilversalObjectType.DOMTokenList;
            ___Multiversal.registerPrototypeObject(domTokenListProtototype);
            domTokenListProtototype.hasGeneralNodeConstatVariables = false;
            this.defineProperty("DOMTokenList", domTokenListProtototype, ScriptableObject.DONTENUM);



            PrototypeFunctionDelegate windowElementProtototype = new PrototypeFunctionDelegate("Element", this);
            windowElementProtototype.multiversalClassType = IMutilversalObjectType.Element;
            windowElementProtototype.hasGeneralNodeConstatVariables = true;
            ___Multiversal.registerPrototypeObject(windowElementProtototype);
            //this.defineProperty("Element", windowElementProtototype, ScriptableObject.DONTENUM);
            ScriptableObject.putProperty(this, "Element", windowElementProtototype);

            PrototypeFunctionDelegate windowHTMLElementProtototype = new PrototypeFunctionDelegate("HTMLElement", this);
            windowHTMLElementProtototype.multiversalClassType = IMutilversalObjectType.HTMLElement;
            windowHTMLElementProtototype.hasGeneralNodeConstatVariables = true;
            ___Multiversal.registerPrototypeObject(windowHTMLElementProtototype);
            // this.defineProperty("HTMLElement", windowHTMLElementProtototype, ScriptableObject.DONTENUM);
            ScriptableObject.putProperty(this, "HTMLElement", windowHTMLElementProtototype);


            PrototypeFunctionDelegate windowHTMLHtmlElementProtototype = new PrototypeFunctionDelegate("HTMLHtmlElement", this);
            windowHTMLHtmlElementProtototype.multiversalClassType = IMutilversalObjectType.HTMLHtmlElement;
            windowHTMLHtmlElementProtototype.hasGeneralNodeConstatVariables = true;
            ___Multiversal.registerPrototypeObject(windowHTMLHtmlElementProtototype);
            this.defineProperty("HTMLHtmlElement", windowHTMLHtmlElementProtototype, ScriptableObject.DONTENUM);

            PrototypeFunctionDelegate windowHTMLBodyElementProtototype = new PrototypeFunctionDelegate("HTMLBodyElement", this);
            windowHTMLBodyElementProtototype.multiversalClassType = IMutilversalObjectType.HTMLBodyElement;
            windowHTMLBodyElementProtototype.hasGeneralNodeConstatVariables = true;

            ___Multiversal.registerPrototypeObject(windowHTMLBodyElementProtototype);
            this.defineProperty("HTMLBodyElement", windowHTMLBodyElementProtototype, ScriptableObject.DONTENUM);

            PrototypeFunctionDelegate windowHTMLHeadElementProtototype = new PrototypeFunctionDelegate("HTMLHeadElement", this);
            windowHTMLHeadElementProtototype.multiversalClassType = IMutilversalObjectType.HTMLHeadElement;
            windowHTMLHeadElementProtototype.hasGeneralNodeConstatVariables = true;

            ___Multiversal.registerPrototypeObject(windowHTMLHeadElementProtototype);
            this.defineProperty("HTMLHeadElement", windowHTMLHeadElementProtototype, ScriptableObject.DONTENUM);

            PrototypeFunctionDelegate windowHTMLBaseElementProtototype = new PrototypeFunctionDelegate("HTMLBaseElement", this);
            windowHTMLBaseElementProtototype.multiversalClassType = IMutilversalObjectType.HTMLBaseElement;
            windowHTMLBaseElementProtototype.hasGeneralNodeConstatVariables = true;

            ___Multiversal.registerPrototypeObject(windowHTMLBaseElementProtototype);
            this.defineProperty("HTMLBaseElement", windowHTMLBaseElementProtototype, ScriptableObject.DONTENUM);



            PrototypeFunctionDelegate windowHTMLInputElementProtototype = new PrototypeFunctionDelegate("HTMLInputElement", this);
            windowHTMLInputElementProtototype.multiversalClassType = IMutilversalObjectType.HTMLInputElement;
            windowHTMLInputElementProtototype.hasGeneralNodeConstatVariables = true;

            ___Multiversal.registerPrototypeObject(windowHTMLInputElementProtototype);
            this.defineProperty("HTMLInputElement", windowHTMLInputElementProtototype, ScriptableObject.DONTENUM);

            PrototypeFunctionDelegate windowHTMLAudioElementProtototype = new PrototypeFunctionDelegate("HTMLAudioElement", this);
            windowHTMLAudioElementProtototype.multiversalClassType = IMutilversalObjectType.HTMLAudioElement;
            windowHTMLAudioElementProtototype.hasGeneralNodeConstatVariables = true;
            ___Multiversal.registerPrototypeObject(windowHTMLAudioElementProtototype);
            this.defineProperty("HTMLAudioElement", windowHTMLAudioElementProtototype, ScriptableObject.DONTENUM);

            PrototypeFunctionDelegate windowHTMLVideoElementProtototype = new PrototypeFunctionDelegate("HTMLVideoElement", this);
            windowHTMLVideoElementProtototype.multiversalClassType = IMutilversalObjectType.HTMLVideoElement;
            windowHTMLVideoElementProtototype.hasGeneralNodeConstatVariables = true;
            ___Multiversal.registerPrototypeObject(windowHTMLVideoElementProtototype);
            this.defineProperty("HTMLVideoElement", windowHTMLVideoElementProtototype, ScriptableObject.DONTENUM);


            PrototypeFunctionDelegate windowHTMLCanvasElementProtototype = new PrototypeFunctionDelegate("HTMLCanvasElement", this);
            windowHTMLCanvasElementProtototype.multiversalClassType = IMutilversalObjectType.HTMLCanvasElement;
            windowHTMLCanvasElementProtototype.hasGeneralNodeConstatVariables = true;
            ___Multiversal.registerPrototypeObject(windowHTMLCanvasElementProtototype);
            this.defineProperty("HTMLCanvasElement", windowHTMLCanvasElementProtototype, ScriptableObject.DONTENUM);

            PrototypeFunctionDelegate windowHTMLImageElementProtototype = new PrototypeFunctionDelegate("HTMLImageElement", this);
            windowHTMLImageElementProtototype.multiversalClassType = IMutilversalObjectType.HTMLImageElement;
            windowHTMLImageElementProtototype.hasGeneralNodeConstatVariables = true;
            ___Multiversal.registerPrototypeObject(windowHTMLImageElementProtototype);
            this.defineProperty("HTMLImageElement", windowHTMLImageElementProtototype, ScriptableObject.DONTENUM);

            PrototypeFunctionDelegate windowHTMLDivElementProtototype = new PrototypeFunctionDelegate("HTMLDivElement", this);
            windowHTMLDivElementProtototype.multiversalClassType = IMutilversalObjectType.HTMLDivElement;
            windowHTMLDivElementProtototype.hasGeneralNodeConstatVariables = true;
            ___Multiversal.registerPrototypeObject(windowHTMLDivElementProtototype);
            this.defineProperty("HTMLDivElement", windowHTMLDivElementProtototype, ScriptableObject.DONTENUM);

            PrototypeFunctionDelegate windowHTMLSpanElementProtototype = new PrototypeFunctionDelegate("HTMLSpanElement", this);
            windowHTMLSpanElementProtototype.multiversalClassType = IMutilversalObjectType.HTMLSpanElement;
            windowHTMLSpanElementProtototype.hasGeneralNodeConstatVariables = true;
            ___Multiversal.registerPrototypeObject(windowHTMLSpanElementProtototype);
            this.defineProperty("HTMLSpanElement", windowHTMLSpanElementProtototype, ScriptableObject.DONTENUM);


            PrototypeFunctionDelegate windowHTMLFormElementProtototype = new PrototypeFunctionDelegate("HTMLFormElement", this);
            windowHTMLFormElementProtototype.multiversalClassType = IMutilversalObjectType.HTMLFormElement;
            windowHTMLFormElementProtototype.hasGeneralNodeConstatVariables = true;
            ___Multiversal.registerPrototypeObject(windowHTMLFormElementProtototype);
            this.defineProperty("HTMLFormElement", windowHTMLFormElementProtototype, ScriptableObject.DONTENUM);

            PrototypeFunctionDelegate windowHTMLOptionElementProtototype = new PrototypeFunctionDelegate("HTMLOptionElement", this);
            windowHTMLOptionElementProtototype.multiversalClassType = IMutilversalObjectType.HTMLOptionElement;
            windowHTMLOptionElementProtototype.hasGeneralNodeConstatVariables = true;
            ___Multiversal.registerPrototypeObject(windowHTMLOptionElementProtototype);
            this.defineProperty("HTMLOptionElement", windowHTMLOptionElementProtototype, ScriptableObject.DONTENUM);

            PrototypeFunctionDelegate windowHTMLOptGroupElementProtototype = new PrototypeFunctionDelegate("HTMLOptGroupElement", this);
            windowHTMLOptGroupElementProtototype.multiversalClassType = IMutilversalObjectType.HTMLOptGroupElement;
            windowHTMLOptGroupElementProtototype.hasGeneralNodeConstatVariables = true;
            ___Multiversal.registerPrototypeObject(windowHTMLOptGroupElementProtototype);
            this.defineProperty("HTMLOptGroupElement", windowHTMLOptGroupElementProtototype, ScriptableObject.DONTENUM);

            PrototypeFunctionDelegate windowHTMLSourceElementProtototype = new PrototypeFunctionDelegate("HTMLSourceElement", this);
            windowHTMLSourceElementProtototype.multiversalClassType = IMutilversalObjectType.HTMLSourceElement;
            windowHTMLSourceElementProtototype.hasGeneralNodeConstatVariables = true;
            ___Multiversal.registerPrototypeObject(windowHTMLSourceElementProtototype);
            this.defineProperty("HTMLSourceElement", windowHTMLSourceElementProtototype, ScriptableObject.DONTENUM);

            PrototypeFunctionDelegate windowHTMLButtonElementProtototype = new PrototypeFunctionDelegate("HTMLButtonElement", this);
            windowHTMLButtonElementProtototype.multiversalClassType = IMutilversalObjectType.HTMLButtonElement;
            windowHTMLButtonElementProtototype.hasGeneralNodeConstatVariables = true;
            ___Multiversal.registerPrototypeObject(windowHTMLButtonElementProtototype);
            this.defineProperty("HTMLButtonElement", windowHTMLButtonElementProtototype, ScriptableObject.DONTENUM);

            PrototypeFunctionDelegate windowHTMLSelectElementProtototype = new PrototypeFunctionDelegate("HTMLSelectElement", this);
            windowHTMLSelectElementProtototype.multiversalClassType = IMutilversalObjectType.HTMLSelectElement;
            windowHTMLSelectElementProtototype.hasGeneralNodeConstatVariables = true;
            ___Multiversal.registerPrototypeObject(windowHTMLSelectElementProtototype);
            this.defineProperty("HTMLSelectElement", windowHTMLSelectElementProtototype, ScriptableObject.DONTENUM);

            PrototypeFunctionDelegate windowHTMLIFrameElementProtototype = new PrototypeFunctionDelegate("HTMLIFrameElement", this);
            windowHTMLIFrameElementProtototype.multiversalClassType = IMutilversalObjectType.HTMLIFrameElement;
            windowHTMLIFrameElementProtototype.hasGeneralNodeConstatVariables = true;
            ___Multiversal.registerPrototypeObject(windowHTMLIFrameElementProtototype);
            this.defineProperty("HTMLIFrameElement", windowHTMLIFrameElementProtototype, ScriptableObject.DONTENUM);

            PrototypeFunctionDelegate windowHTMLFrameElementProtototype = new PrototypeFunctionDelegate("HTMLFrameElement", this);
            windowHTMLFrameElementProtototype.multiversalClassType = IMutilversalObjectType.HTMLFrameElement;
            windowHTMLFrameElementProtototype.hasGeneralNodeConstatVariables = true;
            ___Multiversal.registerPrototypeObject(windowHTMLFrameElementProtototype);
            this.defineProperty("HTMLFrameElement", windowHTMLFrameElementProtototype, ScriptableObject.DONTENUM);

            PrototypeFunctionDelegate windowHTMLLinkElementProtototype = new PrototypeFunctionDelegate("HTMLLinkElement", this);
            windowHTMLLinkElementProtototype.multiversalClassType = IMutilversalObjectType.HTMLLinkElement;
            windowHTMLLinkElementProtototype.hasGeneralNodeConstatVariables = true;
            ___Multiversal.registerPrototypeObject(windowHTMLLinkElementProtototype);
            this.defineProperty("HTMLLinkElement", windowHTMLLinkElementProtototype, ScriptableObject.DONTENUM);

            PrototypeFunctionDelegate windowHTMLAnchorElementProtototype = new PrototypeFunctionDelegate("HTMLAnchorElement", this);
            windowHTMLAnchorElementProtototype.multiversalClassType = IMutilversalObjectType.HTMLAnchorElement;
            windowHTMLAnchorElementProtototype.hasGeneralNodeConstatVariables = true;
            ___Multiversal.registerPrototypeObject(windowHTMLAnchorElementProtototype);
            this.defineProperty("HTMLAnchorElement", windowHTMLAnchorElementProtototype, ScriptableObject.DONTENUM);

            PrototypeFunctionDelegate windowHTMLStyleElementProtototype = new PrototypeFunctionDelegate("HTMLStyleElement", this);
            windowHTMLStyleElementProtototype.multiversalClassType = IMutilversalObjectType.HTMLStyleElement;
            windowHTMLStyleElementProtototype.hasGeneralNodeConstatVariables = true;
            ___Multiversal.registerPrototypeObject(windowHTMLStyleElementProtototype);
            this.defineProperty("HTMLStyleElement", windowHTMLStyleElementProtototype, ScriptableObject.DONTENUM);

            PrototypeFunctionDelegate windowHTMLScriptElementProtototype = new PrototypeFunctionDelegate("HTMLScriptElement", this);
            windowHTMLScriptElementProtototype.multiversalClassType = IMutilversalObjectType.HTMLScriptElement;
            windowHTMLScriptElementProtototype.hasGeneralNodeConstatVariables = true;
            ___Multiversal.registerPrototypeObject(windowHTMLScriptElementProtototype);
            this.defineProperty("HTMLScriptElement", windowHTMLScriptElementProtototype, ScriptableObject.DONTENUM);



            PrototypeFunctionDelegate windowHTMLTemplateElementProtototype = new PrototypeFunctionDelegate("HTMLTemplateElement", this);
            windowHTMLTemplateElementProtototype.multiversalClassType = IMutilversalObjectType.HTMLTemplateElement;
            windowHTMLTemplateElementProtototype.hasGeneralNodeConstatVariables = true;
            ___Multiversal.registerPrototypeObject(windowHTMLTemplateElementProtototype);
            this.defineProperty("HTMLTemplateElement", windowHTMLTemplateElementProtototype, ScriptableObject.DONTENUM);

            PrototypeFunctionDelegate windowHTMLObjectElementProtototype = new PrototypeFunctionDelegate("HTMLObjectElement", this);
            windowHTMLObjectElementProtototype.multiversalClassType = IMutilversalObjectType.HTMLObjectElement;
            windowHTMLObjectElementProtototype.hasGeneralNodeConstatVariables = true;
            ___Multiversal.registerPrototypeObject(windowHTMLObjectElementProtototype);
            this.defineProperty("HTMLObjectElement", windowHTMLObjectElementProtototype, ScriptableObject.DONTENUM);

            PrototypeFunctionDelegate windowHTMLTableElementProtototype = new PrototypeFunctionDelegate("HTMLTableElement", this);
            windowHTMLTableElementProtototype.multiversalClassType = IMutilversalObjectType.HTMLTableElement;
            windowHTMLTableElementProtototype.hasGeneralNodeConstatVariables = true;
            ___Multiversal.registerPrototypeObject(windowHTMLTableElementProtototype);
            this.defineProperty("HTMLTableElement", windowHTMLTableElementProtototype, ScriptableObject.DONTENUM);

            PrototypeFunctionDelegate windowHTMLTableRowElementProtototype = new PrototypeFunctionDelegate("HTMLTableRowElement", this);
            windowHTMLTableRowElementProtototype.multiversalClassType = IMutilversalObjectType.HTMLTableRowElement;
            windowHTMLTableRowElementProtototype.hasGeneralNodeConstatVariables = true;
            ___Multiversal.registerPrototypeObject(windowHTMLTableRowElementProtototype);
            this.defineProperty("HTMLTableRowElement", windowHTMLTableRowElementProtototype, ScriptableObject.DONTENUM);

            PrototypeFunctionDelegate windowHTMLTableColElementProtototype = new PrototypeFunctionDelegate("HTMLTableColElement", this);
            windowHTMLTableColElementProtototype.multiversalClassType = IMutilversalObjectType.HTMLTableColElement;
            windowHTMLTableColElementProtototype.hasGeneralNodeConstatVariables = true;
            ___Multiversal.registerPrototypeObject(windowHTMLTableColElementProtototype);
            this.defineProperty("HTMLTableColElement", windowHTMLTableColElementProtototype, ScriptableObject.DONTENUM);

            PrototypeFunctionDelegate windowHTMLTableCellElementProtototype = new PrototypeFunctionDelegate("HTMLTableCellElement", this);
            windowHTMLTableCellElementProtototype.multiversalClassType = IMutilversalObjectType.HTMLTableCellElement;
            windowHTMLTableCellElementProtototype.hasGeneralNodeConstatVariables = true;
            ___Multiversal.registerPrototypeObject(windowHTMLTableCellElementProtototype);
            this.defineProperty("HTMLTableCellElement", windowHTMLTableCellElementProtototype, ScriptableObject.DONTENUM);

            PrototypeFunctionDelegate windowHTMLTableSectionElementProtototype = new PrototypeFunctionDelegate("HTMLTableSectionElement", this);
            windowHTMLTableSectionElementProtototype.multiversalClassType = IMutilversalObjectType.HTMLTableSectionElement;
            windowHTMLTableSectionElementProtototype.hasGeneralNodeConstatVariables = true;
            ___Multiversal.registerPrototypeObject(windowHTMLTableSectionElementProtototype);
            this.defineProperty("HTMLTableSectionElement", windowHTMLTableSectionElementProtototype, ScriptableObject.DONTENUM);

            PrototypeFunctionDelegate windowHTMLTextAreaElementProtototype = new PrototypeFunctionDelegate("HTMLTextAreaElement", this);
            windowHTMLTextAreaElementProtototype.multiversalClassType = IMutilversalObjectType.HTMLTextAreaElement;
            windowHTMLTextAreaElementProtototype.hasGeneralNodeConstatVariables = true;
            ___Multiversal.registerPrototypeObject(windowHTMLTextAreaElementProtototype);
            this.defineProperty("HTMLTextAreaElement", windowHTMLTextAreaElementProtototype, ScriptableObject.DONTENUM);

            PrototypeFunctionDelegate windowHTMLAreaElementProtototype = new PrototypeFunctionDelegate("HTMLAreaElement", this);
            windowHTMLAreaElementProtototype.multiversalClassType = IMutilversalObjectType.HTMLAreaElement;
            windowHTMLAreaElementProtototype.hasGeneralNodeConstatVariables = true;
            ___Multiversal.registerPrototypeObject(windowHTMLAreaElementProtototype);
            this.defineProperty("HTMLAreaElement", windowHTMLAreaElementProtototype, ScriptableObject.DONTENUM);


            PrototypeFunctionDelegate windowHTMLTextElementProtototype = new PrototypeFunctionDelegate("HTMLTextElement", this);
            windowHTMLTextElementProtototype.multiversalClassType = IMutilversalObjectType.HTMLTextElement;
            windowHTMLTextElementProtototype.hasGeneralNodeConstatVariables = true;
            ___Multiversal.registerPrototypeObject(windowHTMLTextElementProtototype);
            this.defineProperty("HTMLTextElement", windowHTMLTextElementProtototype, ScriptableObject.DONTENUM);

            PrototypeFunctionDelegate windowHTMLUListPrototype = new PrototypeFunctionDelegate("HTMLUListElement", this);
            windowHTMLUListPrototype.multiversalClassType = IMutilversalObjectType.HTMLUListElement;
            windowHTMLUListPrototype.hasGeneralNodeConstatVariables = true;
            ___Multiversal.registerPrototypeObject(windowHTMLUListPrototype);
            this.defineProperty("HTMLUListElement", windowHTMLUListPrototype, ScriptableObject.DONTENUM);

            PrototypeFunctionDelegate windowHTMLLIElementPrototype = new PrototypeFunctionDelegate("HTMLLIElement", this);
            windowHTMLLIElementPrototype.multiversalClassType = IMutilversalObjectType.HTMLLIElement;
            windowHTMLLIElementPrototype.hasGeneralNodeConstatVariables = true;
            ___Multiversal.registerPrototypeObject(windowHTMLLIElementPrototype);
            this.defineProperty("HTMLLIElement", windowHTMLLIElementPrototype, ScriptableObject.DONTENUM);

            PrototypeFunctionDelegate windowHTMLDataListElementPrototype = new PrototypeFunctionDelegate("HTMLDataListElement", this);
            windowHTMLDataListElementPrototype.multiversalClassType = IMutilversalObjectType.HTMLDataListElement;
            windowHTMLDataListElementPrototype.hasGeneralNodeConstatVariables = true;
            ___Multiversal.registerPrototypeObject(windowHTMLDataListElementPrototype);
            this.defineProperty("HTMLDatalistElement", windowHTMLDataListElementPrototype, ScriptableObject.DONTENUM);

            PrototypeFunctionDelegate windowSVGElementPrototype = new PrototypeFunctionDelegate("SVGElement", this);
            windowSVGElementPrototype.multiversalClassType = IMutilversalObjectType.SVGElement;
            windowSVGElementPrototype.hasGeneralNodeConstatVariables = true;
            ___Multiversal.registerPrototypeObject(windowSVGElementPrototype);
            this.defineProperty("SVGElement", windowSVGElementPrototype, ScriptableObject.DONTENUM);
        }

            DateTime dtStart = DateTime.Now;
            int ____PropertyDefinedCount = 0;

            if (___IsFirstRun == false && CompiledOnFunctionList.Count > 0)
            {
                if (System.Threading.Monitor.TryEnter(this.___ScopeLockingObject, 5000))
                {
                    try
                    {
                        for (int fpos = CompiledOnFunctionList.Count - 1; fpos >= 0; fpos--)
                        {
                            org.mozilla.javascript.Script __compiledScript = CompiledOnFunctionList.Values[fpos];
                            if (__compiledScript != null)
                            {
                                __compiledScript.exec(con, this);
                                ____PropertyDefinedCount++;
                            }
                        }
                    }
                    finally
                    {
                        System.Threading.Monitor.Exit(this.___ScopeLockingObject);
                    }

                }
            }
            else
            {
                object ___objLock = new object();
                if (System.Threading.Monitor.TryEnter(___objLock, 10000))
                {
                    try
                    {
                        string strDefScript = null;
                        foreach (string ___strKey in ___WindowOnFunctionNamedList.Keys)
                        {
                            try
                            {
                                //================================================
                                // history.js has problem if we use object.defineProperty in normal way.
                                // onhashchange, and onpopstate should be handled in the way above.
                                // ===============================================
                                if ( string.Equals(___strKey, "onhashchange", StringComparison.Ordinal) == true || string.Equals(___strKey, "onpopstate", StringComparison.Ordinal) == true )
                                {
                                    /*
                                    if (base.has("onhashchange", this) == true)
                                    {
                                        base.getPrototype().delete(___strKey);
                                        this.delete(___strKey);
                                        if (base.has(___strKey, this) == true)
                                        {
                                            if (commonLog.LoggingEnabled)
                                            {
                                                commonLog.LogEntry("scope has already objtained onhashchange property....");
                                            }
                                        }
                                        object ___onhashchangeObject = base.get(___strKey);
                                        if (___onhashchangeObject != null)
                                        {
                                        }
                                        ScriptableObject ___onhashchangeScriptable = base.getOwnPropertyDescriptor(con,___strKey);
                                        if (___onhashchangeScriptable != null)
                                        {
                                            object __obj1 = base.getGetterOrSetter(___strKey, 0, false);
                                        }
                                     */
                                    continue;
                                    //strDefScript = ___createPropertyDefineScript(___strKey, true, true,true);

                                }
                                else
                                {

                                    strDefScript = ___createPropertyDefineScript(___strKey, true, true, true);
                                }
                                org.mozilla.javascript.Script ___defineScript = con.compileString(strDefScript, "", 1, null);
                                ___defineScript.exec(con, this);
                                CompiledOnFunctionList[___strKey] = ___defineScript;
                                ____PropertyDefinedCount++;
                                continue;
                            }
                            catch (Exception ex)
                            {
                                if (commonLog.LoggingEnabled)
                                {
                                    commonLog.LogEntry("[Crital ERROR!!!]___createStandadObjects()  define() Exception", ex);
                                }
                            }
                            continue;
                        }
                        // ====================================
                        // These functions has problem with 'history.js' saying 'cant modify readonly property'
                        // To workaround the issue, use just put in WindowOnFunctionNamesList.
                        // Cannot modify readonly property: onhashchange.LineNumber :326
                        //=====================================
                        //WindowOnFunctionNamesList["onhashchange"] = 1;
                        //WindowOnFunctionNamesList["onpopstate"] = 1;
                    }
                    finally
                    {
                        System.Threading.Monitor.Exit(___objLock);
                    }
                }
            }
            // ============================
            // RegExp Object will not load as object in Rhino
            // we want to load test to be load in order to this Scope has "RegExp" as Basic
            // object as primary object
            // ============================
            ___initRegExpAndTestHealty(con);
            if (commonLog.LoggingEnabled && commonLog.LogLevel >= 10)
            {
                TimeSpan tpSpan = DateTime.Now.Subtract(dtStart);
                commonLog.LogEntry("RhinoScope : " + ____PropertyDefinedCount.ToString() + " properties created. Took " + tpSpan.TotalMilliseconds.ToString() + " ms");
            }
            

            if (___PropertiesNeedsToBeBaseScope != null && ___isPropertiesNeedsToBeBaseScopeListInited == false)
            {
            
                ___PropertiesNeedsToBeBaseScope["ArrayBuffer"] = 1;
                ___PropertiesNeedsToBeBaseScope["Float32Array"] = 1;
                ___PropertiesNeedsToBeBaseScope["Float64Array"] = 1;
                ___PropertiesNeedsToBeBaseScope["Int8Array"] = 1;
                ___PropertiesNeedsToBeBaseScope["Int16Array"] = 1;
                ___PropertiesNeedsToBeBaseScope["Int32Array"] = 1;
                ___PropertiesNeedsToBeBaseScope["Uint8Array"] = 1;
                ___PropertiesNeedsToBeBaseScope["Uint16Array"] = 1;
                ___PropertiesNeedsToBeBaseScope["Uint32Array"] = 1;
                ___PropertiesNeedsToBeBaseScope["Uint8ClampedArray"] = 1;
            }
            ___isPropertiesNeedsToBeBaseScopeListInited = true;
            this.___hasInitializeCompleted = true;
         
            

           
             



            Context.exit();
        }

        /// <summary>
        /// Clear Standard Objects in this script processor
        /// </summary>
        public void ___disposeScriptEngine()
        {
            if (commonLog.LoggingEnabled)
            {
                commonLog.LogEntry("calling {0}.____clearStandardObjects()....", this);
            }
            object[] objIDS  = this.getIds();
            int _objIDSLen = objIDS.Length;
            for (int i = 0; i < _objIDSLen; i++)
            {
                try
                {
                    base.delete(i);
                }
                catch
                {
                    if (commonLog.LoggingEnabled)
                    {
                        commonLog.LogEntry("calling {0}.delete({1}) failed....", this, objIDS[i]);
                    }
                }
            }
            this.___hasInitializeCompleted = false;

        }
        
        private void ___executeTestFunction(Context con)
        {
            try
            {
                if (commonLog.LoggingEnabled)
                {
                    commonLog.LogEntry("Executing Trial Scripts Now....");
                }
                string strScript = System.IO.File.ReadAllText(@"C:\inetpub\wwwroot\js\phaser.io.plain.js");
         
                org.mozilla.javascript.Script sc = con.compileString(strScript, "", 1, null);

                
            }
            catch (Exception ex)
            {
                if (commonLog.LoggingEnabled)
                {
                    commonLog.LogEntry("Executing Trial Scripts Failed...", ex);
                }
            }
        }
         

        private void ___initRegExpAndTestHealty(Context con)
        {
            bool ___isRegExpNativeCtorExists = false;
            bool ___isRegExpObjectCreatedSuccess = false;
            try
            {

                object objRegExpTest1 = base.get("RegExp");
                if (objRegExpTest1 != null)
                {
                    /// Orginal String Contrctor is "+		objRegExpTest1	{org.mozilla.javascript.regexp.NativeRegExpCtor@218f1f9}	object {org.mozilla.javascript.regexp.NativeRegExpCtor}

                    if (objRegExpTest1.GetType().FullName.IndexOf("NativeRegExpCtor", StringComparison.Ordinal) > -1)
                    {
                        ___isRegExpNativeCtorExists = true;
                        goto InitRegExpPhase;
                    }
                    else
                    {
                        try
                        {
                            if (commonLog.LoggingEnabled)
                            {
                                commonLog.LogEntry("RegExp exists is not expected type delete one....");
                            }
                            base.delete("RegExp");
                        }
                        catch (Exception exDelRegExp)
                        {
                            if (commonLog.LoggingEnabled)
                            {
                                commonLog.LogEntry("RegExp Delete Exception....", exDelRegExp);
                            }
                        }
                    }
                InitRegExpPhase:
                    org.mozilla.javascript.Script __regExpScript = con.compileString("var regExpTest_1 = new RegExp('ab+c');", "", 1, null);
                    if (__regExpScript != null)
                    {
                        __regExpScript.exec(con, this);
                        ___isRegExpObjectCreatedSuccess = true;
                    }
                    this.delete("regExpTest_1");
                   
                }

            }
            catch (Exception exRegExInit)
            {
                if (commonLog.LoggingEnabled)
                {
                    commonLog.LogEntry("RegExp Init Exception....", exRegExInit);
                }
            }
            if (commonLog.LoggingEnabled)
            {
                commonLog.LogEntry("Rhino RegExp Init Test Complete NativeObject : {0} Test Script Success {1}", ___isRegExpNativeCtorExists, ___isRegExpObjectCreatedSuccess);
            }
        }
        public void ___relaseMultiversal()
        {
            ___Multiversal = null;
        }
        public string ___getMultivasalScopeName()
        {
            return "rhino.net";
        }
        public static IMultiversalScope ___constructorMultiversalScope(IMultiversalWindow multi)
        {
            RhinoMultiversalScope rhinoGlobal = null;

            rhinoGlobal = new RhinoMultiversalScope();

            rhinoGlobal.___Multiversal = multi;
            return rhinoGlobal;
        }
        
        
        public override void put(string ___name, Scriptable start, object value)
        {

            if (___hasInitializeCompleted == false)
            {
                base.put(___name, start, value);
                if (___isPropertiesNeedsToBeBaseScopeListInited == false)
                {
                    ___PropertiesNeedsToBeBaseScope[___name] = 1;
                }
            }
            else
            {
                if (commonLog.LoggingEnabled && commonLog.LogLevel >= 10)
                {

                    commonLog.LogEntry("enter RhinoMultervalScope put({0}, {1}, {2})....", ___name, start, value);

                }
                if (___PropertiesNeedsToBeBaseScope.ContainsKey(___name))
                {
                    base.put(___name, start, value);
                    return;
                }

                if (___WindowOnFunctionNamedList.ContainsKey(___name))
                {
                    // we expect all 'onhogehoge()' function should go through ___set_onfunction_property()
                    // but rhino may use put 
                    this.___Multiversal.___set_onfunction_property(___name, value);
                    return;
                }
                if (this.___Multiversal != null)
                {
                    this.___Multiversal.put(___name, value);
                }
                if (base.has(___name, start) == true)
                {
                    base.delete(___name);
                }
            }
        }

        public override void putConst(string ___name, Scriptable start, object value)
        {
            if (___hasInitializeCompleted == false)
            {
                
                base.putConst(___name, start, value);
            }
            else
            {
#if DEBUG
                if (commonLog.LoggingEnabled && commonLog.LogLevel >= 50)
                {
                    commonLog.LogEntry("enter RhinoMultervalScope defineConst({0}, {1}, {2})....", ___name, start, value);
                }
#endif
                
                if(___PropertiesNeedsToBeBaseScope.ContainsKey(___name))
                {
                        base.putConst(___name, start, value);
                        return;
                }
                 
                this.___Multiversal.put(___name, value);
                if (base.has(___name, start) == true)
                {
                    base.delete(___name);
                }
            }

        }
        /*
        public override int getAttributes(string name)
        {
            return base.getAttributes(name);
        }
         * */
        public override void defineProperty(string propertyName, java.lang.Class clazz, int attributes)
        {
            if (___hasInitializeCompleted == false)
            {
                base.defineProperty(propertyName, clazz, attributes);
            }
            else
            {
                base.defineProperty(propertyName, clazz, attributes);
            }
        }
        
        public override void setAttributes(string name, int attributes)
        {
            if (___hasInitializeCompleted == false)
            {
                base.setAttributes(name, attributes);
            }
            else
            {
                base.setAttributes(name, attributes);
            }
        }
        public override void delete(string name)
        {
            if (___hasInitializeCompleted == false)
            {
                base.delete(name);
            }
            else
            {
                this.___Multiversal.delete(name);
            }
        }
        public override void delete(int ___index)
        {
            if (___hasInitializeCompleted == false)
            {
                base.delete(___index);
            }
            else
            {
                this.___Multiversal.delete(___index);
            }
        }

        public override object get(int index, Scriptable start)
        {
            object ___result = base.get(index, start);
            if (___result is org.mozilla.javascript.Scriptable)
            {
                return ___result;
            }
            if (commonTypeConverter.IsUndefined(___result) || org.mozilla.javascript.UniqueTag.NOT_FOUND.equals(___result))
            {
                if (this.___Multiversal != null)
                {
                    object ___objMultiversal = this.___Multiversal.get(index);
                    if (___objMultiversal != null)
                    {

                        ___result = commonTypeConverter.ConvertCLRValueToJavaValue(___objMultiversal, start);
                    }
                }
            }
            return ___result;
        }
        public void ___setOptimizationLevel(int ___level)
        {
            commonTypeConverter.RhinoOptimizationLevel = ___level;
        }
        public override object get(string name, Scriptable start)
        {
            object ___result = null;
            bool ___isMultiversalLookuped = false;
            bool ___isObjectSeemsToSameToLastObject = false;
            try
            {
                /*
                if (string.IsNullOrEmpty(this.___LastMultivasalReturnedObjectName) == false && string.Equals(name, this.___LastMultivasalReturnedObjectName, StringComparison.Ordinal) == true)
                {
                    ___isObjectSeemsToSameToLastObject = true;
                    goto SecondPhase;
                }
                */
                if (commonLog.LoggingEnabled && commonLog.LogLevel >= 50)
                {
                    commonLog.LogEntry("calling RhinoMultervalScope get({0}, {1}....", name, start);
                }
                ___result = base.get(name, start);
                if (___result is org.mozilla.javascript.Scriptable)
                {
                    return ___result;
                }
            }
            catch (Exception exGET)
            {
                if (commonLog.LoggingEnabled && commonLog.LogLevel >= 1000)
                {
                    commonLog.LogEntry("ERROR! RhinoMultervalScope get({0}, {1}), but try cont....", name, start);
                    commonLog.LogEntry("Exception Detail ", exGET);
                   
                }
                ___result = org.mozilla.javascript.Undefined.instance;
            }
 
            if (this.___hasInitializeCompleted == true || (this.___Multiversal != null && this.___Multiversal.___getMultiversalWindowLevel() > 1))
            {
                ___isMultiversalLookuped = true;

                if (___result == null || org.mozilla.javascript.UniqueTag.NOT_FOUND.equals(___result) ||commonTypeConverter.IsUndefined(___result))
                {
                    if (___isObjectSeemsToSameToLastObject == true)
                    {
                        goto GetViaMultivalWindow;
                    }
                    switch (name)
                    {
                        case "window":
                            return this;
                        case "self":
                            return this;
                    }

                    if (___PropertiesNeedsToBeBaseScope.ContainsKey(name))
                    {
                        return ___result;
                    }
                    if (___WindowOnFunctionNamedList.ContainsKey(name))
                    {
                        object ____objResultFromMultiversalWindow = this.___Multiversal.___get_onfunction_property(name);
                        if (____objResultFromMultiversalWindow != null)
                        {
                           
                            ___result = ____objResultFromMultiversalWindow;
                        }
                        else
                        {
                            ___result = null;
                        }
                        goto ReturnPhase;
                    }
                GetViaMultivalWindow:
                    if (this.___Multiversal != null)
                    {
                        ___result  = this.___Multiversal.get(name);
                        if (___result != null)
                        {
                             
                            goto ReturnPhase;
                        }
                        /*
                        if (____objResultFromMultiversalWindow != null)
                        {
                            this.___LastMultivasalReturnedObjectName = string.Copy(name);
                            ___result = ____objResultFromMultiversalWindow;
                            goto ReturnPhase;
                        }
                        */

                    }
                }

                else if (___result == null)
                {
                    if (___WindowOnFunctionNamedList.ContainsKey(name))
                    {
                        object ____objResultFromMultiversalWindow = this.___Multiversal.___get_onfunction_property(name);
                        if (____objResultFromMultiversalWindow != null)
                        {
                            ___result = ____objResultFromMultiversalWindow;
                        }
                        else
                        {
                            ___result = null;
                        }
                        goto ReturnPhase;
                    }
                }
                 
            }

            // return this.______get(name);


            ReturnPhase:
            if (___result != null)
            {
                if (___isMultiversalLookuped == true)
                {

                    if (___result == null)
                    {
                        return org.mozilla.javascript.UniqueTag.NULL_VALUE;
                    }

                    else
                    {
                        ___result = commonTypeConverter.ConvertCLRValueToJavaValue(___result, start);
                    }
                }
            }

            return ___result;
        }



        public override object[] getIds()
        {
            object[] idArray;
            if (this.___hasInitializeCompleted == false)
            {
                idArray = base.getIds();
            }
            else
            {
                System.Collections.ArrayList resultArray = new System.Collections.ArrayList();
                // 1) First Get Multivasal Keys.
                resultArray.AddRange(base.getIds());
                // 2) GetBaseKeys
                resultArray.AddRange(this.___Multiversal.getIds());
                idArray = resultArray.ToArray();
            }
            return idArray;
        }
        public override void defineProperty(string propertyName, object value, int attributes)
        {
            if (this.___hasInitializeCompleted == false)
            {
                
                base.defineProperty(propertyName, value, attributes);
            }
            else
            {
                if (___PropertiesNeedsToBeBaseScope.ContainsKey(propertyName))
                {
                    base.defineProperty(propertyName, value, attributes);
                    return;
                }
                this.___Multiversal.put(propertyName, value);
            }
        }

 

        /// <summary>

        /// </summary>
        /// <param name="___name"></param>
        /// <param name="___value"></param>
        public object ___get_onfunction_property(string ___name)
        {
            if (this.___Multiversal != null)
            {
                return this.___Multiversal.___get_onfunction_property(___name);
            }
            return null;
        }

        /// <summary>

        /// </summary>
        /// <param name="___name"></param>
        /// <param name="___value"></param>
        public void ___set_onfunction_property(string ___name, object ___value)
        {
            if (this.___Multiversal != null)
            {
                this.___Multiversal.___set_onfunction_property(___name, ___value);
            }
        }

        public object ___get___onhashchange()
        {
            if (this.___Multiversal != null)
            {
                return this.___Multiversal.___get_onfunction_property("onhashchange");
            }
            return null;
        }
        public void ___set___onhashchange(object ___value)
        {
            if (this.___Multiversal != null)
            {
                this.___Multiversal.___set_onfunction_property("onhashchange", ___value);
            }
        }

        public object ___get___onpopstate()
        {
            if (this.___Multiversal != null)
            {
                return this.___Multiversal.___get_onfunction_property("onpopstate");
            }
            return null;
        }
        public void ___set___onpopstate(object ___value)
        {
            if (this.___Multiversal != null)
            {
                this.___Multiversal.___set_onfunction_property("onpopstate", ___value);
            }
        }

        
        public override bool has(string name, Scriptable start)
        {
            bool ___result = false;

            ___result = base.has(name, start);
            
           if (___result == false)
           {
               try
               {
                   if (this.___Multiversal != null)
                   {
                       ___result = this.___Multiversal.has(name);
                   }
               }
               catch (Exception ex)
               {
                   if (commonLog.LoggingEnabled)
                   {
                       commonLog.LogEntry("RhinoMultiversal exception on has() ", ex);
                   }
               }
           }

           return ___result;
        }
        
       


        private static string ___createPropertyDefineScript(string ___functionName, bool ___enumrable, bool ___configurable, bool ___writable)
        {

            // ====================================
            // note) Do not use writable attributes
            // it throws exception
            // =====================================
            if (___enumrable && ___configurable)
            {
                return string.Concat("Object.defineProperty(this,\r\n '", ___functionName, "', \r\n{  set : function(_bva_xd96843){this.___set_onfunction_property(\'" + ___functionName + "\', _bva_xd96843);},\r\n get : function(){return this.___get_onfunction_property(\'" + ___functionName + "\');}, enumerable: true, configurable: true});");
            }
            else if (___enumrable == true && ___configurable == false)
            {
                return string.Concat("Object.defineProperty(this,\r\n '", ___functionName, "', \r\n{  set : function(_bva_xd96843){this.___set_onfunction_property(\'" + ___functionName + "\', _bva_xd96843);},\r\n get : function(){return this.___get_onfunction_property(\'" + ___functionName + "\');}, enumerable: true, configurable: false});");
            }
            else if (___enumrable == false && ___configurable == true)
            {
                return string.Concat("Object.defineProperty(this,\r\n '", ___functionName, "', \r\n{  set : function(_bva_xd96843){this.___set_onfunction_property(\'" + ___functionName + "\', _bva_xd96843);},\r\n get : function(){return this.___get_onfunction_property(\'" + ___functionName + "\');}, enumerable: false, configurable: true});");
            }
            else
            {
                return string.Concat("Object.defineProperty(this,\r\n '", ___functionName, "', \r\n{  set : function(_bva_xd96843){this.___set_onfunction_property(\'" + ___functionName + "\', _bva_xd96843);},\r\n get : function(){return this.___get_onfunction_property(\'" + ___functionName + "\');}, enumerable: false, configurable: false});");
            }
        }

        public void ___setMultiversalWindow(IMultiversalWindow window)
        {
            this.___Multiversal = window;
        }
    }
}
