using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SuperMarket.DL;
using SuperMarket.Model.Data;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket.BL
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<User> _userManager;
        private readonly IMapper mapper;
    
        private readonly JwtOption _jwt;

        public AuthService( IMapper _mapper
            , UserManager<User> userManager
            , JwtOption jwt)
        {
            
            mapper = _mapper;
            _userManager = userManager;
      
            _jwt = jwt;
        }
        public async Task<AuthDto> LoginAsync(LoginDto dto)
        {
            var aughModel = new AuthDto();

            var user = await _userManager.FindByEmailAsync(dto.Email);

            if (user is null || !await _userManager.CheckPasswordAsync(user, dto.Password))
            {
                aughModel.Masseage = "Email or Password is incorrect";
                return aughModel;
            }

            var jwtSecurityToken = await CreateJwtToken(user);

            aughModel.Email = user!.Email;
            aughModel.IsAuthenticated = true;
            aughModel.UserName = user.UserName;
            aughModel.ExpiresOn = jwtSecurityToken.ValidTo;
            aughModel.Role = jwtSecurityToken.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)!.Value;
            aughModel.Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
            return aughModel;
        }

        public async Task<AuthDto> RegisterAsync(RegisterDto dto)
        {
            if (await _userManager.FindByEmailAsync(dto.Email) is not null)
                return new AuthDto { Masseage = "Email is already registered!" };

            if (await _userManager.FindByNameAsync(dto.Name) is not null)
                return new AuthDto { Masseage = "UserName is already registered!" };

            var user = mapper.Map<User>(dto);

            var result = await _userManager.CreateAsync(user, dto.Password);

            if (!result.Succeeded)
            {
                var errors = string.Empty;

                foreach (var error in result.Errors)
                    errors += $"{error.Description},";

                return new AuthDto { Masseage = errors };

            }

            var jwtSecurityToken = await CreateJwtToken(user, dto.Role);

            return new AuthDto
            {
                Email = user.Email,
                ExpiresOn = jwtSecurityToken.ValidTo,
                IsAuthenticated = true,
                Role = jwtSecurityToken.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)!.Value,
                Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
                UserName = user.UserName

            };

        }

        private async Task<JwtSecurityToken> CreateJwtToken(User user)
        {
            var userClaims = await _userManager.GetClaimsAsync(user);

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwt.SigningKey));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(
                claims: userClaims,
                issuer: _jwt.Issuer,
                audience: _jwt.Audience,
                signingCredentials: signingCredentials,
                expires: DateTime.Now.AddDays(_jwt.DurationInDays));
                
            return jwtSecurityToken;
        }
        private async Task<JwtSecurityToken> CreateJwtToken(User user, string role)
        {
            var claims = new[]
            {
                
                new Claim(ClaimTypes.Role, role==string.Empty?"User":role),
                new Claim(ClaimTypes.Email , user!.Email),
                new Claim(ClaimTypes.Name , user.UserName),
                new Claim(ClaimTypes.NameIdentifier , user.Id.ToString())
              
            };

            await _userManager.AddClaimsAsync(user, claims);

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwt.SigningKey));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(
                claims: claims,
                issuer: _jwt.Issuer,
                audience: _jwt.Audience,
                signingCredentials: signingCredentials,
                expires: DateTime.Now.AddDays(_jwt.DurationInDays));

            return jwtSecurityToken;
        }
    }
}
