using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaCad.Application.Common
{ 
    public class ApiResponse<T>
    {
        public ApiResponse()
        {
            Errors = new List<string>();
        }
        public bool IsSuccess { get; set; }
        public string Message { get; set; } = string.Empty;
        public T? Obj { get; set; }
        public List<string> Errors { get; set; }

       
        public static ApiResponse<T> Success(string message = "") =>
            new ApiResponse<T> { IsSuccess = true, Message = message };

        public static ApiResponse<T> Success(T obj, string message = "") =>
            new ApiResponse<T> { IsSuccess = true, Obj = obj, Message = message };

        public static ApiResponse<T> Failure(string message = "") =>
            new ApiResponse<T> { IsSuccess = false, Message = message };

        public static ApiResponse<T> Failure(List<string> errors, string message = "") =>
            new ApiResponse<T> { IsSuccess = false, Errors = errors, Message = message };
    }
}
