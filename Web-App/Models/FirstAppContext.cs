using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Web_App.Models;

public partial class FirstAppContext : DbContext
{
    public FirstAppContext()
    {
    }

    public FirstAppContext(DbContextOptions<FirstAppContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Person> Persons { get; set; }

    public virtual DbSet<Users> Users { get; set; }

    //    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
    //        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-B6E1A1I\\SQLEXPRESS;Initial Catalog=first_app;Integrated Security=True;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Person>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Persons__AA2FFBE59142FB07");

        });

        modelBuilder.Entity<Users>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Users__3214EC27D37CD6DE");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
