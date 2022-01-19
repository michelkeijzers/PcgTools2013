// (c) Copyright 2011-2019 MiKeSoft, Michel Keijzers, All rights reserved

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using PcgTools.ClipBoard;
using PcgTools.Model.Common.Synth.Meta;
using PcgTools.Model.Common.Synth.OldParameters;
using PcgTools.Model.Common.Synth.PatchDrumKits;
using PcgTools.Model.Common.Synth.PatchDrumPatterns;
using PcgTools.Model.Common.Synth.PatchPrograms;
using PcgTools.Model.Common.Synth.PatchWaveSequences;
using PcgTools.Model.KronosSpecific.Synth;

namespace PcgTools.Model.NautilusSpecific.Synth
{
    /// <summary>
    /// 
    /// </summary>
    public class NautilusProgram : KronosProgram
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="programBank"></param>
        /// <param name="index"></param>
        public NautilusProgram(IProgramBank programBank, int index)
            : base(programBank, index)
        {
        }


        /// <summary>
        /// Sets parameters after initialization.
        /// </summary>
        public override void SetParameters()
        {
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public override IParameter GetParam(ParameterNames.ProgramParameterName name)
        {
            IParameter parameter;

            switch (name)
            {
                case ParameterNames.ProgramParameterName.OscMode: // In the documentation called fully Oscillator Mode
                    parameter = EnumParameter.Instance.Set(Root, Root.Content, ByteOffset + 2552, 2, 0,
                        new List<string> { "Single", "Double", "Drums", "- (EXI)", "- (Unused)", "Double Drums" }, this);
                    break;

                case ParameterNames.ProgramParameterName.Category:
                    parameter = IntParameter.Instance.Set(Root, Root.Content, ByteOffset + 2562, 4, 0, false, this);
                    break;

                case ParameterNames.ProgramParameterName.SubCategory:
                    parameter = IntParameter.Instance.Set(Root, Root.Content, ByteOffset + 2562, 7, 5, false, this);
                    break;

                case ParameterNames.ProgramParameterName.Favorite:
                    parameter = BoolParameter.Instance.Set(Root, Root.Content, ByteOffset + 2552, 5, this);
                    break;

                case ParameterNames.ProgramParameterName.Scene1DrumTrackPatternNumber:
                   parameter = WordParameter.Instance.Set(Root, Root.Content, ByteOffset + 2460, true, 1, this);
                   break;

                case ParameterNames.ProgramParameterName.Scene1DrumTrackPatternBank:
                    parameter = IntParameter.Instance.Set(Root, Root.Content, ByteOffset + 2462, 1, 0, false, this);
                    break;

                case ParameterNames.ProgramParameterName.Scene2DrumTrackPatternNumber:
                    parameter = WordParameter.Instance.Set(Root, Root.Content, ByteOffset + 2488, true, 1, this);
                    break;

                case ParameterNames.ProgramParameterName.Scene2DrumTrackPatternBank:
                    parameter = IntParameter.Instance.Set(Root, Root.Content, ByteOffset + 2490, 3, 0, false, this);
                    break;

                case ParameterNames.ProgramParameterName.Scene3DrumTrackPatternNumber:
                    parameter = WordParameter.Instance.Set(Root, Root.Content, ByteOffset + 2516, true, 1, this);
                    break;

                case ParameterNames.ProgramParameterName.Scene3DrumTrackPatternBank:
                    parameter = IntParameter.Instance.Set(Root, Root.Content, ByteOffset + 2518, 3, 0, false, this);
                    break;

                case ParameterNames.ProgramParameterName.Scene4DrumTrackPatternNumber:
                    parameter = WordParameter.Instance.Set(Root, Root.Content, ByteOffset + 2544, true, 1, this);
                    break;

                case ParameterNames.ProgramParameterName.Scene4DrumTrackPatternBank:
                    parameter = IntParameter.Instance.Set(Root, Root.Content, ByteOffset + 2546, 3, 0, false, this);
                    break;

                case ParameterNames.ProgramParameterName.DrumTrackProgramNumber:
                    parameter = IntParameter.Instance.Set(Root, Root.Content, ByteOffset + 2682, 7, 0, false, this);
                    break;

                case ParameterNames.ProgramParameterName.DrumTrackProgramBank:
                    parameter = IntParameter.Instance.Set(Root, Root.Content, ByteOffset + 2683, 3, 0, false, this);
                    break;

                default:
                    parameter = base.GetParam(name);
                    break;
            }
            return parameter;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="otherPatch"></param>
        /// <param name="includingName"></param>
        /// <param name="maxDiffs"></param>
        /// <returns></returns>
        public override int CalcByteDifferences(IPatch otherPatch, bool includingName, int maxDiffs)
        {
            int diffs = base.CalcByteDifferences(otherPatch, includingName, maxDiffs);
            return diffs;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="otherPatch"></param>
        /// <param name="includingName"></param>
        /// <param name="maxDiffs"></param>
        /// <returns></returns>
        public override int CalcByteDifferences(IClipBoardPatch otherPatch, bool includingName, int maxDiffs)
        {
            ClipBoardProgram otherProgram = otherPatch as ClipBoardProgram;
            Debug.Assert(otherProgram != null);

            int diffs = base.CalcByteDifferences(otherPatch, includingName, maxDiffs);
            return diffs;
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="osc"></param>
        /// <param name="zone"></param>
        /// <returns></returns>
        private EMode GetZoneMsType(int osc, int zone)
        {
            int offset = ByteOffset + 2774 + osc * (3240 - 2774) +
                         zone * (2796 - 2774);

            IntParameter parameter = new IntParameter();
            parameter.Set(Root, Root.Content, offset, 1, 0, false, null);
            int value = parameter.Value;
            EMode mode;
            switch (value)
            {
                case 0:
                    mode = EMode.Off;
                    break;

                case 1:
                    mode = EMode.Sample;
                    break;

                case 2:
                    mode = EMode.WaveSequence;
                    break;

                default:
                    mode = EMode.Off;
                    // Not supported, selected when copy drum kit from Nautilus OS3.0 file.
                    // throw new ApplicationException("Illegal case");
                    break;
            }

            return mode;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="osc"></param>
        /// /// <param name="zone"></param>
        /// <returns></returns>
        protected override int GetZoneMsByteOffset(int osc, int zone)
        {
            return ByteOffset + 2774 + osc * (3240 - 2774) + zone * (2796 - 2774);
        }


        /// <summary>
        /// 
        /// </summary>
        /// /// <param name="osc"></param>
        /// <param name="zone"></param>
        /// <returns></returns>
        public override IWaveSequence GetUsedWaveSequence(int osc, int zone)
        {
            IWaveSequence waveSequence = null;
            if (GetZoneMsType(osc, zone) == EMode.WaveSequence)
            {
                IntParameter parameter = new IntParameter();
                int waveSequenceByteOffset = GetZoneMsByteOffset(osc, zone);
                int bankIndex;
                int patchIndex;

                parameter.Set(Root, Root.Content, waveSequenceByteOffset + 16, 2, 0, false, this);
                int waveSequenceIndex = parameter.Value;

                GetWaveSequenceIndices(waveSequenceIndex, out bankIndex, out patchIndex);
                waveSequence = (IWaveSequence)PcgRoot.WaveSequenceBanks[bankIndex].Patches[patchIndex];
            }

            return waveSequence;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="waveSequenceIndex"></param>
        /// <param name="bankIndex"></param>
        /// <param name="patchIndex"></param>
        private void GetWaveSequenceIndices(int waveSequenceIndex, out int bankIndex, out int patchIndex)
        {
            bankIndex = 0;
            patchIndex = waveSequenceIndex;

            while (waveSequenceIndex >= PcgRoot.WaveSequenceBanks[bankIndex].Patches.Count)
            {
                patchIndex -= PcgRoot.WaveSequenceBanks[bankIndex].Patches.Count;
                bankIndex++;
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="waveSequence"></param>
        /// <returns></returns>
        private int GetWaveSequenceIndex(IWaveSequence waveSequence)
        {
            IWaveSequenceBank bank = (IWaveSequenceBank)waveSequence.Parent;

            int index = PcgRoot.WaveSequenceBanks.BankCollection.TakeWhile(
                bankIterator => bank != bankIterator).Sum(bankIterator => bankIterator.Patches.Count);

            index += waveSequence.Index;

            return index;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="osc"></param>
        /// /// <param name="zone"></param>
        /// <param name="waveSequence"></param>
        public override void SetWaveSequence(int osc, int zone, IWaveSequence waveSequence)
        {
            IntParameter parameter = new IntParameter();

            parameter.SetMultiBytes(Root, Root.Content, GetZoneMsByteOffset(osc, zone), 2, false, false, null);
            parameter.Value = GetWaveSequenceIndex(waveSequence);
        }


        /// <summary>
        /// Returns used drum kits. 
        /// If OSC Mode is Single/Drums        => use MS Bank/Number as Drum Kit (if MS Type == Drums), for OSC 1      , zone 1-8 (if used)
        /// If OSC Mode is Double/Double Drums => use MS Bank/Number as Drum Kit (if MS Type == Drums), for OSC 1 and 2, zone 1-8 (if used)
        /// </summary>
        public override List<IDrumKit> UsedDrumKits
        {
            get
            {
                string param = "Drums";

                try
                {
                    param = GetParam(ParameterNames.ProgramParameterName.OscMode).Value;
                }
                catch
                {
                    // N_TODO
                }

                // Only the first MS is used.
                List<IDrumKit> usedDrumKits = new List<IDrumKit>();
                if ((param == "Drums") || (param == "Double Drums"))
                {
                    usedDrumKits.Add(GetUsedDrumKit(0, 0));
                }

                if (param == "Double Drums")
                {
                    usedDrumKits.Add(GetUsedDrumKit(1, 0));
                }

                return usedDrumKits;
            }
        }


        /// <summary>
        /// 
        /// </summary>
        override public List<IDrumPattern> UsedDrumTrackPatterns
        {
            get
            {
                List<IDrumPattern> patterns = new List<IDrumPattern>();
                AddUsedDramTrackPattern(patterns, 
                    ParameterNames.ProgramParameterName.Scene1DrumTrackPatternBank,
                    ParameterNames.ProgramParameterName.Scene1DrumTrackPatternNumber);
                AddUsedDramTrackPattern(patterns,
                    ParameterNames.ProgramParameterName.Scene2DrumTrackPatternBank,
                    ParameterNames.ProgramParameterName.Scene2DrumTrackPatternNumber);
                AddUsedDramTrackPattern(patterns,
                    ParameterNames.ProgramParameterName.Scene3DrumTrackPatternBank,
                    ParameterNames.ProgramParameterName.Scene3DrumTrackPatternNumber);
                AddUsedDramTrackPattern(patterns,
                    ParameterNames.ProgramParameterName.Scene4DrumTrackPatternBank,
                    ParameterNames.ProgramParameterName.Scene4DrumTrackPatternNumber);
                return patterns;
            }
        }

        private void AddUsedDramTrackPattern(List<IDrumPattern> patterns, ParameterNames.ProgramParameterName bankName,
            ParameterNames.ProgramParameterName numberName)
        {
            IParameter paramBank = GetParam(bankName);
            if (paramBank != null)
            {
                IDrumPatternBank bank = (IDrumPatternBank)PcgRoot.DrumPatternBanks.GetBankWithPcgId((int)(paramBank.Value));

                IParameter paramNumber = GetParam(numberName);
                if (paramNumber != null)
                {
                    //MK patterns.Add(bank.Patches[paramNumber.Value]);
                }
            }
        }
    }
}