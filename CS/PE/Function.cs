using System;
using System.Collections.Generic;
using System.Text;
using CoffLib.X86;

namespace CoffLib.PE
{
    public class Function
    {
        private Module module;

        private Addr32 address;
        public Addr32 Address { get { return address; } }

        private CallType callType = CallType.CDecl;
        public CallType CallType { get { return callType; } }

        public Function(Module mod, Addr32 addr)
        {
            module = mod;
            address = addr;
        }

        public Function(Module mod, Addr32 addr, CallType call)
        {
            module = mod;
            address = addr;
            callType = call;
        }

        public OpCode[] Invoke(params object[] args)
        {
            for (int i = 0; i < args.Length; i++)
            {
                if (args[i] is string) args[i] = module.GetString((string)args[i]);
            }
            return I386.Call(callType, address, args);
        }
    }
}
