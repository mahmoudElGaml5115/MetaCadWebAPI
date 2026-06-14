using FluentValidation;
using MediatR;
using MetaCad.Application.Common;
using MetaCad.Application.Models.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace MetaCad.Application.Features.AppUser.Commands
{ 

    public class RegisterCommand : IRequest<ApiResponse<string>>
    {
        public RegisterModel Model { get; set; }
    }

    public class RegisterHandler : IRequestHandler<RegisterCommand, ApiResponse<string>>
    {
        public Task<ApiResponse<string>> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
