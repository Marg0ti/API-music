using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HernandezMargot_API_M.Models;

[Table("Genero")]
public partial class Genero
{
    [Key]
    public int GeneroId { get; set; }

    [StringLength(255)]
    public string Nombre { get; set; } = null!;

    [InverseProperty("Genero")]
    public virtual ICollection<Pistum> Pista { get; set; } = new List<Pistum>();
}
