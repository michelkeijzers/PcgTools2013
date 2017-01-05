using System;
using System.Text.RegularExpressions;


// (c) 2011 Michel Keijzers
using PcgTools.Model.Common.Synth.PatchDrumKits;

namespace PcgTools.Model.TrinitySpecific.Synth
{
    /// <summary>
    /// 
    /// </summary>
    public class TrinityDrumKit : DrumKit
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="drumKitBank"></param>
        /// <param name="index"></param>
        public TrinityDrumKit(IDrumKitBank drumKitBank, int index)
            : base(drumKitBank, index)
        {
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
            get { return 16; }
        }


        /// <summary>
        /// 
        /// </summary>
        public override bool IsEmptyOrInit
        {
            get
            {
                // I don't know if this was done by an editor on the PC or on the synth itself...
                return ((Name == String.Empty) || (Name.Contains("Init") && Name.Contains("Drum") && Name.Contains("Kit")) || 
                    (new Regex("Drumkit[0-9]*").IsMatch(Name)));
            }
        }


        /// <summary>
        /// Sets parameters after initialization.
        /// </summary>
        public override void SetParameters()
        {
        }
    }
}
