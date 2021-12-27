// (c) Copyright 2011-2019 MiKeSoft, Michel Keijzers, All rights reserved

using System;
using System.Diagnostics;
using System.Text;
using System.Collections.Generic;
using Common.Utils;

using PcgTools.Model.Common.Synth.MemoryAndFactory;
using PcgTools.Model.Common.Synth.Meta;

namespace PcgTools.Model.Common
{
    public abstract class Util
    {
        private static readonly char[] CTerminators = new[] { ' ', '\0', '\t', '\n' };


        public static string GetChars(byte[] data, int start, int amount)
        {
            Debug.Assert(data != null);
            Debug.Assert((start + amount) < data.Length);

            return Encoding.ASCII.GetString(data, start, amount).Trim(CTerminators).Split('\0')[0];

/*
            var output = String.Empty;
            var finished = false;
            var index = 0;
            while (!finished)
            {
                var character = (char) data[start + index];
                if (character != 0)
                {
                    output += character;
                }

                index++;
                finished = (index == amount) || (character == 0);
            }
            return output.TrimEnd();
 */
        }


        public static void SetChars(IPcgMemory pcgMemory, byte[] data, int start, int maxLength, string text)
        {
            Debug.Assert(pcgMemory != null);
            Debug.Assert(data != null);

            Debug.Assert(start >= 4); // Do not overwrite KORG header.
            Debug.Assert(text.Length <= maxLength);

            bool dirty = false;

            int index;
            for (index = 0; index < text.Length; index++)
            {
                byte orgData = data[start + index];
                data[start + index] = (byte) (text[index]);
                //Console.WriteLine(String.Format("SetChars: Write {0} to {1} ", (byte) (text[index]), start + index));
                dirty |= (orgData != data[start + index]);
            }

            // Padd with zeros.
            while (index < maxLength)
            {
                dirty |= (data[start + index] != 0);
                data[start + index] = 0;
                index++;
            }

            pcgMemory.IsDirty |= dirty;
        }
        

        public static int GetInt(byte[] data, int start, int amount)
        {
            Debug.Assert(data != null);

            int output = 0;
            for (int index = 0; index < amount; index++)
            {
                output += data[start + index]*(int) (Math.Pow(256, (amount - index - 1)));
            }
            return output;
        }


        /// <summary>
        /// Only use for fixed parameters or special usage.
        /// </summary>
        /// <returns></returns>
        public static int GetBits(byte[] data, int offset, int highBit, int lowBit)
        {
            return BitsUtil.GetBits(data, offset, highBit, lowBit);
        }



        public static void SetInt(IPcgMemory pcgMemory, byte[] data, int start, int amount, int value)
        {
            Debug.Assert(pcgMemory != null);
            Debug.Assert(data != null);

            bool dirty = false;

            switch (amount)
            {
                case 1:
                    Debug.Assert((value >= 0) && (value <= 255));
                    dirty |= (data[start] != (byte) value);
                    //Console.WriteLine(String.Format("SetInt: Write {0} to {1} ", (byte) value, start));
                    data[start] = (byte) value;
                    break;

                case 2:
                    Debug.Assert((value >= 0) && (value <= 65535));
                    dirty |= (data[start] != (byte) (value/256));
                    //Console.WriteLine(String.Format("SetInt: Write two bytes to {0}", start));
                    data[start] = (byte) (value/256);
                    dirty |= (data[start + 1] != (byte) (value%256));
                    data[start + 1] = (byte) (value%256);
                    break;

                case 4:
                    //Console.WriteLine(String.Format("SetInt: Write four bytes to {0}", start));
                    dirty |= (data[start + 3] != (byte) (value%256));
                    data[start + 3] = (byte) (value%256);

                    value /= 256;
                    dirty |= (data[start + 2] != (byte) (value%256));
                    data[start + 2] = (byte) (value%256);

                    value /= 256;
                    dirty |= (data[start + 1] != (byte) (value%256));
                    data[start + 1] = (byte) (value%256);

                    dirty |= (data[start] != (byte) (value/256));
                    data[start] = (byte) (value/256);
                    break;

                default:
                    throw new ApplicationException("Illegal value");
            }

            pcgMemory.IsDirty |= dirty;
        }


