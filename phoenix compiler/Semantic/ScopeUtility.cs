using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace phoenix_compiler.Semantic
{
    static class ScopeUtility
    {
        static public int GlobalScopeID = 10000001;

        public static void Flush()
        {
            // Implement required
        }

        public static List<FunctionTableEntry> getGlobalScopeEntries()
        {
            List<FunctionTableEntry> list = new List<FunctionTableEntry>();
            foreach (FunctionTableEntry entry in FunctionTable.Entries)
                if (entry.ScopeID == GlobalScopeID) list.Add(entry);

            list.Reverse();
            return list;
        }

        public static List<FunctionTableEntry> getScopeEntries(int ScopeID)
        {
            List<FunctionTableEntry> list = new List<FunctionTableEntry>();
            foreach (FunctionTableEntry entry in FunctionTable.Entries)
                if (entry.ScopeID == ScopeID) list.Add(entry);

            list.Reverse();
            return list;
        }

        public static FunctionTableEntry CheckEntityExist(string Name, int ScopeID = -1, int Level = -1, bool option = false) // option = true means check in both global as well as local
        {
            if (ScopeID != -1 && Level != -1) foreach (FunctionTableEntry entry in getScopeEntries(ScopeID))
                    if (entry.Name.Equals(Name) && entry.Level <= Level) return entry;

            if (ScopeID != -1 && Level == -1) foreach (FunctionTableEntry entry in getScopeEntries(ScopeID))
                    if (entry.Name.Equals(Name)) return entry;

            if (option) foreach (FunctionTableEntry entry in getGlobalScopeEntries())
                    if (entry.Name.Equals(Name)) return entry;

            return null;
        }

        public static int generateScopeID()
        {
            return Convert.ToInt32(new Random().Next(500000) - new Random().Next(200) + new Random().Next(50));
        }
    }
}
