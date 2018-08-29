using BilisimKreatif.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BilisimKreatif.Data.Maps
{
    public class ProductMap
    {
        public ProductMap(EntityTypeBuilder<Product> entityBuilder)
        {
            entityBuilder.HasKey(c => c.Id);
            entityBuilder.Property(c => c.Name).IsRequired().HasMaxLength(200);
            entityBuilder.Property(c=>c.Price).HasColumnType("DECIMAL(18,2)");
        }
    }

    
}
