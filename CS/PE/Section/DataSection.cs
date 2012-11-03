using System;
using System.Collections.Generic;
using System.Text;
using CoffLib.Binary;
using CoffLib.X86;

namespace CoffLib.PE
{
    public class DataBlock
    {
        private Val32 address = new Val32(0, true);
        public Val32 Address { get { return address; } }

        public Block Block { get; private set; }

        public DataBlock() { Block = new Block(); }
        public DataBlock(byte[] d) : this() { Block.Add(d); }

        public void Write(Block block)
        {
            address.Value = block.Current;
            block.Add(Block);
            uint padlen = Module.Align((uint)Block.Length, 4) - (uint)Block.Length;
            if (padlen > 0) block.Add(new byte[padlen]);
        }
    }

    public class DataSection : SectionBase
    {
        private string name;
        public override string Name { get { return name; } }

        public DataSection(string name)
        {
            this.name = name;
        }

        private Dictionary<string, Dictionary<string, DataBlock>> data =
            new Dictionary<string, Dictionary<string, DataBlock>>();

        public bool IsEmtpy { get { return data.Count == 0; } }

        private Dictionary<string, DataBlock> GetCategory(string name)
        {
            if (data.ContainsKey(name)) return data[name];

            var ret = new Dictionary<string, DataBlock>();
            data.Add(name, ret);
            return ret;
        }

        public void Add(string category, string name, DataBlock data)
        {
            var ctg = GetCategory(category);
            if (!ctg.ContainsKey(name)) ctg.Add(name, data);
        }

        public DataBlock Add(string category, string name, byte[] data)
        {
            var ctg = GetCategory(category);
            if (ctg.ContainsKey(name)) return ctg[name];

            var ret = new DataBlock(data);
            ctg.Add(name, ret);
            return ret;
        }

        public DataBlock AddString(string s)
        {
            return Add("string", s, Module.DefaultEncoding.GetBytes(s + "\0"));
        }

        public DataBlock AddBuffer(string name, int size)
        {
            return Add("buffer", name, new byte[size]);
        }

        public override void Write(Block block)
        {
            foreach (var ctg in data.Values)
                foreach (var db in ctg.Values)
                    db.Write(block);
            if (IsEmtpy) block.Add(new byte[16]);
        }
    }
}
