using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

using Sun.WebAPI.Receiver.Entities;
using Sun.WebAPI.Receiver.Helpers;
using Sun.WebAPI.Receiver.Models;
using Microsoft.Extensions.Configuration;

namespace Sun.WebAPI.Receiver.Services
{
    public interface IUserService
    {
        AuthenticateResponse Authenticate(AuthenticateRequest model);
        IEnumerable<User> GetAll();
        User GetById(int id);
    }

    public class UserService : IUserService
    {
        private readonly IConfiguration _configuration;

        // users hardcoded for simplicity, store in a db with hashed passwords in production applications
        private List<User> _users = new List<User>
        {
            new User { Id = 1, FirstName = "Test", LastName = "User", Username = "test", Password = "test" }
        };

        private readonly AppSettings _appSettings;
        readonly ClientSettings _clientSettings;
        readonly short tokenExpiryInDays = 7;//Default Value is set to 7 Days.

        //public UserService(IOptions<AppSettings> appSettings)
        //{
        //    _appSettings = appSettings.Value;
        //}

        //public UserService(IOptions<AppSettings> appSettings, IOptions<ClientsData> clients)
        //{
        //    _appSettings = appSettings.Value;
        //}

        public UserService(IOptions<AppSettings> appSettings, IOptions<ClientSettings> clientSettings)
        {
            _appSettings = appSettings.Value;
            _clientSettings = clientSettings.Value;
            if(_clientSettings != null)
            {
                tokenExpiryInDays = _clientSettings.TokenExpiryInDays;
                //Add Clients to login and provide access token.
                foreach (var client in _clientSettings.Sources)
                {
                    _users.Add(new User()
                    {
                        Username = client.User,
                        Password = client.Secret
                    });
                }
            }
        }

        public AuthenticateResponse Authenticate(AuthenticateRequest model)
        {
            var user = _users.SingleOrDefault(x => x.Username == model.Username && x.Password == model.Password);

            // return null if user not found
            if (user == null) return null;

            // authentication successful so generate jwt token
            var token = generateJwtToken(user);

            return new AuthenticateResponse(user, token);
        }

        public IEnumerable<User> GetAll()
        {
            return _users;
        }

        public User GetById(int id)
        {
            return _users.FirstOrDefault(x => x.Id == id);
        }

        // helper methods

        private string generateJwtToken(User user)
        {
            // generate token that is valid for 7 days
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()) }),
                Expires = DateTime.UtcNow.AddDays(7),//Token Expiry Time Set to 7 Days
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
