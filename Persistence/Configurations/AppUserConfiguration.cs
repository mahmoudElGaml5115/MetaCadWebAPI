using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Configurations
{ 
    public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        { 
            builder.HasKey(f => f.Id);
             
            builder.Property(u => u.FullName)
                .HasMaxLength(100) 
                .IsRequired(true);
             
            builder.Property(u => u.CountryCode) 
                .IsRequired(true); 
               
            builder.Property(u => u.Email)
                .HasMaxLength(255);  
            builder.HasIndex(u => u.NormalizedEmail).IsUnique();


            builder.Property(u => u.PhoneNumber)
                .HasMaxLength(14);
              
        }
    }
}
