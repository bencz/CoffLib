using System;
using System.Collections.Generic;
using System.Text;
using CoffLib.Binary;

namespace CoffLib.X86
{
    public partial class MMX
    {
        public static void Test()
        {
            MovD(Mm._1, Reg32.EAX)
                .Test("movd mm1, eax", "0F-6E-C8");
            MovD(Mm._3, Reg32.ESP)
                .Test("movd mm3, esp", "0F-6E-DC");
            MovD(Mm._0, new Addr32(Reg32.EDX))
                .Test("movd mm0, [edx]", "0F-6E-02");
            MovD(Mm._4, new Addr32(Reg32.EAX, 0x1000))
                .Test("movd mm4, [eax+0x1000]", "0F-6E-A0-00-10-00-00");
            MovD(Mm._5, new Addr32(Reg32.EBP, -4))
                .Test("movd mm5, [ebp-4]", "0F-6E-6D-FC");
            MovD(Mm._7, new Addr32(0x12345678))
                .Test("movd mm7, [0x12345678]", "0F-6E-3D-78-56-34-12");
            MovD(Reg32.EAX, Mm._1)
                .Test("movd eax, mm1", "0F-7E-C8");
            MovD(Reg32.ESP, Mm._3)
                .Test("movd esp, mm3", "0F-7E-DC");
            MovD(new Addr32(Reg32.EDX), Mm._0)
                .Test("movd [edx], mm0", "0F-7E-02");
            MovD(new Addr32(Reg32.EAX, 0x1000), Mm._4)
                .Test("movd [eax+0x1000], mm4", "0F-7E-A0-00-10-00-00");
            MovD(new Addr32(Reg32.EBP, -4), Mm._5)
                .Test("movd [ebp-4], mm5", "0F-7E-6D-FC");
            MovD(new Addr32(0x12345678), Mm._7)
                .Test("movd [0x12345678], mm7", "0F-7E-3D-78-56-34-12");

            MovQ(Mm._1, Mm._0)
                .Test("movq mm1, mm0", "0F-6F-C8");
            MovQ(Mm._3, Mm._6)
                .Test("movq mm3, mm6", "0F-6F-DE");
            MovQ(Mm._0, new Addr32(Reg32.EDX))
                .Test("movq mm0, [edx]", "0F-6F-02");
            MovQ(Mm._4, new Addr32(Reg32.EAX, 0x1000))
                .Test("movq mm4, [eax+0x1000]", "0F-6F-A0-00-10-00-00");
            MovQ(Mm._5, new Addr32(Reg32.EBP, -4))
                .Test("movq mm5, [ebp-4]", "0F-6F-6D-FC");
            MovQ(Mm._7, new Addr32(0x12345678))
                .Test("movq mm7, [0x12345678]", "0F-6F-3D-78-56-34-12");
            MovQ(new Addr32(Reg32.EDX), Mm._0)
                .Test("movq [edx], mm0", "0F-7F-02");
            MovQ(new Addr32(Reg32.EAX, 0x1000), Mm._4)
                .Test("movq [eax+0x1000], mm4", "0F-7F-A0-00-10-00-00");
            MovQ(new Addr32(Reg32.EBP, -4), Mm._5)
                .Test("movq [ebp-4], mm5", "0F-7F-6D-FC");
            MovQ(new Addr32(0x12345678), Mm._7)
                .Test("movq [0x12345678], mm7", "0F-7F-3D-78-56-34-12");

            PAddB(Mm._1, Mm._0)
                .Test("paddb mm1, mm0", "0F-FC-C8");
            PAddB(Mm._3, Mm._6)
                .Test("paddb mm3, mm6", "0F-FC-DE");
            PAddB(Mm._0, new Addr32(Reg32.EDX))
                .Test("paddb mm0, [edx]", "0F-FC-02");
            PAddB(Mm._4, new Addr32(Reg32.EAX, 0x1000))
                .Test("paddb mm4, [eax+0x1000]", "0F-FC-A0-00-10-00-00");
            PAddB(Mm._5, new Addr32(Reg32.EBP, -4))
                .Test("paddb mm5, [ebp-4]", "0F-FC-6D-FC");
            PAddB(Mm._7, new Addr32(0x12345678))
                .Test("paddb mm7, [0x12345678]", "0F-FC-3D-78-56-34-12");

            PAddW(Mm._1, Mm._0)
                .Test("paddw mm1, mm0", "0F-FD-C8");
            PAddD(Mm._1, Mm._0)
                .Test("paddd mm1, mm0", "0F-FE-C8");
            PAddQ(Mm._1, Mm._0)
                .Test("paddq mm1, mm0", "0F-D4-C8");

            PSubB(Mm._1, Mm._0)
                .Test("psubb mm1, mm0", "0F-F8-C8");
            PSubW(Mm._1, Mm._0)
                .Test("psubw mm1, mm0", "0F-F9-C8");
            PSubD(Mm._1, Mm._0)
                .Test("psubd mm1, mm0", "0F-FA-C8");
            PSubQ(Mm._1, Mm._0)
                .Test("psubq mm1, mm0", "0F-FB-C8");

            PMulHW(Mm._1, Mm._0)
                .Test("pmulhw mm1, mm0", "0F-E5-C8");
            PMulLW(Mm._1, Mm._0)
                .Test("pmullw mm1, mm0", "0F-D5-C8");

            PSLLW(Mm._1, Mm._0)
                .Test("psllw mm1, mm0", "0F-F1-C8");
            PSLLW(Mm._1, 1)
                .Test("psllw mm1, 1", "0F-71-F1-01");
            PSLLD(Mm._1, Mm._0)
                .Test("pslld mm1, mm0", "0F-F2-C8");
            PSLLD(Mm._1, 1)
                .Test("pslld mm1, 1", "0F-72-F1-01");
            PSLLQ(Mm._1, Mm._0)
                .Test("psllq mm1, mm0", "0F-F3-C8");
            PSLLQ(Mm._1, 1)
                .Test("psllq mm1, 1", "0F-73-F1-01");

            PSRLW(Mm._1, Mm._0)
                .Test("psrlw mm1, mm0", "0F-D1-C8");
            PSRLW(Mm._1, 1)
                .Test("psrlw mm1, 1", "0F-71-D1-01");
            PSRLD(Mm._1, Mm._0)
                .Test("psrld mm1, mm0", "0F-D2-C8");
            PSRLD(Mm._1, 1)
                .Test("psrld mm1, 1", "0F-72-D1-01");
            PSRLQ(Mm._1, Mm._0)
                .Test("psrlq mm1, mm0", "0F-D3-C8");
            PSRLQ(Mm._1, 1)
                .Test("psrlq mm1, 1", "0F-73-D1-01");

            PSRAW(Mm._1, Mm._0)
                .Test("psraw mm1, mm0", "0F-E1-C8");
            PSRAW(Mm._1, 1)
                .Test("psraw mm1, 1", "0F-71-E1-01");
            PSRAD(Mm._1, Mm._0)
                .Test("psrad mm1, mm0", "0F-E2-C8");
            PSRAD(Mm._1, 1)
                .Test("psrad mm1, 1", "0F-72-E1-01");

            PUnpckHBW(Mm._1, Mm._0)
                .Test("punpckhbw mm1, mm0", "0F-68-C8");
            PUnpckHWD(Mm._1, Mm._0)
                .Test("punpckhwd mm1, mm0", "0F-69-C8");
            PUnpckHDQ(Mm._1, Mm._0)
                .Test("punpckhdq mm1, mm0", "0F-6A-C8");

            PUnpckLBW(Mm._1, Mm._0)
                .Test("punpcklbw mm1, mm0", "0F-60-C8");
            PUnpckLWD(Mm._1, Mm._0)
                .Test("punpcklwd mm1, mm0", "0F-61-C8");
            PUnpckLDQ(Mm._1, Mm._0)
                .Test("punpckldq mm1, mm0", "0F-62-C8");

            PackSSWB(Mm._1, Mm._0)
                .Test("packsswb mm1, mm0", "0F-63-C8");
            PackSSDW(Mm._1, Mm._0)
                .Test("packssdw mm1, mm0", "0F-6B-C8");
            PackUSWB(Mm._1, Mm._0)
                .Test("packuswb mm1, mm0", "0F-67-C8");
        }
    }
}
