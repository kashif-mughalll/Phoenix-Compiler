using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace phoenix_compiler
{
    static class Constants
    {
        static public bool IsConstant(string word)
        {
            return (StringConstants.IsStringConstants(word) || CharConstant.IsCharConstant(word)
                || DoubleConstant.IsDoubleConstant(word) || IntConstant.IsIntConstants(word) || BooleanConstant.IsBooleanConstant(word));
        }

        static public string GetConstantClassName(string word)
        {
            if (StringConstants.IsStringConstants(word)) return "Constant / String";
            else if (CharConstant.IsCharConstant(word)) return "Constant / Character";
            else if (IntConstant.IsIntConstants(word)) return "Constant / Integer";
            else if (DoubleConstant.IsDoubleConstant(word)) return "Constant / Double";
            else if (BooleanConstant.IsBooleanConstant(word)) return "Constant / Bool";
            else return null;
        }
    }

    static class StringConstants
    {
        //public readonly static string RE = "";
        //static public bool IsStringConstants(string word) { return new Regex(RE).IsMatch(word); }

        static public bool IsStringConstants(string word)
        {
            word = word.Trim();
            if (word.Length >= 2)
                if (word[0] == '"' && word[word.Length - 1] == '"' && word[word.Length - 2] != '\\')
                    return true;
            return false;
        }
    }

    static class BooleanConstant
    {
        static public bool IsBooleanConstant(string word)
        {
            return (word.Equals("true") || word.Equals("false"));
        }
    }

    static class CharConstant
    {
        static public bool IsCharConstant(string word)
        {
            word = word.Trim();
            if (word.Length == 3) if (word[0] == '\'' && word[2] == '\'' && word[1] != '\'' && word[1] != '\\') return true;
            if (word.Length == 4) if (word[0] == '\'' && word[3] == '\'' && word[1] == '\\') return true;
            return false;
        }
    }

    static class IntConstant
    {
        public readonly static string RE = "^[+-]?[0-9]+$";

        static public bool IsIntConstants(string word) { return new Regex(RE).IsMatch(word); }
    }

    static class DoubleConstant
    {
        public readonly static string RE = @"^([+-]?)([0-9]+|([0-9]*(\.)[0-9]+))$";

        static public bool IsDoubleConstant(string word) { return new Regex(RE).IsMatch(word); }        
    }
}
