using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WFACinemaTicketBooking.Models;

[Table("session")]
public partial class Session
{
    [Key]
    [Column("sessionID")]
    public int SessionId { get; set; }

    [Required]
    [Column("hour")]
    [StringLength(5)]
    [Unicode(false)]
    public string Hour { get; set; }

    [InverseProperty("Session")]
    public virtual ICollection<MovieSession> MovieSessions { get; set; } = new List<MovieSession>();
}
