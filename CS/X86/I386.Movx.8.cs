using System;
using System.Collections.Generic;
using System.Text;
using CoffLib.Binary;

namespace CoffLib.X86
{
    public partial class I386
    {
        // Movzx, Movsx

        public static OpCode MovzxB(Reg32 op1, Reg8 op2) { return FromNameB("movzx", op1, op2); }
        public static OpCode MovzxB(Reg32 op1, Addr32 op2) { return FromNameB("movzx", op1, op2); }

        public static OpCode MovzxB(Reg16 op1, Reg8 op2) { return FromNameB("movzx", op1, op2); }
        public static OpCode MovzxB(Reg16 op1, Addr32 op2) { return FromNameB("movzx", op1, op2); }

        public static OpCode MovsxB(Reg32 op1, Reg8 op2) { return FromNameB("movsx", op1, op2); }
        public static OpCode MovsxB(Reg32 op1, Addr32 op2) { return FromNameB("movsx", op1, op2); }

        public static OpCode MovsxB(Reg16 op1, Reg8 op2) { return FromNameB("movsx", op1, op2); }
        public static OpCode MovsxB(Reg16 op1, Addr32 op2) { return FromNameB("movsx", op1, op2); }

        public static OpCode FromNameB(string op, Reg32 op1, Reg8 op2)
        {
            byte b;
            switch (op)
            {
                case "movzx":
                    b = 0xb6;
                    break;
                case "movsx":
                    b = 0xbe;
                    break;
                default:
                    throw new Exception("invalid operator: " + op);
            }
            return new OpCode(new byte[] { 0x0f, b, (byte)(0xc0 + (((int)op1) << 3) + op2) });
        }

        public static OpCode FromNameB(string op, Reg16 op1, Reg8 op2)
        {
            byte b;
            switch (op)
            {
                case "movzx":
                    b = 0xb6;
                    break;
                case "movsx":
                    b = 0xbe;
                    break;
                default:
                    throw new Exception("invalid operator: " + op);
            }
            return new OpCode(new byte[] { 0x66, 0x0f, b, (byte)(0xc0 + (((int)op1) << 3) + op2) });
        }

        public static OpCode FromNameB(string op, Reg32 op1, Addr32 op2)
        {
            byte b;
            switch (op)
            {
                case "movzx":
                    b = 0xb6;
                    break;
                case "movsx":
                    b = 0xbe;
                    break;
                default:
                    throw new Exception("invalid operator: " + op);
            }
            return new OpCode(new byte[] { 0x0f, b }, null, new Addr32(op2, (byte)op1));
        }

        public static OpCode FromNameB(string op, Reg16 op1, Addr32 op2)
        {
            byte b;
            switch (op)
            {
                case "movzx":
                    b = 0xb6;
                    break;
                case "movsx":
                    b = 0xbe;
                    break;
                default:
                    throw new Exception("invalid operator: " + op);
            }
            return new OpCode(new byte[] { 0x66, 0x0f, b }, null, new Addr32(op2, (byte)op1));
        }
    }
}
