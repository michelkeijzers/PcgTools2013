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
            Nautilus,

            Kronos10_11,
            Kronos15_16,
            Kronos2x,
            Kronos3x,
            Oasys,

            Krome,
            KromeEx,

            Kross,
            Kross2,

            M1,

            M3_1X,
            M3_20,

            M3R,

            M50,
            
            MicroStation,

            MicroKorgXl,
            MicroKorgXlPlus,

            Ms2000,

            TritonExtreme,
            TritonTrClassicStudioRack,
            TritonKarma,
            TritonLe,

            TrinityV2, // Solo: S Bank
            TrinityV3,  // Moss: M Bank

            TSeries,

            XSeries,

            Z1,

            ZeroSeries, // 01W etc
            Zero3Rw // 03R/W
            // ReSharper restore InconsistentNaming
        }


        /// <summary>
        /// </summary>
        public enum EModelType
        {
            Nautilus,
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
            KromeEx,
            Kross,
            Kross2,
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
        private static IEnumerable<MemoryAndFactory.Model> Instance => _instance ?? (_instance = new Models());


        /// <summary>
        /// 
        /// </summary>
        private void Fill()
        {
            Add(new MemoryAndFactory.Model(EModelType.Nautilus, EOsVersion.Nautilus, Strings.Empty));

            Add(new MemoryAndFactory.Model(EModelType.Kronos, EOsVersion.Kronos10_11, Strings.Version1011));
            Add(new MemoryAndFactory.Model(EModelType.Kronos, EOsVersion.Kronos15_16, Strings.Version1516));
            Add(new MemoryAndFactory.Model(EModelType.Kronos, EOsVersion.Kronos2x, Strings.Version2x));
            Add(new MemoryAndFactory.Model(EModelType.Kronos, EOsVersion.Kronos3x, Strings.Version3x));

            Add(new MemoryAndFactory.Model(EModelType.Oasys, EOsVersion.Oasys, string.Empty));

            Add(new MemoryAndFactory.Model(EModelType.Krome, EOsVersion.Krome, string.Empty));
            Add(new MemoryAndFactory.Model(EModelType.KromeEx, EOsVersion.KromeEx, string.Empty));

            Add(new MemoryAndFactory.Model(EModelType.Kross, EOsVersion.Kross, string.Empty));
            Add(new MemoryAndFactory.Model(EModelType.Kross2, EOsVersion.Kross2, string.Empty));

            Add(new MemoryAndFactory.Model(EModelType.M1, EOsVersion.M1, string.Empty));
            Add(new MemoryAndFactory.Model(EModelType.M3, EOsVersion.M3_1X, Strings.Version1x));
            Add(new MemoryAndFactory.Model(EModelType.M3, EOsVersion.M3_20, Strings.Version1x));
            Add(new MemoryAndFactory.Model(EModelType.M3R, EOsVersion.M3R, string.Empty));

            Add(new MemoryAndFactory.Model(EModelType.M50, EOsVersion.M50, string.Empty));

            Add(new MemoryAndFactory.Model(EModelType.Ms2000, EOsVersion.Ms2000, string.Empty));

            Add(new MemoryAndFactory.Model(EModelType.MicroKorgXl, EOsVersion.MicroKorgXl, string.Empty));
            Add(new MemoryAndFactory.Model(EModelType.MicroKorgXlPlus, EOsVersion.MicroKorgXlPlus, string.Empty));

            Add(new MemoryAndFactory.Model(EModelType.MicroStation, EOsVersion.MicroStation, string.Empty));

            Add(new MemoryAndFactory.Model(EModelType.TritonExtreme, EOsVersion.TritonExtreme, string.Empty));
            Add(new MemoryAndFactory.Model(EModelType.TritonTrClassicStudioRack, EOsVersion.TritonTrClassicStudioRack, string.Empty));
            Add(new MemoryAndFactory.Model(EModelType.TritonKarma, EOsVersion.TritonKarma, string.Empty));
            Add(new MemoryAndFactory.Model(EModelType.TritonLe, EOsVersion.TritonLe, string.Empty));
            Add(new MemoryAndFactory.Model(EModelType.Trinity, EOsVersion.TrinityV2, Strings.VersionV2));

            Add(new MemoryAndFactory.Model(EModelType.Trinity, EOsVersion.TrinityV3, Strings.VersionV3));

            Add(new MemoryAndFactory.Model(EModelType.TSeries, EOsVersion.TSeries, string.Empty));

            Add(new MemoryAndFactory.Model(EModelType.Z1, EOsVersion.Z1, string.Empty));

            Add(new MemoryAndFactory.Model(EModelType.ZeroSeries, EOsVersion.ZeroSeries, string.Empty));
            Add(new MemoryAndFactory.Model(EModelType.Zero3Rw, EOsVersion.Zero3Rw, string.Empty));
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
