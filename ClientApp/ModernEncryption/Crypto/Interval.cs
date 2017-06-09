using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using System.Text;

namespace ModernEncryption.Crypto
{
    public class Interval
    {
        public int Start { get; }
        public int End { get; }
        public Interval(int start, int end)
        {
            Start = start;
            End = end;
        }

      
    }
}
