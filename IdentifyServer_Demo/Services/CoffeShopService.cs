using DataAccess.Data;
using IdentifyServer_Demo.Models;
using Microsoft.EntityFrameworkCore;

namespace IdentifyServer_Demo.Services
{
    public class CoffeShopService : ICoffeShopService
    {
        private readonly ApplicationDbContext _context;

        public CoffeShopService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<CoffeShopModel>> List()
        {
            var coffeShops = await (from shop in _context.CoffeShops
                                   select new CoffeShopModel()
                                   {
                                       Id = shop.Id,
                                       Address = shop.Address,
                                        Name = shop.Name,
                                        OpeningHours = shop.OpeningHours
                                   }).ToListAsync();
            return coffeShops;
        }
    }
}
