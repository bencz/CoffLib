using System;
using System.Collections.Generic;
using System.Text;

namespace CoffLib.X86
{
    public enum CallType { CDecl, Std };

    public enum Reg32
    {
        EAX = 0, ECX, EDX, EBX, ESP, EBP, ESI, EDI
    }

    public enum Reg16
    {
        AX = 0, CX, DX, BX, SP, BP, SI, DI
    }

    public enum Reg8
    {
        AL = 0, CL, DL, BL, AH, CH, DH, BH
    }

    public enum SegReg
    {
        SS, CS, DS, ES
    }

    public enum Cc
    {
        O,
        NO,
        C, B = C, NAE = C,
        NC, AE = NC, NB = NC,
        Z, E = Z,
        NZ, NE = NZ,
        BE, NA = BE,
        NBE, A = NBE,
        S,
        NS,
        P, PE = P,
        NP, PO = NP,
        L, NGE = L,
        NL, GE = NL,
        LE, NG = LE,
        NLE, G = NLE
    }

    public enum Mm
    {
        _0, _1, _2, _3, _4, _5, _6, _7
    }

    public enum Xmm
    {
        _0, _1, _2, _3, _4, _5, _6, _7
    }
}
