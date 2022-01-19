
using PcgTools.Model.Common.Synth.MemoryAndFactory;
using PcgTools.Model.Common.Synth.Meta;
using PcgTools.Model.KronosSpecific.Synth;

// (c) 2011 Michel Keijzers

namespace PcgTools.Model.NautilusSpecific.Synth
{
    /// <summary>
    /// 
    /// </summary>
    public class NautilusDrumPatternBanks : KronosDrumPatternBanks
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pcgMemory"></param>
        public NautilusDrumPatternBanks(IPcgMemory pcgMemory)
            : base(pcgMemory)
        {
        }


        /// <summary>
        /// 
        /// </summary>
        protected override void CreateBanks()
        {

            Add(new NautilusDrumPatternBank(this, BankType.EType.Int, "P", 0)); // Preset

           
            for (int bank = 0; bank < 15; bank++)
            {
                Add(new NautilusDrumPatternBank(this, BankType.EType.Int, ((char) ('A' + bank)).ToString(), 1));
            }
        }
    }
}
