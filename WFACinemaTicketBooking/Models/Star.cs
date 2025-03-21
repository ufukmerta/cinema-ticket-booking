using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WFACinemaTicketBooking.Models;

[Table("star")]
public partial class Star
{
    [Key]
    [Column("starID")]
    public int StarId { get; set; }

    [Required]
    [Column("name")]
    [StringLength(50)]
    public string Name { get; set; }

    [ForeignKey("StarId")]
    [InverseProperty("Stars")]
    public virtual ICollection<Movie> Movies { get; set; } = new List<Movie>();
}
