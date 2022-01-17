using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace phoenix_compiler.Semantic
{
    static class MainTable
    {
        private static List<MainTableEntry> Entries = new List<MainTableEntry>();


        public static void Flush()
        {
            Entries = new List<MainTableEntry>();
        }

        public static void AddEntry(MainTableEntry entry)
        {
            if (!entry.Name.Equals(""))
                Entries.Add(entry);
        }

        public static bool CheckEntryExistsByName(string Name)
        {
            foreach (MainTableEntry entry in Entries) if (entry.Name.Equals(Name)) return true;
            return false;
        }

        public static bool CheckEntryIsAbstract(string Name)
        {
            foreach (MainTableEntry entry in Entries) if (entry.Name.Equals(Name)) return entry.Abstract;
            throw new EntryDoesNotExist_InMainTable();
        }

        public static string GetEntryTypeByName(string Name)
        {
            foreach (MainTableEntry entry in Entries) if (entry.Name.Equals(Name)) return entry.Type;
            throw new EntryDoesNotExist_InMainTable();
        }
    }
}
