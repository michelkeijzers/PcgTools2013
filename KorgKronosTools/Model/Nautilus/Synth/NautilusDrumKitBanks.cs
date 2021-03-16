
using PcgTools.Model.Common.Synth.MemoryAndFactory;
using PcgTools.Model.Common.Synth.Meta;
using PcgTools.Model.KronosSpecific.Synth;

// (c) 2011 Michel Keijzers

namespace PcgTools.Model.NautilusSpecific.Synth
{
    /// <summary>
    /// 
    /// </summary>
    public class NautilusDrumKitBanks : KronosDrumKitBanks
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pcgMemory"></param>
        public NautilusDrumKitBanks(IPcgMemory pcgMemory)
            : base(pcgMemory)
        {
        }


        /// <summary>
        /// 
        /// </summary>
        protected override void CreateBanks()
        {
            Add(new NautilusDrumKitBank(this, BankType.EType.Int, "INT", -1));

            foreach (var id in new[] { "U-A", "U-B", "U-C", "U-D", "U-E", "U-F", "U-G" })
            {
                Add(new NautilusDrumKitBank(this, BankType.EType.User, id, -1));
            }

            foreach (var id in new[] { "U-AA", "U-BB", "U-CC", "U-DD", "U-EE", "U-FF", "U-GG" })
            {
                Add(new NautilusDrumKitBank(this, BankType.EType.User, id, -1));
            }

            // LV: GM Drumkit bank. For the patches, probably use a separate subclass KronosGmDrumKit (similar to KronosGmProgram)?
        }
    }
}
