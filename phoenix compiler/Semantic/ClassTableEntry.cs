using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace phoenix_compiler.Semantic
{
    public class ClassTableEntry
    {
        public string Name; // indentifier 
        public string Type; // interface or class
        public bool Abstract; // true false
        public string AM; // Access modifier

        public ClassTableEntry(string Name, string Type, bool Abstract, string AM)
        {
            this.Name = Name;
            this.Type = Type;
            this.Abstract = Abstract;
            this.AM = AM;
        }

        public bool IsMethod()
        {
            return this.Type.Contains('>');
        }
    }
}
