using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using OnlineGrocery.Models;
using OnlineGrocery.ViewModels;

namespace OnlineGrocery.Controllers
{
    public class CMSController : Controller
    {
        private readonly ICMSIndexRepository _cMSIndexRepository;

        private readonly IWebHostEnvironment _hostingEnvironment;

        public CMSController(ICMSIndexRepository cMSIndexRepository, IWebHostEnvironment hostingEnvironment)
        {
            _cMSIndexRepository = cMSIndexRepository;
            _hostingEnvironment = hostingEnvironment;
        }

        /// <summary>
        /// This function opens CMS for index in Admin window
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult CMSIndexPage()
        {
            CMSIndexViewModel model = new CMSIndexViewModel();
            model.Page = _cMSIndexRepository.Get(3);
            model.Photo1 = null;
            model.Photo2 = null;
            model.Photo3 = null;
            return View(model);
        }

        /// <summary>
        /// This function commits changes in Index
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult CMSIndexPage(CMSIndexViewModel model)
        {
            

            if(ModelState.IsValid == true)
            {
                string ImgPath1 = "";
                string ImgPath2 = "";
                string ImgPath3 = "";

                CMSIndexPageModel page = new CMSIndexPageModel();

                page.Id = model.Page.Id;
                page.Header_H1 = model.Page.Header_H1;
                page.Header_P1_Welcome = model.Page.Header_P1_Welcome;
                page.About_1_H3 = model.Page.About_1_H3;
                page.About_2_H3 = model.Page.About_2_H3;
                page.About_3_H3 = model.Page.About_3_H3;
                page.About_1_Text = model.Page.About_1_Text;
                page.About_2_Text = model.Page.About_2_Text;
                page.About_3_Text = model.Page.About_3_Text;
                page.Contact_H3 = model.Page.Contact_H3;
                page.Contact_P = model.Page.Contact_P;
                page.Contact_Phone_1 = model.Page.Contact_Phone_1;
                page.Contact_Phone_2 = model.Page.Contact_Phone_2;
                page.Contact_Email_1 = model.Page.Contact_Email_1;
                page.Contact_Email_2 = model.Page.Contact_Email_2;
                page.Contact_Address_Street = model.Page.Contact_Address_Street;
                page.Contact_Address_Postcode = model.Page.Contact_Address_Postcode;
                page.Contact_Address_City = model.Page.Contact_Address_City;

                //If there was an old image and user is editing one then chage image
                if (model.Photo1 != null)
                {
                    string filepath = Path.Combine(_hostingEnvironment.WebRootPath, "images", model.Page.About_1_Img_Path);
                    System.IO.File.Delete(filepath);

                    ImgPath1 = ProcessUploadedFile1(model);
                }

                //If there was an old image and user is editing one then chage image
                if (model.Photo2 != null)
                {
                    string filepath = Path.Combine(_hostingEnvironment.WebRootPath, "images", model.Page.About_2_Img_Path);
                    System.IO.File.Delete(filepath);

                    ImgPath2 = ProcessUploadedFile2(model);
                }

                //If there was an old image and user is editing one then chage image
                if (model.Photo3 != null)
                {
                    string filepath = Path.Combine(_hostingEnvironment.WebRootPath, "images", model.Page.About_3_Img_Path);
                    System.IO.File.Delete(filepath);

                    ImgPath3 = ProcessUploadedFile3(model);
                }

                if (ImgPath1 != "")
                {
                    page.About_1_Img_Path = ImgPath1;
                }
                else
                {
                    page.About_1_Img_Path = model.Page.About_1_Img_Path;
                }

                if (ImgPath2 != "")
                {
                    page.About_2_Img_Path = ImgPath2;
                }
                else
                {
                    page.About_2_Img_Path = model.Page.About_2_Img_Path;
                }

                if (ImgPath3 != "")
                {
                    page.About_3_Img_Path = ImgPath3;
                }
                else
                {
                    page.About_3_Img_Path = model.Page.About_3_Img_Path;
                }

                _cMSIndexRepository.Update(page);

                return RedirectToAction("Index" , "Home");
            }

            return View();

        }


        /// <summary>
        /// This function loads mock data for testing to database / file is included in wwroot
        /// </summary>
        public void LoadData()
        {
            CMSIndexLoader i = new CMSIndexLoader();
            _cMSIndexRepository.Add(i.PageLoad());
        }




        #region Helping Functions
        /// <summary>
        /// This function will process image path
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        private string ProcessUploadedFile1(CMSIndexViewModel model)
        {
            string uniqueFileName = null;
            if (model.Photo1 != null)
            {
                string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(model.Photo1.FileName);
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.Photo1.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }
        /// <summary>
        /// This function will process image path
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        private string ProcessUploadedFile2(CMSIndexViewModel model)
        {
            string uniqueFileName = null;
            if (model.Photo2 != null)
            {
                string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(model.Photo2.FileName);
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.Photo2.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }

        /// <summary>
        /// This function will process image path
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        private string ProcessUploadedFile3(CMSIndexViewModel model)
        {
            string uniqueFileName = null;
            if (model.Photo3 != null)
            {
                string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(model.Photo3.FileName);
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.Photo3.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }

        #endregion
    }
}
