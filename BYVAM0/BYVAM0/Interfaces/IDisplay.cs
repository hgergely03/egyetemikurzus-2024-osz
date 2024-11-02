using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BYVAM0.Interfaces
{
    internal interface IDisplay
    {
        void GreetUser();

        void DisplayQuestion(string question);

        Task DisplayCatFact(Task<string> fact);

        void EndProgram();

        void WriteLine(string line);
    }
}
