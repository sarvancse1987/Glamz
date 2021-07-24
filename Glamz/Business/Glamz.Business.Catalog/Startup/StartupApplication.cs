using Glamz.Business.Catalog.Interfaces.Categories;
using Glamz.Business.Catalog.Interfaces.Discounts;
using Glamz.Business.Catalog.Interfaces.Collections;
using Glamz.Business.Catalog.Interfaces.Prices;
using Glamz.Business.Catalog.Interfaces.Products;
using Glamz.Business.Catalog.Interfaces.Tax;
using Glamz.Business.Catalog.Services.Categories;
using Glamz.Business.Catalog.Services.Discounts;
using Glamz.Business.Catalog.Services.Collections;
using Glamz.Business.Catalog.Services.Prices;
using Glamz.Business.Catalog.Services.Products;
using Glamz.Business.Catalog.Services.Tax;
using Glamz.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Glamz.Business.Catalog.Services.Brands;
using Glamz.Business.Catalog.Interfaces.Brands;

namespace Glamz.Business.Catalog.Startup
{
    public class StartupApplication : IStartupApplication
    {

        public void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            RegisterCatalogService(services);
            RegisterDiscountsService(services);
            RegisterTaxService(services);
        }

        public void Configure(IApplicationBuilder application, IWebHostEnvironment webHostEnvironment)
        {

        }
        public int Priority => 100;
        public bool BeforeConfigure => false;

        private void RegisterCatalogService(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IOutOfStockSubscriptionService, OutOfStockSubscriptionService>();
            serviceCollection.AddScoped<ICategoryService, CategoryService>();
            serviceCollection.AddScoped<IBrandService, BrandService>();
            serviceCollection.AddScoped<ICompareProductsService, CompareProductsService>();
            serviceCollection.AddScoped<IRecentlyViewedProductsService, RecentlyViewedProductsService>();
            serviceCollection.AddScoped<ICollectionService, CollectionService>();
            serviceCollection.AddScoped<IPriceFormatter, PriceFormatter>();
            serviceCollection.AddScoped<IProductAttributeFormatter, ProductAttributeFormatter>();
            serviceCollection.AddScoped<IProductAttributeParser, ProductAttributeParser>();
            serviceCollection.AddScoped<IProductAttributeService, ProductAttributeService>();
            serviceCollection.AddScoped<IProductService, ProductService>();
            serviceCollection.AddScoped<IProductCategoryService, ProductCategoryService>();
            serviceCollection.AddScoped<IProductCollectionService, ProductCollectionService>();
            serviceCollection.AddScoped<IProductReviewService, ProductReviewService>();
            serviceCollection.AddScoped<ICopyProductService, CopyProductService>();
            serviceCollection.AddScoped<IProductReservationService, ProductReservationService>();
            serviceCollection.AddScoped<IAuctionService, AuctionService>();
            serviceCollection.AddScoped<IProductCourseService, ProductCourseService>();
            serviceCollection.AddScoped<ISpecificationAttributeService, SpecificationAttributeService>();
            serviceCollection.AddScoped<IProductLayoutService, ProductLayoutService>();
            serviceCollection.AddScoped<IBrandLayoutService, BrandLayoutService>();
            serviceCollection.AddScoped<ICategoryLayoutService, CategoryLayoutService>();
            serviceCollection.AddScoped<ICollectionLayoutService, CollectionLayoutService>();
            serviceCollection.AddScoped<IProductTagService, ProductTagService>();
            serviceCollection.AddScoped<ICustomerGroupProductService, CustomerGroupProductService>();
            serviceCollection.AddScoped<IInventoryManageService, InventoryManageService>();
            serviceCollection.AddScoped<IStockQuantityService, StockQuantityService>();
            serviceCollection.AddScoped<IPricingService, PricingService>();
        }

        private void RegisterDiscountsService(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IDiscountService, DiscountService>();
        }

        private void RegisterTaxService(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<ITaxService, TaxService>();
            serviceCollection.AddScoped<IVatService, VatService>();
            serviceCollection.AddScoped<ITaxCategoryService, TaxCategoryService>();
        }
    }
}
