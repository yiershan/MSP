using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityModel.Client;
using Microsoft.AspNetCore.Mvc;

namespace MSP.Web.Controllers
{
    public class TokenController : MSPApiController
    {
        [HttpGet]
        public async Task<JsonResult> GetAsync() {
            var client = new DiscoveryClient("http://10.3.30.210:1234")
            {
                Policy = {
                RequireHttps = false
                }
            };
            var disco = await client.GetAsync();

            var tokenClient = new TokenClient(disco.TokenEndpoint, "ro.client", "secret1");
            var tokenResponse = await tokenClient.RequestResourceOwnerPasswordAsync("1111", "password");
            return new JsonResult(tokenResponse);
        }
    }
    [Route("api/[controller]/[action]")]
    public class MSPApiController : Controller
    {

    }
}
