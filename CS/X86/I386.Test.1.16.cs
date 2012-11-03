using System;
using System.Collections.Generic;
using System.Text;
using CoffLib.Binary;

namespace CoffLib.X86
{
    public partial class I386
    {
        public static void Test1_16()
        {
            // Push, Pop, Inc, Dec, Not, Neg, Mul, Imul, Div, Idiv

            // Push
            PushW((ushort)0x1234)
                .Test("push word 0x1234", "66-68-34-12");
            PushW(Reg16.AX)
                .Test("push ax", "66-50");
            PushW(Reg16.SP)
                .Test("push sp", "66-54");
            PushW(new Addr32(Reg32.EAX))
                .Test("push word [eax]", "66-FF-30");
            PushW(new Addr32(Reg32.EBP))
                .Test("push word [ebp]", "66-FF-75-00");
            PushW(new Addr32(Reg32.EBP, -4))
                .Test("push word [ebp-4]", "66-FF-75-FC");
            PushW(new Addr32(Reg32.ESI, 0x1000))
                .Test("push word [esi+0x1000]", "66-FF-B6-00-10-00-00");

            // Pop
            PopW(Reg16.AX)
                .Test("pop ax", "66-58");
            PopW(Reg16.SP)
                .Test("pop sp", "66-5C");
            PopW(new Addr32(Reg32.EAX))
                .Test("pop word [eax]", "66-8F-00");
            PopW(new Addr32(Reg32.EBP))
                .Test("pop word [ebp]", "66-8F-45-00");
            PopW(new Addr32(Reg32.EBP, -4))
                .Test("pop word [ebp-4]", "66-8F-45-FC");
            PopW(new Addr32(Reg32.ESI, 0x1000))
                .Test("pop word [esi+0x1000]", "66-8F-86-00-10-00-00");

            // Inc
            IncW(Reg16.AX)
                .Test("inc ax", "66-40");
            IncW(Reg16.SP)
                .Test("inc sp", "66-44");
            IncW(new Addr32(Reg32.EAX))
                .Test("inc word [eax]", "66-FF-00");
            IncW(new Addr32(Reg32.EBP))
                .Test("inc word [ebp]", "66-FF-45-00");
            IncW(new Addr32(Reg32.EBP, -4))
                .Test("inc word [ebp-4]", "66-FF-45-FC");
            IncW(new Addr32(Reg32.ESI, 0x1000))
                .Test("inc word [esi+0x1000]", "66-FF-86-00-10-00-00");

            // Dec
            DecW(Reg16.AX)
                .Test("dec ax", "66-48");
            DecW(Reg16.SP)
                .Test("dec sp", "66-4C");
            DecW(new Addr32(Reg32.EAX))
                .Test("dec word [eax]", "66-FF-08");
            DecW(new Addr32(Reg32.EBP))
                .Test("dec word [ebp]", "66-FF-4D-00");
            DecW(new Addr32(Reg32.EBP, -4))
                .Test("dec word [ebp-4]", "66-FF-4D-FC");
            DecW(new Addr32(Reg32.ESI, 0x1000))
                .Test("dec word [esi+0x1000]", "66-FF-8E-00-10-00-00");

            // Not
            NotW(Reg16.AX)
                .Test("not ax", "66-F7-D0");
            NotW(Reg16.SP)
                .Test("not sp", "66-F7-D4");
            NotW(new Addr32(Reg32.EAX))
                .Test("not word [eax]", "66-F7-10");
            NotW(new Addr32(Reg32.EBP))
                .Test("not word [ebp]", "66-F7-55-00");
            NotW(new Addr32(Reg32.EBP, -4))
                .Test("not word [ebp-4]", "66-F7-55-FC");
            NotW(new Addr32(Reg32.ESI, 0x1000))
                .Test("not word [esi+0x1000]", "66-F7-96-00-10-00-00");

            // Neg
            NegW(Reg16.AX)
                .Test("neg ax", "66-F7-D8");
            NegW(Reg16.SP)
                .Test("neg sp", "66-F7-DC");
            NegW(new Addr32(Reg32.EAX))
                .Test("neg word [eax]", "66-F7-18");
            NegW(new Addr32(Reg32.EBP))
                .Test("neg word [ebp]", "66-F7-5D-00");
            NegW(new Addr32(Reg32.EBP, -4))
                .Test("neg word [ebp-4]", "66-F7-5D-FC");
            NegW(new Addr32(Reg32.ESI, 0x1000))
                .Test("neg word [esi+0x1000]", "66-F7-9E-00-10-00-00");

            // Mul
            MulW(Reg16.AX)
                .Test("mul ax", "66-F7-E0");
            MulW(Reg16.SP)
                .Test("mul sp", "66-F7-E4");
            MulW(new Addr32(Reg32.EAX))
                .Test("mul word [eax]", "66-F7-20");
            MulW(new Addr32(Reg32.EBP))
                .Test("mul word [ebp]", "66-F7-65-00");
            MulW(new Addr32(Reg32.EBP, -4))
                .Test("mul word [ebp-4]", "66-F7-65-FC");
            MulW(new Addr32(Reg32.ESI, 0x1000))
                .Test("mul word [esi+0x1000]", "66-F7-A6-00-10-00-00");

            // Imul
            ImulW(Reg16.AX)
                .Test("imul ax", "66-F7-E8");
            ImulW(Reg16.SP)
                .Test("imul sp", "66-F7-EC");
            ImulW(new Addr32(Reg32.EAX))
                .Test("imul word [eax]", "66-F7-28");
            ImulW(new Addr32(Reg32.EBP))
                .Test("imul word [ebp]", "66-F7-6D-00");
            ImulW(new Addr32(Reg32.EBP, -4))
                .Test("imul word [ebp-4]", "66-F7-6D-FC");
            ImulW(new Addr32(Reg32.ESI, 0x1000))
                .Test("imul word [esi+0x1000]", "66-F7-AE-00-10-00-00");

            // Div
            DivW(Reg16.AX)
                .Test("div ax", "66-F7-F0");
            DivW(Reg16.SP)
                .Test("div sp", "66-F7-F4");
            DivW(new Addr32(Reg32.EAX))
                .Test("div word [eax]", "66-F7-30");
            DivW(new Addr32(Reg32.EBP))
                .Test("div word [ebp]", "66-F7-75-00");
            DivW(new Addr32(Reg32.EBP, -4))
                .Test("div word [ebp-4]", "66-F7-75-FC");
            DivW(new Addr32(Reg32.ESI, 0x1000))
                .Test("div word [esi+0x1000]", "66-F7-B6-00-10-00-00");

            // Idiv
            IdivW(Reg16.AX)
                .Test("idiv ax", "66-F7-F8");
            IdivW(Reg16.SP)
                .Test("idiv sp", "66-F7-FC");
            IdivW(new Addr32(Reg32.EAX))
                .Test("idiv word [eax]", "66-F7-38");
            IdivW(new Addr32(Reg32.EBP))
                .Test("idiv word [ebp]", "66-F7-7D-00");
            IdivW(new Addr32(Reg32.EBP, -4))
                .Test("idiv word [ebp-4]", "66-F7-7D-FC");
            IdivW(new Addr32(Reg32.ESI, 0x1000))
                .Test("idiv word [esi+0x1000]", "66-F7-BE-00-10-00-00");
        }
    }
}
