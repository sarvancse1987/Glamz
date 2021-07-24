using FluentValidation;
using Glamz.Api.DTOs.Catalog;
using Glamz.Business.Catalog.Interfaces.Products;
using Glamz.Business.Common.Interfaces.Localization;
using Glamz.Infrastructure.Validators;
using System.Collections.Generic;

namespace Glamz.Api.Validators.Catalog
{
    public class ProductSpecificationAttributeValidator : BaseGrandValidator<ProductSpecificationAttributeDto>
    {
        public ProductSpecificationAttributeValidator(
            IEnumerable<IValidatorConsumer<ProductSpecificationAttributeDto>> validators,
            ITranslationService translationService, ISpecificationAttributeService specificationAttributeService)
            : base(validators)
        {
            RuleFor(x => x).MustAsync(async (x, y, context) =>
            {
                var specification = await specificationAttributeService.GetSpecificationAttributeById(x.SpecificationAttributeId);
                if (specification == null)
                    return false;
                return true;
            }).WithMessage(translationService.GetResource("Api.Catalog.ProductSpecificationAttribute.Fields.SpecificationAttributeId.NotExists"));

            RuleFor(x => x).MustAsync(async (x, y, context) =>
            {
                if (!string.IsNullOrEmpty(x.SpecificationAttributeOptionId))
                {
                    var sa = await specificationAttributeService.GetSpecificationAttributeByOptionId(x.SpecificationAttributeOptionId);
                    if (sa == null)
                        return false;
                }
                return true;
            }).WithMessage(translationService.GetResource("Api.Catalog.ProductSpecificationAttribute.Fields.SpecificationAttributeOptionId.NotExists"));
        }
    }
}
