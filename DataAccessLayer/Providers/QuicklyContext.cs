using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DataAccessLayer.Providers
{
    public partial class QuicklyContext : DbContext
    {
        public QuicklyContext()
        {
        }

        public QuicklyContext(DbContextOptions<QuicklyContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Comment> Comments { get; set; } = null!;
        public virtual DbSet<CommentAttachment> CommentAttachments { get; set; } = null!;
        public virtual DbSet<FkProjectsUser> FkProjectsUsers { get; set; } = null!;
        public virtual DbSet<Project> Projects { get; set; } = null!;
        public virtual DbSet<Task> Tasks { get; set; } = null!;
        public virtual DbSet<TaskAttachment> TaskAttachments { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql(Environment.GetEnvironmentVariable("POSTGRE_SQL"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasPostgresExtension("pg_catalog", "adminpack");

            modelBuilder.Entity<Comment>(entity =>
            {
                entity.ToTable("Comments", "quickly");

                entity.HasComment("Table of Comments in Task");

                entity.Property(e => e.Id).HasDefaultValueSql("gen_random_uuid()");

                entity.Property(e => e.TaskComment).HasMaxLength(1024);

                entity.HasOne(d => d.Commenter)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.CommenterId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("comments_users_id_fk");

                entity.HasOne(d => d.Task)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.TaskId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("comments_tasks_id_fk");
            });

            modelBuilder.Entity<CommentAttachment>(entity =>
            {
                entity.ToTable("CommentAttachments", "quickly");

                entity.Property(e => e.Id).HasDefaultValueSql("gen_random_uuid()");

                entity.Property(e => e.FileUrl).HasMaxLength(256);

                entity.HasOne(d => d.Comment)
                    .WithMany(p => p.CommentAttachments)
                    .HasForeignKey(d => d.CommentId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("commentattachments_comments_id_fk");
            });

            modelBuilder.Entity<FkProjectsUser>(entity =>
            {
                entity.ToTable("FK_ProjectsUsers", "quickly");

                entity.Property(e => e.Id).HasDefaultValueSql("gen_random_uuid()");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.FkProjectsUsers)
                    .HasForeignKey(d => d.ProjectId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("fk_projectsusers_projects_id_fk");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.FkProjectsUsers)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("fk_projectsusers_users_id_fk");
            });

            modelBuilder.Entity<Project>(entity =>
            {
                entity.ToTable("Projects", "quickly");

                entity.Property(e => e.Id).HasDefaultValueSql("gen_random_uuid()");

                entity.Property(e => e.ProjectDetails).HasMaxLength(1024);

                entity.Property(e => e.ProjectImageUrl).HasMaxLength(256);

                entity.Property(e => e.ProjectName).HasMaxLength(128);
            });

            modelBuilder.Entity<Task>(entity =>
            {
                entity.ToTable("Tasks", "quickly");

                entity.Property(e => e.Id).HasDefaultValueSql("gen_random_uuid()");

                entity.Property(e => e.TaskDescription).HasMaxLength(1024);

                entity.Property(e => e.TaskStatus).HasMaxLength(16);

                entity.Property(e => e.TaskTitle).HasMaxLength(128);

                entity.Property(e => e.TaskType).HasMaxLength(5);
            });

            modelBuilder.Entity<TaskAttachment>(entity =>
            {
                entity.ToTable("TaskAttachments", "quickly");

                entity.Property(e => e.Id).HasDefaultValueSql("gen_random_uuid()");

                entity.Property(e => e.FileUrl).HasMaxLength(256);

                entity.HasOne(d => d.Task)
                    .WithMany(p => p.TaskAttachments)
                    .HasForeignKey(d => d.TaskId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("taskattachments_tasks_id_fk");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("Users", "quickly");

                entity.Property(e => e.Id).HasDefaultValueSql("gen_random_uuid()");

                entity.Property(e => e.Email).HasMaxLength(64);

                entity.Property(e => e.FullName).HasMaxLength(64);

                entity.Property(e => e.IsVerified).HasDefaultValueSql("false");

                entity.Property(e => e.Pass).HasMaxLength(128);

                entity.Property(e => e.Phone).HasMaxLength(20);

                entity.Property(e => e.ProfileImageUrl).HasMaxLength(256);

                entity.Property(e => e.UserType).HasMaxLength(16);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
