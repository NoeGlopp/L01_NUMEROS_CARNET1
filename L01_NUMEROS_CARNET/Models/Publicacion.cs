namespace L01_NUMEROS_CARNET.Models
{
    public class Publicacion
    {
        public int PublicacionId { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public int UsuarioId { get; set; }
    }
}