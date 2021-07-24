﻿using Glamz.Api.DTOs.Catalog;
using Glamz.Api.Extensions;
using Glamz.Business.Catalog.Interfaces.Categories;
using Glamz.Business.Common.Extensions;
using Glamz.Business.Common.Interfaces.Localization;
using Glamz.Business.Common.Interfaces.Logging;
using Glamz.Business.Common.Interfaces.Seo;
using Glamz.Domain.Seo;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Glamz.Api.Commands.Models.Catalog
{
    public class AddCategoryCommandHandler : IRequestHandler<AddCategoryCommand, CategoryDto>
    {
        private readonly ICategoryService _categoryService;
        private readonly ISlugService _slugService;
        private readonly ILanguageService _languageService;
        private readonly ICustomerActivityService _customerActivityService;
        private readonly ITranslationService _translationService;
        private readonly SeoSettings _seoSettings;

        public AddCategoryCommandHandler(
            ICategoryService categoryService,
            ISlugService slugService,
            ILanguageService languageService,
            ICustomerActivityService customerActivityService,
            ITranslationService translationService,
            SeoSettings seoSettings)
        {
            _categoryService = categoryService;
            _slugService = slugService;
            _languageService = languageService;
            _customerActivityService = customerActivityService;
            _translationService = translationService;
            _seoSettings = seoSettings;
        }

        public async Task<CategoryDto> Handle(AddCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = request.Model.ToEntity();
            category.CreatedOnUtc = DateTime.UtcNow;
            category.UpdatedOnUtc = DateTime.UtcNow;
            await _categoryService.InsertCategory(category);
            request.Model.SeName = await category.ValidateSeName(request.Model.SeName,
                category.Name, true, _seoSettings, _slugService, _languageService);
            category.SeName = request.Model.SeName;
            await _categoryService.UpdateCategory(category);
            await _slugService.SaveSlug(category, request.Model.SeName, "");

            //activity log
            await _customerActivityService.InsertActivity("AddNewCategory", category.Id,
                _translationService.GetResource("ActivityLog.AddNewCategory"), category.Name);

            return category.ToModel();
        }
    }
}