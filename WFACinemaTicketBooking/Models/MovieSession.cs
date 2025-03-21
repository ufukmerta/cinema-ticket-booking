using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WFACinemaTicketBooking.Models;

[Table("movie_session")]
public partial class MovieSession
{
    [Key]
    [Column("movie_sessionID")]
    public int MovieSessionId { get; set; }

    [Column("movieID")]
    public int MovieId { get; set; }

    [Column("hallID")]
    public int HallId { get; set; }

    [Column("date")]
    public DateOnly Date { get; set; }

    [Column("sessionID")]
    public int SessionId { get; set; }

    [ForeignKey("HallId")]
    [InverseProperty("MovieSessions")]
    public virtual Hall Hall { get; set; }

    [ForeignKey("MovieId")]
    [InverseProperty("MovieSessions")]
    public virtual Movie Movie { get; set; }

    [ForeignKey("SessionId")]
    [InverseProperty("MovieSessions")]
    public virtual Session Session { get; set; }

    [InverseProperty("MovieSession")]
    public virtual ICollection<TicketBooking> TicketBookings { get; set; } = new List<TicketBooking>();
}
