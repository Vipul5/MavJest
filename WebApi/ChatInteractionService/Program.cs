using ChatInteractionService.Model;
using ChatInteractionService.Service;
using DataLayer.Repository;
using MavJest.Repository;
using MavJest.Service;

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
builder.Services.AddSingleton<ChatServerModel>(new ChatServerModel
{
    ChatServerUri = "http://localhost:11434/api",
    AIModel = "phi3:mini"
});
builder.Services.AddScoped<IAcademicHistoryService, AcademicHistoryService>();
//builder.Services.AddSingleton<IActivityService, ActivityService>();
builder.Services.AddScoped<IActivityRepository, ActivityRepository>();
builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<IAcademicHistoryRepository, AcademicHistoryRepository>();
//builder.Services.AddSingleton<IBehaviourService, BehaviourService>();
builder.Services.AddScoped<IBehaviourRepository, BehaviourRepository>();
builder.Services.AddHostedService<BootstrapService>();

//builder.Services.AddScoped<IStudentService, StudentService>();

// Add support for controllers
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Build the app
var app = builder.Build();

app.UseCors("AllowAll");
app.UseRouting();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1"));
}

app.MapControllers();
app.Run();
