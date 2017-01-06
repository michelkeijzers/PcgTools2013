// (c) Copyright 2011-2016 MiKeSoft, Michel Keijzers, All rights reserved


using PcgTools.Model.Common.Synth.MemoryAndFactory;
using PcgTools.Model.MSpecific.Pcg;
using PcgTools.Model.MicroStationSpecific.Synth;


namespace PcgTools.Model.MicroStationSpecific.Pcg
{
    /// <summary>
    /// 
    /// </summary>
    public class MicroStationPcgMemory : MPcgMemory
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileName"></param>
        public MicroStationPcgMemory(string fileName)
            : base(fileName, Models.EModelType.MicroStation)
        {
            CombiBanks = new MicroStationCombiBanks(this);
            ProgramBanks = new MicroStationProgramBanks(this);
            SetLists = null;
            WaveSequenceBanks = null;
            DrumKitBanks = new MicroStationDrumKitBanks(this);
            DrumPatternBanks = null;
            Global = new MicroStationGlobal(this);
            Model = Models.Find(Models.EOsVersion.EOsVersionMicroStation);
        }
    }
}
