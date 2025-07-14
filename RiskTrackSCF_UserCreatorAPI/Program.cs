using MassTransit;
using Microsoft.EntityFrameworkCore;
using RiskTrackSCF_UserCreatorAPI.Consumers;
using RiskTrackSCF_UserCreatorAPI.Data;
using RiskTrackSCF_UserCreatorAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Configure DbContext
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register services
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IEmailService, EmailService>(); 

// Add controllers
builder.Services.AddControllers();

builder.Services.AddMassTransit(x =>
{
    x.AddConsumer<UserCreatedConsumer>();

    x.UsingRabbitMq((context, cfg) =>
    {
        var rabbitMqConfig = builder.Configuration.GetSection("RabbitMQ");
        cfg.Host(rabbitMqConfig["HostName"], "/", h =>
        {
            h.Username(rabbitMqConfig["UserName"]);
            h.Password(rabbitMqConfig["Password"]);
        });

        cfg.ConfigureEndpoints(context);
    });
});

// ?? Add Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();



// ?? Enable Swagger middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(); // default UI at /swagger
}

app.UseHttpsRedirection();
app.UseCors(); 
app.UseAuthorization();

app.MapControllers();

app.Run();
