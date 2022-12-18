using Cheapla.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cheapla.Business.Services
{
    public interface ICartService
    {
        void InitializeCart(int userId);
        CartEntity GetCartByUserId(int userId);
        void AddToCart(int userId, int productId, int quantity);
        void DeleteFromCart(int userId, int productId);

       

    }
}
