using WebApplication2.Middleware;
using WebApplication2.Services;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<IDetectBrowseService, DetectChrome>();
builder.Services.AddSingleton<IDetectBrowseService, DetectOpera>();
builder.Services.AddSingleton<IDetectBrowseService, DetectFireFox>();
builder.Services.AddSingleton<IDetectBrowseService, DetectOtherBrowsers>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseMiddleware<DetectBrowserMiddleware>();


app.Run();
