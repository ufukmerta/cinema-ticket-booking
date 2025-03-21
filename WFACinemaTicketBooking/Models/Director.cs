using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WFACinemaTicketBooking.Models;

[Table("director")]
public partial class Director
{
    [Key]
    [Column("directorID")]
    public int DirectorId { get; set; }

    [Required]
    [Column("name")]
    [StringLength(50)]
    public string Name { get; set; }

    [ForeignKey("DirectorId")]
    [InverseProperty("Directors")]
    public virtual ICollection<Movie> Movies { get; set; } = new List<Movie>();
}
