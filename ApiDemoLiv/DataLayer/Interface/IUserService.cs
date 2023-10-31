using ApiDemoLiv.Response;
using ApiDemoLiv.VMmodels;
using System.Diagnostics.Eventing.Reader;

namespace ApiDemoLiv.DataLayer.Interface
{
    public interface IUserService
    {
      public ApiResponse Login(LoginVm loginVm);
      
      public ApiResponse Registration(SignUpVM signUpVM);

    }
}
