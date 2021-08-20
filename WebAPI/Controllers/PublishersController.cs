using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;
using WebAPI.Models.ViewModels;
using WebAPI.Services;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublishersController : ControllerBase
    {
        private readonly PublishersService _publishersService;

        public PublishersController(PublishersService publishersSerive)
        {
            _publishersService = publishersSerive;
        }

        [HttpGet("get-all-publishers")]
        public IActionResult GetAllPublishers()
        {
            var allPublishers = _publishersService.GetAllPublishers();
            return Ok(allPublishers);
        }

        [HttpPost("add-publisher")]
        public IActionResult AddPublisher([FromBody] PublishersVM publisher)
        {
            var newPublisher = _publishersService.AddPublisher(publisher);
            return Created(nameof(AddPublisher), newPublisher); 
        }

        [HttpPut("update-publisher/{id}")]
        public IActionResult UpdatePublisherById(int id, [FromBody] Publishers publishers)
        {
            var updatedBook = _publishersService.UpdatePublishersById(id, publishers);
            return Ok(updatedBook);
        }

        [HttpDelete("delete-publisher/{id}")]
        public IActionResult PublisherBook(int id)
        {
            _publishersService.DeletePublishers(id);
            return Ok();
        }
    }
}
