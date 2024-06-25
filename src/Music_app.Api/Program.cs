using Music_app.Api.Configurations;
using Music_app.Api.Middlewares;
using Npgsql;
using Serilog;
using System.Data;

var builder = WebApplication.CreateBuilder(args);

//ConnectionString
var connectionString = builder.Configuration.GetConnectionString("PgConnection");
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Serilog
Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .Enrich.FromLogContext()
    .CreateLogger();

builder.Host.UseSerilog();

//Register services

builder.Services.AddInfrastructure()
    .AddApplication()
    .AddDbConfiguration(builder.Configuration);

builder.Services.AddTransient(provider =>
    provider.GetRequiredService<IDbConnection>().BeginTransaction());

builder.Services.AddTransient<IDbConnection>(_ =>
{
    var connection = new NpgsqlConnection(connectionString);
    connection.Open();
    return connection;
});

builder.Services.AddTransient(provider =>
    provider.GetRequiredService<IDbConnection>().BeginTransaction());

var app = builder.Build();

// Configure the HTTP request pipeline.
if(app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.UseMiddleware<ValidationExceptionHandlingMiddleware>();

app.UseAuthorization();

app.MapControllers();

app.Run();
