using Microsoft.AspNetCore.Mvc;
using Webmarket.Modelss;
using WebMarket.DataAccess.Services;
using WebMarket.DataAccess.Services.Interface;
using WebMarket.Modelss;

namespace WebMarketBook.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CoverTypeController : Controller
    {
        private readonly ICoverTypeService _coverTypeService;

        public CoverTypeController(ICoverTypeService coverTypeService)
        {
            _coverTypeService = coverTypeService;
        }

        public IActionResult Index()
        {
            IEnumerable<CoverType> CategoryList = _coverTypeService.GetAll();
            return View(CategoryList);
        }
        //Get
        public IActionResult Create()
        {


            return View();
        }

        //Post
        [HttpPost]
        public IActionResult Create(CoverType obj)
        {


            if (ModelState.IsValid) //true or false

            {
                _coverTypeService.Add(obj);
                
                TempData["success"] = "Die neue Category";
                return RedirectToAction("Index");
            }
            return View(obj);

        }


        //Get
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            //var categoryFromDb = _db.Categories.Find(id);
            var categoryFromDbFirst = _coverTypeService.GetFirstOrDefault(c => c.Id == id);
            //var categoryFromDbsingle = _db.Categories.SingleOrDefault(c => c.Id == id);
            if (categoryFromDbFirst == null)
            {
                return NotFound();
            }
            return View(categoryFromDbFirst);
        }

        //Post
        [HttpPost]
        public IActionResult Edit(CoverType obj)
        {



            if (ModelState.IsValid) //true or false

            {
                _coverTypeService.Update(obj);
                TempData["success"] = "Die neue Category edit";
          
                return RedirectToAction("Index");
            }
            return View(obj);
        }


        //Get
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var categoryFromDbFirst = _coverTypeService.GetFirstOrDefault(c => c.Id == id);
            //var categoryFromDbsingle = _db.Categories.SingleOrDefault(c => c.Id == id);
            if (categoryFromDbFirst == null)
            {
                return NotFound();
            }
            return View(categoryFromDbFirst);
        }
        //Post
        [HttpPost]
        public IActionResult DeletePost(int? id)
        {


            var obj = _coverTypeService.GetFirstOrDefault(c => c.Id == id);
            _coverTypeService.Remove(obj);
            TempData["success"] = "Die neue Category remove";
           
            return RedirectToAction("Index");


        }
    }
}
