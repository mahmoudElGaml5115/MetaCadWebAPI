using MetaCad.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;

namespace MetaCad.Application.IServices
{
    public interface IEmailService
    {
        Task SendEmailAsync(EmailMessage message, CancellationToken ct = default);
    }
}
