using MetaCad.Application.DTOs;
using MetaCad.Application.IServices;
using MetaCad.Application.Models.Auth;
using MetaCad.Core.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MetaCad.Application.Services
{
    public class IdentityService : IIdentityService
    {
        private readonly UserManager<AppUser> _userManager;

        public IdentityService(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<RegisterDto> CreateAppUserAsync(RegisterModel model)
        {
            var user = new AppUser
            {
                UserName = model.Email,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber
            };

            var result = await _userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
            { 
                return new RegisterDto(false, null, result.Errors.Select(e => e.Description));
            }
             
            return new RegisterDto(true, user.Id, null);
          
        }

        public async Task<bool> AddToRoleAsync(string userId, string roleName)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null) return false;

            var result = await _userManager.AddToRoleAsync(user, roleName);
            return result.Succeeded;
        }

    }
}
