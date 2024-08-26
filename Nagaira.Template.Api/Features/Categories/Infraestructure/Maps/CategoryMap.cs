using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nagaira.Template.Api.Features.Categories.Domain.Entities;

namespace Nagaira.Template.Api.Features.Categories.Infraestructure.Maps
{
    public class CategoryMap : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("categories", "example");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id").ValueGeneratedOnAdd();
            builder.Property(x => x.Description).HasColumnName("description");
            builder.Property(x => x.Active).HasColumnName("active");
            builder.Property(x => x.DateRegister).HasColumnName("date_register").HasColumnType("timestamp without time zone");
            builder.Property(x => x.DateModification).HasColumnName("date_modification").HasColumnType("timestamp without time zone");
            builder.Property(x => x.UserRegister).HasColumnName("user_register");
            builder.Property(x => x.UserModification).HasColumnName("user_modification");
        }
    }
}
