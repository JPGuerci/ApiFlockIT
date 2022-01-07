using ApiFlockIT.Controllers;
using ApiFlockIT.Models.DTO;
using ApiFlockIT.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using WebApiNet.Services;

namespace TestApiFlockIT
{
    [TestClass]
    public class LocalizacionTest
    {
        private LocalizacionDTO Localizacion_Succes() => new LocalizacionDTO()
        {
            IDResultado = 0,
            Resultado = "OK. Localizacion encontrada",
            Nombre = "Salta",
            Latitud = "-24.2991344492002",
            Longitud = "-64.8144629600627"

        };
        private LocalizacionDTO Localizacion_Unsucces() => new LocalizacionDTO()
        {
            IDResultado = -1,
            Resultado = "Error. No se encontro la Provincia",
            Nombre = null,
            Latitud = null,
            Longitud = null

        };

        [TestMethod]
        public void TestLocalizacion_Succes()
        {
            var validProvincia = "salta";
            var mocklog = new Mock<Ilog4netManager>();
            var mockcoordenadas = new Mock<ICoordenadasAPI>();

            mockcoordenadas.Setup(coordenada => coordenada.GetCoordenadas(validProvincia)).Returns(Localizacion_Succes());
            var controlador = new LocalizacionController(mockcoordenadas.Object, mocklog.Object);
            var resultado = controlador.GetLocalizacion(validProvincia) as OkObjectResult;

            Assert.IsInstanceOfType(resultado, typeof(OkObjectResult));
            Assert.IsTrue(resultado.StatusCode == 200);

            var resultadotest = resultado.Value as LocalizacionDTO;

            Assert.IsTrue(resultadotest.IDResultado == 0);
            Assert.IsTrue(resultadotest.Resultado == "OK. Localizacion encontrada");
            Assert.IsNotNull(resultadotest.Nombre);
            Assert.IsNotNull(resultadotest.Latitud);
            Assert.IsNotNull(resultadotest.Longitud);
        }
        [TestMethod]
        public void TestLocalizacion_Unsucces()
        {
            var invalidProvincia = "Falso";
            var mocklog = new Mock<Ilog4netManager>();
            var mockcoordenadas = new Mock<ICoordenadasAPI>();

            mockcoordenadas.Setup(coordenada => coordenada.GetCoordenadas(invalidProvincia)).Returns(Localizacion_Unsucces());
            var controlador = new LocalizacionController(mockcoordenadas.Object, mocklog.Object);
            var resultado = controlador.GetLocalizacion(invalidProvincia) as BadRequestObjectResult;

            Assert.IsInstanceOfType(resultado, typeof(BadRequestObjectResult));
            Assert.IsTrue(resultado.StatusCode == 400);

            var resultadotest = resultado.Value as LocalizacionDTO;

            Assert.IsTrue(resultadotest.IDResultado == -1 || resultadotest.IDResultado == -2);
            Assert.IsTrue(resultadotest.Resultado.Contains("Error"));
            Assert.IsNull(resultadotest.Nombre);
            Assert.IsNull(resultadotest.Latitud);
            Assert.IsNull(resultadotest.Longitud);
        }
    }
}
