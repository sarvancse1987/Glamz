using Glamz.Business.Checkout.Interfaces.CheckoutAttributes;
using Glamz.Business.Checkout.Interfaces.GiftVouchers;
using Glamz.Business.Checkout.Interfaces.Orders;
using Glamz.Business.Checkout.Interfaces.Payments;
using Glamz.Business.Checkout.Interfaces.Shipping;
using Glamz.Business.Checkout.Services.CheckoutAttributes;
using Glamz.Business.Checkout.Services.GiftVouchers;
using Glamz.Business.Checkout.Services.Orders;
using Glamz.Business.Checkout.Services.Payments;
using Glamz.Business.Checkout.Services.Shipping;
using Glamz.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Glamz.Business.Checkout.Startup
{
    public class StartupApplication : IStartupApplication
    {
        public void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            RegisterOrdersService(services);
            RegisterPaymentsService(services);
            RegisterShippingService(services);
        }
        public void Configure(IApplicationBuilder application, IWebHostEnvironment webHostEnvironment)
        {

        }
        public int Priority => 100;
        public bool BeforeConfigure => false;


        private void RegisterOrdersService(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<ILoyaltyPointsService, LoyaltyPointsService>();
            serviceCollection.AddScoped<IGiftVoucherService, GiftVoucherService>();
            serviceCollection.AddScoped<IOrderService, OrderService>();
            serviceCollection.AddScoped<IOrderStatusService, OrderStatusService>();
            serviceCollection.AddScoped<IOrderCalculationService, OrderCalculationService>();
            serviceCollection.AddScoped<IMerchandiseReturnService, MerchandiseReturnService>();
            serviceCollection.AddScoped<ILoyaltyPointsService, LoyaltyPointsService>();
            serviceCollection.AddScoped<IShoppingCartService, ShoppingCartService>();
            serviceCollection.AddScoped<IShoppingCartValidator, ShoppingCartValidator>();
            serviceCollection.AddScoped<ICheckoutAttributeFormatter, CheckoutAttributeFormatter>();
            serviceCollection.AddScoped<ICheckoutAttributeParser, CheckoutAttributeParser>();
            serviceCollection.AddScoped<ICheckoutAttributeService, CheckoutAttributeService>();
            serviceCollection.AddScoped<IOrderTagService, OrderTagService>();

        }
        private void RegisterPaymentsService(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IPaymentService, PaymentService>();
            serviceCollection.AddScoped<IPaymentTransactionService, PaymentTransactionService>();
        }
        private void RegisterShippingService(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IShipmentService, ShipmentService>();
            serviceCollection.AddScoped<IShippingService, ShippingService>();
            serviceCollection.AddScoped<IPickupPointService, PickupPointService>();
            serviceCollection.AddScoped<IDeliveryDateService, DeliveryDateService>();
            serviceCollection.AddScoped<IWarehouseService, WarehouseService>();
            serviceCollection.AddScoped<IShippingMethodService, ShippingMethodService>();
        }
    }
}
