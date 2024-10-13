using ChatInteractionService.Database.Context;
using ChatInteractionService.Service;
using DataLayer.Repository;
using MavJest.Repository;
using MavJest.Service;

////insert the data
//using (var context = new MavJestContext())
//{
//    // Automatically create the database and tables if they do not exist
//    context.Database.EnsureCreated();

//    // Add Students
//    var student1 = new Student { Name = "Ayaan Khan", FatherName = "Sameer Khan", DateOfAdmission = DateTime.Now, ClassName = "Nursery" };
//    var student2 = new Student { Name = "Meera Singh", FatherName = "Raj Singh", DateOfAdmission = DateTime.Now, ClassName = "Prep" };

//    context.Students.Add(student1);
//    context.Students.Add(student2);

//    // Save changes to database
//    context.SaveChanges();

//    // Add ActivityHistory
//    var activity1 = new ActivityHistory { StudentId = student1.Id, Date = DateTime.Now, ActivityName = "Drawing", Description = "Coloring", Performance = "Excellent" };
//    var activity2 = new ActivityHistory { StudentId = student2.Id, Date = DateTime.Now, ActivityName = "Singing", Description = "Performed in class", Performance = "Good" };
//    var activity3 = new ActivityHistory { StudentId = student1.Id, Date = DateTime.Now, ActivityName = "Dancing", Description = "on Tauba tauba song", Performance = "Average" };

//    context.ActivityHistories.Add(activity1);
//    context.ActivityHistories.Add(activity2);
//    context.ActivityHistories.Add(activity3);

//    // Save changes to database
//    context.SaveChanges();
//}

//read the data

// Create a web application builder
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader());
});

// Register the GreetingService with the DI container
builder.Services.AddSingleton<IAcademicHistoryService, AcademicHistoryService>();
builder.Services.AddSingleton<IActivityService, ActivityService>();
builder.Services.AddSingleton<IActivityRepository, ActivityRepository>();
builder.Services.AddSingleton<IStudentRepository, StudentRepository>();
builder.Services.AddSingleton<IAcademicHistoryRepository, AcademicHistoryRepository>();
builder.Services.AddSingleton<IBehaviourService, BehaviourService>();
builder.Services.AddSingleton<IBehaviourRepository, BehaviourRepository>();
builder.Services.AddHostedService<BootstrapService>();

builder.Services.AddScoped<IStudentService, StudentService>();

// Add support for controllers
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Build the app
var app = builder.Build();


//using (var scope = app.Services.CreateScope())
//{
//    var chatService = scope.ServiceProvider.GetRequiredService<IChatService();

//    // Manually create an instance of the controller
//    var chatController = new ActivityController(chatService);

//    // Call the controller method directly
//    chatController.GetGroupsForActivity();
//    //Console.WriteLine(result.Value);  
//}

app.UseCors("AllowAll");
app.UseRouting();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1"));
}

app.MapControllers();
app.Run();

//var uri = new Uri("http://localhost:11434");
//var ollama = new OllamaApiClient(uri);

//// select a model which should be used for further operations
//ollama.SelectedModel = "phi3:mini";

//var models = await ollama.ListLocalModels();

//await foreach (var status in ollama.PullModel("phi3:mini"))
//    Console.WriteLine($"{status.Percent}% {status.Status}");

//Console.WriteLine("Server Connected. Ollama is Running and loaded.");

//var chat = new Chat(ollama, "You need to analyze following data and provide response for upcoming questions.");

//var data = File.ReadAllText("./data.json");
//var array = JsonSerializer.Deserialize<dynamic[]>(data);
//List<Message> messages = new List<Message>();
//Console.WriteLine("Reading Records...");
//for (var i = 0; i < array.Length; i++)
//{
//    string json = JsonSerializer.Serialize(array[i]);
//    messages.Add(new Message(ChatRole.System, json));
//    Console.WriteLine($"{i} - Record Loaded");
//}

//chat.SetMessages(messages);

//var message2 = @"Analyze the provided data for this question. Now you have to analyze and share with me what is a subject Advita needs to look into. The suggested subject (only one) should have usually less score than others, and also Advita do not show interest in doing the assignment of that subject.
//The output should only be JSON string in the following format, no extra comment should be provided:
//{""Subject"":""English""}";

//StringBuilder sb = new StringBuilder();
//await foreach (var answerToken in chat.SendAs(ChatRole.User, message2))
//    sb.Append(answerToken);

//sb.Replace("```json", string.Empty);
//sb.Replace("```", string.Empty);

//Console.WriteLine(sb.ToString());

//var result = JsonSerializer.Deserialize<dynamic>(sb.ToString());
//Console.ReadLine();

