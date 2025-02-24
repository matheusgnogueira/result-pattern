using OneOf;
using ResultPattern.Application.Error;

namespace ResultPattern.Application
{
    public interface ICarService
    {
        Task<OneOf<Car, AppError>> AddCar(string name, CancellationToken ct);
    }
}
