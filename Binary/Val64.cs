using System;
using System.Collections.Generic;
using System.Text;

namespace CoffLib.Binary
{
    public class Val64
    {
        private ulong value;
        public Val64 ref1, ref2;

        public ulong Value
        {
            get
            {
                if (ref1 == null) return value;
                return ref1.Value + ref2.Value;
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

        public Val64() { }
        public Val64(ulong v) { Value = v; }
        public Val64(ulong v, bool reloc) : this(v) { IsNeedForRelocation = reloc; }
        public Val64(Val64 a, Val64 b) { ref1 = a; ref2 = b; }

        public static implicit operator Val64(ulong v)
        {
            return new Val64(v);
        }
    }
}
