using System;
using System.Collections.Generic;
using System.Text;
using CoffLib.Binary;

namespace CoffLib.X86
{
    public class I8086
    {
        public static OpCode Push(Reg16 op1)
        {
            return new OpCode(new byte[] { (byte)(0x50 + (int)op1) });
        }

        public static OpCode Push(SegReg op1)
        {
            switch (op1)
            {
                case SegReg.ES:
                    return new OpCode(new byte[] { 0x06 });
                case SegReg.CS:
                    return new OpCode(new byte[] { 0x0e });
            }
            throw new Exception("The method or operation is not implemented.");
        }

        public static OpCode Pop(Reg16 op1)
        {
            return new OpCode(new byte[] { (byte)(0x58 + (int)op1) });
        }

        public static OpCode Pop(SegReg op1)
        {
            switch (op1)
            {
                case SegReg.ES:
                    return new OpCode(new byte[] { 0x07 });
                case SegReg.DS:
                    return new OpCode(new byte[] { 0x1f });
            }
            throw new Exception("The method or operation is not implemented.");
        }

        public static OpCode Mov(Reg16 op1, ushort op2)
        {
            return new OpCode(new byte[] { (byte)(0xb8 + (int)op1) }, op2);
        }

        public static OpCode Mov(Reg8 op1, byte op2)
        {
            return new OpCode(new byte[] { (byte)(0xb0 + (int)op1) }, op2);
        }

        public static OpCode Inc(Reg16 op1)
        {
            return new OpCode(new byte[] { (byte)(0x40 + (int)op1) });
        }

        public static OpCode Dec(Reg16 op1)
        {
            return new OpCode(new byte[] { (byte)(0x48 + (int)op1) });
        }

        public static OpCode Int(byte op1)
        {
            return new OpCode(new byte[] { 0xcd }, op1);
        }
    }
}
