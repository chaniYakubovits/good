using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
//using ex2.Models;
namespace ex2.Models;

public partial class TasksContext : DbContext
{
    public TasksContext()
    {
    }

    public TasksContext(DbContextOptions<TasksContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Attachment> Attachments { get; set; }

    public virtual DbSet<Project> Projects { get; set; }

    public virtual DbSet<Tasks> Tasks { get; set; }

    public virtual DbSet<Users> Users { get; set; }

    public virtual DbSet<Logger1> Logger1 { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Attachment>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Project>(entity =>
        {
            entity.HasKey(x => x.Id);

            entity.ToTable("Project");

            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Tasks>(entity =>
        {
            entity.HasKey(x => x.Id);

            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Attachments).WithMany(p => p.Tasks)
                .HasForeignKey(d => d.AttachmentsId)
                .HasConstraintName("FK_Tasks_Attachments");

            entity.HasOne(d => d.Project).WithMany(p => p.Tasks)
                .HasForeignKey(d => d.ProjectId)
                .HasConstraintName("FK_Tasks_Project");

            entity.HasOne(d => d.User).WithMany(p => p.Tasks)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_Tasks_User");
        });

        modelBuilder.Entity<Users>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.ToTable("User");

            entity.Property(e => e.Aderss)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PhonNumber)
                .HasMaxLength(50)
                .IsUnicode(false);
        });
        modelBuilder.Entity<Logger1>(entity =>
        {
            entity.HasKey(e => e.Messege);
                //.HasMaxLength(500)
                //.IsUnicode(false);
            entity.Property(e => e.Date)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
