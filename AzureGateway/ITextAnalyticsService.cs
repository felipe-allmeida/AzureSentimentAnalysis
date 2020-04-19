using System.Threading.Tasks;

namespace AzureGateway
{
    public interface ITextAnalyticsService
    {
        Task DoSentimentAnalysis(string message);
    }
}
