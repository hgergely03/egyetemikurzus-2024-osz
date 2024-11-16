using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BYVAM0.Model;

namespace BYVAM0.Interfaces
{
    internal interface IDisplay
    {
        void GreetUser();
        void DisplayQuestion(string question);
        Task DisplayCatFact(Task<string> fact);
        void WriteLine(string line);
        void DisplayResult(Result result);
        void EndProgram(bool htmlCreationSuccessful, string filePath);
    }
}
