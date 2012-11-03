using System;
using System.Collections.Generic;
using System.Text;
using CoffLib.Binary;

namespace CoffLib.X86
{
    public partial class I386
    {
        public static void TestMovx_8()
        {
            // Movzx

            MovzxB(Reg32.EAX, Reg8.BL)
                .Test("movzx eax, bl", "0F-B6-C3");
            MovzxB(Reg32.EAX, new Addr32(Reg32.EDX))
                .Test("movzx eax, byte [edx]", "0F-B6-02");
            MovzxB(Reg32.EBX, new Addr32(Reg32.EAX))
                .Test("movzx ebx, byte [eax]", "0F-B6-18");
            MovzxB(Reg32.ECX, new Addr32(Reg32.ESP))
                .Test("movzx ecx, byte [esp]", "0F-B6-0C-24");
            MovzxB(Reg32.EBP, new Addr32(Reg32.EAX, 0x1000))
                .Test("movzx ebp, byte [eax+0x1000]", "0F-B6-A8-00-10-00-00");
            MovzxB(Reg32.EAX, new Addr32(0x12345678))
                .Test("movzx eax, byte [0x12345678]", "0F-B6-05-78-56-34-12");

            MovzxB(Reg16.AX, Reg8.BL)
                .Test("movzx ax, bl", "66-0F-B6-C3");
            MovzxB(Reg16.AX, new Addr32(Reg32.EDX))
                .Test("movzx ax, byte [edx]", "66-0F-B6-02");
            MovzxB(Reg16.BX, new Addr32(Reg32.EAX))
                .Test("movzx bx, byte [eax]", "66-0F-B6-18");
            MovzxB(Reg16.CX, new Addr32(Reg32.ESP))
                .Test("movzx cx, byte [esp]", "66-0F-B6-0C-24");
            MovzxB(Reg16.BP, new Addr32(Reg32.EAX, 0x1000))
                .Test("movzx bp, byte [eax+0x1000]", "66-0F-B6-A8-00-10-00-00");
            MovzxB(Reg16.AX, new Addr32(0x12345678))
                .Test("movzx ax, byte [0x12345678]", "66-0F-B6-05-78-56-34-12");

            // Movsx

            MovsxB(Reg32.EAX, Reg8.BL)
                .Test("movsx eax, bl", "0F-BE-C3");
            MovsxB(Reg32.EAX, new Addr32(Reg32.EDX))
                .Test("movsx eax, byte [edx]", "0F-BE-02");
            MovsxB(Reg32.EBX, new Addr32(Reg32.EAX))
                .Test("movsx ebx, byte [eax]", "0F-BE-18");
            MovsxB(Reg32.ECX, new Addr32(Reg32.ESP))
                .Test("movsx ecx, byte [esp]", "0F-BE-0C-24");
            MovsxB(Reg32.EBP, new Addr32(Reg32.EAX, 0x1000))
                .Test("movsx ebp, byte [eax+0x1000]", "0F-BE-A8-00-10-00-00");
            MovsxB(Reg32.EAX, new Addr32(0x12345678))
                .Test("movsx eax, byte [0x12345678]", "0F-BE-05-78-56-34-12");

            MovsxB(Reg16.AX, Reg8.BL)
                .Test("movsx ax, bl", "66-0F-BE-C3");
            MovsxB(Reg16.AX, new Addr32(Reg32.EDX))
                .Test("movsx ax, byte [edx]", "66-0F-BE-02");
            MovsxB(Reg16.BX, new Addr32(Reg32.EAX))
                .Test("movsx bx, byte [eax]", "66-0F-BE-18");
            MovsxB(Reg16.CX, new Addr32(Reg32.ESP))
                .Test("movsx cx, byte [esp]", "66-0F-BE-0C-24");
            MovsxB(Reg16.BP, new Addr32(Reg32.EAX, 0x1000))
                .Test("movsx bp, byte [eax+0x1000]", "66-0F-BE-A8-00-10-00-00");
            MovsxB(Reg16.AX, new Addr32(0x12345678))
                .Test("movsx ax, byte [0x12345678]", "66-0F-BE-05-78-56-34-12");
        }
    }
}
