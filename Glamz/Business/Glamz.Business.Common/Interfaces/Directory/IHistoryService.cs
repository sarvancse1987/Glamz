using Glamz.Domain;
using Glamz.Domain.History;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Glamz.Business.Common.Interfaces.Directory
{
    /// <summary>
    /// History service interface
    /// </summary>
    public partial interface IHistoryService
    {
        Task SaveObject<T>(T entity) where T : BaseEntity;
        Task<IList<T>> GetHistoryForEntity<T>(BaseEntity entity) where T : BaseEntity;
        Task<IList<HistoryObject>> GetHistoryObjectForEntity(BaseEntity entity);
    }
}