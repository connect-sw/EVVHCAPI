using EVVHCAPI.HUB;
using Microsoft.AspNetCore.SignalR;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// ✅ Add SignalR
builder.Services.AddSignalR();

// ✅ Add CORS for WebSocket clients (allow any origin during development)
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyHeader()
              .AllowAnyMethod()
              .AllowCredentials()
              .SetIsOriginAllowed(_ => true); // Allow all origins
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// ✅ Enable CORS
app.UseCors();

app.UseAuthorization();

app.MapControllers();

// ✅ Map SignalR hub endpoint
app.MapHub<LocationHub>("/locationhub");

app.Run();
