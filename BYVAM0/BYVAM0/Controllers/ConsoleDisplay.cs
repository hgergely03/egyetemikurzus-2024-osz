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
            Console.WriteLine("Welcome to the program!");
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
    }
}
