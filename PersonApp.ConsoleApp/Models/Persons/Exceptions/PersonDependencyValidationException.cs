using Xeptions;

namespace PersonApp.ConsoleApp.Models.Persons.Exceptions
{
    public class PersonDependencyValidationException : Xeption
    {
        public PersonDependencyValidationException(Xeption innerException)
            : base(message: "Person dependency validation error occurred, fix and try again",
                  innerException)
        { }
    }
}