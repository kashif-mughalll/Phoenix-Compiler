using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace phoenix_compiler
{
    class Automata
    {
        int IS;
        string[] Input_Type_RE;
        int[] FS;
        int[][] Transition_Table;
        int Current_State;


        Automata(int IS, string[] Input_Type_RE , int[] FS , int[][] Transition_Table)
        {
            this.IS = IS;
            this.FS = FS;
            this.Input_Type_RE = Input_Type_RE;
            this.Transition_Table = Transition_Table;
        }

        public bool Verify_Pattern(string pattern)
        {
            this.Current_State = this.IS;
            for (int i = 0; i < pattern.Length; i++)
                Transition(this.Current_State, pattern[i]);

            return IsFinalState(this.Current_State);
        }

        void Transition(int Current_State, char c)
        {
            this.Current_State = this.Transition_Table[Current_State][ColumeNumber(c)];
        }

        int ColumeNumber(char c)
        {
            for (int i = 0; i < this.Input_Type_RE.Length; i++)
            {
                if (Valid(this.Input_Type_RE[i], c.ToString())) return i;
            }
            return -1;
        }

        bool IsFinalState(int state)
        {
            for (int i = 0; i < this.FS.Length; i++)
                if (this.FS[i] == state) return true;

            return false;
        }


        bool Valid(string RE, string pattern)
        {
            return new Regex(RE).IsMatch(pattern);
        }
    }
}
