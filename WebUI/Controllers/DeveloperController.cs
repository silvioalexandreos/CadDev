﻿

using Business.Repository.Service.Developer;
using Business.Repository.Service.User;
using Database;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Threading.Tasks;
using WebUI.Hash;
using WebUI.Models;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace WebUI.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]

    public class DeveloperController : Controller
    {
        private IDeveloperService _service;
        private IUserService _user;
        public DeveloperController(IDeveloperService service, IUserService user)
        {
            _service = service;
            _user = user;
        }

        [HttpGet]
        [Route("Publico")]
        [AllowAnonymous]
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
        [Authorize]
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
        [Route("cadastrar")]
        [Authorize(Roles ="gerente,funcionario")]
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
        [Route("Atulizar")]
        [Authorize(Roles = "Gerente")]
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
        [Route("Delete")]
        [Authorize(Roles = "Gerente")]
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
