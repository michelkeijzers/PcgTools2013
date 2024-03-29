﻿// (c) Copyright 2011-2019 MiKeSoft, Michel Keijzers, All rights reserved


using PcgTools.Model.Common.Synth.PatchCombis;
using PcgTools.Model.MntxSeriesSpecific.Synth;

namespace PcgTools.Model.M3rSpecific.Synth
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class M3RTimbres : MntxTimbres
    {
        /// <summary>
        /// 
        /// </summary>
        private static int TimbresOffsetConstant => 36;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="combi"></param>
        public M3RTimbres(ICombi combi)
            : base(combi, TimbresOffsetConstant)
        {
            for (int n = 0; n < TimbresPerCombi; n++)
            {
                TimbresCollection.Add(new M3RTimbre(this, n));
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        protected override ITimbre CreateNewTimbre(int index)
        {
            return new M3RTimbre(this, index);
        }

    }
}
