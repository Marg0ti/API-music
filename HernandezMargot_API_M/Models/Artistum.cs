using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HernandezMargot_API_M.Models;

public partial class Artistum
{
    [Key]
    [DisplayName("Código de artista")]
    public int ArtistaId { get; set; }

    [StringLength(255, MinimumLength = 1, ErrorMessage = "El texto debe tener entre 1 y 255 caracteres.")]
    [DisplayName("Nombre")]

    public string Nombre { get; set; } = null!;

    [InverseProperty("Artista")]
    [DisplayName("Álbumes")]
    public virtual ICollection<Album> Albums { get; set; } = new List<Album>();
}
