using BilisimKreatif.Model;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BilisimKreatif.Data.Maps
{
    public class ProposalMap
    {
        public ProposalMap(EntityTypeBuilder<Proposal> entityBuilder)
        {
            entityBuilder.HasKey(c => c.Id);
            entityBuilder.Property(c => c.CompanyName).IsRequired().HasMaxLength(200);
            entityBuilder.Property(c => c.Authorize).IsRequired().HasMaxLength(200);
            entityBuilder.Property(c => c.Phone).HasMaxLength(200);
            entityBuilder.Property(c => c.Email).HasMaxLength(200);
        }
    }
}
