﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PockWebApiWithIdentity.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace PockWebApiWithIdentity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserProfileController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UserProfileController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        [Authorize]
        public async Task<Object> GetUserProfile()
        {
            var userId = User.Claims.First(c => c.Type == "UserId").Value;
            var user = await _userManager.FindByIdAsync(userId);
            return new
            {
                user.FullName,
                user.Email,
                user.UserName
            };
        }
    }
}