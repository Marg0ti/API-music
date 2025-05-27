using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HernandezMargot_API_M.Data;
using HernandezMargot_API_M.Models;

namespace HernandezMargot_API_M.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistumsController : ControllerBase
    {
        private readonly ChinookModificadaContext _context;

        public ArtistumsController(ChinookModificadaContext context)
        {
            _context = context;
        }

        // GET: api/Artistums
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public async Task<ActionResult<IEnumerable<Artistum>>> GetArtista()
        {
            //incluir los discos compuestos por el artista
            return Ok(await _context.Artista
                                    .Include(a => a.Albums)
                                    .OrderBy(x => x.Nombre)
                                    .Take(10)
                                    .ToListAsync());
        }

        // GET: api/Artistums/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<Artistum>> GetArtistum(int id)
        {
            var artistum = _context.Artista
                                   .Include(x => x.Albums)
                                   //.ThenInclude(a => a.Pista) // Incluir las pistas de los álbumes
                                   .FirstOrDefault(x => x.ArtistaId == id);

            if (artistum == null)
            {
                return NotFound("Artista no encontrado");
            }

            return Ok(artistum);
        }

        // PUT: api/Artistums/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> PutArtistum(int id, ArtistumUpdateModel artistum)
        {
            var artist = _context.Artista.FirstOrDefault(x => x.ArtistaId == id);

            if (artist == null)
            {
                return NotFound("Artista no encontrado");
            }

            if (ModelState.IsValid)
            {
                artist.Nombre = artistum.Nombre;
                await _context.SaveChangesAsync();

                return Ok("Artista editado con éxito");
            }

            return BadRequest("Modelo no válido");
        }

        // POST: api/Artistums
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<Artistum>> PostArtistum(ArtistumUpdateModel artistum)
        {
            Artistum artist = new Artistum();
            artist.Nombre = artistum.Nombre;
            

            if (ModelState.IsValid)
            {
                _context.Artista.Add(artist);
                await _context.SaveChangesAsync();
                return Ok(artist);
            }

            return BadRequest("Modelo no válido");

            //return CreatedAtAction("GetArtistum", new { id = artistum.ArtistaId }, artistum);

        }

        // DELETE: api/Artistums/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteArtistum(int id)
        {
            var artistum = await _context.Artista.FindAsync(id);
            if (artistum == null)
            {
                return NotFound("Artista no encontrado");
            }


            var artistum_Album = _context.Albums.Where(x => x.ArtistaId == id).ToList(); //Obtener los albumes del artista

            var artistum_Pista = new List<Pistum>(); //Obtener las pistas de los albumes del artista, como son varios van en una lista

            foreach (var album in artistum_Album)
            {
                var pistas = _context.Pista.Where(x => x.AlbumId == album.AlbumId).ToList();
                artistum_Pista.AddRange(pistas); //las agrega a la lista
            }

            //borramos las claves foráneas

            if (artistum_Pista.Any())
            {
                _context.Pista.RemoveRange(artistum_Pista);
            }

            
            if(artistum_Album.Any())
            {
                _context.Albums.RemoveRange(artistum_Album);
            }


            //borradas las claves foráneas, ahora se borra el artista
            _context.Artista.Remove(artistum);
            await _context.SaveChangesAsync();

            return Ok(artistum);
        }

        private bool ArtistumExists(int id)
        {
            return _context.Artista.Any(e => e.ArtistaId == id);
        }

        [HttpGet("los_primos")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Artistum>>> GetArtistasConPrimosDeDiscos()
        {
            var artistasConPrimos = await _context.Artista
                .Include(a => a.Albums) // Cargar álbumes asociados
                .Where(a => a.Albums.Count == 1 || a.Albums.Count == 3 || a.Albums.Count == 5 || a.Albums.Count == 7)
                .ToListAsync();

            return Ok(artistasConPrimos);
        }
    }
}
