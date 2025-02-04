﻿using System;
using System.Collections.Generic;
using System.Text;
using MultiversalRenderer.Interfaces;
namespace MultiversalRenderer.Core
{
    /// <summary>
    /// The AudioParam interface represents an audio-related parameter, usually a parameter of an AudioNode (such as GainNode.gain). An AudioParam can be set to a specific value or a change in value, and can be scheduled to happen at a specific time and following a specific pattern.
    /// </summary>
    public sealed class CHtmlAudioBiquadFilterNode : CHtmlAudioNode  , ICommonObjectInterface 
    {
      
        internal new System.WeakReference ___ownerDocumentWeakReference = null;
        internal new System.WeakReference ___ownerContextWeakReference = null;
  
       
        #region AudioContextClassSpecificProperties
        public CHtmlAudioBiquadFilterNode()
        {
            ___detune = new CHtmlAudioParam();
            ___detune.value = -1;
            ___frequency = new CHtmlAudioParam();
            ___frequency.value = 360;
            ___Q = new CHtmlAudioParam();
            ___Q.value = 1;
            ___gain = new CHtmlAudioParam();
            ___gain.value = 0;
            ___biquadFilterNodeTypeString = "";
            ___multiversalClassType = IMutilversalObjectType.BiquadFilterNode;
            //this.___multiversalClassType = IMutilversalObjectType.
        }

        #endregion

