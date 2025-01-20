using System;
using System.Collections.Generic;
using System.Text;
using MultiversalRenderer.Interfaces;

namespace MultiversalRenderer.Core
{
    public sealed class CHtmlPerformanceEntriesList : CHtmlCollection 
    {
        public CHtmlPerformanceEntriesList()
        {
            this.___CollectionType = CHtmlHTMLCollectionType.PerformanceEntriesList;
        }
        private object ___filterFunction = null;
        public CHtmlPerformanceEntriesList filter(object ___objFilter)
        {
            if (commonLog.LoggingEnabled &&commonLog.CommonLogLevel >= 8)
            {
               commonLog.LogEntry("TODO: calling {0}.filter({1})", this, ___objFilter);
            }
            this.___filterFunction = ___objFilter;
            CHtmlPerformanceEntriesList newList = new CHtmlPerformanceEntriesList();
            return newList;
        }
        public object reduce(object ___objReduce1, object ___objRduce2)
        {
            return this.___reduce_inner(___objReduce1, ___objRduce2);
        }
        private object ___reduce_inner(object ___objReduce1, object ___objRduce2)
        {
            if (commonLog.LoggingEnabled &&commonLog.CommonLogLevel >= 8)
            {
               commonLog.LogEntry("TODO: calling {0}.recude({1}, {2})", this, ___objReduce1, ___objRduce2);
            }
            return null;
        }
    }
}
