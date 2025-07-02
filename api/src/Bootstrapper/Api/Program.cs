// Add services to the container.
var builder = WebApplication.CreateBuilder(args);

builder.Host
    .UseSerilog((context, config) =>
    config.ReadFrom.Configuration(context.Configuration));

var catalogAssembly = typeof(CatalogModule).Assembly;
var basketAssembly = typeof(BasketModule).Assembly;
var userAssembly = typeof(UserModule).Assembly;

builder.Services
    .AddCarterWithAssemblies(catalogAssembly, 
    basketAssembly, userAssembly);

builder.Services
    .AddMediatRWithAssemblies(catalogAssembly, 
    basketAssembly, userAssembly);

builder.Services
    .AddCatalogModule(builder.Configuration)
    .AddBasketModule(builder.Configuration)
    .AddUserModule(builder.Configuration);

builder.Services.AddControllers();

builder.Services
    .AddExceptionHandler<CustomExceptionHandler>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontendDev", policy =>
    {
        policy.WithOrigins("http://localhost:5173")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure the HTTP request pipeline.
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowFrontendDev");

app.MapGet("/", context =>
{
    context.Response.Redirect("/swagger");
    return Task.CompletedTask;
});

app.UseSerilogRequestLogging();
app.UseExceptionHandler(options => { });

app.UseCatalogModule()
    .UseBasketModule()
    .UseUserModule();

app.MapControllers();
app.MapCarter();

app.Run();
