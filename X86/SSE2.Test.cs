using System;
using System.Collections.Generic;
using System.Text;
using CoffLib.Binary;

namespace CoffLib.X86
{
    public partial class SSE2
    {
        public static void Test()
        {
            MovD(Xmm._1, Reg32.EAX)
                .Test("movd xmm1, eax", "66-0F-6E-C8");
            MovD(Xmm._3, Reg32.ESP)
                .Test("movd xmm3, esp", "66-0F-6E-DC");
            MovD(Xmm._0, new Addr32(Reg32.EDX))
                .Test("movd xmm0, [edx]", "66-0F-6E-02");
            MovD(Xmm._4, new Addr32(Reg32.EAX, 0x1000))
                .Test("movd xmm4, [eax+0x1000]", "66-0F-6E-A0-00-10-00-00");
            MovD(Xmm._5, new Addr32(Reg32.EBP, -4))
                .Test("movd xmm5, [ebp-4]", "66-0F-6E-6D-FC");
            MovD(Xmm._7, new Addr32(0x12345678))
                .Test("movd xmm7, [0x12345678]", "66-0F-6E-3D-78-56-34-12");
            MovD(Reg32.EAX, Xmm._1)
                .Test("movd eax, xmm1", "66-0F-7E-C8");
            MovD(Reg32.ESP, Xmm._3)
                .Test("movd esp, xmm3", "66-0F-7E-DC");
            MovD(new Addr32(Reg32.EDX), Xmm._0)
                .Test("movd [edx], xmm0", "66-0F-7E-02");
            MovD(new Addr32(Reg32.EAX, 0x1000), Xmm._4)
                .Test("movd [eax+0x1000], xmm4", "66-0F-7E-A0-00-10-00-00");
            MovD(new Addr32(Reg32.EBP, -4), Xmm._5)
                .Test("movd [ebp-4], xmm5", "66-0F-7E-6D-FC");
            MovD(new Addr32(0x12345678), Xmm._7)
                .Test("movd [0x12345678], xmm7", "66-0F-7E-3D-78-56-34-12");

            MovQ(Xmm._1, Xmm._0)
                .Test("movq xmm1, xmm0", "F3-0F-7E-C8");
            MovQ(Xmm._3, Xmm._6)
                .Test("movq xmm3, xmm6", "F3-0F-7E-DE");
            MovQ(Xmm._0, new Addr32(Reg32.EDX))
                .Test("movq xmm0, [edx]", "F3-0F-7E-02");
            MovQ(Xmm._4, new Addr32(Reg32.EAX, 0x1000))
                .Test("movq xmm4, [eax+0x1000]", "F3-0F-7E-A0-00-10-00-00");
            MovQ(Xmm._5, new Addr32(Reg32.EBP, -4))
                .Test("movq xmm5, [ebp-4]", "F3-0F-7E-6D-FC");
            MovQ(Xmm._7, new Addr32(0x12345678))
                .Test("movq xmm7, [0x12345678]", "F3-0F-7E-3D-78-56-34-12");
            MovQ(new Addr32(Reg32.EDX), Xmm._0)
                .Test("movq [edx], xmm0", "66-0F-D6-02");
            MovQ(new Addr32(Reg32.EAX, 0x1000), Xmm._4)
                .Test("movq [eax+0x1000], xmm4", "66-0F-D6-A0-00-10-00-00");
            MovQ(new Addr32(Reg32.EBP, -4), Xmm._5)
                .Test("movq [ebp-4], xmm5", "66-0F-D6-6D-FC");
            MovQ(new Addr32(0x12345678), Xmm._7)
                .Test("movq [0x12345678], xmm7", "66-0F-D6-3D-78-56-34-12");

            MovDQA(Xmm._1, Xmm._0)
                .Test("movdqa xmm1, xmm0", "66-0F-6F-C8");
            MovDQA(Xmm._3, Xmm._6)
                .Test("movdqa xmm3, xmm6", "66-0F-6F-DE");
            MovDQA(Xmm._0, new Addr32(Reg32.EDX))
                .Test("movdqa xmm0, [edx]", "66-0F-6F-02");
            MovDQA(Xmm._4, new Addr32(Reg32.EAX, 0x1000))
                .Test("movdqa xmm4, [eax+0x1000]", "66-0F-6F-A0-00-10-00-00");
            MovDQA(Xmm._5, new Addr32(Reg32.EBP, -4))
                .Test("movdqa xmm5, [ebp-4]", "66-0F-6F-6D-FC");
            MovDQA(Xmm._7, new Addr32(0x12345678))
                .Test("movdqa xmm7, [0x12345678]", "66-0F-6F-3D-78-56-34-12");
            MovDQA(new Addr32(Reg32.EDX), Xmm._0)
                .Test("movdqa [edx], xmm0", "66-0F-7F-02");
            MovDQA(new Addr32(Reg32.EAX, 0x1000), Xmm._4)
                .Test("movdqa [eax+0x1000], xmm4", "66-0F-7F-A0-00-10-00-00");
            MovDQA(new Addr32(Reg32.EBP, -4), Xmm._5)
                .Test("movdqa [ebp-4], xmm5", "66-0F-7F-6D-FC");
            MovDQA(new Addr32(0x12345678), Xmm._7)
                .Test("movdqa [0x12345678], xmm7", "66-0F-7F-3D-78-56-34-12");

            MovDQU(Xmm._1, Xmm._0)
                .Test("movdqu xmm1, xmm0", "F3-0F-6F-C8");
            MovDQU(Xmm._3, Xmm._6)
                .Test("movdqu xmm3, xmm6", "F3-0F-6F-DE");
            MovDQU(Xmm._0, new Addr32(Reg32.EDX))
                .Test("movdqu xmm0, [edx]", "F3-0F-6F-02");
            MovDQU(Xmm._4, new Addr32(Reg32.EAX, 0x1000))
                .Test("movdqu xmm4, [eax+0x1000]", "F3-0F-6F-A0-00-10-00-00");
            MovDQU(Xmm._5, new Addr32(Reg32.EBP, -4))
                .Test("movdqu xmm5, [ebp-4]", "F3-0F-6F-6D-FC");
            MovDQU(Xmm._7, new Addr32(0x12345678))
                .Test("movdqu xmm7, [0x12345678]", "F3-0F-6F-3D-78-56-34-12");
            MovDQU(new Addr32(Reg32.EDX), Xmm._0)
                .Test("movdqu [edx], xmm0", "F3-0F-7F-02");
            MovDQU(new Addr32(Reg32.EAX, 0x1000), Xmm._4)
                .Test("movdqu [eax+0x1000], xmm4", "F3-0F-7F-A0-00-10-00-00");
            MovDQU(new Addr32(Reg32.EBP, -4), Xmm._5)
                .Test("movdqu [ebp-4], xmm5", "F3-0F-7F-6D-FC");
            MovDQU(new Addr32(0x12345678), Xmm._7)
                .Test("movdqu [0x12345678], xmm7", "F3-0F-7F-3D-78-56-34-12");

            PAddB(Xmm._1, Xmm._0)
                .Test("paddb xmm1, xmm0", "66-0F-FC-C8");
            PAddB(Xmm._3, Xmm._6)
                .Test("paddb xmm3, xmm6", "66-0F-FC-DE");
            PAddB(Xmm._0, new Addr32(Reg32.EDX))
                .Test("paddb xmm0, [edx]", "66-0F-FC-02");
            PAddB(Xmm._4, new Addr32(Reg32.EAX, 0x1000))
                .Test("paddb xmm4, [eax+0x1000]", "66-0F-FC-A0-00-10-00-00");
            PAddB(Xmm._5, new Addr32(Reg32.EBP, -4))
                .Test("paddb xmm5, [ebp-4]", "66-0F-FC-6D-FC");
            PAddB(Xmm._7, new Addr32(0x12345678))
                .Test("paddb xmm7, [0x12345678]", "66-0F-FC-3D-78-56-34-12");

            PAddW(Xmm._1, Xmm._0)
                .Test("paddw xmm1, xmm0", "66-0F-FD-C8");
            PAddD(Xmm._1, Xmm._0)
                .Test("paddd xmm1, xmm0", "66-0F-FE-C8");
            PAddQ(Xmm._1, Xmm._0)
                .Test("paddq xmm1, xmm0", "66-0F-D4-C8");

            PSubB(Xmm._1, Xmm._0)
                .Test("psubb xmm1, xmm0", "66-0F-F8-C8");
            PSubW(Xmm._1, Xmm._0)
                .Test("psubw xmm1, xmm0", "66-0F-F9-C8");
            PSubD(Xmm._1, Xmm._0)
                .Test("psubd xmm1, xmm0", "66-0F-FA-C8");
            PSubQ(Xmm._1, Xmm._0)
                .Test("psubq xmm1, xmm0", "66-0F-FB-C8");

            PMulHW(Xmm._1, Xmm._0)
                .Test("pmulhw xmm1, xmm0", "66-0F-E5-C8");
            PMulLW(Xmm._1, Xmm._0)
                .Test("pmullw xmm1, xmm0", "66-0F-D5-C8");

            PSLLW(Xmm._1, Xmm._0)
                .Test("psllw xmm1, xmm0", "66-0F-F1-C8");
            PSLLW(Xmm._1, 1)
                .Test("psllw xmm1, 1", "66-0F-71-F1-01");
            PSLLD(Xmm._1, Xmm._0)
                .Test("pslld xmm1, xmm0", "66-0F-F2-C8");
            PSLLD(Xmm._1, 1)
                .Test("pslld xmm1, 1", "66-0F-72-F1-01");
            PSLLQ(Xmm._1, Xmm._0)
                .Test("psllq xmm1, xmm0", "66-0F-F3-C8");
            PSLLQ(Xmm._1, 1)
                .Test("psllq xmm1, 1", "66-0F-73-F1-01");

            PSRLW(Xmm._1, Xmm._0)
                .Test("psrlw xmm1, xmm0", "66-0F-D1-C8");
            PSRLW(Xmm._1, 1)
                .Test("psrlw xmm1, 1", "66-0F-71-D1-01");
            PSRLD(Xmm._1, Xmm._0)
                .Test("psrld xmm1, xmm0", "66-0F-D2-C8");
            PSRLD(Xmm._1, 1)
                .Test("psrld xmm1, 1", "66-0F-72-D1-01");
            PSRLQ(Xmm._1, Xmm._0)
                .Test("psrlq xmm1, xmm0", "66-0F-D3-C8");
            PSRLQ(Xmm._1, 1)
                .Test("psrlq xmm1, 1", "66-0F-73-D1-01");

            PSRAW(Xmm._1, Xmm._0)
                .Test("psraw xmm1, xmm0", "66-0F-E1-C8");
            PSRAW(Xmm._1, 1)
                .Test("psraw xmm1, 1", "66-0F-71-E1-01");
            PSRAD(Xmm._1, Xmm._0)
                .Test("psrad xmm1, xmm0", "66-0F-E2-C8");
            PSRAD(Xmm._1, 1)
                .Test("psrad xmm1, 1", "66-0F-72-E1-01");

            PUnpckHBW(Xmm._1, Xmm._0)
                .Test("punpckhbw xmm1, xmm0", "66-0F-68-C8");
            PUnpckHWD(Xmm._1, Xmm._0)
                .Test("punpckhwd xmm1, xmm0", "66-0F-69-C8");
            PUnpckHDQ(Xmm._1, Xmm._0)
                .Test("punpckhdq xmm1, xmm0", "66-0F-6A-C8");

            PUnpckLBW(Xmm._1, Xmm._0)
                .Test("punpcklbw xmm1, xmm0", "66-0F-60-C8");
            PUnpckLWD(Xmm._1, Xmm._0)
                .Test("punpcklwd xmm1, xmm0", "66-0F-61-C8");
            PUnpckLDQ(Xmm._1, Xmm._0)
                .Test("punpckldq xmm1, xmm0", "66-0F-62-C8");

            PackSSWB(Xmm._1, Xmm._0)
                .Test("packsswb xmm1, xmm0", "66-0F-63-C8");
            PackSSDW(Xmm._1, Xmm._0)
                .Test("packssdw xmm1, xmm0", "66-0F-6B-C8");
            PackUSWB(Xmm._1, Xmm._0)
                .Test("packuswb xmm1, xmm0", "66-0F-67-C8");
        }
    }
}
