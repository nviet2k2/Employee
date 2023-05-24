using Employee.DataAccess;
using Employee.Entity;
using Employee.Models;
using Employee.Services;
using Microsoft.AspNetCore.Mvc;

namespace Employee.Controllers
{
    public class TaxYearController : Controller
    {
        private ITaxYearService _taxyearservice;
        public TaxYearController(ITaxYearService taxyearservice)
        {
            _taxyearservice = taxyearservice;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var model = _taxyearservice.GetAll().Select(TaxYear => new TaxYearIndexViewModel
            {
                Id = TaxYear.Id,
                YearOfTax = TaxYear.YearOfTax,
            }).ToList();

            return View(model);
        }
        [HttpGet]
        public IActionResult Create()
        {
            var model = new TaxYearCreateViewModel();
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Create(TaxYearCreateViewModel model)
        {

            if(ModelState.IsValid)
            {
            var taxyear = new TaxYear
            {
                Id=model.Id,
                YearOfTax = model.YearOfTax,
            };
                await _taxyearservice.CreateAsSync(taxyear);
                return RedirectToAction("Index");
            }

            return View();
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            
            var taxyear = _taxyearservice.GetById(id);
            if(taxyear == null)
            {
                return NotFound();
            }
            var model = new TaxYearEditViewModel
            {
                Id=taxyear.Id,
                YearOfTax=taxyear.YearOfTax,

            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(TaxYearEditViewModel model)
        {
           
            if (ModelState.IsValid)
            {
                var taxyear = _taxyearservice.GetById(model.Id);

                taxyear.Id = model.Id;
                taxyear.YearOfTax = model.YearOfTax;
               
                await _taxyearservice.UpdateAsSync(taxyear);
                return RedirectToAction("Index");
            }

            return View(model);
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {

            var taxyear = _taxyearservice.GetById(id);
            if (taxyear == null)
            {
                return NotFound();
            }
            var model = new TaxYearDeleteViewModel
            {
                Id = taxyear.Id,
                YearOfTax = taxyear.YearOfTax,

            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(TaxYearDeleteViewModel model)
        {
            var taxyear = _taxyearservice.GetById(model.Id);
            if (taxyear == null)
            {
                return NotFound();
            }
                await _taxyearservice.DeleteById(model.Id);
                return RedirectToAction("Index");
           

          
        }
        [HttpGet]
        public IActionResult Detail(int id)
        {

            var taxyear = _taxyearservice.GetById(id);
            if (taxyear == null)
            {
                return NotFound();
            }
            var model = new TaxYearDetailViewModel
            {
                Id = taxyear.Id,
                YearOfTax = taxyear.YearOfTax,

            };
            return View(model);
        }
    }
}
