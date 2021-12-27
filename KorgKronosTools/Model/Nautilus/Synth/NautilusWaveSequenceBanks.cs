
using PcgTools.Model.Common.Synth.MemoryAndFactory;
using PcgTools.Model.Common.Synth.Meta;
using PcgTools.Model.KronosSpecific.Synth;

// (c) 2011 Michel Keijzers

namespace PcgTools.Model.NautilusSpecific.Synth
{
    /// <summary>
    /// 
    /// </summary>
    public class NautilusWaveSequenceBanks : KronosWaveSequenceBanks
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pcgMemory"></param>
        public NautilusWaveSequenceBanks(IPcgMemory pcgMemory)
            : base(pcgMemory)
        {
        }


        /// <summary>
        /// 
        /// </summary>
        protected override void CreateBanks()
        {
            Add(new NautilusWaveSequenceBank(this, BankType.EType.Int, "INT", -1));

            foreach (string id in new[] { "USER-A", "USER-B", "USER-C", "USER-D", "USER-E", "USER-F", "USER-G" })
            {
                Add(new NautilusWaveSequenceBank(this, BankType.EType.User, id, -1));
            }

            foreach (string id in new[] { "USER-AA", "USER-BB", "USER-CC", "USER-DD", "USER-EE", "USER-FF", "USER-GG" })
            {
                Add(new NautilusWaveSequenceBank(this, BankType.EType.User, id, -1));
            }
        }
    }
}
