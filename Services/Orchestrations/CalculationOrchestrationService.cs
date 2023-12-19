using Calculator.Core.Models.Calculations;
using Calculator.Core.Services.Processings.Calculations;
using Calculator.Core.Services.Processings.Feedbacks;
using Calculator.Core.Services.Processings.Users;
using System.Threading.Tasks;

namespace Calculator.Core.Services.Orchestrations
{
    public class CalculationOrchestrationService : ICalculationOrchestrationService
    {
        private readonly IUserProcessingService userProcessingService;
        private readonly ICalculationProcessingService calculationProcessingService;
        private readonly IFeedbackProcessingService feedbackProcessingService;

        public CalculationOrchestrationService(
            IUserProcessingService userProcessingService,
            ICalculationProcessingService calculationProcessingService,
            IFeedbackProcessingService feedbackProcessingService)
        {
            this.userProcessingService = userProcessingService;
            this.calculationProcessingService = calculationProcessingService;
            this.feedbackProcessingService = feedbackProcessingService;
        }

        public async ValueTask<string> ManageAllFunctions(string userName, Calculation calculation)
        {
            var user = this.userProcessingService.RetrieveUserByName(userName);

            var feedback = await this.calculationProcessingService.Calculate(calculation, user);

            await this.feedbackProcessingService.AddFeedbackAsync(feedback, user.Id);

            return feedback;
        }
    }
}
