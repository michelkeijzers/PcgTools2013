// (c) Copyright 2011-2019 MiKeSoft, Michel Keijzers, All rights reserved


using PcgTools.Model.Common.Synth.MemoryAndFactory;
using PcgTools.Model.Common.Synth.PatchSetLists;

namespace PcgTools.Model.NautilusSpecific.Synth
{
    /// <summary>
    /// 
    /// </summary>
    public class NautilusSetLists : SetLists
    {
        /// <summary>
        /// 
        /// </summary>
        private static int NrOfSetLists => 128;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="pcgMemory"></param>
        public NautilusSetLists(IPcgMemory pcgMemory)
            : base(pcgMemory)
        {
        }


        /// <summary>
        /// 
        /// </summary>
        protected override void CreateSetLists()
        {
            for (int n = 0; n < NrOfSetLists; n++)
            {
                Add(new NautilusSetList(this, n));
            }
        }
    }
}
