using Calculator.Core.Models.Feedbacks;
using Calculator.Core.Services.Processings.Feedbacks;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Calculator.Core.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FeedbackController : Controller
    {
        private readonly IFeedbackProcessingService feedbackProcessingService;

        public FeedbackController(IFeedbackProcessingService feedbackProcessingService)
        {
            this.feedbackProcessingService = feedbackProcessingService;
        }

        [HttpGet]
        public ActionResult<IQueryable<Feedback>> GetFeedbacks()
        {
            var feedbacks = this.feedbackProcessingService.RetrieveAllFeedbacks();

            return Ok(feedbacks);
        }
    }
}
