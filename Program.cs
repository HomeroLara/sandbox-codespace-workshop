using System;
using System.IO;
using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
// Expose the Swagger UI at the app's root to provide a landing page when opening from GitHub Codespaces.
// https://docs.microsoft.com/en-us/aspnet/core/tutorials/getting-started-with-swashbuckle?view=aspnetcore-6.0&tabs=visual-studio#add-and-configure-swagger-middleware
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("./swagger/v1/swagger.json", "v1");
    options.RoutePrefix = string.Empty;
});


app.UseHttpsRedirection();

// A simple hello
app.MapGet("/hello", () => hello());

// ASCII art
app.MapGet("/boxboat", () => ascii("boxboat"));
app.MapGet("/dwight", () => ascii("dwight")); 
app.MapGet("/tnt", () => ascii("tnt")); 
app.MapGet("/mtv", () => ascii("mtv")); 
app.MapGet("/azure", () => ascii("azure")); 
app.MapGet("/octocat", () => ascii("octocat")); 
app.MapGet("/ibm", () => ascii("ibm")); 
app.MapGet("/docker", () => ascii("docker")); 
app.MapGet("/k8s", () => ascii("k8s")); 
app.MapGet("/helm", () => ascii("helm")); 
app.MapGet("/tux", () => ascii("tux"));

app.Run();

string hello() {
  string message = "Hello World!";
  return message;
}

string ascii(string file) {
    string text = "";
    try {
        using (var sr = new StreamReader($"ascii/{file}")) {
            text = sr.ReadToEnd();
        }
    } catch (IOException e) {
        Console.WriteLine(e.Message);
    }

    return text;
}
