using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HernandezMargot_API_M.Data;
using HernandezMargot_API_M.Models;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace HernandezMargot_API_M.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlbumsController : ControllerBase
    {
        private readonly ChinookModificadaContext _context;

        public AlbumsController(ChinookModificadaContext context)
        {
            _context = context;
        }

        // GET: api/Albums
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Album>>> GetAlbums()
        {
            return Ok(await _context.Albums
                                .Include(x => x.Artista)
                                .Include(x => x.Pista)
                                .OrderByDescending(x => x.Titulo)
                                .Take(10)
                                .ToListAsync());
        }

        // GET: api/Albums/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<Album>> GetAlbum(int id)
        {
            var album =  _context.Albums
                                  .Include(x => x.Artista)
                                  .Include(x => x.Pista)
                                  .FirstOrDefault(x => x.AlbumId == id);

            if (album == null)
            {
                return NotFound("El álbum no encontrado");
            }

            return Ok(album);
        }

        // PUT: api/Albums/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> PutAlbum(int id, AlbumCreateModel album)
        {

            Album albumEntity = _context.Albums.FirstOrDefault(x => x.AlbumId == id);
            if (albumEntity == null)
            {
                return NotFound("Álbum no encontrado");
            }

            //_context.Entry(album).State = EntityState.Modified;
            //En resumen, esta línea le dice a Entity Framework que la entidad album ha sido modificada y que debe actualizarse en la base de datos. 


            if (ModelState.IsValid)
            {
                albumEntity.Titulo = album.Titulo;
                if (albumEntity.ArtistaId != album.ArtistaId)
                {
                    if (!_context.Artista.Any(x => x.ArtistaId == album.ArtistaId))
                    {
                        return NotFound("El artista no existe");
                    }
                    albumEntity.ArtistaId = album.ArtistaId;
                    albumEntity.Artista = _context.Artista.FirstOrDefault(x => x.ArtistaId == album.ArtistaId);
                }
                await _context.SaveChangesAsync();
                return Ok(albumEntity);
            }
            
            return BadRequest("Modelo no válido");
        }

        // POST: api/Albums
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Album>> PostAlbum(AlbumCreateModel album)
        {
            if(album == null)
            {
                return BadRequest("Añade datos");
            }
            
            if (ModelState.IsValid)
            {
                Album albumNuevo = new Album();
                //albumNuevo.AlbumId = _context.Albums.Max(a => a.AlbumId) + 1; //No hace falta se incrementa sola
                albumNuevo.Titulo = album.Titulo;

                Artistum artist = _context.Artista.FirstOrDefault(X => X.ArtistaId == album.ArtistaId); 
                if (artist == null)
                {
                    return NotFound("Artista no encontrado");
                }
                albumNuevo.ArtistaId = album.ArtistaId;
                albumNuevo.Artista = artist;


                _context.Albums.Add(albumNuevo);
                await _context.SaveChangesAsync();
                //return CreatedAtAction("GetAlbum", new { id = album.AlbumId }, album);
                return Ok(albumNuevo);
            }

            return BadRequest("Modelo no válido");
            
        }

        // DELETE: api/Albums/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteAlbum(int id)
        {
            var album = await _context.Albums.FindAsync(id);
            if (album == null)
            {
                return NotFound("Álbum no encontrado");
            }
            
            var pistas = _context.Pista.Where(x => x.AlbumId == id).ToList(); //lista de canciones del album
            if (pistas !=null)
            {
                _context.Pista.RemoveRange(pistas); //borra las canciones
            }

            _context.Albums.Remove(album);
            await _context.SaveChangesAsync();

            return Ok(album);
        }

        private bool AlbumExists(int id)
        {
            return _context.Albums.Any(e => e.AlbumId == id);
        }

        [HttpGet("misfavoritos")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Album>>> misfavoritos()
        {
            string word = "soul";
            var albums = _context.Albums;
            var albumsFavoritos = new List<Album>();

            foreach (var album in albums )
            {
                if (album.Titulo.ToLower().Contains(word))
                {
                    albumsFavoritos.Add(album);
                }
                
            }

            //if  (albumsFavoritos.Count() == 0)
            //{
            //    return NotFound();
            //}
            
 

            return Ok(albumsFavoritos);
        }
    }
}
