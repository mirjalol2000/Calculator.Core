using Calculator.Core.Models.Users;
using System;
using System.Text.Json.Serialization;

namespace Calculator.Core.Models.Calculations
{
    public class Calculation
    {
        public Guid Id { get; set; }
        public decimal FirstNumber { get; set; }
        public decimal secondNumber { get; set; }
        public string Function { get; set; }

        public Guid UserId { get; set; }
        [JsonIgnore]
        public User User { get; set; }

    }
}
