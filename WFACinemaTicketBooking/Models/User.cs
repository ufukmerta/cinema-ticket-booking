using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WFACinemaTicketBooking.Models;

[Table("user")]
public partial class User
{
    [Key]
    [Column("userID")]
    public int UserId { get; set; }

    [Required]
    [Column("name")]
    [StringLength(25)]
    public string Name { get; set; }

    [Required]
    [Column("surname")]
    [StringLength(25)]
    public string Surname { get; set; }

    [Column("profession")]
    [StringLength(50)]
    public string Profession { get; set; }

    [Column("phone_number")]
    [StringLength(11)]
    [Unicode(false)]
    public string PhoneNumber { get; set; }

    [Required]
    [Column("email")]
    [StringLength(200)]
    [Unicode(false)]
    public string Email { get; set; }

    [Required]
    [Column("password")]
    [StringLength(16)]
    [Unicode(false)]
    public string Password { get; set; }

    [Required]
    [Column("auth")]
    [StringLength(1)]
    [Unicode(false)]
    public string Auth { get; set; }

    [InverseProperty("User")]
    public virtual ICollection<TicketBooking> TicketBookings { get; set; } = new List<TicketBooking>();
}
