using Cheapla.Business.Services;
using Cheapla.WebUI.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;

namespace Cheapla.WebUI.Areas.Admin.Controllers
{
    public class CommentController : BaseController
    {
        private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService=commentService;
        }


        public IActionResult Index()
        {
            var commentList = _commentService.GetComments();

            var ViewModel = commentList.Select(x => new CommentViewModel
            {
                Id = x.Id,
              UserName=x.UserName,
              CommentContent=x.CommentContent,  
            }).ToList();

            return View(ViewModel);
        }
        public IActionResult Delete(int id)
        {
            _commentService.DeleteComment(id);
            return RedirectToAction("Index");
        }
    }
}
