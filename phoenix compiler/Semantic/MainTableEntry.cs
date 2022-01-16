using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace phoenix_compiler.Semantic
{
    public class MainTableEntry
    {
        public string Name; // indentifier 
        public string Type; // interface or class
        public bool Abstract; // true false
        public string Parent; // Parent
        public List<string> InterfaceList; // inherited interfaces
        public ClassTable classTable;
        public string AM;

        public MainTableEntry(string Name,string Type, bool Abstract, string AM,string Parent, List<string> InterfaceList)
        {
            this.Name = Name;
            this.Type = Type;
            this.Abstract = Abstract;
            this.Parent = Parent;
            this.InterfaceList = InterfaceList;
            classTable = new ClassTable();
            this.AM = AM;
        }

        public static List<string> GenerateInterfaceList(string Data)
        {
            List<string> list = new List<string>();
            string[] tokens = Data.Split(',');
            foreach (string ID in tokens) list.Add(ID);
            return list;
        }
    }
}
