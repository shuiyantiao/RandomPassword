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

        private static readonly List<char> _chars = new List<char>() 
            { 
                '0',
                '1',
                '2',
                '3',
                '4',
                '5',
                '6',
                '7',
                '8',
                '9',
                'a',
                'b',
                'c',
                'd',
                'e',
                'f',
                'g',
                'h',
                'i',
                'j',
                'k',
                'l',
                'm',
                'n',
                'o',
                'p',
                'q',
                'r',
                's',
                't',
                'u',
                'v',
                'w',
                'x',
                'y',
                'z',
                'Z',
                'Y',
                'X',
                'W',
                'V',
                'U',
                'T',
                'S',
                'R',
                'Q',
                'P',
                'O',
                'N',
                'M',
                'L',
                'K',
                'J',
                'I',
                'H',
                'G',
                'F',
                'E',
                'D',
                'C',
                'B',
                'A',
                '.',
                '_',
            };

        public static char GetChar(int a)
        {
            if (a >= _chars.Count) return '0';
            return _chars[a];
        }
    }
}
