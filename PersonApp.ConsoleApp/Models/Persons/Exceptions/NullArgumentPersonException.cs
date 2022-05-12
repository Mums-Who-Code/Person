using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xeptions;

namespace PersonApp.ConsoleApp.Models.Persons.Exceptions
{
    public class NullArgumentPersonException : Xeption
    {
        public NullArgumentPersonException(Exception innerException)
            : base(message: "Null argument person error  occurred, fix the errors and try again.",
                  innerException)
        { }
    }
}
