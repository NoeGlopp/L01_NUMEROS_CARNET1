using Microsoft.AspNetCore.Mvc;
using System.Linq;

[Route("api/[controller]")]
[ApiController]
public class ComentariosController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public ComentariosController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: api/Comentarios
    [HttpGet]
    public IActionResult GetComentarios()
    {
        var comentarios = _context.Comentarios.ToList();
        return Ok(comentarios);
    }

    // GET: api/Comentarios/PorUsuario/{usuarioId}
    [HttpGet("PorUsuario/{usuarioId}")]
    public IActionResult GetComentariosPorUsuario(int usuarioId)
    {
        var comentarios = _context.Comentarios
            .Where(c => c.UsuarioId == usuarioId)
            .ToList();
        return Ok(comentarios);
    }

    // POST: api/Comentarios
    [HttpPost]
    public IActionResult CrearComentario([FromBody] Comentario comentario)
    {
        _context.Comentarios.Add(comentario);
        _context.SaveChanges();
        return Ok(comentario);
    }

    // PUT: api/Comentarios/{id}
    [HttpPut("{id}")]
    public IActionResult EditarComentario(int id, [FromBody] Comentario comentario)
    {
        var comentarioExistente = _context.Comentarios.Find(id);
        if (comentarioExistente == null)
            return NotFound();

        comentarioExistente.PublicacionId = comentario.PublicacionId;
        comentarioExistente.UsuarioId = comentario.UsuarioId;
        comentarioExistente.ComentarioTexto = comentario.ComentarioTexto;

        _context.SaveChanges();
        return Ok(comentarioExistente);
    }

    // DELETE: api/Comentarios/{id}
    [HttpDelete("{id}")]
    public IActionResult EliminarComentario(int id)
    {
        var comentario = _context.Comentarios.Find(id);
        if (comentario == null)
            return NotFound();

        _context.Comentarios.Remove(comentario);
        _context.SaveChanges();
        return Ok(new { message = "Comentario eliminado" });
    }
}

