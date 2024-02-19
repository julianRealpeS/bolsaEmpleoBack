namespace bolsaEmpleoBack.DTOs
{
    public class CiudadanoRegistrarDTO
    {
        public long TipoDocumentoId { get; set; }
        public string Cedula { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public DateOnly FechaNacimiento { get; set; }
        public string Profesion { get; set; }
        public long AspiracionSalarial { get; set; }
        public string CorreoElectronico { get; set; }
    }
}
