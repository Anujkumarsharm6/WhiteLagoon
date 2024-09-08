using Microsoft.AspNetCore.Mvc;
using WhiteLagoon.Application.Common.Interfaces;
using WhiteLagoon.domain.Entities;
using WhiteLagoon.Infrastructure.Data;

namespace WhiteLagoon.web.Controllers
{


    public class VillaController : Controller
    {

        private readonly IVillaRepository _villaRepo;

        public VillaController(IVillaRepository villaRepo)
        {
            _villaRepo = villaRepo;
        }
        
        public IActionResult Index()
        {
            var villas = _villaRepo.GetAll();
            return View(villas);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Villa obj)
        {
            if(obj.Name == obj.Descripton)
            {
                ModelState.AddModelError("name", "The description cannot be same as name");
            }
            if(ModelState.IsValid)
            {
                _villaRepo.Add(obj);
                _villaRepo.Save();
                TempData["success"] = "Added Successfully!!";
                return RedirectToAction("Index");
            }
            TempData["error"] = "Failure";
            return View(obj);
        }
        [HttpGet]
        public IActionResult Update(int villaId)
        {
            Villa? obj = _villaRepo.Get(x => x.Id == villaId);
            if(obj == null)
            {
                return RedirectToAction("Error","Home");
            }
            return View(obj);
        }
        [HttpPost]
        public IActionResult Update(Villa obj)
        {
            if (ModelState.IsValid && obj.Id > 0)
            {
                _villaRepo.Update(obj);
                _villaRepo.Save();
                TempData["success"] = "Updated Successfully!!";
                return RedirectToAction("Index");
            }
            TempData["error"] = "Failure";
            return View(obj);
        }

        public IActionResult Delete(int villaId)
        {
            Villa? obj = _villaRepo.Get(x => x.Id == villaId);
            if (obj == null)
            {
                return RedirectToAction("Error", "Home");
            }
            return View(obj);
        }
        [HttpPost]
        public IActionResult Delete(Villa obj)
        {
            Villa? objFromDb = _villaRepo.Get(x=>x.Id == obj.Id);
            if (objFromDb is not null)
            {
                _villaRepo.Remove(objFromDb);
                _villaRepo.Save();
                TempData["success"] = "Deleted Successfully!!";
                return RedirectToAction("Index");
            }
            TempData["error"] = "Failure";
            return View(obj);
        }

    }
}