        public static void SwapBytes(IMemory pcgMemory, byte[] sourceData, int sourceOffset, byte[] destinationData,
                                     int destinationOffset, int amount)
        {
            Debug.Assert(pcgMemory != null);
            Debug.Assert(sourceData != null);

            bool dirty = false;

            for (int index = 0; index < amount; index++)
            {
                dirty |= (sourceData[sourceOffset + index] != destinationData[destinationOffset + index]);

                Debug.Assert(destinationOffset + index >= 4); // Korg header
                Debug.Assert(sourceOffset + index >= 4); // Korg header

                byte temp = destinationData[destinationOffset + index];
                //Console.WriteLine(String.Format("SwapBytes: Write {0} to {1}", sourceData[sourceOffset + index], destinationOffset + index));
                destinationData[destinationOffset + index] = sourceData[sourceOffset + index];
                //Console.WriteLine(String.Format("SwapBytes: Write {0} to {1}", temp, sourceOffset + index));
                sourceData[sourceOffset + index] = temp;
            }

            pcgMemory.IsDirty |= dirty;
        }


        public static bool ByteCompareEqual(byte[] data1, int data1Offset, byte[] data2, int length)
        {
            Debug.Assert(data1 != null);
            Debug.Assert(data2 != null);

            for (int index = 0; index < length; index++)
            {
                if (data1[index + data1Offset] != data2[index])
                {
                    return false;
                }
            }

            return true;
        }


