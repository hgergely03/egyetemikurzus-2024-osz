using System.Text.Json;
using BYVAM0.Model;
using BYVAM0.Interfaces;

namespace BYVAM0.DataAccess
{
    public class FileAccessor : IDataAccess
    {
        private static readonly JsonSerializerOptions Options = new()
        {
            PropertyNameCaseInsensitive = true,
        };

        public List<Question>? GetQuestions(string filePath)
        {
            try
            {
                using var stream = File.OpenRead(filePath);
                var questions = JsonSerializer.Deserialize<List<Question>>(stream, Options);

                return questions;
            }
            catch (Exception ex) when (ex is FileNotFoundException
                                       || ex is DirectoryNotFoundException)
            {
                return null;
            }
        }

        public bool WriteResults(string filePath, string htmlPage)
        {
            try
            {
                File.WriteAllText(filePath, htmlPage);
                return true;
            }
            catch (Exception ex) when (ex is DirectoryNotFoundException
                                       || ex is UnauthorizedAccessException)
            {
                return false;
            }
        }
    }
}
