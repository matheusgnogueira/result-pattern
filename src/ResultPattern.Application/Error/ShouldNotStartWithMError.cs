namespace ResultPattern.Application.Error
{
    public record ShouldNotStartWithMError() : AppError("Should not start with [M]", ErrorType.BusinessRule, nameof(ShouldNotStartWithMError));
}
