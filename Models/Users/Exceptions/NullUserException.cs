using Xeptions;

namespace Calculator.Core.Models.Users.Exceptions
{
    public class NullUserException : Xeption
    {
        public NullUserException()
            : base (message : "User is null.")
        {
        }
    }
}
