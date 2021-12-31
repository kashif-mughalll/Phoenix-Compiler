using System;
using System.Collections.Generic;
using System.IO;

namespace phoenix_compiler
{
    class KeywordType
    {
        private string ClassName;
        private List<string> Childrens;

        public KeywordType(string ClassName,List<string> Childrens)
        {
            this.ClassName = ClassName;
            this.Childrens = Childrens;
        }
        public string GetClassName() { return this.ClassName; }
        public bool IsAvailble(string keyword) { return this.Childrens.Contains(keyword); }

        public override string ToString()
        {
            string str = "";
            foreach (string key in Childrens) str += key + " ";
            return "{\n  " + "ClassName : " + ClassName + "\n  " + "Childrens : " + str + "\n}\n";
        }
    }

    static class Keywords
    {
        static private List<KeywordType> KeywordsGroups = new List<KeywordType>();
        static private string SourceData = @"
            DT:str,char,int,dbl,long,bool
            void:void
            datetime:dt
            if:whether
            else:or
            do:do
            while:repeat
            elseif:elif
            return:rtn
            class:class
            AM:personal,general
            ref:base,this
            new:new
            extends:@
            implements:apply
            interface:group
            final:closed
            abstract:abstract
            try:try
            catch:catch
            finally:finally
            throw:throw
        ";

        //boolconst: true,false

        static Keywords()
        {
            foreach (string Class in SourceData.Split('\n'))
            {
                string[] Tokens = Class.Trim().Split(':');
                if(Tokens.Length > 1)
                if(!String.IsNullOrEmpty(Tokens[0]) && !String.IsNullOrEmpty(Tokens[1]))
                {
                    string ClassName = Tokens[0].Trim();
                    List<string> Childrens = new List<string>();
                    foreach (string key in Tokens[1].Trim().Split(',')) Childrens.Add(key.Trim());
                    KeywordsGroups.Add(new KeywordType(ClassName, Childrens));
                }
            }

        }

        public static List<KeywordType> GetKeywordsGroups() { return KeywordsGroups; }

        public static bool IsKeyword(string keyword)
        {
            if (String.IsNullOrEmpty(keyword)) return false;
            foreach (KeywordType Ins in KeywordsGroups) if(Ins.IsAvailble(keyword)) return true;            
            return false;
        }

        public static string GetKeywordClassName(string keyword)
        {
            if (IsKeyword(keyword)) foreach (KeywordType Ins in KeywordsGroups)
                    if (Ins.IsAvailble(keyword))
                        return "Keyword / " + Ins.GetClassName();
            return null;
        }

    }
}
