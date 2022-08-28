using IdentifyServer_Demo.Models;

namespace IdentifyServer_Demo.Services
{
    public interface ICoffeShopService
    {
        Task<List<CoffeShopModel>> List();
    }
}
