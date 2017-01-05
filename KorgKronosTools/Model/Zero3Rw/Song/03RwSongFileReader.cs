// (c) Copyright 2011-2016 MiKeSoft, Michel Keijzers, All rights reserved

using PcgTools.Model.Common.Synth.SongsRelated;
using PcgTools.Model.ZeroSeries.Song;
using PcgTools.Model.ZeroSeriesSpecific.Song;

namespace PcgTools.Model.Zero3Rw.Song
{
    /// <summary>
    /// 
    /// </summary>
    public class Zero3RwSongFileReader : ZeroSeriesSongFileReader
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="songMemory"></param>
        /// <param name="content"></param>
        public Zero3RwSongFileReader(ISongMemory songMemory, byte[] content) 
            : base(songMemory, content)
        {
        }
    }
}
