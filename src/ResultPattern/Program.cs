using Microsoft.AspNetCore.Mvc;
using OneOf.Types;
using ResultPattern.Application;
using ResultPattern.Application.Error;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddApplication();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapPost("/cars", async ([FromBody] RegisterCarRequest req, ICarService service, CancellationToken ct = default) =>
{
    var carResult = await service.AddCar(req.Name, ct);

    return carResult.Match(
        car => Results.Created($"cars/{car.Id}", car),
        error =>
        {
            if (error.ErrorType == ErrorType.BusinessRule)
                return Results.Conflict(error);

            return Results.BadRequest(error);
        });
});

app.Run();

public record RegisterCarRequest(string Name);
