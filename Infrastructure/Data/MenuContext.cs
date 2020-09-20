using System;
using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Infrastructure.Data
{
    //TODO зачем partial ?
    public partial class MenuContext : DbContext
    {
        public MenuContext()
        {
        }

        public MenuContext(DbContextOptions<MenuContext> options)
            : base(options)
        {
        }

        public virtual DbSet<MenuItem> MenuItem { get; set; }

        //TODO Такую настройку делать не тут, а в Startup
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=HomeServer");
            }
        }

        //Имена в нотации Camel; Конфиги по сущностям лучше вынести в отдельные классы конфигурации EntityTypeConfiguration<T>, а тут их подключать
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MenuItem>(entity =>
            {
                entity.HasIndex(e => e.Title)
                    .HasName("UQ__MenuItem__E52A1BB3DCEEF5D2")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Calories)
                    .HasColumnName("calories")
                    .HasColumnType("numeric(5, 4)");

                entity.Property(e => e.CookingTime).HasColumnName("cooking_time");

                entity.Property(e => e.CreationDate)
                    .HasColumnName("creation_date")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(sysdatetime())");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Grams).HasColumnName("grams");

                entity.Property(e => e.Ingredients)
                    .HasColumnName("ingredients")
                    .HasColumnType("text");

                entity.Property(e => e.Price)
                    .HasColumnName("price")
                    .HasColumnType("money");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnName("title")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        //TODO зачем partial ?

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
