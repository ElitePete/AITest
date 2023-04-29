using System;
using System.Threading.Tasks;
using OpenAI_API;

namespace OpenAI_Console
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var api = new OpenAIAPI("APIKEYHERE");

            var chat = api.Chat.CreateConversation();

            Console.WriteLine("Enter your message (type 'exit' to quit):");

            string userInput = Console.ReadLine();
            while (userInput.ToLower() != "exit")
            {
                // Send message to API for chat response
                chat.AppendUserInput(userInput);

                // Get response 
                string response = await chat.GetResponseFromChatbotAsync();

                // Print response 
                await PrintWithTypingEffect(response);

                // Prompt user for next message
                Console.WriteLine("Enter your message (type 'exit' to quit):");
                userInput = Console.ReadLine();
            }
        }

        static async Task PrintWithTypingEffect(string text, int delay = 50)
        {
            foreach (char c in text)
            {
                Console.Write(c);
                await Task.Delay(delay);
            }
            Console.WriteLine();
        }
    }
}
