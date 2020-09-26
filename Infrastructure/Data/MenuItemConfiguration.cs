using ApplicationCore.Entities.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data
{
    public class MenuItemConfiguration : IEntityTypeConfiguration<MenuItem>
    {
        public void Configure(EntityTypeBuilder<MenuItem> builder)
        {
            builder.HasIndex(e => e.Title)
                       .HasName("UQ__MenuItem__E52A1BB3DCEEF5D2")
                       .IsUnique();

            builder.Property(e => e.Id).HasColumnName("id");

            builder.Property(e => e.Calories)
                .HasColumnName("calories")
                .HasColumnType("numeric(5, 4)");

            builder.Property(e => e.CookingTime).HasColumnName("cooking_time");

            builder.Property(e => e.CreationDate)
                .HasColumnName("creation_date")
                .HasColumnType("datetime")
                .HasDefaultValueSql("(sysdatetime())");

            builder.Property(e => e.Description)
                .HasColumnName("description")
                .HasMaxLength(500)
                .IsUnicode(false);

            builder.Property(e => e.Grams).HasColumnName("grams");

            builder.Property(e => e.Ingredients)
                .HasColumnName("ingredients")
                .HasColumnType("nvarchar(max)");

            builder.Property(e => e.Price)
                .HasColumnName("price")
                .HasColumnType("money");

            builder.Property(e => e.Title)
                .IsRequired()
                .HasColumnName("title")
                .HasMaxLength(255)
                .IsUnicode(false);

        }
    }
}
