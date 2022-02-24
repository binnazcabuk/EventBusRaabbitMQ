using BorrowAPI.Service.Context;
using BorrowAPI.Service.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace BorrowAPI.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BorrowController : ControllerBase
    {
        private readonly BorrowDbContext _context;

        public BorrowController(BorrowDbContext context)
        {
            _context=context;
        }

        [HttpGet]
        public async Task<IActionResult> Get(string name)
        {
            var response = await _context.Borrows.Where(x => x.borrowName==name).ToListAsync();
           
            return  Ok(response);
        }
        [HttpPost]
        public async Task<IActionResult>Save(Borrow borrow)
        {          
            await _context.Borrows.AddAsync(borrow);
            await _context.SaveChangesAsync();

            return Ok();
        }
        [HttpPost("update")]
        public async Task<IActionResult> up(Borrow borrow)
        {
           
           _context.Borrows.Update(borrow);
           await _context.SaveChangesAsync();

            return Ok(borrow);
        }
    }
}
