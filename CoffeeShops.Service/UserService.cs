using CoffeeShops.Core;
using CoffeeShops.Service.Abstracts;
using CoffeeShops.Service.Models;
using CoffeeShops.Service.Models.UserModel;
using CoffeShops.Data.Abstracts;
using CoffeShops.Data.Models;
using Mapster;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShops.Service
{
    public class UserService:IUserService
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IUserRepository _userRepository;
        private readonly IOptions<AppSettings> _options;

        public UserService(ICompanyRepository companyRepository ,IUserRepository userRepository, IOptions<AppSettings> options)
        {
            _companyRepository = companyRepository;
            _userRepository = userRepository;
            _options = options;
        }

       

         public LoginResponseModel Login(LoginDto loginDto)
        {
          var user= _userRepository.GetAll(x => x.Email == loginDto.Email).FirstOrDefault();
            string passwordEncrypted = string.Empty;
            using (MD5 md5 = MD5.Create())
            {
                passwordEncrypted = System.Text.Encoding.UTF8.GetString(md5.ComputeHash(Encoding.UTF8.GetBytes(loginDto.Password + user.PasswordSalt)));
            }
            if (user.PasswordEncrypted==passwordEncrypted)
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_options.Value.TokenKey);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                    new Claim("UserId", user.Id.ToString()),
                    new Claim("CompanyId", user.CompanyId.ToString())
                    }),
                    Expires = DateTime.UtcNow.AddDays(1),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                return new LoginResponseModel() { Token = tokenHandler.WriteToken(token) };
               
            }
            return null;
        }

        public string Register(RegisterDto registerDto)
        {
            var company = new Company();

            company.Id = Guid.NewGuid();
            company.Name = registerDto.CompanyName;

            _companyRepository.Insert(company);

            var user = new User();

            user.Id = Guid.NewGuid();
            user.Email = registerDto.Email;
            user.FirstName = registerDto.FirstName;
            user.LastName = registerDto.LastName;
            user.PasswordSalt = Guid.NewGuid().ToString();
            using (MD5 md5 = MD5.Create())
            {
                var addPassword = registerDto.Password + user.PasswordSalt;
                user.PasswordEncrypted =System.Text.Encoding.UTF8.GetString( md5.ComputeHash(Encoding.UTF8.GetBytes(addPassword)));
            }
            user.CompanyId = company.Id;
            _userRepository.Insert(user);

            return company.Id.ToString();
        }

        public UserDetailDto Detail(Guid userId)
        {
            var user = _userRepository.GetById(userId);

            var company = _companyRepository.GetById(user.CompanyId);

            return new UserDetailDto()
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Password = user.PasswordEncrypted,

                CompanyName = company.Name
            };
        }


        public List<UserListIdViewModelDto> ListUsers (Guid companyId)
        {
            List<User> users = _userRepository.ListUsers(companyId);
            return users.Select(m => m.Adapt<UserListIdViewModelDto>()).ToList();
        }

        public Guid Save(SaveRegisterDto saveRegisterDto)
        {
            var user= new User();


            user.FirstName = saveRegisterDto.FirstName;
            user.LastName = saveRegisterDto.LastName;
            user.Email = saveRegisterDto.Email;
            user.PasswordSalt = Guid.NewGuid().ToString();
            using (MD5 md5 = MD5.Create())
            {
                var addPassword = saveRegisterDto.Password + user.PasswordSalt;
                user.PasswordEncrypted = System.Text.Encoding.UTF8.GetString(md5.ComputeHash(Encoding.UTF8.GetBytes(addPassword)));
            }

            user.CompanyId = saveRegisterDto.CompanyId;
            
            if (saveRegisterDto.Id == Guid.Empty)
            {


                user.Id = Guid.NewGuid();
                _userRepository.Insert(user);
            }
            else
            {
                user.Id = saveRegisterDto.Id;
                _userRepository.Update(user);
            }
            return user.Id;
        }

        public UserGetResponseDto Get(Guid companyId, Guid userId)
        {
           
                var table = _userRepository.Get(companyId, userId);
                return table.Adapt<UserGetResponseDto>();
            
        }

        public void Delete(Guid companyId, Guid userId)
        {
            _userRepository.Delete(companyId, userId);
        }
    }
}
