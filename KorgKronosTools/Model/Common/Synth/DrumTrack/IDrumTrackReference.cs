using PcgTools.Model.Common.Synth.PatchDrumPatterns;
using System.Collections.Generic;

namespace PcgTools.Model.Common.Synth.PatchPrograms
{
    /// <summary>
    /// Interface for patches (programs/combis) using a drum track (containing of a (drum track) program and a (drum track) pattern.
    /// </summary>
    public interface IDrumTrackReference
    {
        /// <summary>
        /// Drum pattern assigned to the program.
        /// </summary>
        List<IDrumPattern> UsedDrumTrackPatterns { get; }
    }
}
