using System;
using System.Collections.Generic;
using System.Text;
using MultiversalRenderer.Interfaces;

namespace MultiversalRenderer.Interfaces
{


    public interface IMultiversalWindow
    {
        /// <summary>
        /// Retuns Multiversal Window Level
        /// </summary>
        /// <returns></returns>
        int ___getMultiversalWindowLevel();
        bool has(string ___name);
        bool has(int ___index);
        object get(string ___name);
        object get(int ___index);
        void put(string ___name, Object ___val);
        void put(int ___index, Object ___val);
        object[] getIds();
        void delete(string ___name);
        void delete(int ___index);
        IMultiversalScope getMultiversalScopeByName(string __name);
        IMultiversalScope getMultiversalScopeByScriptType(string ___type);
        /// <summary>
        /// Some types are script engine specific type( such as org.mozilla.javascript.Constring).
        /// In order to allow multiversal window to handle conversion, pre-register the type using this method
        /// </summary>
        /// <param name="___convertingType">Script Engine Specific Type</param>
        /// <param name="___returnType">Return Type</param>
        /// <param name="___delegate">delegate for conversion function</param>
        void registerTypeConvertDelegate(Type ___convertingType, Type ___returnType, Delegate ___delegate);
        /// <summary>
        /// Child Nodes Nodes Weak Reference
        /// </summary>
        System.Collections.Generic.Dictionary<int, System.WeakReference> childMultiversalWindows
        {
            get;
        }
        void initializeMultiversalScopes(bool createStandardObjects);
        void registerPrototypeObject(IPrototypeFunction protofunction);
        /// <summary>
        /// IE and Chrome does not have return value
        /// </summary>
        /// <param name="args"></param>
        object addEventListener(Object[] args);
        /// <summary>
        /// IE and Chrome does not return value
        /// </summary>
        /// <param name="args"></param>
        object removeEventListener(Object[] args);
        object setTimeout(Object[] args);
        object setInterval(Object[] args);

        object clearInterval(Object[] args);
        object clearTimeout(Object[] args);

        object postMessage(Object[] args);

        object requestAnimationFrame(Object[] args);

        object cancelAnimationFrame(Object[] args);

        object captureEvents(Object[] args);

        object releaseEvents(Object[] args);


        object dispatchEvent(Object[] args);

        object alert(Object[] args);

        object confirm(Object[] args);

        object open(Object[] args);

        object navigate(Object[] args);

        object showModalDialog(Object[] args);

        object moveBy(Object[] args);

        object moveTo(Object[] args);


        object resizeBy(Object[] args);

        object resizeTo(Object[] args);

        object scroll(Object[] args);


        object scrollTo(Object[] args);

        object scrollBy(Object[] args);

        object close(Object[] args);

        object find(Object[] args);

        object focus(Object[] args);

        object blur(Object[] args);


        object print(Object[] args);

        object prompt(Object[] args);


        object stop(Object[] args);

        // ------------------------------
        // String Encode / Decode
        // -----------------------------

        object escape(Object[] args);

        object unescape(Object[] args);


        object encodeURIComponent(Object[] args);

        object decodeURIComponent(Object[] args);

        object decodeURI(Object[] args);

        object encodeURI(Object[] args);

        object atob(Object[] args);
        object btoa(Object[] args);

        void ___set_onfunction_property(string ___name, object ___func);
        object ___get_onfunction_property(string ___name);
        object ___createObject(string ___instanceName, params object[] args);
        object ___createAsActiveXObject(object[] args);
     
        int ___getScriptProcessorCount();
        object getComputedStyle(Object[] args);

        object matchMedia(object[] args);

        object requestFileSystem(object[] args);
        
     

    }
}

