using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BYVAM0.Interfaces;

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
            Console.WriteLine($"How true is the following for you " +
                              $"on a scale from 1 (not true) to 10 (very true):{Environment.NewLine}" +
                              $"{question}");
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

        public void EndProgram()
        {
            Console.WriteLine("Hope you enjoyed this feline test! Press any key to exit the program.");
        }
    }
}