        public new string getClassName()
        {
            return this.GetType().Name;
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


        public new bool hasOwnProperty(string ___name)
        {
            return this.___hasPropertyByName(___name);
        }


        #region IPropertBox メンバ
        internal CHtmlAudioParam ___detune = null;
        public CHtmlAudioParam detune
        {
            get { return this.___detune; }
            set { this.___detune = value; }
        }


        /// <summary>
        /// The frequency property of the BiquadFilterNode interface Is a k-rate AudioParam, a double representing a frequency in the current filtering algorithm measured in hertz (Hz).
        /// frequency's default value is 350 with a nominal range  of 10 to the Nyquist frequency — that is, half of the sample rate.
        /// </summary>
        internal CHtmlAudioParam ___frequency = null;
        public CHtmlAudioParam frequency
        {
            get { return this.___frequency; }
            set { this.___frequency = value; }
        }


        /// <summary>
        /// The frequency property of the BiquadFilterNode interface Is a k-rate AudioParam, a double representing a frequency in the current filtering algorithm measured in hertz (Hz).
        /// frequency's default value is 350 with a nominal range  of 10 to the Nyquist frequency — that is, half of the sample rate.
        /// </summary>
        internal CHtmlAudioParam ___gain = null;
        public CHtmlAudioParam gain
        {
            get { return this.___gain; }
            set { this.___gain = value; }
        }
        /// <summary>
        /// The Q property of the BiquadFilterNode interface Is a k-rate AudioParam, a double representing a Q factor, or quality factor.
        /// It is a dimensionless value with a default value of 1 and a nominal range of 0.0001 to 1000.
        /// </summary>
        internal CHtmlAudioParam ___Q = null;
        public CHtmlAudioParam Q
        {
            get { return this.___Q; }
            set { this.___Q = value; }
        }



        /// <summary>
        /// The type property of the BiquadFilterNode interface is a string (enum) value defining the kind of filtering algorithm the node is implementing.
        /// </summary>
        internal string ___biquadFilterNodeTypeString = null;
        public new string type
        {
            get { return this.___biquadFilterNodeTypeString; }
            set { this.___set_type_string(value); }
        }
        public void ___set_type_string(string __type)
        {
            if (commonLog.LoggingEnabled &&commonLog.CommonLogLevel >= 8)
            {
               commonLog.LogEntry("set {0}.type = {1}", this, __type);
            }
            this.___biquadFilterNodeTypeString = __type;
        }
        

        public new object ___getPropertyByName(string ___name)
        {
            if (commonLog.LoggingEnabled &&commonLog.CommonLogLevel >= 8)
            {
               commonLog.LogEntry("GetPropertyValue for {0} {1} ", this, ___name);
            }
            switch (___name)
            {
                case "Q":
                    return ___Q;
                case "type":
                    return this.___biquadFilterNodeTypeString;
                case "detune":
                    return this.___detune;
                case "frequency":
                    return this.___frequency;
                case "gain":
                    return ___gain;
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
               commonLog.LogEntry("getPropertyValue for {0} {1} failed", this, ___name);
            }
            return null;
        }

        public override void ___setPropertyByName(string ___name, object val)
        {
            if (commonLog.LoggingEnabled &&commonLog.CommonLogLevel >= 8)
            {
               commonLog.LogEntry("entring setPropertyValueIndex for {0} {1}  {2} = {3}", this.GetType(), this, ___name, val);
            }
            switch (___name)
            {
                case "type":
                    this.___set_type_string(commonHTML.GetStringValue(val));
                    break;
                default:
                    if (commonLog.LoggingEnabled &&commonLog.CommonLogLevel >= 8)
                    {
                       commonLog.LogEntry("TODO: setPropertyValue for {0} {1}  {2} = {3} failed", this.GetType(), this, ___name, val);
                    }
                    this.___properties[___name] = val;
                    break;
            }
        }
        public override void ___setPropertyByIndex(int ___index, object val)
        {
            if (commonLog.LoggingEnabled &&commonLog.CommonLogLevel >= 8)
            {
               commonLog.LogEntry("setPropertyValueIndex for {0} {1}  {2} = {3} failed", this.GetType(), this, ___index, val);
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

        public override bool ___hasPropertyByName(string ___name)
        {

            return false;
        }
        public  override  bool ___hasPropertyByIndex(int ___index)
        {
            return true;
        }
        public new object ___common_object_clone()
        {
            if (commonLog.LoggingEnabled &&commonLog.CommonLogLevel >= 10)
            {
               commonLog.LogEntry("x__Clone {0} {1} called", this.GetType(), this);
            }
            return this;
        }
        public override void ___deleteByIndex(int ___index)
        {
            if (commonLog.LoggingEnabled &&commonLog.CommonLogLevel >= 10)
            {
               commonLog.LogEntry("___deleteByIndex {0} {1} called : {2}", this.GetType(), this, ___index);
            }
        }
        public override  void ___deleteByName(string ___name)
        {
            if (commonLog.LoggingEnabled &&commonLog.CommonLogLevel >= 10)
            {
               commonLog.LogEntry("___deleteByName {0} {1} called : {2}", this.GetType(), this, ___name);
            }

        }
        public new  object[] ___getByIds()
        {
            if (commonLog.LoggingEnabled &&commonLog.CommonLogLevel >= 10)
            {
               commonLog.LogEntry("___getByIds() {0} {1} called", this.GetType(), this);
            }
            return null;

        }
        public new string ___getClassName()
        {
            if (commonLog.LoggingEnabled &&commonLog.CommonLogLevel >= 10)
            {
               commonLog.LogEntry("___getClassName {0} {1} called", this.GetType(), this);
            }
            return this.GetType().Name;
        }
        public new object ___getDefaultValue()
        {
            if (commonLog.LoggingEnabled &&commonLog.CommonLogLevel >= 10)
            {
               commonLog.LogEntry("___getDefaultValue {0} {1} called", this.GetType(), this);
            }
            return null;
        }
        public new object ___getParentScope()
        {
            if (commonLog.LoggingEnabled &&commonLog.CommonLogLevel >= 10)
            {
               commonLog.LogEntry("___getParentScope {0} {1} called", this.GetType(), this);
            }
            return null;
        }
        public override  void ___setParentScope(object ___object)
        {
            if (commonLog.LoggingEnabled &&commonLog.CommonLogLevel >= 10)
            {
               commonLog.LogEntry("___setParentScope {0} {1} called : {2}", this.GetType(), this, ___object);
            }
        }
        public new object ___getProtoType()
        {
            if (commonLog.LoggingEnabled &&commonLog.CommonLogLevel >= 10)
            {
               commonLog.LogEntry("___getProtoType {0} {1} called", this.GetType(), this);
            }
            return null;
        }
        public override bool ___hasInstance(object ___object)
        {
            if (commonLog.LoggingEnabled &&commonLog.CommonLogLevel >= 10)
            {
               commonLog.LogEntry("___hasInstance {0} {1} called : {2}", this.GetType(), this, ___object);
            }
            return false;
        }
        public override bool ___instanceEquals(object ___object)
        {
            if (commonLog.LoggingEnabled &&commonLog.CommonLogLevel >= 10)
            {
               commonLog.LogEntry("___instanceEquals {0} {1} called : {2}", this.GetType(), this, ___object);
            }
            return object.ReferenceEquals(this, ___object);
        }
        public override void ___setProtoType(object ___object)
        {
            if (commonLog.LoggingEnabled &&commonLog.CommonLogLevel >= 10)
            {
               commonLog.LogEntry("___setProtoType {0} {1} called : {2}", this.GetType(), this, ___object);
            }
        }

        #endregion
    }
}
