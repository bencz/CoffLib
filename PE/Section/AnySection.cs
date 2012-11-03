using System;
using System.Collections.Generic;
using System.Text;
using CoffLib.Binary;

namespace CoffLib.PE
{
    public class AnySection : SectionBase
    {
        private string name;
        public override string Name { get { return name; } }

        public byte[] data;

        public AnySection(string name, byte[] data)
        {
            this.name = name;
            this.data = data;
        }

        public override void Write(Block block)
        {
            block.Add(data);
        }
    }
}
