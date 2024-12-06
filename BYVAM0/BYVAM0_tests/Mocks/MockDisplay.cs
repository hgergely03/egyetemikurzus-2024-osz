using BYVAM0.Interfaces;
using BYVAM0.Model;

namespace BYVAM0_tests.Mocks
{
    public class MockDisplay : IDisplay
    {
        public Task DisplayCatFact(Task<string> fact)
        {
            return Task.CompletedTask;
        }

        public void DisplayQuestion(string question)
        {
            return;
        }

        public void DisplayResult(Result result)
        {
            return;
        }

        public void EndProgram(bool htmlCreationSuccessful, string filePath)
        {
            return;
        }

        public void GreetUser()
        {
            return;
        }

        public void WriteLine(string line)
        {
            return;
        }
    }
}
