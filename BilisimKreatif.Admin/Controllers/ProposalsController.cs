using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BilisimKreatif.Admin.Models;
using BilisimKreatif.Model;
using BilisimKreatif.Service;
using Microsoft.AspNetCore.Mvc;

namespace BilisimKreatif.Admin.Controllers
{
    public class ProposalsController : Controller
    {
        private readonly IMapper mapper;
        private readonly IProposalService proposalService;
        public ProposalsController(IMapper mapper, IProposalService proposalService)
        {
            this.mapper = mapper;
            this.proposalService = proposalService;
        }
        public async Task<IActionResult> Index()
        {
            var proposals = await proposalService.GetAllAsync();
            return View(proposals);
        }

        public IActionResult Create()
        {
            var Proposals = new ProposalViewModel();
            return View(Proposals);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProposalViewModel ProposalsVM)
        {
            if (ModelState.IsValid)
            {
                var Proposals = mapper.Map<Proposal>(ProposalsVM);
                try
                {
                    await proposalService.InsertAsync(Proposals);
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("Exception", "Kayıt işlemi sırasında beklenmeyen bir hata oluştu; durumu sistem yöneticisine bildiriniz.");
                    return View(ProposalsVM);
                }
                return RedirectToAction("Index");
            }
            return View(ProposalsVM);
        }

        public async Task<IActionResult> Edit(string id)
        {
            var Proposals = await proposalService.GetAsync(id);
            var ProposalsVM = mapper.Map<ProposalViewModel>(Proposals);
            return View(ProposalsVM);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ProposalViewModel ProposalsVM)
        {
            if (ModelState.IsValid)
            {
                var Proposals = await proposalService.GetAsync(ProposalsVM.Id);
                mapper.Map(ProposalsVM, Proposals, typeof(ProposalViewModel), typeof(Proposal));
                try
                {
                    await proposalService.UpdateAsync(Proposals);
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("Exception", "Kayıt işlemi sırasında beklenmeyen bir hata oluştu; durumu sistem yöneticisine bildiriniz.");
                    return View(ProposalsVM);
                }
                return RedirectToAction("Index");
            }
            return View(ProposalsVM);
        }

        public async Task<IActionResult> Delete(string id)
        {
            await proposalService.DeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}