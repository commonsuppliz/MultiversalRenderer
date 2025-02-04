using System;
using System.Collections.Generic;
using MultiversalRenderer.Interfaces;
using NiL.JS;
using NiL.JS.Core;
using NiL.JS.BaseLibrary;
using NiL.JS.Extensions;


using static System.Formats.Asn1.AsnWriter;
namespace NilJsProcessor
{
#pragma warning disable 618
    public class NilJsScope : IMultiversalScope
    {
        private IMultiversalWindow multiwindow = null;
        public NiL.JS.Core.Context context = null;
        public NiL.JS.Core.GlobalContext globalContext = null;
        private bool _isInitCompleted = false;
        private IMultiversalScriptProcessor processor = null;
        public IMultiversalScope constructorMultiversalScope(IMultiversalWindow multi)
        {
            multiwindow = multi;
            return this;
        }
        public NilJsScope() { }

        public void disposeScriptEngine()
        {
            context = null;
        }


        public string getMultivasalScopeName()
        {
            throw new NotImplementedException();
        }

        public string[] getMultiversalInvokeScriptNames()
        {
            throw new NotImplementedException();
        }

        public IMultiversalScriptProcessor getMultiversalScriptProcessor()
        {
            return processor;
        }

        public IMultiversalWindow getMultiversalWindow()
        {
            return multiwindow;
        }

        public IMultiversalWindowType getMutilversalWindowType()
        {
            throw new NotImplementedException();
        }

        public void initScriptEngine()
        {
            globalContext = new GlobalContext();
            globalContext.GlobalObjectsAssignMode = GlobalObjectsAssignMode.Allow;
            context = new NiL.JS.Core.Context();
            processor = new NilJsProcessor();
            processor.multiversalscope = this;



            _isInitCompleted = true;
        }

        public bool isDefaultMultiversalProcessor()
        {
            throw new NotImplementedException();
        }

        public bool isInitCompleted()
        {
            return _isInitCompleted;
        }

        public void relaseMultiversal()
        {
            multiwindow = null;
        }


        public void setMultiversalWindow(IMultiversalWindow window)
        {
            multiwindow = window;
            //globalContext = new GlobalContext();
            // globalContext.GlobalObjectsAssignMode = GlobalObjectsAssignMode.Allow;
            globalContext.DefineVariable("window").Assign(JSValue.Marshal(multiwindow));
            globalContext.DefineVariable("this").Assign(JSValue.Marshal(multiwindow));

            context.DefineVariable("window").Assign(JSValue.Marshal(multiwindow));



        }

        public void setMutilversalWindowType(IMultiversalWindowType windowType)
        {
            throw new NotImplementedException();
        }

