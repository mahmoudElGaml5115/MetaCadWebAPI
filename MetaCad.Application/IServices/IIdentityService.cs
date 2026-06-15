using MetaCad.Application.DTOs;
using MetaCad.Application.Models.Auth;
using System;
using System.Collections.Generic;
using System.Text;

namespace MetaCad.Application.IServices
{
    public interface IIdentityService
    {
        Task<RegisterDto> CreateAppUserAsync(RegisterModel model);
        Task<bool> AddToRoleAsync(string userId, string roleName);
    }
}
