using Calculator.Core.Models.Users;
using System.Linq;
using System.Threading.Tasks;
using System;
using Calculator.Core.Models.Feedbacks;

namespace Calculator.Core.Brokers.Storages
{
    public partial interface IStorageBroker
    {
        ValueTask<Feedback> InsertFeedbackAsync(Feedback feedback);
        IQueryable<Feedback> SelectAllFeedbacks();
        ValueTask<Feedback> SelectFeedbackByIdAsync(Guid userId);
        ValueTask<Feedback> UpdateFeedbackAsync(Feedback feedback);
        ValueTask<Feedback> DeletedFeedbackAsync(Feedback feedback);
    }
}
