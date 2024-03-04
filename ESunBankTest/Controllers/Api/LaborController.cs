using ESunBankTest.Connections;
using ESunBankTest.Providers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ESunBankTest.Controllers.Api
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LaborController : ControllerBase
    {
        private readonly DataGovProvider DataGovProvider;
        public LaborController(DataGovProvider DataGovProvider)
        {
            this.DataGovProvider = DataGovProvider;
        }

        [HttpPost]
        public async Task<IActionResult> GetData13223ToDataBase()
        {
            var Result = await DataGovProvider.GetData13223ToDataBaseAsync();
            return Ok(Result);
        }

        [HttpGet]
        public async Task<IActionResult> GetData13223FromDataBase()
        {
            var Result = await DataGovProvider.GetData13223FromDataBaseAsync();
            return Ok(Result);
        }


    }
}
