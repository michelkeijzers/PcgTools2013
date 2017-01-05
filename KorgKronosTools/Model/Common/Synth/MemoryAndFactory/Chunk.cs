// (c) Copyright 2011-2016 MiKeSoft, Michel Keijzers, All rights reserved

using System;

namespace PcgTools.Model.Common.Synth.MemoryAndFactory
{
    /// <summary>
    /// 
    /// </summary>
    public class Chunk : IChunk
    {
        /// <summary>
        /// 
        /// </summary>
        public string Name { get; private set; }


        /// <summary>
        /// 
        /// </summary>
        public int Offset { get; private set; }


        /// <summary>
        /// 
        /// </summary>
        public int Size { get; private set; }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="offset"></param>
        /// <param name="size"></param>
        public Chunk(string name, int offset, int size)
        {
// ReSharper disable RedundantStringFormatCall
            Console.WriteLine(String.Format("Chunk {0}, offset {1:x10}, size {2:x10}", name, offset, size));
// ReSharper restore RedundantStringFormatCall
            Name = name;
            Offset = offset;
            Size = size;
        }
    }
}
