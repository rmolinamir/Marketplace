using Microsoft.AspNetCore.Mvc;

namespace Marketplace.Api
{
    [Route("/ad")]
    public class ClassifiedAdsCommandsApi : Controller
    {
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Contracts.ClassifiedAds.V1.Create request)
        {
            // handle request here
            return Ok();
        }
    }
}