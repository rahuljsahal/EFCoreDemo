using EFCoreDemoPr.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFCoreDemoPr.Controllers
{
    [Route("api/languages")]
    [ApiController]
    public class LanguageController : ControllerBase
    {
        private readonly AppDbContext appDbContext;

        public LanguageController(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        [HttpGet("")]

        public async Task<IActionResult> GetAllLanguageAsync()
        {
            var result = await appDbContext.LanguageTable.ToListAsync();
            return Ok(result);
                

        }

        [HttpGet("{Id:int}")]

        public async Task<IActionResult> GetLanguageByIdAsync([FromRoute] int Id)
        {
            var result = await appDbContext.LanguageTable.FindAsync(Id);
            if (result == null)
            {
                return NotFound("Data not found");
            }
            return Ok(result);
        }
       
    }
}
