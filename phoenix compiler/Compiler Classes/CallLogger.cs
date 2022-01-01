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

        public CallLogger(bool tokenTracking)
        {
            FilePath = Path + "logFile.txt";
            serialFile = Path + "serialFile.txt";
            TokenTracking = tokenTracking;
            File.WriteAllText(FilePath, "");
            File.WriteAllText(serialFile, "");
        }
        public CallLogger()
        {
            File.WriteAllText(FilePath, "");
            File.WriteAllText(serialFile, "");
        }

        public void AddLog(string funcName,Token T)
        {
            AddLOG(funcName, true, T);
            string _append = "\n" + "Calling Function : " + funcName + "\n";
            //if (TokenTracking) _append += T.ToString();
            File.AppendAllText(FilePath, _append);
        }

        public void AddLOG(string data,bool B,Token T)   // true : non terminal       else false
        {
            if (StopSerial) return;
            string _append = "";
            if (B)
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
            if(Utility.StopAtFalse) StopSerial = true;
        }


        public void ChainBreak(string funcName, Token T, int i)
        {
            string _append = "\n" + "False Return at : " + funcName + "  i:" + i + "\n";
            //_append += T.ToString();
            File.AppendAllText(FilePath, _append);
        }

        public void CheckTerminal(string funcName, int i)
        {
            string _append = "\n" + "Checking for Token : " + funcName + "    i : " + i + "\n";
            File.AppendAllText(FilePath, _append);
        }
    }
}
