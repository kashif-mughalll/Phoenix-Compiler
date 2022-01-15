using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace phoenix_compiler
{
    static class SelectionSets
    {
        private static string ID = "Identifier";

        static private List<string> _Selection_Set = new List<string>
        { };

        static List<string> MST_Selection_Set = new List<string>
        { "repeat", "do", "whether", "rtn", "export", "break",
            "continue", "this", "super"};

        static List<string> Ter9_Selection_Set = new List<string>
        { "[", ".", "(", "="};

        static List<string> Par_Selection_Set = new List<string>
        { "!", "(", "new", "this", "super","&&","||"};


        static List<string> Exp_Selection_Set = new List<string>
        { "!", "(", "new", "this", "super"};


        static List<string> Imp_ST_Selection_Set = new List<string>
        { "import" };

        static private List<string> IDS1_Selection_Set = new List<string>
        { "*" };


        static private List<string> Dec_Selection_Set = new List<string>
        { ";",",","=" };




























        


        public static bool Check_Dec_Selection_Set(Token T)
        {
            return Dec_Selection_Set.Contains(T.Value);
        }

        public static bool Check_IDS1_Selection_Set(Token T)
        {
            return (IDS1_Selection_Set.Contains(T.Value) || T.ClassName.Equals(ID));
        }


        public static bool Check_Ter9_Selection_Set(string s)
        {
            return Ter9_Selection_Set.Contains(s);
        }

        public static bool Check_Par_Selection_Set(string s)
        {
            if (Identifier.IsIdentifier(s) || Operators.IsIncDecOperator(s) || Constants.IsConstant(s) || Par_Selection_Set.Contains(s) || Operators.IsOperator(s))
                return true;
            
            return false;
        }

        public static bool Check_F_Selection_Set(string s)
        {
            if (Identifier.IsIdentifier(s) || Operators.IsIncDecOperator(s) || Constants.IsConstant(s) || Par_Selection_Set.Contains(s))
                return true;

            return false;
        }

        public static bool Check_Imp_St_Selection_Set(string s)
        {
            if (Imp_ST_Selection_Set.Contains(s))
                return true;

            return false;
        }

        public static bool Check_Input_Par_SelectionSet(string s)
        {
            if (Identifier.IsIdentifier(s)) return true;
            if (Keywords.IsKeyword(s)) if (Keywords.GetKeywordClassName(s).Equals("Keyword / DT")) return true;
            return false;
        }
               


        public static bool Check_MST_SelectionSet(Token T)
        {
            
            try
            {
                if (MST_Selection_Set.Contains(T.Value) || Operators.IsIncDecOperator(T.Value) || (T.ClassName.Equals("Identifier")))
                {
                    return true;
                }
                if (Keywords.IsKeyword(T.Value))
                {
                    if (Keywords.GetKeywordClassName(T.Value).Equals("Keyword / DT"))
                        return true;
                }
                    
                return false;
            }
            catch(Exception E)
            {
                Console.WriteLine(T.ToString());
                Console.WriteLine("BHUND YAHAN HAI" + E.Message);
                return false;
            }
        }

    }
}
