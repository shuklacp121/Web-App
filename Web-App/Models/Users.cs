using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

public partial class Users
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string? Name { get; set; } 

    [StringLength(255)]
    [Unicode(false)]
    public string? Email { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string? Password { get; set; }
}
