using AutoMapper;
using FluentValidation;
using Gym.API.Application.Mappings;
using Gym.API.IoC;
using Gym.API.Validators;
using Gym.Domain.AggregateModels.Member;
using Gym.Infrastructure.Repository;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddValidatorsFromAssemblyContaining<MemberValidator>();
builder.Host.UseSerilog((context, configuration) =>
    configuration.ReadFrom.Configuration(context.Configuration));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseSerilogRequestLogging();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
