using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using mootableProject.Shared.Entities.Concrete;
using mootableProject.Shared.Entities.Dtos;
using MootableSpace.Business.Abstract;
using MootableSpace.Web.Helpers.Abstract;
using MootableSpace.Web.Models;

namespace MootableSpace.Web.Controllers
{
    public class UserController : Controller
    {
        private readonly UserManager<User> _userMAnager;
        private readonly SignInManager<User> _signInManager;
        private readonly IMootService _mootService;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IMapper _mapper;
        private readonly IImageHelper _imageHelper;

        public UserController(UserManager<User> userMAnager, SignInManager<User> signInManager,
             IHttpContextAccessor contextAccessor, IMootService mootService)
        {
            _userMAnager = userMAnager;
            _signInManager = signInManager;
            _contextAccessor = contextAccessor;
            _mootService = mootService;
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
            model.FirstName = user.FirstName;
            model.LastName = user.LastName;
            model.DtoList = _mootService.FetchAllDtosByUserId(user.Id);
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
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home", new { Area = "" });
        }
        [Authorize]
        [HttpGet]
        public async Task<ViewResult> ChangeDetails()
        {
            var user = await _userMAnager.GetUserAsync(HttpContext.User);
            var updateDto = new UserDto
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                UserName = user.UserName,
                PhoneNumber = user.PhoneNumber
            };
            return View(updateDto);
        }
        [Authorize]
        [HttpPost]
        public async Task<ViewResult> ChangeDetails(UserDto userDto)
        {
            var oldUser = await _userMAnager.GetUserAsync(HttpContext.User);
            //var updatedUser = new User
            //{
            //    Id = oldUser.Id,
            //    FirstName = userDto.FirstName,
            //    LastName = userDto.LastName,
            //    Email = userDto.Email,
            //    Gender = userDto.Gender,
            //    UserName = userDto.UserName,
            //    PhoneNumber = userDto.PhoneNumber,

            //    AccessFailedCount=oldUser.AccessFailedCount,
            //    ConcurrencyStamp=oldUser.ConcurrencyStamp,
            //    EmailConfirmed=oldUser.EmailConfirmed,
            //    LockoutEnabled=oldUser.LockoutEnabled,
            //    LockoutEnd=oldUser.LockoutEnd,
            //    NormalizedEmail=oldUser.NormalizedEmail,
            //    NormalizedUserName=userDto.UserName.ToUpper(),
            //    PhoneNumberConfirmed=oldUser.PhoneNumberConfirmed,
            //    PasswordHash=oldUser.PasswordHash,
            //    SecurityStamp=oldUser.SecurityStamp,
            //    TwoFactorEnabled=oldUser.TwoFactorEnabled,
            //};
            var updatedUser = _mapper.Map<UserDto, User>(userDto, oldUser);
            if (oldUser != null)
            {
                var result = await _userMAnager.UpdateAsync(updatedUser);
                if (result.Succeeded)
                {
                    TempData.Add("SuccessMessage", $"{updatedUser.FirstName} adlı kullanıcı başarıyla güncellenmiştir.");
                    return View(userDto);
                }
                else
                {
                    foreach (var err in result.Errors)
                    {
                        ModelState.AddModelError("", err.Description);
                    }
                    return View(userDto);
                }
            }
            return View(userDto);
        }
        [Authorize]
        [HttpGet]
        public ViewResult PasswordChange()
        {
            return View();
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> PasswordChange(UserPasswordChangeDto dto)
        {
            if (ModelState.IsValid)
            {
                var user = await _userMAnager.GetUserAsync(HttpContext.User);
                var isVerify = await _userMAnager.CheckPasswordAsync(user, dto.CurrentPassword);
                if (isVerify)
                {
                    var result = await _userMAnager.ChangePasswordAsync(user, dto.CurrentPassword, dto.NewPassword);
                    if (result.Succeeded)
                    {
                        await _userMAnager.UpdateSecurityStampAsync(user);
                        await _signInManager.SignOutAsync();
                        await _signInManager.PasswordSignInAsync(user, dto.NewPassword, true, false);
                        TempData.Add("SuccessMessage", $"Şifreniz başarıyla güncellenmiştir");
                        return View();
                    }
                    else
                    {
                        foreach (var err in result.Errors)
                        {
                            ModelState.AddModelError("", err.Description);
                        }
                        return View(dto);
                    }
                }
                else // eğer verify olmazsa
                {
                    ModelState.AddModelError("", $"Lütfen girmiş olduğunuz şuanki şifrenizi kontrol ediniz.");
                    return View(dto);
                }
            }
            else
            {
                return View(dto);
            }
        }
    }
}
