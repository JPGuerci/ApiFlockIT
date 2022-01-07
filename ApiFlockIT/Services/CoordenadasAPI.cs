using Newtonsoft.Json;
using System;
using System.Net;
using ApiFlockIT.Models.DTO;
using ApiFlockIT.Services;
using Microsoft.Extensions.Configuration;

namespace WebApiNet.Services
{   public interface ICoordenadasAPI 
    {
        LocalizacionDTO GetCoordenadas(string provincia);
    }
    public class CoordenadasAPI: ICoordenadasAPI
    {
        private readonly Ilog4netManager _log;
        private readonly IConfiguration _config;

        public CoordenadasAPI(Ilog4netManager log, IConfiguration configuration)
        {
            _log = log;
            _config = configuration;
        }
        public LocalizacionDTO GetCoordenadas(string provincia)
        {
            var result = new LocalizacionDTO();
            try
            {
                _log.LogInfo("Inicio Get ApiCoordenadas");
                string url = _config.GetValue<string>("URLApiProvincias") + provincia;
                _log.LogDebug($"URL={url}");
                var json = new WebClient().DownloadString(url);
                dynamic m = JsonConvert.DeserializeObject(json);

                if (m.cantidad == 0)
                {
                    result.IDResultado = -1;
                    result.Resultado = "Error. No se encontro la Provincia " + provincia;
                    _log.LogWarn($"Resultado Controlador={result.IDResultado} Mensaje={result.Resultado}");
                }
                else 
                {
                    result.IDResultado = 0;
                    result.Resultado = "OK. Localizacion encontrada";
                    result.Nombre = m.provincias[0].nombre;
                    result.Latitud = m.provincias[0].centroide.lat;
                    result.Longitud = m.provincias[0].centroide.lon;
                    _log.LogInfo($"Resultado={result.IDResultado} Mensaje={result.Resultado}");
                }
            }
            catch (Exception ex)
            {
                result.IDResultado = -2;
                result.Resultado = "Error. "+ex.Message;
                _log.LogError($"Resultado={result.IDResultado} Mensaje={result.Resultado}");
            }
            return result;

        }

    }
}
