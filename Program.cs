var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
app.MapGet("/", () => "StormSafe API running");
app.Run();