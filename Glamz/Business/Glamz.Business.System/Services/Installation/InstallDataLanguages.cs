﻿using Glamz.Business.System.Interfaces.Installation;
using Glamz.Domain.Localization;
using System.Threading.Tasks;

namespace Glamz.Business.System.Services.Installation
{
    public partial class InstallationService : IInstallationService
    {
        protected virtual async Task InstallLanguages()
        {
            var language = new Language
            {
                Name = "English",
                LanguageCulture = "en-US",
                UniqueSeoCode = "en",
                FlagImageFileName = "us.png",
                Published = true,
                DisplayOrder = 1
            };
            await _languageRepository.InsertAsync(language);
        }
    }
}
