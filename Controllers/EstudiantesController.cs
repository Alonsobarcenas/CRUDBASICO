using CRUDBASICO.DTO.AddDTO;
using CRUDBASICO.Models;
using CRUDBASICO.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CRUDBASICO.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstudiantesController : ControllerBase
    {
        private readonly ContextDB _context;

        public EstudiantesController(ContextDB context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult> PostEstudiantes(AddEstudianteDTO AddEstudiante)
        {
            try
            {
                var estudiante = new Estudiante();

                estudiante.Nombre = AddEstudiante.Nombre;
                estudiante.Apellidos = AddEstudiante.Apellidos;
                estudiante.Direccion = AddEstudiante.Direccion;
                estudiante.Estado = AddEstudiante.Estado;
                estudiante.Numero = AddEstudiante.Numero;
                estudiante.NumeroTelefonico = AddEstudiante.NumeroTelefonico;

                _context.Add(estudiante);
                await _context.SaveChangesAsync();

                return Ok(estudiante);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }

        [HttpGet]
        public async Task<ActionResult> GetAllEstudiantes()
        {
            try
            {
                var buscarEstudiantes = await _context.Estudiantes.ToListAsync();
                return Ok(buscarEstudiantes);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult> PutEstudiantes(int IdEstudiantes, Estudiante UptdEstudiante)
        {
            try
            {


                if (IdEstudiantes == UptdEstudiante.IdEstudiantes)
                {
                    _context.Update(UptdEstudiante);
                    await _context.SaveChangesAsync();
                    return Ok();

                }
                else
                {
                    return BadRequest($"No existe ningun alumno con este {IdEstudiantes} ");

                }

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public async Task<ActionResult> EliminarEstudinates(int IdEstudiante)
        {
            try
            {
                var buscarEstudiante = await _context.Estudiantes.FindAsync(IdEstudiante);

                if(buscarEstudiante == null)
                {
                    return BadRequest("No se pudo elimiar este Estudiante");
                }
                else
                {
                    _context.Estudiantes.Remove(_context.Estudiantes.Find(IdEstudiante));
                    await _context.SaveChangesAsync();
                    return Ok();
                }
               
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

    }

}
