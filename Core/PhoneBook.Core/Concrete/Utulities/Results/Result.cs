using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PhoneBook.Core.Concrete.Utulities.Results
{
    public class Result
    {
        [JsonPropertyName("success")]
        public bool Success { get; set; }
        [JsonPropertyName("message")]
        public string Message { get; set; }
        [JsonPropertyName("code")]
        public ResultCode Code { get; set; }
        protected Result(bool success, string message, ResultCode code)
        {
            Success = success;
            Message = message;
            Code = code;
        }
        public Result() { }

        public static Result SuccessResult(string message = "Success")
        {
            return new Result(true, message, ResultCode.Success);
        }

        public static Result FailureResult(string message, ResultCode code)
        {
            return new Result(false, message, code);
        }
    }
    public class Result<T> : Result
    {
        [JsonPropertyName("data")]
        public T Data { get; set; }

        private Result(bool success, T data, string message, ResultCode code)
            : base(success, message, code)
        {
            Data = data;
        }
        public Result() { }
        public static Result<T> SuccessResult(T data, string message = "Success")
        {
            return new Result<T>(true, data, message, ResultCode.Success);
        }

        public static Result<T> FailureResult(string message, ResultCode code)
        {
            return new Result<T>(false, default, message, code);
        }
    }
    public class ResultDataList<T> : Result
    {
        [JsonPropertyName("data")]
        public List<T> DataList { get; set; }

        private ResultDataList(bool success, List<T> data, string message, ResultCode code)
            : base(success, message, code)
        {
            DataList = data;
        }

        public static ResultDataList<T> SuccessResult(List<T> data, string message = "Success")
        {
            return new ResultDataList<T>(true, data, message, ResultCode.Success);
        }

        public static ResultDataList<T> FailureResult(string message, ResultCode code)
        {
            return new ResultDataList<T>(false, new List<T>(), message, code);
        }
    }
    public enum ResultCode
    {
        Success = 200,
        NotFound = 404,
        ValidationError = 400,
        ServerError = 500,
        Error = 501,
        SerializationError = 502,
        Forbidden = 503,
        ExternalServiceError = 504,
        KafkaError = 505,
        TokenExpired = 506,
        Unauthorized = 507
    }
}
