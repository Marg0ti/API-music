using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HernandezMargot_API_M.Models;

public partial class Pistum
{
    [Key]
    public int PistaId { get; set; }

    [StringLength(255, MinimumLength = 1, ErrorMessage = "El texto debe tener entre 1 y 255 caracteres.")]
    public string Nombre { get; set; } = null!;

    public int AlbumId { get; set; }

    [DisplayName("Código de género")]
    public int GeneroId { get; set; }

    [DisplayName("Duración")]
    [Range(1,20000, ErrorMessage = "Tiempo entre 1 y 20.000 segundos")]
    public int Duracion { get; set; }

    [ForeignKey("AlbumId")]
    [InverseProperty("Pista")]
    public virtual Album Album { get; set; } = null!;

    [ForeignKey("GeneroId")]
    [InverseProperty("Pista")]
    public virtual Genero Genero { get; set; } = null!;
}
