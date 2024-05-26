using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

public partial class Person
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string? LastName { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string? FirstName { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string? Address { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string? City { get; set; }
}
