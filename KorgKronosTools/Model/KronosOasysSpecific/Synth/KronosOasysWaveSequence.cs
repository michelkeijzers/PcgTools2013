using System;


// (c) 2011 Michel Keijzers
using PcgTools.Model.Common.Synth.PatchWaveSequences;

namespace PcgTools.Model.KronosOasysSpecific.Synth
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class KronosOasysWaveSequence : WaveSequence
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="waveSeqBank"></param>
        /// <param name="index"></param>
        protected KronosOasysWaveSequence(IWaveSequenceBank waveSeqBank, int index)
            : base(waveSeqBank, index) 
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
                    (Name == "WaveSequence")) ||
                    ((Name.Contains("Init") && Name.Contains("Wave") && Name.Contains("Sequence")));
            }
        }
    }
}
