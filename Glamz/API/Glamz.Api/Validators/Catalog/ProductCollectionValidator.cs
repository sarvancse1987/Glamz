using FluentValidation;
using Glamz.Api.DTOs.Catalog;
using Glamz.Business.Catalog.Interfaces.Collections;
using Glamz.Business.Common.Interfaces.Localization;
using Glamz.Infrastructure.Validators;
using System.Collections.Generic;

namespace Glamz.Api.Validators.Catalog
{
    public class ProductCollectionValidator : BaseGrandValidator<ProductCollectionDto>
    {
        public ProductCollectionValidator(IEnumerable<IValidatorConsumer<ProductCollectionDto>> validators,
            ITranslationService translationService, ICollectionService collectionService)
            : base(validators)
        {
            RuleFor(x => x).MustAsync(async (x, y, context) =>
            {
                var collection = await collectionService.GetCollectionById(x.CollectionId);
                if (collection == null)
                    return false;
                return true;
            }).WithMessage(translationService.GetResource("Api.Catalog.ProductCollection.Fields.CollectionId.NotExists"));
        }
    }
}
