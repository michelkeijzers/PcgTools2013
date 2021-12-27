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

            Add(new NautilusProgramBank(
                this, BankType.EType.User, "G", 64, ProgramBank.SynthesisType.Unknown, "HD-1 sounds"));  // 6
            
            Add(new NautilusProgramBank(
                this, BankType.EType.User, "H", 65, ProgramBank.SynthesisType.Unknown, "HD-1 sounds"));  // 7

            Add(new NautilusProgramBank(
                this, BankType.EType.User, "I", 66, ProgramBank.SynthesisType.Unknown, "HD-1 sounds"));  // 8

            Add(new NautilusProgramBank(
                this, BankType.EType.User, "J", 67, ProgramBank.SynthesisType.Unknown, "HD-1 sounds"));  // 9

            Add(new NautilusProgramBank(
                this, BankType.EType.User, "K", 68, ProgramBank.SynthesisType.Unknown, "HD-1 sounds"));  // 10

            Add(new NautilusProgramBank(
                this, BankType.EType.User, "L", 69, ProgramBank.SynthesisType.Unknown, "HD-1 sounds"));  // 11

            Add(new NautilusProgramBank(
                this, BankType.EType.User, "M", 70, ProgramBank.SynthesisType.Unknown, "HD-1 sounds"));  // 12

            Add(new NautilusProgramBank(
                this, BankType.EType.User, "N", 71, ProgramBank.SynthesisType.Unknown, "HD-1 sounds"));  // 13

            Add(new NautilusProgramBank(
                this, BankType.EType.UserExtended, "O", 72, ProgramBank.SynthesisType.Unknown, "Initialized EXi programs")); // 14

            Add(new NautilusProgramBank(
                this, BankType.EType.UserExtended, "P", 73, ProgramBank.SynthesisType.Unknown, "Initialized EXi Programs")); // 15
            
            Add(new NautilusProgramBank(
                this, BankType.EType.UserExtended, "Q", 74, ProgramBank.SynthesisType.Unknown, "Initialized EXi Programs")); // 16

            Add(new NautilusProgramBank(
                this, BankType.EType.UserExtended, "R", 75, ProgramBank.SynthesisType.Unknown, "Initialized EXi Programs HD-1 Programs")); // 17
            
            Add(new NautilusProgramBank(
                this, BankType.EType.UserExtended, "S", 76, ProgramBank.SynthesisType.Unknown, "Initialized EXi Programs HD - 1 Programs")); // 18

            Add(new NautilusProgramBank(
                this, BankType.EType.UserExtended, "T", 77, ProgramBank.SynthesisType.Unknown, "Initialized EXi Programs HD - 1 Programs")); // 18

            //Add(new NautilusGmProgramBank(this, ProgramBank.ListSubType.Gm, "g(1)", 7,  "GM2 Main programs"));             // [7]
            //Add(new NautilusGmProgramBank(this, ProgramBank.ListSubType.Gm, "g(2)", 8,  "GM2 Main programs"));             // [8]
            //Add(new NautilusGmProgramBank(this, ProgramBank.ListSubType.Gm, "g(3)", 9,  "GM2 Main programs"));             // [9]
            //Add(new NautilusGmProgramBank(this, ProgramBank.ListSubType.Gm, "g(4)", 10, "GM2 Main programs"));            // [10]
            //Add(new NautilusGmProgramBank(this, ProgramBank.ListSubType.Gm, "g(5)", 11, "GM2 Main programs"));            // [11]
            //Add(new NautilusGmProgramBank(this, ProgramBank.ListSubType.Gm, "g(6)", 12, "GM2 Main programs"));            // [12]
            //Add(new NautilusGmProgramBank(this, ProgramBank.ListSubType.Gm, "g(7)", 13, "GM2 Main programs"));            // [13]
            //Add(new NautilusGmProgramBank(this, ProgramBank.ListSubType.Gm, "g(8)", 14, "GM2 Main programs"));            // [14]
            //Add(new NautilusGmProgramBank(this, ProgramBank.ListSubType.Gm, "g(9)", 15, "GM2 Main programs"));            // [15]
            //Add(new NautilusGmProgramBank(this, ProgramBank.ListSubType.Gm, "g(d)", 16, "GM2 Main programs"));            // [16]

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
