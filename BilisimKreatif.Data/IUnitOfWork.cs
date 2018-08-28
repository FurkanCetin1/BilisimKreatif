using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BilisimKreatif.Data
{
    public interface IUnitOfWork
    {
        Task SaveChangesAsync();
    }
}
