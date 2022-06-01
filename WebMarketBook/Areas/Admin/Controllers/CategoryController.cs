using Microsoft.AspNetCore.Mvc;

using WebMarket.DataAccess.Services.Interface;
using WebMarket.Modelss;

namespace WebMarketBook.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _cotegoryService;

        public CategoryController(ICategoryService cotegoryService)
        {
            _cotegoryService = cotegoryService;
        }

        public IActionResult Index()
        {
            IEnumerable<Category> CategoryList = _cotegoryService.GetAll();
            return View(CategoryList);
        }
        //Get
        public IActionResult Create()
        {

            return View();
        }

        //Post
        [HttpPost]
        public IActionResult Create(Category obj)
        {
            if (obj.Name == obj.DesplayOrder.ToString())
            {
                ModelState.AddModelError("Name", " das mus nicht gleich sein");
            }

            if (ModelState.IsValid) //true or false

            {
                _cotegoryService.Add(obj);
              
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
            var categoryFromDbFirst = _cotegoryService.GetFirstOrDefault(c => c.Id == id);
            //var categoryFromDbsingle = _db.Categories.SingleOrDefault(c => c.Id == id);
            if (categoryFromDbFirst == null)
            {
                return NotFound();
            }
            return View(categoryFromDbFirst);
        }

        //Post
        [HttpPost]
        public IActionResult Edit(Category obj)
        {

            if (obj.Name == obj.DesplayOrder.ToString())
            {
                ModelState.AddModelError("Name", " das mus nicht gleich sein");
            }

            if (ModelState.IsValid) //true or false

            {
                _cotegoryService.Update(obj);
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

            var categoryFromDbFirst = _cotegoryService.GetFirstOrDefault(c => c.Id == id);
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


            var obj = _cotegoryService.GetFirstOrDefault(c => c.Id == id);
            _cotegoryService.Remove(obj);
            TempData["success"] = "Die neue Category remove";
            
            return RedirectToAction("Index");


        }
    }
}
