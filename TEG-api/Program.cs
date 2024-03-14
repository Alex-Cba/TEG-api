using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;
using TEG_api.CQRS.Commands.User.Create;
using TEG_api.Data;
using TEG_api.Helpers.JwtSecurity;
using TEG_api.Hubs;
using TEG_api.Middleware;
using TEG_api.Services.Imp;
using TEG_api.Services.Interface;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSignalR();

// Add services to the container.

builder.Services.AddCors();

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
});

//builder.Services.AddScoped<IValidator<PostEmpleadoCommand>, PostEmpleadoCommandValidator>();
//builder.Services.AddScoped<IValidator<PutEmpleadoCommand>, PutEmpleadoCommandValidator>();
//builder.Services.AddScoped<IValidator<DeleteEmpleadoCommand>, DeleteEmpleadoCommandValidator>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{

    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Auhtorization",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"

    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type= ReferenceType.SecurityScheme,
                    Id="Bearer",
                }
            },
            new string[] {}
        }
    });

});

builder.Services.AddDbContext<TEGContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});

//Remember Add Scopes for services!!!
builder.Services.AddSingleton<JwtHelper>();
builder.Services.AddScoped<ICRUDService, CRUDImp>();
builder.Services.AddScoped<IDiceService, DiceService>();
builder.Services.AddScoped<IDealer, Dealer>();
builder.Services.AddScoped<IGameSynchronizer, GameSynchronizer>();
builder.Services.AddScoped<ITurnController, TurnControllerService>();
builder.Services.AddValidatorsFromAssemblyContaining<CreateUserValidator>();
builder.Services.AddTransient<IValidatorFactory, ServiceProviderValidatorFactory>();
builder.Services.AddLogging();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(c =>
{
    c.AllowAnyHeader();
    c.AllowAnyMethod();
    c.WithOrigins("http://localhost:3000", "http://localhost:3001", "https://localhost:7123");
    c.AllowCredentials();
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseMiddleware<ErrorMiddleware>();

app.MapControllers();

app.MapHub<PrincipalHub>("/PrincipalHub");

app.Run();