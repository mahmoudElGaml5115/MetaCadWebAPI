using System;
using System.Collections.Generic;
using System.Text;

namespace MetaCad.Application.DTOs
{
    public class RegisterDto
    {
        public bool IsSuccess { get; set; }
        public string? UserId { get; set; }
        public IEnumerable<string>? Errors { get; set; }

        public RegisterDto(bool isSuccess,string? userId,IEnumerable<string>? errors)
        {
            IsSuccess = isSuccess;
            UserId = userId;
            Errors = errors;
        }
    }
}
