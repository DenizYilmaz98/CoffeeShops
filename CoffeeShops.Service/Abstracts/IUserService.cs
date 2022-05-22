using CoffeeShops.Service.Models;
using CoffeeShops.Service.Models.UserModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShops.Service.Abstracts
{
    public interface IUserService
    {
    
        public string Register(RegisterDto registerDto);
        public LoginResponseModel Login(LoginDto loginDto);
        UserDetailDto Detail(Guid userId);
        public List<UserListIdViewModelDto> ListUsers(Guid companyId);
        UserGetResponseDto Get(Guid companyId, Guid userId);
        void Delete(Guid companyId, Guid userId);

        public Guid Save(SaveRegisterDto saveRegisterDto);


    }
}
