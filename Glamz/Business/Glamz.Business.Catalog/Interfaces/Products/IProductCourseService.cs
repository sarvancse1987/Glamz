using Glamz.Domain.Catalog;
using Glamz.Domain.Courses;
using System.Threading.Tasks;

namespace Glamz.Business.Catalog.Interfaces.Products
{
    public interface IProductCourseService
    {
        Task<Product> GetProductByCourseId(string courseId);
        Task<Course> GetCourseByProductId(string productId);
        Task UpdateCourseOnProduct(string productId, string courseId);
    }
}
