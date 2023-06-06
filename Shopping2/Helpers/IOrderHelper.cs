using Shopping2.Common;
using Shopping2.Models;

namespace Shopping2.Helpers
{
    public interface IOrderHelper
    {
        Task<Response> ProcessOrderAsync(ShowCartViewModel model);
        Task<Response> CancelOrderAsync(int id);
    }
}
