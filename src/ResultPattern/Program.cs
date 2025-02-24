using Microsoft.AspNetCore.Mvc;
using ResultPattern.Application;


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
    var car = await service.AddCar(req.Name, ct);
    return Results.Created($"cars/{car.Id}", car);
});

app.Run();

public record RegisterCarRequest(string Name);
