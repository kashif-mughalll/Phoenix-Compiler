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
    

}
