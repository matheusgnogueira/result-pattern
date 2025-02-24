namespace ResultPattern.Application.Error
{
    public record CarNameAlreadyExistsError() : AppError("Car already exists", ErrorType.BusinessRule, nameof(CarNameAlreadyExistsError));
}
