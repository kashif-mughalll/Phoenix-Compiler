using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using phoenix_compiler;
using System.Drawing;
using System.Threading;

namespace Compiler_Pheonix
{
    static public class TextGen1
    {
        private static RichTextBox Box;
        private static bool AllowGeneration = false;
        private static bool WaitingStateAvailble = false;

        public static void Init(RichTextBox box)
        {
            Box = box;
        }

        static public void HandleChange()
        {
            //  CodeArea.SelectionStart.ToString() + " , " + CodeArea.GetLineFromCharIndex(CodeArea.SelectionStart);

            AllowGeneration = false;
            if (!WaitingStateAvailble)
            {
                WaitingStateAvailble = true;
                Task.Factory.StartNew(() =>
                {
                    Thread.Sleep(1000);
                    AllowGeneration = true;
                    WaitingStateAvailble = false;
                });
            }
        }

        static private void RegularCheck()
        {
            Task.Factory.StartNew(() => {
                while (true)
                {
                    if (AllowGeneration) Generate();
                    Thread.Sleep(500);
                }
            });
        }

        public static void Generate()
        {
            string SourceData = Box.Text;
            int cursorPos = Box.SelectionStart;
            Box.ReadOnly = true;
            Box.Text = "";
            string currentChar, word = "";
            int lineNum = 0;
            bool skip, strInProg = false, charInProg = false, skipWholeLine = false;
            string[] Lines = SourceData.Split('\n');

            foreach (var line in Lines)
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
                    else if (currentChar == "\"" && !charInProg)
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
                            word = createToken(word, lineNum);
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
                    if (currentChar == ".")
                    {
                        if (((i + 1) < line.Length))
                        {
                            if (int.TryParse(line[i + 1].ToString(), out a))
                            {
                                if (int.TryParse(word, out a))
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
                            word = createToken(word, lineNum);
                            createToken(currentChar, lineNum);
                        }
                        else word += currentChar;

                    SkipCodeBellow:;
                }
                if(Lines.Length > lineNum) createToken("\n", -1);
            }

            if (word != "") createToken(word, lineNum);
            Box.SelectionStart = cursorPos;
            Box.ReadOnly = false;
        }

        private static string createToken(string word, int lineNum)
        {
            if (word != "")
            {
                string classPart = CalculateClassName(word);
                if (classPart.Equals("[error]: Unknown type")) ;// throw new LexicalError(lineNum, word);
                //TokenSet.Add(new Token(word, classPart, lineNum));
                Utility.AppendText(Box, word, CalculateColor(classPart));
            }
            return "";
        }

        public static Color CalculateColor(string word)
        {
            if (word.Contains("Keyword"))
                return Color.Blue;
            else if (word.Contains("Operator"))
                return Color.DarkSeaGreen;
            else if (word.Contains("Punctuator"))
                return Color.Purple;
            else if (word.Contains("Constant"))
                return Color.Purple;
            else if (Identifier.IsIdentifier(word))
                return Color.DarkCyan;

            return Color.Black;
        }


        public static bool IsWordBreaker(string Char)
        {
            if ((Operators.IsOperator(Char)) || (Punctuators.IsPunctuator(Char)) ||
                    (Seperator.IsSeperator(Char)))
                return true;
            else return false;
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
            else if (word.Equals(" ") || word.Equals('\t') || word.Equals('\n') || word.Equals('\r'))
                return "";

            return "[error]: Unknown type";

        }
    }
}
