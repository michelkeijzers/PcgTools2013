// (c) Copyright 2011-2019 MiKeSoft, Michel Keijzers, All rights reserved

using System.Collections.Generic;
using System.Diagnostics;
using PcgTools.ClipBoard;
using PcgTools.Model.Common;

using PcgTools.Model.Common.Synth.Meta;
using PcgTools.Model.Common.Synth.OldParameters;
using PcgTools.Model.Common.Synth.PatchCombis;
using PcgTools.Model.Common.Synth.PatchDrumPatterns;
using PcgTools.Model.KronosOasysSpecific.Synth;
using PcgTools.Model.KronosSpecific.Synth;
using PcgTools.Model.NautilusSpecific.Synth;

namespace PcgTools.Model.NautilusSpecific.Synth
{
    /// <summary>
    /// 
    /// </summary>
    public class NautilusCombi : KronosOasysCombi
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="combiBank"></param>
        /// <param name="index"></param>
        public NautilusCombi(CombiBank combiBank, int index)
            : base(combiBank, index)
        {
            Timbres = new NautilusTimbres(this);
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
        public override Common.Synth.OldParameters.IParameter GetParam(ParameterNames.CombiParameterName name)
        {
            IParameter parameter;

            switch (name)
            {
                case ParameterNames.CombiParameterName.Category:
                    parameter = IntParameter.Instance.Set(Root, Root.Content, ByteOffset + 2620, 4, 0, false, this);
                    break;

                case ParameterNames.CombiParameterName.SubCategory:
                    parameter = IntParameter.Instance.Set(Root, Root.Content, ByteOffset + 2620, 7, 5, false, this);
                    break;

                case ParameterNames.CombiParameterName.Favorite:
                    parameter = BoolParameter.Instance.Set(Root, Root.Content, ByteOffset + 2621, 0, this);
                    break;

                case ParameterNames.CombiParameterName.Tempo:
                    parameter = WordParameter.Instance.Set(Root, Root.Content, ByteOffset + 1350, false, 100, this);
                    break;

                case ParameterNames.CombiParameterName.Scene1DrumTrackPatternNumber:
                    parameter = WordParameter.Instance.Set(Root, Root.Content, ByteOffset + 2476, true, 1, this);
                    break;

                case ParameterNames.CombiParameterName.Scene1DrumTrackPatternBank:
                    parameter = IntParameter.Instance.Set(Root, Root.Content, ByteOffset + 2478, 3, 0, false, this);
                    break;

                case ParameterNames.CombiParameterName.Scene2DrumTrackPatternNumber:
                    parameter = WordParameter.Instance.Set(Root, Root.Content, ByteOffset + 2520, true, 1, this);
                    break;

                case ParameterNames.CombiParameterName.Scene2DrumTrackPatternBank:
                    parameter = IntParameter.Instance.Set(Root, Root.Content, ByteOffset + 2522, 3, 0, false, this);
                    break;

                case ParameterNames.CombiParameterName.Scene3DrumTrackPatternNumber:
                    parameter = WordParameter.Instance.Set(Root, Root.Content, ByteOffset + 2564, true, 1, this);
                    break;

                case ParameterNames.CombiParameterName.Scene3DrumTrackPatternBank:
                    parameter = IntParameter.Instance.Set(Root, Root.Content, ByteOffset + 2566, 3, 0, false, this);
                    break;

                case ParameterNames.CombiParameterName.Scene4DrumTrackPatternNumber:
                    parameter = WordParameter.Instance.Set(Root, Root.Content, ByteOffset + 2608, true, 1, this);
                    break;

                case ParameterNames.CombiParameterName.Scene4DrumTrackPatternBank:
                    parameter = IntParameter.Instance.Set(Root, Root.Content, ByteOffset + 2610, 3, 0, false, this);
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
        override public List<IDrumPattern> UsedDrumTrackPatterns
        {
            get
            {
                List<IDrumPattern> patterns = new List<IDrumPattern>();
                AddUsedDrumTrackPattern(patterns,
                    ParameterNames.CombiParameterName.Scene1DrumTrackPatternBank,
                    ParameterNames.CombiParameterName.Scene1DrumTrackPatternNumber);
                AddUsedDrumTrackPattern(patterns,
                    ParameterNames.CombiParameterName.Scene2DrumTrackPatternBank,
                    ParameterNames.CombiParameterName.Scene2DrumTrackPatternNumber);
                AddUsedDrumTrackPattern(patterns,
                    ParameterNames.CombiParameterName.Scene3DrumTrackPatternBank,
                    ParameterNames.CombiParameterName.Scene3DrumTrackPatternNumber);
                AddUsedDrumTrackPattern(patterns,
                    ParameterNames.CombiParameterName.Scene4DrumTrackPatternBank,
                    ParameterNames.CombiParameterName.Scene4DrumTrackPatternNumber);
                return patterns;
            }
        }

        private void AddUsedDrumTrackPattern(List<IDrumPattern> patterns, ParameterNames.CombiParameterName bankName,
            ParameterNames.CombiParameterName numberName)
        {
            IParameter paramBank = GetParam(bankName);
            if (paramBank != null)
            {
                IDrumPatternBank bank = (IDrumPatternBank)PcgRoot.DrumPatternBanks.GetBankWithPcgId((int)(paramBank.Value));

                if (bank != null)
                {
                    IParameter paramNumber = GetParam(numberName);
                    if (paramNumber != null)
                    {
                        if (paramNumber.Value < bank.Patches.Count)
                        {
                            patterns.Add(bank.Patches[paramNumber.Value]);
                        }
                        else 
                        {
                            // Index is not reset for user bank, continue counting in next bank (assuming there are 2: Preset, User)
                            IBanks banks = (IBanks) bank.Parent;
                            int value = paramNumber.Value - bank.CountPatches;
                            bank = (IDrumPatternBank) banks[banks.IndexOfBank(bank) + 1];
                            patterns.Add((IDrumPattern)bank.Patches[value]);
                        }
                    }
                }
            }
        }
    }
}

