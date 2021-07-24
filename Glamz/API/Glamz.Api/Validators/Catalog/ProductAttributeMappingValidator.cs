using FluentValidation;
using Glamz.Api.DTOs.Catalog;
using Glamz.Business.Catalog.Interfaces.Products;
using Glamz.Business.Common.Interfaces.Localization;
using Glamz.Infrastructure.Validators;
using System.Collections.Generic;

namespace Glamz.Api.Validators.Catalog
{
    public class ProductAttributeMappingValidator : BaseGrandValidator<ProductAttributeMappingDto>
    {
        public ProductAttributeMappingValidator(
            IEnumerable<IValidatorConsumer<ProductAttributeMappingDto>> validators,
            ITranslationService translationService, IProductAttributeService productAttributeService)
            : base(validators)
        {
            RuleFor(x => x).MustAsync(async (x, y, context) =>
            {
                var productattribute = await productAttributeService.GetProductAttributeById(x.ProductAttributeId);
                if (productattribute == null)
                    return false;
                return true;
            }).WithMessage(translationService.GetResource("Api.Catalog.ProductAttributeMapping.Fields.ProductAttributeId.NotExists"));
        }
    }
}
