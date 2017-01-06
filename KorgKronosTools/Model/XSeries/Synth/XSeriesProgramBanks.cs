// (c) Copyright 2011-2016 MiKeSoft, Michel Keijzers, All rights reserved

using PcgTools.Model.Common.Synth.MemoryAndFactory;
using PcgTools.Model.Common.Synth.Meta;
using PcgTools.Model.Common.Synth.PatchPrograms;
using PcgTools.Model.MntxSeriesSpecific.Synth;

namespace PcgTools.Model.XSeries.Synth
{
    /// <summary>
    /// 
    /// </summary>
    public class XSeriesProgramBanks : MntxProgramBanks
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pcgMemory"></param>
        public XSeriesProgramBanks(IPcgMemory pcgMemory)
            : base(pcgMemory)
        {
        }


        /// <summary>
        /// The first (default internal) eight program banks are called A..H.
        /// The next (virtual) banks will be called V1A, V1B, ... V1H, V2A, ...
        /// </summary>
        protected override void CreateBanks()
        {
            // Add internal banks.
            Add(
                new XSeriesProgramBank(
                    this, BankType.EType.Int, string.Format("{0}", "A"), 0, 
                    ProgramBank.SynthesisType.Ai, "-"));

            Add(
                new XSeriesProgramBank(
                    this, BankType.EType.Int, string.Format("{0}", "B"), 1, 
                    ProgramBank.SynthesisType.Ai, "-"));
        }
    }
}
