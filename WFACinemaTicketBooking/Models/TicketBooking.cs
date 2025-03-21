using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WFACinemaTicketBooking.Models;

[Table("ticket_booking")]
public partial class TicketBooking
{
    [Key]
    [Column("ticketID")]
    public int TicketId { get; set; }

    [Column("movie_sessionID")]
    public int MovieSessionId { get; set; }

    [Column("userID")]
    public int UserId { get; set; }

    [Column("seat_no")]
    public int SeatNo { get; set; }

    [Column("price", TypeName = "money")]
    public decimal Price { get; set; }

    [Column("ticket_date", TypeName = "datetime")]
    public DateTime TicketDate { get; set; }

    [ForeignKey("MovieSessionId")]
    [InverseProperty("TicketBookings")]
    public virtual MovieSession MovieSession { get; set; }

    [ForeignKey("UserId")]
    [InverseProperty("TicketBookings")]
    public virtual User User { get; set; }
}
