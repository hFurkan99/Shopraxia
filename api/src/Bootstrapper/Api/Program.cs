// Add services to the container.
var builder = WebApplication.CreateBuilder(args);
builder.AddServiceDefaults();

// Configure the HTTP request pipeline.
var app = builder.Build();
app.MapDefaultEndpoints();
app.Run();
