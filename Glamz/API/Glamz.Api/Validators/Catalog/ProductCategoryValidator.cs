﻿using FluentValidation;
using Glamz.Api.DTOs.Catalog;
using Glamz.Business.Catalog.Interfaces.Categories;
using Glamz.Business.Common.Interfaces.Localization;
using Glamz.Infrastructure.Validators;
using System.Collections.Generic;

namespace Glamz.Api.Validators.Catalog
{
    public class ProductCategoryValidator : BaseGrandValidator<ProductCategoryDto>
    {
        public ProductCategoryValidator(IEnumerable<IValidatorConsumer<ProductCategoryDto>> validators, ITranslationService translationService, ICategoryService categoryService)
            : base(validators)
        {
            RuleFor(x => x).MustAsync(async (x, y, context) =>
            {
                var category = await categoryService.GetCategoryById(x.CategoryId);
                if (category == null)
                    return false;
                return true;
            }).WithMessage(translationService.GetResource("Api.Catalog.ProductCategory.Fields.CategoryId.NotExists"));
        }
    }
}
