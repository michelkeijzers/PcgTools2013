// (c) Copyright 2011-2016 MiKeSoft, Michel Keijzers, All rights reserved

using PcgTools.Model.Common.Synth.MemoryAndFactory;

namespace PcgTools.Model.KronosOasysSpecific.Pcg
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class KronosOasysPcgMemory : PcgMemory
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="modelType"></param>
        protected KronosOasysPcgMemory(string fileName, Models.EModelType modelType)
            : base(fileName, modelType)
        {
        }


        /// <summary>
        /// 
        /// </summary>
        public override bool HasSubCategories { get { return true; } }


        /// <summary>
        /// 
        /// </summary>
        public override int NumberOfCategories { get { return 18; } }


        /// <summary>
        /// 
        /// </summary>
        public override int NumberOfSubCategories { get { return 8; } }
    }
}
