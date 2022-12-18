using Cheapla.Business.Services;
using Cheapla.WebUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace Cheapla.WebUI.ViewComponents
{
    public class CommentsViewComponent : ViewComponent
    {
        private readonly ICommentService _commentService;


        public CommentsViewComponent(ICommentService commentService)
        {
            _commentService = commentService;
        }

        public IViewComponentResult Invoke()
        {



            var commentList = _commentService.GetComments();

            var ViewModel = commentList.Select(x => new CommentViewModel
            {
                Id = x.Id,
                UserName = x.UserName,
                CommentContent = x.CommentContent,
            }).ToList();

            return View(ViewModel);
        }
    }
}
