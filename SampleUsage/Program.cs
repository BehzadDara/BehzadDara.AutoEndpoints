using BehzadDara.AutoEndpoints;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

var projectName = "SampleUsage"; // Name of project where Enums are located

var assembly = AppDomain.CurrentDomain.GetAssemblies()
    .FirstOrDefault(a => a.GetName().Name == projectName)
    ?? throw new ArgumentException($"Assembly with project name '{projectName}' not found.");

app.UsingEnumEndpoints(assembly);

app.Run();
