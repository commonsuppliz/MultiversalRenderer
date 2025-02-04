using System;
using System.Collections.Generic;
using System.Text;
using MultiversalRenderer.Interfaces;
namespace MultiversalRenderer.Core
{
    public class CHtmlNode
    {
        internal IMutilversalObjectType ___multiversalClassType = IMutilversalObjectType.Node;
        internal string ___multiversalClassTypeString = null;
        internal bool ___IsPrototype = false;
        internal CHtmlCollection ___childNodes = null;
        internal System.Collections.Generic.Dictionary<string, object> ___properties;
        internal System.Collections.Generic.Dictionary<string, object> ___getterProperties;
        internal System.Collections.Generic.Dictionary<string, object> ___setterProperties;
        internal CHtmlNode ___parentNode = null;
        internal System.WeakReference ___prototypeWeakReference = null;
        public CHtmlNode()
        {
            this.___childNodes = new CHtmlCollection();
            this.___childNodes.___CollectionType = CHtmlHTMLCollectionType.NodeChildNodes;
            this.___childNodes.___createObjectIDTable();
            this.___properties = new Dictionary<string, object>(StringComparer.Ordinal);
            this.___getterProperties = new Dictionary<string, object>(StringComparer.Ordinal);
            this.___setterProperties = new Dictionary<string, object>(StringComparer.Ordinal);
        }
        public int ELEMENT_NODE
        {
            get
            {
                return 1;
            }
        }
        public int ATTRIBUTE_NODE
        {
            get
            {
                return 2;
            }
        }
        public int TEXT_NODE
        {
            get
            {
                return 3;
            }
        }
        public int CDATA_SECTION_NODE
        {
            get
            {
                return 4;
            }
        }
        public int ENTITY_REFERENCE_NODE
        {
            get
            {
                return 5;
            }
        }
        public int ENTITY_NODE
        {
            get
            {
                return 6;
            }
        }
        public int PROCESSING_INSTRUCTION_NODE
        {
            get
            {
                return 7;
            }
        }
        public int COMMENT_NODE
        {
            get
            {
                return 8;
            }
        }
        public int DOCUMENT_NODE
        {
            get
            {
                return 9;
            }
        }
        public int DOCUMENT_TYPE_NODe
        {
            get
            {
                return 10;
            }
        }
        public int DOCUMENT_FRAGMENT_NODE
        {
            get
            {
                return 11;
            }
        }
        public int NOTATION_NODE
        {
            get
            {
                return 12;
            }
        }
        public override string ToString()
        {
            if (string.IsNullOrEmpty(this.___multiversalClassTypeString) == true)
            {
                this.___multiversalClassTypeString = "[object " + this.___multiversalClassType.ToString() + "]";

            }
            return this.___multiversalClassTypeString;
        }
        public CHtmlCollection childNodes
        {
            get { return this.___childNodes; }
        }
        public System.Collections.Generic.Dictionary<string, object> properites
        {
            get { return this.___properties; }
        }
        public CHtmlNode parentNode
        {
            get
            {
                return this.___parentNode;
            }
            set
            {
                this.___parentNode = value;
            }
        }
        public IMutilversalObjectType multiversalClassType
        {
            get
            {
                return this.___multiversalClassType;
            }
        }

    }
}
