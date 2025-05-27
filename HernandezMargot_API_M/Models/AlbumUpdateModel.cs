using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace HernandezMargot_API_M.Models
{
    public class AlbumUpdateModel
    {

        [StringLength(255)]
        [DisplayName("Título")]
        [Required]
        public string Titulo { get; set; } = null!;

        
    }
}
