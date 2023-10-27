using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AppDev
{
    //Реализуйте операторы неявного приведения из long,int,byt в Bits
    internal interface IBites
    {
        long Value { get; set; }
        void SetBit(bool bit, int index);
        bool GetBit(int index);
    }
    class Bites: IBites
    {
        private int size = 0;
        public long Value { get; set; } = 0;
        public Bites(short data) { Value = data; size = sizeof(short) * 8; }
        public Bites(byte data) { Value = data; size = sizeof(byte) * 8; }
        public Bites(int data) { Value = data; size = sizeof(int) * 8; }
        public Bites(long data) { Value = data; size = sizeof(long) * 8; }

        public static implicit operator byte(Bites b) { return (byte)b.Value; }
        public static explicit operator Bites(byte b) => new Bites(b);

        public static implicit operator int(Bites b) { return (int)b.Value; }
        public static explicit operator Bites(int b) => new Bites(b);

        public static implicit operator long(Bites b) { return (long)b.Value; }
        public static explicit operator Bites(long b) => new Bites(b);

        public void SetBit(bool bit, int index)
        {
            if (index < 0 || index > size)
                throw new ArgumentOutOfRangeException("Вне диапазона");
            if (bit)
                Value = (byte)(Value | (1 << index));
            else
            {
                var mask = (byte)(1 << index);
                mask = (byte)(0xff ^ mask);
                Value &= (byte)(Value & mask);
            }
        }
        public bool GetBit(int index)
        {
            if(index < 0 || index > size)
                throw new ArgumentOutOfRangeException("Вне диапазона");
            else
                return ((Value >> index) & 1) == 1;
        }
    }
}
