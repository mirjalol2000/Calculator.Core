using Calculator.Core.Models.Users;
using System;
using System.Text.Json.Serialization;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Calculator.Core.Models.Calculations
{
    public class Calculation
    {
        [JsonIgnore]
        public Guid Id { get; set; }
        public decimal FirstNumber { get; set; }
        public decimal SecondNumber { get; set; }
        public Function Function { get; set; }

        [JsonIgnore]
        public string UserName { get; set; }

        [JsonIgnore]
        public Guid UserId { get; set; }
        [JsonIgnore]
        public User User { get; set; }

    }
}
