﻿using System;
using System.Collections.Generic;
using System.Linq;
using Common.Mvvm;
using PcgTools.PcgToolsResources;

namespace PcgTools.Model.Common.Synth.MemoryAndFactory
{
    /// <summary>
    /// 
    /// </summary>
    public class Models : ObservableCollectionEx<MemoryAndFactory.Model>
    {
        /// <summary>
        /// 
        /// </summary>
        public enum EOsVersion
        {
            // ReSharper disable InconsistentNaming
            EOsVersionKronos10_11,
            EOsVersionKronos15_16,
            EOsVersionKronos2x,
            EOsVersionKronos3x,
            EOsVersionOasys,

            EOsVersionKrome,
            EOsVersionKross,

            EOsVersionM1,

            EOsVersionM3_1X,
            EOsVersionM3_20,

            EOsVersionM3R,

            EOsVersionM50,
            
            EOsVersionMicroStation,

            EOsVersionMicroKorgXl,
            EOsVersionMicroKorgXlPlus,

            EOsVersionMs2000,

            EOsVersionTritonExtreme,
            EOsVersionTritonTrClassicStudioRack,
            EOsVersionTritonKarma,
            EOsVersionTritonLe,

            EOsVersionTrinityV2, // Solo: S Bank
            EOsVersionTrinityV3,  // Moss: M Bank

            EOsVersionTSeries,

            EOsVersionXSeries,

            EOsVersionZ1,

            EOsVersionZeroSeries, // 01W etc
            EosVersionZero3Rw // 03R/W
            // ReSharper restore InconsistentNaming
        }


        /// <summary>
        /// </summary>
        public enum EModelType
        {
            Kronos,
            Oasys,
            M1,
            M3,
            M3R,
            M50,
            MicroKorgXl,        // (mkxl_all)
            MicroKorgXlPlus,    // (mkxlp_prog, mkxlp_all)
            MicroStation,
            Ms2000,             // (prg)
            Krome,
            Kross,
            TritonExtreme,
            TritonTrClassicStudioRack,
            TritonLe,
            TritonKarma,
            Trinity,
            // ReSharper disable once InconsistentNaming
            TSeries,
            XSeries,
            Z1,
            ZeroSeries,          // 01/W etc
            Zero3Rw              // 03R/W
        }


        /// <summary>
        /// Singleton.
        /// </summary>
        private Models()
        {
            Fill();
        }


        /// <summary>
        /// 
        /// </summary>
        private static Models _instance;


        /// <summary>
        /// 
        /// </summary>
        private static IEnumerable<MemoryAndFactory.Model> Instance
        {
            get { return _instance ?? (_instance = new Models()); }
        }


        /// <summary>
        /// 
        /// </summary>
        private void Fill()
        {
            Add(new MemoryAndFactory.Model(EModelType.Kronos, EOsVersion.EOsVersionKronos10_11, Strings.Version1011));
            Add(new MemoryAndFactory.Model(EModelType.Kronos, EOsVersion.EOsVersionKronos15_16, Strings.Version1516));
            Add(new MemoryAndFactory.Model(EModelType.Kronos, EOsVersion.EOsVersionKronos2x, Strings.Version2x));
            Add(new MemoryAndFactory.Model(EModelType.Kronos, EOsVersion.EOsVersionKronos3x, Strings.Version3x));
            Add(new MemoryAndFactory.Model(EModelType.Oasys, EOsVersion.EOsVersionOasys, String.Empty));
            Add(new MemoryAndFactory.Model(EModelType.Krome, EOsVersion.EOsVersionKrome, String.Empty));
            Add(new MemoryAndFactory.Model(EModelType.Kross, EOsVersion.EOsVersionKross, String.Empty));
            Add(new MemoryAndFactory.Model(EModelType.M1, EOsVersion.EOsVersionM1, String.Empty));
            Add(new MemoryAndFactory.Model(EModelType.M3, EOsVersion.EOsVersionM3_1X, Strings.Version1x));
            Add(new MemoryAndFactory.Model(EModelType.M3, EOsVersion.EOsVersionM3_20, Strings.Version1x));
            Add(new MemoryAndFactory.Model(EModelType.M3R, EOsVersion.EOsVersionM3R, String.Empty));
            Add(new MemoryAndFactory.Model(EModelType.M50, EOsVersion.EOsVersionM50, String.Empty));
            Add(new MemoryAndFactory.Model(EModelType.Ms2000, EOsVersion.EOsVersionMs2000, String.Empty));
            Add(new MemoryAndFactory.Model(EModelType.MicroKorgXl, EOsVersion.EOsVersionMicroKorgXl, String.Empty));
            Add(new MemoryAndFactory.Model(EModelType.MicroKorgXlPlus, EOsVersion.EOsVersionMicroKorgXlPlus, String.Empty));
            Add(new MemoryAndFactory.Model(EModelType.MicroStation, EOsVersion.EOsVersionMicroStation, String.Empty));
            Add(new MemoryAndFactory.Model(EModelType.TritonExtreme, EOsVersion.EOsVersionTritonExtreme, String.Empty));
            Add(new MemoryAndFactory.Model(EModelType.TritonTrClassicStudioRack, EOsVersion.EOsVersionTritonTrClassicStudioRack, String.Empty));
            Add(new MemoryAndFactory.Model(EModelType.TritonKarma, EOsVersion.EOsVersionTritonKarma, String.Empty));
            Add(new MemoryAndFactory.Model(EModelType.TritonLe, EOsVersion.EOsVersionTritonLe, String.Empty));
            Add(new MemoryAndFactory.Model(EModelType.Trinity, EOsVersion.EOsVersionTrinityV2, Strings.VersionV2));
            Add(new MemoryAndFactory.Model(EModelType.Trinity, EOsVersion.EOsVersionTrinityV3, Strings.VersionV3));
            Add(new MemoryAndFactory.Model(EModelType.TSeries, EOsVersion.EOsVersionTSeries, String.Empty));
            Add(new MemoryAndFactory.Model(EModelType.Z1, EOsVersion.EOsVersionZ1, String.Empty));
            Add(new MemoryAndFactory.Model(EModelType.ZeroSeries, EOsVersion.EOsVersionZeroSeries, String.Empty));
            Add(new MemoryAndFactory.Model(EModelType.Zero3Rw, EOsVersion.EosVersionZero3Rw, String.Empty));
        }
        

        /// <summary>
        /// 
        /// </summary>
        /// <param name="osVersion"></param>
        /// <returns></returns>
        static internal MemoryAndFactory.Model Find(EOsVersion osVersion)
        {
            return Instance.First(model => model.OsVersion == osVersion);
        }
    }
}
