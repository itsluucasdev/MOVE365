using M365.Infrastructure.Extensions;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// ====================================
// ConfigureHostBuilder Extensions
// ====================================
builder.Host.AddCustomUseSerilog();

// ====================================
// Services Extensions
// ====================================
builder.Services.AddControllers();
builder.Services.AddCustomApiVersioning(builder.Configuration);
builder.Services.AddCustomOpenTelemetry(builder.Configuration);
builder.Services.AddCustomSwaggerGen(builder.Configuration);
builder.Services.AddCustomAuthentication(builder.Configuration);
builder.Services.AddCustomHealthChecks(builder.Configuration);
builder.Services.ConfigureMongoDb(builder.Configuration);
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSerilogRequestLogging();
app.UseAuthentication();
app.UseAuthorization();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();
app.MapHealthChecks("/health");
app.UseHttpsRedirection();

app.Run();