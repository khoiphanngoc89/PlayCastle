using Catalog.API.Config;
using Catalog.API.Entities;
using Catalog.API.Middlewares;
using Common.SharedKernel.Serilog;
using Common.SharedKernel.Settings;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

var serilogSettings = builder.Configuration.GetSection(nameof(SerilogSettings)).Get<SerilogSettings>();

builder.Host.UseSerilog((ctx, lc) =>
        SerilogConfig.Initialize(ctx, lc, serilogSettings));
    
// Add services to the container.
builder.Services.AddControllers(options =>
{
    // aspnet does not remove async suffix from any methods
    options.SuppressAsyncSuffixInActionNames = false;
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Inject another services
var serviceSettings = builder.Configuration.GetSection(nameof(ServiceSettings)).Get<ServiceSettings>();
var mongoDbSettings = builder.Configuration.GetSection(nameof(MongoDbSettings)).Get<MongoDbSettings>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddMongoDb(mongoDbSettings, serviceSettings).AddRepository<Item>(mongoDbSettings);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<CustomExceptionHandlingMiddleware>();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
