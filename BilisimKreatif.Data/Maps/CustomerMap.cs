using BilisimKreatif.Model;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BilisimKreatif.Data.Maps
{
    public class CustomerMap
    {
        public CustomerMap(EntityTypeBuilder<Customer> entityBuilder)
        {
            entityBuilder.HasKey(c => c.Id);
            entityBuilder.Property(c => c.FirstName).IsRequired().HasMaxLength(200);
            entityBuilder.Property(c => c.LastName).IsRequired().HasMaxLength(200);
            entityBuilder.Ignore(c => c.FullName);
            entityBuilder.Property(c => c.Phone).HasMaxLength(200);
            entityBuilder.Property(c => c.Email).HasMaxLength(200);
        }
    }

    
}
