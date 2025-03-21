using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WFACinemaTicketBooking.Models;

[Table("genre")]
public partial class Genre
{
    [Key]
    [Column("genreID")]
    public int GenreId { get; set; }

    [Required]
    [Column("name")]
    [StringLength(20)]
    public string Name { get; set; }

    [ForeignKey("GenreId")]
    [InverseProperty("Genres")]
    public virtual ICollection<Movie> Movies { get; set; } = new List<Movie>();
}
