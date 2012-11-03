using System;
using System.Collections.Generic;
using System.Text;
using CoffLib.Binary;

namespace CoffLib.X86
{
    public partial class I386
    {
        // Shl, Shr, Sal, Sar

        public static OpCode Shl(Reg32 op1, byte op2) { return Shift("shl", op1, op2); }
        public static OpCode Shl(Reg32 op1, Reg8 op2) { return Shift("shl", op1, op2); }
        public static OpCode Shl(Addr32 op1, byte op2) { return Shift("shl", op1, op2); }
        public static OpCode Shl(Addr32 op1, Reg8 op2) { return Shift("shl", op1, op2); }

        public static OpCode Shr(Reg32 op1, byte op2) { return Shift("shr", op1, op2); }
        public static OpCode Shr(Reg32 op1, Reg8 op2) { return Shift("shr", op1, op2); }
        public static OpCode Shr(Addr32 op1, byte op2) { return Shift("shr", op1, op2); }
        public static OpCode Shr(Addr32 op1, Reg8 op2) { return Shift("shr", op1, op2); }

        public static OpCode Sal(Reg32 op1, byte op2) { return Shift("sal", op1, op2); }
        public static OpCode Sal(Reg32 op1, Reg8 op2) { return Shift("sal", op1, op2); }
        public static OpCode Sal(Addr32 op1, byte op2) { return Shift("sal", op1, op2); }
        public static OpCode Sal(Addr32 op1, Reg8 op2) { return Shift("sal", op1, op2); }

        public static OpCode Sar(Reg32 op1, byte op2) { return Shift("sar", op1, op2); }
        public static OpCode Sar(Reg32 op1, Reg8 op2) { return Shift("sar", op1, op2); }
        public static OpCode Sar(Addr32 op1, byte op2) { return Shift("sar", op1, op2); }
        public static OpCode Sar(Addr32 op1, Reg8 op2) { return Shift("sar", op1, op2); }

        public static OpCode Shift(string op, Reg32 op1, byte op2)
        {
            byte b;
            switch (op)
            {
                case "shl":
                case "sal":
                    b = (byte)(0xe0 + op1);
                    break;
                case "shr":
                    b = (byte)(0xe8 + op1);
                    break;
                case "sar":
                    b = (byte)(0xf8 + op1);
                    break;
                default:
                    throw new Exception("invalid operator: " + op);
            }
            if (op2 == 1)
                return new OpCode(new byte[] { 0xd1, b });
            else
                return new OpCode(new byte[] { 0xc1, b }, op2);
        }

        public static OpCode Shift(string op, Reg32 op1, Reg8 op2)
        {
            byte b;
            switch (op)
            {
                case "shl":
                case "sal":
                    b = (byte)(0xe0 + op1);
                    break;
                case "shr":
                    b = (byte)(0xe8 + op1);
                    break;
                case "sar":
                    b = (byte)(0xf8 + op1);
                    break;
                default:
                    throw new Exception("invalid operator: " + op);
            }
            if (op2 != Reg8.CL)
                throw new Exception("invalid register: " + op2);
            else
                return new OpCode(new byte[] { 0xd3, b });
        }

        public static OpCode Shift(string op, Addr32 op1, byte op2)
        {
            Addr32 ad;
            switch (op)
            {
                case "shl":
                case "sal":
                    ad = new Addr32(op1, 4);
                    break;
                case "shr":
                    ad = new Addr32(op1, 5);
                    break;
                case "sar":
                    ad = new Addr32(op1, 7);
                    break;
                default:
                    throw new Exception("invalid operator: " + op);
            }
            if (op2 == 1)
                return new OpCode(new byte[] { 0xd1 }, null, ad);
            else
                return new OpCode(new byte[] { 0xc1 }, op2, ad);
        }

        public static OpCode Shift(string op, Addr32 op1, Reg8 op2)
        {
            Addr32 ad;
            switch (op)
            {
                case "shl":
                case "sal":
                    ad = new Addr32(op1, 4);
                    break;
                case "shr":
                    ad = new Addr32(op1, 5);
                    break;
                case "sar":
                    ad = new Addr32(op1, 7);
                    break;
                default:
                    throw new Exception("invalid operator: " + op);
            }
            if (op2 != Reg8.CL)
                throw new Exception("invalid register: " + op2);
            else
                return new OpCode(new byte[] { 0xd3 }, null, ad);
        }
    }
}
