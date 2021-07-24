﻿using MediatR;
using System.Linq;

namespace Glamz.Api.Queries.Models.Common
{
    public class GetQuery<T> : IRequest<IQueryable<T>> where T : class
    {
        public string Id { get; set; }
    }
}
