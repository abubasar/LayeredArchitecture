using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Data.Configurations
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.ToTable("Student");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired()
                .HasMaxLength(50);
            builder.Property(x => x.CreatedOn).IsRequired()
                .HasPrecision(7);
            builder.Property(x => x.Grade)
              .HasMaxLength(2);
        }
    }
}
