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
        private IProductRepository _productRepository;

        public SuppliersController(ISupplierRepository supplierRepository, IProductRepository productRepository)
        {
            _supplierRepository = supplierRepository;
            _productRepository = productRepository;
        }

        public IActionResult SuppliersDisplay()
        {
            List<SuppliersModel> suppliers = _supplierRepository.ReturnSuppliers().ToList();
            return View(suppliers);
        }

        /// <summary>
        /// Functtion will create new supplier and add it to database
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult AddSupplier()
        {
            SupplierViewModel viewModel = new SupplierViewModel();

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult AddSupplier(SupplierViewModel viewModel)
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

        [HttpGet]
        public IActionResult EditSupplier(int Id)
        {
            SuppliersModel supplier = _supplierRepository.GetSupplier(Id);

            if(supplier != null)
            {
                SupplierViewModel model = new SupplierViewModel();

                model.Email = supplier.Email;
                model.Name = supplier.Name;
                model.PhoneNumber = supplier.PhoneNumber;
                model.Id = supplier.Id;
                model.OldName = supplier.Name;
                return View(model);
            }

            return RedirectToAction("Error");
        }

        [HttpPost]
        public IActionResult EditSupplier(SupplierViewModel supplier)
        {
            if (ModelState.IsValid)
            {
                SuppliersModel new_model = new SuppliersModel();
                
                new_model.Email = supplier.Email;
                new_model.Id = supplier.Id;
                new_model.Name = supplier.Name;
                new_model.PhoneNumber = supplier.PhoneNumber;

                //Update supplier name for the products
                List<ProductModel> products = _productRepository.GetProductsOfSupplier(supplier.OldName);
                for(int i = 0; i < products.Count; i++)
                {
                    ProductModel product = new ProductModel();
                    product = products[i];
                    product.SupplierName = new_model.Name;
                    _productRepository.Update(product);
                }

                _supplierRepository.EditSupplier(new_model);
                return RedirectToAction("SuppliersDisplay");
            }

            return View();
        }


        public IActionResult DeleteSupplier(SupplierViewModel model)
        {
            if(model != null)
            {
                _supplierRepository.DeleteSupplier(model.Id);
            }
            return RedirectToAction("SuppliersDisplay");
        }
    }
}
