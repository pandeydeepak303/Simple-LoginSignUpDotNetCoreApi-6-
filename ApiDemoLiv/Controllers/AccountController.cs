using ApiDemoLiv.DataLayer.Interface;
using ApiDemoLiv.Response;
using ApiDemoLiv.VMmodels;
using Microsoft.AspNetCore.Mvc;

namespace ApiDemoLiv.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [Route("Login")]
        public ApiResponse Login(LoginVm loginVm)
        {
            return _userService.Login(loginVm);
        }

        [HttpPost]
        [Route("Registration")]
        public ApiResponse Registration(SignUpVM signUpVM)
        {
            return _userService.Registration(signUpVM);
        }


    }
}
