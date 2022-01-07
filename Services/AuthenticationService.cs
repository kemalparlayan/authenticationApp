using authenticationApp.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System;

namespace authenticationApp.Services
{
    /// <summary>
    /// 
    /// </summary>
    public class AuthenticationService
    {
        private readonly IMongoCollection<AuthenticatedUser> _authenticatedUsers;
        private readonly string _secret;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dbSettings"></param>
        /// <param name="jwtSettings"></param>
        public AuthenticationService(IAuthenticationAppDBSettings dbSettings, IAuthenticationAppJWTSettings jwtSettings)
        {
            MongoClient client = new MongoClient(dbSettings.ConnectionString);
            IMongoDatabase database = client.GetDatabase(dbSettings.DatabaseName);

            _authenticatedUsers = database.GetCollection<AuthenticatedUser>(dbSettings.AuthenticationAppCollectionName);

            _secret = jwtSettings.Secret;
        }

        /// <summary>
        /// Validate user and return jwt
        /// </summary>
        /// <returns></returns>
        public string ValidateUser(string username, string password)
        {
            try
            {
                List<AuthenticatedUser> authenticatedUsers = _authenticatedUsers.Find(user => user.username == username && user.password == password).ToList();
                if (authenticatedUsers.Count == 1)
                {
                    JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
                    var key = Encoding.ASCII.GetBytes(_secret);
                    SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor();
                    Claim claim = new Claim(ClaimTypes.Name, "authenticationAppVerify");
                    Claim[] claimArray = new Claim[1] { claim };
                    ClaimsIdentity claimsIdentity = new ClaimsIdentity(claimArray);
                    tokenDescriptor.Subject = claimsIdentity;
                    tokenDescriptor.Expires = DateTime.UtcNow.AddMinutes(20);
                    tokenDescriptor.SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature);
                    SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);
                    return tokenHandler.WriteToken(token);
                }
                else
                {
                    throw new System.Exception("No Valid Username/Password");
                }
            }
            catch (System.Exception)
            {
                throw new System.Exception("No Valid Username/Password");
            }
        }
    }
}