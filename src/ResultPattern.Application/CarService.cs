using Microsoft.EntityFrameworkCore;

namespace ResultPattern.Application
{
    internal class CarService(AppDbContext appDb) : ICarService
    {
        public async Task<Car> AddCar(string name, CancellationToken ct)
        {
            if (name.StartsWith("M", StringComparison.InvariantCultureIgnoreCase))
                throw new Exception("Should not start with [M]");

            var carAlreadyExists = await appDb
                .Cars.AnyAsync(x => x.Name.Equals(name, StringComparison.InvariantCultureIgnoreCase), ct);
        
            if (carAlreadyExists)
                throw new Exception("Car already exists");

            var car = new Car(Guid.NewGuid(), name);
            await appDb.Cars.AddAsync(car, ct);
            await appDb.SaveChangesAsync(ct);

            return car;
        }
    }
}
