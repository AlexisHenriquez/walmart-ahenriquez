using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;

namespace walmart_ahenriquez.Domain
{
    public class SearchTerm
    {
        private string _value;

        public SearchTerm(string value)
        {
            _value = value;
        }

        public string GetValue()
        {
            return _value;
        }

        public bool IsPalindrome()
        {
            return GetValue().SequenceEqual(GetValue().Reverse());
        }
    }
}
