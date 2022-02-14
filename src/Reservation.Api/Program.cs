using FluentValidation.AspNetCore;
using Reservation.Api.Filters;
using Reservation.Application.Configs;
using Reservation.Shared.Configs;
using Reservation.Shared.Validators;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(config => config.Filters.Add(typeof(ValidateModelAttribute)))
    .AddFluentValidation(options => options.RegisterValidatorsFromAssemblyContaining<IValidationsMarker>());
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddServices();
builder.Services.RegisterAutoMapper();

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
