using System.Text.Json;
using System;

using BYVAM0.Model;
using BYVAM0.Interfaces;

namespace BYVAM0.DataAccess
{
    internal class FileAccessor : IDataAccess
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
    }
}
