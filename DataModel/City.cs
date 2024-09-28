using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataModel;

public partial class City
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Column("city")]
    [StringLength(50)]
    [Unicode(false)]
    public string City1 { get; set; } = null!;

    [Column("latitude")]
    public double Latitude { get; set; }

    [Column("longitude")]
    public double Longitude { get; set; }

    [Column("population")]
    public int Population { get; set; }

    [Column("countryID")]
    public int CountryId { get; set; }

    [ForeignKey("CountryId")]
    [InverseProperty("Cities")]
    public virtual Country Country { get; set; } = null!;
}
