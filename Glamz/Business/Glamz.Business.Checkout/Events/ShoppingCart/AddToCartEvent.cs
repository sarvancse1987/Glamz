﻿using Glamz.Domain.Catalog;
using Glamz.Domain.Customers;
using Glamz.Domain.Orders;
using MediatR;

namespace Glamz.Business.Checkout.Events.ShoppingCart
{
    public class AddToCartEvent : INotification
    {
        private readonly Product _product;
        private readonly Customer _customer;
        private readonly ShoppingCartItem _shoppingCartItem;

        public AddToCartEvent(Customer customer, ShoppingCartItem shoppingCartItem, Product product)
        {
            _customer = customer;
            _shoppingCartItem = shoppingCartItem;
            _product = product;
        }

        public Customer Customer { get { return _customer; } }
        public ShoppingCartItem ShoppingCartItem { get { return _shoppingCartItem; } }
        public Product Product { get { return _product; } }

    }
}
