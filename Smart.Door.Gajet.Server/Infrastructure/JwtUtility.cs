using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure
{
    public static class JwtUtility
    {
        static JwtUtility()
        {
        }

        public static string GenerateJwtToken(Models.User user, Infrastructure.ApplicationSettings.Main mainSettings)
        {
            byte[] key =
                System.Text.Encoding.ASCII.GetBytes(mainSettings.SignKey);

            var symetricSignKey =
                new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(key: key);

            var signAlgorithm =
                 Microsoft.IdentityModel.Tokens.SecurityAlgorithms.HmacSha256Signature;

            var signingCredentials =
                new Microsoft.IdentityModel.Tokens.SigningCredentials(key: symetricSignKey, algorithm: signAlgorithm);


            var tokenDescriptor =
                new Microsoft.IdentityModel.Tokens.SecurityTokenDescriptor
                {
                    Subject = new System.Security.Claims.ClaimsIdentity(new[]
                    {
                        //nameof(user.FullName) ~ "FullName"
                        new System.Security.Claims.Claim(type: nameof(user.FullName), value: user.FullName),

                        new System.Security.Claims.Claim(type: nameof(user.RoleId), value: user.RoleId.ToString()),

                        new System.Security.Claims.Claim(type: System.Security.Claims.ClaimTypes.Name, value: user.Username),

                        new System.Security.Claims.Claim(type: System.Security.Claims.ClaimTypes.Role, value: user.Type.ToString()),

                        new System.Security.Claims.Claim(type: System.Security.Claims.ClaimTypes.NameIdentifier, value: user.Id.ToString()),


                    }),

                    //این دو تا بیشتر جنبه ی تشریفاتی دارند

                    //برای مشخص کردن کدام شرکت می باشد
                    Issuer = "",

                    //برای مشخص کردن کدام پروژه  می باشد
                    Audience = "",

                    //مدت زمان معمول 24 ساعت است ولی بهترین و مطمئنترین 20 دقیقه می باشد
                    Expires =
                        System.DateTime.UtcNow.AddMinutes(mainSettings.TokenExpiresInMinutes),

                    SigningCredentials = signingCredentials,

                };

            var tokenHandler =
                new System.IdentityModel.Tokens.Jwt.JwtSecurityTokenHandler();

            Microsoft.IdentityModel.Tokens.SecurityToken securityToken =
                tokenHandler.CreateToken(tokenDescriptor: tokenDescriptor);

            string token =
                tokenHandler.WriteToken(token: securityToken);

            return token;
        }

        public async static void AttachUserToContextByToken(Microsoft.AspNetCore.Http.HttpContext context,
            Services.IUserService userService, string token, string signKey)
        {
            try
            {
                var key =
                    System.Text.Encoding.ASCII.GetBytes(signKey);

                var toeknHandler =
                    new System.IdentityModel.Tokens.Jwt.JwtSecurityTokenHandler();

                toeknHandler.ValidateToken(token: token, validationParameters: new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,

                    ValidateIssuerSigningKey = true,

                    IssuerSigningKey =
                        new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(key: key),

                    //Set ClockSkew to zero so tokens expire
                    //exactly at token expiration time (instead of 5 minute later)
                    ClockSkew =
                     System.TimeSpan.Zero,
                }, out Microsoft.IdentityModel.Tokens.SecurityToken validatedToken);

                var jwtToken =
                    validatedToken as System.IdentityModel.Tokens.Jwt.JwtSecurityToken;

                if (jwtToken == null)
                {
                    return;
                }

                //  ها از توکن  claim  روش استخراج کردن 
                //  می باشد که مورد نیاز ما است userId  در واقع همان   NameId 
                System.Security.Claims.Claim userIdClaim =
                    jwtToken.Claims
                    .Where(current => current.Type.ToLower() == nameof(Resources.DataDictionary.NameId).ToLower())
                    .FirstOrDefault()
                    ;

                if (userIdClaim == null)
                {
                    return;
                }

                //این دستور هم درست کار می کند
                //Guid userId;
                //bool bln=
                //       Guid.TryParse(userIdClaim.Value,out userId);

                var userId =
                    Guid.Parse(userIdClaim.Value);

                Models.User foundedUser =
                    await userService.GetByIdAsync(id: userId).ConfigureAwait(false);

                if (foundedUser == null)
                {
                    return;
                }

                if (foundedUser.IsActive == false)
                {
                    return;
                }

                //Attach user to context on successful jwt validation
                context.Items[nameof(Resources.DataDictionary.User)] = foundedUser;

            }
            catch (System.Exception ex)
            {
                ViewModels.General.ErrorViewModel errorViewModel =
                    new ViewModels.General.ErrorViewModel(ex.Message);

                //Log(errorViewModel.Message)

            }
        }
    }
}
