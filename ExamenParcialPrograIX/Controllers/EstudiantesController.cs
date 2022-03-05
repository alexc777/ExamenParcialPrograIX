using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ExamenParcialPrograIX.Data;
using ExamenParcialPrograIX.Models;

namespace ExamenParcialPrograIX.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstudiantesController : ControllerBase
    {
        private readonly ExamenParcialPrograIXContext _context;

        public EstudiantesController(ExamenParcialPrograIXContext context)
        {
            _context = context;
        }

        /* GET: api/Estudiantes
            * este método funciona de forma síncrona
        */
        [HttpGet]
        public ActionResult<IEnumerable<Estudiante>> GetEstudiante()
        {
            return _context.Estudiante.ToList();
        }

        /* GET: api/Estudiantes/5
           * este método funciona de forma síncrona
         */
        [HttpGet("{id}")]
        public ActionResult<Estudiante> GetEstudiante(int? id)
        {
            //var estudiante = _context.Estudiante.FindAsync(id);
            var estudiante = _context.Estudiante.Find(id);

            if (estudiante == null)
            {
                return NotFound();
            }

            return estudiante;
        }

        /* POST: api/Estudiantes
            * Inserta la información del estudiante de forma Asíncrona 
        */
        [HttpPost]
        [Route("ASYNC")]
        public async Task<ActionResult<Estudiante>> PostEstudiante(Estudiante estudiante)
        {
            //_context.Estudiante.Add(estudiante);
            await _context.Estudiante.AddAsync(estudiante);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEstudiante", new { id = estudiante.id }, estudiante);
        }

        /* PUT: api/Estudiantes/5
           * actualiza el estudiante de forma Asíncrona
        */
        [HttpPut("updateAsync/{id}")]
        public async Task<IActionResult> PutEstudiante(int? id, Estudiante estudiante)
        {
            if (id != estudiante.id)
            {
                return BadRequest();
            }

            _context.Entry(estudiante).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EstudianteExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/Estudiantes/5
        /*[HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEstudiante(int? id)
        {
            var estudiante = await _context.Estudiante.FindAsync(id);
            if (estudiante == null)
            {
                return NotFound();
            }

            _context.Estudiante.Remove(estudiante);
            await _context.SaveChangesAsync();

            return NoContent();
        }*/

        private bool EstudianteExists(int? id)
        {
            return _context.Estudiante.Any(e => e.id == id);
        }
    }
}
