using Calculator.Core.Models.Users;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using System;
using Calculator.Core.Models.Feedbacks;

namespace Calculator.Core.Brokers.Storages
{
    public partial class StorageBroker
    {
        public DbSet<Feedback> Feedbacks { get; set; }

        public async ValueTask<Feedback> InsertFeedbackAsync(Feedback feedback) =>
            await InsertAsync(feedback);


        public IQueryable<Feedback> SelectAllFeedbacks() =>
            SelectAll<Feedback>();


        public async ValueTask<Feedback> SelectFeedbackByIdAsync(Guid userId) =>
            await SelectAsync<Feedback>(userId);


        public async ValueTask<Feedback> UpdateFeedbackAsync(Feedback feedback) =>
            await UpdateAsync(feedback);


        public async ValueTask<Feedback> DeletedFeedbackAsync(Feedback feedback) =>
            await DeleteAsync(feedback);
    }
}
