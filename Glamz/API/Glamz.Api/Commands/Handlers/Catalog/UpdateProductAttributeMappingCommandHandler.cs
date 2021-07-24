﻿using Glamz.Api.DTOs.Catalog;
using Glamz.Api.Extensions;
using Glamz.Business.Catalog.Interfaces.Products;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Glamz.Api.Commands.Models.Catalog
{
    public class UpdateProductAttributeMappingCommandHandler : IRequestHandler<UpdateProductAttributeMappingCommand, ProductAttributeMappingDto>
    {
        private readonly IProductAttributeService _productAttributeService;

        public UpdateProductAttributeMappingCommandHandler(IProductAttributeService productAttributeService)
        {
            _productAttributeService = productAttributeService;
        }

        public async Task<ProductAttributeMappingDto> Handle(UpdateProductAttributeMappingCommand request, CancellationToken cancellationToken)
        {
            //insert mapping
            var productAttributeMapping = request.Model.ToEntity();
            await _productAttributeService.UpdateProductAttributeMapping(productAttributeMapping, request.Product.Id, true);

            return productAttributeMapping.ToModel();
        }
    }
}
