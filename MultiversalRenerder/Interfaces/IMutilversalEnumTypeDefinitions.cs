﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MultiversalRenderer.Interfaces
{
    public enum IMultiversalWindowType
    {
        Unknown = -1,
        NormalWindow = 1,
        WorkerWindow = 10,
        Generic = 100000,
    }
    public enum IMutilversalObjectType : ushort
    {
        Unkown,
        Object,
        Node,
        Boolean,
        Array,
        ArrayBuffer,
        Int8Array,
        Int16Array,
        Int32Array,
        Int64Array,
        Uint8Array,
        Uint16Array,
        Uint32Array,
        Float32Array,
        Float64Array,
        TypedArray,
        Date,
        Function,
        RegExp,
        #region W3CRelated
        #region Major Object
        HTMLDocument,
        HTMLCollection,
        Crypto,
        CryptoOperation,
        CryptoSubtle,
        Attr,
        Storage,
        ApplicationCache,
        ApplicationCacheErrorEvent,
        Document,
        DocumentType,
        DocumentFragment,
        TextRectangle,
        DOMTokenList,
        DOMError,
        DOMException,
        DOMParser,
        DOMSettableTokenList,
        DOMStringList,
        DOMStringMap,
        Blob,
        URL,
        Touch,
        TouchEvent,
        TouchList,
        BatteryManager,
        XMLHttpRequest,
        XMLDocument,
        XMLHttpRequestUpload,
        XMLSerializer,
        XPathResult,
        XPathExpression,
        XPathEvaluator,
        NodeList,
        Window,
        Location,
        Worker,
        SharedWorker,
        Console,
        CustomEvent,
        KeyboardEvent,
        Event,
        MouseEvent,
        EventSource,
        EventTarget,
        File,
        FileList,
        FileError,
        FileReader,
        ActiveXObject,
        XDomainRequest,
        GainNode,
        Gamepad,
        GamepadEvent,
        Image,
        ImageBitmap,
        ImageData,
        IDBFactory,
        IDBIndex,
        IDBObjectStore,
        History,
        Navigator,
        Screen,
        Range,
        RangeError,
        Promise,
        Plugin,
        PluginArray,
        MimeTypeArray,
        TimeRanges,
        Performance,
        PerformanceEntry,
        PerformanceNavigation,
        PerformanceTiming,
        ProgressEvent,
        Path2D,
        Clipboard,
        CDATASection,
        CSS,
        CSSFontFaceRule,
        CSSRule,
        CSSMediaRule,
        CSSRuleList,
        CSSStyleDeclaration,
        CSSUnknownRule,
        CSSViewportRule,
        CSSStyleSheet,
        MediaList,
        MediaQueryList,
        Text, // for #Text
        #endregion
        Element,
        HTMLElement,
        HTMLHtmlElement,
        HTMLHeadElement,
        HTMLBodyElement,
        HTMLInputElement,
        HTMLFormElement,
        HTMLDivElement,
        HTMLAnchorElement,
        HTMLAppletElement,
        HTMLAreaElement,
        HTMLBaseElement,
        HTMLBaseFontElement,
        HTMLBRElement,
        HTMLButtonElement,
        HTMLDirectoryElement,
        HTMLDListElement,
        HTMLFieldSetElement,
        HTMLFontElement,
        HTMLFrameElement,
        HTMLFrameSetElement,
        HTMLHeadingElement,
        HTMLHRElement,
        HTMLIFrameElement,
        HTMLImageElement,
        HTMLIsIndexElement,
        HTMLLabelElement,
        HTMLLegendElement,
        HTMLSpanElement,
        HTMLLIElement,
        HTMLLinkElement,
        HTMLMapElement,
        HTMLMenuElement,
        HTMLMetaElement,
        HTMLModElement,
        HTMLObjectElement,
        HTMLOListElement,
        HTMLOptGroupElement,
        HTMLOptionElement,
        HTMLParagraphElement,
        HTMLParamElement,
        HTMLPictureElement,
        HTMLPreElement,
        HTMLQuoteElement,
        HTMLScriptElement,
        HTMLSelectElement,
        HTMLStyleElement,
        HTMLTableCaptionElement,
        HTMLTableCellElement,
        HTMLCanvasElement,
        HTMLAudioElement,
        HTMLVideoElement,
        HTMLTableColElement,
        HTMLTableElement,
        HTMLTableRowElement,
        HTMLTemplateElement,
        HTMLEmbedElement,
        HTMLTableSectionElement,
        HTMLTextAreaElement,
        HTMLTitleElement,
        HTMLDataListElement,
        HTMLUListElement,
        HTMLSourceElement,
        HTMLTextElement,
        HTMLTrackElement,
        HTMLDetailsElement,
        HTMLUnknownElement,
        NamedNodeMap,
        ScreenOrientation,
        #endregion
        #region SVG
        SVGElement,
        SVGAngle,
        SVGAnimateColorElement,
        SVGAnimateElement,
        SVGAnimateMotionElement,
        SVGAnimateTransformElement,
        SVGAnimatedAngle,
        SVGAnimatedBoolean,
        SVGAnimatedEnumeration,
        SVGAnimatedInteger,
        SVGAnimatedLength,
        SVGAnimatedLengthList,
        SVGAnimatedNumber,
        SVGAnimatedNumberList,
        SVGAnimatedPoints,
        SVGAnimatedPreserveAspectRatio,
        SVGAnimatedRect,
        SVGAnimatedString,
        SVGAnimatedTransformList,
        SVGAnimationElement,
        SVGCircleElement,
        SVGClipPathElement,
        SVGCursorElement,
        SVGDefsElement,
        SVGDescElement,
        SVGEllipseElement,
        SVGFilterElement,
        SVGFontElement,
        SVGFontFaceElement,
        SVGFontFaceFormatElement,
        SVGFontFaceNameElement,
        SVGFontFaceSrcElement,
        SVGFontFaceUriElement,
        SVGForeignObjectElement,
        SVGGElement,
        SVGGlyphElement,
        SVGGradientElement,
        SVGHKernElement,
        SVGImageElement,
        SVGLength,
        SVGLengthList,
        SVGLineElement,
        SVGLinearGradientElement,
        SVGMPathElement,
        SVGMaskElement,
        SVGMatrix,
        SVGMissingGlyphElement,
        SVGNumber,
        SVGNumberList,
        SVGPathElement,
        SVGPatternElement,
        SVGPoint,
        SVGPolygonElement,
        SVGPolylineElement,
        SVGPreserveAspectRatio,
        SVGRadialGradientElement,
        SVGRect,
        SVGRectElement,
        SVGSVGElement,
        SVGScriptElement,
        SVGSetElement,
        SVGStopElement,
        SVGStringList,
        SVGStylable,
        SVGStyleElement,
        SVGSwitchElement,
        SVGSymbolElement,
        SVGTRefElement,
        SVGTSpanElement,
        SVGTests,
        SVGTextElement,
        SVGTextPositioningElement,
        SVGTitleElement,
        SVGTransform,
        SVGTransformList,
        SVGTransformable,
        SVGUseElement,
        SVGVKernElement,
        SVGViewElement,
        TimeEvent,
        #endregion
        #region WebGLRelated
        CanvasRenderingContext2D,
        WebGLRenderingContext,
        WebGLActiveInfo,
        WebGLBuffer,
        WebGLContextEvent,
        WebGLFramebuffer,
        WebGLShader,
        WebGLShaderPrecisionFormat,
        WebGLProgram,
        WebGLTexture,
        WebGLRenderbuffer,
        WebGLUniformLocation,
        AudioContext,
        Audio,
        AudioBuffer,
        AudioBufferSourceNode,
        AudioDestinationNode,
        AudioListener,
        AudioParam,
        AudioProcessingEvent,
        AudioNode,
        BiquadFilterNode,
        ChannelMergerNode,
        ChannelSplitterNode,
        ConvolverNode,
        DelayNode,
        DynamicsCompressorNode,
        MediaElementAudioSourceNode,
        MediaStreamAudioDestinationNode,
        MediaStreamAudioSourceNode,
        OfflineAudioCompletionEvent,
        OfflineAudioContext,
        OscillatorNode,
        PannerNode,
        PeriodicWave,
        ScriptProcessorNode,
        WaveShaperNode,
        AudioScheduledSouceNode,
        #endregion
        #region WebSpeechApi
        SpeechGrammar,
        SpeechGrammarList,
        SpeechRecognition,
        SpeechRecognitionAlternative,
        SpeechRecognitionError,
        SpeechRecognitionEvent,
        SpeechRecognitionResult,
        SpeechRecognitionResultList,
        SpeechSynthesis,
        SpeechSynthesisErrorEvent,
        SpeechSynthesisEvent,
        SpeechSynthesisUtterance,
        SpeechSynthehesisVoice,
        #endregion
        Other
    }
    


}