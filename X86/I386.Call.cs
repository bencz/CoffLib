using System;
using System.Collections.Generic;
using System.Text;
using CoffLib.Binary;

namespace CoffLib.X86
{
    public partial class I386
    {
        // Call

        public static OpCode Call(Reg32 op1)
        {
            switch (op1)
            {
                case Reg32.EAX:
                    return new OpCode(new byte[] { 0xff, 0xd0 });
            }
            throw new Exception("The method or operation is not implemented.");
        }

        public static OpCode Call(Addr32 op1)
        {
            return new OpCode(new byte[] { 0xff }, null, new Addr32(op1, 2));
        }

        public static OpCode Call(Val32 op1)
        {
            return new OpCode(new byte[] { 0xe8 }, op1, true);
        }

        public static OpCode[] Call(CallType call, Addr32 func, object[] args)
        {
            List<OpCode> ret = new List<OpCode>();
            args = args.Clone() as object[];
            Array.Reverse(args);
            foreach (object arg in args)
            {
                if (arg is int) ret.Add(Push((uint)(int)arg));
                else if (arg is uint) ret.Add(Push((uint)arg));
                else if (arg is Val32) ret.Add(Push((Val32)arg));
                else if (arg is Addr32) ret.Add(Push((Addr32)arg));
                else throw new Exception("Unknown argument.");
            }
            ret.Add(Call(func));
            if (call == CallType.CDecl)
            {
                ret.Add(Add(Reg32.ESP, (byte)(args.Length * 4)));
            }
            return ret.ToArray();
        }
    }
}
