﻿using Glamz.Api.DTOs.Catalog;
using MediatR;

namespace Glamz.Api.Commands.Models.Catalog
{
    public class AddProductAttributeCommand : IRequest<ProductAttributeDto>
    {
        public ProductDto Product { get; set; }
        public ProductAttributeDto Model { get; set; }
    }
}
