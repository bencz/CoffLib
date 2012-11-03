using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CoffLib.Binary
{
    public abstract class WriterBase
    {
        public abstract void Write(Block block);

        public Block ToBlock()
        {
            Block ret = new Block();
            Write(ret);
            return ret;
        }

        public void Write(BinaryWriter bw)
        {
            ToBlock().Write(bw);
        }
    }
}
