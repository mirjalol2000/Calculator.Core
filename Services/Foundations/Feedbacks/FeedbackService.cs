using Calculator.Core.Brokers.Storages;
using Calculator.Core.Models.Users;
using System.Linq;
using System.Threading.Tasks;
using System;
using Calculator.Core.Models.Feedbacks;

namespace Calculator.Core.Services.Foundations.Feedbacks
{
    public class FeedbackService : IFeedbackService
    {
        private readonly IStorageBroker storageBroker;

        public FeedbackService(IStorageBroker storageBroker)
        {
            this.storageBroker = storageBroker;
        }

        public async ValueTask<Feedback> AddFeedbackAsync(Feedback feedback) =>
            await this.storageBroker.InsertFeedbackAsync(feedback);

        public async ValueTask<Feedback> ModifyFeedbackAsync(Feedback feedback) =>
            await this.storageBroker.UpdateFeedbackAsync(feedback);


        public async ValueTask<Feedback> RemoveFeedbackAsync(Guid feedbackId)
        {
            var feedback = await this.storageBroker.SelectFeedbackByIdAsync(feedbackId);

            return await this.storageBroker.DeletedFeedbackAsync(feedback);
        }


        public IQueryable<Feedback> ReterieveAllFeedbacks() =>
            this.storageBroker.SelectAllFeedbacks();


        public async ValueTask<Feedback> RetrieveFeedbackByIdAsync(Guid feedbackId) =>
            await this.storageBroker.SelectFeedbackByIdAsync(feedbackId);
    }
}
