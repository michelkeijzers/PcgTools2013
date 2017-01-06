// (c) Copyright 2011-2016 MiKeSoft, Michel Keijzers, All rights reserved


using PcgTools.Model.Common.Synth.Global;
using PcgTools.Model.Common.Synth.MemoryAndFactory;

namespace PcgTools.Model.MSpecific.Synth
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class MGlobal : Global
    {
        /// <summary>
        /// 
        /// </summary>
        protected override int CategoryNameLength { get { return 24; } }


        /// <summary>
        /// 
        /// </summary>
        protected override int NrOfCategories { get { return 18; } }


        /// <summary>
        /// 
        /// </summary>
        protected override int NrOfSubCategories { get { return 8; } }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="pcgMemory"></param>
        protected MGlobal(IPcgMemory pcgMemory): base(pcgMemory)
        {
        }
    }
}
