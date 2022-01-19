// (c) Copyright 2011-2019 MiKeSoft, Michel Keijzers, All rights reserved


using PcgTools.Model.Common.Synth.PatchCombis;

namespace PcgTools.Model.NautilusSpecific.Synth
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class NautilusTimbres : Timbres
    {
        /// <summary>
        /// 
        /// </summary>
        public static int TimbresPerCombiConstant => 16;


        /// <summary>
        /// 
        /// </summary>
        private static int TimbresOffsetConstant => 2632;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="combi"></param>
        public NautilusTimbres(Combi combi)
            : base(combi, TimbresPerCombiConstant, TimbresOffsetConstant)
        {
            for (int n = 0; n < TimbresPerCombi; n++)
            {
                TimbresCollection.Add(new NautilusTimbre(this, n));
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        protected override ITimbre CreateNewTimbre(int index)
        {
            return new NautilusTimbre(this, index);
        }
    }
}
