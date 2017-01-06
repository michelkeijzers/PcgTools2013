
using System;
using PcgTools.Model.Common.Synth.Meta;
using PcgTools.Model.Common.Synth.PatchDrumPatterns;
using PcgTools.Model.Common.Synth.PatchSetLists;

// (c) 2011 Michel Keijzers

namespace PcgTools.Model.MSpecific.Synth
{
    /// <summary>
    /// 
    /// </summary>
    public class MDrumPattern : DrumPattern
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="drumPatternBank"></param>
        /// <param name="index"></param>
        public MDrumPattern(DrumPatternBank drumPatternBank, int index)
            : base(drumPatternBank, index)
        {
        }


        /// <summary>
        /// Sets parameters after initialization.
        /// </summary>
        public override void SetParameters()
        {
        }


        /// <summary>
        /// Used for OS 1.5/1.6.
        /// </summary>
        public int Drk2BankOffset
        {
            get
            {
                return (((DrumPatternBanks)(Parent.Parent)).Drk2PcgOffset +
                        128 * Convert.ToInt16(((DrumPatternBank)Parent).Id) + Index);
            }
        }


        /// <summary>
        /// Used for OS 1.5/1.6.
        /// </summary>
        public int Drk2PatchOffset
        {
            // first 128 = # banks, 2nd/3th 128 = slots/bank
            get
            {
                return 128 * 128 + ((MDrumPatternBanks)(Parent.Parent)).Drk2PcgOffset +
                    128 * Convert.ToInt16(((SetList)Parent).Id) + Index;
            }
        }

        
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
        public override int MaxNameLength
        {
            get { return 24; }
        }


        /// <summary>
        /// 
        /// </summary>
        public override bool IsEmptyOrInit
        {
            get
            {
                return ((Name == String.Empty) ||
                    Name.StartsWith("DrumPattern      0") ||
                    (Name.Contains("Init") && Name.Contains("Drum") && Name.Contains("Pattern")));
            }
        }
    }
}
