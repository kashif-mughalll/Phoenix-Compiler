using Compiler_Pheonix;
using phoenix_compiler.Semantic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace phoenix_compiler.Compiler_Classes
{
    static class SemanticGrammer
    {
        // %%%%%%%%%%%%%%%%%%%%%%  Utils  %%%%%%%%%%%%%%%%%%%%%%%%%%%5

        static private List<string> IDsList = new List<string>();

        // $$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$


        private static CallLogger log;
        private static List<Token> tokenList;
        private static int i = 0;
        private static int currentScopeID;
        private static int currentLevel;
        private static bool isGlobalScope;
        private static bool InsideClassBody;
        private static ClassTable cTable;
        private static string currentClassName;


        public static bool Start(List<Token> _tokenList, CallLogger _log)
        {
            tokenList = _tokenList;
            i = 0;
            currentScopeID = 0;
            currentLevel = -1;
            log = _log;
            log.setDisableTracking(true);
            IDsList = new List<string>();
            isGlobalScope = true;
            InsideClassBody = false;
            cTable = null;
            FunctionTable.Flush();
            MainTable.Flush();
            return start();
        }

        private static bool start()
        {
            log.AddLog("start", getToken());

            if (endMarker()) return true;
            if (getToken().Value.Equals("import"))
            {
                if (Imp_St())
                    if (start()) return true;
            }
            else if (Start_Global()) return true;

            return ReturnFalse("start");
        }

        private static bool endMarker()
        {
            if (TokenIs("$$$")) return true;
            return false;
        }

        private static bool Start_Global()
        {
            log.AddLog("Start_Global", getToken());

            if (endMarker())
            {
                return true;
            }
            if (SST1())
            {
                if (Start_Global()) return true;
            }

            return ReturnFalse("Start_Global");
        }

        private static bool SST1()
        {
            log.AddLog("SST1", getToken());

            if (while_St())
            {
                return ReturnTrue();
            }
            else if (Do_While())
            {
                return ReturnTrue();
            }
            else if (If_Else())
            {
                return ReturnTrue();
            }
            else if (Ret_St())
            {
                return ReturnTrue();
            }
            else if (Export_St())
            {
                return ReturnTrue();
            }
            else if (getToken().Value.Equals("break"))
            {
                if (TokenIs("break"))
                    if (TokenIs(";"))
                        return ReturnTrue();
            }
            else if (getToken().Value.Equals("continue"))
            {
                if (TokenIs("continue"))
                    if (TokenIs(";"))
                        return ReturnTrue();
            }
            else if (Inc_Dec_St())
            {
                return ReturnTrue();
            }
            else if (Combine1())
            {
                return ReturnTrue();
            }

            return ReturnFalse("SST1");
        }

        private static bool Combine1()
        {
            log.AddLog("Combine1", getToken());

            if (TokenIs_ID())
            {
                if (Ter41())
                    return ReturnTrue();
            }
            else if (TokenIs_DT())
            {
                if (Ter51())
                {
                    return ReturnTrue();
                }
            }
            else if (TokenIs("empty"))
            {
                if (TokenIs_ID())
                {
                    if (Fn_Def()) return ReturnTrue();
                }
            }
            else if (TokenIs("general"))
            {
                if (Ter1("general"))
                {
                    return ReturnTrue();
                }
            }
            else if (TokenIs("personal"))
            {
                if (Ter1("personal"))
                {
                    return ReturnTrue();
                }
            }
            else if (Class_Def(null))
            {
                return ReturnTrue();
            }
            else if (Int_Def(null))
            {
                return ReturnTrue();
            }

            return ReturnFalse("Combine1");
        }


        private static bool Ter1(string AM)
        {
            log.AddLog("Ter1", getToken());

            if (Class_Def(AM))
            {
                return ReturnTrue();
            }
            else if (Int_Def(AM))
            {
                return ReturnTrue();
            }
            else if (G_Fn_Def())
            {
                return ReturnTrue();
            }

            return ReturnFalse("Ter1");
        }

        private static bool SST()
        {
            log.AddLog("SST", getToken());

            if (while_St())
            {
                return ReturnTrue();
            }
            else if (Do_While())
            {
                return ReturnTrue();
            }
            else if (If_Else())
            {
                return ReturnTrue();
            }
            else if (Ret_St())
            {
                return ReturnTrue();
            }
            else if (Export_St())
            {
                return ReturnTrue();
            }
            else if (TokenIs("break"))
            {
                if (TokenIs(";"))
                    return ReturnTrue();
            }
            else if (TokenIs("continue"))
            {
                if (TokenIs(";"))
                    return ReturnTrue();
            }
            else if (Inc_Dec_St())
            {
                return ReturnTrue();
            }
            else if (Combine())
            {
                return ReturnTrue();
            }

            return ReturnFalse("SST");
        }



        private static bool Combine()
        {
            log.AddLog("Combine", getToken());

            if (TokenIs_ID())
            {
                if (Ter41()) return ReturnTrue();
            }
            else if (TokenIs_DT())
            {
                if (Ter5())
                {
                    return ReturnTrue();
                }
            }
            /*else if (TokenIs("empty"))
            {
                if (TokenIs_ID())
                {
                    if (Fn_Def()) return ReturnTrue();
                }
            }
            else if (TokenIs("general"))
            {
                if (G_Fn_Def())
                {
                    return ReturnTrue();
                }
            }
            else if (TokenIs("personal"))
            {
                if (G_Fn_Def())
                {
                    return ReturnTrue();
                }
            }*/
            else if (TokenIs("this"))
            {
                if (TokenIs("."))
                {
                    if (TokenIs_ID())
                        if (Ter20())
                            if (Init())
                                if (TokenIs(";"))
                                    return ReturnTrue();
                }
            }
            else if (TokenIs("super"))
            {
                if (TokenIs("."))
                {
                    if (TokenIs_ID())
                    {
                        if (Ops1())
                        {
                            return ReturnTrue();
                        }
                    }
                }
            }

            return ReturnFalse("Combine");
        }


        private static bool Ter4()
        {
            log.AddLog("Ter4", getToken());

            if (TokenIs("["))
            {
                if (Ter2()) return ReturnTrue();
            }
            else if (TokenIs_ID())
            {
                if (Dec("" ,"" ,"")) return ReturnTrue();
            }
            else if (Ops1())
            {
                return ReturnTrue();
            }

            return ReturnFalse("Ter4");
        }

        private static bool Ter41()
        {
            log.AddLog("Ter41", getToken());

            if (TokenIs("["))
            {
                if (Ter211())
                    if (TokenIs(";"))
                        return ReturnTrue();
            }
            else if (TokenIs_ID())
            {
                if (Ter7("" ,"" ,"")) return ReturnTrue();
            }
            else if (Ops1())
            {
                if (Init())
                    if (TokenIs(";"))
                        return ReturnTrue();
            }

            return ReturnFalse("Ter41");
        }


        private static bool Ter2()
        {
            log.AddLog("Ter2", getToken());

            string coma = "";
            if (Comma(out coma))
            {
                if (TokenIs("]"))
                {
                    if (TokenIs_ID())
                    {
                        if (G_Array_Def()) return ReturnTrue();
                    }
                }
            }
            else if (Value())
            {
                if (TokenIs("]"))
                {
                    if (Ops1()) return ReturnTrue();
                }
            }

            return ReturnFalse("Ter2");
        }


        private static bool Ter5()
        {
            log.AddLog("Ter5", getToken());

            if (TokenIs_ID())
            {
                if (Dec("" ,"" ,"")) return ReturnTrue();
            }
            else if (TokenIs("["))
            {
                string coma = "";
                if (Comma(out coma))
                {
                    if (TokenIs("]"))
                    {
                        if (TokenIs_ID())
                        {
                            if (G_Array_Def()) return ReturnTrue();
                        }
                    }
                }
            }

            return ReturnFalse("Ter5");
        }


        private static bool Ter51()
        {
            log.AddLog("Ter51", getToken());

            if (TokenIs_ID())
            {
                if (Ter7("" ,"" ,"")) return ReturnTrue();
            }
            else if (TokenIs("["))
            {
                string coma = "";
                if (Comma(out coma))
                {
                    if (TokenIs("]"))
                    {
                        if (TokenIs_ID())
                        {
                            if (Ter8()) return ReturnTrue();
                        }
                    }
                }
            }

            return ReturnFalse("Ter51");
        }


        private static bool Ter7(string AM, string DT, string Name)
        {
            log.AddLog("Tr7", getToken());

            if (Dec(AM, DT, Name))
            {
                return ReturnTrue();
            }
            else if (Cntr(AM, DT, Name)) return ReturnTrue();    // fn_def changed to cntr()

            return ReturnFalse("Ter7");
        }


        private static bool Ter8()
        {
            log.AddLog("Ter8", getToken());

            if (Fn_Def()) return ReturnTrue();
            else if (G_Array_Def()) return ReturnTrue();

            return ReturnFalse("Ter8");
        }


        private static bool Abs(out bool abs)
        {
            abs = false;
            if (!getToken().Value.Equals("abstract")) return true;

            log.AddLog("Abs", getToken());

            if (TokenIs("abstract"))
            {
                abs = true;
                return ReturnTrue();
            }
            else return ReturnTrue();
        }


        private static bool CDT_ID()
        {
            log.AddLog("CDT_ID", getToken());

            if (TokenIs_ID())
            {
                if (Ter18()) return ReturnTrue();
            }
            else if (TokenIs_DT())
            {
                if (Ter18()) return ReturnTrue();
            }
            else if (TokenIs("empty")) return ReturnTrue();

            return ReturnFalse("CDT_ID");
        }


        private static bool Ter18()
        {
            log.AddLog("Ter18", getToken());

            if (TokenIs("["))
            {
                string coma = "";
                if (Comma(out coma))
                {
                    if (TokenIs("]")) return ReturnTrue();
                }
            }
            else return ReturnTrue();

            return ReturnFalse("Ter18");
        }


        private static bool Comma(out string coma)
        {
            coma = "";
            log.AddLog("Comma", getToken());

            if (TokenIs(","))
            {
                coma = ",";
                return ReturnTrue();
            }
            else return ReturnTrue();
        }


        private static bool DT_ID()
        {
            log.AddLog("DT_ID", getToken());

            if (TokenIs_ID()) return ReturnTrue();
            else if (TokenIs_DT()) return ReturnTrue();

            return ReturnFalse("DT_ID");
        }

        private static bool AM()
        {
            log.AddLog("AM", getToken());

            if (TokenIs("general"))
                return ReturnTrue();
            else if (TokenIs("personal"))
                return ReturnTrue();
            else return ReturnTrue();
        }

        


        private static bool IDS()
        {
            log.AddLog("IDS", getToken());

            if (MainTable.CheckEntryExistsByName(getToken().Value)) {
                if (MainTable.GetEntryTypeByName(getToken().Value).Equals("group")) {                    
                    if (!CheckList(IDsList, getToken().Value)) IDsList.Add(getToken().Value);
                    else throw new GeneralSemanticError("' "+getToken().Value + " '  is used mutiple time.");
                }
                else throw new InterfaceExpectedError(getToken().Value);
            }
            else throw new UndefinedError(getToken().Value);

            if (TokenIs_ID())
                if (Rep_IDS())
                    return ReturnTrue();

            return ReturnFalse("IDS");
        }


        private static bool Rep_IDS()
        {
            if (Utility.EnableSS && !getToken().Value.Equals(",")) return true;

            log.AddLog("Rep_IDS", getToken());

            if (TokenIs(","))
            {
                if (IDS()) return ReturnTrue();
            }
            else return true;

            return ReturnFalse("Rep_IDS");
        }

        private static bool Dot_Chain()
        {
            log.AddLog("Dot_Chain", getToken());

            if (TokenIs("["))
            {
                if (Value())
                    if (TokenIs("]"))
                        if (Ops1())
                            return ReturnTrue();
            }
            else if (Ops1())
            {
                return ReturnTrue();
            }

            return ReturnFalse("Dot_Chain");
        }


        private static bool Ops1()
        {
            if (Utility.EnableSS && !(getToken().Value.Equals(".") || getToken().Value.Equals("("))) return true;

            log.AddLog("Ops1", getToken());

            if (TokenIs("."))
            {
                if (TokenIs_ID())
                    if (Ter20()) return ReturnTrue();
            }
            else if (Fn_Call())
            {
                if (Fn_Op()) return ReturnTrue();
            }
            else return ReturnTrue();

            /*else if (TokenIs("="))
            {
                if (Ter3()) return ReturnTrue();
            }*/


            return ReturnFalse("Ops1");
        }

        private static bool Fn_Op()
        {
            if (Utility.EnableSS && !getToken().Value.Equals(".")) return true;

            log.AddLog("Fn_Op", getToken());

            if (TokenIs("."))
            {
                if (TokenIs_ID())
                    if (Ops1()) return ReturnTrue();
            }
            else return ReturnTrue();

            return ReturnFalse("Fn_Op");
        }


        private static bool Ter20()
        {
            log.AddLog("Ter20", getToken());

            if (Fn_Call())
            {
                if (Ops1()) return ReturnTrue();
            }
            else if (TokenIs("["))
            {
                if (Value())
                    if (TokenIs("]"))
                        if (Ops1())
                            return ReturnTrue();
            }
            else if (Ops1()) return ReturnTrue();

            return ReturnFalse("Ter20");
        }


        private static bool Value()
        {
            log.AddLog("Value", getToken());

            if (Exp())
                if (Ops2())
                    return ReturnTrue();

            return ReturnFalse("Value");
        }

        private static bool Ops2()
        {
            log.AddLog("Ops2", getToken());

            if (TokenIs(","))
            {
                if (Exp()) return ReturnTrue();
            }
            else return ReturnTrue();

            return ReturnFalse("Ops2");
        }

        

        private static bool Input_Par()
        {
            log.AddLog("Input_Par", getToken());

            if (SelectionSets.Check_Input_Par_SelectionSet(getToken().Value))
            {
                string IDorDT = getToken().Value;
                if (TokenIs_ID())
                {
                    if (Ter19(IDorDT)) return ReturnTrue();
                }
                else if (TokenIs_DT())
                {
                    if (Ter19(IDorDT)) return ReturnTrue();
                }
            }
            else return ReturnTrue();

            return ReturnFalse("Input_Par");
        }

        private static bool Ter19(string DT)
        {
            log.AddLog("Ter19", getToken());

            if (TokenIs_ID())
            {
                string Name = tokenList[i - 1].Value;
                FunctionTableEntry entry = ScopeUtility.CheckEntityExist(Name, currentScopeID, currentLevel);
                if (entry == null) FunctionTable.AddEntry(new FunctionTableEntry(Name, null, DT, currentScopeID, currentLevel));
                else throw new ReDeclarationError(Name, DT);
                IDsList.Add(DT);

                if (Rpt())
                    return ReturnTrue();
            }
            else if (TokenIs("["))
            {
                string coma = "";
                if (Comma(out coma))
                    if (TokenIs("]"))
                    {
                        DT += "[" + coma + "]";
                        if (TokenIs_ID())
                        {
                            string Name = tokenList[i - 1].Value;
                            FunctionTableEntry entry = ScopeUtility.CheckEntityExist(Name, currentScopeID, currentLevel);
                            if (entry == null) FunctionTable.AddEntry(new FunctionTableEntry(Name, null, DT, currentScopeID, currentLevel));
                            else throw new ReDeclarationError(Name, DT);
                            IDsList.Add(DT);

                            if (Rpt()) return ReturnTrue();
                        }
                    }
            }

            return ReturnFalse("Ter19");
        }

        private static bool Rpt()
        {
            log.AddLog("Rpt", getToken());

            if (TokenIs(","))
            {
                if (Input_Par()) return ReturnTrue();
            }
            else return ReturnTrue();

            return ReturnFalse("Rpt");
        }

        private static bool MST()
        {
            log.AddLog("MST", getToken());

            if (SelectionSets.Check_MST_SelectionSet(getToken()))
            {
                if (SST())
                    if (MST()) return ReturnTrue();
            }
            else return ReturnTrue();

            return ReturnFalse("MST");
        }

        private static bool Body()
        {
            log.AddLog("Body", getToken());

            if (TokenIs(";"))
            {
                return ReturnTrue();
            }
            else if (TokenIs("{"))
            {
                if (MST())
                    if (TokenIs("}"))
                        return ReturnTrue();
            }
            else if (SST())
            {
                return ReturnTrue();
            }

            return ReturnFalse("Body");
        }

        private static bool TS()
        {
            log.AddLog("TS", getToken());

            if (TokenIs("this"))
            {
                if (TokenIs("."))
                    return ReturnTrue();
            }
            else if (TokenIs("super"))
            {
                if (TokenIs("."))
                    return ReturnTrue();
            }
            else return ReturnTrue();

            return ReturnFalse("TS");
        }

        // Falto kam
        private static bool Const()
        {
            log.AddLog("Const", getToken());

            if (IsConstant()) return ReturnTrue();

            return ReturnFalse("Const");
        }






        /* ###################################################
                GENERAL
        */ //#################################################



        private static bool while_St()
        {
            if (Utility.EnableSS && !getToken().Value.Equals("repeat")) return false;

            log.AddLog("while_St", getToken());

            if (TokenIs("repeat"))
            {
                if (TokenIs("("))
                {
                    if (Exp())
                    {
                        if (TokenIs(")"))
                        {
                            if (Body()) return ReturnTrue();
                        }
                    }
                }
            }

            return ReturnFalse("while_St");
        }



        private static bool Do_While()
        {
            if (Utility.EnableSS && !getToken().Value.Equals("do")) return false;

            log.AddLog("Do_While", getToken());

            if (TokenIs("do"))
            {
                if (Body())
                {
                    if (TokenIs("repeat"))
                    {
                        if (TokenIs("("))
                        {
                            if (Exp())
                            {
                                if (TokenIs(")"))
                                {
                                    if (TokenIs(";"))
                                    {
                                        return ReturnTrue();
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return ReturnFalse("Do_While");
        }

        private static bool If_Else()
        {
            if (Utility.EnableSS && !getToken().Value.Equals("whether")) return false;

            log.AddLog("If_Else", getToken());

            if (TokenIs("whether"))
            {
                if (TokenIs("("))
                {
                    if (Exp())
                    {
                        if (TokenIs(")"))
                        {
                            if (Body())
                                if (Else()) return ReturnTrue();
                        }
                    }
                }
            }

            return ReturnFalse("If_Else");
        }

        private static bool Else()
        {
            if (Utility.EnableSS && !getToken().Value.Equals("or")) return true;

            log.AddLog("Else", getToken());

            if (TokenIs("or"))
            {
                if (Body()) return ReturnTrue();
            }
            else return ReturnTrue();

            return ReturnFalse("Else");
        }

        private static bool Fn_Call()
        {
            if (Utility.EnableSS && !getToken().Value.Equals("(")) return false;

            log.AddLog("Fn_Call", getToken());

            if (TokenIs("("))
            {
                if (Par())
                {
                    if (TokenIs(")"))
                    {
                        return ReturnTrue();
                    }
                }
            }
            return ReturnFalse("Fn_Call");
        }

        private static bool Par()
        {
            log.AddLog("Par", getToken());

            if (SelectionSets.Check_Par_Selection_Set(getToken().Value))
            {
                if (Par1()) return ReturnTrue();
            }
            else return ReturnTrue();

            return ReturnFalse("Par");
        }

        private static bool Par1()
        {
            log.AddLog("Par1", getToken());

            if (Exp())
            {
                if (Par2()) return ReturnTrue();
            }

            return ReturnFalse("Par1");
        }

        private static bool Par2()
        {
            log.AddLog("Par2", getToken());
            if (TokenIs(","))
            {
                if (Par1()) return ReturnTrue();
            }
            else return ReturnTrue();

            return ReturnFalse("Par2");
        }


        private static bool Ret_St()
        {
            if (Utility.EnableSS && !getToken().Value.Equals("rtn")) return false;

            log.AddLog("Ret_St", getToken());

            if (TokenIs("rtn"))
            {
                if (X()) return ReturnTrue();
            }

            return ReturnFalse("Ret_St");
        }

        private static bool X()
        {
            log.AddLog("X", getToken());

            if (TokenIs(";"))
            {
                return ReturnTrue();
            }
            else if (Ter3()) return ReturnTrue();

            return ReturnFalse("X");
        }

        private static bool Follow_Dot_Chain()
        {
            if (Utility.EnableSS && !getToken().Value.Equals(".")) return true;

            log.AddLog("Follow_Dot_Chain", getToken());

            if (TokenIs("."))
            {
                if (Dot_Chain()) return ReturnTrue();
            }
            else return ReturnTrue();

            return ReturnFalse("Follow_Dot_Chain");
        }

        private static bool Ter3()
        {
            log.AddLog("Ter3", getToken());

            if (IsConstant())
            {
                if (TokenIs(";")) return ReturnTrue();
            }
            else if (TokenIs("!"))
            {
                if (F())
                {
                    if (TokenIs(";"))
                    {
                        return ReturnTrue();
                    }
                }
            }
            else if (TokenIs_ID())
            {
                if (Ter9())
                {
                    if (TokenIs(";"))
                    {
                        return ReturnTrue();
                    }
                }
            }
            else if (IsIncDecOperator())
            {
                if (Ter10())
                {
                    if (TokenIs(";"))
                    {
                        return ReturnTrue();
                    }
                }
            }
            else if (TokenIs("("))
            {
                if (Exp())
                {
                    if (TokenIs(")"))
                    {
                        if (TokenIs(";"))
                        {
                            return ReturnTrue();
                        }
                    }
                }
            }
            else if (TokenIs("this"))
            {
                if (TokenIs("."))
                {
                    if (TokenIs_ID())
                    {
                        if (Fn_Call())
                        {
                            if (Follow_Dot_Chain())
                            {
                                if (TokenIs(";"))
                                {
                                    return ReturnTrue();
                                }
                            }
                        }
                    }
                }
            }
            else if (TokenIs("super"))
            {
                if (TokenIs("."))
                {
                    if (TokenIs_ID())
                    {
                        if (Fn_Call())
                        {
                            if (Follow_Dot_Chain())
                            {
                                if (TokenIs(";"))
                                {
                                    return ReturnTrue();
                                }
                            }
                        }
                    }
                }
            }
            else if (TokenIs("new"))
            {
                if (Ter6()) return ReturnTrue();
            }
            return ReturnFalse("Ter3");
        }

        private static bool Ter6()
        {
            log.AddLog("Ter6", getToken());

            if (TokenIs_DT())
            {
                if (TokenIs("["))
                {
                    if (Value())
                    {
                        if (TokenIs("]"))
                        {
                            if (Hard_Code())
                            {
                                return ReturnTrue();
                            }
                        }

                    }
                }
            }
            else if (TokenIs_ID())
            {
                if (Ter21())
                {
                    return ReturnTrue();
                }
            }

            return ReturnFalse("Ter6");
        }

        private static bool Ter211()
        {
            log.AddLog("Ter211", getToken());

            string coma = "";
            if (Comma(out coma))
            {
                if (TokenIs("]"))
                    if (TokenIs_ID())
                        if (Ter8()) return ReturnTrue();
            }
            else if (Value())
            {
                if (TokenIs("]"))
                    if (Ops1()) return ReturnTrue();
            }

            return ReturnFalse("Ter211");
        }


        private static bool Ter21()
        {
            log.AddLog("Ter21", getToken());

            if (TokenIs("["))
            {
                if (Value())
                {
                    if (TokenIs("]"))
                    {
                        if (Hard_Code())
                        {
                            return ReturnTrue();
                        }
                    }

                }
            }
            else if (Fn_Call())
            {
                if (Follow_Dot_Chain())
                {
                    if (TokenIs(";"))
                    {
                        return ReturnTrue();
                    }
                }
            }

            return ReturnFalse("Ter21");
        }

        private static bool Imp_St()
        {
            log.AddLog("Imp_St", getToken());

            if (TokenIs("import"))
            {
                if (TokenIs("{"))
                {
                    if (IDS1())
                    {
                        if (TokenIs("}"))
                        {
                            if (TokenIs("from"))
                            {
                                if (IsStringConstant())
                                {
                                    if (TokenIs(";"))
                                    {
                                        return ReturnTrue();
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return ReturnFalse("Imp_St");
        }

        private static bool IDS1()
        {
            log.AddLog("IDS1", getToken());

            if (TokenIs("*"))
            {
                return ReturnTrue();
            }
            else if (IDS())
            {
                return ReturnTrue();
            }


            return ReturnFalse("IDS1");
        }

        private static bool Dec(string AM ,string DT,string Name)
        {
            if (Utility.EnableSS && !SelectionSets.Check_Dec_Selection_Set(getToken())) return false;

            log.AddLog("Dec", getToken());

            if (Init())
            {
                if (List(AM,DT,Name)) return ReturnTrue();
            }

            return ReturnFalse("Dec");
        }

        private static bool Init()
        {
            if (Utility.EnableSS && !getToken().Value.Equals("=")) return true;

            log.AddLog("Init", getToken());

            if (TokenIs("="))
            {
                if (Exp())
                {
                    return ReturnTrue();
                }
            }
            else return ReturnTrue();

            return ReturnFalse("Init");
        }


        private static bool List(string AM, string DT, string Name)
        {
            log.AddLog("List", getToken());

            if (TokenIs(";"))
            {
                if (InsideClassBody)
                {
                    if (currentClassName == Name) throw new GeneralSemanticError("class with name  ' "+ currentClassName+" '  already exists can't create attribute with same name.");
                    if (!cTable.CheckEntryExistsByName(Name)) cTable.AddEntry(new ClassTableEntry(Name, DT, false, AM));
                    else throw new ReDeclarationError(Name,DT);
                }

                return ReturnTrue();
            }
            else if (TokenIs(","))
            {
                if (TokenIs_ID())
                {
                    Name = tokenList[i - 1].Value;

                    if (Init())
                    {
                        if (List(AM,DT,Name)) return ReturnTrue();
                    }
                }
            }

            return ReturnFalse("List");
        }

        private static bool Assign_St()
        {
            log.AddLog("Assign_St", getToken());

            if (Dot_Chain())
            {
                if (TokenIs("="))
                {
                    if (Ter3())
                    {
                        return ReturnTrue();
                    }
                }
            }

            return ReturnFalse("Assign_St");
        }

        private static bool Inc_Dec_St()
        {
            if (Utility.EnableSS && !getToken().ClassName.Equals("Operator / IncDec")) return false;

            log.AddLog("Inc_Dec_St", getToken());

            if (IsIncDecOperator())
            {
                if (TS())
                {
                    if (Dot_Chain())
                    {
                        return ReturnTrue();
                    }
                }
            }

            return ReturnFalse("Inc_Dec_St");
        }


        private static bool Export_St()
        {
            if (Utility.EnableSS && !getToken().Value.Equals("export")) return false;

            log.AddLog("Export_St", getToken());

            if (TokenIs("export"))
            {
                if (TokenIs("="))
                {
                    if (TokenIs_ID())
                    {
                        if (TokenIs(";"))
                        {
                            return ReturnTrue();
                        }
                    }
                }
            }

            return ReturnFalse("Export_St");
        }


        private static bool G_Fn_Def()
        {
            log.AddLog("G_Fn_Def", getToken());

            if (CDT_ID())
            {
                if (TokenIs_ID())
                {
                    if (Fn_Def())
                    {
                        return ReturnTrue();
                    }
                }
            }
            return ReturnFalse("G_Fn_Def");
        }

        private static bool Fn_Def()
        {
            log.AddLog("Fn_Def", getToken());

            if (TokenIs("("))
            {
                IDsList.Clear();
                if (Input_Par())
                {
                    if (TokenIs(")"))
                    {
                        if (TokenIs("{"))
                        {
                            if (MST())
                            {
                                if (TokenIs("}"))
                                {
                                    return ReturnTrue();
                                }
                            }
                        }
                    }
                }
            }

            return ReturnFalse("Fn_Def");
        }

        private static bool G_Array_Def()
        {
            log.AddLog("G_Array_Def", getToken());

            if (TokenIs(";"))
            {
                return ReturnTrue();
            }
            else if (TokenIs("="))
            {
                if (Init1()) return ReturnTrue();
            }

            return ReturnFalse("G_Array_Def");
        }

        private static bool Init1()
        {
            log.AddLog("Init1", getToken());

            if (TokenIs("new"))
            {
                if (DT_ID())
                {
                    if (TokenIs("["))
                    {
                        if (Values())
                        {
                            if (TokenIs("]"))
                            {
                                if (Hard_Code())
                                {
                                    return ReturnTrue();
                                }
                            }
                        }
                    }
                }
            }

            return ReturnFalse("Init1");
        }


        private static bool Hard_Code()
        {
            log.AddLog("Hard_Code", getToken());

            if (TokenIs(";"))
            {
                return ReturnTrue();
            }
            else if (TokenIs("{"))
            {
                if (Values())
                {
                    if (Value_Bracket())
                    {
                        if (TokenIs(";"))
                        {
                            return ReturnTrue();
                        }
                    }
                }
            }

            return ReturnFalse("Hard_Code");
        }


        private static bool Value_Bracket()
        {
            log.AddLog("Value_Bracket", getToken());

            if (TokenIs(","))
            {
                if (Values())
                {
                    if (TokenIs("}"))
                    {
                        return ReturnTrue();
                    }
                }
            }
            else
            {
                if (TokenIs("}"))
                {
                    return ReturnTrue();
                }
            }

            return ReturnFalse("Value_Bracket");
        }


        private static bool Values()
        {
            log.AddLog("Values", getToken());

            if (Exp())
            {
                if (Ops3())
                {
                    return ReturnTrue();
                }
            }
            return ReturnFalse("Values");
        }


        private static bool Ops3()
        {
            log.AddLog("Ops3", getToken());

            if (TokenIs(","))
            {
                if (Values())
                {
                    return ReturnTrue();
                }
            }
            else return ReturnTrue();
            return ReturnFalse("Ops3");
        }

        private static bool Exp()
        {
            log.AddLog("Exp", getToken());

            if (AE())
            {
                if (Exp1())
                {
                    return ReturnTrue();
                }
            }
            return ReturnFalse("Exp");
        }

        private static bool Exp1()
        {
            log.AddLog("Exp1", getToken());

            if (TokenIs("||"))
            {
                if (AE())
                {
                    if (Exp1())
                    {
                        return ReturnTrue();
                    }
                }
            }
            else return ReturnTrue();

            return ReturnFalse("Exp1");
        }

        private static bool AE()
        {
            log.AddLog("AE", getToken());

            if (RE())
            {
                if (AE1())
                {
                    return ReturnTrue();
                }
            }
            return ReturnFalse("AE");
        }


        private static bool AE1()
        {
            log.AddLog("AE1", getToken());

            if (TokenIs("&&"))
            {
                if (RE())
                {
                    if (AE1())
                    {
                        return ReturnTrue();
                    }
                }
            }
            else return ReturnTrue();

            return ReturnFalse("AE1");
        }


        private static bool RE()
        {
            log.AddLog("RE", getToken());

            if (P())
            {
                if (RE1())
                {
                    return ReturnTrue();
                }
            }
            return ReturnFalse("RE");
        }

        private static bool RE1()
        {
            log.AddLog("RE1", getToken());

            if (IsRelationalOperator())
            {
                if (P())
                {
                    if (RE1())
                    {
                        return ReturnTrue();
                    }
                }
            }
            else return ReturnTrue();

            return ReturnFalse("RE1");
        }

        private static bool P()
        {
            log.AddLog("P", getToken());

            if (T())
            {
                if (P1())
                {
                    return ReturnTrue();
                }
            }

            return ReturnFalse("P");
        }

        private static bool P1()
        {
            log.AddLog("P1", getToken());

            if (IsPM())
            {
                if (T())
                {
                    if (P1())
                    {
                        return ReturnTrue();
                    }
                }
            }
            else return ReturnTrue();
            return ReturnFalse("P1");
        }

        private static bool T()
        {
            log.AddLog("T", getToken());

            if (F())
            {
                if (T1())
                    return ReturnTrue();
            }

            return ReturnFalse("T");
        }

        private static bool T1()
        {
            log.AddLog("T1", getToken());

            if (IsMDM())
            {
                if (F())
                {
                    if (T1())
                    {
                        return ReturnTrue();
                    }
                }
            }
            else return ReturnTrue();

            return ReturnFalse("T1");
        }

        private static bool F()
        {
            log.AddLog("F", getToken());

            if (IsConstant())
            {
                return ReturnTrue();
            }
            else if (TokenIs("!"))
            {
                if (F()) return ReturnTrue();
            }
            else if (TokenIs_ID())
            {
                if (Ter9()) return ReturnTrue();
            }
            else if (IsIncDecOperator())
            {
                if (Ter10()) return ReturnTrue();
            }
            else if (TokenIs("("))
            {
                if (Exp())
                {
                    if (TokenIs(")"))
                    {
                        return ReturnTrue();
                    }
                }
            }
            else if (TokenIs("new"))
            {
                if (TokenIs_ID())
                {
                    if (Fn_Call())
                    {
                        if (Ops1())
                        {
                            return ReturnTrue();
                        }
                    }
                }
            }
            else if (TokenIs("this"))
            {
                if (TokenIs("."))
                {
                    if (TokenIs_ID())
                        if (Ter20())
                            return ReturnTrue();
                }
            }
            else if (TokenIs("super"))
            {
                if (TokenIs("."))
                {
                    if (TokenIs_ID())
                    {
                        if (Fn_Call())
                        {
                            if (Follow_Dot_Chain())
                            {
                                //if (TokenIs(";")) return ReturnTrue();
                                return ReturnTrue();
                            }
                        }
                    }
                }
            }

            return ReturnFalse("F");
        }

        private static bool Ter9()
        {
            log.AddLog("Ter9", getToken());

            if (Utility.EnableSS && SelectionSets.Check_Ter9_Selection_Set(getToken().Value))
            {
                if (Dot_Chain())
                {
                    return ReturnTrue();
                }
                else if (Fn_Call())
                {
                    if (Follow_Dot_Chain())
                        return ReturnTrue();
                }

            }
            else return ReturnTrue();

            return ReturnFalse("Ter9");
        }

        private static bool Ter10()
        {
            log.AddLog("AE1", getToken());

            if (TokenIs("("))
            {
                if (Exp())
                {
                    if (TokenIs(")"))
                    {
                        return ReturnTrue();
                    }
                }
            }
            else if (TS())
            {
                if (Dot_Chain())
                {
                    return ReturnTrue();
                }
            }
            return ReturnFalse("Ter10");
        }

        private static bool Class_Def(string AM)
        {
            if (Utility.EnableSS && !(getToken().Value.Equals("abstract") || getToken().Value.Equals("class"))) return false;

            log.AddLog("Class_Def", getToken());

            bool Abstract;
            string Type;
            string Name;
            string Parent;
            List<string> InterfaceList;

            if (Abs(out Abstract))
            {
                if (TokenIs("class"))
                {
                    Type = "class";
                    Name = getToken().Value;
                    currentClassName = Name;

                    if (TokenIs_ID())
                    {
                        IDsList.Clear();

                        if (Ter(Type,out Parent))
                        {
                            InterfaceList = IDsList;
                            ClassTable table = new ClassTable();

                            if (!MainTable.CheckEntryExistsByName(Name))
                                MainTable.AddEntry(new MainTableEntry(Name, Type, Abstract, AM, Parent, InterfaceList,table));
                            else throw new ReDeclarationError(Name, Type);

                            cTable = table;
                            InsideClassBody = true;

                            if (TokenIs("{"))
                            {
                                currentScopeID = ScopeUtility.generateScopeID();
                                currentLevel++;
                                isGlobalScope = false;

                                if (Class_Body())
                                {
                                    if (TokenIs("}"))
                                    {
                                        cTable = null;
                                        InsideClassBody = false;
                                        isGlobalScope = true;
                                        reduceScope();
                                        return ReturnTrue();
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return ReturnFalse("Class_Def");
        }

        private static bool Ter(string ChildType,out string Parent)
        {
            Parent = null;
            if (Utility.EnableSS && !(getToken().Value.Equals("@") || getToken().Value.Equals("applies"))) return true;

            log.AddLog("Ter", getToken());

            if (TokenIs("@"))
            {
                Parent = getToken().Value;
                if (!MainTable.CheckEntryExistsByName(Parent)) throw new UndefinedError(Parent);
                else
                {
                    if (!MainTable.GetEntryTypeByName(Parent).Equals(ChildType))
                        throw new InheritanceError(ChildType, MainTable.GetEntryTypeByName(Parent));
                }

                if (TokenIs_ID())
                {
                    if (Ter11())
                    {
                        return ReturnTrue();
                    }
                }
            }
            else if (TokenIs("applies"))
            {
                if (IDS())
                {
                    return ReturnTrue();
                }
            }
            else return ReturnTrue();

            return ReturnFalse("Ter");
        }

        private static bool Ter11()
        {
            if (Utility.EnableSS && !getToken().Value.Equals("applies")) return true;            

            log.AddLog("Ter11", getToken());

            if (TokenIs("applies"))
            {
                if (IDS())
                {
                    return ReturnTrue();
                }
            }
            else return ReturnTrue();
            return ReturnFalse("Ter11");
        }

        private static bool Class_Body()
        {
            log.AddLog("Class_Body", getToken());

            if (TokenIs("personal"))
            {
                if (Ter12("personal"))
                {
                    if (Class_Body()) return ReturnTrue();
                }
            }
            else if (TokenIs("general"))
            {
                if (Ter12("general"))
                {
                    if (Class_Body()) return ReturnTrue();
                }
            }
            else if (TokenIs("abstract"))
            {
                if (Obj_Fn())
                {
                    if (Class_Body()) return ReturnTrue();
                }
            }
            else if (TokenIs_ID())
            {
                string DT = tokenList[i - 1].Value;

                if (Ter13(DT))
                {
                    if (Class_Body()) return ReturnTrue();
                }
            }
            else if (TokenIs_DT())
            {
                string DT = tokenList[i - 1].Value;

                if (Ter14(DT))
                {
                    if (Class_Body()) return ReturnTrue();
                }
            }
            else if (TokenIs("empty"))
            {
                if (TokenIs_ID())
                {
                    if (Cntr(null,"empty",tokenList[i-1].Value))
                    {
                        if (Class_Body()) return ReturnTrue();
                    }
                }
            }
            else return ReturnTrue();

            return ReturnFalse("Class_Body");
        }

        private static bool Obj_Fn()
        {
            log.AddLog("Obj_Fn", getToken());

            if (TokenIs_ID())
            {
                if (Ter23())
                {
                    if (Cntr("" ,"" ,"")) return ReturnTrue();
                }
            }
            else if (TokenIs_DT())
            {
                if (Ter18())
                {
                    if (TokenIs_ID())
                    {
                        if (Cntr("" ,"" ,"")) return ReturnTrue();
                    }
                }
            }
            else if (TokenIs("empty"))
            {
                if (TokenIs_ID())
                {
                    if (Cntr("" ,"" ,"")) return ReturnTrue();
                }
            }

            return ReturnFalse("Obj_Fn");
        }

        private static bool Ter23()
        {
            log.AddLog("Ter23", getToken());

            if (TokenIs_ID())
            {
                return ReturnTrue();
            }
            else if (TokenIs("["))
            {
                string coma = "";
                if (Comma(out coma))
                {
                    if (TokenIs("]"))
                    {
                        if (TokenIs_ID())
                        {
                            return ReturnTrue();
                        }
                    }

                }
            }
            else return ReturnTrue();

            return ReturnFalse("Ter23");
        }


        private static bool Super()
        {
            log.AddLog("Super", getToken());

            if (TokenIs("super"))
            {
                if (TokenIs("("))
                {
                    if (Par())
                    {
                        if (TokenIs(")"))
                        {
                            return ReturnTrue();
                        }
                    }
                }
            }
            else return ReturnTrue();

            return ReturnFalse("Super");
        }

        private static bool Ter12(string AM)
        {
            log.AddLog("Ter12", getToken());

            if (TokenIs("abstract"))
            {
                if (Obj_Fn())
                {
                    return ReturnTrue();
                }
            }
            else if (TokenIs_DT())
            {
                string DT = tokenList[i - 1].Value;

                if (Ter17(AM,DT))
                {
                    return ReturnTrue();
                }
            }
            else if (TokenIs_ID())
            {
                string DT = tokenList[i - 1].Value;

                if (Ter121(AM,DT))
                {
                    return ReturnTrue();
                }
            }
            else if (TokenIs("empty"))
            {
                if (TokenIs_ID())
                {
                    string Name = tokenList[i - 1].Value;
                    if (Cntr(AM, "empty", Name)) return ReturnTrue();
                }
            }

            return ReturnFalse("Ter12");
        }

        private static bool Ter121(string AM, string DT)
        {
            log.AddLog("Ter121", getToken());

            if(getToken().ClassName == "Identifier")
            {
                if (TokenIs_ID())
                {
                    string Name = tokenList[i - 1].Value;
                    if (Ter7(AM,DT,Name)) return ReturnTrue();
                    else if (Cntr(AM,DT,Name)) return ReturnTrue();
                }
            }
            else if (Ter7(AM, null, DT)) return ReturnTrue();
            else if (Cntr(AM, null, DT)) return ReturnTrue();

            return ReturnFalse("Ter121");
        }


        private static bool Cntr(string AM, string DT, string Name)
        {
            if (Utility.EnableSS && !getToken().Value.Equals("(")) return false;

            log.AddLog("Cntr", getToken());

            if (TokenIs("("))
            {
                currentLevel++;
                IDsList.Clear();

                if (Input_Par())
                {
                    if (TokenIs(")"))
                    {
                        string TypeExp = FunctionTable.generateTypeExp(IDsList, DT);
                        if (InsideClassBody)
                        {
                            if (currentClassName == Name && DT != null) throw new GeneralSemanticError("class with name  ' " + currentClassName + " '  already exists can't create method with same name.");
                            if(DT == null && currentClassName != Name) throw new GeneralSemanticError("Constructor name should be kept as of class ' " + currentClassName + " '.");
                            if (!cTable.CheckEntryExistsByName(Name, TypeExp))
                                cTable.AddEntry(new ClassTableEntry(Name, TypeExp, false, AM));
                            else throw new ReDeclarationError(Name, TypeExp);
                        }

                        if (TokenIs("{"))
                        {
                            if (Super())
                            {
                                if (MST())
                                {
                                    if (TokenIs("}"))
                                    {
                                        reduceScope();
                                        return ReturnTrue();
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return ReturnFalse("Cntr");
        }

        private static bool Ter13(string DT)
        {
            log.AddLog("Ter13", getToken());

            if (TokenIs_ID())
            {
                string Name = tokenList[i - 1].Value;

                if (Ter16(null,DT,Name))
                {
                    return ReturnTrue();
                }
            }
            else if (TokenIs("["))
            {
                string coma = "";
                if (Comma(out coma))
                {
                    if (TokenIs("]"))
                    {
                        if (TokenIs_ID())
                        {
                            string Name = tokenList[i - 1].Value;
                            DT += "[" + coma + "]";
                            if (Ter15(null,DT,Name)) return ReturnTrue();
                        }
                    }
                }
            }
            else if (Cntr(null,null,DT))
            {
                return ReturnTrue();
            }

            return ReturnFalse("Ter13");
        }

        private static bool Ter14(string DT)
        {
            log.AddLog("Ter14", getToken());

            if (TokenIs_ID())
            {
                string Name = tokenList[i - 1].Value;

                if (Ter16(null,DT,Name))
                {
                    return ReturnTrue();
                }
            }
            else if (TokenIs("["))
            {
                string coma = "";
                if (Comma(out coma))
                {
                    if (TokenIs("]"))
                    {
                        if (TokenIs_ID())
                        {
                            string Name = tokenList[i - 1].Value;
                            DT += "[" + coma + "]";
                            if (Ter15(null,DT,Name)) return ReturnTrue();
                        }
                    }
                }
            }

            return ReturnFalse("Ter14");
        }

        private static bool Ter15(string AM, string DT, string Name)
        {
            log.AddLog("Ter15", getToken());

            if (Cntr(AM,DT,Name))
            {
                return ReturnTrue();
            }
            else if (G_Array_Def())
            {
                return ReturnTrue();
            }

            return ReturnFalse("Ter15");
        }

        private static bool Ter16(string AM,string DT,string Name)
        {
            log.AddLog("Ter16", getToken());

            if (Cntr(AM,DT,Name))
            {
                return ReturnTrue();
            }
            else if (Dec(AM, DT, Name))
            {
                return ReturnTrue();
            }

            return ReturnFalse("Ter16");
        }

        private static bool Ter17(string AM, string DT)
        {
            log.AddLog("Ter17", getToken());

            if (TokenIs_ID())
            {
                string Name = tokenList[i - 1].Value;               

                if (Ter16(AM,DT,Name))
                {
                    return ReturnTrue();
                }
            }
            else if (TokenIs("["))
            {
                string coma = "";
                if (Comma(out coma))
                {
                    if (TokenIs("]"))
                    {
                        if (TokenIs_ID())
                        {
                            string Name = tokenList[i-1].Value;
                            DT += "[" + coma + "]";
                            if (Cntr(AM,DT,Name)) return ReturnTrue();
                        }
                    }
                }
            }

            return ReturnFalse("Ter17");
        }

        private static bool Int_Def(string AM)
        {
            if (Utility.EnableSS && !getToken().Value.Equals("group")) return false;

            log.AddLog("Int_Def", getToken());

            string Type;
            string Name;

            if (TokenIs("group"))
            {
                Type = "group";
                Name = getToken().Value;

                if (TokenIs_ID())
                {
                    IDsList.Clear();

                    if (Inherit())
                    {
                        cTable = new ClassTable();

                        if (!MainTable.CheckEntryExistsByName(Name))
                            MainTable.AddEntry(new MainTableEntry(Name, Type, false, AM, null, IDsList, cTable));
                        else throw new ReDeclarationError(Name,Type);

                        if (TokenIs("{"))
                        {
                            currentScopeID = ScopeUtility.generateScopeID();
                            currentLevel = 0;
                            isGlobalScope = false;

                            if (Int_Body())
                            {
                                if (TokenIs("}"))
                                {
                                    isGlobalScope = true;
                                    return ReturnTrue();
                                }
                            }
                        }
                    }
                }
            }

            return ReturnFalse("Int_Def");
        }

        private static bool Inherit()
        {
            if (Utility.EnableSS && !getToken().Value.Equals("applies")) return true;

            log.AddLog("Inherit", getToken());

            if (TokenIs("applies"))
            {
                if (IDS())
                {
                    return ReturnTrue();
                }
            }
            else return ReturnTrue();

            return ReturnFalse("Inherit");
        }

        private static bool Int_Body()
        {
            log.AddLog("Int_Body", getToken());

            if (Int_Func())
            {
                return ReturnTrue();
            }
            else return ReturnTrue();
        }

        private static bool Int_Func()
        {
            if (Utility.EnableSS && !(getToken().Value.Equals("general") || getToken().Value.Equals("personal"))) return false;

            log.AddLog("Int_Func", getToken());

            if (AM())
            {
                if (TokenIs("abstract"))
                {
                    if (CDT_ID())
                    {
                        if (TokenIs_ID())
                        {
                            if (TokenIs("("))
                            {
                                IDsList.Clear();
                                if (Input_Par())
                                {
                                    if (TokenIs(")"))
                                    {
                                        if (TokenIs(";"))
                                        {
                                            if (Int_Func())
                                            {
                                                return ReturnTrue();
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            else return ReturnTrue();

            return ReturnFalse("Int_Func");
        }





        /* ###################################################
                UTILS
        */ //#################################################



        private static bool ReturnFalse(string name)
        {
            log.ChainBreak(name, tokenList[i], i);
            log.AddLOG("False", false, getToken());
            log.StopSerialFile();
            if (Utility.ThrowSyntaxError) throw new SyntaxError(getToken().LineNumber, getToken(), name);
            return false;
        }

        private static void reduceScope()
        {
            FunctionTable.RemoveEntries(currentLevel);
            currentLevel--;
        }

        private static bool ReturnTrue(string name = "")
        {
            log.AddLOG("__backTrackTree__#", true, getToken());
            return true;
        }


        private static bool IsRelationalOperator()
        {
            log.maintainHintStructure("Relational Operator");
            log.CheckTerminal("Relational op   result = " + Operators.IsRelationalOperator(getToken().Value), i);

            if (Operators.IsRelationalOperator(getToken().Value))
            {
                log.AddLOG(getToken().Value, false, getToken());
                i++;
                return true;
            }
            return false;
        }


        private static bool IsIncDecOperator()
        {
            log.maintainHintStructure("Increment / Decrement Operator");
            log.CheckTerminal("IncDec op   result = " + getToken().ClassName.Equals("Operator / IncDec"), i);

            if (getToken().ClassName.Equals("Operator / IncDec"))
            {
                log.AddLOG(getToken().Value, false, getToken());
                i++;
                return true;
            }
            return false;
        }

        private static bool IsPM()
        {
            log.maintainHintStructure("+ or -");
            log.CheckTerminal("PM   result = " + Operators.IsPM(getToken().Value), i);

            if (Operators.IsPM(getToken().Value))
            {
                log.AddLOG(getToken().Value, false, getToken());
                i++;
                return true;
            }
            return false;
        }


        private static bool IsMDM()
        {
            log.maintainHintStructure("* or / or %");
            log.CheckTerminal("MDM   result = " + Operators.IsMDM(getToken().Value), i);

            if (Operators.IsMDM(getToken().Value))
            {
                log.AddLOG(getToken().Value, false, getToken());
                i++;
                return true;
            }
            return false;
        }


        private static Token getToken()
        {
            return tokenList[i];
        }

        private static bool TokenIs(string match)
        {
            log.maintainHintStructure(match);
            log.CheckTerminal(match + "   result = " + getToken().Value.Equals(match), i);
            if (getToken().Value.Equals(match))
            {
                log.AddLOG(match, false, getToken());
                i++;
                return true;
            }
            return false;
        }

        private static bool TokenIs_ID()
        {
            log.maintainHintStructure("Indentifier");
            log.CheckTerminal("Checking for Identifier   result = " + (getToken().ClassName.Equals("Identifier")).ToString(), i);
            if (getToken().ClassName.Equals("Identifier"))
            {
                log.AddLOG("ID => " + getToken().Value, false, getToken());
                i++;
                return true;
            }
            return false;
        }

        private static bool IsStringConstant()
        {
            log.maintainHintStructure("String Constant");
            log.CheckTerminal("String constant   result = " + getToken().ClassName.Equals("Constant / String"), i);

            if (getToken().ClassName.Equals("Constant / String"))
            {
                log.AddLOG(getToken().Value, false, getToken());
                i++;
                return true;
            }
            return false;
        }


        private static bool IsConstant()
        {
            log.maintainHintStructure("Any Constant");
            log.CheckTerminal("Constant   result = " + getToken().ClassName.Contains("Constant"), i);

            if (getToken().ClassName.Contains("Constant"))
            {
                log.AddLOG(getToken().Value, false, getToken());
                i++;
                return true;
            }
            return false;
        }

        private static bool TokenIs_DT()
        {
            log.maintainHintStructure("Primitiv Datatype");
            log.CheckTerminal("Checking for DataType   result = " + (getToken().ClassName.Equals("Keyword / DT")).ToString(), i);
            if (getToken().ClassName.Equals("Keyword / DT"))
            {
                log.AddLOG(getToken().Value, false, getToken());
                i++;
                return true;
            }
            return false;
        }

        private static Token getCompleteToken()
        {
            if (tokenList.Count < i)
            {
                return new Token("", "", 0);
            }
            return tokenList[i];
        }

        private static bool CheckList(List<string> list,string item)
        {
            return list.Contains(item);
        }
    }
}
