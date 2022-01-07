using ApiFlockIT.Services;
using Microsoft.AspNetCore.Mvc;
using WebApiNet.Services;

namespace ApiFlockIT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocalizacionController : Controller
    {
        private readonly ICoordenadasAPI _servicio;
        private readonly Ilog4netManager _log;

        public LocalizacionController(ICoordenadasAPI servicio, Ilog4netManager log) 
        { _servicio = servicio;
          _log = log;
        }
        /// <summary>Metodo que devuelve la latitud 
        /// y longitud segun la provincia ingresada</summary>
        /// <param name="Provincia">
        /// Nombre de la provincia a buscar
        /// </param>
        /// <returns>
        /// </returns>
        /// <response code="200">OK. Localizacion encontrada</response>
        /// <response code="400">Error. No se encontró la provincia</response>
        /// <response code="409">Error. Problema con la api</response>
        [HttpGet("{Provincia}")]
        public IActionResult GetLocalizacion(string Provincia)
        {
            _log.LogInfo("LLamada a ICoordenadasAPI.GetCoordenadas");
            _log.LogDebug($"Provincia={Provincia}");
            var result = _servicio.GetCoordenadas(Provincia);
            _log.LogInfo($"Resultado en controlador={result.IDResultado} Mensaje={result.Resultado}");
            switch (result.IDResultado)
            {
                case 0: return Ok(result);         
                case -1:return BadRequest(result);
                case -2:
                default:return Conflict(result);
            }
        }

    }

}
