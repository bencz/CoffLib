using System;
using System.Collections.Generic;
using System.Text;
using CoffLib.Binary;

namespace CoffLib.X86
{
    public partial class I386
    {
        // Push, Pop, Inc, Dec, Not, Neg, Mul, Imul, Div, Idiv

        public static OpCode PushB(byte op1)
        {
            return new OpCode(new byte[] { 0x6a }, op1);
        }

        public static OpCode IncB(Reg8 op1) { return FromNameB("inc", op1); }
        public static OpCode IncB(Addr32 op1) { return FromNameB("inc", op1); }

        public static OpCode DecB(Reg8 op1) { return FromNameB("dec", op1); }
        public static OpCode DecB(Addr32 op1) { return FromNameB("dec", op1); }

        public static OpCode NotB(Reg8 op1) { return FromNameB("not", op1); }
        public static OpCode NotB(Addr32 op1) { return FromNameB("not", op1); }

        public static OpCode NegB(Reg8 op1) { return FromNameB("neg", op1); }
        public static OpCode NegB(Addr32 op1) { return FromNameB("neg", op1); }

        public static OpCode MulB(Reg8 op1) { return FromNameB("mul", op1); }
        public static OpCode MulB(Addr32 op1) { return FromNameB("mul", op1); }

        public static OpCode ImulB(Reg8 op1) { return FromNameB("imul", op1); }
        public static OpCode ImulB(Addr32 op1) { return FromNameB("imul", op1); }

        public static OpCode DivB(Reg8 op1) { return FromNameB("div", op1); }
        public static OpCode DivB(Addr32 op1) { return FromNameB("div", op1); }

        public static OpCode IdivB(Reg8 op1) { return FromNameB("idiv", op1); }
        public static OpCode IdivB(Addr32 op1) { return FromNameB("idiv", op1); }

        public static OpCode FromNameB(string op, Reg8 op1)
        {
            switch (op)
            {
                case "inc":
                    return new OpCode(new byte[] { 0xfe, (byte)(0xc0 + op1) });
                case "dec":
                    return new OpCode(new byte[] { 0xfe, (byte)(0xc8 + op1) });
                case "not":
                    return new OpCode(new byte[] { 0xf6, (byte)(0xd0 + op1) });
                case "neg":
                    return new OpCode(new byte[] { 0xf6, (byte)(0xd8 + op1) });
                case "mul":
                    return new OpCode(new byte[] { 0xf6, (byte)(0xe0 + op1) });
                case "imul":
                    return new OpCode(new byte[] { 0xf6, (byte)(0xe8 + op1) });
                case "div":
                    return new OpCode(new byte[] { 0xf6, (byte)(0xf0 + op1) });
                case "idiv":
                    return new OpCode(new byte[] { 0xf6, (byte)(0xf8 + op1) });
                default:
                    throw new Exception("invalid operator: " + op);
            }
        }

        public static OpCode FromNameB(string op, Addr32 op1)
        {
            switch (op)
            {
                case "inc":
                    return new OpCode(new byte[] { 0xfe }, null, op1);
                case "dec":
                    return new OpCode(new byte[] { 0xfe }, null, new Addr32(op1, 1));
                case "not":
                    return new OpCode(new byte[] { 0xf6 }, null, new Addr32(op1, 2));
                case "neg":
                    return new OpCode(new byte[] { 0xf6 }, null, new Addr32(op1, 3));
                case "mul":
                    return new OpCode(new byte[] { 0xf6 }, null, new Addr32(op1, 4));
                case "imul":
                    return new OpCode(new byte[] { 0xf6 }, null, new Addr32(op1, 5));
                case "div":
                    return new OpCode(new byte[] { 0xf6 }, null, new Addr32(op1, 6));
                case "idiv":
                    return new OpCode(new byte[] { 0xf6 }, null, new Addr32(op1, 7));
                default:
                    throw new Exception("invalid operator: " + op);
            }
        }
    }
}
