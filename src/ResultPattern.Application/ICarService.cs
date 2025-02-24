namespace ResultPattern.Application
{
    public interface ICarService
    {
        Task<Car> AddCar(string name, CancellationToken ct);
    }
}
