using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;

namespace HernandezMargot_API_M.Models
{
    public class AlbumCreateModel
    {


        [StringLength(220, MinimumLength = 1, ErrorMessage = "El texto debe tener entre 1 y 220 caracteres.")]
        [DisplayName("Título")]
        [Required]
        public string Titulo { get; set; } = null!;

        [DisplayName("Código del artista")]
        [Required]
        public int ArtistaId { get; set; }

    }
}
