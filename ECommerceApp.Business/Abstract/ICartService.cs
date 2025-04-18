﻿using ECommerce.Entities.Concrete;
using ECommerce.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.Business.Abstract
{
    public interface ICartService
    {
        void AddToCart(Cart cart, Product product);
        List<CartLine>? List(Cart cart);
        void RemoveFromCart(Cart cart,int productId);
        void Decrement(Cart cart,int productId);
        void Increment(Cart cart, int productId);
    }
}
