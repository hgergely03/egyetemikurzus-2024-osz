using BYVAM0.DataAccess;
using BYVAM0.Interfaces;
using BYVAM0.Model;


namespace BYVAM0_tests
{
    public class DataAccessTests
    {
        [Test]
        public void GetQuestions_FileDoesNotExist_ReturnsNull()
        {
            string questionsFilePath = Path.Join(AppContext.BaseDirectory, "Assets", "questiöns.json");
            IDataAccess fileAccessor = new FileAccessor();

            var questions = fileAccessor.GetQuestions(questionsFilePath);

            Assert.That(questions, Is.Null);
        }

        [Test]
        public void GetQuestions_FileExists_ReturnsQuestions()
        {
            string questionsFilePath = Path.Join(AppContext.BaseDirectory, "Assets", "questions.json");
            IDataAccess fileAccessor = new FileAccessor();

            var questions = fileAccessor.GetQuestions(questionsFilePath);
            List<Question> testQuestions = [
                new Question() {
                    Text = "question 1",
                    Weight = 1,
                },
                new Question() {
                    Text = "question 2",
                    Weight = 2,
                },
            ];

            CollectionAssert.AreEqual(testQuestions, questions);
        }
    }
}
