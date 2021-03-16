// (c) Copyright 2011-2019 MiKeSoft, Michel Keijzers, All rights reserved

using System;
using System.Diagnostics;
using System.Linq;
using Common.Utils;
using PcgTools.ClipBoard;
using PcgTools.Model.Common;

using PcgTools.Model.Common.Synth.MemoryAndFactory;
using PcgTools.Model.Common.Synth.Meta;
using PcgTools.Model.Common.Synth.NewParameters;
using PcgTools.Model.Common.Synth.PatchCombis;
using PcgTools.Model.Common.Synth.PatchPrograms;
using PcgTools.Model.Common.Synth.PatchSetLists;

namespace PcgTools.Model.NautilusSpecific.Synth
{
    /// <summary>
    /// 
    /// </summary>
    public class NautilusSetListSlot : SetListSlot
    {
        /// <summary>
        /// // ##3x 27 = color, 28 = volume, ##3X 29 = Transpose 30 = Description offset
        /// </summary>
        /// <param name="setList"></param>
        /// <param name="index"></param>
        public NautilusSetListSlot(SetList setList, int index) : base(setList, index, 28, 30)
        {
        }


        /// <summary>
        /// 
        /// </summary>
        public override void SetParameters()
        {
            _color = null;
        }


        /// <summary>
        /// 
        /// </summary>
        private IIntParameter _color;


        /// <summary>
        /// 
        /// </summary>
        public override IIntParameter Color => _color;


        // Name

        /// <summary>
        /// 
        /// </summary>
        public override string Name
        {
            get
            {
                return GetChars(0, MaxNameLength);
            }

            set
            {
                if (Name != value)
                {
                    SetChars(0, MaxNameLength, value);
                    OnPropertyChanged("Name");
                }
            }
        }


        /// <summary>
        /// 
        /// </summary>
        public override int MaxNameLength => 24;


        // Description.

        /// <summary>
        /// 
        /// </summary>
        public override string Description
        {
            get { return GetChars(DescriptionPcgOffset, MaxDescriptionLength); }
         
            set
            {
                if (Description != value)
                {
                    SetChars(DescriptionPcgOffset, MaxDescriptionLength, value);
                    OnPropertyChanged("Description");
                }
            }
        }


        /// <summary>
        /// 
        /// </summary>
        public override TextSize SelectedTextSize
        {
            get
            {
                return (TextSize)((BitsUtil.GetBits(PcgRoot.Content, ByteOffset + 29, 4, 4) << 2) + // MSB 1 bits
                                     BitsUtil.GetBits(PcgRoot.Content, ByteOffset + 24, 7, 6)); // LSB 2 bits
            }

            set
            {
                if (SelectedTextSize != value)
                {
                    BitsUtil.SetBits(PcgRoot.Content, ByteOffset + 29, 4, 4, (int)value >> 2); // MSB 1 bits
                    BitsUtil.SetBits(PcgRoot.Content, ByteOffset + 24, 7, 6, (int)value & 0x03); // LSB 2 bits
                    OnPropertyChanged("SelectedTextSize");
                }
            }
        }


        /// <summary>
        /// 
        /// </summary>
        public override int Volume
        {
            get { return GetInt(VolumePcgOffset, 1); }

            set
            {
                if (Volume != value)
                {
                    SetInt(VolumePcgOffset, 1, value);
                    OnPropertyChanged("Volume");
                }
            }
        }


        /// <summary>
        /// 
        /// </summary>
        public override int Transpose
        {
            get
            {
                return BitsUtil.ToSignedBit(6,
                      (BitsUtil.GetBits(PcgRoot.Content, ByteOffset + 25, 7, 5) << 3) + // MSB 3 bits
                       BitsUtil.GetBits(PcgRoot.Content, ByteOffset + 29, 7, 5)); // LSB 3 bits
            }
            set
            {
                if (Transpose != value)
                {
                    if (value < 0)
                    {
                        value += 32;
                        BitsUtil.SetBit(PcgRoot.Content, ByteOffset + 25, 7); // Set sign bit.
                        BitsUtil.SetBits(PcgRoot.Content, ByteOffset + 25, 6, 5, (value) >> 3); // MSB 3 bits, bit 7 already set.
                        BitsUtil.SetBits(PcgRoot.Content, ByteOffset + 29, 7, 5, (value) & 0x07); // LSB 3 bits
                    }
                    else
                    {
                        BitsUtil.SetBits(PcgRoot.Content, ByteOffset + 25, 6, 5, (value) >> 3); // MSB 3 bits, bit 7 alwyas 0 because of +
                        BitsUtil.SetBits(PcgRoot.Content, ByteOffset + 29, 7, 5, (value) & 0x07); // LSB 3 bits
                    }
                    OnPropertyChanged("Transpose");
                }
            }
        }

        
        /// <summary>
        /// 
        /// </summary>
        public override int MaxDescriptionLength => 512;


        // ListSubType

        /// <summary>
        /// 
        /// </summary>
        public override PatchType SelectedPatchType
        {
            get
            {
                return (PatchType)BitsUtil.GetBits(PcgRoot.Content, TypeOffset, 1, 0);
            }
            set
            {
                BitsUtil.SetBits(PcgRoot.Content, TypeOffset, 1, 0, (int)value);
            }
        }


        /// <summary>
        /// 
        /// </summary>
        protected override IBank UsedProgramBank => PcgRoot.ProgramBanks.GetBankWithPcgId(Util.GetBits(PcgRoot.Content,
            DefaultBankOffset, 4, 0));


        /// <summary>
        /// 
        /// </summary>
        protected override IBank UsedCombiBank => PcgRoot.CombiBanks[Util.GetBits(PcgRoot.Content,
           DefaultBankOffset, 4, 0)];


