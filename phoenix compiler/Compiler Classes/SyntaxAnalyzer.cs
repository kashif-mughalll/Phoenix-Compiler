using Compiler_Pheonix;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace phoenix_compiler
{
    static class SyntaxAnalyzer
    {
        private static CallLogger log;
        private static List<Token> tokenList;
        private static int i = 0;


        public static bool Start(List<Token> _tokenList)
        {
            tokenList = _tokenList;
            i = 0;
            log = new CallLogger(false);
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
            if (TokenIs("$$$") || tokenList[i].Value.Equals("$$$")) return true;
            return false;
        }

        
        private static bool Start_Global()
        {
            log.AddLog("Start_Global", getToken());
            
            if (endMarker())
            {
                Console.WriteLine("ending here");
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
                return true;
            }
            else if (Do_While())
            {
                return true;
            }
            else if (If_Else())
            {
                return true;
            }
            else if (Ret_St())
            {
                return true;
            }
            else if (Export_St())
            {
                return true;
            }
            else if (TokenIs("break"))
            {
                if (TokenIs(";"))
                    return true;
            }
            else if (TokenIs("continue"))
            {
                if (TokenIs(";"))
                    return true;
            }
            else if (Inc_Dec_St())
            {
                return true;
            }
            else if (Combine1())
            {
                return true;
            }

            return ReturnFalse("SST1");
        }

        private static bool Combine1()
        {
            log.AddLog("Combine1", getToken());

            if (TokenIs_ID())
            {                
                if (Ter41()) return true;
            }
            else if (TokenIs_DT())
            {                
                if (Ter51())
                {
                    return true;
                }
            }
            else if (TokenIs("empty"))
            {                
                if (TokenIs_ID())
                {                   
                    if (Fn_Def()) return true;
                }
            }
            else if (TokenIs("general"))
            {                
                if (Ter1())
                {
                    return true;
                }
            }
            else if (TokenIs("personal"))
            {
                if (Ter1())
                {
                    return true;
                }
            }
            /*else if (TokenIs("this"))
            {                
                if (TokenIs("."))
                {                    
                    if (TokenIs_ID())
                    {                        
                        if (Assign_St())
                        {
                            return true;
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
                        if (Assign_St())
                        {
                            return true;
                        }
                    }
                }
            }*/
            else if (Class_Def())
            {
                return true;
            }
            else if (Int_Def())
            {
                return true;
            }

            return ReturnFalse("Combine1");
        }


        private static bool Ter1()
        {
            log.AddLog("Ter1", getToken());

            if (Class_Def())
            {
                return true;
            }
            else if (Int_Def())
            {
                return true;
            }
            else if (G_Fn_Def())
            {
                return true;
            }

            return ReturnFalse("Ter1");
        }

        private static bool SST()
        {
            log.AddLog("SST", getToken());

            if (while_St())
            {
                return true;
            }
            else if (Do_While())
            {
                return true;
            }
            else if (If_Else())
            {
                return true;
            }
            else if (Ret_St())
            {
                return true;
            }
            else if (Export_St())
            {
                return true;
            }
            else if (TokenIs("break"))
            {
                if (TokenIs(";"))
                    return true;
            }
            else if (TokenIs("continue"))
            {
                if (TokenIs(";"))
                    return true;
            }
            else if (Inc_Dec_St())
            {
                return true;
            }
            else if (Combine())
            {
                return true;
            }

            return ReturnFalse("SST");
        }



        private static bool Combine()
        {
            log.AddLog("Combine", getToken());

            if (TokenIs_ID())
            {
                if (Ter4()) return true;
            }
            else if (TokenIs_DT())
            {
                if (Ter5())
                {
                    return true;
                }
            }
            /*else if (TokenIs("empty"))
            {
                if (TokenIs_ID())
                {
                    if (Fn_Def()) return true;
                }
            }
            else if (TokenIs("general"))
            {
                if (G_Fn_Def())
                {
                    return true;
                }
            }
            else if (TokenIs("personal"))
            {
                if (G_Fn_Def())
                {
                    return true;
                }
            }*/
            else if (TokenIs("this"))
            {
                if (TokenIs("."))
                {
                    if (TokenIs_ID())
                    {
                        if (Ops1())
                        {
                            return true;
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
                        if (Ops1())
                        {
                            return true;
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
                if (Ter2()) return true;
            }
            else if (TokenIs_ID())
            {
                if (Dec()) return true;
            }
            else if (Ops1())
            {
                return true;
            }

            return ReturnFalse("Ter4");
        }

        private static bool Ter41()
        {
            log.AddLog("Ter41", getToken());

            if (TokenIs("["))
            {
                if (Ter211()) return true;
            }
            else if (TokenIs_ID())
            {
                if (Ter7()) return true;
            }
            else if (Ops1())
            {
                return true;
            }

            return ReturnFalse("Ter41");
        }


        private static bool Ter2()
        {
            log.AddLog("Ter2", getToken());

            if (Comma())
            {
                if(TokenIs("]"))
                {
                    if (TokenIs_ID())
                    {
                        if(G_Array_Def()) return true;
                    }
                }
            }
            else if (Value())
            {
                if (TokenIs("]"))
                {
                    if (Ops1()) return true;
                }
            }

            return ReturnFalse("Ter2");
        }


        private static bool Ter5()
        {
            log.AddLog("Ter5", getToken());

            if (TokenIs_ID())
            {
                if (Dec()) return true;
            }
            else if (TokenIs("["))
            {
                if (Comma())
                {
                    if (TokenIs("]"))
                    {
                        if (TokenIs_ID())
                        {
                            if (G_Array_Def()) return true;
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
                if (Ter7()) return true;
            }
            else if (TokenIs("["))
            {
                if (Comma())
                {
                    if (TokenIs("]"))
                    {
                        if (TokenIs_ID())
                        {
                            if (Ter8()) return true;
                        }
                    }
                }
            }

            return ReturnFalse("Ter51");
        }


        private static bool Ter7()
        {
            log.AddLog("Tr7", getToken());

            if (Dec()) return true;
            else if (Fn_Def()) return true;

            return ReturnFalse("Ter7");
        }


        private static bool Ter8()
        {
            log.AddLog("Ter8", getToken());

            if (Fn_Def()) return true;
            else if (G_Array_Def()) return true;

            return ReturnFalse("Ter8");
        }


        private static bool Abs()
        {
            log.AddLog("Abs", getToken());

            if (TokenIs("abstract")) return true;
            else return true;
        }


        private static bool CDT_ID()
        {
            log.AddLog("CDT_ID", getToken());

            if (TokenIs_ID())
            {
                if (Ter18()) return true;
            }
            else if (TokenIs_DT())
            {
                if (Ter18()) return true;
            }
            else if (TokenIs("empty")) return true;

            return ReturnFalse("CDT_ID");
        }


        private static bool Ter18()
        {
            log.AddLog("Ter18", getToken());

            if (TokenIs("["))
            {
                if (Comma())
                {
                    if (TokenIs("]")) return true;
                }
            }
            else return true;

            return ReturnFalse("Ter18");
        }


        private static bool Comma()
        {
            log.AddLog("Comma", getToken());

            if (TokenIs(","))
                return true;
            else return true;
        }


        private static bool DT_ID()
        {
            log.AddLog("DT_ID", getToken());

            if (TokenIs_ID()) return true;
            else if (TokenIs_DT()) return true;

            return ReturnFalse("DT_ID");
        }

        private static bool AM()
        {
            log.AddLog("AM", getToken());

            if (TokenIs("general"))
                return true;
            else if (TokenIs("personal"))
                return true;
            else return true;
        }


        private static bool IDS()
        {
            log.AddLog("IDS", getToken());

            if (TokenIs_ID())
                if (Rep_IDS())
                    return true;

            return ReturnFalse("IDS");
        }


        private static bool Rep_IDS()
        {
            log.AddLog("Rep_IDS", getToken());

            if (TokenIs(","))
            {
                if (IDS()) return true;
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
                            return true;
            }
            else if (Ops1())
            {
                return true;
            }

            return ReturnFalse("Dot_Chain");
        }
        


        private static bool Ops1()
        {
            log.AddLog("Ops1", getToken());

            if (TokenIs("."))
            {
                if (TokenIs_ID())
                    if (Ter20()) return true;
            }
            else if (Fn_Call())
            {
                if (Fn_Op()) return true;
            }
            else if (TokenIs("="))
            {
                if (Ter3()) return true;
            }

            return ReturnFalse("Ops1");
        }

        private static bool Fn_Op()
        {
            log.AddLog("Fn_Op", getToken());

            if (TokenIs("."))
            {
                if (TokenIs_ID())
                    if (Ops1()) return true;
            }
            else if (TokenIs(";")) return true;

            return ReturnFalse("Fn_Op");
        }


        private static bool Ter20()
        {
            log.AddLog("Ter20", getToken());

            if (Fn_Call())
            {
                if (Ops1()) return true;
            }
            else if (TokenIs("["))
            {
                if (Value())
                    if (TokenIs("]"))
                        if (Ops1())
                            return true;
            }
            else if (Ops1()) return true;

            return ReturnFalse("Ter20");
        }


        private static bool Value()
        {
            log.AddLog("Value", getToken());

            if (Exp())
                if (Ops2())
                    return true;

            return ReturnFalse("Value");
        }

        private static bool Ops2()
        {
            log.AddLog("Ops2", getToken());

            if (TokenIs(","))
            {
                if (Exp()) return true;
            }
            else return true;

            return ReturnFalse("Ops2");
        }


        private static bool Input_Par()
        {
            log.AddLog("Input_Par", getToken());

            if (SelectionSets.Check_Input_Par_SelectionSet(getToken().Value))
            {
                if (TokenIs_ID())
                {
                    if (Ter19()) return true;
                }
                else if (TokenIs_DT())
                {
                    if (Ter19()) return true;
                }
            }
            else return true;

            return ReturnFalse("Input_Par");
        }

        private static bool Ter19()
        {
            log.AddLog("Ter19", getToken());

            if (TokenIs_ID())
            {
                if (Rpt())
                    return true;
            }
            else if (TokenIs("["))
            {
                if (Comma())
                    if (TokenIs("]"))
                        if (TokenIs_ID())
                            if (Rpt())
                                return true;
            }

            return ReturnFalse("Ter19");
        }

        private static bool Rpt()
        {
            log.AddLog("Rpt", getToken());

            if (TokenIs(","))
            {
                if (Input_Par()) return true;
            }
            else return true;

            return ReturnFalse("Rpt");
        }

        private static bool MST()
        {
            log.AddLog("MST", getToken());

            if (SelectionSets.Check_MST_SelectionSet(getToken()))
            {
                if (SST())
                    if (MST()) return true;                
            }
            else return true;

            return ReturnFalse("MST");
        }

        private static bool Body()
        {
            log.AddLog("Body", getToken());

            if (TokenIs(";"))
            {
                return true;
            }
            else if (TokenIs("{"))
            {
                if (MST())
                    if (TokenIs("}"))
                        return true;
            }
            else if (SST())
            {
                return true;
            }            

            return ReturnFalse("Body");
        }

        private static bool TS()
        {
            log.AddLog("TS", getToken());

            if (TokenIs("this"))
            {
                if (TokenIs("."))
                    return true;
            }
            else if (TokenIs("super"))
            {
                if (TokenIs("."))
                    return true;
            }
            else return true;

            return ReturnFalse("TS");
        }

        // Falto kam
        private static bool Const()
        {
            log.AddLog("Const", getToken());

            if (IsConstant()) return true;

            return ReturnFalse("Const");
        }

       




        /* ###################################################
                GENERAL
        */ //#################################################

            

        private static bool while_St()
        {
            log.AddLog("while_St", getToken());

            if(TokenIs("repeat"))
            {                
                if(TokenIs("("))
                {
                    if (Exp())
                    {
                        if(TokenIs(")"))
                        {
                            if(Body()) return true;
                        }
                    }
                }
            }

            return ReturnFalse("while_St");
        }

        

        private static bool Do_While()
        {
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
                                        return true;
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
                                if(Else()) return true;
                        } 
                    }
                }
            }

            return ReturnFalse("If_Else");
        }

        private static bool Else()
        {
            log.AddLog("Else", getToken());

            if (TokenIs("or"))
            {
                if (Body()) return true;
            }
            else return true;           

            return ReturnFalse("Else");
        }

        private static bool Fn_Call()
        {
            log.AddLog("Fn_Call", getToken());

            if (TokenIs("("))
            {                
                if (Par())
                {
                    if (TokenIs(")"))
                    {
                        return true;
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
                if (Par1()) return true;
            }
            else return true;

            return ReturnFalse("Par");
        }

        private static bool Par1()
        {
            log.AddLog("Par1", getToken());

            if (Exp())
            {
                if (Par2()) return true;                
            }

            return ReturnFalse("Par1");
        }

        private static bool Par2()
        {
            log.AddLog("Par2", getToken());
            if (TokenIs(","))
            {                
                if (Par1()) return true;
            }
            else return true;

            return ReturnFalse("Par2");        
        }


        private static bool Ret_St()
        {
            log.AddLog("Ret_St", getToken());

            if(TokenIs("rtn"))
            {
                if (X()) return true;
            }

            return ReturnFalse("Ret_St"); 
        }

        private static bool X()
        {
            log.AddLog("X", getToken());

            if (TokenIs(";"))
            {                
                return true;
            }
            else if(Ter3()) return true;

            return ReturnFalse("X"); 
        }

        private static bool Follow_Dot_Chain()
        {
            log.AddLog("Follow_Dot_Chain", getToken());

            if (TokenIs("."))
            {
                if (Dot_Chain()) return true;
            }
            else return true;

            return ReturnFalse("Follow_Dot_Chain");
        }

        private static bool Ter3()
        {
            log.AddLog("Ter3", getToken());

            if (IsConstant())
            {
                if(TokenIs(";")) return true;
            }
            else if (TokenIs("!"))
            {                
                if (F())
                {
                    if(TokenIs(";"))
                    {                        
                        return true;
                    }
                }
            }
            else if (TokenIs_ID())
            {                
                if (Ter9())
                {
                    if(TokenIs(";"))
                    {
                        return true;
                    }
                }
            }
            else if (IsIncDecOperator())
            {       
                if (Ter10())
                {
                    if (TokenIs(";"))
                    {                        
                        return true;
                    }
                }
            }
            else if (TokenIs("("))
            {                
                if (Exp())
                {
                    if(TokenIs( ")"))
                    {                        
                        if(TokenIs(";"))
                        {                            
                            return true;
                        }
                    }
                }
            }
            else if (TokenIs("this"))
            {
                if(TokenIs("."))
                {                    
                    if (TokenIs_ID())
                    {                        
                        if (Fn_Call())
                        {
                            if (Follow_Dot_Chain())
                            {
                                if(TokenIs(";"))
                                {                                    
                                    return true;                                    
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
                                    return true;
                                }
                            }
                        }
                    }
                }
            }
            else if (TokenIs("new"))
            {
                if (Ter6()) return true;                
            }
            return ReturnFalse("Ter3");
        }

        private static bool Ter6()
        {
            log.AddLog("Ter6", getToken());

            if (TokenIs_DT())
            {                
                if(TokenIs("["))
                {                    
                    if (Value())
                    {
                        if (TokenIs("]"))
                        {                            
                            if (Hard_Code())
                            {
                                return true;
                            }
                        }

                    }
                }
            }
            else if (TokenIs_ID())
            {                
                if (Ter21())
                {
                    return true;
                }
            }

            return ReturnFalse("Ter6");
        }

        private static bool Ter211()
        {
            log.AddLog("Ter211", getToken());

            if (Comma())
            {
                if(TokenIs("]"))
                    if (TokenIs_ID())
                        if (Ter8()) return true;
            }
            else if (Value())
            {
                if (TokenIs("]"))
                    if (Ops1()) return true;
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
                            return true;
                        }
                    }

                }
            }
            else if (Fn_Call())
            {
                if (Follow_Dot_Chain())
                {
                    if(TokenIs(";"))
                    {                        
                        return true;
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
                                        return true;
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

            if (IDS())
            {
                return true;
            }
            else if (TokenIs("*"))
            {
                return true;
            }

            return ReturnFalse("IDS1");
        }

        private static bool Dec()
        {
            log.AddLog("Dec", getToken());

            if (Init())
            {
                if (List()) return true;                
            }
            return ReturnFalse("Dec");
        }

        private static bool Init()
        {
            log.AddLog("Init", getToken());

            if (TokenIs("="))
            {                
                if (Exp())
                {
                    return true;
                }
            }
            else return true;

            return ReturnFalse("Init");
        }


        private static bool List()
        {
            log.AddLog("List", getToken());

            if (TokenIs(";"))
            {                
                return true;
            }
            else if (TokenIs(","))
            {                
                if (TokenIs_ID())
                {
                    if (Init())
                    {
                        if (List()) return true;
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
                if(TokenIs("="))
                {                    
                    if (Ter3())
                    {
                        return true;
                    }
                }
            }

            return ReturnFalse("Assign_St");
        }

        private static bool Inc_Dec_St()
        {
            log.AddLog("Inc_Dec_St", getToken());

            if (IsIncDecOperator())
            {
                if (TS())
                {
                    if (Dot_Chain())
                    {
                        return true;
                    }
                }
            }

            return ReturnFalse("Inc_Dec_St");
        }


        private static bool Export_St()
        {
            log.AddLog("Export_St", getToken());

            if (TokenIs("export"))
            {                
                if (TokenIs("="))
                {
                    if (TokenIs_ID())
                    {                        
                        if(TokenIs(";"))
                        {
                            return true;
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
                        return true;
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
                if (Input_Par())
                {
                    if (TokenIs(")"))
                    {                        
                        if (TokenIs("{"))
                        {                            
                            if (MST())
                            {
                                if(TokenIs("}"))
                                {
                                    return true;
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
                return true;
            }
            else if(TokenIs("="))
            {                
                if (Init1()) return true;                
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
                                    return true;
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
                return true;
            }
            else if(TokenIs("{"))
            {                
                if (Values())
                {
                    if (Value_Bracket())
                    {
                        if (TokenIs(";"))
                        {
                            return true;
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
                        return true;
                    }
                }
            }
            else
            {
                if (TokenIs("}"))
                {
                    return true;
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
                    return true;
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
                    return true;
                }
            }
            else return true;
            return ReturnFalse("Ops3");
        }

        private static bool Exp()
        {
            log.AddLog("Exp", getToken());

            if (AE())
            {
                if (Exp1())
                {
                    return true;
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
                        return true;
                    }
                }
            }
            else return true;

            return ReturnFalse("Exp1");
        }

        private static bool AE()
        {
            log.AddLog("AE", getToken());

            if (RE())
            {
                if (AE1())
                {
                    return true;
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
                        return true;
                    }
                }
            }
            else return true;

            return ReturnFalse("AE1");
        }


        private static bool RE()
        {
            log.AddLog("RE", getToken());

            if (P())
            {
                if (RE1())
                {
                    return true;
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
                        return true;
                    }
                }
            }
            else return true;

            return ReturnFalse("RE1");
        }

        private static bool P()
        {
            log.AddLog("P", getToken());

            if (T())
            {
                if (P1())
                {
                    return true;
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
                        return true;
                    }
                }
            }
            else return true;
            return ReturnFalse("P1");
        }

        private static bool T()
        {
            log.AddLog("T", getToken());

            if (SelectionSets.Check_F_Selection_Set(getToken().Value))
            {
                if (F())
                {
                    if (T1())
                        return true;                    
                }
            }
            else return true;

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
                        return true;
                    }
                }
            }
            else return true;

            return ReturnFalse("T1");
        }

        private static bool F()
        {
            log.AddLog("F", getToken());

            if (IsConstant())
            {
                return true;
            }
            else if (TokenIs("!"))
            {
                if (F()) return true;
            }
            else if (TokenIs_ID())
            {
                if (Ter9()) return true;
            }
            else if (IsIncDecOperator())
            {
                if (Ter10()) return true;
            } 
            else if (TokenIs("("))
            {
                if (Exp())
                {
                    if (TokenIs(")"))
                    {
                        return true;
                    }
                }
            }
            else if (TokenIs("new"))
            {
                if (TokenIs_ID())
                {
                    if (Fn_Call())
                    {
                        if (Follow_Dot_Chain())
                        {
                            if(TokenIs(";")) return true;
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
                                if (TokenIs(";")) return true;
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
                                if (TokenIs(";")) return true;
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

            

            if (SelectionSets.Check_Ter9_Selection_Set(getToken().Value))
            {
                if (Dot_Chain())
                {
                    return true;
                }
                else if (Fn_Call())
                {
                    if (Follow_Dot_Chain())
                        return true;
                }

            }            
            else return true;

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
                        return true;
                    }
                }
            }
            else if (TS())
            {
                if (Dot_Chain())
                {
                    return true;
                }
            }
            return ReturnFalse("Ter10");
        }

        private static bool Class_Def()
        {
            log.AddLog("Class_Def", getToken());

            if (Abs())
            {
                if (TokenIs("class"))
                {                    
                    if (TokenIs_ID())
                    {                        
                        if (Ter())
                        {
                            if (TokenIs("{"))
                            {                                
                                if (Class_Body())
                                {
                                    if (TokenIs("}"))
                                    {                                        
                                        return true;
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return ReturnFalse("Class_Def");
        }

        private static bool Ter()
        {
            log.AddLog("Ter", getToken());

            if (TokenIs("@"))
            {                
                if (TokenIs_ID())
                {                    
                    if (Ter11())
                    {
                        return true;
                    }
                }
            }
            else return true;
            return ReturnFalse("Ter");
        }

        private static bool Ter11()
        {
            log.AddLog("Ter11", getToken());

            if (TokenIs("applies"))
            {
                if (IDS())
                {
                    return true;
                }
            }
            else return true;
            return ReturnFalse("Ter11");
        }

        private static bool Class_Body()
        {
            log.AddLog("Class_Body", getToken());

            if (TokenIs("personal"))
            {
                if (Ter12())
                {
                    if (Class_Body()) return true;
                }
            }
            else if (TokenIs("general"))
            {
                if (Ter12())
                {
                    if (Class_Body()) return true;
                }
            }
            else if (TokenIs("abstract"))
            {
                if (Obj_Fn())
                {
                    if (Class_Body()) return true;
                }
            }
            else if (TokenIs_ID())
            {
                if (Ter13())
                {
                    if (Class_Body()) return true;
                }
            }
            else if (TokenIs_DT())
            {
                if (Ter14())
                {
                    if (Class_Body()) return true;
                }
            }
            else if (TokenIs("empty"))
            {
                if (TokenIs_ID())
                {
                    if (Cntr())
                    {
                        if (Class_Body()) return true;
                    }
                }
            }
            else return true;

            return ReturnFalse("Class_Body");
        }

        private static bool Obj_Fn()
        {
            log.AddLog("Obj_Fn", getToken());

            if (TokenIs_ID())
            {
                if (Ter23())
                {
                    if (Cntr()) return true;
                }
            }
            else if (TokenIs_DT())
            {
                if (Ter18())
                {
                    if (TokenIs_ID())
                    {                        
                        if (Cntr()) return true;
                    }
                }
            }
            else if (TokenIs("empty"))
            {
                if (TokenIs_ID())
                {                    
                    if(Cntr()) return true;
                }
            }

            return ReturnFalse("Obj_Fn");
        }


        private static bool Ter23()
        {
            log.AddLog("Ter23", getToken());

            if (TokenIs_ID())
            {                
                return true;
            }
            else if (TokenIs("["))
            {                
                if (Comma())
                {
                    if (TokenIs("]"))
                    {                        
                        if (TokenIs_ID())
                        {                            
                            return true;
                        }
                    }

                }
            }
            else return true;

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
                            return true;
                        }
                    }
                }
            }
            else return true;

            return ReturnFalse("Super");
        }

        private static bool Ter12()
        {
            log.AddLog("Ter12", getToken());

            if (TokenIs("abstract"))
            {                
                if (Obj_Fn())
                {
                    return true;
                }
            }
            else if (TokenIs_DT())
            {
                if (Ter17())
                {
                    return true;
                }
            }
            else if (TokenIs_ID())
            {
                if (Ter121())
                {
                    return true;
                }
            }
            else if (TokenIs("empty"))
            {   
                if (TokenIs_ID())
                {   
                    if(Cntr()) return true;
                }
            }

            return ReturnFalse("Ter12");
        }

        private static bool Ter121()
        {
            log.AddLog("Ter121", getToken());

            if (Ter7()) return true;
            else if (Cntr()) return true;

            return ReturnFalse("Ter121");
        }


        private static bool Cntr()
        {
            log.AddLog("Cntr", getToken());

            if (TokenIs("("))
            {   
                if (Input_Par())
                {
                    if (TokenIs(")"))
                    {                        
                        if (TokenIs("{"))
                        {                            
                            if (Super())
                            {
                                if (MST())
                                {
                                    if(TokenIs("}"))
                                    {                                        
                                        return true;
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return ReturnFalse("Cntr");
        }

        private static bool Ter13()
        {
            log.AddLog("Ter13", getToken());

            if (TokenIs_ID())
            {   
                if (Ter16())
                {
                    return true;
                }
            }
            else if (TokenIs("["))
            {                
                if (Comma())
                {
                    if (TokenIs("]"))
                    {
                        
                        if (TokenIs_ID())
                        {
                            
                            if (Ter15()) return true;
                        }
                    }
                }
            }
            else if (Cntr())
            {
                return true;
            }

            return ReturnFalse("Ter13");
        }

        private static bool Ter14()
        {
            log.AddLog("Ter14", getToken());

            if (TokenIs_ID())
            {
                
                if (Ter16())
                {
                    return true;
                }
            }
            else if (TokenIs("["))
            {                
                if (Comma())
                {
                    if (TokenIs("]"))
                    {                        
                        if (TokenIs_ID())
                        {                            
                            if (Ter15()) return true;
                        }
                    }
                }
            }

            return ReturnFalse("Ter14");
        }

        private static bool Ter15()
        {
            log.AddLog("Ter15", getToken());

            if (Cntr())
            {
                return true;
            }
            else if (G_Array_Def())
            {
                return true;
            }

            return ReturnFalse("Ter15");
        }

        private static bool Ter16()
        {
            log.AddLog("Ter16", getToken());

            if (Cntr())
            {
                return true;
            }
            else if (Dec())
            {
                return true;
            }

            return ReturnFalse("Ter16");
        }

        private static bool Ter17()
        {
            log.AddLog("Ter17", getToken());

            if (TokenIs_ID())
            {                
                if (Ter16())
                {
                    return true;
                }
            }
            else if (TokenIs("["))
            {
                
                if (Comma())
                {
                    if (TokenIs("]"))
                    {                        
                        if (TokenIs_ID())
                        {                            
                            if (Cntr()) return true;
                        }
                    }
                }
            }

            return ReturnFalse("Ter17");
        }

        private static bool Int_Def()
        {
            log.AddLog("Int_Def", getToken());

            if (TokenIs("group"))
            {                
                if (TokenIs_ID())
                {                    
                    if (Inherit())
                    {
                        if (TokenIs("{"))
                        {                            
                            if (Int_Body())
                            {
                                if (TokenIs("}"))
                                {                                    
                                    return true;
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
            log.AddLog("Inherit", getToken());

            if (TokenIs("applies"))
            {
                
                if (IDS())
                {
                    return true;
                }
            }
            else return true;

            return ReturnFalse("Inherit");
        }

        private static bool Int_Body()
        {
            log.AddLog("Int_Body", getToken());

            if (Int_Func())
            {
                return true;
            }
            else return true;
        }

        private static bool Int_Func()
        {
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
                                if (Input_Par())
                                {
                                    if (TokenIs(")"))
                                    {                                        
                                        if (TokenIs(";"))
                                        {                                            
                                            if (Int_Func())
                                            {
                                                return true;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            else return true;

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
            if (Utility.ThrowSyntaxError) throw new SyntaxError(getToken().LineNumber,getToken(),name);
            return false;
        }


        private static bool IsRelationalOperator()
        {
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
            //if (tokenList[i].Value == "$$$") throw new ArgumentOutOfRangeException("",i.ToString());
            return tokenList[i];
        }

        private static bool TokenIs(string match)
        {
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
            log.CheckTerminal("Checking for Identifier   result = " + (getToken().ClassName.Equals("Identifier")).ToString(), i);
            if (getToken().ClassName.Equals("Identifier"))
            {
                log.AddLOG("ID => "+ getToken().Value, false, getToken());
                i++;
                return true;
            }
            return false;
        }

        private static bool IsStringConstant()
        {
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
    }
}
