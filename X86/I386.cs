using System;
using System.Collections.Generic;
using System.Text;
using CoffLib.Binary;

namespace CoffLib.X86
{
    public partial class I386
    {
        public static OpCode Jmp(Addr32 op1)
        {
            return new OpCode(new byte[] { 0xff }, null, new Addr32(op1, 4));
        }

        public static OpCode Jmp(Val32 op1)
        {
            return new OpCode(new byte[] { 0xe9 }, op1, true);
        }

        public static OpCode Jcc(Cc c, Val32 op1)
        {
            return new OpCode(new byte[] { 0x0f, (byte)(0x80 + c) }, op1, true);
        }

        public static OpCode Ret(ushort op1)
        {
            return new OpCode(new byte[] { 0xc2 }, op1);
        }

        public static OpCode Loop(Val32 op1)
        {
            return new OpCode(new byte[] { 0xe2 }, op1, true) { ByteRelative = true };
        }

        public static OpCode Lea(Reg32 op1, Addr32 op2)
        {
            return new OpCode(new byte[] { 0x8d }, null, new Addr32(op2, (byte)op1));
        }

        public static OpCode Setcc(Cc c, Reg8 op1)
        {
            return new OpCode(new byte[] { 0x0f, (byte)(0x90 + c), (byte)(0xc0 + op1) });
        }

        public static OpCode Enter(ushort op1, byte op2)
        {
            return new OpCode(new byte[] { 0xc8 }, op1, op2);
        }

        public static OpCode Nop() { return FromName("nop"); }
        public static OpCode Ret() { return FromName("ret"); }
        public static OpCode Cdq() { return FromName("cdq"); }
        public static OpCode Cld() { return FromName("cld"); }
        public static OpCode Std() { return FromName("std"); }
        public static OpCode Rep() { return FromName("rep"); }
        public static OpCode Leave() { return FromName("leave"); }
        public static OpCode Movsb() { return FromName("movsb"); }
        public static OpCode Movsw() { return FromName("movsw"); }
        public static OpCode Movsd() { return FromName("movsd"); }
        public static OpCode Stosb() { return FromName("stosb"); }
        public static OpCode Stosw() { return FromName("stosw"); }
        public static OpCode Stosd() { return FromName("stosd"); }
        public static OpCode Pushf() { return FromName("pushf"); }
        public static OpCode Popf() { return FromName("popf"); }

        public static OpCode FromName(string op)
        {
            switch (op)
            {
                case "nop":
                    return new OpCode(new byte[] { 0x90 });
                case "ret":
                    return new OpCode(new byte[] { 0xc3 });
                case "cdq":
                    return new OpCode(new byte[] { 0x99 });
                case "cld":
                    return new OpCode(new byte[] { 0xfc });
                case "std":
                    return new OpCode(new byte[] { 0xfd });
                case "rep":
                    return new OpCode(new byte[] { 0xf3 });
                case "leave":
                    return new OpCode(new byte[] { 0xc9 });
                case "movsb":
                    return new OpCode(new byte[] { 0xa4 });
                case "movsw":
                    return new OpCode(new byte[] { 0x66, 0xa5 });
                case "movsd":
                    return new OpCode(new byte[] { 0xa5 });
                case "stosb":
                    return new OpCode(new byte[] { 0xaa });
                case "stosw":
                    return new OpCode(new byte[] { 0x66, 0xab });
                case "stosd":
                    return new OpCode(new byte[] { 0xab });
                case "pushf":
                    return new OpCode(new byte[] { 0x9c });
                case "popf":
                    return new OpCode(new byte[] { 0x9d });
                default:
                    throw new Exception("invalid operator: " + op);
            }
        }
    }
}
