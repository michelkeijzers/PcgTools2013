using System;
using PcgTools.Model.Common.Synth.PatchWaveSequences;
using PcgTools.Model.KronosSpecific.Synth;

// (c) 2011 Michel Keijzers

namespace PcgTools.Model.NautilusSpecific.Synth
{
    /// <summary>
    /// 
    /// </summary>
    public class NautilusWaveSequence : KronosWaveSequence
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="waveSeqBank"></param>
        /// <param name="index"></param>
        public NautilusWaveSequence(WaveSequenceBank waveSeqBank, int index)
            : base(waveSeqBank, index)
        {
        }


        /// <summary>
        /// Sets parameters after initialization.
        /// </summary>
        public override void SetParameters()
        {
        }
    }
}
