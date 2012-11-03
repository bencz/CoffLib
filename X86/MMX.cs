using System;
using System.Collections.Generic;
using System.Text;
using CoffLib.Binary;

namespace CoffLib.X86
{
    public partial class MMX
    {
        public static OpCode EMMS()
        {
            return new OpCode(new byte[] { 0x0f, 0x77 });
        }

        public static OpCode MovD(Mm op1, Reg32 op2) { return FromName("movd", op1, op2); }
        public static OpCode MovD(Mm op1, Addr32 op2) { return FromName("movd", op1, op2); }
        public static OpCode MovD(Reg32 op1, Mm op2) { return FromName("movd", op1, op2); }
        public static OpCode MovD(Addr32 op1, Mm op2) { return FromName("movd", op1, op2); }

        public static OpCode MovQ(Mm op1, Mm op2) { return FromName("movq", op1, op2); }
        public static OpCode MovQ(Mm op1, Addr32 op2) { return FromName("movq", op1, op2); }
        public static OpCode MovQ(Addr32 op1, Mm op2) { return FromName("movq", op1, op2); }

        public static OpCode PAddB(Mm op1, Mm op2) { return FromName("paddb", op1, op2); }
        public static OpCode PAddB(Mm op1, Addr32 op2) { return FromName("paddb", op1, op2); }
        public static OpCode PAddW(Mm op1, Mm op2) { return FromName("paddw", op1, op2); }
        public static OpCode PAddW(Mm op1, Addr32 op2) { return FromName("paddw", op1, op2); }
        public static OpCode PAddD(Mm op1, Mm op2) { return FromName("paddd", op1, op2); }
        public static OpCode PAddD(Mm op1, Addr32 op2) { return FromName("paddd", op1, op2); }
        public static OpCode PAddQ(Mm op1, Mm op2) { return FromName("paddq", op1, op2); }
        public static OpCode PAddQ(Mm op1, Addr32 op2) { return FromName("paddq", op1, op2); }

        public static OpCode PSubB(Mm op1, Mm op2) { return FromName("psubb", op1, op2); }
        public static OpCode PSubB(Mm op1, Addr32 op2) { return FromName("psubb", op1, op2); }
        public static OpCode PSubW(Mm op1, Mm op2) { return FromName("psubw", op1, op2); }
        public static OpCode PSubW(Mm op1, Addr32 op2) { return FromName("psubw", op1, op2); }
        public static OpCode PSubD(Mm op1, Mm op2) { return FromName("psubd", op1, op2); }
        public static OpCode PSubD(Mm op1, Addr32 op2) { return FromName("psubd", op1, op2); }
        public static OpCode PSubQ(Mm op1, Mm op2) { return FromName("psubq", op1, op2); }
        public static OpCode PSubQ(Mm op1, Addr32 op2) { return FromName("psubq", op1, op2); }

        public static OpCode PMulHW(Mm op1, Mm op2) { return FromName("pmulhw", op1, op2); }
        public static OpCode PMulHW(Mm op1, Addr32 op2) { return FromName("pmulhw", op1, op2); }
        public static OpCode PMulLW(Mm op1, Mm op2) { return FromName("pmullw", op1, op2); }
        public static OpCode PMulLW(Mm op1, Addr32 op2) { return FromName("pmullw", op1, op2); }

        public static OpCode PSLLW(Mm op1, Mm op2) { return FromName("psllw", op1, op2); }
        public static OpCode PSLLW(Mm op1, Addr32 op2) { return FromName("psllw", op1, op2); }
        public static OpCode PSLLW(Mm op1, byte op2) { return FromName("psllw", op1, op2); }
        public static OpCode PSLLD(Mm op1, Mm op2) { return FromName("pslld", op1, op2); }
        public static OpCode PSLLD(Mm op1, Addr32 op2) { return FromName("pslld", op1, op2); }
        public static OpCode PSLLD(Mm op1, byte op2) { return FromName("pslld", op1, op2); }
        public static OpCode PSLLQ(Mm op1, Mm op2) { return FromName("psllq", op1, op2); }
        public static OpCode PSLLQ(Mm op1, Addr32 op2) { return FromName("psllq", op1, op2); }
        public static OpCode PSLLQ(Mm op1, byte op2) { return FromName("psllq", op1, op2); }

