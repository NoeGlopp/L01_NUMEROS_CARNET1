namespace L01_NUMEROS_CARNET.Models
{
    public class Comentario
    {
        public int ComentarioId { get; set; }
        public int PublicacionId { get; set; }
        public string ComentarioTexto { get; set; } // Mapea al campo "comentario"
        public int UsuarioId { get; set; }
    }
}