// (c) Copyright 2011-2019 MiKeSoft, Michel Keijzers, All rights reserved

using System.Collections.Generic;
using System.Diagnostics;

using PcgTools.Model.Common.Synth.MemoryAndFactory;
using PcgTools.Model.Common.Synth.Meta;
using PcgTools.Model.Common.Synth.PatchPrograms;
using PcgTools.Model.KronosSpecific.Synth;

namespace PcgTools.Model.NautilusSpecific.Synth
{
    /// <summary>
    /// 
    /// </summary>
    public class NautilusProgramBanks : KronosProgramBanks
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pcgMemory"></param>
        public NautilusProgramBanks(IPcgMemory pcgMemory)
            : base(pcgMemory)
        {
        }


        /// <summary>
        /// 
        /// </summary>
        protected override void CreateBanks()
        {
            /*
            // Unknown synthesis type because it is dynamic.
            Add(new NautilusProgramBank(
                this, BankType.EType.Int, "A", 0, ProgramBank.SynthesisType.Unknown, "EXi sounds"));    //  0

            Add(new NautilusProgramBank(
                this, BankType.EType.Int, "B", 1, ProgramBank.SynthesisType.Unknown, "EXi sounds"));    //  1
            
            Add(new NautilusProgramBank(
                this, BankType.EType.Int, "C", 2, ProgramBank.SynthesisType.Unknown, "EXi sounds"));    //  2
            
            Add(new NautilusProgramBank(
                this, BankType.EType.Int, "D", 3, ProgramBank.SynthesisType.Unknown, "EXi sounds"));    //  3
            
            Add(new NautilusProgramBank(
                this, BankType.EType.Int, "E", 4, ProgramBank.SynthesisType.Unknown, "EXi sounds"));    //  4
            
            Add(new NautilusProgramBank(
                this, BankType.EType.Int, "F", 5, ProgramBank.SynthesisType.Unknown, "HD-1 sounds"));   //  5
            */
    
            // Remaining banks (total: A..T, a..t, 2* 20 - 7(A..F)
            for (int bank = 0; bank < 40; bank++)
            {
                char bankName = bank < 20 ? (char)('A' + bank) : (char)('a' + (bank - 20));
                Add(new NautilusProgramBank(
                  this, BankType.EType.Int, bankName.ToString() + "(" + bank.ToString() + ")", bank, 
                  ProgramBank.SynthesisType.Unknown, "HD-1/EXI sounds"));
                //Add(new NautilusProgramBank(
                //  this, BankType.EType.Int, ((char)('a' + bank)).ToString(), 64 + bank * 2 + 1,
                //  ProgramBank.SynthesisType.Unknown, "HD-1/EXI sounds")); 
            }

            // a: 76
            // c: 65
            CreateVirtualBanks();

            // Add GM bank.
            Add(new NautilusGmProgramBank(
                this, BankType.EType.Gm, "GM", 6, ProgramBank.SynthesisType.Hd1, "GM2 Main programs"));          // [84]
        }


#pragma warning disable 1570
        /// <summary>
        /// Create 32 virtual banks (8 groups of 8 banks).
        /// To create virtual banks, name them like V<number><A..H>.
        /// 
        /// The PCG file that is created, adds the banks after the first two (so the bank IDS are 0, 1, 0x30, 0x30 + 1, ... 0x30 + 63, 2, 3, ...
        /// Do not forget to change the IDs (0x30 ... 0x30 + 63, and change the chunk size of PRG1. 
        /// 
        /// Some interesting offsets/values:
        /// 0x8EA2A8 PRG1
        /// 0x8EA2AC 0xC1C1E0 Chunk size (change this: 0x9B018 per program bank (same for HD1/EXi).
        /// ...
        /// New banks start at A202F8 (?)
        /// </summary>
#pragma warning restore 1570
        protected override void CreateVirtualBanks()
        {
            List<char> bankNames = new List<char> { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H' };

            for (int bankGroupIndex = 0; bankGroupIndex < 8; bankGroupIndex++)
            {
                for (int bankIndex = 0; bankIndex < bankNames.Count; bankIndex++)
                {
                    Add(
                        new NautilusProgramBank(
                            this, BankType.EType.Virtual,
                            $"V{bankGroupIndex}-{bankNames[bankIndex]}",        // [20..83]
                            FirstVirtualBankId + bankGroupIndex * bankNames.Count + bankIndex, 
                            ProgramBank.SynthesisType.Unknown, string.Empty));
                }
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="pcgId"></param>
        /// <returns></returns>
        public override IBank GetBankWithPcgId(int pcgId)
        {
            if (pcgId <= 5)
            {
                return BankCollection[pcgId];
            }
            else if (pcgId <= 16)
            {
                return BankCollection[BankCollection.Count - 1]; // GM 
            }
            else return BankCollection[pcgId - 11];
        }

    }
}
