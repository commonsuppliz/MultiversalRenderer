 [WIP] .NET HTML Rendering Library 

## About
HTML Rendering Library for .NET 6 and above [WIP]
- Supports for most of HTML5 Web APIs.
  - Window, HTMLDocument, HTMLElements, HTMLAttributes, etc
  - Most of HTML tags are supported
  - XMLWebRequest
  - basic Window Events
- CSS3 support
- Javascript (JS5) support with Java Rhino Library (https://github.com/mozilla/rhino) and IKVM Revived project (https://github.com/ikvmnet/ikvm)

## DOM API
- Most of HMLT5 DOM API has been implemented
    - Document.createElement()
    - Document.createEvent()
    - Document.createTextNode()
    - Document.querySelector()
    - Document.querySelectorAll()
    - Document.getElementById()
    - Document.evaluate()
    - Documennt.getElementsByClassName()
    - Document.getElementsByTagName()
    - Element.appendChild()
    - Element.removeChild()
    - Element.contains()
    - Element.insertBefore()
    - Element.replaceChild()
    - Element.getBoundingClientRect()
    - CSStyleSheet.addRule()
    - DOMParser.parseFromStrig()
    - HTMLCanvasElement.getContext("2D")   [All Canvas 2D API are supported]
    - WebGLContext and AudioContext API exists, but does nothing currently.
 
    - etc
## Previous Project Screen Image 

<img src='ScreenShootofMultiversalRenderer_DotnetFrameworkWindows.jpg' width="600" height="700" alt="Screen image on Windows 11 and .NET Framework 1.1 and above">

## Curent Status
  - The previous project was designed for .NET Framework 1.1 and Mono Project above and Winforms
  - The migration for Dotnet 6, 7, 8 and above (dotnetcore) is under progress
  - NiLJs Javascript Engine has been implemented instead of Rhino JS Engine
  - WIP is appproximately 50%.

## TODO

1. Remove existing obsolute Web Client API (WebClient/WebHttpRequest)  code has be re-write to support HtttpClient API
2. Graphical API need to support the latest .NET Cross-Platformm Grahical APIs.
3. HTML layout engine needs a lot of work for improvement. 
4. Impliment better HTML layout scheme.
5. Implement other GUI support other than  Winforms GUI.

