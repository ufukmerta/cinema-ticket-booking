using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WFACinemaTicketBooking.Models;

[Table("hall")]
public partial class Hall
{
    [Key]
    [Column("hallID")]
    public int HallId { get; set; }

    [Required]
    [Column("name")]
    [StringLength(15)]
    public string Name { get; set; }

    [Column("hall_capacity")]
    public int HallCapacity { get; set; }

    [InverseProperty("Hall")]
    public virtual ICollection<MovieSession> MovieSessions { get; set; } = new List<MovieSession>();
}
