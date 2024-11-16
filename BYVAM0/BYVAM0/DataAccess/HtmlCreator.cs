using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BYVAM0.Extensions;
using BYVAM0.Interfaces;
using BYVAM0.Model;

namespace BYVAM0.DataAccess
{
    internal class HtmlCreator
    {
        private readonly IDataAccess _fileAccessor;
        public string FilePath { get; init; }

        public HtmlCreator(IDataAccess fileAccessor)
        {
            _fileAccessor = fileAccessor;
            FilePath = Path.Join(AppContext.BaseDirectory, "Assets", "results.html");
        }

        private static string CreateHtmlMarkup(Result result)
        {
            string htmlPage = $@"<!DOCTYPE html>
                                <html lang=""en"">
                                <head>
                                    <meta charset=""UTF-8"">
                                    <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
                                    <title>Your FeliScope Results</title>
                                    <link rel=""stylesheet"" href=""./style.css"">
                                </head>
                                <body>
                                    <h1>Review your FelisCope results!</h1>
                                    <p id=""description"">{result.Description}</p>
                                    <p id=""result"">
                                        You are a 
                                        <span class=""bold-text"">
                                            {result.Cat.LowerCat()}
                                        </span> 
                                        cat
                                    </p>
                                    <img src=""{result.Cat.GetCatImgPath()}"" alt=""{result.Cat} cat image"">
                                    <a href=""https://www.youtube.com/watch?v=3dgQcSn9wAs"">
                                        Take a look at how a cat works!
                                    </a>
                                </body>
                                </html>";

            return htmlPage;
        }

        public bool CreateHtmlPage(Result result)
        {
            string htmlPage = CreateHtmlMarkup(result);
            bool writeResult = _fileAccessor.WriteResults(FilePath, htmlPage);
            
            return writeResult;
        }
    }
}
