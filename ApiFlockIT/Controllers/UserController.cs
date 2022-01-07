using Microsoft.AspNetCore.Mvc;
using ApiFlockIT.Models;
using NetCoreApi.Services;
using ApiFlockIT.Services;

namespace ApiFlockIT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserValidate _servicio;
        private readonly Ilog4netManager _log;

        public UserController(IUserValidate servicio,Ilog4netManager log) 
        { _servicio = servicio;
          _log=log;
        }

        /// <summary>
        /// Metodo de Autenticacion de Usuario
        /// </summary>
        /// <param name="UserLogin">
        /// Username(nombre de usuario)
        /// Password(contraseña)
        /// </param>
        /// <returns>
        /// </returns>
        /// <response code="200">Ok. Usuario validado</response>
        /// <response code="400">Error. Usuario Invalido</response>
        [HttpPost]
        public IActionResult Login(UserLogin user)
        {
            _log.LogInfo("LLamada a IUserValidate.Login");
            _log.LogDebug($"Username={user.Username} Password={user.Password}");
            var result =_servicio.Login(user.Username, user.Password);
            _log.LogInfo($"Resultado en controlador={result.IDResultado} Mensaje={result.Resultado}");
            switch (result.IDResultado) 
            { 
                case 0: return Ok(result);
                default:
                case -1: return BadRequest(result);
            }
            
        }
    }
}
