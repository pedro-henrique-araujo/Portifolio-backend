using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Portifolio.Auth;
using Portifolio.Data;
using Portifolio.Services;

namespace Portifolio.Controllers
{
    [ApiController]
    [Route("/")]
    public class DefaultController : ControllerBase
    {
        private readonly IContactService _contactService;

        public DefaultController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpGet, AuthorizePortifolio]
        public async Task<IActionResult> GetAllAsync()
        {
            var output = await _contactService.GetAllAsync();
            return Ok(output);
        }

        [HttpGet("{id}"), AuthorizePortifolio]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            var output = await _contactService.GetByIdAsync(id);
            return Ok(output);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(Contact contact)
        {
            await _contactService.CreateAsync(contact);
            return Created("/", null);
        }
    }
}