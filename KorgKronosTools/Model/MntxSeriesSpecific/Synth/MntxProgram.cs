// (c) Copyright 2011-2016 MiKeSoft, Michel Keijzers, All rights reserved


using PcgTools.Model.Common.Synth.Meta;
using PcgTools.Model.Common.Synth.PatchPrograms;

namespace PcgTools.Model.MntxSeriesSpecific.Synth
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class MntxProgram : Program
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="programBank"></param>
        /// <param name="index"></param>
        protected MntxProgram(IBank programBank, int index)
            : base(programBank, index)
        {
        }

        
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
        /// 
        /// </summary>
        public override bool IsEmptyOrInit
        {
            get
            {
                return ((Name == string.Empty) || (Name.Contains("Init") && Name.Contains("Prog")));
            }
        }
    }
}
