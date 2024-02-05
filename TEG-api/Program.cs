using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using TEG_api.CQRS.Commands.User.Create;
using TEG_api.Data;
using TEG_api.Middleware;
using TEG_api.Services.Imp;
using TEG_api.Services.Interface;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddCors(config =>
{
    config.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyHeader()
               .AllowAnyMethod();
    });
});

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
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<TEGContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});

//Remember Add Scopes for services!!!
builder.Services.AddScoped<ICRUDService, CRUDImp>();
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

app.UseHttpsRedirection();

app.UseCors();

app.UseAuthorization();

app.UseMiddleware<ErrorMiddleware>();

app.MapControllers();

app.Run();