        /// <summary>
        /// 
        /// </summary>
        public override IPatch UsedPatch
        {
            get
            {
                switch (SelectedPatchType)
                {
                    case PatchType.Program:
                        return GetUsedProgram;

                    case PatchType.Combi:
                        return GetUsedCombi;

                    case PatchType.Song:
                        break;

                    default:
                        throw new NotSupportedException("Illegal switch");
                }

                return null;
            }
            set
            {
                if (value is IProgram)
                {
                    SelectedPatchType = PatchType.Program;
                }
                else if (value is ICombi)
                {
                    SelectedPatchType = PatchType.Combi;
                }

                switch (SelectedPatchType)
                {
                    case PatchType.Program: // Fall through
                        SetUsedProgram(value);
                        break;

                    case PatchType.Combi:
                        SetUsedCombi(value);
                        break;

                    case PatchType.Song:
                        throw new NotSupportedException("Not implemented");

                    default:
                        throw new NotSupportedException("Illegal switch");
                }
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        private void SetUsedCombi(IPatch value)
        {
            var combi = (NautilusCombi) value;
            var combiBank = (NautilusCombiBank) (value.Parent);
            var combiBanks = (NautilusCombiBanks) combiBank.Parent;

            // Set bank.
            Util.SetInt(PcgRoot, PcgRoot.Content, DefaultBankOffset, 1, combiBanks.BankCollection.IndexOf(combiBank));

            // Set combi.
            Util.SetInt(PcgRoot, PcgRoot.Content, DefaultPatchOffset, 1, combi.Index);

            combi.RaisePropertyChanged(string.Empty, false);
            RaisePropertyChanged(string.Empty, false);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        private void SetUsedProgram(IPatch value)
        {
            var program = (NautilusProgram) value;
            var bank = (NautilusProgramBank) (value.Parent);

            SetUsedProgramBank(bank);
            SetUsedProgram(bank, program);

            program.RaisePropertyChanged(string.Empty, false);
            RaisePropertyChanged(string.Empty, false);
        }


        /// <summary>
        /// Set used program.
        /// </summary>
        /// <param name="bank"></param>
        /// <param name="program"></param>
        private void SetUsedProgram(NautilusProgramBank bank, NautilusProgram program)
        {
            Util.SetInt(PcgRoot, PcgRoot.Content, DefaultPatchOffset, 1, program.Index);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="bank"></param>
        private void SetUsedProgramBank(NautilusProgramBank bank)
        {
            Util.SetInt(PcgRoot, PcgRoot.Content, DefaultBankOffset, 1, bank.PcgId);
        }


        /// <summary>
        /// 
        /// </summary>
        private IPatch GetUsedCombi
        {
            get
            {
                var combiId = Util.GetInt(PcgRoot.Content, DefaultPatchOffset, 1);

                var combi = UsedCombiBank[combiId];
                if (!((IBank) (combi.Parent)).IsWritable)
                {
                    // Try to find it in the master file.
                    var masterPcgMemory = MasterFiles.MasterFiles.Instances.FindMasterPcg(Root.Model);
                    if ((masterPcgMemory != null) && (masterPcgMemory.FileName != Root.FileName))
                    {
                        var combiBank = masterPcgMemory.CombiBanks.BankCollection.FirstOrDefault(
                            item => (item.Id == UsedCombiBank.Id) && item.IsFilled);
                        return combiBank == null ? null : combiBank[combiId] as Combi;
                    }
                }

                return combi;
            }
        }


        /// <summary>
        /// 
        /// </summary>
        private IPatch GetUsedProgram
        {
            get
            {
                var programId = Util.GetInt(PcgRoot.Content, DefaultPatchOffset, 1);

                var program = UsedProgramBank[programId];
                if (!((IBank) (program.Parent)).IsWritable && ((ProgramBank) (program.Parent)).Type != BankType.EType.Gm)
                {
                    // Try to find it in the master file.
                    var masterPcgMemory = MasterFiles.MasterFiles.Instances.FindMasterPcg(Root.Model);
                    if ((masterPcgMemory != null) && (masterPcgMemory.FileName != Root.FileName))
                    {
                        var programBank = masterPcgMemory.ProgramBanks.BankCollection.FirstOrDefault(
                            item => (item.PcgId == UsedProgramBank.PcgId) && item.IsFilled);
                        return programBank == null ? null : programBank[programId] as Program;
                    }
                }

                return program;
            }
        }


        /// <summary>
        /// 
        /// </summary>
        public override void Clear()
        {
            base.Clear();
            PcgRoot.Content[TypeOffset] = (int)PatchType.Program;

            PcgRoot.Content[DefaultBankOffset] = 0; // Program bank I-A.
            PcgRoot.Content[DefaultPatchOffset] = 0; // index 0

            RaisePropertyChanged(string.Empty, false);
        }


        /// <summary>
        /// Used for non OS 1.5/1.6.
        /// </summary>
        private int DefaultBankOffset => ByteOffset + 25;


  

        /// <summary>
        /// </summary>
        private int  DefaultPatchOffset => ByteOffset + 26;


        /// <summary>
        /// </summary>
        private int TypeOffset => ByteOffset + 24;

        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="otherPatch"></param>
        /// <param name="includingName"></param>
        /// <param name="maxDiffs"></param>
        /// <returns></returns>
        public override int CalcByteDifferences(IPatch otherPatch, bool includingName, int maxDiffs)
        {
            var diffs = base.CalcByteDifferences(otherPatch, includingName, maxDiffs);
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
            var otherSetListSlot = otherPatch as ClipBoardSetListSlot;
            Debug.Assert(otherSetListSlot != null);

            var diffs = base.CalcByteDifferences(otherPatch, includingName, maxDiffs);
            return diffs;
        }
    }
}
