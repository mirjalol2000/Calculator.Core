using Calculator.Core.Models.Users;
using System.Linq;
using System.Threading.Tasks;
using System;
using Calculator.Core.Models.Feedbacks;

namespace Calculator.Core.Services.Foundations.Feedbacks
{
    public interface IFeedbackService
    {
        ValueTask<Feedback> AddFeedbackAsync(Feedback feedback);
        IQueryable<Feedback> RetrieveAllFeedbacks();
        
    }
}
