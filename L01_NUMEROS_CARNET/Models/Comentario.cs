using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace L01_NUMEROS_CARNET.Models
{
    [Table("comentarios")]
    public class Comentario
    {
        [Key]
        [Column("cometarioId")] 
        public int ComentarioId { get; set; }

        [Column("publicacionId")]
        public int PublicacionId { get; set; }

        [Column("comentario")] 
        public string ComentarioTexto { get; set; }

        [Column("usuarioId")]
        public int UsuarioId { get; set; }
    }
}
