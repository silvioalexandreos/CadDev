using System;
using System.Net;
using System.Threading.Tasks;
using Business.Repository.Service.User;
using Database;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebUI.Hash;

namespace WebUI.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private IUserService _user;
        public UserController( IUserService user)
        {
            _user = user;
        }

        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        [Route("login")]
        [AllowAnonymous]//Permite acesso anonimo a essa rota
        public async Task<ActionResult<dynamic>> Authenticate([FromBody] User model)
        {
            var user = _user.Login(model.Username, model.Password);
            if (user == null)
                return NotFound(new { message = "Usuário ou senha inválido" });

            var token = TokenService.GenerateToken(user.Result);
            
            return new
            {
                user = user,
                token = token
            };
            
        }

        [HttpGet]
        [Route("Get")]
        [AllowAnonymous]
        public async Task<ActionResult> GetAll()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            try
            {
                return Ok(await _user.GetAll());
            }
            catch (ArgumentException ex)
            {

                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Authorize]
        [Route("{id}", Name = "GetId")]
        public async Task<ActionResult> Get(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            try
            {
                return Ok(await _user.Get(id));
            }
            catch (ArgumentException ex)
            {

                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        [HttpPost]
        [Route("cadastrar")]
        [Authorize(Roles = "gerente,funcionario")]
        public async Task<ActionResult> Post([FromBody] Database.User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            try
            {
                var result = await _user.Post(user);
                if (result != null)
                {
                    return Created(new Uri(Url.Link("GetId", new { id = result.Id })), result);
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
        public async Task<ActionResult> Put([FromBody] Database.User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            try
            {
                var result = await _user.Put(user);
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
                return Ok(await _user.Delete(id));
            }
            catch (ArgumentException ex)
            {

                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
