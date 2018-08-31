using BilisimKreatif.Data;
using BilisimKreatif.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BilisimKreatif.Service
{
    public class ProposalService : IProposalService
    {
        private readonly IRepository<Proposal> proposalRepository;
        private readonly IUnitOfWork unitOfWork;
        public ProposalService(IUnitOfWork unitOfWork, IRepository<Proposal> proposalRepository)
        {
            this.proposalRepository = proposalRepository;
            this.unitOfWork = unitOfWork;
        }

        public async Task DeleteAsync(Proposal entity)
        {
            proposalRepository.Delete(entity);
            await unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteAsync(string id)
        {
            var entity = await proposalRepository.GetAsync(id);
            proposalRepository.Delete(entity);
            await unitOfWork.SaveChangesAsync();
        }

        public async Task<Proposal> GetAsync(string id)
        {
            return await proposalRepository.GetAsync(id);
        }

        public async Task<IEnumerable<Proposal>> GetAllAsync()
        {
            return await proposalRepository.GetAllAsync();
        }

        public async Task InsertAsync(Proposal entity)
        {
            proposalRepository.Insert(entity);
            await unitOfWork.SaveChangesAsync();
        }

        public async Task UpdateAsync(Proposal entity)
        {
            proposalRepository.Update(entity);
            await unitOfWork.SaveChangesAsync();
        }

        public async Task<bool> AnyAsync(string id)
        {
            return await proposalRepository.AnyAsync(a => a.Id == id);
        }
    }

    public interface IProposalService
    {
        Task<IEnumerable<Proposal>> GetAllAsync();
        Task<Proposal> GetAsync(string id);
        Task InsertAsync(Proposal entity);
        Task UpdateAsync(Proposal entity);
        Task DeleteAsync(Proposal entity);
        Task DeleteAsync(string id);
        Task<bool> AnyAsync(string id);
    }
}
