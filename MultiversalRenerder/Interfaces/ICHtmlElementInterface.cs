using System;
using System.Collections.Generic;
using System.Text;

namespace MultiversalRenderer.Interfaces
{
    public interface ICHtmlElementInterface
    {
        string name { get; set; }
        string id { get; set; }
        string className { get; set; }
        string tagName { get; }
        string title { get; set; }
        string localName { get; }
        string baseUri { get; }
        double nodeType { get; }
        string nodeName { get; }
        object nodeValue { get; set; }
        ICHtmlElementInterface firstChild { get; }
        ICHtmlElementInterface lastChild { get; }
        ICHtmlElementInterface nextSibling { get; }
        ICHtmlElementInterface previousSibling { get; }
        string textContent { get; set; }
        string text { get; set; }
        string type { get; set; }
        object @value { get; set; }
    }
}
