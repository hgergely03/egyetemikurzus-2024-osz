using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BYVAM0.Interfaces;

namespace BYVAM0.Controllers
{
    internal class ConsoleReader : IInputReader
    {
        public string? ReadLine()
        {
            return Console.ReadLine();
        }

        public ConsoleKeyInfo ReadKey()
        {
            return Console.ReadKey();
        }
    }
}
