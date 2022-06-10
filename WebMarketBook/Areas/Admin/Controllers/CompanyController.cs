using Microsoft.AspNetCore.Mvc;
using Webmarket.Modelss;
using WebMarket.DataAccess.Services.Interface;
using WebMarket.Modelss;

namespace WebMarketBook.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CompanyController : Controller
    {
        private readonly ICopmanyService _copmanyService;

        public CompanyController(ICopmanyService companyService)
        {
            _copmanyService = companyService;
        }

        public IActionResult Index()
        {
            IEnumerable<Company> CategoryList = _copmanyService.GetAll();
            return View(CategoryList);
        }
        //Get
        public IActionResult Create()
        {

            return View();
        }

        //Post
        [HttpPost]
        public IActionResult Create(Company obj)
        {
          

            if (ModelState.IsValid) //true or false

            {
                _copmanyService.Add(obj);
              
                TempData["success"] = "Die neue company";
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
            var categoryFromDbFirst = _copmanyService.GetFirstOrDefault(c => c.Id == id);
            //var categoryFromDbsingle = _db.Categories.SingleOrDefault(c => c.Id == id);
            if (categoryFromDbFirst == null)
            {
                return NotFound();
            }
            return View(categoryFromDbFirst);
        }

        //Post
        [HttpPost]
        public IActionResult Edit(Company obj)
        {

           

            if (ModelState.IsValid) //true or false

            {
                _copmanyService.Update(obj);
                TempData["success"] = "Die neue company edit";
           
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

            var companyFromDbFirst = _copmanyService.GetFirstOrDefault(c => c.Id == id);
            //var categoryFromDbsingle = _db.Categories.SingleOrDefault(c => c.Id == id);
            if (companyFromDbFirst == null)
            {
                return NotFound();
            }
            return View(companyFromDbFirst);
        }
        //Post
        [HttpPost]
        public IActionResult DeletePost(int? id)
        {


            var obj = _copmanyService.GetFirstOrDefault(c => c.Id == id);
            _copmanyService.Remove(obj);
            TempData["success"] = "Die neue company remove";
            
            return RedirectToAction("Index");


        }
    }
}
