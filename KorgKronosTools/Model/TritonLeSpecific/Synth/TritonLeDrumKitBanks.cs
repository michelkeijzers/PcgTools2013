﻿

// (c) 2011 Michel Keijzers
using PcgTools.Model.Common.Synth.MemoryAndFactory;
using PcgTools.Model.Common.Synth.Meta;
using PcgTools.Model.Common.Synth.PatchDrumKits;

namespace PcgTools.Model.TritonLeSpecific.Synth
{
    /// <summary>
    /// 
    /// </summary>
    public class TritonLeDrumKitBanks : DrumKitBanks
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pcgMemory"></param>
        public TritonLeDrumKitBanks(IPcgMemory pcgMemory)
            : base(pcgMemory)
        {
        }


        /// <summary>
        /// 
        /// </summary>
        protected override void CreateBanks()
        {
            // LV: Following is based on documentation in "Triton Le Operation Guide page 121".
            // I did see it work with a PCG for Triton Le which had all Drumkit banks.
            //
            // I am not sure if it is correct for other Triton models that share this same class implementation!
            // E.g. the bank names used.
            // Also have a look at PcgFileReader.DrumKitBankId2DrumKitIndex() especially for which bank ids in the PCG are >=0x20000.
            // Sorry but I could not do better than this at the moment, the Triton Drumkit banks are very differently organized...

            foreach (var id in new[] { "A", "B", "C", "D"})
            {
                Add(new TritonLeDrumKitBank(this, BankType.EType.Int, id, -1));
            }

            //Add(new TritonLeDrumKitBank(this, "USER", DrumKitBank.PatchType.User));
        }
    }
}
