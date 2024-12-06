using BYVAM0.Model;

namespace BYVAM0.Interfaces
{
    public interface IDataAccess
    {
        List<Question>? GetQuestions(string filePath);
        bool WriteResults(string filePath, string htmlPage);
    }
}
