using AzureGateway;
using System;
using System.Threading.Tasks;

namespace ConsoleApplication
{
    class Program
    {
        static async Task Main(string[] args)
        {
            ITextAnalyticsService service = new TextAnalyticsService();

            bool isRunning = true;

            while(isRunning)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("Type the message to be analyzed: ");
                Console.ForegroundColor = ConsoleColor.White;

                string message = Console.ReadLine();

                if (!string.IsNullOrEmpty(message) && message != "exit")
                {
                    await service.DoSentimentAnalysis(message);

                    Console.WriteLine("Press anything to continue...");
                    Console.ReadLine();
                    Console.Clear();
                }
                else
                {
                    isRunning = false;
                }
            }

        }
    }
}
