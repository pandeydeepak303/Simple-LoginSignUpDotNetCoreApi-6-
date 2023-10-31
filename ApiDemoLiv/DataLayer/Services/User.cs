using ApiDemoLiv.DataLayer.Interface;
using ApiDemoLiv.datamodel;
using ApiDemoLiv.Response;
using ApiDemoLiv.VMmodels;
using System.Text;
using XSystem.Security.Cryptography;

namespace ApiDemoLiv.DataLayer.Services
{
    public class User : IUserService
    {


         private readonly DemoLive2Context _db;
         ApiResponse _apiResponse; 
        public User(DemoLive2Context db)
        {
            _db = db;
            _apiResponse = new ApiResponse();

        }

        public ApiResponse Login(LoginVm loginVm)
        {
            var user = _db.TblUsers.FirstOrDefault(x => x.UserName == loginVm.UserName);

            if (user != null)
            {
                var hashedPassword = EncodePassword(loginVm.Password);

                if (hashedPassword == user.Password)
                {

                    _apiResponse.statusCode = 200;
                    _apiResponse.message = "Login successful";
                    _apiResponse.Success = true;
                }
                else
                {
                    _apiResponse.statusCode = 401;
                    _apiResponse.message = "Login failed. Inv alid credentials.";
                    _apiResponse.Success = false;
                }
            }
            else
            {
                _apiResponse.statusCode =404;
                _apiResponse.message = "Login failed. User not found.";
             _apiResponse.Success = false;
            }

            return _apiResponse;
        }

    
        public ApiResponse Registration(SignUpVM signUpVM)
        {
            var user = _db.TblUsers.FirstOrDefault(x => x.UserId == signUpVM.UserId);
            if (user == null)
            {
                TblUser tblUser = new TblUser();
                tblUser.UserName = signUpVM.UserName;
                tblUser.Password = EncodePassword(signUpVM.Password);
                tblUser.Email = signUpVM.Email;
                tblUser.UserType = "User";
                tblUser.Name = signUpVM.Name;
                tblUser.Address = signUpVM.Address;
                _db.TblUsers.Add(tblUser);
                _db.SaveChanges();
                _apiResponse.statusCode = 200;
                _apiResponse.message = "Registration Successful";

            }
            else
            {
                _apiResponse.statusCode = 201;
                _apiResponse.message = "User with the same ID already exists";
            }

            return _apiResponse;
        }


        public string EncodePassword(string pass)
        {
           
            Byte[] originalBytes;
            Byte[] encodedBytes;

            MD5 md5;
            md5 = new MD5CryptoServiceProvider();
            originalBytes = ASCIIEncoding.Default.GetBytes(pass);
            encodedBytes = md5.ComputeHash(originalBytes);
            return BitConverter.ToString(encodedBytes);
        }



    }


}

