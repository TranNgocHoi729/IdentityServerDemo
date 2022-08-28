using IdentifyServer_Demo.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IdentifyServer_Demo.Controllers
{
    [Route("shops/coffeshop")]
    [ApiController]
    public class CoffeShopController : ControllerBase
    {
        private readonly ICoffeShopService _coffeShopService;

        public CoffeShopController(ICoffeShopService coffeShopService)
        {
            _coffeShopService = coffeShopService;
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var coffeShops = await _coffeShopService.List();
            return Ok(coffeShops);
        }
    }
}
