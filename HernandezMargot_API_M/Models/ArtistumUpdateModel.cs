using System.ComponentModel.DataAnnotations;

namespace HernandezMargot_API_M.Models
{
    public class ArtistumUpdateModel
    {
        [Required]
        [StringLength(255, MinimumLength = 1, ErrorMessage = "El texto debe tener entre 1 y 255 caracteres.")]
        public string Nombre { get; set; }
    }
}
