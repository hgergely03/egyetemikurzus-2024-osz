using BYVAM0.Interfaces;
using BYVAM0.Model;

namespace BYVAM0.Controllers
{
    public class UserInputController
    {
        private const int MIN_ANSWER = 0;
        private const int MAX_ANSWER = 10;
        private readonly IDisplay _display;
        private readonly IInputReader _inputReader;

        public UserInputController(IDisplay display, IInputReader inputReader)
        {
            _display = display;
            _inputReader = inputReader;
        }

        private static string? ValidateUserInput(string? input)
            => input switch
            {
                _ when string.IsNullOrWhiteSpace(input) 
                        => $"Please enter a number between {MIN_ANSWER} and {MAX_ANSWER}",
                _ when !int.TryParse(input, out int result) 
                        => "Please enter a valid number",
                _ when int.Parse(input) < MIN_ANSWER || int.Parse(input) > MAX_ANSWER
                        => $"Please enter a number between {MIN_ANSWER} and {MAX_ANSWER}",
                _ => null
            };

        private int ReadAnswer()
        {
            string? input = _inputReader.ReadLine();
            string? errorMessage = ValidateUserInput(input);

            while (errorMessage is not null) {
                _display.WriteLine(errorMessage);
                input = _inputReader.ReadLine();
                errorMessage = ValidateUserInput(input);
            }

            int answer = int.Parse(input!);

            return answer;
        }

        public List<int> GetAnswers(List<Question> questions)
        {
            List<int> answers = [];
            foreach (var question in questions)
            {
                _display.DisplayQuestion(question.Text);
                answers.Add(ReadAnswer() * question.Weight);
            }

            return answers;
        }
    }
}
