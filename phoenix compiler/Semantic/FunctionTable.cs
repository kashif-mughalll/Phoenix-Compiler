using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace phoenix_compiler.Semantic
{
    static class FunctionTable
    {
        public static List<FunctionTableEntry> Entries = new List<FunctionTableEntry>();

        public static void Flush()
        {
            Entries = new List<FunctionTableEntry>();
        }

        public static void AddEntry(FunctionTableEntry entry)
        {
            if(!entry.Name.Equals(""))
            Entries.Add(entry);
        }

        public static string generateTypeExp(List<string> para, string RT)
        {
            string result = "";
            for (int i = 0; i < para.Count; i++)
                if ((i + 1) < para.Count) result += para[i] + ',';
                else result += para[i];

            return result + ">" + RT;
        }

        public static void RemoveEntries(int Level)
        {
            List<FunctionTableEntry> list = new List<FunctionTableEntry>();
            foreach (FunctionTableEntry item in Entries)
                if (item.Level != Level) list.Add(item);
            Entries = list;
        }

        /*public static bool CheckEntryExistsByName(string Name)
        {
            foreach (FunctionTableEntry entry in Entries) if (entry.Name.Equals(Name)) return true;
            return false;
        }

        public static string GetEntryTypeByName(string Name)
        {
            foreach (FunctionTableEntry entry in Entries) if (entry.Name.Equals(Name)) return entry.Type;
            throw new EntryDoesNotExist_InMainTable();
        }

        public static string GetEntryAMByName(string Name)
        {
            foreach (FunctionTableEntry entry in Entries) if (entry.Name.Equals(Name)) return entry.AM;
            throw new EntryDoesNotExist_InMainTable();
        }*/
    }
}
