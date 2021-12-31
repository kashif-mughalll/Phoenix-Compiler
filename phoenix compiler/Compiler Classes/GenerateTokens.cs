using Compiler_Pheonix;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace phoenix_compiler
{
    public class Token
    {
        public string Value;
        public string ClassName;
        public int LineNumber;

        public Token( string Value, string ClassName, int LineNumber)
        {
            this.Value = Value;
            this.ClassName = ClassName;
            this.LineNumber = LineNumber;
        }

        public string GenerateStr()
        {
            return "value = " + this.Value + "%class = " + this.ClassName + "%line  = " + this.LineNumber;
        }

        public override string ToString()
        {            
            return "{\n    value : " + this.Value + "\n    class : " + this.ClassName + "\n    line  : " + this.LineNumber + "\n}\n";
        }
    }



    static class GenerateTokens
    {
        private static List<Token> TokenSet;

        public static List<Token> Generate(string SourceData)
        {
            TokenSet = new List<Token>();
            if (String.IsNullOrEmpty(SourceData))
            {
                TokenSet.Add(new Token("$$$", "End marker", -1));
                return TokenSet;
            }
            string currentChar, word = "";
            int lineNum = 0;
            bool skip, strInProg = false, charInProg = false, skipWholeLine = false, FloatCheck = false;

            foreach (var line in SourceData.Split('\n'))
            {
                lineNum++;
                strInProg = false;
                charInProg = false;
                skipWholeLine = false;

                for (int i = 0; i < line.Length; i++)
                {
                    skip = false;
                    currentChar = line[i].ToString();
                    if (skipWholeLine) goto SkipCodeBellow;

                    if (strInProg)
                    {
                        if ((currentChar == "\"" && (line[i - 1] != '\\')) || !((i + 1) < line.Length))
                        {
                            word += currentChar;
                            word = createToken(word, lineNum);
                            strInProg = false;
                        }
                        else word += currentChar;
                        goto SkipCodeBellow;
                    }
                    else if(currentChar == "\"" && !charInProg)
                    {
                        word = createToken(word, lineNum);
                        word += "\"";
                        strInProg = true;
                        goto SkipCodeBellow;
                    }


                    if (charInProg)
                    {
                        if ((currentChar == "'" && (line[i - 1] != '\\')) || !((i + 1) < line.Length))
                        {
                            word += currentChar;
                            word = createToken(word, lineNum);
                            charInProg = false;
                        }
                        else word += currentChar;
                        goto SkipCodeBellow;
                    }
                    else if (currentChar == "'")
                    {
                        word = createToken(word, lineNum);
                        word += "'";
                        charInProg = true;
                        goto SkipCodeBellow;
                    }


                    if (((i + 1) < line.Length) && !strInProg)
                    {
                        string op = line[i].ToString() + line[i + 1].ToString();
                        if (Operators.IsMultiCharacterOP(op))
                        {                            
                            word = createToken(word,lineNum);
                            createToken(op, lineNum);
                            i++;
                            skip = true;
                        }
                        if (currentChar == "#" && line[i + 1].ToString() == "#")
                        {
                            word = createToken(word, lineNum);
                            skipWholeLine = true;
                            goto SkipCodeBellow;
                        }
                    }


                    // Block for Floating Number
                    int a = 5;
                    if(currentChar == ".")
                    {
                        if (((i + 1) < line.Length))
                        {
                            if(int.TryParse(line[i+1].ToString(), out a))
                            {
                                if(int.TryParse(word, out a))
                                {
                                    word += currentChar;
                                    goto SkipCodeBellow;
                                }
                                else
                                {
                                    word = createToken(word, lineNum);
                                    word += currentChar;
                                    goto SkipCodeBellow;
                                }
                            }
                        }
                    }

                    


                    // General Block
                    if (!skip && !strInProg)
                        if (IsWordBreaker(currentChar))
                        {
                            word = createToken(word,lineNum);
                            if (!Seperator.IsSeperator(currentChar)) createToken(currentChar, lineNum);
                        }
                        else word += currentChar;

                    SkipCodeBellow:;
                }
            }

            if (word != "") createToken(word, lineNum);

            TokenSet.Add(new Token("$$$", "End marker", -1));
            return TokenSet;
        }

        private static string createToken(string word,int lineNum)
        {
            if (word != "")
            {
                string classPart = CalculateClassName(word);
                if (classPart.Equals("[error]: Unknown type")) throw new LexicalError(lineNum,word);
                TokenSet.Add(new Token(word, classPart, lineNum));
            }
            return "";
        }
            

        public static bool IsWordBreaker(string Char) 
        {
            if ( (Operators.IsOperator(Char)) || (Punctuators.IsPunctuator(Char)) || 
                    (Seperator.IsSeperator(Char)))
                        return true; else return false;
        }

        public static string CalculateClassName(string word)
        {
            if (Keywords.IsKeyword(word))
                return Keywords.GetKeywordClassName(word);
            else if (Operators.IsOperator(word))
                return Operators.GetOperatorClassName(word);
            else if (Punctuators.IsPunctuator(word))
                return Punctuators.GetPunctuatorClassName(word);
            else if (Constants.IsConstant(word))
                return Constants.GetConstantClassName(word);
            else if (Identifier.IsIdentifier(word))
                return "Identifier";

            return "[error]: Unknown type";
            
        }
    }
}
