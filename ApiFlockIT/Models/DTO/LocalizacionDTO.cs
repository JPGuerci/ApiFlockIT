namespace ApiFlockIT.Models.DTO
{
    public class LocalizacionDTO : ResponseDTO
    {
        public string Nombre { get; set; }
        public string Latitud { get; set; }
        public string Longitud { get; set; }
    }
}
