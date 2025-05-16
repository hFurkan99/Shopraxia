// Add services to the container.
var builder = WebApplication.CreateBuilder(args);

builder.Host
    .UseSerilog((context, config) =>
    config.ReadFrom.Configuration(context.Configuration));

var catalogAssembly = typeof(CatalogModule).Assembly;

builder.Services
    .AddCarterWithAssemblies(catalogAssembly);

builder.Services
    .AddMediatRWithAssemblies(catalogAssembly);

builder.Services
    .AddCatalogModule(builder.Configuration);

builder.Services
    .AddExceptionHandler<CustomExceptionHandler>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// Configure the HTTP request pipeline.
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapCarter();
app.UseSerilogRequestLogging();
app.UseExceptionHandler(options => { });
app.UseCatalogModule();

app.Run();
