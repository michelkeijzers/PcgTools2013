// (c) Copyright 2011-2016 MiKeSoft, Michel Keijzers, All rights reserved


using PcgTools.Model.Common.Synth.MemoryAndFactory;

namespace PcgTools.Model.TritonSpecific.Pcg
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class TritonPcgMemory : PcgMemory
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="modelType"></param>
        protected TritonPcgMemory(string fileName, Models.EModelType modelType)
            : base(fileName, modelType)
        {
        }


        /// <summary>
        /// 
        /// </summary>
        public override bool HasSubCategories
        {
            get { return false; }
        }


        /// <summary>
        /// 
        /// </summary>
        public override int NumberOfCategories
        {
            get { return 16; }
        }


        /// <summary>
        /// 
        /// </summary>
        public override int NumberOfSubCategories
        {
            get { return 0; }
        }
    }
}
