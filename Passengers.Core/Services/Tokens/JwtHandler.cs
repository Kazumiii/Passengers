using System;
using System.Collections.Generic;
using System.Text;
using Passengers.Core.DTO;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;

namespace Passengers.Core.Services
{
    public class JwtHandler : IjwtHandler
    {
        private readonly jwtSettings _settings;

       public JwtHandler(jwtSettings settings)
        {
            _settings = settings;
        }




        public jwtDTO CreateToken(Guid userID,string role)
        {
            //set expiriation date of our token
            var now = DateTime.UtcNow;

            //Claims allows set data of our token
            var claims = new Claim[]
            {
                //inform for who token is created 
                //user identification by userID
                new Claim(JwtRegisteredClaimNames.Sub,userID.ToString()),


                //to automatic put user's data from token to identity of users from application level
                 new Claim(JwtRegisteredClaimNames.UniqueName,userID.ToString()),



                //role of our user (admin ot normal user)
                new Claim(ClaimTypes.Role,role),

              //unique token's identifikator
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),

                //token's creation date
                //iy must be save in Ticks format but it's impossilbe use build Ticks format 
                //I must use Linux format(epoch) to save this data that's why i must exent standard DateTime class 
                new Claim(JwtRegisteredClaimNames.Iat,now.ToTimestamp().ToString(),ClaimValueTypes.Integer64),



            };

            var expiry=now.AddMinutes(_settings.ExpireMinutes);

            //way of signing of our token
            //choosen security algorithm
            var signCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes( _settings.Key)),SecurityAlgorithms.HmacSha256);


            var jwt = new JwtSecurityToken(

                //who can evoke token
                //this what is Issuer is defined in appseetings.json file 
                issuer: _settings.Issuer,
                
                //pass our claims created above
                claims:claims,

                //when token is valid 
                notBefore:now,

                //when token is unvalid
                 expires:expiry,

                 // pass signing credentials, key to create token
                 signingCredentials:signCredentials
);


            //genrates token
            //write token to our jwt
            var token = new JwtSecurityTokenHandler().WriteToken(jwt);


            //at the end returns encrypted token
            return new jwtDTO
            {
                Token = token,
                Expire=expiry.ToTimestamp(),
            };
        }
    }
}
