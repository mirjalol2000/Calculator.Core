using Calculator.Core.Models.Users;
using System;
using System.Text.Json.Serialization;

namespace Calculator.Core.Models.Feedbacks
{
    public class Feedback
    {
        public Guid Id { get; set; }
        public string Answer { get; set; }

        public Guid UserId { get; set; }
        [JsonIgnore]
        public User User { get; set; }
    }
}
