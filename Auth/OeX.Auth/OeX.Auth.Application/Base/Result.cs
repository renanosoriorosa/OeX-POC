using System.Text.Json.Serialization;

namespace OeX.Auth.Application.Base
{
    public class Result<T>
    {
        public bool Success { get; private set; }
        public IEnumerable<string>? Messages { get; private set; }
        public T? Data { get; private set; }
        public ExceptionDetails? Exception { get; private set; }

        public Result()
        {
        }

        [JsonConstructor]
        public Result(bool success, IEnumerable<string>? messages, T? data, ExceptionDetails? exception)
        {
            Success = success;
            Messages = messages;
            Data = data;
            Exception = exception;
        }

        public static Result<T> Ok(T data = default)
        {
            return new Result<T>
            {
                Success = true,
                Data = data
            };
        }

        public static Result<T> Fail(IEnumerable<string> message)
        {
            return new Result<T>
            {
                Success = false,
                Messages = message
            };
        }

        public static Result<T> Fail(string message)
        {
            List<string> _messages = new List<string>();

            if (!string.IsNullOrEmpty(message))
                _messages.Add(message);

            return new Result<T>
            {
                Success = false,
                Messages = _messages
            };
        }

        public static Result<T> FailException(Exception exception)
        {
            return new Result<T>
            {
                Success = false,
                Exception = exception != null ? new ExceptionDetails(exception) : null
            };
        }
    }

    public class ExceptionDetails
    {
        public string Message { get; private set; }
        public string? StackTrace { get; private set; }
        public string? InnerExceptionMessage { get; private set; }

        [JsonConstructor]
        public ExceptionDetails(string message, string? stackTrace, string? innerExceptionMessage)
        {
            Message = message;
            StackTrace = stackTrace;
            InnerExceptionMessage = innerExceptionMessage;
        }

        public ExceptionDetails(Exception exception)
        {
            Message = exception.Message;
            StackTrace = exception.StackTrace;
            InnerExceptionMessage = exception.InnerException?.Message;
        }
    }
}