        public static OpCode PSRLW(Mm op1, Mm op2) { return FromName("psrlw", op1, op2); }
        public static OpCode PSRLW(Mm op1, Addr32 op2) { return FromName("psrlw", op1, op2); }
        public static OpCode PSRLW(Mm op1, byte op2) { return FromName("psrlw", op1, op2); }
        public static OpCode PSRLD(Mm op1, Mm op2) { return FromName("psrld", op1, op2); }
        public static OpCode PSRLD(Mm op1, Addr32 op2) { return FromName("psrld", op1, op2); }
        public static OpCode PSRLD(Mm op1, byte op2) { return FromName("psrld", op1, op2); }
        public static OpCode PSRLQ(Mm op1, Mm op2) { return FromName("psrlq", op1, op2); }
        public static OpCode PSRLQ(Mm op1, Addr32 op2) { return FromName("psrlq", op1, op2); }
        public static OpCode PSRLQ(Mm op1, byte op2) { return FromName("psrlq", op1, op2); }

        public static OpCode PSRAW(Mm op1, Mm op2) { return FromName("psraw", op1, op2); }
        public static OpCode PSRAW(Mm op1, Addr32 op2) { return FromName("psraw", op1, op2); }
        public static OpCode PSRAW(Mm op1, byte op2) { return FromName("psraw", op1, op2); }
        public static OpCode PSRAD(Mm op1, Mm op2) { return FromName("psrad", op1, op2); }
        public static OpCode PSRAD(Mm op1, Addr32 op2) { return FromName("psrad", op1, op2); }
        public static OpCode PSRAD(Mm op1, byte op2) { return FromName("psrad", op1, op2); }

        public static OpCode PUnpckHBW(Mm op1, Mm op2) { return FromName("punpckhbw", op1, op2); }
        public static OpCode PUnpckHBW(Mm op1, Addr32 op2) { return FromName("punpckhbw", op1, op2); }
        public static OpCode PUnpckHWD(Mm op1, Mm op2) { return FromName("punpckhwd", op1, op2); }
        public static OpCode PUnpckHWD(Mm op1, Addr32 op2) { return FromName("punpckhwd", op1, op2); }
        public static OpCode PUnpckHDQ(Mm op1, Mm op2) { return FromName("punpckhdq", op1, op2); }
        public static OpCode PUnpckHDQ(Mm op1, Addr32 op2) { return FromName("punpckhdq", op1, op2); }

        public static OpCode PUnpckLBW(Mm op1, Mm op2) { return FromName("punpcklbw", op1, op2); }
        public static OpCode PUnpckLBW(Mm op1, Addr32 op2) { return FromName("punpcklbw", op1, op2); }
        public static OpCode PUnpckLWD(Mm op1, Mm op2) { return FromName("punpcklwd", op1, op2); }
        public static OpCode PUnpckLWD(Mm op1, Addr32 op2) { return FromName("punpcklwd", op1, op2); }
        public static OpCode PUnpckLDQ(Mm op1, Mm op2) { return FromName("punpckldq", op1, op2); }
        public static OpCode PUnpckLDQ(Mm op1, Addr32 op2) { return FromName("punpckldq", op1, op2); }

        public static OpCode PackSSWB(Mm op1, Mm op2) { return FromName("packsswb", op1, op2); }
        public static OpCode PackSSWB(Mm op1, Addr32 op2) { return FromName("packsswb", op1, op2); }
        public static OpCode PackSSDW(Mm op1, Mm op2) { return FromName("packssdw", op1, op2); }
        public static OpCode PackSSDW(Mm op1, Addr32 op2) { return FromName("packssdw", op1, op2); }
        public static OpCode PackUSWB(Mm op1, Mm op2) { return FromName("packuswb", op1, op2); }
        public static OpCode PackUSWB(Mm op1, Addr32 op2) { return FromName("packuswb", op1, op2); }

