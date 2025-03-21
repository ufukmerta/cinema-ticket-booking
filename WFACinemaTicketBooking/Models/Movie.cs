using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WFACinemaTicketBooking.Models;

[Table("movie")]
public partial class Movie
{
    [Key]
    [Column("movieID")]
    public int MovieId { get; set; }

    [Required]
    [Column("name")]
    [StringLength(50)]
    public string Name { get; set; }

    [Column("description")]
    public string Description { get; set; }

    [Column("duration")]
    [StringLength(5)]
    public string Duration { get; set; }

    [Column("image_url")]
    [StringLength(100)]
    public string ImageUrl { get; set; }

    [Column("trailer")]
    [StringLength(50)]
    public string Trailer { get; set; }

    [InverseProperty("Movie")]
    public virtual ICollection<MovieSession> MovieSessions { get; set; } = new List<MovieSession>();

    [ForeignKey("MovieId")]
    [InverseProperty("Movies")]
    public virtual ICollection<Director> Directors { get; set; } = new List<Director>();

    [ForeignKey("MovieId")]
    [InverseProperty("Movies")]
    public virtual ICollection<Genre> Genres { get; set; } = new List<Genre>();

    [ForeignKey("MovieId")]
    [InverseProperty("Movies")]
    public virtual ICollection<Star> Stars { get; set; } = new List<Star>();
}
