using BYVAM0.Model;

namespace BYVAM0.DataAccess
{
    internal interface IDataAccess
    {
        List<Question>? GetQuestions(string filePath);
    }
}