        /// <summary>
        /// Copy bytes from different source.
        /// </summary>
        /// <param name="pcgMemory"></param>
        /// <param name="source"></param>
        /// <param name="destination"></param>
        /// <param name="offset"></param>
        /// <param name="size"></param>
        public static void CopyBytes(PcgMemory pcgMemory, byte[] source, byte[] destination, int offset, int size)
        {
            Debug.Assert(pcgMemory != null);

            bool dirty = false;

            Debug.Assert(offset >= 4); // Korg header
            for (int index = 0; index < size; index++)
            {
                dirty |= (source[index] != (destination[offset + index]));
                //Console.WriteLine(String.Format("CopyBytes: Write {0} to {1}", source[index], offset + index));
                destination[offset + index] = source[index];
            }

            pcgMemory.IsDirty |= dirty;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="pcgMemory"></param>
        /// <param name="sourceOffset"></param>
        /// <param name="destination"></param>
        /// <param name="destinationOffset"></param>
        /// <param name="size"></param>
        public static void CopyBytes(PcgMemory pcgMemory, int sourceOffset, byte[] destination, int destinationOffset, int size)
        {
            Debug.Assert(pcgMemory != null);

            bool dirty = false;

            Debug.Assert(destinationOffset >= 4); // Korg header
            for (int index = 0; index < size; index++)
            {
                dirty |= (destination[sourceOffset + index] != (destination[destinationOffset + index]));
                //Console.WriteLine(String.Format("CopyBytes: Write {0} to {1}", source[index], offset + index));
                destination[destinationOffset + index] = destination[sourceOffset + index];
            }

            pcgMemory.IsDirty |= dirty;       
        }


        /// <summary>
        /// Copy bytes internally.
        /// </summary>
        /// <param name="pcgMemory"></param>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="size"></param>
        public static void CopyBytes(PcgMemory pcgMemory, int from, int to, int size)
        {
            Debug.Assert(pcgMemory != null);

            byte[] content = pcgMemory.Content;

            Debug.Assert(from + size < content.Length);
            Debug.Assert(to + size <content.Length);

            bool dirty = false;

            for (int index = 0; index < size; index++)
            {
                dirty |= (content[from + index] != (content[to + index]));
                content[to + index] = content[from + index];
            }

            pcgMemory.IsDirty |= dirty;
        }


        // Following implementation was copied from
        // http://www.codeproject.com/Articles/36747/Quick-and-Dirty-HexDump-of-a-Byte-Array 
// ReSharper disable UnusedMember.Global
        public static string HexDump(byte[] bytes, int bytesPerLine = 16)
// ReSharper restore UnusedMember.Global
        {
            if (bytes == null) return "<null>";
            int bytesLength = bytes.Length;

            char[] hexChars = "0123456789ABCDEF".ToCharArray();

            const int firstHexColumn = 8 // 8 characters for the address
                                       + 3; // 3 spaces

            int firstCharColumn = firstHexColumn
                                  + bytesPerLine*3 // - 2 digit for the hexadecimal value and 1 space
                                  + (bytesPerLine - 1)/8 // - 1 extra space every 8 characters from the 9th
                                  + 2; // 2 spaces 

            int lineLength = firstCharColumn
                             + bytesPerLine // - characters to show the ascii value
                             + Environment.NewLine.Length; // Carriage return and line feed (should normally be 2)

            char[] line = (new string(' ', lineLength - 2) + Environment.NewLine).ToCharArray();
            int expectedLines = (bytesLength + bytesPerLine - 1)/bytesPerLine;
            StringBuilder result = new StringBuilder(expectedLines*lineLength);

            for (int i = 0; i < bytesLength; i += bytesPerLine)
            {
                line[0] = hexChars[(i >> 28) & 0xF];
                line[1] = hexChars[(i >> 24) & 0xF];
                line[2] = hexChars[(i >> 20) & 0xF];
                line[3] = hexChars[(i >> 16) & 0xF];
                line[4] = hexChars[(i >> 12) & 0xF];
                line[5] = hexChars[(i >> 8) & 0xF];
                line[6] = hexChars[(i >> 4) & 0xF];
                line[7] = hexChars[(i >> 0) & 0xF];

                int hexColumn = firstHexColumn;
                int charColumn = firstCharColumn;

                for (int j = 0; j < bytesPerLine; j++)
                {
                    if (j > 0 && (j & 7) == 0) hexColumn++;
                    if (i + j >= bytesLength)
                    {
                        line[hexColumn] = ' ';
                        line[hexColumn + 1] = ' ';
                        line[charColumn] = ' ';
                    }
                    else
                    {
                        byte b = bytes[i + j];
                        line[hexColumn] = hexChars[(b >> 4) & 0xF];
                        line[hexColumn + 1] = hexChars[b & 0xF];
                        line[charColumn] = (b < 32 ? '·' : (char) b);
                    }
                    hexColumn += 3;
                    charColumn++;
                }
                result.Append(line);
            }
            return result.ToString();
        }

        public static string GetPatchIdsString(List<IPatch> patchList)
        {
            // Requirement: The patchList is allowed to contain patches of different Banks, but in that case 
            //   the patchList must be grouped (not necessarily ordered) by Bank.
            // Recommendation: For the shortest possible string, 
            // within each Bank, the patchList needs to be ordered by Patch index.

            StringBuilder builder = new StringBuilder();
            int listIndex = 0;
            int listLength = patchList.Count;
            bool firstPrint = true;
            bool lastPrint = false;
            bool needToPrint = false;
            int prevPatchIndex = -2;
            IBank prevPatchBank = null;
            IPatch rangePatchStart = null;
            IPatch rangePatchEnd = null;

            foreach (IPatch patch in patchList)
            {
                if (listIndex == 0) // First patch? Initialize a range.
                {
                    rangePatchStart = patch;
                    rangePatchEnd = patch;
                    prevPatchIndex = patch.Index;
                    prevPatchBank = (IBank) patch.Parent;
                }
                else if (patch.Parent != prevPatchBank) // New bank?
                {
                    needToPrint = true;
                }
                else if ((patch.Index - prevPatchIndex) > 1) // New range?
                {
                    needToPrint = true;
                }
                else // Extend the existing range
                {
                    rangePatchEnd = patch;
                    prevPatchIndex = patch.Index;
                }

                if (listIndex == listLength - 1) // Last patch?
                {
                    lastPrint = true;
                    needToPrint = true;
                }

                while (needToPrint)
                {
                    firstPrint = PrintRange(firstPrint, builder, patch, ref rangePatchStart, ref rangePatchEnd, 
                        ref lastPrint, ref needToPrint, ref prevPatchIndex, ref prevPatchBank);
                }

                listIndex++;
            }

            return builder.ToString();
        }

        private static bool PrintRange(bool firstPrint, StringBuilder builder, IPatch patch, ref IPatch rangePatchStart,
            ref IPatch rangePatchEnd, ref bool lastPrint, ref bool needToPrint, ref int prevPatchIndex, ref IBank prevPatchBank)
        {
// First print the previous range
            if (firstPrint)
            {
                firstPrint = false;
            }
            else
            {
                builder.Append(", ");
            }

            if (rangePatchStart != rangePatchEnd)
            {
                if (rangePatchStart != null)
                {
                    builder.Append(rangePatchStart.Id);
                }

                builder.Append("~");
            }

            if (rangePatchEnd != null)
            {
                builder.Append(rangePatchEnd.Id);

                // If we've just printed the last patch, we're done
                if (lastPrint && (patch == rangePatchEnd))
                {
                    needToPrint = false;
                }
                else // Otherwise start a new range
                {
                    rangePatchStart = patch;
                    rangePatchEnd = patch;
                    prevPatchIndex = patch.Index;
                    prevPatchBank = (IBank) patch.Parent;

                    // If this is now the last patch, then we need 
                    // one final print before we leave the foreach loop
                    if (!lastPrint)
                    {
                        needToPrint = false;
                    }

                    lastPrint = false;
                }
            }
            return firstPrint;
        }
    }
}


