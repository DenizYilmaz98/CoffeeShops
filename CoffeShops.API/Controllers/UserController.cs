using CoffeShops.API.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mapster;
using CoffeeShops.Service.Abstracts;
using CoffeeShops.Service.Models;
using CoffeeShops.API.Models;
using CoffeeShops.API.Attributes;
using CoffeeShops.API.Models.UserModel;
using static CoffeeShops.API.Models.UserModel.UserListIdViewModel;
using CoffeeShops.Service.Models.UserModel;

namespace CoffeShops.API.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly UserContext _userContext;

        public UserController(IUserService userService, UserContext userContext)
        {
         
            _userService = userService;
            _userContext = userContext;
        }
       

        [HttpPost("Register")]
        public RegisterViewModel Register(RegisterInputModel input)
        {
            var model = input.Adapt<RegisterDto>();
            var companyId = _userService.Register(model);
            return new RegisterViewModel() {  CompanyId=companyId };      
        }
        [HttpPost("Save")]
        [Authorize]
        public SaveRegisterViewModel Save(SaveRegisterInputModel saveRegisterInputModel)
        {

            var model = saveRegisterInputModel.Adapt<SaveRegisterDto>();
            model.CompanyId = _userContext.CompanyId;
            var userId = _userService.Save(model);
            return new SaveRegisterViewModel() { UserId = userId };
        }


        [HttpPost("Get")]
        [Authorize]
        public GetUserViewModel Get(Guid id)
        {
            var table = _userService.Get(_userContext.CompanyId, id);
            return table.Adapt<GetUserViewModel>();
        }
        [HttpPost("Login")]
        public LoginViewModel Login(LoginInputModel input)
        {
            var model = input.Adapt<LoginDto>();
            var response=  _userService.Login(model);

            return new LoginViewModel() { Token = response.Token };
        }
        [Authorize]
        [HttpPost("detail")]
        public UserDetailViewModel GetUser()
        {
            var detail = _userService.Detail(_userContext.UserId);
            return new UserDetailViewModel()
            {
                UserId = detail.Id,
                FirstName = detail.FirstName,
                CompanyName = detail.CompanyName
            };
        }
       
        [HttpPost("ListUsers")]
        [Authorize]
        public UserListIdViewModel ListUsers()
        {
            var user = _userService.ListUsers(_userContext.CompanyId);
            
            return new UserListIdViewModel()
            {
                List = user.Select(r => r.Adapt<UserListByTableIdRowViewModel>()).ToList()
            };
        }
        [HttpPost("Delete")]
        [Authorize]
        public void Delete(Guid id)
        {
            _userService.Delete(_userContext.CompanyId, id);
        }
    }
    
}
