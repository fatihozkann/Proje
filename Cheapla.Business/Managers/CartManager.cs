using Cheapla.Business.Managers;
using Cheapla.Business.Services;
using Cheapla.Data.Entities;
using Cheapla.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cheapla.Business.Managers
{
    public class CartManager : ICartService
    {
        private readonly IRepository<CartEntity> _cartRepository;

        public CartManager(IRepository<CartEntity> cartRepository)
        {
            _cartRepository = cartRepository;
        }

        public async void AddToCart(int userId, int productId, int quantity)
        {
            var cart = GetCartByUserId(userId);
            if (cart != null)
            {
                var index = cart.CartItems.FindIndex(i => i.ProductId == productId);

                if (index < 0)
                {
                    cart.CartItems.Add(new CartItemEntity()
                    {
                        ProductId = productId,
                        Quantity = quantity,
                        CartId = cart.Id
                    });
                }

                else
                {
                    cart.CartItems[index].Quantity += quantity;
                }

                
                _cartRepository.CartUpdate(cart);
            }
        }


        public void DeleteFromCart(int userId, int productId)
        {
            var cart = GetCartByUserId(userId);
            if (cart != null)
            {
                var cardId = cart.Id;
                _cartRepository.DeleteFromCart(cart.Id, productId);
            }
        }

        public CartEntity GetCartByUserId(int userId)
        {
            return _cartRepository.GetByUserrId(userId);
        }

        public void InitializeCart(int userId)
        {
            _cartRepository.Add(new CartEntity() { UserId = userId });
        }
    }
}
