using Microsoft.EntityFrameworkCore;
using OneOf;
using ResultPattern.Application.Error;

namespace ResultPattern.Application
{
    internal class CarService(AppDbContext appDb) : ICarService
    {
        public async Task<OneOf<Car, AppError>> AddCar(string name, CancellationToken ct)
        {
            if (name.StartsWith("M", StringComparison.InvariantCultureIgnoreCase))
                return new ShouldNotStartWithMError();

            var carAlreadyExists = await appDb
                .Cars.AnyAsync(x => x.Name.Equals(name, StringComparison.InvariantCultureIgnoreCase), ct);

            if (carAlreadyExists)
                return new CarNameAlreadyExistsError();

            var car = new Car(Guid.NewGuid(), name);
            await appDb.Cars.AddAsync(car, ct);
            await appDb.SaveChangesAsync(ct);

            return car;
        }
    }
}
