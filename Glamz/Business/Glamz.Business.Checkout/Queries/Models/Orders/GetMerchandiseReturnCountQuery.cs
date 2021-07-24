﻿using MediatR;
namespace Glamz.Business.Checkout.Queries.Models.Orders
{
    public class GetMerchandiseReturnCountQuery : IRequest<int>
    {
        public int RequestStatusId { get; set; }
        public string StoreId { get; set; }
    }
}
