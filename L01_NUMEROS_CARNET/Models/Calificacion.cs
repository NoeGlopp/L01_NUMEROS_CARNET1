namespace L01_NUMEROS_CARNET.Models
{
    public class Calificacion
    {
        public int CalificacionId { get; set; }
        public int PublicacionId { get; set; }
        public int UsuarioId { get; set; }
        public int Valor { get; set; } // Mapea al campo "calificacion"
    }
}