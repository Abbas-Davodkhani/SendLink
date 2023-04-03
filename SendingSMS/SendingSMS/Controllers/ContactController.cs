using Microsoft.AspNetCore.Mvc;
using SendingSMS.Model;
using SendingSMS.Model.Repository;
using SendingSMS.Service;

namespace SendingSMS.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactController : ControllerBase
    {
        private readonly IContactRepository _contactRepository;
        private readonly IShortLinkService _shortLinkService;
        public ContactController(IContactRepository contactRepository , IShortLinkService shortLinkService)
        {
            _contactRepository = contactRepository;
            _shortLinkService = shortLinkService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var res =  await _contactRepository.GetAllAsync(cancellationToken);
            return Ok(res); 
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id , CancellationToken cancellationToken)
        {
            var res = await _contactRepository.GetAsync(id, cancellationToken);
            return Ok(res);
        }
        [HttpPost]
        public async Task<IActionResult> Post(Contact contact , CancellationToken cancellationToken)
        {
            var res = await _contactRepository.AddAsync(contact , cancellationToken);
            return Ok(contact);
        }
        [HttpPut]
        public async Task<IActionResult> Put(int id , Contact contact , CancellationToken cancellationToken)
        {
            var res = await _contactRepository.UpdateAsync(id ,contact , cancellationToken).ConfigureAwait(false);
            return Ok(res);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id , CancellationToken cancellationToken)
        {
            await _contactRepository.DeleteAsync(id, cancellationToken);
            return Ok();
        }

        [HttpGet("[action]")]
        public async Task<ActionResult> SendUrlToContact(int id , string message , CancellationToken cancellationToken)
        {
            return Ok(await _contactRepository.SendUrlToContcat(id , message , cancellationToken));
        }

        [HttpGet("[action]")]
        public async Task<ActionResult> SendUrlToContactShort(string longUrl, CancellationToken cancellationToken)
        {
            return Ok(await _shortLinkService.GetShortLinkAsync(longUrl , cancellationToken));
        }
    }
}
