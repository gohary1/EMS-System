using demo.PL.ViewModel;
using Demo.DAL.Migrations;
using Demo.DAL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace demo.PL.Controllers
{
    public class UserController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserController(UserManager<ApplicationUser> userManager,RoleManager<IdentityRole> roleManager)
        {
             _userManager=userManager ;
            _roleManager = roleManager;
        }
        public async Task<IActionResult> Index(string email)
        {
            List<UsersViewModel> user;
            if (string.IsNullOrEmpty(email))
            {

                user = await _userManager.Users.Select( x => new UsersViewModel()
                {
                    Id=x.Id,
                    Email = x.Email,
                    FName = x.Fname,
                    LName = x.Lname,
                    phoneNumber = x.PhoneNumber                  
                }).ToListAsync();
                return View(user);
            }
            else
            {
                var findedUser= await _userManager.Users.Where(u=>u.Email.Trim().ToLower().Contains(email.Trim().ToLower())).ToListAsync();
                if (findedUser != null)
                {
                    user = findedUser.Select(u => new UsersViewModel
                    {
                        Id = u.Id,
                        Email = u.Email,
                        FName = u.Fname,
                        LName = u.Lname,
                        phoneNumber = u.PhoneNumber
                    }).ToList();
                    return View(user);
                }
                else
                {
                    return View();
                }
            }

        }

        public async Task<IActionResult> details(string id)
        {
            if (id != null)
            {
                var user = await _userManager.FindByIdAsync(id);
                if (user != null)
                {
                    UsersViewModel result = new UsersViewModel()
                    {
                        Id = user.Id,
                        Email = user.Email,
                        LName = user.Lname,
                        phoneNumber = user.PhoneNumber,
                        FName = user.Fname,
                    };
                    return View(result);
                }
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> update(string id)
        {
            if (id != null)
            {
                var user=await _userManager.FindByIdAsync(id);
                if (user != null)
                {
                    UsersViewModel update = new UsersViewModel()
                    {
                        Id=user.Id,
                        Email = user.Email,
                        LName = user.Lname,
                        FName=user.Fname,
                        phoneNumber=user.PhoneNumber,
                    };
                    return View(update);
                }
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> update(UsersViewModel model)
        {
            if (ModelState.IsValid)
            {
                var existingUser = await _userManager.FindByIdAsync(model.Id);

                if (existingUser != null)
                {
                    existingUser.Email = model.Email;
                    existingUser.Fname = model.FName;
                    existingUser.Lname = model.LName;
                    existingUser.PhoneNumber = model.phoneNumber;
                    existingUser.UserName = model.Email.Split("@")[0];
                    var updated= await _userManager.UpdateAsync(existingUser);
                if (updated.Succeeded)
                {
                    return RedirectToAction(nameof(Index));
                }  
                }
                             
            }
            return View(model);
        }
        public async Task<IActionResult> delete(string id)
        {
            if (id != null)
            {
                var user=await _userManager.FindByIdAsync(id);
                if (user != null)
                {
                    var result=await _userManager.DeleteAsync(user);
                    if (result.Succeeded)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                }
            }
            return View();
        }
    }
}
