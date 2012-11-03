using System;
using System.Collections.Generic;
using System.Text;
using CoffLib.Binary;

namespace CoffLib.X86
{
    public partial class I386
    {
        public static void Test1_32()
        {
            // Push, Pop, Inc, Dec, Not, Neg, Mul, Imul, Div, Idiv

            // Push
            Push((Val32)0x12345678)
                .Test("push dword 0x12345678", "68-78-56-34-12");
            Push(Reg32.EAX)
                .Test("push eax", "50");
            Push(Reg32.ESP)
                .Test("push esp", "54");
            Push(new Addr32(Reg32.EAX))
                .Test("push dword [eax]", "FF-30");
            Push(new Addr32(Reg32.EBP))
                .Test("push dword [ebp]", "FF-75-00");
            Push(new Addr32(Reg32.EBP, -4))
                .Test("push dword [ebp-4]", "FF-75-FC");
            Push(new Addr32(Reg32.ESI, 0x1000))
                .Test("push dword [esi+0x1000]", "FF-B6-00-10-00-00");

            // Pop
            Pop(Reg32.EAX)
                .Test("pop eax", "58");
            Pop(Reg32.ESP)
                .Test("pop esp", "5C");
            Pop(new Addr32(Reg32.EAX))
                .Test("pop dword [eax]", "8F-00");
            Pop(new Addr32(Reg32.EBP))
                .Test("pop dword [ebp]", "8F-45-00");
            Pop(new Addr32(Reg32.EBP, -4))
                .Test("pop dword [ebp-4]", "8F-45-FC");
            Pop(new Addr32(Reg32.ESI, 0x1000))
                .Test("pop dword [esi+0x1000]", "8F-86-00-10-00-00");

            // Inc
            Inc(Reg32.EAX)
                .Test("inc eax", "40");
            Inc(Reg32.ESP)
                .Test("inc esp", "44");
            Inc(new Addr32(Reg32.EAX))
                .Test("inc dword [eax]", "FF-00");
            Inc(new Addr32(Reg32.EBP))
                .Test("inc dword [ebp]", "FF-45-00");
            Inc(new Addr32(Reg32.EBP, -4))
                .Test("inc dword [ebp-4]", "FF-45-FC");
            Inc(new Addr32(Reg32.ESI, 0x1000))
                .Test("inc dword [esi+0x1000]", "FF-86-00-10-00-00");

            // Dec
            Dec(Reg32.EAX)
                .Test("dec eax", "48");
            Dec(Reg32.ESP)
                .Test("dec esp", "4C");
            Dec(new Addr32(Reg32.EAX))
                .Test("dec dword [eax]", "FF-08");
            Dec(new Addr32(Reg32.EBP))
                .Test("dec dword [ebp]", "FF-4D-00");
            Dec(new Addr32(Reg32.EBP, -4))
                .Test("dec dword [ebp-4]", "FF-4D-FC");
            Dec(new Addr32(Reg32.ESI, 0x1000))
                .Test("dec dword [esi+0x1000]", "FF-8E-00-10-00-00");

            // Not
            Not(Reg32.EAX)
                .Test("not eax", "F7-D0");
            Not(Reg32.ESP)
                .Test("not esp", "F7-D4");
            Not(new Addr32(Reg32.EAX))
                .Test("not dword [eax]", "F7-10");
            Not(new Addr32(Reg32.EBP))
                .Test("not dword [ebp]", "F7-55-00");
            Not(new Addr32(Reg32.EBP, -4))
                .Test("not dword [ebp-4]", "F7-55-FC");
            Not(new Addr32(Reg32.ESI, 0x1000))
                .Test("not dword [esi+0x1000]", "F7-96-00-10-00-00");

            // Neg
            Neg(Reg32.EAX)
                .Test("neg eax", "F7-D8");
            Neg(Reg32.ESP)
                .Test("neg esp", "F7-DC");
            Neg(new Addr32(Reg32.EAX))
                .Test("neg dword [eax]", "F7-18");
            Neg(new Addr32(Reg32.EBP))
                .Test("neg dword [ebp]", "F7-5D-00");
            Neg(new Addr32(Reg32.EBP, -4))
                .Test("neg dword [ebp-4]", "F7-5D-FC");
            Neg(new Addr32(Reg32.ESI, 0x1000))
                .Test("neg dword [esi+0x1000]", "F7-9E-00-10-00-00");

            // Mul
            Mul(Reg32.EAX)
                .Test("mul eax", "F7-E0");
            Mul(Reg32.ESP)
                .Test("mul esp", "F7-E4");
            Mul(new Addr32(Reg32.EAX))
                .Test("mul dword [eax]", "F7-20");
            Mul(new Addr32(Reg32.EBP))
                .Test("mul dword [ebp]", "F7-65-00");
            Mul(new Addr32(Reg32.EBP, -4))
                .Test("mul dword [ebp-4]", "F7-65-FC");
            Mul(new Addr32(Reg32.ESI, 0x1000))
                .Test("mul dword [esi+0x1000]", "F7-A6-00-10-00-00");

            // Imul
            Imul(Reg32.EAX)
                .Test("imul eax", "F7-E8");
            Imul(Reg32.ESP)
                .Test("imul esp", "F7-EC");
            Imul(new Addr32(Reg32.EAX))
                .Test("imul dword [eax]", "F7-28");
            Imul(new Addr32(Reg32.EBP))
                .Test("imul dword [ebp]", "F7-6D-00");
            Imul(new Addr32(Reg32.EBP, -4))
                .Test("imul dword [ebp-4]", "F7-6D-FC");
            Imul(new Addr32(Reg32.ESI, 0x1000))
                .Test("imul dword [esi+0x1000]", "F7-AE-00-10-00-00");

            // Div
            Div(Reg32.EAX)
                .Test("div eax", "F7-F0");
            Div(Reg32.ESP)
                .Test("div esp", "F7-F4");
            Div(new Addr32(Reg32.EAX))
                .Test("div dword [eax]", "F7-30");
            Div(new Addr32(Reg32.EBP))
                .Test("div dword [ebp]", "F7-75-00");
            Div(new Addr32(Reg32.EBP, -4))
                .Test("div dword [ebp-4]", "F7-75-FC");
            Div(new Addr32(Reg32.ESI, 0x1000))
                .Test("div dword [esi+0x1000]", "F7-B6-00-10-00-00");

            // Idiv
            Idiv(Reg32.EAX)
                .Test("idiv eax", "F7-F8");
            Idiv(Reg32.ESP)
                .Test("idiv esp", "F7-FC");
            Idiv(new Addr32(Reg32.EAX))
                .Test("idiv dword [eax]", "F7-38");
            Idiv(new Addr32(Reg32.EBP))
                .Test("idiv dword [ebp]", "F7-7D-00");
            Idiv(new Addr32(Reg32.EBP, -4))
                .Test("idiv dword [ebp-4]", "F7-7D-FC");
            Idiv(new Addr32(Reg32.ESI, 0x1000))
                .Test("idiv dword [esi+0x1000]", "F7-BE-00-10-00-00");
        }
    }
}
