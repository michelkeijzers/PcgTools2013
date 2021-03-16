// (c) Copyright 2011-2019 MiKeSoft, Michel Keijzers, All rights reserved


using PcgTools.Model.Common.Synth.MemoryAndFactory;
using PcgTools.Model.KronosSpecific.Synth;

namespace PcgTools.Model.NautilusSpecific.Synth
{
    /// <summary>
    /// 
    /// </summary>
    public class NautilusGlobal : KronosGlobal
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pcgMemory"></param>
        public NautilusGlobal(IPcgMemory pcgMemory): base(pcgMemory)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        protected override int PcgOffsetCategories => 12902;
    }
}
