using System;
using System.Diagnostics;
using System.Globalization;

// (c) 2011 Michel Keijzers

namespace PcgTools.Model.Common.Synth.OldParameters
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class ParameterValues
    {
        /// <summary>
        /// 
        /// </summary>
        public const int MidiChannelGch = 16;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="parameterName"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string GetStringValue(ParameterNames.TimbreParameterName parameterName, int value)
        {
            string str;

            switch (parameterName)
            {
                case ParameterNames.TimbreParameterName.MidiChannel:
                    str = GetMidiChannelString(value);
                    break;

                case ParameterNames.TimbreParameterName.TopKey: // Fall through
                case ParameterNames.TimbreParameterName.BottomKey:
                    str = GetKeyString(value);
                    break;

                case ParameterNames.TimbreParameterName.Transpose:
                    str = GetTransposeString(value);
                    break;

                case ParameterNames.TimbreParameterName.Detune:
                    str = GetDetuneString(value);
                    break;

                case ParameterNames.TimbreParameterName.BendRange:
                    str = GetBendRangeString(value);
                    break;

                case ParameterNames.TimbreParameterName.Portamento:
                    str = GetPortamentoString(value);
                    break;

                default:
                    throw new ApplicationException("No value available for parameter.");
            }
            return str;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private static string GetMidiChannelString(int value)
        {
            Debug.Assert((value >= 0) && (value <= 16));

            return value < MidiChannelGch ? string.Format("{0, 2}", value + 1) : "Gch";
        }


        /// <summary>
        /// 0 = C-1 ... 127 = G9.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private static string GetKeyString(int value)
        {
            var notes = new[] {"C", "C#", "D", "D#", "E", "F", "F#", "G", "G#", "A", "A#", "B"};
            return string.Format("{0,-2}{1,2}", notes[value%12], value/12 - 1);
        }


        /// <summary>
        /// -60..+60 for Kronos, Oasys, -24..+24 for others (but not taken into account)
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private static string GetTransposeString(int value)
        {
            return ((sbyte) value).ToString(CultureInfo.InvariantCulture);
        }


        /// <summary>
        /// -1200..+1200
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private static string GetDetuneString(int value)
        {
            return ((short) value).ToString(CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// -25=PRG, -24..+24 = bend range
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private static string GetBendRangeString(int value)
        {
            value = (sbyte) value;
            return (value == -25) ? "Prg" : value.ToString(CultureInfo.InvariantCulture);
        }


        /// <summary>
        ///  -1=PRG, 0=Off, 1..127 = portamento
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private static string GetPortamentoString(int value)
        {
            value = (sbyte) value;
            return (value == -1) ? "Prg" : ((value == 0) ? "Off" : value.ToString(CultureInfo.InvariantCulture));
        }
    }
}