using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace phoenix_compiler.Semantic
{
    public class FunctionTableEntry
    {
        public string Name;
        public string AM;
        public string Type;
        public int Level;
        public int ScopeID; 

        public FunctionTableEntry(string Name, string AM, string Type, int ScopeID, int Level)
        {
            this.Name = Name;
            this.AM = AM;
            this.Type = Type;
            this.ScopeID = ScopeID;
            this.Level = Level;
        }
    }
}
