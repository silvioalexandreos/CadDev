using Business.Report;
using Business.Repository;
using Business.Repository.Service.Developer;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace WebUI.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class DeveloperController : Controller
    {
        private IDeveloperService _service;
        public DeveloperController(IDeveloperService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            try
            {
                return Ok(await _service.GetAll());
            }
            catch (ArgumentException ex)
            {

                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("{id}", Name = "GetWihtId")]
        public async Task<ActionResult> Get(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            try
            {
                return Ok (await _service.Get(id));
            }
            catch (ArgumentException ex)
            {

                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        [HttpPost]
        public async Task<ActionResult> Post([FromBody]Database.Developer developer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            try
            {
                var result = await _service.Post(developer);
                if (result != null)
                {
                    return Created(new Uri(Url.Link("GetWihtId", new { id = result.Id })), result);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (ArgumentException ex)
            {

                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult> Put([FromBody] Database.Developer developer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            try
            {
                var result = await _service.Put(developer);
                if (result != null)
                {
                    return Ok(result);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (ArgumentException ex)
            {

                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            try
            {
                return Ok(await _service.Delete(id));
            }
            catch (ArgumentException ex)
            {

                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
