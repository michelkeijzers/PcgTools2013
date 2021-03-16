namespace PcgTools.Model.Common.Synth.OldParameters
{
    /// <summary>
    /// Contains parameter names.
    /// </summary>
    public class ParameterNames
    {
        /// <summary>
        /// 
        /// </summary>
        public enum ProgramParameterName
        {
            OscMode, 
            Mode,
            
            Favorite,

            Category,
            SubCategory,

            // Kronos and before
            DrumTrackCommonPatternBank,
            DrumTrackCommonPatternNumber, // Kronos and before

            DrumTrackProgramBank,
            DrumTrackProgramNumber,

            // Nautilus
            Scene1DrumTrackPatternBank,
            Scene1DrumTrackPatternNumber,
            Scene2DrumTrackPatternBank,
            Scene2DrumTrackPatternNumber,
            Scene3DrumTrackPatternBank,
            Scene3DrumTrackPatternNumber,
            Scene4DrumTrackPatternBank,
            Scene4DrumTrackPatternNumber,
        }


        /// <summary>
        /// 
        /// </summary>
        public enum CombiParameterName
        {
            Category,
            SubCategory,
            Favorite,
            Tempo,

            // Kronos and before
            DrumTrackCommonPatternBank,
            DrumTrackCommonPatternNumber,

            // Nautilus
            Scene1DrumTrackPatternBank,
            Scene1DrumTrackPatternNumber,
            Scene2DrumTrackPatternBank,
            Scene2DrumTrackPatternNumber,
            Scene3DrumTrackPatternBank,
            Scene3DrumTrackPatternNumber,
            Scene4DrumTrackPatternBank,
            Scene4DrumTrackPatternNumber,
        }


        /// <summary>
        /// 
        /// </summary>
        public enum TimbreParameterName 
        {
            Status,
            Mute,
            OscMode,
            OscSelect,
            Priority,

            MidiChannel,
            
            Volume,
            
            BottomKey,
            TopKey,
            
            BottomVelocity,
            TopVelocity,

            BendRange,
            Portamento,
            Transpose,
            Detune
        }


        /// <summary>
        /// 
        /// </summary>
        public enum SetListSlotParameterName
        {
        }


        /// <summary>
        /// 
        /// </summary>
        public enum DrumKitParameterName
        {
            Category
        }


        /// <summary>
        /// 
        /// </summary>
        public enum DrumPatternParameterName
        {

        }


        /// <summary>
        /// 
        /// </summary>
        public enum WaveSequencetParameterName
        {

        }
    }
}