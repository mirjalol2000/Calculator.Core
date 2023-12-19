using Calculator.Core.Models.Feedbacks;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Calculator.Core.Services.Processings.Feedbacks
{
    public interface IFeedbackProcessingService
    {
        ValueTask<Feedback> AddFeedbackAsync(string answer, Guid userId);
        IQueryable<Feedback> RetrieveAllFeedbacks();
    }
}
