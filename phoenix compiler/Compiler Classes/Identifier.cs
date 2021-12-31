using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace phoenix_compiler
{
    static class Identifier
    {
        public static string IdentifierRE = @"^[A-Za-z]+$|^([A-Za-z]|_)([A-Za-z]|[0-9])+$";

        public static bool IsIdentifier(string word) { return new Regex(IdentifierRE).IsMatch(word); }
    }
}
