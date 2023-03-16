using GFT.Application.Protocols;

namespace GFT.Application.Results
{
    public class UseCaseResult<T> : IUseCaseResult
    {
        public UseCaseResult(ResultStatus status)
        {
            Status = status;
        }

        public UseCaseResult(T value)
        {
            Value = value;
        }

        public T Value { get; }
        public ResultStatus Status { get; private set; } = ResultStatus.Ok;
        public object GetValue() => Value;
        public static UseCaseResult<T> Success(T value) => new(value);
        public IEnumerable<string> Errors { get; private set; } = new List<string>();
        public static UseCaseResult<T> Invalid(string validationError) => new(ResultStatus.Invalid) { Errors = new List<string> { validationError } };
        public static UseCaseResult<T> Invalid(List<string> validationErrors) => new(ResultStatus.Invalid) { Errors = validationErrors };
    }
}
