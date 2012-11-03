using System;
using System.Collections.Generic;
using System.Text;
using CoffLib.Binary;

namespace CoffLib.X86
{
    public class Addr32
    {
        private bool isInitialized = true;
        public bool IsInitialized { get { return isInitialized; } }

        private Reg32 reg;
        public Reg32 Register { get { return reg; } }

        private int disp = 0;
        public int Disp { get { return disp; } }

        private Val32 address;
        public Val32 Address { get { return address; } }
        public bool IsAddress { get { return address != null; } }

        private byte middleBits = 0;

        public Addr32() { isInitialized = false; }
        public Addr32(Reg32 r) { reg = r; }
        public Addr32(Reg32 r, int offset) { reg = r; disp = offset; }
        public Addr32(Val32 ad) { address = ad; }
        public Addr32(Addr32 src) { Set(src); }
        public Addr32(Addr32 src, byte middleBits)
            : this(src)
        {
            this.middleBits = middleBits;
        }

        public void Set(Addr32 src)
        {
            isInitialized = src.isInitialized;
            reg = src.reg;
            disp = src.disp;
            address = src.address;
            middleBits = src.middleBits;
        }

        private byte[] GetModRM()
        {
            if (address != null)
                return Util.GetBytes(new byte[] { 0x05 }, address.Value);

            sbyte sbdisp = (sbyte)disp;
            if (reg == Reg32.ESP)
            {
                if (disp == 0)
                    return new byte[] { 0x04, 0x24 };
                else if (disp == sbdisp)
                    return new byte[] { 0x44, 0x24, (byte)sbdisp };
                else
                    return Util.GetBytes(new byte[] { 0x84, 0x24 }, (uint)disp);
            }
            else if (reg == Reg32.EBP || disp != 0)
            {
                if (disp == sbdisp)
                    return new byte[] { (byte)(0x40 + (int)reg), (byte)sbdisp };
                else
                    return Util.GetBytes(new byte[] { (byte)(0x80 + (int)reg) }, (uint)disp);
            }
            else
            {
                return new byte[] { (byte)reg };
            }
        }

        public byte[] GetCodes()
        {
            byte[] ret = GetModRM();
            ret[0] += (byte)(middleBits << 3);
            return ret;
        }

        public void Write(Block block)
        {
            if (address != null)
            {
                block.Add((byte)(0x05 + (middleBits << 3)));
                block.Add(address);
            }
            else
            {
                block.Add(GetCodes());
            }
        }

        public void Add(int n)
        {
            if (n == 0) return;

            if (address != null)
            {
                address = new Val32(address, (uint)n);
            }
            else
            {
                disp += n;
            }
        }
    }
}