        private static byte GetCode(string op)
        {
            switch (op)
            {
                case "movq":
                    return 0x6f;
                case "paddb":
                    return 0xfc;
                case "paddw":
                    return 0xfd;
                case "paddd":
                    return 0xfe;
                case "paddq":
                    return 0xd4;
                case "psubb":
                    return 0xf8;
                case "psubw":
                    return 0xf9;
                case "psubd":
                    return 0xfa;
                case "psubq":
                    return 0xfb;
                case "pmulhw":
                    return 0xe5;
                case "pmullw":
                    return 0xd5;
                case "psllw":
                    return 0xf1;
                case "pslld":
                    return 0xf2;
                case "psllq":
                    return 0xf3;
                case "psrlw":
                    return 0xd1;
                case "psrld":
                    return 0xd2;
                case "psrlq":
                    return 0xd3;
                case "psraw":
                    return 0xe1;
                case "psrad":
                    return 0xe2;
                case "punpckhbw":
                    return 0x68;
                case "punpckhwd":
                    return 0x69;
                case "punpckhdq":
                    return 0x6a;
                case "punpcklbw":
                    return 0x60;
                case "punpcklwd":
                    return 0x61;
                case "punpckldq":
                    return 0x62;
                case "packsswb":
                    return 0x63;
                case "packssdw":
                    return 0x6b;
                case "packuswb":
                    return 0x67;
                default:
                    throw new Exception("invalid operator: " + op);
            }
        }

        public static OpCode FromName(string op, Mm op1, Mm op2)
        {
            var b = GetCode(op);
            return new OpCode(new byte[] { 0x0f, b, (byte)(0xc0 + (((int)op1) << 3) + op2) });
        }

        public static OpCode FromName(string op, Mm op1, Addr32 op2)
        {
            byte b;
            switch (op)
            {
                case "movd":
                    b = 0x6e;
                    break;
                default:
                    b = GetCode(op);
                    break;
            }
            return new OpCode(new byte[] { 0x0f, b }, null, new Addr32(op2, (byte)op1));
        }

        public static OpCode FromName(string op, Addr32 op1, Mm op2)
        {
            byte b;
            switch (op)
            {
                case "movd":
                    b = 0x7e;
                    break;
                case "movq":
                    b = 0x7f;
                    break;
                default:
                    throw new Exception("invalid operator: " + op);
            }
            return new OpCode(new byte[] { 0x0f, b }, null, new Addr32(op1, (byte)op2));
        }

        public static OpCode FromName(string op, Mm op1, Reg32 op2)
        {
            byte b;
            switch (op)
            {
                case "movd":
                    b = 0x6e;
                    break;
                default:
                    throw new Exception("invalid operator: " + op);
            }
            return new OpCode(new byte[] { 0x0f, b, (byte)(0xc0 + (((int)op1) << 3) + op2) });
        }

        public static OpCode FromName(string op, Reg32 op1, Mm op2)
        {
            byte b;
            switch (op)
            {
                case "movd":
                    b = 0x7e;
                    break;
                default:
                    throw new Exception("invalid operator: " + op);
            }
            return new OpCode(new byte[] { 0x0f, b, (byte)(0xc0 + (((int)op2) << 3) + op1) });
        }

        public static OpCode FromName(string op, Mm op1, byte op2)
        {
            byte b1 = 0, b2 = 0;
            switch (op)
            {
                case "psllw":
                case "psrlw":
                case "psraw":
                    b1 = 0x71;
                    break;
                case "pslld":
                case "psrld":
                case "psrad":
                    b1 = 0x72;
                    break;
                case "psllq":
                case "psrlq":
                    b1 = 0x73;
                    break;
            }
            switch (op)
            {
                case "psllw":
                case "pslld":
                case "psllq":
                    b2 = 0xf0;
                    break;
                case "psrlw":
                case "psrld":
                case "psrlq":
                    b2 = 0xd0;
                    break;
                case "psraw":
                case "psrad":
                    b2 = 0xe0;
                    break;
            }
            if (b1 == 0 || b2 == 0)
                throw new Exception("invalid operator: " + op);
            return new OpCode(new byte[] { 0x0f, b1, (byte)(b2 + op1) }, op2);
        }
    }
}
