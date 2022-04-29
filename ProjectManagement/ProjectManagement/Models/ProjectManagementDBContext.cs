using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ProjectManagement.Models
{
    public partial class ProjectManagementDBContext : DbContext
    {
        public ProjectManagementDBContext()
        {
        }

        public ProjectManagementDBContext(DbContextOptions<ProjectManagementDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<FollowUp> FollowUps { get; set; } = null!;
        public virtual DbSet<Project> Projects { get; set; } = null!;
        public virtual DbSet<Task> Tasks { get; set; } = null!;
        public virtual DbSet<UserDetail> UserDetails { get; set; } = null!;
        public virtual DbSet<UserList> UserLists { get; set; } = null!;
        public virtual DbSet<UserRole> UserRoles { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=localhost, 1433;Initial Catalog=ProjectManagementDB;Persist Security Info=False;User ID=sa;Password=funFett!5;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;Trusted_Connection=false;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FollowUp>(entity =>
            {
                entity.ToTable("follow_ups");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("created_date");

                entity.Property(e => e.Notes)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("notes");

                entity.Property(e => e.TaskId).HasColumnName("task_id");

                entity.Property(e => e.UpdatedById).HasColumnName("updated_by_id");
            });

            modelBuilder.Entity<Project>(entity =>
            {
                entity.ToTable("project");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ClientId).HasColumnName("client_id");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("created_date");

                entity.Property(e => e.ProjectDescription)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("project_description");

                entity.Property(e => e.ProjectManagerId).HasColumnName("project_manager_id");

                entity.Property(e => e.ProjectName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("project_name");

                entity.Property(e => e.Status)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("status");
            });

            modelBuilder.Entity<Task>(entity =>
            {
                entity.ToTable("task");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AssignedById).HasColumnName("assigned_by_id");

                entity.Property(e => e.AssignedToId).HasColumnName("assigned_to_id");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("created_date");

                entity.Property(e => e.ProjectId).HasColumnName("project_id");

                entity.Property(e => e.TaskDescription)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("task_description");

                entity.Property(e => e.TaskStatus)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("task_status");

                entity.Property(e => e.TaskTitle)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("task_title");

                entity.Property(e => e.UpdatedById).HasColumnName("updated_by_id");
            });

            modelBuilder.Entity<UserDetail>(entity =>
            {
                entity.ToTable("user_details");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Address)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("address");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.Phonenumber)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("phonenumber");

                entity.Property(e => e.UserListId).HasColumnName("user_list_id");
            });

            modelBuilder.Entity<UserList>(entity =>
            {
                entity.ToTable("user_list");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.Property(e => e.UserRolesId).HasColumnName("user_roles_id");

                entity.Property(e => e.Username)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("username");
            });

            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.ToTable("user_roles");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Role)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("role");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
