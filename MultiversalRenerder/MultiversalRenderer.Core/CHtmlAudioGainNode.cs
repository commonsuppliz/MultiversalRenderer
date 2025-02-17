﻿using System;
using System.Collections.Generic;
using System.Text;
using MultiversalRenderer.Interfaces;
namespace MultiversalRenderer.Core
{
    /// <summary>
    /// FileList for HTML5. ex.  input type=files
    /// </summary>
    public sealed class CHtmlAudioGainNode : CHtmlAudioNode
    {
      

        internal CHtmlAudioParam  ___gain = null;
        internal bool ___paused;
        public CHtmlAudioGainNode()
        {
            this.___gain = new CHtmlAudioParam();
        }

        public override string ToString()
        {
            if (this.___IsPrototype == false)
            {
                return this.GetType().Name;
            }
            else
            {
                return this.GetType().Name + "[prototype]";
            }
        }
        public Boolean paused
        {
            get
            {
                return this.___paused;
            }
            set
            {
                this.___paused = commonData.convertObjectToBoolean(value);
            }
        }

        public override bool hasOwnProperty(string ___name)
        {
            return this.___hasPropertyByName(___name);
        }
        public CHtmlAudioParam gain
        {
            get { return this.___gain; }
        }

        #region IPropertBox メンバ

        public override object ___getPropertyByName(string ___name)
        {
            if (commonLog.LoggingEnabled &&commonLog.CommonLogLevel >= 8)
            {
               commonLog.LogEntry("GetPropertyValue for {0} {1} ", this, ___name);
            }
            switch (___name)
            {
                case "gain":
                    return this.___gain;
                case "paused":
                    return this.___paused;
                default:
                    break;
            }
            object propValue;
            if (___properties.TryGetValue(___name, out propValue))
            {
                return propValue;
            }
            if (commonLog.LoggingEnabled &&commonLog.CommonLogLevel >= 8)
            {
               commonLog.LogEntry("GetPropertyValue for {0} {1} failed", this, ___name);
            }
            return null;
        }

        public override  void ___setPropertyByName(string ___name, object val)
        {
            switch (___name)
            {
                case "paused":
                   this.___paused = commonData.convertObjectToBoolean(val);
                    return;

                default:
                    if (commonLog.LoggingEnabled &&commonLog.CommonLogLevel >= 8)
                    {
                       commonLog.LogEntry("SetPropertyValue for {0} {1}  {2} = {3} failed", this.GetType(), this, ___name, val);
                    }
                    this.___properties[___name] = val;
                    break;
            }
        }
        public override  void ___setPropertyByIndex(int ___index, object val)
        {
            if (commonLog.LoggingEnabled &&commonLog.CommonLogLevel >= 8)
            {
               commonLog.LogEntry("SetPropertyValueIndex for {0} {1}  {2} = {3} failed", this.GetType(), this, ___index, val);
            }
        }
        public override object ___getPropertyByIndex(int ___index)
        {
            if (commonLog.LoggingEnabled &&commonLog.CommonLogLevel >= 8)
            {
               commonLog.LogEntry("GetPropertyValueInex for {0} {1} {2} failed", this.GetType(), this, ___index);
            }
            return null;
        }

        public override  bool ___hasPropertyByName(string ___name)
        {

            return false;
        }
        public override  bool ___hasPropertyByIndex(int ___index)
        {
            return true;
        }




        #endregion
    }
}
