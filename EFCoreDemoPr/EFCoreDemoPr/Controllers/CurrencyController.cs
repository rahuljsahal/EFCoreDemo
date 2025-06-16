using EFCoreDemoPr.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Any;

namespace EFCoreDemoPr.Controllers
{
    [Route("api/currencies")]
    [ApiController]
    public class CurrencyController : ControllerBase
    {
        private readonly AppDbContext appDbContext;

        public CurrencyController(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        [HttpGet("")]
        //public IActionResult GettAllCurrency()
        //{
        //    //var result = this.appDbContext.CurrencyTable.ToList();

        //    var result = (from CurrencyType in appDbContext.CurrencyTable
        //                  select CurrencyType).ToList();
        //    return Ok(result);
        //}
         public async Task<IActionResult> GettAllCurrency()
        {
            //var result = await appDbContext.CurrencyTable.ToListAsync();
            var result = await (from CurrencyType in appDbContext.CurrencyTable
                                select CurrencyType).ToListAsync();
            return Ok(result);
        }
        [HttpGet("{currency}")]
        public async Task<IActionResult> GetDetailsByCurrencyAsync([FromRoute] string currency)
        {
            var result = await appDbContext.CurrencyTable.FirstOrDefaultAsync(x=> x.Currency == currency);
            if (result==null)
            {
                return NotFound("Data not found");
            }
            return Ok(result);
        }

    }
}
