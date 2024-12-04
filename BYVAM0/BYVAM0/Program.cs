using BYVAM0.Controllers;
using BYVAM0.DataAccess;
using BYVAM0.Interfaces;
using BYVAM0.Model;
using BYVAM0.Services;

// Initialize program
IDataAccess dataAccess = new FileAccessor();
string questionsFilePath = Path.Join(AppContext.BaseDirectory, "Assets", "questions.json");
var questions = dataAccess.GetQuestions(questionsFilePath);

IDisplay display = new ConsoleDisplay();

if (questions is null)
{
    display.WriteLine("The questions could not be loaded! Try restarting the program.");
    return;
}

display.GreetUser();

// Get answers from user
IInputReader inputReader = new ConsoleReader();
var inputController = new UserInputController(display, inputReader);
var answers = inputController.GetAnswers(questions);

// Before the results, display a cat fact
HttpClient httpClient = new()
{
    BaseAddress = new Uri("https://catfact.ninja"),
};

IFactService factService = new FactService(httpClient);
await display.DisplayCatFact(factService.GetCatFact());

// Calculate and display results
Result result = ResultCalculator.CalculateResult(answers);
display.DisplayResult(result);

// Write results to html file, display path
HtmlCreator htmlCreator = new(dataAccess);
bool writeResult = htmlCreator.CreateHtmlPage(result);

display.EndProgram(writeResult, htmlCreator.FilePath);

inputReader.ReadKey();