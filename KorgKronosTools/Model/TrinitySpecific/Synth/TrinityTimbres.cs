// (c) Copyright 2011-2019 MiKeSoft, Michel Keijzers, All rights reserved


using PcgTools.Model.Common.Synth.PatchCombis;

namespace PcgTools.Model.TrinitySpecific.Synth
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class TrinityTimbres : Timbres
    {
        /// <summary>
        /// 
        /// </summary>
        private static int TimbresOffsetConstant => 236;


        /// <summary>
        /// 
        /// </summary>
        private static int TimbresPerCombiConstant => 8;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="combi"></param>
        public TrinityTimbres(ICombi combi)
            : base(combi, TimbresPerCombiConstant, TimbresOffsetConstant)
        {
            for (int n = 0; n < TimbresPerCombi; n++)
            {
                TimbresCollection.Add(new TrinityTimbre(this, n));
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        protected override ITimbre CreateNewTimbre(int index)
        {
            return new TrinityTimbre(this, index);
        }
    }
}
