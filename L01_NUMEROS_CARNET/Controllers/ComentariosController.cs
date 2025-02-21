using L01_NUMEROS_CARNET.Data;
using L01_NUMEROS_CARNET.Models;
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

    [HttpGet]
    public IActionResult GetComentarios()
    {
        var comentarios = _context.Comentarios.ToList();
        return Ok(comentarios);
    }

    [HttpGet("PorUsuario/{usuarioId}")]
    public IActionResult GetComentariosPorUsuario(int usuarioId)
    {
        var comentarios = _context.Comentarios
            .Where(c => c.UsuarioId == usuarioId)
            .ToList();
        return Ok(comentarios);
    }


    [HttpPost]
    public IActionResult CrearComentario([FromBody] Comentario comentario)
    {
        _context.Comentarios.Add(comentario);
        _context.SaveChanges();
        return Ok(comentario);
    }


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

