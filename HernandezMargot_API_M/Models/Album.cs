using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HernandezMargot_API_M.Models;

[Table("Album")]
public partial class Album
{
    [Key]
    [DisplayName("Código")]
    public int AlbumId { get; set; }

    [DisplayName("Título")]
    [StringLength(255, MinimumLength = 1, ErrorMessage = "El texto debe tener entre 1 y 255 caracteres.")]
    public string Titulo { get; set; } = null!;

    [DisplayName("Código del artista")]
    public int ArtistaId { get; set; }

    [ForeignKey("ArtistaId")]
    [InverseProperty("Albums")]
    [DisplayName("Artista")]
    public virtual Artistum Artista { get; set; } = null!;

    [InverseProperty("Album")]
    [DisplayName("Álbum")]
    public virtual ICollection<Pistum>? Pista { get; set; } = new List<Pistum>();
}
