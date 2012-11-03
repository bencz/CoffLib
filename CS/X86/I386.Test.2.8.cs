using System;
using System.Collections.Generic;
using System.Text;
using CoffLib.Binary;

namespace CoffLib.X86
{
    public partial class I386
    {
        public static void Test2_8()
        {
            // Mov, Add, Or, Adc, Sbb, And, Sub, Xor, Cmp, Test, Xchg

            // Mov
            MovB(Reg8.AL, 4)
                .Test("mov al, 4", "B0-04");
            MovB(Reg8.AH, 4)
                .Test("mov ah, 4", "B4-04");
            MovB(Reg8.AL, Reg8.BL)
                .Test("mov al, bl", "88-D8");
            MovB(Reg8.BL, Reg8.AL)
                .Test("mov al, bl", "88-C3");
            MovB(Reg8.AL, new Addr32(Reg32.EDX))
                .Test("mov al, [edx]", "8A-02");
            MovB(Reg8.BL, new Addr32(Reg32.EAX))
                .Test("mov bl, [eax]", "8A-18");
            MovB(Reg8.CL, new Addr32(Reg32.ESP))
                .Test("mov cl, [esp]", "8A-0C-24");
            MovB(Reg8.BH, new Addr32(Reg32.EAX, 0x1000))
                .Test("mov bh, [eax+0x1000]", "8A-B8-00-10-00-00");
            MovB(new Addr32(Reg32.EDX), Reg8.AL)
                .Test("mov [edx], al", "88-02");
            MovB(new Addr32(Reg32.EAX), Reg8.BL)
                .Test("mov [eax], bl", "88-18");
            MovB(new Addr32(Reg32.ESP), Reg8.CL)
                .Test("mov [esp], cl", "88-0C-24");
            MovB(new Addr32(Reg32.EAX, 0x1000), Reg8.BH)
                .Test("mov [eax+0x1000], bh", "88-B8-00-10-00-00");
            MovB(new Addr32(Reg32.EAX), (byte)1)
                .Test("mov byte [eax], 1", "C6-00-01");
            MovB(new Addr32(Reg32.EBP, -4), (byte)8)
                .Test("mov byte [ebp-4], 8", "C6-45-FC-08");
            MovB(Reg8.AL, new Addr32(0x12345678))
                .Test("mov al, [0x12345678]", "A0-78-56-34-12");
            MovB(new Addr32(0x12345678), Reg8.AL)
                .Test("mov [0x12345678], al", "A2-78-56-34-12");

            // Add
            AddB(Reg8.AL, 4)
                .Test("add al, 4", "04-04");
            AddB(Reg8.AH, 4)
                .Test("add ah, 4", "80-C4-04");
            AddB(Reg8.AL, Reg8.BL)
                .Test("add al, bl", "00-D8");
            AddB(Reg8.AL, new Addr32(Reg32.EDX))
                .Test("add al, [edx]", "02-02");
            AddB(Reg8.BL, new Addr32(Reg32.EAX))
                .Test("add bl, [eax]", "02-18");
            AddB(Reg8.CL, new Addr32(Reg32.ESP))
                .Test("add cl, [esp]", "02-0C-24");
            AddB(Reg8.BH, new Addr32(Reg32.EAX, 0x1000))
                .Test("add bh, [eax+0x1000]", "02-B8-00-10-00-00");
            AddB(new Addr32(Reg32.EDX), Reg8.AL)
                .Test("add [edx], al", "00-02");
            AddB(new Addr32(Reg32.EAX), Reg8.BL)
                .Test("add [eax], bl", "00-18");
            AddB(new Addr32(Reg32.ESP), Reg8.CL)
                .Test("add [esp], cl", "00-0C-24");
            AddB(new Addr32(Reg32.EAX, 0x1000), Reg8.BH)
                .Test("add [eax+0x1000], bh", "00-B8-00-10-00-00");
            AddB(new Addr32(Reg32.EAX), (byte)1)
                .Test("add byte [eax], 1", "80-00-01");
            AddB(new Addr32(Reg32.EBP, -4), (byte)8)
                .Test("add byte [ebp-4], 8", "80-45-FC-08");

            // Or
            OrB(Reg8.AL, 4)
                .Test("or al, 4", "0C-04");
            OrB(Reg8.AH, 4)
                .Test("or ah, 4", "80-CC-04");
            OrB(Reg8.AL, Reg8.BL)
                .Test("or al, bl", "08-D8");
            OrB(Reg8.AL, new Addr32(Reg32.EDX))
                .Test("or al, [edx]", "0A-02");
            OrB(Reg8.BL, new Addr32(Reg32.EAX))
                .Test("or bl, [eax]", "0A-18");
            OrB(Reg8.CL, new Addr32(Reg32.ESP))
                .Test("or cl, [esp]", "0A-0C-24");
            OrB(Reg8.BH, new Addr32(Reg32.EAX, 0x1000))
                .Test("or bh, [eax+0x1000]", "0A-B8-00-10-00-00");
            OrB(new Addr32(Reg32.EDX), Reg8.AL)
                .Test("or [edx], al", "08-02");
            OrB(new Addr32(Reg32.EAX), Reg8.BL)
                .Test("or [eax], bl", "08-18");
            OrB(new Addr32(Reg32.ESP), Reg8.CL)
                .Test("or [esp], cl", "08-0C-24");
            OrB(new Addr32(Reg32.EAX, 0x1000), Reg8.BH)
                .Test("or [eax+0x1000], bh", "08-B8-00-10-00-00");
            OrB(new Addr32(Reg32.EAX), (byte)1)
                .Test("or byte [eax], 1", "80-08-01");
            OrB(new Addr32(Reg32.EBP, -4), (byte)8)
                .Test("or byte [ebp-4], 8", "80-4D-FC-08");

            // Adc
            AdcB(Reg8.AL, 4)
                .Test("adc al, 4", "14-04");
            AdcB(Reg8.AH, 4)
                .Test("adc ah, 4", "80-D4-04");
            AdcB(Reg8.AL, Reg8.BL)
                .Test("adc al, bl", "10-D8");
            AdcB(Reg8.AL, new Addr32(Reg32.EDX))
                .Test("adc al, [edx]", "12-02");
            AdcB(Reg8.BL, new Addr32(Reg32.EAX))
                .Test("adc bl, [eax]", "12-18");
            AdcB(Reg8.CL, new Addr32(Reg32.ESP))
                .Test("adc cl, [esp]", "12-0C-24");
            AdcB(Reg8.BH, new Addr32(Reg32.EAX, 0x1000))
                .Test("adc bh, [eax+0x1000]", "12-B8-00-10-00-00");
            AdcB(new Addr32(Reg32.EDX), Reg8.AL)
                .Test("adc [edx], al", "10-02");
            AdcB(new Addr32(Reg32.EAX), Reg8.BL)
                .Test("adc [eax], bl", "10-18");
            AdcB(new Addr32(Reg32.ESP), Reg8.CL)
                .Test("adc [esp], cl", "10-0C-24");
            AdcB(new Addr32(Reg32.EAX, 0x1000), Reg8.BH)
                .Test("adc [eax+0x1000], bh", "10-B8-00-10-00-00");
            AdcB(new Addr32(Reg32.EAX), (byte)1)
                .Test("adc byte [eax], 1", "80-10-01");
            AdcB(new Addr32(Reg32.EBP, -4), (byte)8)
                .Test("adc byte [ebp-4], 8", "80-55-FC-08");

            // Sbb
            SbbB(Reg8.AL, 4)
                .Test("sbb al, 4", "1C-04");
            SbbB(Reg8.AH, 4)
                .Test("sbb ah, 4", "80-DC-04");
            SbbB(Reg8.AL, Reg8.BL)
                .Test("sbb al, bl", "18-D8");
            SbbB(Reg8.AL, new Addr32(Reg32.EDX))
                .Test("sbb al, [edx]", "1A-02");
            SbbB(Reg8.BL, new Addr32(Reg32.EAX))
                .Test("sbb bl, [eax]", "1A-18");
            SbbB(Reg8.CL, new Addr32(Reg32.ESP))
                .Test("sbb cl, [esp]", "1A-0C-24");
            SbbB(Reg8.BH, new Addr32(Reg32.EAX, 0x1000))
                .Test("sbb bh, [eax+0x1000]", "1A-B8-00-10-00-00");
            SbbB(new Addr32(Reg32.EDX), Reg8.AL)
                .Test("sbb [edx], al", "18-02");
            SbbB(new Addr32(Reg32.EAX), Reg8.BL)
                .Test("sbb [eax], bl", "18-18");
            SbbB(new Addr32(Reg32.ESP), Reg8.CL)
                .Test("sbb [esp], cl", "18-0C-24");
            SbbB(new Addr32(Reg32.EAX, 0x1000), Reg8.BH)
                .Test("sbb [eax+0x1000], bh", "18-B8-00-10-00-00");
            SbbB(new Addr32(Reg32.EAX), (byte)1)
                .Test("sbb byte [eax], 1", "80-18-01");
            SbbB(new Addr32(Reg32.EBP, -4), (byte)8)
                .Test("sbb byte [ebp-4], 8", "80-5D-FC-08");

            // And
            AndB(Reg8.AL, 4)
                .Test("and al, 4", "24-04");
            AndB(Reg8.AH, 4)
                .Test("and ah, 4", "80-E4-04");
            AndB(Reg8.AL, Reg8.BL)
                .Test("and al, bl", "20-D8");
            AndB(Reg8.AL, new Addr32(Reg32.EDX))
                .Test("and al, [edx]", "22-02");
            AndB(Reg8.BL, new Addr32(Reg32.EAX))
                .Test("and bl, [eax]", "22-18");
            AndB(Reg8.CL, new Addr32(Reg32.ESP))
                .Test("and cl, [esp]", "22-0C-24");
            AndB(Reg8.BH, new Addr32(Reg32.EAX, 0x1000))
                .Test("and bh, [eax+0x1000]", "22-B8-00-10-00-00");
            AndB(new Addr32(Reg32.EDX), Reg8.AL)
                .Test("and [edx], al", "20-02");
            AndB(new Addr32(Reg32.EAX), Reg8.BL)
                .Test("and [eax], bl", "20-18");
            AndB(new Addr32(Reg32.ESP), Reg8.CL)
                .Test("and [esp], cl", "20-0C-24");
            AndB(new Addr32(Reg32.EAX, 0x1000), Reg8.BH)
                .Test("and [eax+0x1000], bh", "20-B8-00-10-00-00");
            AndB(new Addr32(Reg32.EAX), (byte)1)
                .Test("and byte [eax], 1", "80-20-01");
            AndB(new Addr32(Reg32.EBP, -4), (byte)8)
                .Test("and byte [ebp-4], 8", "80-65-FC-08");

            // Sub
            SubB(Reg8.AL, 4)
                .Test("sub al, 4", "2C-04");
            SubB(Reg8.AH, 4)
                .Test("sub ah, 4", "80-EC-04");
            SubB(Reg8.AL, Reg8.BL)
                .Test("sub al, bl", "28-D8");
            SubB(Reg8.AL, new Addr32(Reg32.EDX))
                .Test("sub al, [edx]", "2A-02");
            SubB(Reg8.BL, new Addr32(Reg32.EAX))
                .Test("sub bl, [eax]", "2A-18");
            SubB(Reg8.CL, new Addr32(Reg32.ESP))
                .Test("sub cl, [esp]", "2A-0C-24");
            SubB(Reg8.BH, new Addr32(Reg32.EAX, 0x1000))
                .Test("sub bh, [eax+0x1000]", "2A-B8-00-10-00-00");
            SubB(new Addr32(Reg32.EDX), Reg8.AL)
                .Test("sub [edx], al", "28-02");
            SubB(new Addr32(Reg32.EAX), Reg8.BL)
                .Test("sub [eax], bl", "28-18");
            SubB(new Addr32(Reg32.ESP), Reg8.CL)
                .Test("sub [esp], cl", "28-0C-24");
            SubB(new Addr32(Reg32.EAX, 0x1000), Reg8.BH)
                .Test("sub [eax+0x1000], bh", "28-B8-00-10-00-00");
            SubB(new Addr32(Reg32.EAX), (byte)1)
                .Test("sub byte [eax], 1", "80-28-01");
            SubB(new Addr32(Reg32.EBP, -4), (byte)8)
                .Test("sub byte [ebp-4], 8", "80-6D-FC-08");

            // Xor
            XorB(Reg8.AL, 4)
                .Test("xor al, 4", "34-04");
            XorB(Reg8.AH, 4)
                .Test("xor ah, 4", "80-F4-04");
            XorB(Reg8.AL, Reg8.BL)
                .Test("xor al, bl", "30-D8");
            XorB(Reg8.AL, new Addr32(Reg32.EDX))
                .Test("xor al, [edx]", "32-02");
            XorB(Reg8.BL, new Addr32(Reg32.EAX))
                .Test("xor bl, [eax]", "32-18");
            XorB(Reg8.CL, new Addr32(Reg32.ESP))
                .Test("xor cl, [esp]", "32-0C-24");
            XorB(Reg8.BH, new Addr32(Reg32.EAX, 0x1000))
                .Test("xor bh, [eax+0x1000]", "32-B8-00-10-00-00");
            XorB(new Addr32(Reg32.EDX), Reg8.AL)
                .Test("xor [edx], al", "30-02");
            XorB(new Addr32(Reg32.EAX), Reg8.BL)
                .Test("xor [eax], bl", "30-18");
            XorB(new Addr32(Reg32.ESP), Reg8.CL)
                .Test("xor [esp], cl", "30-0C-24");
            XorB(new Addr32(Reg32.EAX, 0x1000), Reg8.BH)
                .Test("xor [eax+0x1000], bh", "30-B8-00-10-00-00");
            XorB(new Addr32(Reg32.EAX), (byte)1)
                .Test("xor byte [eax], 1", "80-30-01");
            XorB(new Addr32(Reg32.EBP, -4), (byte)8)
                .Test("xor byte [ebp-4], 8", "80-75-FC-08");

            // Cmp
            CmpB(Reg8.AL, 4)
                .Test("cmp al, 4", "3C-04");
            CmpB(Reg8.AH, 4)
                .Test("cmp ah, 4", "80-FC-04");
            CmpB(Reg8.AL, Reg8.BL)
                .Test("cmp al, bl", "38-D8");
            CmpB(Reg8.AL, new Addr32(Reg32.EDX))
                .Test("cmp al, [edx]", "3A-02");
            CmpB(Reg8.BL, new Addr32(Reg32.EAX))
                .Test("cmp bl, [eax]", "3A-18");
            CmpB(Reg8.CL, new Addr32(Reg32.ESP))
                .Test("cmp cl, [esp]", "3A-0C-24");
            CmpB(Reg8.BH, new Addr32(Reg32.EAX, 0x1000))
                .Test("cmp bh, [eax+0x1000]", "3A-B8-00-10-00-00");
            CmpB(new Addr32(Reg32.EDX), Reg8.AL)
                .Test("cmp [edx], al", "38-02");
            CmpB(new Addr32(Reg32.EAX), Reg8.BL)
                .Test("cmp [eax], bl", "38-18");
            CmpB(new Addr32(Reg32.ESP), Reg8.CL)
                .Test("cmp [esp], cl", "38-0C-24");
            CmpB(new Addr32(Reg32.EAX, 0x1000), Reg8.BH)
                .Test("cmp [eax+0x1000], bh", "38-B8-00-10-00-00");
            CmpB(new Addr32(Reg32.EAX), (byte)1)
                .Test("cmp byte [eax], 1", "80-38-01");
            CmpB(new Addr32(Reg32.EBP, -4), (byte)8)
                .Test("cmp byte [ebp-4], 8", "80-7D-FC-08");

            // Test
            TestB(Reg8.AL, 4)
                .Test("test al, 4", "A8-04");
            TestB(Reg8.AH, 4)
                .Test("test ah, 4", "F6-C4-04");
            TestB(Reg8.AL, Reg8.BL)
                .Test("test al, bl", "84-D8");
            TestB(new Addr32(Reg32.EDX), Reg8.AL)
                .Test("test [edx], al", "84-02");
            TestB(new Addr32(Reg32.EAX), Reg8.BL)
                .Test("test [eax], bl", "84-18");
            TestB(new Addr32(Reg32.ESP), Reg8.CL)
                .Test("test [esp], cl", "84-0C-24");
            TestB(new Addr32(Reg32.EAX, 0x1000), Reg8.BH)
                .Test("test [eax+0x1000], bh", "84-B8-00-10-00-00");
            TestB(new Addr32(Reg32.EAX), (byte)1)
                .Test("test byte [eax], 1", "F6-00-01");
            TestB(new Addr32(Reg32.EBP, -4), (byte)8)
                .Test("test byte [ebp-4], 8", "F6-45-FC-08");

            // Xchg
            XchgB(Reg8.AL, Reg8.AL)
                .Test("xchg al, al", "86-C0");
            XchgB(Reg8.AL, Reg8.BL)
                .Test("xchg al, bl", "86-D8");
            XchgB(Reg8.BL, Reg8.AL)
                .Test("xchg bl, al", "86-C3");
            XchgB(Reg8.AL, new Addr32(Reg32.EDX))
                .Test("xchg al, [edx]", "86-02");
            XchgB(Reg8.BL, new Addr32(Reg32.EAX))
                .Test("xchg bl, [eax]", "86-18");
            XchgB(Reg8.CL, new Addr32(Reg32.ESP))
                .Test("xchg cl, [esp]", "86-0C-24");
            XchgB(Reg8.BH, new Addr32(Reg32.EAX, 0x1000))
                .Test("xchg bh, [eax+0x1000]", "86-B8-00-10-00-00");
            XchgB(new Addr32(Reg32.EDX), Reg8.AL)
                .Test("xchg [edx], al", "86-02");
        }
    }
}
