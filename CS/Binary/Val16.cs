using System;
using System.Collections.Generic;
using System.Text;

namespace CoffLib.Binary
{
    public class Val16
    {
        private ushort value;
        public Val16 ref1, ref2;

        public ushort Value
        {
            get
            {
                if (ref1 == null) return value;
                return (ushort)(ref1.Value + ref2.Value);
            }

            set
            {
                this.value = value;
                isInitialized = true;
            }
        }

        private bool isInitialized = false;
        public bool IsInitialized { get { return isInitialized; } }

        public bool IsNeedForRelocation = false;

        public Val16() { }
        public Val16(ushort v) { Value = v; }
        public Val16(ushort v, bool reloc) : this(v) { IsNeedForRelocation = reloc; }
        public Val16(Val16 a, Val16 b) { ref1 = a; ref2 = b; }

        public static implicit operator Val16(ushort v)
        {
            return new Val16(v);
        }
    }
}
