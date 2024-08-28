using Hotel_Reservation.Irepository;
using Hotel_Reservation.Models;
using Microsoft.AspNetCore.Mvc;

namespace Hotel_Reservation.Controllers
{
    public class SeasonsController : Controller
    {
        ISeasons seasonsRepository;
        public SeasonsController(ISeasons seasonsRepository) 
        { 
            this.seasonsRepository = seasonsRepository;
        }

        public IActionResult Index()
        {
            return View(seasonsRepository.GetAll());
        }

        public IActionResult Details(int id)
        {
            return PartialView(seasonsRepository.GetById(id));
        }
        [HttpGet]
        public IActionResult New()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult New(Seasons seasons)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    seasonsRepository.Insert(seasons);
                    return RedirectToAction("Index");

                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                }

            }
            return View(seasons);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Seasons seasons = seasonsRepository.GetById(id);
            return View(seasons);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Seasons seasons)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    seasonsRepository.Update(id, seasons);
                    return RedirectToAction("Index");

                }
                catch(Exception ex) 
                {
                    ModelState.AddModelError("", ex.Message);

                }
            }
            return View(seasons);

        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            Seasons seasons = seasonsRepository.GetById(id);
            return PartialView("ConfirmDelete", seasons);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ConfirmDelete(Seasons seasons)
        {
            seasonsRepository.Delete(seasons.Id);
            return RedirectToAction("Index");
        }
    }
}
