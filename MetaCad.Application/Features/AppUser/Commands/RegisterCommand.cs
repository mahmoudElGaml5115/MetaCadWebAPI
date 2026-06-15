using FluentValidation;
using MediatR;
using MetaCad.Application.Common;
using MetaCad.Application.DTOs;
using MetaCad.Application.IServices;
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
        private readonly IIdentityService _identityService;   
        private readonly IEmailService _emailService;
        private readonly IConfiguration _configuration;

        public RegisterHandler(IIdentityService appUserService,
                                IEmailService emailService,
                                IConfiguration configuration)
        {
            _identityService = appUserService; 
            _emailService = emailService;
            _configuration = configuration;
        }

        public async Task<ApiResponse<string>> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            try
            { 
                var result = await _identityService.CreateAppUserAsync(request.Model); 
                if (!result.IsSuccess)
                {
                    var errorMessage = string.Join(" | ", result.Errors!);
                    return ApiResponse<string>.Failure(errorMessage); 
                }
                 
                await _identityService.AddToRoleAsync(result.UserId!, "user");

                var activationUrl = $"{_configuration["FrontendUrls:ActivateAccountUrl"]}?email={request.Model?.Email}";
                var email = await PrepaireMailTemplate(request.Model?.Email??"", request.Model?.ActivationCode??"", request.Model?.FullName??"", activationUrl);
                await _emailService.SendEmailAsync(email, cancellationToken);

                return ApiResponse<string>.Success("تم إنشاء الحساب بنجاح وتم إرسال كود التفعيل للبريد الإلكتروني.");
             
            }
            catch (Exception ex)
            { 
                return ApiResponse<string>.Failure("حدث خطأ غير متوقع أثناء التسجيل، يرجى المحاولة لاحقاً.");
            }
        }

        public async Task<EmailMessage> PrepaireMailTemplate(string email, string otp, string fullName, string activationUrl)
        {
            var templatePath = Path.Combine(AppContext.BaseDirectory, "wwwroot", "Templates", "ActivateAccountTemplate.cshtml");

            var htmlBody = await File.ReadAllTextAsync(templatePath);
            htmlBody = htmlBody.Replace("{{UserName}}", fullName)
                               .Replace("{{ActivationUrl}}", activationUrl)
                               .Replace("{{OTP}}", otp);

            var message = new EmailMessage
            {
                To = email,
                Subject = "كود التفعيل الخاص بك",
                Body = htmlBody,
                IsHtml = true
            };
            return message;
        }
    }
}
