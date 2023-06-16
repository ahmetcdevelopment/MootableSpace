using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using mootableProject.Shared.Entities.Concrete;
using mootableProject.Shared.Entities.Dtos;
using MootableSpace.Web.Helpers.Abstract;
using MootableSpace.Web.Models;

namespace MootableSpace.Web.Controllers
{
    public class UserController : Controller
    {
        private readonly UserManager<User> _userMAnager;
        private readonly SignInManager<User> _signInManager;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IMapper _mapper;
        private readonly IImageHelper _imageHelper;

        public UserController(UserManager<User> userMAnager, SignInManager<User> signInManager,
             IHttpContextAccessor contextAccessor)
        {
            _userMAnager = userMAnager;
            _signInManager = signInManager;
            _contextAccessor = contextAccessor;
        }
        /// <summary>
        /// Authorize ekleyeceğiz.
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = "Admin,Editor,User")]
        public async Task<IActionResult> Index()
        {
            var model = new UserViewModel();
            var user = await _userMAnager.GetUserAsync(HttpContext.User);
            model.Id = user.Id;
            model.UserName = user.UserName;
            model.FirstName= user.FirstName;
            model.LastName= user.LastName;
            return View(model);
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View("UserLogin");
        }
        [HttpPost]
        public async Task<IActionResult> Login(UserLoginDto dto)
        {
            if (ModelState.IsValid)
            {
                var user = await _userMAnager.FindByEmailAsync(dto.Email);
                if (user != null)
                {
                    var result = await _signInManager.PasswordSignInAsync(user, dto.Password,
                        dto.RememberMe, false);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError("", "E-Posta adresiniz veya şifreniz yanlıştır.");
                        return View("UserLogin");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "E-Posta adresiniz veya şifreniz yanlıştır.");
                    return View("UserLogin");
                }
            }
            else
            {
                return View("UserLogin");
            }
        }
    }
}
