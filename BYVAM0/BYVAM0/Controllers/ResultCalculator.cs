using System.Numerics;
using System.Text;
using BYVAM0.Model;

namespace BYVAM0.Controllers
{
    public static class ResultCalculator
    {
        private static int NormalizeAnswer(int answer)
        {
            return answer switch
            {
                1 => 0,
                >= 2 and <= 3 => 1,
                >= 4 and <= 6 => 2,
                >= 7 and <= 8 => 4,
                >= 9 => 8,
                _ => 0
            };
        }

        private static Cat CalculateCatType(List<int> answers)
        {
            int calculation = answers.Sum(n => NormalizeAnswer(Math.Clamp(n, 1, 10)));
            calculation /= answers.Count;
            // Get the power of two that is closest to the result
            var result = BitOperations.RoundUpToPowerOf2(Convert.ToUInt32(calculation));
            Cat cat = (Cat)result;

            return cat;
        }

        private static string GetDescription(List<int> answers)
        {
            // Define the necessary metrics
            int numberOfLargeAnswers = answers.Where(n => n > 7).Count();
            bool nineAnswerExists = answers.Any(n => n == 9);
            int largestDifference = answers.Max() - answers.Min();
            var description = new StringBuilder();

            description.Append(
                nineAnswerExists 
                ? "You may have been a cat in your last 9 lives. " 
                : $"You still have {Math.Min(answers.Max(), 8)} cat lives remaining. "
                );

            description.Append(
                numberOfLargeAnswers > answers.Count / 2 
                ? "You also deal in absolutes. " 
                : "You are also well-balanced. "
                );

            description.Append(
                largestDifference > 5
                ? "Meanwhile chaos follows your every step, like pushing down objects from the shelf. " 
                : "Meanwhile you know how to behave and not wreak havoc. "
                );

            return description.ToString();
        }

        public static Result CalculateResult(List<int> answers)
        {
            Cat cat = CalculateCatType(answers);
            string description = GetDescription(answers);

            Result result = new()
            {
                Cat = cat,
                Description = description
            };

            return result;
        }
    }
}
