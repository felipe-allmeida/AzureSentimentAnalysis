using Azure;
using Azure.AI.TextAnalytics;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;

namespace AzureGateway
{
    /// <summary>
    /// You can check how to configure the Azure Cognitive Services in the below link!
    /// https://docs.microsoft.com/en-us/azure/cognitive-services/text-analytics/quickstarts/text-analytics-sdk?tabs=version-3&pivots=programming-language-csharp
    /// </summary>
    public class TextAnalyticsService : ITextAnalyticsService
    {
        private readonly AzureKeyCredential _azureKeyCredential = new AzureKeyCredential("your_azure_key_credential");
        private readonly Uri _endpoint = new Uri("your_azure_cognitive_services_endpoint");

        private readonly TextAnalyticsClient _client;

        public TextAnalyticsService()
        {
            _client = new TextAnalyticsClient(_endpoint, _azureKeyCredential);
        }

        public async Task DoSentimentAnalysis(string message)
        {
            DocumentSentiment documentSentiment = await _client.AnalyzeSentimentAsync(message);

            Console.WriteLine($"Document sentiment: { documentSentiment.Sentiment }\n");

            var stringInfo = new StringInfo(message);
            foreach(var sentence in documentSentiment.Sentences)
            {
                Console.WriteLine($"\tSentence [length {sentence.GraphemeLength}]");
                Console.WriteLine($"\tText: \"{stringInfo.SubstringByTextElements(sentence.GraphemeOffset, sentence.GraphemeLength)}\"");
                Console.WriteLine($"\tSentence sentiment: {sentence.Sentiment}");
                Console.WriteLine($"\tPositive score: {sentence.ConfidenceScores.Positive:0.00}");
                Console.WriteLine($"\tNegative score: {sentence.ConfidenceScores.Negative:0.00}");
                Console.WriteLine($"\tNeutral score: {sentence.ConfidenceScores.Neutral:0.00}\n");
            }
        }
    }
}
