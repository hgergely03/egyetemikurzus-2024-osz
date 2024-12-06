using BYVAM0.Controllers;
using BYVAM0.Model;

using BYVAM0_tests.Mocks;

namespace BYVAM0_tests
{
    public class ControllerTests
    {
        private readonly List<Question> _testQuestions = [
                new Question() {
                    Text = "question 1",
                    Weight = 1,
                },
                new Question() {
                    Text = "question 2",
                    Weight = 1,
                },
            ];

        [Test]
        public void GetAnswers_CorrectInput_ReturnsAnswers()
        {
            UserInputController controller = new(new MockDisplay(), new MockReader("1"));
            var answers = controller.GetAnswers(_testQuestions);
            List<int> expected = [1, 1];

            CollectionAssert.AreEqual(answers, expected);
        }

        [Test]
        public void GetAnswers_CorrectInputWithWeights_ReturnsAnswers()
        {
            var newQuestions = _testQuestions.Append(new Question()
            {
                Text = "question 3",
                Weight = 2,
            }).ToList();
            UserInputController controller = new(new MockDisplay(), new MockReader("1"));
            var answers = controller.GetAnswers(newQuestions);
            List<int> expected = [1, 1, 2];

            CollectionAssert.AreEqual(answers, expected);
        }

        [Test]
        public void CalculateResult_ReturnsTabby()
        {
            List<int> answers = [1, 1, 1];
            Result result = ResultCalculator.CalculateResult(answers);

            Assert.That(result.Cat, Is.EqualTo(Cat.Tabby));
        }

        [Test]
        public void CalculateResult_ReturnsOrange()
        {
            List<int> weightedAnswers = [5, 10, 40, 20, 10];
            Result result = ResultCalculator.CalculateResult(weightedAnswers);

            Assert.That(result.Cat, Is.EqualTo(Cat.Orange));
        }
    }
}