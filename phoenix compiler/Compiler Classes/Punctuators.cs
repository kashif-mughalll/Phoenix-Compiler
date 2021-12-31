using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace phoenix_compiler
{
    static class Punctuators
    {
        static private List<string> punctuators = new List<string> { ",", ";", ":", ".", "{", "}", "[", "]", "(", ")" };

        public static bool IsPunctuator(string Punctuator) { return punctuators.Contains(Punctuator); }

        public static string GetPunctuatorClassName(string punctuator)
        {
            if (!IsPunctuator(punctuator)) return null;
            switch (punctuator)
            {
                case ",":
                    return "Punctuator / Comma";

                case ";":
                    return "Punctuator / Semicolon";

                case ":":
                    return "Punctuator / Colon";

                case ".":
                    return "Punctuator / Dot";

                case "{":
                    return "Punctuator / OCB";

                case "}":
                    return "Punctuator / CCB";

                case "(":
                    return "Punctuator / OB";

                case ")":
                    return "Punctuator / CB";

                case "[":
                    return "Punctuator / OSB";

                case "]":
                    return "Punctuator / CSB";

                default: return null; 
            }
        }
    }

    static class Seperator
    {
        static private List<string> Seperators = new List<string> { " ", "\n", "\r", "\t" };

        public static bool IsSeperator(string Seperator) { return Seperators.Contains(Seperator); }
    }
}
