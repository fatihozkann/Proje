using Cheapla.Business.Services;
using Cheapla.Business.Types;
using Cheapla.Data.Dto;
using Cheapla.Data.Entities;
using Cheapla.Data.Repositories;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cheapla.Business.Managers
{
    public class CommentManager : ICommentService
    {
        private readonly IRepository<CommentEntity> _commentRepository;

        public CommentManager(IRepository<CommentEntity> commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public ServiceMessage AddComment(CommentDto comment)
        {
            var commentEntity = new CommentEntity
            {
               CommentUserName = comment.UserName,
                Id = comment.Id,
                CommentContent = comment.CommentContent,
                Date = DateTime.Now,
                ProductId=comment.ProductId,
                UserId=comment.UserId,
              
                
            };


            _commentRepository.Add(commentEntity);


            return new ServiceMessage
            {
                IsSucceed = true
            };
        }

        public void DeleteComment(int id)
        {
            _commentRepository.Delete(id);
        }

     

        public CommentDto GetCommentById(int id)
        {
            var commentEntity = _commentRepository.GetById(id);

            var commentDto = new CommentDto
            {
                Id = commentEntity.Id,

                UserName = commentEntity.CommentUserName,

                CommentContent = commentEntity.CommentContent
            };

            return commentDto;
        }

        public List<CommentDto> GetComments(int? productId = null)
        {
            var query = _commentRepository.GetAll();

            if (productId.HasValue)
            {
                query = query.Where(x => x.ProductId == productId.Value);
            }
            var productEntities = query.OrderBy(x => x.CreatedDate);



            var commentList = productEntities.Select(x => new CommentDto
            {
                Id = x.Id,
                CommentContent = x.CommentContent,
                UserName = x.CommentUserName,
                Date = DateTime.Now,
                
                
            }).ToList();

            return commentList;
        }
    }
}
