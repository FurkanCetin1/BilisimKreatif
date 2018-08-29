using AutoMapper;
using BilisimKreatif.Admin.Models;
using BilisimKreatif.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BilisimKreatif.Admin.Mappings
{
    public class DomainProfile:Profile
    {
        public DomainProfile()
        {
            CreateMap<Customer, CustomerViewModel>();
            CreateMap<CustomerViewModel, Customer>();
        }
        
    }
}
