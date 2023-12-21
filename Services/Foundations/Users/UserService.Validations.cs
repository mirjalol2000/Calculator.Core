using Calculator.Core.Models.Users;
using Calculator.Core.Models.Users.Exceptions;
using System;
using System.Data;
using System.Reflection.Metadata;
using System.Text.RegularExpressions;

namespace Calculator.Core.Services.Foundations.Users
{
    public partial class UserService
    {
        private void ValidateUser(User user)
        {
            ValidateUserNotNull(user);

            Validate(
                (Rule: IsInvalid(user.Id), Parameter: nameof(User.Id)),
                (Rule: IsInvalid(user.FirstName), Parameter: nameof(User.FirstName)),
                (Rule: IsInvalid(user.LastName), Parameter: nameof(User.LastName)),
                (Rule: IsInvalid(user.Age), Parameter: nameof(User.Age)),
                (Rule: IsInvalidEmail(user.Email), Parameter: nameof(User.Email)));
              

        }

        private static void ValidateUserNotNull(User user)
        {
            if (user == null)
            {
                throw new NullUserException();
            }
        }

        private static dynamic IsInvalid(Guid userId) => new
        {
            Condition = userId == default,
            Message = "Id is required.",
        };

        private static dynamic IsInvalid(string text) => new
        {
            Condition = string.IsNullOrWhiteSpace(text),
            Message = "Text is required.",
        };

        private static dynamic IsInvalid(int age) => new
        {
            Condition = age <=12,
            Message = "You are still small."
        };

        private static dynamic IsInvalidEmail(string email) => new
        {
            Condition = new Regex($"^\\S+@\\S+\\.\\S+$"),
            Message = "Email is invalid."
        }; 

        private static void Validate(params (dynamic Rule, string Parameter)[] validations)
        {
            var invalidUserException = new InvalidUserException();

            foreach((dynamic rule, string parameter)in validations)
            {
                if (rule.Condition)
                {
                    invalidUserException.UpsertDataList(
                        key: parameter,
                        value: rule.Message);
                }
            }

            invalidUserException.ThrowIfContainsErrors();
        }
    }
}
