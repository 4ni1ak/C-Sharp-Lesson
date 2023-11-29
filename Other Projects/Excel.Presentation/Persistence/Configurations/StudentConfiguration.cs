using Excel.Presentation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Excel.Presentation.Persistence.Configurations
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
       
            // ID - Primary Key
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            // FirstName
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Name).HasMaxLength(60);
            
            // Department
            builder.Property(x => x.Department).IsRequired();
            builder.Property(x => x.Department).HasMaxLength(100);

            // Age
            builder.Property(x => x.Age).IsRequired();
            builder.Property(x => x.Age).HasColumnType("smallint");


            builder.ToTable("Students");
        }
    }
}
