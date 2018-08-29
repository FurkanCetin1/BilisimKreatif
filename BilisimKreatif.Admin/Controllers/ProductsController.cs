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
    public class ProductsController : Controller
    {
        private readonly IMapper mapper;
        private readonly IProductService productService;
        public ProductsController(IMapper mapper, IProductService productService)
        {
            this.mapper = mapper;
            this.productService = productService;
        }
        public async Task<IActionResult> Index()
        {
            var products = await productService.GetAllAsync();
            return View(products);
        }

        public IActionResult Create()
        {
            var product = new ProductViewModel();
            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductViewModel productVM)
        {
            if (ModelState.IsValid) {
                var product = mapper.Map<Product>(productVM);
                try
                {
                    await productService.InsertAsync(product);
                } catch (Exception ex)
                {
                    ModelState.AddModelError("Exception", "Kayıt işlemi sırasında beklenmeyen bir hata oluştu; durumu sistem yöneticisine bildiriniz.");
                    return View(productVM);
                }
                return RedirectToAction("Index");
            }
            return View(productVM);
        }

        public async Task<IActionResult> Edit(string id)
        {
            var product = await productService.GetAsync(id);
            var productVM = mapper.Map<ProductViewModel>(product);
            return View(productVM);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ProductViewModel productVM)
        {
            if (ModelState.IsValid)
            {
                var product = await productService.GetAsync(productVM.Id);
                mapper.Map(productVM, product, typeof(ProductViewModel), typeof(Product));
                try
                {
                    await productService.UpdateAsync(product);
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("Exception", "Kayıt işlemi sırasında beklenmeyen bir hata oluştu; durumu sistem yöneticisine bildiriniz.");
                    return View(productVM);
                }
                return RedirectToAction("Index");
            }
            return View(productVM);
        }

        public async Task<IActionResult> Delete(string id)
        {
            await productService.DeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}