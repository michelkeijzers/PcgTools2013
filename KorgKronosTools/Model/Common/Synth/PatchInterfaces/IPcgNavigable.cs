// (c) Copyright 2011-2016 MiKeSoft, Michel Keijzers, All rights reserved

using PcgTools.Model.Common.Synth.MemoryAndFactory;

namespace PcgTools.Model.Common.Synth.PatchInterfaces
{
    public interface IPcgNavigable : INavigable
    {
        IPcgMemory PcgRoot { get; }

    }
}
