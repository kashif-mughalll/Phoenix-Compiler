using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace phoenix_compiler.Semantic
{
    public class ClassTable
    {
        private List<ClassTableEntry> Entries;

        public ClassTable()
        {
            Entries = new List<ClassTableEntry>();
        }

        public void AddEntry(ClassTableEntry entry)
        {
            Entries.Add(entry);
        }

        public bool CheckEntryExistsByName(string Name)
        {
            foreach (ClassTableEntry entry in Entries) if (entry.Name.Equals(Name)) return true;
            return false;
        }

        public bool CheckEntryIsAbstract(string Name)
        {
            foreach (ClassTableEntry entry in Entries) if (entry.Name.Equals(Name)) return entry.Abstract;
            throw new EntryDoesNotExist_InClassTable();
        }

        public string GetEntryType(string Name)
        {
            foreach (ClassTableEntry entry in Entries) if (entry.Name.Equals(Name)) return entry.Type;
            throw new EntryDoesNotExist_InClassTable();
        }
    }
}
