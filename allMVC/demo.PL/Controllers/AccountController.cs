using demo.PL.Helpers;
using demo.PL.ViewModel;
using Demo.DAL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace demo.PL.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _singInManager;

        public AccountController(UserManager<ApplicationUser> userManager,SignInManager<ApplicationUser> singInManager)
        {
           _userManager = userManager;
            _singInManager = singInManager;
        }
        public IActionResult Signup()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Signup(SignupViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser()
                {
                    UserName = model.Email.Split("@")[0],
                    Email = model.Email,
                    Fname = model.Fname,
                    Lname = model.Lname,
                    PasswordHash = model.Password,
                    IsAgree = model.IsAgree
                };
                var result=await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction(nameof(signin));
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return View();
        }
        public IActionResult signin()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> signin(signinViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user= await _userManager.FindByEmailAsync(model.Email);
                if (user != null)
                {
                    bool flag =await _userManager.CheckPasswordAsync(user,model.Password);
                    if (flag)
                    {
                        var result = await _singInManager.PasswordSignInAsync(user, model.Password, model.RemeberMe, false);
                        if (result.Succeeded)
                        {
                            return RedirectToAction(nameof(HomeController.Index),"home");
                        }
                    }
                }
            }
            else
            {
                ModelState.AddModelError(string.Empty, "invalid Login");
                
            }
            return View(model);
        }
        public async Task<IActionResult> logOut()
        {
            await _singInManager.SignOutAsync();
            return RedirectToAction(nameof(signin));
        }
        [HttpGet]
        public IActionResult forgetPass()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> forgetPass(ForgetPass model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                if (user is not null)
                {
                    var token=_userManager.GeneratePasswordResetTokenAsync(user);
                    var resetPassUrl = Url.Action("resetPass", "Account", new { email = model.Email ,token=token},Request.Scheme);
                    var email = new Email()
                    {
                        Subject = "Reset you Password",
                        Recipients = model.Email,
                        Body = resetPassUrl
                    };
                    EmailSetting.SendEmail(email);
                    return RedirectToAction(nameof(checkYourInbox));
                }
            }
            ModelState.AddModelError("", "Invalid Email");
            return View(model);

        }
        public IActionResult checkYourInbox()
        {
            return View();
        }
        [HttpGet]
        public IActionResult resetPass(string email,string token)
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> resetPass(resetPassViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _userManager.FindByEmailAsync(model.Email);
                if (result is not null)
                {
                    var user = await _userManager.ResetPasswordAsync(result, model.token, model.Password);
                    if (user.Succeeded)
                    {
                        return RedirectToAction(nameof(signin));
                    }
                    ModelState.AddModelError(" ", "error has happend");
                    return View(model);
                }
                ModelState.AddModelError("", "invalid data");
                return View(model);
            }
            return View(model);
        }
    }
}
