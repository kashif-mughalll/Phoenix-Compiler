using Compiler_Pheonix;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace phoenix_compiler
{

    class CallLogger
    {
        private string Path = Directory.GetCurrentDirectory() + @"\";
        private string FilePath = "";
        private string serialFile = "";
        private bool TokenTracking = false;
        private bool StopSerial = false;
        private List<string> CheckList;
        private bool DisableTracking = false;

        public CallLogger(bool tokenTracking)
        {
            FilePath = Path + "logFile.txt";
            serialFile = Path + "serialFile.txt";
            TokenTracking = tokenTracking;
            File.WriteAllText(FilePath, "");
            File.WriteAllText(serialFile, "");
            CheckList = new List<string>();
        }
        public CallLogger()
        {
            FilePath = Path + "logFile.txt";
            serialFile = Path + "serialFile.txt";
            File.WriteAllText(FilePath, "");
            File.WriteAllText(serialFile, "");            
            CheckList = new List<string>();
        }

        public void AddLog(string funcName,Token T)
        {
            if (DisableTracking) return;
            AddLOG(funcName, true, T);
            string _append = "\n" + "Calling Function : " + funcName + "\n";
            //if (TokenTracking) _append += T.ToString();
            File.AppendAllText(FilePath, _append);
        }

        public void AddLOG(string data,bool B,Token T)   // true : non terminal       else false
        {
            if (DisableTracking) return;
            if (StopSerial) return;
            string _append = "";
            if (data.Equals("__backTrackTree__#"))
            {
                _append += "Back-Track : " + "\n";
            }
            else if (B)
            {
                _append += "Non-Terminal : " + data + ":" + T.GenerateStr() + "\n";
            }
            else
            {
                _append += "Terminal : " + data + ":" + T.GenerateStr() + "\n";
            }
            File.AppendAllText(serialFile, _append);
        }

        public void StopSerialFile()
        {
            if (DisableTracking) return;
            if (DisableTracking) return;
            if (Utility.StopAtFalse) StopSerial = true;
        }


        public void ChainBreak(string funcName, Token T, int i)
        {
            if (DisableTracking) return;
            string _append = "\n" + "False Return at : " + funcName + "  i:" + i + "\n";
            //_append += T.ToString();
            File.AppendAllText(FilePath, _append);
        }

        public void CheckTerminal(string funcName, int i)
        {
            if (DisableTracking) return;
            string _append = "\n" + "Checking for Token : " + funcName + "    i : " + i + "\n";
            File.AppendAllText(FilePath, _append);
        }

        public void maintainHintStructure(string check)
        {
            if (DisableTracking) return;
            CheckList.Add(check);
        }

        public string GetHint()
        {
            if (DisableTracking) return null;

            if(CheckList.Count > 0)
            {
                if(CheckList.Count > 1)
                {
                    return "[Syntax Hint] Expected  \" " + CheckList[CheckList.Count - 1] + " \"  after " + CheckList[CheckList.Count - 2];
                }
                return "[Syntax Hint] Expected  \" " + CheckList[CheckList.Count - 1] + " \"";
            }
            return "[Syntax Hint] Expected tokens with language specifications";
        }

        public void setDisableTracking(bool DisableTracking)
        {
            this.DisableTracking = DisableTracking;
        }
    }
}
