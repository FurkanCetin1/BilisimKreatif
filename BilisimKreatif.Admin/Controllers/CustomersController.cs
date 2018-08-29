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
    public class CustomersController : Controller
    {
        private readonly IMapper mapper;
        private readonly ICustomerService customerService;
        public CustomersController(IMapper mapper, ICustomerService customerService)
        {
            this.mapper = mapper;
            this.customerService = customerService;
        }
        public async Task<IActionResult> Index()
        {
            var customers = await customerService.GetAllAsync();
            return View(customers);
        }

        public IActionResult Create()
        {
            var customer = new CustomerViewModel();
            return View(customer);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CustomerViewModel customerVM)
        {
            if (ModelState.IsValid) {
                var customer = mapper.Map<Customer>(customerVM);
                try
                {
                    await customerService.InsertAsync(customer);
                } catch (Exception ex)
                {
                    ModelState.AddModelError("Exception", "Kayıt işlemi sırasında beklenmeyen bir hata oluştu; durumu sistem yöneticisine bildiriniz.");
                    return View(customerVM);
                }
                return RedirectToAction("Index");
            }
            return View(customerVM);
        }

        public async Task<IActionResult> Edit(string id)
        {
            var customer = await customerService.GetAsync(id);
            var customerVM = mapper.Map<CustomerViewModel>(customer);
            return View(customerVM);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CustomerViewModel customerVM)
        {
            if (ModelState.IsValid)
            {
                var customer = await customerService.GetAsync(customerVM.Id);
                mapper.Map(customerVM, customer, typeof(CustomerViewModel), typeof(Customer));
                try
                {
                    await customerService.UpdateAsync(customer);
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("Exception", "Kayıt işlemi sırasında beklenmeyen bir hata oluştu; durumu sistem yöneticisine bildiriniz.");
                    return View(customerVM);
                }
                return RedirectToAction("Index");
            }
            return View(customerVM);
        }

        public async Task<IActionResult> Delete(string id)
        {
            await customerService.DeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}