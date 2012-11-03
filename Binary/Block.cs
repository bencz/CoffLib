using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CoffLib.Binary
{
    public class Block
    {
        private ArrayList data = new ArrayList();

        private uint length = 0;
        public uint Length { get { return length; } }

        public uint Address = 0;
        public uint Current { get { return Address + length; } }

        private List<uint> relocs = new List<uint>();
        public uint[] Relocations { get { return relocs.ToArray(); } }

        public Block() { }
        public Block(uint addr) { Address = addr; }

        public void Add(byte v) { data.Add(v); length += sizeof(byte); }
        public void Add(ushort v) { data.Add(v); length += sizeof(ushort); }
        public void Add(uint v) { data.Add(v); length += sizeof(uint); }
        public void Add(int v) { data.Add(v); length += sizeof(int); }
        public void Add(long v) { data.Add(v); length += sizeof(long); }
        public void Add(byte[] v) { data.Add(v); length += (uint)v.Length; }
        public void Add(char[] v) { data.Add(v); length += (uint)v.Length; }
        public void Add(string v) { data.Add(v); length += (uint)v.Length; }
        public void Add(Val32 v)
        {
            data.Add(v);
            if (v.IsNeedForRelocation) relocs.Add(length);
            length += sizeof(uint);
        }

        public void Add(Block block)
        {
            foreach (object obj in block.data)
            {
                if (obj is byte) Add((byte)obj);
                else if (obj is ushort) Add((ushort)obj);
                else if (obj is uint) Add((uint)obj);
                else if (obj is int) Add((int)obj);
                else if (obj is long) Add((long)obj);
                else if (obj is byte[]) Add((byte[])obj);
                else if (obj is char[]) Add((char[])obj);
                else if (obj is string) Add((string)obj);
                else if (obj is Block) Add((Block)obj);
                else if (obj is Val32) Add((Val32)obj);
                else throw new Exception("The method or operation is not implemented.");
            }
        }

        public void Write(BinaryWriter bw)
        {
            foreach (object obj in data)
            {
                if (obj is byte) bw.Write((byte)obj);
                else if (obj is ushort) bw.Write((ushort)obj);
                else if (obj is uint) bw.Write((uint)obj);
                else if (obj is int) bw.Write((int)obj);
                else if (obj is long) bw.Write((long)obj);
                else if (obj is byte[]) bw.Write((byte[])obj);
                else if (obj is char[]) bw.Write((char[])obj);
                else if (obj is string) bw.Write(((string)obj).ToCharArray());
                else if (obj is Block) (obj as Block).Write(bw);
                else if (obj is Val32) bw.Write(((Val32)obj).Value);
                else throw new Exception("The method or operation is not implemented.");
            }
        }

        public byte[] ToByteArray()
        {
            MemoryStream ms = new MemoryStream();
            BinaryWriter bw = new BinaryWriter(ms, Encoding.ASCII);
            Write(bw);
            bw.Close();
            ms.Close();
            return ms.ToArray();
        }
    }
}
