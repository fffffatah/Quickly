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

        public virtual DbSet<Auth> Auths { get; set; } = null!;
        public virtual DbSet<Comment> Comments { get; set; } = null!;
        public virtual DbSet<CommentAttachment> CommentAttachments { get; set; } = null!;
        public virtual DbSet<FkProjectsUser> FkProjectsUsers { get; set; } = null!;
        public virtual DbSet<Otp> Otps { get; set; } = null!;
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

            modelBuilder.Entity<Auth>(entity =>
            {
                entity.ToTable("Auth", "quickly");

                entity.Property(e => e.Id).HasDefaultValueSql("nextval('\"Auth_Id_seq\"'::regclass)");

                entity.Property(e => e.IpAddress).HasMaxLength(20);

                entity.Property(e => e.RefreshToken).HasMaxLength(256);
            });

            modelBuilder.Entity<Comment>(entity =>
            {
                entity.ToTable("Comments", "quickly");

                entity.HasComment("Table of Comments in Task");

                entity.Property(e => e.Id).HasDefaultValueSql("nextval('\"Comments_Id_seq\"'::regclass)");

                entity.Property(e => e.CommenterId).HasDefaultValueSql("nextval('\"Comments_CommenterId_seq\"'::regclass)");

                entity.Property(e => e.TaskComment).HasMaxLength(1024);

                entity.Property(e => e.TaskId).HasDefaultValueSql("nextval('\"Comments_TaskId_seq\"'::regclass)");

                entity.HasOne(d => d.Commenter)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.CommenterId)
                    .HasConstraintName("comments_users_id_fk");

                entity.HasOne(d => d.Task)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.TaskId)
                    .HasConstraintName("comments_tasks_id_fk");
            });

            modelBuilder.Entity<CommentAttachment>(entity =>
            {
                entity.ToTable("CommentAttachments", "quickly");

                entity.Property(e => e.Id).HasDefaultValueSql("nextval('\"CommentAttachments_Id_seq\"'::regclass)");

                entity.Property(e => e.CommentId).HasDefaultValueSql("nextval('\"CommentAttachments_CommentId_seq\"'::regclass)");

                entity.Property(e => e.FileUrl).HasMaxLength(256);

                entity.HasOne(d => d.Comment)
                    .WithMany(p => p.CommentAttachments)
                    .HasForeignKey(d => d.CommentId)
                    .HasConstraintName("commentattachments_comments_id_fk");
            });

            modelBuilder.Entity<FkProjectsUser>(entity =>
            {
                entity.ToTable("FK_ProjectsUsers", "quickly");

                entity.Property(e => e.Id).HasDefaultValueSql("nextval('\"FK_ProjectsUsers_Id_seq\"'::regclass)");

                entity.Property(e => e.ProjectId).HasDefaultValueSql("nextval('\"FK_ProjectsUsers_ProjectId_seq\"'::regclass)");

                entity.Property(e => e.UserId).HasDefaultValueSql("nextval('\"FK_ProjectsUsers_UserId_seq\"'::regclass)");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.FkProjectsUsers)
                    .HasForeignKey(d => d.ProjectId)
                    .HasConstraintName("fk_projectsusers_projects_id_fk");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.FkProjectsUsers)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("fk_projectsusers_users_id_fk");
            });

            modelBuilder.Entity<Otp>(entity =>
            {
                entity.ToTable("Otps", "quickly");

                entity.Property(e => e.Id).HasDefaultValueSql("nextval('\"Otp_Id_seq\"'::regclass)");

                entity.Property(e => e.Otp1)
                    .HasMaxLength(10)
                    .HasColumnName("Otp");

                entity.Property(e => e.UserId).HasDefaultValueSql("nextval('\"Otps_UserId_seq\"'::regclass)");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Otps)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("otps_users_id_fk");
            });

            modelBuilder.Entity<Project>(entity =>
            {
                entity.ToTable("Projects", "quickly");

                entity.Property(e => e.Id).HasDefaultValueSql("nextval('\"Projects_Id_seq\"'::regclass)");

                entity.Property(e => e.ProjectDetails).HasMaxLength(1024);

                entity.Property(e => e.ProjectImageUrl).HasMaxLength(256);

                entity.Property(e => e.ProjectName).HasMaxLength(128);
            });

            modelBuilder.Entity<Task>(entity =>
            {
                entity.ToTable("Tasks", "quickly");

                entity.Property(e => e.Id).HasDefaultValueSql("nextval('\"Tasks_Id_seq\"'::regclass)");

                entity.Property(e => e.AssignedTo).HasDefaultValueSql("nextval('\"Tasks_AssignedTo_seq\"'::regclass)");

                entity.Property(e => e.CreatedAt).HasColumnType("timestamp without time zone");

                entity.Property(e => e.Deadline).HasColumnType("timestamp without time zone");

                entity.Property(e => e.ProjectId).HasDefaultValueSql("nextval('\"Tasks_ProjectId_seq\"'::regclass)");

                entity.Property(e => e.TaskDescription).HasMaxLength(1024);

                entity.Property(e => e.TaskStatus).HasMaxLength(16);

                entity.Property(e => e.TaskTitle).HasMaxLength(128);

                entity.Property(e => e.TaskType).HasMaxLength(5);

                entity.HasOne(d => d.AssignedToNavigation)
                    .WithMany(p => p.Tasks)
                    .HasForeignKey(d => d.AssignedTo)
                    .HasConstraintName("tasks_users_id_fk");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.Tasks)
                    .HasForeignKey(d => d.ProjectId)
                    .HasConstraintName("tasks_projects_id_fk");
            });

            modelBuilder.Entity<TaskAttachment>(entity =>
            {
                entity.ToTable("TaskAttachments", "quickly");

                entity.Property(e => e.Id).HasDefaultValueSql("nextval('\"TaskAttachments_Id_seq\"'::regclass)");

                entity.Property(e => e.FileUrl).HasMaxLength(256);

                entity.Property(e => e.TaskId).HasDefaultValueSql("nextval('\"TaskAttachments_TaskId_seq\"'::regclass)");

                entity.HasOne(d => d.Task)
                    .WithMany(p => p.TaskAttachments)
                    .HasForeignKey(d => d.TaskId)
                    .HasConstraintName("taskattachments_tasks_id_fk");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("Users", "quickly");

                entity.Property(e => e.Id).HasDefaultValueSql("nextval('\"Users_Id_seq\"'::regclass)");

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
