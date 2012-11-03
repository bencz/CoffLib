using System;
using System.Collections.Generic;
using System.Text;
using CoffLib.Binary;

namespace CoffLib.X86
{
    public partial class I386
    {
        public static void Test()
        {
            Test1_32();
            Test1_16();
            Test1_8();
            Test2_32();
            Test2_16();
            Test2_8();
            TestShift_32();
            TestShift_16();
            TestShift_8();
            TestMovx_16();
            TestMovx_8();

            Call(new Addr32(Reg32.EAX))
                .Test("call [eax]", "FF-10");
            Call(new Addr32(0x12345678))
                .Test("call [0x12345678]", "FF-15-78-56-34-12");

            Jmp(new Addr32(Reg32.EAX))
                .Test("jmp [eax]", "FF-20");
            Jmp(new Addr32(0x12345678))
                .Test("jmp [0x12345678]", "FF-25-78-56-34-12");

            Lea(Reg32.EAX, new Addr32(0x12345678))
                .Test("lea eax, [0x12345678]", "8D-05-78-56-34-12");
            Lea(Reg32.EAX, new Addr32(Reg32.EDX, -4))
                .Test("lea eax, [edx-4]", "8D-42-FC");
            Lea(Reg32.EAX, new Addr32(Reg32.EBP, -4))
                .Test("lea eax, [ebp-4]", "8D-45-FC");

            Ret()
                .Test("ret", "C3");
            Ret(8)
                .Test("ret 8", "C2-08-00");

            Setcc(Cc.A, Reg8.AL)
                .Test("seta al", "0F-97-C0");
            Setcc(Cc.NZ, Reg8.AH)
                .Test("setnz ah", "0F-95-C4");
            Setcc(Cc.NG, Reg8.BH)
                .Test("setng bh", "0F-9E-C7");

            Enter(0x1234, 10)
                .Test("enter 0x1234, 10", "C8-34-12-0A");
            Leave()
                .Test("leave", "C9");
            Nop()
                .Test("nop", "90");
            Cdq()
                .Test("cdq", "99");
        }
    }
}
