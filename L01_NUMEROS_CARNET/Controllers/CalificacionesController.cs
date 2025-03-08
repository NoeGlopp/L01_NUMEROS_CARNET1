﻿using L01_NUMEROS_CARNET.Data;
using L01_NUMEROS_CARNET.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

[Route("api/[controller]")]
[ApiController]
public class CalificacionesController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public CalificacionesController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult GetCalificaciones()
    {
        var calificaciones = _context.Calificaciones.ToList();
        return Ok(calificaciones);
    }


    [HttpGet("PorPublicacion/{publicacionId}")]
    public IActionResult GetCalificacionesPorPublicacion(int publicacionId)
    {
        var calificaciones = _context.Calificaciones
            .Where(c => c.PublicacionId == publicacionId)
            .ToList();
        return Ok(calificaciones);
    }

    [HttpPost]
    public IActionResult CrearCalificacion([FromBody] Calificacion calificacion)
    {
        _context.Calificaciones.Add(calificacion);
        _context.SaveChanges();
        return Ok(calificacion);
    }


    [HttpPut("{id}")]
    public IActionResult EditarCalificacion(int id, [FromBody] Calificacion calificacion)
    {
        var calificacionExistente = _context.Calificaciones.Find(id);
        if (calificacionExistente == null)
            return NotFound();

        calificacionExistente.PublicacionId = calificacion.PublicacionId;
        calificacionExistente.UsuarioId = calificacion.UsuarioId;
        calificacionExistente.Valor = calificacion.Valor;

        _context.SaveChanges();
        return Ok(calificacionExistente);
    }


    [HttpDelete("{id}")]
    public IActionResult EliminarCalificacion(int id)
    {
        var calificacion = _context.Calificaciones.Find(id);
        if (calificacion == null)
            return NotFound();

        _context.Calificaciones.Remove(calificacion);
        _context.SaveChanges();
        return Ok(new { message = "Calificación eliminada" });
    }
}
