using BookAPI.Service.Commands;
using BookAPI.Service.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BookAPI.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IMediator _mediator;
        public BookController(IMediator mediator)
        {
            _mediator=mediator;
        }

        [HttpPost]
        public async Task<IActionResult>CreatedBook(CreateBookCommand createBook)
        {
            var response = await _mediator.Send(createBook);
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllBookQuery();
            return Ok(await _mediator.Send(new GetAllBookQuery()));
        }
    }
}
