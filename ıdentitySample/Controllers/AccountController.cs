using ıdentitySample.Context;
using ıdentitySample.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace ıdentitySample.Controllers
{
    public class AccountController : Controller
    {

        private readonly SignInManager<AppUser> _signinManger;
        private readonly UserManager<AppUser> _userManager;


        public AccountController(SignInManager<AppUser> signinManger, UserManager<AppUser> userManager)
        {
            _signinManger = signinManger;
            _userManager = userManager;
        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel vm)
        {


            var data =  await _userManager.FindByNameAsync(vm.UserName);
            if (data!=null)
            {

                
             
                var result = await _signinManger.PasswordSignInAsync(data, vm.Password, false, true);

                if (result.IsLockedOut)
                {
                    //sen şu kadar süre giremezsin


                    ViewBag.ErrorMessage = data.LockoutEnd.ToString();
                    return View();
                }

                if (!result.Succeeded)
                {
                   


                   await  _userManager.AccessFailedAsync(data);

                  var count = await  _userManager.GetAccessFailedCountAsync(data);

                    ViewBag.ErrorMessage = "kullanıcı adı yada şifre hatalı "+count+" kere hatalı giriş yaptın" ;
                    //ya username yada şifre
                    return View();
                }

             


                return Redirect("/");
            }

            ViewBag.ErrorMessage = "kullanıcı adı yada şifre hatalı";
            return View();
        }
        public IActionResult Register()
        {
            //_userManager.CreateAsync();
            return View();  
        }

        [HttpPost]
        public async Task<IActionResult> Register(SignUpViewModel vm)
        {
            //_userManager.CreateAsync();


           var result =   await _userManager.CreateAsync(new()
             {
                Email= vm.Email,    
                UserName=vm.UserName,

            },vm.Password);


            if (!result.Succeeded)
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
            }

            return View();
        }



        public async Task<IActionResult> Logout()
        {
           


            await _signinManger.SignOutAsync();

            return Redirect("/");
        }

    }
}
