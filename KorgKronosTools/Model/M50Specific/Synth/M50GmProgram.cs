// (c) Copyright 2011-2016 MiKeSoft, Michel Keijzers, All rights reserved


using PcgTools.Model.Common.Synth.PatchPrograms;

namespace PcgTools.Model.M50Specific.Synth
{
    /// <summary>
    /// 
    /// </summary>
    public class M50GmProgram : M50Program
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly string _name;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="programBank"></param>
        /// <param name="index"></param>
        /// <param name="name"></param>
        public M50GmProgram(IProgramBank programBank, int index, string name)
            : base(programBank, index)
        {
            _name = name;
            Id = string.Format("{0}{1:000}", programBank.Id, UserIndex);
        }


        /// <summary>
        /// The user index is the same as index, except for GM programs which are named as GM001 instead of GM000 etc.
        /// </summary>
        public override int UserIndex
        {
            get { return Index + 1; }
        }


        /// <summary>
        /// 
        /// </summary>
        public override string Name
        {
            get { return _name; }
        }
    }
}
