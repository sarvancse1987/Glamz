using Glamz.Domain.Stores;
using System.Threading.Tasks;

namespace Glamz.Infrastructure
{
    public interface IStoreHelper
    {
        Store HostStore { get; }

        Task SetStoreCookie(string storeId);

        Task<Store> SetCurrentStore(string storeId);
    }
}
