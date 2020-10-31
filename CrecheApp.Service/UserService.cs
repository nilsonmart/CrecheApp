using CrecheApp.Domain.Model;
using CrecheApp.Domain.Entity;
using CrecheApp.Domain.Interface.Repository;
using CrecheApp.Domain.Interface.Service;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Security.Claims;
using System.Text;
using CrecheApp.Domain.Interface.Helper;

namespace CrecheApp.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IAppSettings _appSettings;

        public UserService(IUserRepository userRepository, IAppSettings appSettings)
        {
            _userRepository = userRepository;
            _appSettings = appSettings;
        }

        public AuthenticateResponseModel Authenticate(AuthenticateRequestModel model)
        {
            var user = _userRepository.Authenticate(model.Email, model.Password);

            // return null if user not found
            if (user == null) return null;

            // authentication successful so generate jwt token
            var token = GenerateJwtToken(user);

            return new AuthenticateResponseModel(user, token);
        }

        private string GenerateJwtToken(User user)
        {
            // generate token that is valid for 7 days
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("globalId", user.GlobalId.ToString()) }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public void Add(UserModel domain)
        {
            var entity = ConvertToEntity(domain);
            entity.GlobalId = Guid.NewGuid();
            entity.CreationDate = DateTime.UtcNow;
            entity.CreationUser = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
            entity.FirstAuthentication = DateTime.UtcNow;
            entity.Password = GenerateRandomPassword();
            _userRepository.Add(entity);
        }

        public void Delete(Guid globalId)
        {
            var model = _userRepository.GetByGlobalId(globalId);
            if (model == null)
            {
                throw new NullReferenceException("object not found.");
            }
            _userRepository.Delete(model);
        }

        public IEnumerable<UserModel> GetAll()
        {
            var retval = _userRepository.GetAll().ToList();
            if (retval == null)
            {
                return null;
            }
            return retval.Select(user => ConvertToDomain(user));
        }

        public UserModel GetByGlobalId(Guid globalId)
        {
            var entity = _userRepository.GetByGlobalId(globalId);
            if (entity == null)
            {
                return null;
            }
            return ConvertToDomain(entity);
        }

        public UserModel GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(UserModel entity)
        {
            var retval = ConvertToEntity(entity);
            _userRepository.Update(retval);
        }

        private User ConvertToEntity(UserModel domain)
        {
            return new User
            {
                Id = domain.Id,
                GlobalId = domain.GlobalId,
                AccountId = domain.AccountId,
                FirstName = domain.FirstName,
                LastName = domain.LastName,
                Email = domain.Email,
                Password = domain.Password,
                UserRole = domain.UserRole,
                IsActive = domain.IsActive,
                CreationUser = domain.CreationUser,
                CreationDate = domain.CreationDate,
                LastChangeUser = domain.LastChangeUser,
                LastChangeDate = domain.LastChangeDate,
                FirstAuthentication = domain.FirstAuthentication,
                LastAuthentication = domain.LastAuthentication,
                LastAuthenticationIPAddress = domain.LastAuthenticationIPAddress
            };
        }

        private UserModel ConvertToDomain(User entity)
        {
            return new UserModel
            {
                Id = entity.Id,
                GlobalId = entity.GlobalId,
                AccountId = entity.AccountId,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                Email = entity.Email,
                Password = entity.Password,
                UserRole = entity.UserRole,
                IsActive = entity.IsActive,
                CreationUser = entity.CreationUser,
                CreationDate = entity.CreationDate,
                LastChangeUser = entity.LastChangeUser,
                LastChangeDate = entity.LastChangeDate,
                FirstAuthentication = entity.FirstAuthentication,
                LastAuthentication = entity.LastAuthentication,
                LastAuthenticationIPAddress = entity.LastAuthenticationIPAddress
            };
        }

        public static string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            throw new Exception("No network adapters with an IPv4 address in the system!");
        }

        /// <summary>
        /// Generates a Random Password
        /// respecting the given strength requirements.
        /// </summary>
        /// <param name="opts">A valid PasswordOptions object
        /// containing the password strength requirements.</param>
        /// <returns>A random password</returns>
        private string GenerateRandomPassword(PasswordOptions opts = null)
        {
            if (opts == null) opts = new PasswordOptions()
            {
                RequiredLength = 8,
                RequiredUniqueChars = 4,
                RequireDigit = true,
                RequireLowercase = true,
                RequireNonAlphanumeric = true,
                RequireUppercase = true
            };

            string[] randomChars = new[] {
            "ABCDEFGHJKLMNOPQRSTUVWXYZ",    // uppercase 
            "abcdefghijkmnopqrstuvwxyz",    // lowercase
            "0123456789",                   // digits
            "!@$?_-"                        // non-alphanumeric
        };

            Random rand = new Random(Environment.TickCount);
            List<char> chars = new List<char>();

            if (opts.RequireUppercase)
                chars.Insert(rand.Next(0, chars.Count),
                    randomChars[0][rand.Next(0, randomChars[0].Length)]);

            if (opts.RequireLowercase)
                chars.Insert(rand.Next(0, chars.Count),
                    randomChars[1][rand.Next(0, randomChars[1].Length)]);

            if (opts.RequireDigit)
                chars.Insert(rand.Next(0, chars.Count),
                    randomChars[2][rand.Next(0, randomChars[2].Length)]);

            if (opts.RequireNonAlphanumeric)
                chars.Insert(rand.Next(0, chars.Count),
                    randomChars[3][rand.Next(0, randomChars[3].Length)]);

            for (int i = chars.Count; i < opts.RequiredLength
                || chars.Distinct().Count() < opts.RequiredUniqueChars; i++)
            {
                string rcs = randomChars[rand.Next(0, randomChars.Length)];
                chars.Insert(rand.Next(0, chars.Count),
                    rcs[rand.Next(0, rcs.Length)]);
            }

            return new string(chars.ToArray());
        }
    }
}
