
using BYVAM0.Interfaces;

namespace BYVAM0_tests.Mocks
{
    public class MockReader : IInputReader
    {
        private readonly string _input;

        public MockReader(string input)
        {
            _input = input;
        }

        public ConsoleKeyInfo ReadKey()
        {
            return new ConsoleKeyInfo(char.Parse(ConsoleKey.Enter.ToString()), ConsoleKey.Enter, false, false, false); ;
        }

        public string? ReadLine()
        {
            return _input;
        }
    }
}
