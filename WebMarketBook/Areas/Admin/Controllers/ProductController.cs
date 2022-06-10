using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.IO;
using Webmarket.Modelss;
using Webmarket.Modelss.ViewModel;
using WebMarket.DataAccess.Services.Interface;
using WebMarket.Modelss;

namespace WebMarketBook.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly ICoverTypeService _coverTypeService;
        private readonly IWebHostEnvironment _hostEnvironment;

        public ProductController(IProductService productService , ICategoryService categoryService , ICoverTypeService coverTypeService
            ,IWebHostEnvironment hostEnvironment)
        {
            _productService = productService;
            _categoryService = categoryService;
            _coverTypeService = coverTypeService;
            _hostEnvironment = hostEnvironment;
        }

        public IActionResult Index()
        {
            
            return View();
        }
     


        //Get
        public IActionResult Upsert(int? id)
        {
            ProductVM productVM = new()
            {
                Product = new(),
                CategoryList = _categoryService.GetAll().Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                }),
                CoverTypeList = _coverTypeService.GetAll().Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                }),
            };
            if (id == null || id == 0)
            {
                //Create
                //ViewBag.CategoryList= CategoryList;
                //ViewBag.CovertypeList = CoverTypeList;
                return View(productVM);
            }
            else
            {
                //Update
                productVM.Product=_productService.GetFirstOrDefault(u => u.Id==id);
                return View(productVM);
            }
          
            return View(productVM);
        }


        //Post
        [HttpPost]
        public IActionResult Upsert(ProductVM obj,IFormFile? file)
        {

            string wwwrootPath = _hostEnvironment.WebRootPath;

            if (ModelState.IsValid) //true or false

            {
                if(file!= null)
                {
                    string fileName= Guid.NewGuid().ToString();
                    var uploads = Path.Combine(wwwrootPath, @"images\products");
                    var extention= Path.GetExtension(file.FileName);

                    if (obj.Product.ImgeUrl!= null)
                    {
                        var oldImagePath= Path.Combine(wwwrootPath, obj.Product.ImgeUrl.TrimStart('\\'));
                        if(System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }
                    }

                    using (var fileStrems = new FileStream(Path.Combine(uploads, fileName + extention), FileMode.Create))
                    {
                        file.CopyTo(fileStrems);
                    }
                    obj.Product.ImgeUrl =  fileName+ extention;
                }
              



                if(obj.Product.Id==0) _productService.Add(obj);
              else _productService.Update(obj.Product);


                TempData["success"] = "Produkt wurde erfolgreich bearbeitet";
           
                return RedirectToAction("Index");
            }
            return View(obj);
        }


       

        #region API CALL 
        [HttpGet]
        public IActionResult GetAll()
        {
            var productlist = _productService.GetAll();
            return Json(new { data = productlist });
        }
        [HttpDelete]
        public IActionResult Delete(int? id)
        {


            var obj = _productService.GetFirstOrDefault(c => c.Id == id);
            if (obj == null)
            {
                return Json(new { success = false, message = "problem bei delete" });
            }
            var oldImagePath = Path.Combine(_hostEnvironment.WebRootPath, obj.ImgeUrl.TrimStart('\\'));
            if (System.IO.File.Exists(oldImagePath))
            {
                System.IO.File.Delete(oldImagePath);
            }
            _productService.Remove(obj);
            TempData["success"] = "Die Entfernung war erfolgreich";

            return Json(new { success = true, message = "erfolgreich delete" });


        }

        #endregion
    }
}
