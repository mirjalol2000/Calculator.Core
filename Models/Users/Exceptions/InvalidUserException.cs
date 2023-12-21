using Xeptions;

namespace Calculator.Core.Models.Users.Exceptions
{
    public class InvalidUserException :Xeption
    {
        public InvalidUserException()
            :base(message: "User is invalid.")
        {
        }
    }
}
