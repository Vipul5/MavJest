using OllamaSharp;

var uri = new Uri("http://localhost:11434");
var ollama = new OllamaApiClient(uri);

// select a model which should be used for further operations
ollama.SelectedModel = "phi3:mini";

var models = await ollama.ListLocalModels();

await foreach (var status in ollama.PullModel("phi3:mini"))
    Console.WriteLine($"{status.Percent}% {status.Status}");

Console.WriteLine("Server Connected. Ollama is Running and loaded.");

var chat = new Chat(ollama);

    var message1 = @"For the next statement, take example from output format:
1. Hindi";
await foreach (var answerToken in chat.Send(message1)) ;

    var message2 = @"Now I will provide you students report data, you have to just list subjects (without any justification, comments or description) 
where student need to work upon. Don't list subjects where students score more than 8. 
List only subjects where scorint is either effected on day, or there is no improvement seen.
\r\nThe data is:\r\n=>StudentId\t-\tDate\t- Seating \t\t\t-\tMath\t-\tEnglish\t-\tHindi\t-\tDescriptive Comment\r\n
=>1\t\t\t-\t16 Sep\t- Row 1 Column 1\t-\t9\t\t-\t7\t\t-\t4\t\t-\tVery proactive in class, need to concentrate more in Hindi.\r\n
=>1\t\t\t-\t17 Sep\t- Row 2 Column 1\t-\t10\t\t-\t8\t\t-\t6\t\t-\tVery proactive in class, can see improvement in all subjects.\r\n
=>1\t\t\t-\t18 Sep\t- Row 1\tColumn 2\t-\t9\t\t-\t10\t\t-\t2\t\t-\tVery proactive in class, need to work with letter having curves in hindi.";
await foreach (var answerToken in chat.Send(message2))
    Console.Write(answerToken);
