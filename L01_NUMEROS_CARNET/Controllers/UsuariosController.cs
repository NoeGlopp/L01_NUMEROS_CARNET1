using L01_NUMEROS_CARNET.Data;
using L01_NUMEROS_CARNET.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

[Route("api/[controller]")]
[ApiController]
public class UsuariosController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public UsuariosController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult GetUsuarios()
    {
        var usuarios = _context.Usuarios.ToList();
        return Ok(usuarios);
    }

    [HttpGet("BuscarPorNombreApellido/{nombre}")]
    public IActionResult BuscarPorNombreApellido(string nombre)
    {
        var usuarios = _context.Usuarios
            .Where(u => u.Nombre.Contains(nombre) || u.Apellido.Contains(nombre))
            .ToList();
        return Ok(usuarios);
    }

  
    [HttpGet("BuscarPorRol/{rolId}")]
    public IActionResult BuscarPorRol(int rolId)
    {
        var usuarios = _context.Usuarios.Where(u => u.RolId == rolId).ToList();
        return Ok(usuarios);
    }


    [HttpPost]
    public IActionResult CrearUsuario([FromBody] Usuario usuario)
    {
        _context.Usuarios.Add(usuario);
        _context.SaveChanges();
        return Ok(usuario);
    }

    [HttpPut("{id}")]
    public IActionResult EditarUsuario(int id, [FromBody] Usuario usuario)
    {
        var usuarioExistente = _context.Usuarios.Find(id);
        if (usuarioExistente == null)
            return NotFound();

        usuarioExistente.NombreUsuario = usuario.NombreUsuario;
        usuarioExistente.Clave = usuario.Clave;
        usuarioExistente.Nombre = usuario.Nombre;
        usuarioExistente.Apellido = usuario.Apellido;
        usuarioExistente.RolId = usuario.RolId;

        _context.SaveChanges();
        return Ok(usuarioExistente);
    }


    [HttpDelete("{id}")]
    public IActionResult EliminarUsuario(int id)
    {
        var usuario = _context.Usuarios.Find(id);
        if (usuario == null)
            return NotFound();

        _context.Usuarios.Remove(usuario);
        _context.SaveChanges();
        return Ok(new { message = "Usuario eliminado" });
    }

    // GET: api/Usuarios/TopUsuariosComentarios/{topN}
    [HttpGet("TopUsuariosComentarios/{topN}")]
    public IActionResult GetTopUsuariosComentarios(int topN)
    {
        var topUsuarios = _context.Comentarios
            .GroupBy(c => c.UsuarioId)
            .Select(g => new
            {
                UsuarioId = g.Key,
                CantidadComentarios = g.Count(),
                NombreUsuario = _context.Usuarios
                    .Where(u => u.UsuarioId == g.Key)
                    .Select(u => u.NombreUsuario)
                    .FirstOrDefault()
            })
            .OrderByDescending(u => u.CantidadComentarios)
            .Take(topN)
            .ToList();

        return Ok(topUsuarios);
    }
}
