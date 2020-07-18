using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnlineGrocery.Models;
using OnlineGrocery.ViewModels;

namespace OnlineGrocery.Controllers
{
    public class SuppliersController : Controller
    {
        private ISupplierRepository _supplierRepository;

        public SuppliersController(ISupplierRepository supplierRepository)
        {
            _supplierRepository = supplierRepository;
        }

        public IActionResult SuppliersDisplay()
        {
            var suppliers = _supplierRepository.ReturnSuppliers();
            return View(suppliers);
        }

        /// <summary>
        /// Functtion will create new supplier and add it to database
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult AddSupplier()
        {
            AddSupplierViewModel viewModel = new AddSupplierViewModel();

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult AddSupplier(AddSupplierViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                SuppliersModel model = new SuppliersModel();
                model.Name = viewModel.Name;
                model.Email = viewModel.Email;
                model.PhoneNumber = viewModel.PhoneNumber;

                _supplierRepository.AddSupplier(model);

                return RedirectToAction("SuppliersDisplay");
            }
            return View();
        }
    }
}
