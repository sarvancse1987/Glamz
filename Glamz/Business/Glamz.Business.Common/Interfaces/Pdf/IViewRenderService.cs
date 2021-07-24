using System.Threading.Tasks;

namespace Glamz.Business.Common.Interfaces.Pdf
{
    /// <summary>
    /// Allow render rezor view as string
    /// </summary>
    public interface IViewRenderService
    {
        Task<string> RenderToStringAsync<T>(string viewPath, T model);
    }
}
