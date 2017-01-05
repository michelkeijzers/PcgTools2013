﻿// (c) Copyright 2011-2016 MiKeSoft, Michel Keijzers, All rights reserved

using System;
using PcgTools.Model.Common.Synth.Meta;
using PcgTools.Model.Common.Synth.OldParameters;
using PcgTools.Model.Common.Synth.PatchCombis;

namespace PcgTools.Model.MntxSeriesSpecific.Synth
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class MntxCombi: Combi
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
                }
            }
        }


        /// <summary>
        /// 
        /// </summary>
        public override int MaxNameLength
        {
            get { return 10; }
        }


        /// <summary>
        /// Use Comb instead of Combi, because of some Mntx EXB-H banks are initialized as InitCombEH....
        /// </summary>
        public override bool IsEmptyOrInit
        {
            get { return ((Name == String.Empty) || (Name.Contains("Init") && Name.Contains("Comb"))); }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="combiBank"></param>
        /// <param name="index"></param>
        protected MntxCombi(IBank combiBank, int index)
            : base(combiBank, index)
        {
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public override IParameter GetParam(ParameterNames.CombiParameterName name)
        {
            IParameter parameter;

            switch (name)
            {
            default:
                parameter = base.GetParam(name);
                break;
            }
            return parameter;
        }
    }
}