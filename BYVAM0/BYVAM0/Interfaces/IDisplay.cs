using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BYVAM0.Interfaces
{
    internal interface IDisplay
    {
        public void GreetUser();

        public void DisplayQuestion(string question);

        public void WriteLine(string line);
    }
}
