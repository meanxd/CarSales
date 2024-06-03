namespace CarSales.Common.Errors;

public record Error
{
    public static readonly Error None = new(string.Empty, string.Empty, ErrorType.Failure);
    public static readonly Error NullValue = new("Error.NullValue", "Null value was provided", ErrorType.Failure);

    private Error(string code, string description, ErrorType errorType)
    {
        Code = code;
        Description = description;
        Type = errorType;
    }
    public string Code { get; set; }

    public string Description { get; set; }

    public ErrorType Type { get; set; }

    public static Error NotFound(string code, string description) =>
        new(code, description, ErrorType.NotFound);

    public static Error Validation(string code, string description) =>
        new(code, description, ErrorType.Validation);
    public static Error Conflict(string code, string description) =>
        new(code, description, ErrorType.Conflict);
}

public enum ErrorType
{
    Validation = 0,
    NotFound = 1,
    Failure = 2,
    Conflict = 3,
}
