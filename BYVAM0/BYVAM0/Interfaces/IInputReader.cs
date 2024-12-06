using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BYVAM0.Interfaces
{
    public interface IInputReader
    {
        string? ReadLine();
        ConsoleKeyInfo ReadKey();
    }
}
