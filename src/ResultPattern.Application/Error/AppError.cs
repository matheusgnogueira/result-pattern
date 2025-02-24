namespace ResultPattern.Application.Error
{
    public record AppError(string Detail, ErrorType ErrorType, string ErrorCodeName)
    {
    }
}
