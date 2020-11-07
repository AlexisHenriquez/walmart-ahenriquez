using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;

namespace walmart_ahenriquez.Domain
{
    public class SearchTerm
    {
        public SearchTerm(string value)
        {
            Value = value;
        }

        public string Value { get; set; }

        public bool IsPalindrome
        {
            get { return Value.SequenceEqual(Value.Reverse()); }
        }
    }
}