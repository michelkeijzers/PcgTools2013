﻿using System.Diagnostics;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PcgTools.Model.Common.Synth.MemoryAndFactory;
using PcgTools.Model.Common.Synth.Meta;
using PcgTools.Model.Common.Synth.PatchCombis;
using PcgTools.Model.Common.Synth.PatchPrograms;
using PcgTools.Model.Common.Synth.PatchSetLists;
using PcgTools.Model.KronosSpecific.Pcg;
using PcgTools.Model.KronosSpecific.Synth;
using PcgTools.Tools;

namespace PCG_Tools_Unittests
{
    [TestClass]
    public class ReferenceChangerTests
    {
        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void ChangeCombi()
        {
            IPcgMemory pcg = CreatePcg();
            IProgram programIa000 = (IProgram) pcg.ProgramBanks[0][0];
            ICombi combiIa000 = (ICombi) (pcg.CombiBanks[0])[0];
            combiIa000.Name = "NonEmpty";

            combiIa000.Timbres.TimbresCollection[0].UsedProgram = programIa000;
            
            // Set most virtual banks loaded to save time.
            foreach (IBank bank in pcg.CombiBanks.BankCollection.Where(
                bank => (bank.Type == BankType.EType.Virtual) && (bank.Id !="V-0A")))
            {
                bank.IsLoaded = false;
            }

            // Run actual test.
            ReferenceChanger referenceChanger = new ReferenceChanger(pcg);
            RuleParser ruleParser = new RuleParser(pcg);
            referenceChanger.ParseRules(ruleParser, "I-A000->I-B000");
            referenceChanger.ChangeReferences();

            Debug.Assert(combiIa000.Timbres.TimbresCollection[0].UsedProgram == pcg.ProgramBanks[1][0]);
        }


        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void ChangeSetListSlot()
        {
            IPcgMemory pcg = CreatePcg();
            IProgram programIa000 = (IProgram)pcg.ProgramBanks[0][0];
            ISetListSlot setListSlot000000 = (ISetListSlot)(pcg.SetLists[0])[0];
            setListSlot000000.SelectedPatchType = SetListSlot.PatchType.Program;
            setListSlot000000.UsedPatch = programIa000;

            ReferenceChanger referenceChanger = new ReferenceChanger(pcg);
            RuleParser ruleParser = new RuleParser(pcg);
            referenceChanger.ParseRules(ruleParser, "I-A000->I-B000");
            referenceChanger.ChangeReferences();

            Debug.Assert(setListSlot000000.UsedPatch == pcg.ProgramBanks[1][0]);
        }


        /// <summary>
        /// Tests not too many patches will be changed.
        /// </summary>
        [TestMethod]
        public void ChangeSetListSlotNotTooMany()
        {
            IPcgMemory pcg = CreatePcg();

            IProgram programIa000 = (IProgram)pcg.ProgramBanks[0][0];
            ISetListSlot setListSlot000000 = (ISetListSlot)(pcg.SetLists[0])[0];
            setListSlot000000.SelectedPatchType = SetListSlot.PatchType.Program;
            setListSlot000000.UsedPatch = programIa000;

            IProgram programIa001 = (IProgram)pcg.ProgramBanks[0][1];
            ISetListSlot setListSlot000001 = (ISetListSlot)(pcg.SetLists[0])[1];
            setListSlot000001.SelectedPatchType = SetListSlot.PatchType.Program;
            setListSlot000001.UsedPatch = programIa001;

            ReferenceChanger referenceChanger = new ReferenceChanger(pcg);
            RuleParser ruleParser = new RuleParser(pcg);
            referenceChanger.ParseRules(ruleParser, "I-A000->I-B000");
            referenceChanger.ChangeReferences();

            Debug.Assert(setListSlot000000.UsedPatch == pcg.ProgramBanks[1][0]); // Changed
            Debug.Assert(setListSlot000001.UsedPatch == programIa001); // Not changed
        }


        /// <summary>
        /// Creates PCG memory.
        /// Byte offsets are non real.
        /// </summary>
        /// <returns></returns>
        private static IPcgMemory CreatePcg()
        {
            IPcgMemory memory = new KronosPcgMemory("test.pcg");
            memory.Model = new Model(Models.EModelType.Kronos, Models.EOsVersion.Kronos3x, "3.0");
            memory.Content = new byte[10000000]; // Enough for timbre parameters

            int byteOffset = 1000;
            
            memory.ProgramBanks = new KronosProgramBanks(memory);
            memory.ProgramBanks.Fill();

            foreach (IBank bank in memory.ProgramBanks.BankCollection)
            {
                bank.IsLoaded = true;

                foreach (IPatch patch in bank.Patches)
                {
                    patch.ByteOffset = byteOffset;
                    byteOffset += 100;
                }
            }
            
            memory.CombiBanks = new KronosCombiBanks(memory);
            memory.CombiBanks.Fill();

            foreach (IBank bank in memory.CombiBanks.BankCollection)
            {
                bank.IsLoaded = true;

                foreach (IPatch patch in bank.Patches)
                {
                    patch.ByteOffset = byteOffset;
                    byteOffset += 100;
                }
            }

            memory.SetLists = new KronosSetLists(memory);
            memory.SetLists.Fill();
            
            foreach (IBank bank in memory.SetLists.BankCollection)
            {
                bank.IsLoaded = true;

                foreach (IPatch patch in bank.Patches)
                {
                    patch.ByteOffset = byteOffset;
                    byteOffset += 100;
                }
            }

            memory.DrumKitBanks = new KronosDrumKitBanks(memory);

            memory.DrumPatternBanks = new KronosDrumPatternBanks(memory);

            memory.WaveSequenceBanks = new KronosWaveSequenceBanks(memory);

            memory.Global = new KronosGlobal(memory);

            
            return memory;
        }
    }
}
