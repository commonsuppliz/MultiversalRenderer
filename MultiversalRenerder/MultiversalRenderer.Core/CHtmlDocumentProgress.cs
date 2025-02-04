using System;
using System.Collections.Generic;
using System.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultiversalRenderer.Core;

namespace MultiversalRenderer.Core
{
    public class CHttpContentDownload
    {
        public string Url { get; set; }
        public string Method { get; set; }
        public DateTime Time { get; set; }
        public string? FilePath { get; set; }
        public int ContentLength { get; set; }
        public CHtmlDocument? Document;
        public float Progress { get; set; }


    }

}