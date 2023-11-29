using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDev
{
    [AttributeUsage(AttributeTargets.Property)]
    class DontSaveAttribute : Attribute { }

    [AttributeUsage(AttributeTargets.Property)]
    class CustomNameAttribute : Attribute
    {
        public string CustomFieldName { get; }
        public CustomNameAttribute(string customFieldName) => CustomFieldName = customFieldName;
    }

    internal class TestClass
    {
        [CustomName("CustomFieldName")]
        public int I { get; set; }
        [CustomName("CustomFieldName")]
        public string? S { get; set; }
        [CustomName("CustomFieldName")]
        public decimal? D { get; set; }
        public char[]? C { get; set; }

        public TestClass() { }
        
        public TestClass(int i) => I = i;

        public TestClass(int i, string s, decimal d, char[] c) : this(i) 
        {
            S = s;
            D = d;
            C = c;
        }
    }
}
