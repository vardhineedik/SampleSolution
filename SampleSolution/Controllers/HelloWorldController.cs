using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sample.Domain.Abstract;

namespace Sample.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HelloWorldController : ControllerBase
    {
        private readonly IHelloWorldMessageRepository _messageRepository;
        public HelloWorldController(IHelloWorldMessageRepository messageRepository) {
            _messageRepository = messageRepository;
        }

        public async Task<IActionResult> GetHelloWorld()
        {
           var result=await _messageRepository.GetHelloWorldMessage();
            return Ok(result);
        }
    }
}
