using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using mootableProject.Shared.Entities.Concrete;
using mootableProject.Shared.Results.ComplexTypes;
using mootableProject.Shared.Results.Concrete;
using MootableSpace.Business.Abstract;
using MootableSpace.Entities.Concrete;
using MootableSpace.Web.Models;
using System.Diagnostics;

namespace MootableSpace.Web.Controllers
{
    [Authorize(Roles = "Admin,Editor,User")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMootService _mootService;
        private readonly UserManager<User> _userService;
        private readonly ICategoryService _categoryService;
        private readonly ICommentService _commentService;
        public HomeController(ILogger<HomeController> logger, IMootService mootService,
            UserManager<User> userService, ICategoryService categoryService,ICommentService commentService)
        {
            _logger = logger;
            _mootService = mootService;
            _userService = userService;
            _categoryService = categoryService;
            _commentService = commentService;
        }

        public IActionResult Index()
        {
            MootViewModel model = new MootViewModel();
            model.DtoList = _mootService.FetchAllDtos().ToList();
            model.EditModel = new MootEditViewModel();
            model.EditModel.Categories = _categoryService.GetAllBySelectListItems();
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> Share(int? id)
        {
            var model = new MootEditViewModel();
            model.Categories = _categoryService.GetAllBySelectListItems();
            if (id.HasValue)
            {
                var result = await _mootService.SelectById(id.Value);
                if (result.ResultStatus == ResultStatus.Success && result.Data != null)
                {
                    var entity = result.Data;
                    model.Id = entity.Id;
                    model.UserId = entity.UserId;
                    model.CategoryId =entity.CategoryId;
                    model.Text = entity.Text;
                    model.ShareStatus = entity.ShareStatus;
                    model.AgreeCount = entity.AgreeCount;
                    model.CommentCount = entity.CommentCount;
                    model.Picture = entity.Picture;
                    model.ViewCount = entity.ViewCount;
                    model.ShareDate = entity.ShareDate;
                }
            }
            return PartialView(model);
        }
        [HttpPost]
        public async Task<IActionResult> Share(MootEditViewModel model)
        {
            var user = await _userService.GetUserAsync(HttpContext.User);
            //if (ModelState.IsValid)
            //{
                var entity = new Moot();
                entity.Id = model.Id;
                entity.UserId = user.Id != 0 && user.Id >= 0 ? user.Id : 0;
                entity.CategoryId =model.CategoryId;
                entity.Text = model.Text;
                entity.ShareStatus = 1;
                entity.AgreeCount = 0;
                entity.CommentCount = 0;
                entity.Picture = model.Picture;
                entity.ViewCount = 0;
                entity.ShareDate = DateTime.Now;
                entity.ModifiedById = user.Id != 0 && user.Id >= 0 ? user.Id : 0;
                entity.ModifiedDate = DateTime.Now;
                entity.IsDeleted = false;
                await _mootService.Save(entity);
                return Json(entity);
            //}
            //var result = new Result(ResultStatus.Error, "Lütfen tüm alanları doldurunuz.");
            //return Json(result);
        }
        [HttpGet]
        public async Task<IActionResult> CommentEdit(int mootId,int? parentId,int? commentId)
        {
            var model = new CommentEditViewModel();
            var result = await _mootService.SelectById(mootId);
            if (commentId.HasValue)
            {
                var comment = await _commentService.SelectById(commentId.Value);
                model.Text = comment.Data.Text;
                model.Id = comment.Data.Id;
            }
            
            var user = await _userService.GetUserAsync(HttpContext.User);
            if (result.Data!=null)
            {
                var entity = result.Data;
                model.UserId = user.Id;
                model.MootId=mootId;
                model.ParentId = parentId != 0 && parentId >= 0 ? parentId : 0;
                model.ViewCount = 0;
                model.AgreeCount = 0;
            }
            return PartialView(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}