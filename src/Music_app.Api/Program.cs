using System.Data;
using Music_app.Api.Configurations;
using Music_app.Api.Middlewares;
using Music_app.Infrastructure.Configurations;
using Npgsql;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

//ConnectionString
var connectionString = builder.Configuration.GetConnectionString("PgConnection");

//Appsetting
var appSetting = new AppSetting();

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpContextAccessor();

//Serilog
Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .Enrich.FromLogContext()
    .CreateLogger();

builder.Host.UseSerilog();

//Register services
builder.Services.AddInfrastructure()
    .AddApplication()
    .AddDbConfiguration(builder.Configuration)
    .AddAuthentication(appSetting);

//DB Service
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

//Add Cors
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy",
        cors =>
        {
            cors
                .AllowAnyMethod()
                .AllowAnyHeader()
                .SetIsOriginAllowed(_ => true)
            .AllowCredentials();
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("CorsPolicy");

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseAuthentication();

app.UseMiddleware<ValidationExceptionHandlingMiddleware>();

app.UseAuthorization();

app.MapControllers();

app.Run();