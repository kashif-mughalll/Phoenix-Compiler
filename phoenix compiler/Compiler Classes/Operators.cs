using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace phoenix_compiler
{
    static class Operators
    {
        private static string ArithmeticOpsClassName = "Operator / Arithmetic";
        private static string RelationalOpsClassName = "Operator / Relational";
        private static string AssignmentOpsClassName = "Operator / Assignment";
        private static string IncDecOpsClassName = "Operator / IncDec";
        private static string LogicalClassName = "Operator / Logical";

        private static List<string> ArithmeticOps = new List<string> { "+", "-", "/", "*", "%" };
        private static List<string> RelationalOps = new List<string> { "==", "!=", ">", "<", "<=", ">=" };
        private static List<string> AssignmentOps = new List<string> { "=" };
        private static List<string> IncDecOps = new List<string>     { "++", "--" };
        private static List<string> LogicalOPs = new List<string> { "||", "&&" };

        public static bool IsOperator(string _operator)
        {
            return (IsArithmeticOperator(_operator) || IsAssignmentOperator(_operator) || 
                    IsIncDecOperator(_operator) || IsRelationalOperator(_operator) || IsLogicalOps(_operator));
        }

        public static bool IsArithmeticOperator(string _operator) { return ArithmeticOps.Contains(_operator); }

        public static bool IsRelationalOperator(string _operator) {
            return RelationalOps.Contains(_operator);
        }

        public static bool IsLogicalOps(string _operator) { if (LogicalOPs.Contains(_operator)) return true; else return false; }

        public static bool IsPM(string _operator) { if (_operator == "+" || _operator == "-") return true; else return false; }

        public static bool IsMDM(string _operator) { if (_operator == "*" || _operator == "/" || _operator == "%") return true; else return false; }

        public static bool IsAssignmentOperator(string _operator) { return AssignmentOps.Contains(_operator); }

        public static bool IsIncDecOperator(string _operator) { return IncDecOps.Contains(_operator); }

        public static bool IsMultiCharacterOP(string _operator) { return (IsIncDecOperator(_operator) || IsRelationalOperator(_operator)); }

        public static string GetOperatorClassName(string _operator)
        {
            if (IsOperator(_operator))
            {
                if (IsArithmeticOperator(_operator)) return ArithmeticOpsClassName;
                else
                if (IsAssignmentOperator(_operator)) return AssignmentOpsClassName;
                else
                if (IsIncDecOperator(_operator)) return IncDecOpsClassName;
                else
                if (IsRelationalOperator(_operator)) return RelationalOpsClassName;
                else
                if (IsLogicalOps(_operator)) return LogicalClassName;
            }
            return null;
        }
    }
}
