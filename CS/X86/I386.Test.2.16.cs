using System;
using System.Collections.Generic;
using System.Text;
using CoffLib.Binary;

namespace CoffLib.X86
{
    public partial class I386
    {
        public static void Test2_16()
        {
            // Mov, Add, Or, Adc, Sbb, And, Sub, Xor, Cmp, Test, Xchg

            // Mov
            MovW(Reg16.AX, 4)
                .Test("mov ax, 4", "66-B8-04-00");
            MovW(Reg16.SP, 4)
                .Test("mov sp, 4", "66-BC-04-00");
            MovW(Reg16.AX, Reg16.BX)
                .Test("mov ax, bx", "66-89-D8");
            MovW(Reg16.AX, new Addr32(Reg32.EDX))
                .Test("mov ax, [edx]", "66-8B-02");
            MovW(Reg16.BX, new Addr32(Reg32.EAX))
                .Test("mov bx, [eax]", "66-8B-18");
            MovW(Reg16.CX, new Addr32(Reg32.ESP))
                .Test("mov cx, [esp]", "66-8B-0C-24");
            MovW(Reg16.BP, new Addr32(Reg32.EAX, 0x1000))
                .Test("mov bp, [eax+0x1000]", "66-8B-A8-00-10-00-00");
            MovW(new Addr32(Reg32.EDX), Reg16.AX)
                .Test("mov [edx], ax", "66-89-02");
            MovW(new Addr32(Reg32.EAX), Reg16.BX)
                .Test("mov [eax], bx", "66-89-18");
            MovW(new Addr32(Reg32.ESP), Reg16.CX)
                .Test("mov [esp], cx", "66-89-0C-24");
            MovW(new Addr32(Reg32.EAX, 0x1000), Reg16.BP)
                .Test("mov [eax+0x1000], bp", "66-89-A8-00-10-00-00");
            MovW(new Addr32(Reg32.EAX), (ushort)1)
                .Test("mov word [eax], 1", "66-C7-00-01-00");
            MovW(new Addr32(Reg32.EBP, -4), (ushort)8)
                .Test("mov word [ebp-4], 8", "66-C7-45-FC-08-00");
            MovW(Reg16.AX, new Addr32(0x12345678))
                .Test("mov ax, [0x12345678]", "66-A1-78-56-34-12");
            MovW(new Addr32(0x12345678), Reg16.AX)
                .Test("mov [0x12345678], ax", "66-A3-78-56-34-12");

            // Add
            AddW(Reg16.AX, 4)
                .Test("add ax, 4", "66-05-04-00");
            AddW(Reg16.SP, 4)
                .Test("add sp, 4", "66-81-C4-04-00");
            AddW(Reg16.AX, Reg16.BX)
                .Test("add ax, bx", "66-01-D8");
            AddW(Reg16.AX, new Addr32(Reg32.EDX))
                .Test("add ax, [edx]", "66-03-02");
            AddW(Reg16.BX, new Addr32(Reg32.EAX))
                .Test("add bx, [eax]", "66-03-18");
            AddW(Reg16.CX, new Addr32(Reg32.ESP))
                .Test("add cx, [esp]", "66-03-0C-24");
            AddW(Reg16.BP, new Addr32(Reg32.EAX, 0x1000))
                .Test("add bp, [eax+0x1000]", "66-03-A8-00-10-00-00");
            AddW(new Addr32(Reg32.EDX), Reg16.AX)
                .Test("add [edx], ax", "66-01-02");
            AddW(new Addr32(Reg32.EAX), Reg16.BX)
                .Test("add [eax], bx", "66-01-18");
            AddW(new Addr32(Reg32.ESP), Reg16.CX)
                .Test("add [esp], cx", "66-01-0C-24");
            AddW(new Addr32(Reg32.EAX, 0x1000), Reg16.BP)
                .Test("add [eax+0x1000], bp", "66-01-A8-00-10-00-00");
            AddW(new Addr32(Reg32.EAX), (ushort)1)
                .Test("add word [eax], 1", "66-81-00-01-00");
            AddW(new Addr32(Reg32.EBP, -4), (ushort)8)
                .Test("add word [ebp-4], 8", "66-81-45-FC-08-00");

            // Or
            OrW(Reg16.AX, 4)
                .Test("or ax, 4", "66-0D-04-00");
            OrW(Reg16.SP, 4)
                .Test("or sp, 4", "66-81-CC-04-00");
            OrW(Reg16.AX, Reg16.BX)
                .Test("or ax, bx", "66-09-D8");
            OrW(Reg16.AX, new Addr32(Reg32.EDX))
                .Test("or ax, [edx]", "66-0B-02");
            OrW(Reg16.BX, new Addr32(Reg32.EAX))
                .Test("or bx, [eax]", "66-0B-18");
            OrW(Reg16.CX, new Addr32(Reg32.ESP))
                .Test("or cx, [esp]", "66-0B-0C-24");
            OrW(Reg16.BP, new Addr32(Reg32.EAX, 0x1000))
                .Test("or bp, [eax+0x1000]", "66-0B-A8-00-10-00-00");
            OrW(new Addr32(Reg32.EDX), Reg16.AX)
                .Test("or [edx], ax", "66-09-02");
            OrW(new Addr32(Reg32.EAX), Reg16.BX)
                .Test("or [eax], bx", "66-09-18");
            OrW(new Addr32(Reg32.ESP), Reg16.CX)
                .Test("or [esp], cx", "66-09-0C-24");
            OrW(new Addr32(Reg32.EAX, 0x1000), Reg16.BP)
                .Test("or [eax+0x1000], bp", "66-09-A8-00-10-00-00");
            OrW(new Addr32(Reg32.EAX), (ushort)1)
                .Test("or word [eax], 1", "66-81-08-01-00");
            OrW(new Addr32(Reg32.EBP, -4), (ushort)8)
                .Test("or word [ebp-4], 8", "66-81-4D-FC-08-00");

            // Adc
            AdcW(Reg16.AX, 4)
                .Test("adc ax, 4", "66-15-04-00");
            AdcW(Reg16.SP, 4)
                .Test("adc sp, 4", "66-81-D4-04-00");
            AdcW(Reg16.AX, Reg16.BX)
                .Test("adc ax, bx", "66-11-D8");
            AdcW(Reg16.AX, new Addr32(Reg32.EDX))
                .Test("adc ax, [edx]", "66-13-02");
            AdcW(Reg16.BX, new Addr32(Reg32.EAX))
                .Test("adc bx, [eax]", "66-13-18");
            AdcW(Reg16.CX, new Addr32(Reg32.ESP))
                .Test("adc cx, [esp]", "66-13-0C-24");
            AdcW(Reg16.BP, new Addr32(Reg32.EAX, 0x1000))
                .Test("adc bp, [eax+0x1000]", "66-13-A8-00-10-00-00");
            AdcW(new Addr32(Reg32.EDX), Reg16.AX)
                .Test("adc [edx], ax", "66-11-02");
            AdcW(new Addr32(Reg32.EAX), Reg16.BX)
                .Test("adc [eax], bx", "66-11-18");
            AdcW(new Addr32(Reg32.ESP), Reg16.CX)
                .Test("adc [esp], cx", "66-11-0C-24");
            AdcW(new Addr32(Reg32.EAX, 0x1000), Reg16.BP)
                .Test("adc [eax+0x1000], bp", "66-11-A8-00-10-00-00");
            AdcW(new Addr32(Reg32.EAX), (ushort)1)
                .Test("adc word [eax], 1", "66-81-10-01-00");
            AdcW(new Addr32(Reg32.EBP, -4), (ushort)8)
                .Test("adc word [ebp-4], 8", "66-81-55-FC-08-00");

            // Sbb
            SbbW(Reg16.AX, 4)
                .Test("sbb ax, 4", "66-1D-04-00");
            SbbW(Reg16.SP, 4)
                .Test("sbb sp, 4", "66-81-DC-04-00");
            SbbW(Reg16.AX, Reg16.BX)
                .Test("sbb ax, bx", "66-19-D8");
            SbbW(Reg16.AX, new Addr32(Reg32.EDX))
                .Test("sbb ax, [edx]", "66-1B-02");
            SbbW(Reg16.BX, new Addr32(Reg32.EAX))
                .Test("sbb bx, [eax]", "66-1B-18");
            SbbW(Reg16.CX, new Addr32(Reg32.ESP))
                .Test("sbb cx, [esp]", "66-1B-0C-24");
            SbbW(Reg16.BP, new Addr32(Reg32.EAX, 0x1000))
                .Test("sbb bp, [eax+0x1000]", "66-1B-A8-00-10-00-00");
            SbbW(new Addr32(Reg32.EDX), Reg16.AX)
                .Test("sbb [edx], ax", "66-19-02");
            SbbW(new Addr32(Reg32.EAX), Reg16.BX)
                .Test("sbb [eax], bx", "66-19-18");
            SbbW(new Addr32(Reg32.ESP), Reg16.CX)
                .Test("sbb [esp], cx", "66-19-0C-24");
            SbbW(new Addr32(Reg32.EAX, 0x1000), Reg16.BP)
                .Test("sbb [eax+0x1000], bp", "66-19-A8-00-10-00-00");
            SbbW(new Addr32(Reg32.EAX), (ushort)1)
                .Test("sbb word [eax], 1", "66-81-18-01-00");
            SbbW(new Addr32(Reg32.EBP, -4), (ushort)8)
                .Test("sbb word [ebp-4], 8", "66-81-5D-FC-08-00");

            // And
            AndW(Reg16.AX, 4)
                .Test("and ax, 4", "66-25-04-00");
            AndW(Reg16.SP, 4)
                .Test("and sp, 4", "66-81-E4-04-00");
            AndW(Reg16.AX, Reg16.BX)
                .Test("and ax, bx", "66-21-D8");
            AndW(Reg16.AX, new Addr32(Reg32.EDX))
                .Test("and ax, [edx]", "66-23-02");
            AndW(Reg16.BX, new Addr32(Reg32.EAX))
                .Test("and bx, [eax]", "66-23-18");
            AndW(Reg16.CX, new Addr32(Reg32.ESP))
                .Test("and cx, [esp]", "66-23-0C-24");
            AndW(Reg16.BP, new Addr32(Reg32.EAX, 0x1000))
                .Test("and bp, [eax+0x1000]", "66-23-A8-00-10-00-00");
            AndW(new Addr32(Reg32.EDX), Reg16.AX)
                .Test("and [edx], ax", "66-21-02");
            AndW(new Addr32(Reg32.EAX), Reg16.BX)
                .Test("and [eax], bx", "66-21-18");
            AndW(new Addr32(Reg32.ESP), Reg16.CX)
                .Test("and [esp], cx", "66-21-0C-24");
            AndW(new Addr32(Reg32.EAX, 0x1000), Reg16.BP)
                .Test("and [eax+0x1000], bp", "66-21-A8-00-10-00-00");
            AndW(new Addr32(Reg32.EAX), (ushort)1)
                .Test("and word [eax], 1", "66-81-20-01-00");
            AndW(new Addr32(Reg32.EBP, -4), (ushort)8)
                .Test("and word [ebp-4], 8", "66-81-65-FC-08-00");

            // Sub
            SubW(Reg16.AX, 4)
                .Test("sub ax, 4", "66-2D-04-00");
            SubW(Reg16.SP, 4)
                .Test("sub sp, 4", "66-81-EC-04-00");
            SubW(Reg16.AX, Reg16.BX)
                .Test("sub ax, bx", "66-29-D8");
            SubW(Reg16.AX, new Addr32(Reg32.EDX))
                .Test("sub ax, [edx]", "66-2B-02");
            SubW(Reg16.BX, new Addr32(Reg32.EAX))
                .Test("sub bx, [eax]", "66-2B-18");
            SubW(Reg16.CX, new Addr32(Reg32.ESP))
                .Test("sub cx, [esp]", "66-2B-0C-24");
            SubW(Reg16.BP, new Addr32(Reg32.EAX, 0x1000))
                .Test("sub bp, [eax+0x1000]", "66-2B-A8-00-10-00-00");
            SubW(new Addr32(Reg32.EDX), Reg16.AX)
                .Test("sub [edx], ax", "66-29-02");
            SubW(new Addr32(Reg32.EAX), Reg16.BX)
                .Test("sub [eax], bx", "66-29-18");
            SubW(new Addr32(Reg32.ESP), Reg16.CX)
                .Test("sub [esp], cx", "66-29-0C-24");
            SubW(new Addr32(Reg32.EAX, 0x1000), Reg16.BP)
                .Test("sub [eax+0x1000], bp", "66-29-A8-00-10-00-00");
            SubW(new Addr32(Reg32.EAX), (ushort)1)
                .Test("sub word [eax], 1", "66-81-28-01-00");
            SubW(new Addr32(Reg32.EBP, -4), (ushort)8)
                .Test("sub word [ebp-4], 8", "66-81-6D-FC-08-00");

            // Xor
            XorW(Reg16.AX, 4)
                .Test("xor ax, 4", "66-35-04-00");
            XorW(Reg16.SP, 4)
                .Test("xor sp, 4", "66-81-F4-04-00");
            XorW(Reg16.AX, Reg16.BX)
                .Test("xor ax, bx", "66-31-D8");
            XorW(Reg16.AX, new Addr32(Reg32.EDX))
                .Test("xor ax, [edx]", "66-33-02");
            XorW(Reg16.BX, new Addr32(Reg32.EAX))
                .Test("xor bx, [eax]", "66-33-18");
            XorW(Reg16.CX, new Addr32(Reg32.ESP))
                .Test("xor cx, [esp]", "66-33-0C-24");
            XorW(Reg16.BP, new Addr32(Reg32.EAX, 0x1000))
                .Test("xor bp, [eax+0x1000]", "66-33-A8-00-10-00-00");
            XorW(new Addr32(Reg32.EDX), Reg16.AX)
                .Test("xor [edx], ax", "66-31-02");
            XorW(new Addr32(Reg32.EAX), Reg16.BX)
                .Test("xor [eax], bx", "66-31-18");
            XorW(new Addr32(Reg32.ESP), Reg16.CX)
                .Test("xor [esp], cx", "66-31-0C-24");
            XorW(new Addr32(Reg32.EAX, 0x1000), Reg16.BP)
                .Test("xor [eax+0x1000], bp", "66-31-A8-00-10-00-00");
            XorW(new Addr32(Reg32.EAX), (ushort)1)
                .Test("xor word [eax], 1", "66-81-30-01-00");
            XorW(new Addr32(Reg32.EBP, -4), (ushort)8)
                .Test("xor word [ebp-4], 8", "66-81-75-FC-08-00");

            // Cmp
            CmpW(Reg16.AX, 4)
                .Test("cmp ax, 4", "66-3D-04-00");
            CmpW(Reg16.SP, 4)
                .Test("cmp sp, 4", "66-81-FC-04-00");
            CmpW(Reg16.AX, Reg16.BX)
                .Test("cmp ax, bx", "66-39-D8");
            CmpW(Reg16.AX, new Addr32(Reg32.EDX))
                .Test("cmp ax, [edx]", "66-3B-02");
            CmpW(Reg16.BX, new Addr32(Reg32.EAX))
                .Test("cmp bx, [eax]", "66-3B-18");
            CmpW(Reg16.CX, new Addr32(Reg32.ESP))
                .Test("cmp cx, [esp]", "66-3B-0C-24");
            CmpW(Reg16.BP, new Addr32(Reg32.EAX, 0x1000))
                .Test("cmp bp, [eax+0x1000]", "66-3B-A8-00-10-00-00");
            CmpW(new Addr32(Reg32.EDX), Reg16.AX)
                .Test("cmp [edx], ax", "66-39-02");
            CmpW(new Addr32(Reg32.EAX), Reg16.BX)
                .Test("cmp [eax], bx", "66-39-18");
            CmpW(new Addr32(Reg32.ESP), Reg16.CX)
                .Test("cmp [esp], cx", "66-39-0C-24");
            CmpW(new Addr32(Reg32.EAX, 0x1000), Reg16.BP)
                .Test("cmp [eax+0x1000], bp", "66-39-A8-00-10-00-00");
            CmpW(new Addr32(Reg32.EAX), (ushort)1)
                .Test("cmp word [eax], 1", "66-81-38-01-00");
            CmpW(new Addr32(Reg32.EBP, -4), (ushort)8)
                .Test("cmp word [ebp-4], 8", "66-81-7D-FC-08-00");

            // Test
            TestW(Reg16.AX, 4)
                .Test("test ax, 4", "66-A9-04-00");
            TestW(Reg16.SP, 4)
                .Test("test sp, 4", "66-F7-C4-04-00");
            TestW(Reg16.AX, Reg16.BX)
                .Test("test ax, bx", "66-85-D8");
            TestW(new Addr32(Reg32.EDX), Reg16.AX)
                .Test("test [edx], ax", "66-85-02");
            TestW(new Addr32(Reg32.EAX), Reg16.BX)
                .Test("test [eax], bx", "66-85-18");
            TestW(new Addr32(Reg32.ESP), Reg16.CX)
                .Test("test [esp], cx", "66-85-0C-24");
            TestW(new Addr32(Reg32.EAX, 0x1000), Reg16.BP)
                .Test("test [eax+0x1000], bp", "66-85-A8-00-10-00-00");
            TestW(new Addr32(Reg32.EAX), (ushort)1)
                .Test("test word [eax], 1", "66-F7-00-01-00");
            TestW(new Addr32(Reg32.EBP, -4), (ushort)8)
                .Test("test word [ebp-4], 8", "66-F7-45-FC-08-00");

            // Xchg
            XchgW(Reg16.AX, Reg16.AX)
                .Test("xchg ax, ax", "66-90");
            XchgW(Reg16.AX, Reg16.BX)
                .Test("xchg ax, bx", "66-93");
            XchgW(Reg16.BX, Reg16.AX)
                .Test("xchg bx, ax", "66-93");
            XchgW(Reg16.AX, new Addr32(Reg32.EDX))
                .Test("xchg ax, [edx]", "66-87-02");
            XchgW(Reg16.BX, new Addr32(Reg32.EAX))
                .Test("xchg bx, [eax]", "66-87-18");
            XchgW(Reg16.CX, new Addr32(Reg32.ESP))
                .Test("xchg cx, [esp]", "66-87-0C-24");
            XchgW(Reg16.BP, new Addr32(Reg32.EAX, 0x1000))
                .Test("xchg bp, [eax+0x1000]", "66-87-A8-00-10-00-00");
            XchgW(new Addr32(Reg32.EDX), Reg16.AX)
                .Test("xchg [edx], ax", "66-87-02");
        }
    }
}
