using IdentityServer4.Models;
using IdentityServer4.Services;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace oauthServer
{
    public class ProfileService : IProfileService
    {
        private readonly SignInManager<IdentityUser> _signInManager;

        public ProfileService(SignInManager<IdentityUser> signInManager)
        {
            _signInManager = signInManager;
        }

        public async Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            var sub = context.Subject.FindFirst("sub").Value;
            var user = await _signInManager.UserManager.FindByIdAsync(sub);

            var claims = new List<Claim>
            {
                new Claim("email", user.Email),
                new Claim("username", user.UserName)
            };

            context.IssuedClaims = claims;
        }

        public async Task IsActiveAsync(IsActiveContext context)
        {
            var sub = context.Subject.FindFirst("sub").Value;
            var user = await _signInManager.UserManager.FindByIdAsync(sub);
            context.IsActive = user != null;
        }
    }
}
