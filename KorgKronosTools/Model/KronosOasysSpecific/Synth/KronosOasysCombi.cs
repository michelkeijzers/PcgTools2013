// (c) Copyright 2011-2016 MiKeSoft, Michel Keijzers, All rights reserved

using System;
using PcgTools.Model.Common.Synth.PatchCombis;

namespace PcgTools.Model.KronosOasysSpecific.Synth
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class KronosOasysCombi: Combi
    {
        /// <summary>
        /// 
        /// </summary>
        public override string Name
        {
            get { return GetChars(0, MaxNameLength); }

            set
            {
                if (Name != value)
                {
                    SetChars(0, MaxNameLength, value);
                    OnPropertyChanged("Name");
                }
            }
        }


        /// <summary>
        /// 
        /// </summary>
        public override int MaxNameLength
        {
            get { return 24; }
        }


        /// <summary>
        /// 
        /// </summary>
        public override bool IsEmptyOrInit { get { return ((Name == String.Empty) || (Name.Contains("Init") && Name.Contains("Combi"))); } }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="combiBank"></param>
        /// <param name="index"></param>
        protected KronosOasysCombi(ICombiBank combiBank, int index)
            : base(combiBank, index)
        {
        }
    }
}
