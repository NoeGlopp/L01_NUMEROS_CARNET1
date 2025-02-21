using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace L01_NUMEROS_CARNET.Models
{
    [Table("calificaciones")]
    public class Calificacion
    {
        [Key]
        [Column("calificacionId")]
        public int CalificacionId { get; set; }

        [Column("publicacionId")]
        public int PublicacionId { get; set; }

        [Column("usuarioId")]
        public int UsuarioId { get; set; }

    
        [Column("calificacion")]
        public int Valor { get; set; }
    }
}
