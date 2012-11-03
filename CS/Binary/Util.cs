using System;
using System.Collections.Generic;
using System.Text;

namespace CoffLib.Binary
{
    public class Util
    {
        public static byte[] GetBytes(byte[] b, byte v)
        {
            int len = b.Length;
            byte[] ret = new byte[len + 1];
            Array.Copy(b, ret, len);
            ret[len] = v;
            return ret;
        }

        public static byte[] GetBytes(byte[] b, ushort v)
        {
            int len = b.Length;
            byte[] ret = new byte[len + sizeof(ushort)];
            Array.Copy(b, ret, len);
            SetBytes(ret, len, v);
            return ret;
        }

        public static byte[] GetBytes(byte[] b, uint v)
        {
            int len = b.Length;
            byte[] ret = new byte[len + sizeof(uint)];
            Array.Copy(b, ret, len);
            SetBytes(ret, len, v);
            return ret;
        }

        public static byte[] Concat(byte b1, byte[] b2)
        {
            byte[] ret = new byte[1 + b2.Length];
            ret[0] = b1;
            Array.Copy(b2, 0, ret, 1, b2.Length);
            return ret;
        }

        public static byte[] Concat(byte[] b1, byte[] b2)
        {
            byte[] ret = new byte[b1.Length + b2.Length];
            Array.Copy(b1, ret, b1.Length);
            Array.Copy(b2, 0, ret, b1.Length, b2.Length);
            return ret;
        }

        public static void SetBytes(byte[] b, int pos, ushort v)
        {
            b[pos] = (byte)v;
            b[pos + 1] = (byte)(v >> 8);
        }

        public static void SetBytes(byte[] b, int pos, uint v)
        {
            b[pos] = (byte)v;
            b[pos + 1] = (byte)(v >> 8);
            b[pos + 2] = (byte)(v >> 16);
            b[pos + 3] = (byte)(v >> 24);
        }
    }
}
