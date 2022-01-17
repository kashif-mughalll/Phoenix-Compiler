using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace phoenix_compiler.Semantic
{
    public class EntryDoesNotExist_InMainTable : Exception
    {

    }

    public class EntryDoesNotExist_InClassTable : Exception
    {

    }

    public class ReDeclarationError : Exception
    {
        public new string Message;
        public ReDeclarationError(string name, string type = "variable")
        {
            this.Message = type + "  ' " + name + " '  is already been declared. redeclaration not allowed";
        }
    }

    public class UndefinedError : Exception
    {
        public new string Message;
        public UndefinedError(string name)
        {
            this.Message = "variable  ' " + name + " '  not defined anywhere.";
        }
    }

    public class InheritanceError : Exception
    {
        public new string Message;

        public InheritanceError(string Childtype,string parentType)
        {
            this.Message = "Can't inherit entity of type  ' " + parentType + " '  into child of type  ' " + Childtype + " '.";
        }
    }

    public class InterfaceExpectedError : Exception
    {
        public new string Message;

        public InterfaceExpectedError(string Name)
        {
            this.Message = "Excepted an interface, entity  ' " + Name + " '  is not an interface";
        }
    }
    
    
    public class GeneralSemanticError : Exception
    {
        public new string Message;
        public GeneralSemanticError(string Message)
        {
            this.Message = Message;
        }
    }
}
