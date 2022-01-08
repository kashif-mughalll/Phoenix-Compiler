using phoenix_compiler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler_Pheonix
{
    public class LexicalError : Exception
    {
        public int line;
        public string token;

        public LexicalError(int line,string value)
        {
            this.line = line;
            this.token = value;
        }
    }

    public class SyntaxError : Exception
    {
        public int line;
        public string arg;
        public Token token;
        public string NonTerminalName;

        public SyntaxError(int line,Token token,string NonTerminalName, string arg = "Message unavailable")
        {
            this.line = line;
            this.arg = arg;
            this.token = token;
            this.NonTerminalName = NonTerminalName;
        }
    }
    

}
