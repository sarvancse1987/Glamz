﻿using FluentValidation;
using Glamz.Api.DTOs.Catalog;
using Glamz.Business.Catalog.Interfaces.Categories;
using Glamz.Business.Common.Interfaces.Localization;
using Glamz.Business.Storage.Interfaces;
using Glamz.Infrastructure.Validators;
using System.Collections.Generic;

namespace Glamz.Api.Validators.Catalog
{
    public class CategoryValidator : BaseGrandValidator<CategoryDto>
    {
        public CategoryValidator(IEnumerable<IValidatorConsumer<CategoryDto>> validators,
            ITranslationService translationService, IPictureService pictureService, ICategoryService categoryService, ICategoryLayoutService
            categoryLayoutService) : base(validators)
        {

            RuleFor(x => x.Name).NotEmpty().WithMessage(translationService.GetResource("Api.Catalog.Category.Fields.Name.Required"));
            RuleFor(x => x).MustAsync(async (x, y, context) =>
            {
                if (!string.IsNullOrEmpty(x.PictureId))
                {
                    var picture = await pictureService.GetPictureById(x.PictureId);
                    if (picture == null)
                        return false;
                }
                return true;
            }).WithMessage(translationService.GetResource("Api.Catalog.Category.Fields.PictureId.NotExists"));

            RuleFor(x => x).MustAsync(async (x, y, context) =>
            {
                if (!string.IsNullOrEmpty(x.ParentCategoryId))
                {
                    var category = await categoryService.GetCategoryById(x.ParentCategoryId);
                    if (category == null)
                        return false;
                }
                return true;
            }).WithMessage(translationService.GetResource("Api.Catalog.Category.Fields.ParentCategoryId.NotExists"));

            RuleFor(x => x).MustAsync(async (x, y, context) =>
            {
                if (!string.IsNullOrEmpty(x.CategoryLayoutId))
                {
                    var layout = await categoryLayoutService.GetCategoryLayoutById(x.CategoryLayoutId);
                    if (layout == null)
                        return false;
                }
                return true;
            }).WithMessage(translationService.GetResource("Api.Catalog.Category.Fields.CategoryLayoutId.NotExists"));

            RuleFor(x => x).MustAsync(async (x, y, context) =>
            {
                if (!string.IsNullOrEmpty(x.Id))
                {
                    var category = await categoryService.GetCategoryById(x.Id);
                    if (category == null)
                        return false;
                }
                return true;
            }).WithMessage(translationService.GetResource("Api.Catalog.Category.Fields.Id.NotExists"));
        }
    }
}
