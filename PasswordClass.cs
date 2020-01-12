using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomPassword
{
    class PasswordClass
    {
        public string Password { get; set; }

        private static readonly List<char> _chars = new List<char>();

        static PasswordClass()
        {
            var chars = ".0123456789ZaYbXcWdVeUfTgShRiQjPkOlNmMnLoKpJqIrHsGtFuEvDwCxByAz_";
            _chars.AddRange(chars);
        }

        public static char GetChar(int a)
        {
            if (a >= _chars.Count) return '0';
            return _chars[a];
        }
    }
}