        private static System.Collections.Generic.SortedList<string, ushort> createWindowFunctionSortedList()
        {
            System.Collections.Generic.SortedList<string, ushort> list = new SortedList<string, ushort>(StringComparer.Ordinal);
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
        const string getClassNameString = "object";
        public string getClasName()
        {
            return getClassNameString;
        }
        public void createStandardObjects()
        {
            context.DefineVariable("removeEventListener").Assign(new Func<dynamic, dynamic, dynamic, dynamic>((self, thisObj, args) =>
            {
                return multiwindow.removeEventListener(args);
            }));



            //this.defineProperty("removeEventListener", new BaseFunctionDelegate("removeEventListener", new BaseFunctionDelegate.Delegate4Object(this.Multiversal.removeEventListener)), ScriptableObject.PERMANENT);

            context.DefineVariable("addEventListener").Assign(new Func<dynamic, dynamic, dynamic, dynamic>((self, thisObj, args) =>
            {
                return multiwindow.addEventListener(args);
            }));
            //this.defineProperty("addEventListener", new BaseFunctionDelegate("addEventListener", new BaseFunctionDelegate.Delegate4Object(this.Multiversal.addEventListener)), ScriptableObject.PERMANENT);

            context.DefineVariable("attachEvent").Assign(new Func<dynamic, dynamic, dynamic, dynamic>((self, thisObj, args) =>
            {
                return multiwindow.addEventListener(args);
            }));

            //this.defineProperty("attachEvent", new BaseFunctionDelegate("attachEvent", new BaseFunctionDelegate.Delegate4Object(this.Multiversal.addEventListener)), ScriptableObject.PERMANENT);


            context.DefineVariable("detachEvent").Assign(new Func<dynamic, dynamic, dynamic, dynamic>((self, thisObj, args) =>
                {
                    return multiwindow.removeEventListener(args);
                }));

            //this.defineProperty("detachEvent", new BaseFunctionDelegate("detachEvent", new BaseFunctionDelegate.Delegate4Object(this.Multiversal.removeEventListener)), ScriptableObject.PERMANENT);

            context.DefineVariable("postMessage").Assign(new Func<dynamic, dynamic, dynamic, dynamic>((self, thisObj, args) =>
            {
                return multiwindow.postMessage(args);
            }));
            //BaseFunctionDelegate postMessageDelegate = new BaseFunctionDelegate("postMessage", new BaseFunctionDelegate.Delegate4Object(this.Multiversal.postMessage));




            //postMessageDelegate.requiresCallerWindowInformationToBeCalled = true;
            //postMessageDelegate.callerMultiversalWindowWeakReference = new WeakReference(this.Multiversal, false);
            //this.defineProperty("postMessage", postMessageDelegate, ScriptableObject.PERMANENT);

            context.DefineVariable("setTimeout").Assign(new Func<dynamic, dynamic, dynamic, dynamic>((self, thisObj, args) =>
            {
                return multiwindow.setTimeout(args);
            }));
            //this.defineProperty("setTimeout", new BaseFunctionDelegate("setTimeout", new BaseFunctionDelegate.Delegate4Object(this.Multiversal.setTimeout)), ScriptableObject.PERMANENT);

            context.DefineVariable("setInterval").Assign(new Func<dynamic, dynamic, dynamic, dynamic>((self, thisObj, args) =>
            {
                return multiwindow.setInterval(args);
            }));
            //this.defineProperty("setInterval", new BaseFunctionDelegate("setInterval", new BaseFunctionDelegate.Delegate4Object(this.Multiversal.setInterval)), ScriptableObject.PERMANENT);

            context.DefineVariable("clearInterval").Assign(new Func<dynamic, dynamic, dynamic, dynamic>((self, thisObj, args) =>
            {
                return multiwindow.clearInterval(args);
            }));

            //this.defineProperty("clearInterval", new BaseFunctionDelegate("clearInteval", new BaseFunctionDelegate.Delegate4Object(this.Multiversal.clearInterval)), ScriptableObject.PERMANENT);

            context.DefineVariable("clearTimeout").Assign(new Func<dynamic, dynamic, dynamic, dynamic>((self, thisObj, args) =>
            {
                return multiwindow.clearTimeout(args);
            }));

            //this.defineProperty("clearTimeout", new BaseFunctionDelegate("clearTimeout", new BaseFunctionDelegate.Delegate4Object(this.Multiversal.clearTimeout)), ScriptableObject.PERMANENT);

            context.DefineVariable("requestAnimationFrame").Assign(new Func<dynamic, dynamic, dynamic, dynamic>((self, thisObj, args) =>
            {
                return multiwindow.requestAnimationFrame(args);
            }));

            context.DefineVariable("cancelAnimationFrame").Assign(new Func<dynamic, dynamic, dynamic, dynamic>((self, thisObj, args) =>
            {
                return multiwindow.cancelAnimationFrame(args);
            }));
            context.DefineVariable("captureEvents").Assign(new Func<dynamic, dynamic, dynamic, dynamic>((self, thisObj, args) =>
            {
                return multiwindow.captureEvents(args);
            }));

            //this.defineProperty("captureEvents", new BaseFunctionDelegate("captureEvents", new BaseFunctionDelegate.Delegate4Object(this.Multiversal.captureEvents)), ScriptableObject.PERMANENT);

            context.DefineVariable("releaseEvents").Assign(new Func<dynamic, dynamic, dynamic, dynamic>((self, thisObj, args) =>
            {
                return multiwindow.releaseEvents(args);
            }));
            //this.defineProperty("releaseEvents", new BaseFunctionDelegate("releaseEvents", new BaseFunctionDelegate.Delegate4Object(this.Multiversal.releaseEvents)), ScriptableObject.PERMANENT);

            context.DefineVariable("dispatchEvent").Assign(new Func<dynamic, dynamic, dynamic, dynamic>((self, thisObj, args) =>
            {
                return multiwindow.dispatchEvent(args);
            }));
            //this.defineProperty("dispatchEvent", new BaseFunctionDelegate("dispatchEvent", new BaseFunctionDelegate.Delegate4Object(this.Multiversal.dispatchEvent)), ScriptableObject.PERMANENT);

            //BaseFunctionDelegate requestAnimationFrameDelegate = new BaseFunctionDelegate("requestAnimationFrame", new BaseFunctionDelegate.Delegate4Object(this.Multiversal.requestAnimationFrame));
            //this.defineProperty("requestAnimationFrame", requestAnimationFrameDelegate, ScriptableObject.PERMANENT);

            //this.defineProperty("oRequestAnimationFrame", requestAnimationFrameDelegate, ScriptableObject.PERMANENT);
            //this.defineProperty("msRequestAnimationFrame", requestAnimationFrameDelegate, ScriptableObject.PERMANENT);
            //this.defineProperty("cancelAnimationFrame", new BaseFunctionDelegate("cancelAnimationFrame", new BaseFunctionDelegate.Delegate4Object(this.Multiversal.cancelAnimationFrame)), ScriptableObject.PERMANENT);

            context.DefineVariable("open").Assign(new Func<dynamic, dynamic, dynamic, dynamic>((self, thisObj, args) =>
            {
                return multiwindow.open(args);
            }));

            context.DefineVariable("alert").Assign(new Func<dynamic, dynamic, dynamic, dynamic>((self, thisObj, args) =>
            {
                return multiwindow.alert(args);
            }));
            //this.defineProperty("open", new BaseFunctionDelegate("open", new BaseFunctionDelegate.Delegate4Object(this.Multiversal.open)), ScriptableObject.PERMANENT);

            context.DefineVariable("confirm").Assign(new Func<dynamic, dynamic, dynamic, dynamic>((self, thisObj, args) =>
            {
                return multiwindow.confirm(args);
            }));

            context.DefineVariable("navigate").Assign(new Func<dynamic, dynamic, dynamic, dynamic>((self, thisObj, args) =>
            {
                return multiwindow.navigate(args);
            }));

            context.DefineVariable("stop").Assign(new Func<dynamic, dynamic, dynamic, dynamic>((self, thisObj, args) =>
            {
                return multiwindow.stop(args);
            }));

            context.DefineVariable("close").Assign(new Func<dynamic, dynamic, dynamic, dynamic>((self, thisObj, args) =>
            {
                return multiwindow.close(args);
            }));

            context.DefineVariable("prompt").Assign(new Func<dynamic, dynamic, dynamic, dynamic>((self, thisObj, args) =>
            {
                return multiwindow.prompt(args);
            }));

            context.DefineVariable("print").Assign(new Func<dynamic, dynamic, dynamic, dynamic>((self, thisObj, args) =>
            {
                return multiwindow.print(args);
            }));

            context.DefineVariable("showModalDialog").Assign(new Func<dynamic, dynamic, dynamic, dynamic>((self, thisObj, args) =>
            {
                return multiwindow.showModalDialog(args);
            }));
            //this.defineProperty("confirm", new BaseFunctionDelegate("confirm", new BaseFunctionDelegate.Delegate4Object(this.Multiversal.confirm)), ScriptableObject.PERMANENT);

            //this.defineProperty("navigate", new BaseFunctionDelegate("navigate", new BaseFunctionDelegate.Delegate4Object(this.Multiversal.navigate)), ScriptableObject.PERMANENT);


            //this.defineProperty("stop", new BaseFunctionDelegate("stop", new BaseFunctionDelegate.Delegate4Object(this.Multiversal.stop)), ScriptableObject.PERMANENT);


            //this.defineProperty("close", new BaseFunctionDelegate("close", new BaseFunctionDelegate.Delegate4Object(this.Multiversal.close)), ScriptableObject.PERMANENT);

            //this.defineProperty("alert", new BaseFunctionDelegate("alert", new BaseFunctionDelegate.Delegate4Object(this.Multiversal.alert)), ScriptableObject.PERMANENT);
            //this.defineProperty("prompt", new BaseFunctionDelegate("prompt", new BaseFunctionDelegate.Delegate4Object(this.Multiversal.prompt)), ScriptableObject.PERMANENT);
            //this.defineProperty("print", new BaseFunctionDelegate("print", new BaseFunctionDelegate.Delegate4Object(this.Multiversal.print)), ScriptableObject.PERMANENT);

            //this.defineProperty("showModalDialog", new BaseFunctionDelegate("showModalDialog", new BaseFunctionDelegate.Delegate4Object(this.Multiversal.showModalDialog)), ScriptableObject.PERMANENT);

            //this.defineProperty("matchMedia", new BaseFunctionDelegate("matchMedia", new BaseFunctionDelegate.Delegate4Object(this.Multiversal.matchMedia)), ScriptableObject.PERMANENT);

            //this.defineProperty("msMatchMedia", new BaseFunctionDelegate("matchMedia", new BaseFunctionDelegate.Delegate4Object(this.Multiversal.matchMedia)), ScriptableObject.PERMANENT);

            //this.defineProperty("webkitMatchMedia", new BaseFunctionDelegate("matchMedia", new BaseFunctionDelegate.Delegate4Object(this.Multiversal.matchMedia)), ScriptableObject.PERMANENT);

            //this.defineProperty("mozMatchMedia", new BaseFunctionDelegate("matchMedia", new BaseFunctionDelegate.Delegate4Object(this.Multiversal.matchMedia)), ScriptableObject.PERMANENT);

            //this.defineProperty("blur", new BaseFunctionDelegate("blur", new BaseFunctionDelegate.Delegate4Object(this.Multiversal.blur)), ScriptableObject.PERMANENT);

            context.DefineVariable("focus").Assign(new Func<dynamic, dynamic, dynamic, dynamic>((self, thisObj, args) =>
            {
                return multiwindow.focus(args);
            }));

            context.DefineVariable("escape").Assign(new Func<dynamic, dynamic, dynamic, dynamic>((self, thisObj, args) =>
            {
                return multiwindow.escape(args);
            }));

            context.DefineVariable("unescape").Assign(new Func<dynamic, dynamic, dynamic, dynamic>((self, thisObj, args) =>
            {
                return multiwindow.unescape(args);
            }));

            //this.defineProperty("focus", new BaseFunctionDelegate("focus", new BaseFunctionDelegate.Delegate4Object(this.Multiversal.focus)), ScriptableObject.PERMANENT);

            //this.defineProperty("escape", new BaseFunctionDelegate("escape", new BaseFunctionDelegate.Delegate4Object(this.Multiversal.escape)), ScriptableObject.PERMANENT);

            //this.defineProperty("unescape", new BaseFunctionDelegate("unescape", new BaseFunctionDelegate.Delegate4Object(this.Multiversal.unescape)), ScriptableObject.PERMANENT);

            context.DefineVariable("encodeURI").Assign(new Func<dynamic, dynamic, dynamic, dynamic>((self, thisObj, args) =>
            {
                return multiwindow.encodeURI(args);
            }));

            context.DefineVariable("decodeURI").Assign(new Func<dynamic, dynamic, dynamic, dynamic>((self, thisObj, args) =>
            {
                return multiwindow.decodeURI(args);
            }));

            context.DefineVariable("encodeURIComponent").Assign(new Func<dynamic, dynamic, dynamic, dynamic>((self, thisObj, args) =>
            {
                return multiwindow.encodeURIComponent(args);
            }));

            context.DefineVariable("decodeURIComponent").Assign(new Func<dynamic, dynamic, dynamic, dynamic>((self, thisObj, args) =>
            {
                return multiwindow.decodeURIComponent(args);
            }));

            context.DefineVariable("atob").Assign(new Func<dynamic, dynamic, dynamic, dynamic>((self, thisObj, args) =>
            {
                return multiwindow.atob(args);
            }));

            context.DefineVariable("btoa").Assign(new Func<dynamic, dynamic, dynamic, dynamic>((self, thisObj, args) =>
            {
                return multiwindow.btoa(args);
            }));
            //this.defineProperty("getSelection", new BaseFunctionDelegate("getSelection", new BaseFunctionDelegate.Delegate4Object(this.Multiversal.getSelection)), ScriptableObject.PERMANENT);
            //this.defineProperty("encodeURI", new BaseFunctionDelegate("encodeURI", new BaseFunctionDelegate.Delegate4Object(this.Multiversal.encodeURI)), ScriptableObject.PERMANENT);
            //this.defineProperty("decodeURI", new BaseFunctionDelegate("decodeURI", new BaseFunctionDelegate.Delegate4Object(this.Multiversal.decodeURI)), ScriptableObject.PERMANENT);
            //this.defineProperty("encodeURIComponent", new BaseFunctionDelegate("encodeURIComponent", new BaseFunctionDelegate.Delegate4Object(this.Multiversal.encodeURIComponent)), ScriptableObject.PERMANENT);
            //this.defineProperty("decodeURIComponent", new BaseFunctionDelegate("decodeURIComponent", new BaseFunctionDelegate.Delegate4Object(this.Multiversal.decodeURIComponent)), ScriptableObject.PERMANENT);
            //this.defineProperty("atob", new BaseFunctionDelegate("atob", new BaseFunctionDelegate.Delegate4Object(this.Multiversal.atob)), ScriptableObject.PERMANENT);
            //this.defineProperty("btoa", new BaseFunctionDelegate("btoa", new BaseFunctionDelegate.Delegate4Object(this.Multiversal.btoa)), ScriptableObject.PERMANENT);

            context.DefineVariable("find").Assign(new Func<dynamic, dynamic, dynamic, dynamic>((self, thisObj, args) =>
            {
                return multiwindow.find(args);
            }));
            context.DefineVariable("scroll").Assign(new Func<dynamic, dynamic, dynamic, dynamic>((self, thisObj, args) =>
            {
                return multiwindow.scroll(args);
            }));

            context.DefineVariable("scrollTo").Assign(new Func<dynamic, dynamic, dynamic, dynamic>((self, thisObj, args) =>
            {
                return multiwindow.scrollTo(args);
            }));    

            context.DefineVariable("scrollBy").Assign(new Func<dynamic, dynamic, dynamic, dynamic>((self, thisObj, args) =>
            {
                return multiwindow.scrollBy(args);
            }));

            context.DefineVariable("moveTo").Assign(new Func<dynamic, dynamic, dynamic, dynamic>((self, thisObj, args) =>
            {
                return multiwindow.moveTo(args);
            }));


            context.DefineVariable("moveBy").Assign(new Func<dynamic, dynamic, dynamic, dynamic>((self, thisObj, args) =>
            {
                return multiwindow.moveBy(args);
            }));

            context.DefineVariable("resizeTo").Assign(new Func<dynamic, dynamic, dynamic, dynamic>((self, thisObj, args) =>
            {
                return multiwindow.resizeTo(args);
            }));

            context.DefineVariable("resizeBy").Assign(new Func<dynamic, dynamic, dynamic, dynamic>((self, thisObj, args) =>
            {
                return multiwindow.resizeBy(args);
            }));

            context.DefineVariable("getComputedStyle").Assign(new Func<dynamic, dynamic, dynamic, dynamic>((self, thisObj, args) =>
            {
                return multiwindow.getComputedStyle(args);
            }));

            context.DefineVariable("requestFileSystem").Assign(new Func<dynamic, dynamic, dynamic, dynamic>((self, thisObj, args) =>
            {
                return multiwindow.requestFileSystem(args);
            }));

            //this.defineProperty("resizeTo", new BaseFunctionDelegate("resizeTo", new BaseFunctionDelegate.Delegate4Object(this.Multiversal.resizeTo)), ScriptableObject.PERMANENT);


            //this.defineProperty("resizeBy", new BaseFunctionDelegate("resizeBy", new BaseFunctionDelegate.Delegate4Object(this.Multiversal.resizeBy)), ScriptableObject.PERMANENT);


            //this.defineProperty("scrollTo", new BaseFunctionDelegate("scrollTo", new BaseFunctionDelegate.Delegate4Object(this.Multiversal.scrollTo)), ScriptableObject.PERMANENT);
            //this.defineProperty("scroll", new BaseFunctionDelegate("scroll", new BaseFunctionDelegate.Delegate4Object(this.Multiversal.scroll)), ScriptableObject.PERMANENT);

            //this.defineProperty("scrollBy", new BaseFunctionDelegate("scrollBy", new BaseFunctionDelegate.Delegate4Object(this.Multiversal.scrollBy)), ScriptableObject.PERMANENT);

            //this.defineProperty("moveTo", new BaseFunctionDelegate("moveTo", new BaseFunctionDelegate.Delegate4Object(this.Multiversal.moveTo)), ScriptableObject.PERMANENT);

            //this.defineProperty("moveBy", new BaseFunctionDelegate("moveBy", new BaseFunctionDelegate.Delegate4Object(this.Multiversal.moveBy)), ScriptableObject.PERMANENT);

            //this.defineProperty("getComputedStyle", new BaseFunctionDelegate("getComputedStyle", new BaseFunctionDelegate.Delegate4Object(this.Multiversal.getComputedStyle)), ScriptableObject.PERMANENT);

            //this.defineProperty("requestFileSystem", new BaseFunctionDelegate("requestFileSystem", new BaseFunctionDelegate.Delegate4Object(this.Multiversal.requestFileSystem)), ScriptableObject.PERMANENT);
            //PrototypeFunctionDelegate imageDelegate = new PrototypeFunctionDelegate("Image", this);
            //imageDelegate.multiversalClassType = IMutilversalObjectType.Image;
            //Multiversal.registerPrototypeObject(imageDelegate);
            //this.defineProperty("Image", imageDelegate, ScriptableObject.PERMANENT);

            //PrototypeFunctionDelegate audioDelegate = new PrototypeFunctionDelegate("Audio", this);
            //audioDelegate.multiversalClassType = IMutilversalObjectType.HTMLAudioElement;
            //Multiversal.registerPrototypeObject(audioDelegate);
            //this.defineProperty("Audio", audioDelegate, ScriptableObject.PERMANENT);

            //PrototypeFunctionDelegate videoDelegate = new PrototypeFunctionDelegate("Video", this);
            //videoDelegate.multiversalClassType = IMutilversalObjectType.HTMLVideoElement;
            //Multiversal.registerPrototypeObject(videoDelegate);
            //this.defineProperty("Video", videoDelegate, ScriptableObject.PERMANENT);




            //PrototypeFunctionDelegate workerDelegate = new PrototypeFunctionDelegate("Worker", this);
            //workerDelegate.multiversalClassType = IMutilversalObjectType.Worker;
            //Multiversal.registerPrototypeObject(workerDelegate);
            //this.defineProperty("Worker", workerDelegate, ScriptableObject.PERMANENT);

            //PrototypeFunctionDelegate sharedworkerDelegate = new PrototypeFunctionDelegate("SharedWorker", this);
            //sharedworkerDelegate.multiversalClassType = IMutilversalObjectType.SharedWorker;
            //Multiversal.registerPrototypeObject(sharedworkerDelegate);
            //this.defineProperty("SharedWorker", sharedworkerDelegate, ScriptableObject.PERMANENT);


            //PrototypeFunctionDelegate xmlhttpReqeustDelegate = new PrototypeFunctionDelegate("XMLHttpRequest", this);
            //xmlhttpReqeustDelegate.multiversalClassType = IMutilversalObjectType.XMLHttpRequest;
            //Multiversal.registerPrototypeObject(xmlhttpReqeustDelegate);
            //this.defineProperty("XMLHttpRequest", xmlhttpReqeustDelegate, ScriptableObject.PERMANENT);

            // CHtmlMultiversalRootNode definitions

          





        }
    }
}
