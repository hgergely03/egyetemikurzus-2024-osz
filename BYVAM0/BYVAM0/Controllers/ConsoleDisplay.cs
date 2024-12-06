using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BYVAM0.Extensions;
using BYVAM0.Interfaces;
using BYVAM0.Model;

namespace BYVAM0.Controllers
{
    internal class ConsoleDisplay : IDisplay
    {
        public void GreetUser()
        {
            Console.WriteLine("Welcome to FeliScope! Let's see what kind of cat you are :3");
            Console.WriteLine(new string('-', 10));
        }

        public void DisplayQuestion(string question)
        {
            Console.WriteLine();
            Console.WriteLine($"How true is the following for you " +
                              $"on a scale from 1 (not true) to 10 (very true):");
            Console.WriteLine(question);
        }

        public void WriteLine(string line)
        {
            Console.WriteLine(line);
        }

        public async Task DisplayCatFact(Task<string> fact)
        {
            Console.WriteLine("Good job answering all those questions! " +
                "Enjoy a cat fact while we crunch the numbers based on your answers...");

            Console.WriteLine(await fact);
        }

        public void DisplayResult(Result result)
        {
            Console.WriteLine(result.Description);
            Console.WriteLine($"You are a(n) {result.Cat.LowerCat()} cat");
        }

        public void EndProgram(bool htmlCreationSuccessful, string filePath)
        {
            if (htmlCreationSuccessful)
            {
                /* This isn't pretty but it displays a clickable link to the path
                 * (at least in Powershell). It has a fallback, so if the
                 * console does not support links, it only displays the text
                 * so the user can copy-paste it.
                 */
                string link = $"\u001B]8;;{filePath}\a{filePath}\u001B]8;;\a";
                Console.WriteLine($"You can find your prettified results in");
                Console.WriteLine(link);
            }

            Console.WriteLine("Hope you enjoyed this feline test! Press any key to exit the program.");
        }
    }
}
