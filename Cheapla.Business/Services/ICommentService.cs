using Cheapla.Business.Types;
using Cheapla.Data.Dto;
using Cheapla.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cheapla.Business.Services
{
    public interface ICommentService
    {
        ServiceMessage AddComment(CommentDto comment);

        List<CommentDto> GetComments(int? productId = null);

        CommentDto GetCommentById(int id);

       

        void DeleteComment(int id);
    }
}
