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
        //Fetch all Details
        [HttpGet("")]

        public async Task<IActionResult> GetAllLanguageAsync()
        {
            var result = await appDbContext.LanguageTable.ToListAsync();
            return Ok(result);
                

        }

        //fetch by Id
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


        //fetch by title
        [HttpGet("by-Title/{title}")]
        public async Task<IActionResult> GetLanguageByTitle([FromRoute] string title)
        {
            var result = await appDbContext.LanguageTable.FirstOrDefaultAsync(x => x.Title == title);
            if(result == null)
            {
                return NotFound("Data Not Found");
            }
            return Ok(result);
        }


        //fetch by descrription 
        [HttpGet("by-descripton/{description}")]
        public async Task<IActionResult> GetLanguageByDescription([FromRoute] string description)
        {
            var result = await appDbContext.LanguageTable.FirstOrDefaultAsync(x => x.Description == description);
            if (result == null)
            {
                return NotFound("Data Not Found");
            }
            return Ok(result);
        }
       
    }
}
