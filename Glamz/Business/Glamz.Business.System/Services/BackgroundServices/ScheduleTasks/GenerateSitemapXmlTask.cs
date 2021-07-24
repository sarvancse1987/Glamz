﻿using Glamz.Business.Common.Interfaces.Localization;
using Glamz.Business.Common.Interfaces.Stores;
using Glamz.Business.Storage.Interfaces;
using Glamz.Business.System.Commands.Models.Common;
using Glamz.Business.System.Interfaces.ScheduleTasks;
using MediatR;
using System.Threading.Tasks;

namespace Glamz.Business.System.Services.BackgroundServices.ScheduleTasks
{
    /// <summary>
    /// Represents a task end auctions
    /// </summary>
    public partial class GenerateSitemapXmlTask : IScheduleTask
    {
        private readonly IMediator _mediator;
        private readonly ILanguageService _languageService;
        private readonly IStoreService _storeService;
        private readonly IMediaFileStore _mediaFileStore;

        public GenerateSitemapXmlTask(IMediator mediator,
            ILanguageService languageService,
            IStoreService storeService,
            IMediaFileStore mediaFileStore)
        {
            _mediator = mediator;
            _languageService = languageService;
            _storeService = storeService;
            _mediaFileStore = mediaFileStore;
        }

        /// <summary>
        /// Executes a task
        /// </summary>
        public async Task Execute()
        {
            var stores = await _storeService.GetAllStores();
            var languages = await _languageService.GetAllLanguages();

            var file = "sitemap.xml";

            foreach (var store in stores)
            {
                var storelanguages = await _languageService.GetAllLanguages(storeId: store.Id);
                foreach (var lang in storelanguages)
                {
                    var siteMap = await _mediator.Send(new GetSitemapXmlCommand()
                    {
                        Language = lang,
                        Store = store,
                    });

                    if (!(stores.Count == 1 && languages.Count == 1))
                        file = $"sitemap-{store.Shortcut}-{lang.UniqueSeoCode}.xml";

                    await _mediaFileStore.WriteAllText(file, siteMap);
                }
            }
        }
    }
}