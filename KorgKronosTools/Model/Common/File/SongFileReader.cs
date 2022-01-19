// (c) Copyright 2011-2019 MiKeSoft, Michel Keijzers, All rights reserved

using System;

using PcgTools.Model.Common.Synth.MemoryAndFactory;
using PcgTools.Model.Common.Synth.PatchCombis;
using PcgTools.Model.Common.Synth.SongsRelated;

namespace PcgTools.Model.Common.File
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class SongFileReader : FileReader, IPatchesFileReader, ISongFileReader
    {
        /// <summary>
        /// 
        /// </summary>
        private int _index;


        /// <summary>
        /// 
        /// </summary>
        protected readonly ISongMemory SongMemory;

        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="songMemory"></param>
        /// <param name="content"></param>
        protected SongFileReader(ISongMemory songMemory, byte[] content)
        {
            SongMemory = songMemory;
            SongMemory.Content = content;
            songMemory.MemoryFileType = Memory.FileType.Sng;
        }

    
        /// <summary>
        /// 
        /// </summary>
        public virtual void ReadChunks()
        {
            _index = 32; // Sng1Offset;
            int headerSize = Util.GetInt(SongMemory.Content, _index, 4);
            _index += 4 + headerSize;

            while (_index < SongMemory.Content.Length)
            {
                string chunkName = Util.GetChars(SongMemory.Content, _index, 4);
                int chunkSize = Util.GetInt(SongMemory.Content, _index + 4, 4);
                //Console.WriteLine("index = " + Index.ToString("X08") + ", Chunk name: " + chunkName + ", size of chunk: " +
                //    chunkSize.ToString("X08"));
                //_songMemory.Chunks.Add(new Chunk(chunkName, Index, sng1ChunkSize));
                _index += 12;

                switch (chunkName)
                {
                    case "CUE1":
                        ReadCue1Chunk(chunkSize);
                        break;

                    case "PDX1":
                        ReadPdx1Chunk(chunkSize);
                        break;

                    case "RGN1":
                        ReadRgn1Chunk(chunkSize);
                        break;

                    case "SNG1":
                        ReadSng1Chunk(chunkSize);
                        break;

                    default:
                        throw new ApplicationException("Unexpected chunk");
                }
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sng1ChunkSize"></param>
        private void ReadSng1Chunk(int sng1ChunkSize)
        {
            while (_index < SongMemory.Content.Length)
            {
                string chunkName = Util.GetChars(SongMemory.Content, _index, 4);
                int chunkSize = Util.GetInt(SongMemory.Content, _index + 4, 4);
                //Console.WriteLine("index = " + Index.ToString("X08") + ", Chunk name: " + chunkName + ", size of chunk: " +
                //    chunkSize.ToString("X08"));
                //_songMemory.Chunks.Add(new Chunk(chunkName, Index, sng1ChunkSize));
                _index += 12;

                switch (chunkName)
                {
                    case "CUE1":
                        ReadCue1Chunk(chunkSize);
                        break;

                    case "PDX1":
                        ReadPdx1Chunk(chunkSize);
                        break;

                    case "RGN1":
                        ReadRgn1Chunk(chunkSize);
                        break;

                    case "SDK1":
                        ReadSdk1Chunk();
                        break;

                    case "SGS1":
                        ReadSgs1Chunk(chunkSize);
                        break;

                    default:
                        throw new ApplicationException("Unexpected chunk");
                }
            }

            _index += sng1ChunkSize;
        }


        /// <summary>
        /// </summary>
        /// <param name="timbres"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public abstract ITimbre CreateTimbre(ITimbres timbres, int index);


        /// <summary>
        /// 
        /// </summary>
        private void ReadSdk1Chunk()
        {
            int amountOfSongs = Util.GetInt(SongMemory.Content, _index, 4);
            _index += 4;
            int songSize = Util.GetInt(SongMemory.Content, _index, 4);
            _index += 8;

            // Read through song names in SDK1.

            for (int itemIndex = 0; itemIndex < amountOfSongs; itemIndex++)
            {
                Song song = new Song(this, itemIndex, SongMemory, Util.GetChars(SongMemory.Content, _index, 24)); // Song name size
                SongMemory.Songs.SongCollection.Add(song);

                // Details will be filled while reading SDT1 chunk.

                _index += songSize;
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="chunkSize"></param>
        private void ReadSdt1InSgs1Chunk(int chunkSize)
        {
            _index += 12; // Skip header.

            ReadSpr1InSdt1Chunk();
        }


        /// <summary>
        /// 
        /// </summary>
        private void ReadSpr1InSdt1Chunk()
        {
            
        }


        /// <summary>
        /// Found on M50 preload SNG.
        /// </summary>
        private void ReadCue1Chunk(int chunkSize)
        {
            _index += chunkSize;
        }


        /// <summary>
        /// Found on M50 preload SNG.
        /// </summary>
        private void ReadPdx1Chunk(int chunkSize)
        {
            _index += chunkSize;
        }


        /// <summary>
        /// Found on Kronos, contains audio tracks.
        /// </summary>
        private void ReadRgn1Chunk(int chunkSize)
        {
            int amount = Util.GetInt(SongMemory.Content, _index, 4);
            int startIndex = _index;
            _index += 12; // Skip until first region

            const int maxRegionNameSize = 24;
            const int maxRegionSampleFileNameSize = 84;
            for (int itemIndex = 0; itemIndex < amount; itemIndex++)
            {
                Region region = new Region(itemIndex, Util.GetChars(SongMemory.Content, _index, maxRegionNameSize),
                    Util.GetChars(SongMemory.Content, _index + maxRegionNameSize, maxRegionSampleFileNameSize));

                SongMemory.Regions.RegionsCollection.Add(region);
                _index += + maxRegionNameSize + maxRegionSampleFileNameSize + 16;
            }

            _index = startIndex + chunkSize;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="chunkSize"></param>
        private void ReadSgs1Chunk(int chunkSize)
        {
            foreach (ISong song in SongMemory.Songs.SongCollection)
            {
                // Read SDT1
                ReadSdt1Chunk(song);
            }

            _index += chunkSize;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="song"></param>
        private void ReadSdt1Chunk(ISong song)
        {
            // var sdt1ChunkName = Util.GetChars(SongMemory.Content, Index, 4);
            int sdt1ChunkSize = Util.GetInt(SongMemory.Content, _index + 4, 4);
            _index += 12;
            int endOfChunk = _index + sdt1ChunkSize;

            while (_index < endOfChunk)
            {
                string chunkName = Util.GetChars(SongMemory.Content, _index, 4);
                int chunkSize = Util.GetInt(SongMemory.Content, _index + 4, 4);
                _index += 12;

                switch (chunkName)
                {
                    case "ADT1":
                        ReadAdt1Chunk(/* song, */ chunkSize);
                        break;
                        
                    case "SPR1":
                        ReadSpr1Chunk(chunkSize);
                        break;

                    case "BMT1":
                        ReadBmt1Chunk(song, chunkSize);
                        break;

                    case "BMT2":
                        ReadBmt2Chunk(/*, chunkSize*/);
                        break;
                        
                    case "MDT1":
                        ReadMdt1Chunk(/* song, */ chunkSize);
                        break;

                    case "PTN1":
                        ReadPtn1Chunk(/* song, */ chunkSize);
                        break;

                    case "RGN1":
                        ReadRgn1Chunk(chunkSize);
                        break;

                    case "SDT1":
                        ReadSdt1InSdt1Chunk(/* song, */ chunkSize);
                        break;

                    case "TRK1":
                        ReadTrk1Chunk(/* song, */ chunkSize);
                        break;

                    default:
                        throw new ApplicationException("Illegal chunk");
                }
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="chunkSize"></param>
        private void ReadAdt1Chunk(int chunkSize)
        {
            _index += chunkSize; // Skip chunk
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="chunkSize"></param>
        private void ReadSpr1Chunk(int chunkSize)
        {
            _index += chunkSize; // Skip chunk
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="song"></param>
        /// <param name="chunkSize"></param>
        private void ReadBmt1Chunk(ISong song, int chunkSize)
        {
            song.ByteOffset = _index + 0x12C2 + 12;

            for (int timbre = 0; timbre < NumberOfSongTracks; timbre++)
            {
                ITimbre track = song.Timbres.TimbresCollection[timbre];
                track.ByteOffset = song.ByteOffset + timbre * SongTrackByteLength;
            }

            _index += chunkSize; // Skip chunk
        }


        /// <summary>
        /// Obsolete chunk for Kronos OS1.5/1.6.
        /// </summary>
        private void ReadBmt2Chunk()
        {
            _index += 4; // 4 zero's padding.

            _index += 2 * 16; // Skip banks and programs.
        }


        /// <summary>
        ///
        /// </summary>
        private void ReadMdt1Chunk(int chunkSize)
        {
            _index += chunkSize; // Skip chunk
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="chunkSize"></param>
        private void ReadPtn1Chunk(int chunkSize)
        {
            _index += chunkSize; // Skip chunk
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="chunkSize"></param>
        private void ReadSdt1InSdt1Chunk(int chunkSize)
        {
            _index += chunkSize; // Skip chunk
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="chunkSize"></param>
        private void ReadTrk1Chunk(int chunkSize)
        {
            _index += chunkSize; // Skip chunk
        }


        /// <summary>
        /// Number of song tracks (equal to combi timbres)
        /// </summary>
        public virtual int NumberOfSongTracks => 16;


        /// <summary>
        /// Number of bytes in a song track (equal to length of a combi timbre).
        /// </summary>
        public virtual int SongTrackByteLength => -1;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileType"></param>
        /// <param name="modelType"></param>
        public void ReadContent(Memory.FileType fileType, Models.EModelType modelType)
        {
            throw new NotImplementedException();
        }
    }
}