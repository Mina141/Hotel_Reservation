using Hotel_Reservation.Irepository;
using Hotel_Reservation.Models;
using Hotel_Reservation.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Hotel_Reservation.Controllers
{
    public class MealPlanController : Controller
    {
        IMealPlan mealPlanRepository;
        public MealPlanController(IMealPlan mealPlanRepository) 
        {
            this.mealPlanRepository = mealPlanRepository;
        }
        public IActionResult Index()
        {
            return View(mealPlanRepository.GetAll());
        }
        public IActionResult Details(int id)
        {
            return PartialView(mealPlanRepository.GetById(id));
        }
        [HttpGet]
        public IActionResult New()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult New(MealPlan meal)
        {
            if(ModelState.IsValid)
            {
                mealPlanRepository.Insert(meal);
                return RedirectToAction("Index");
            }
            return View(meal);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            MealPlan meal = mealPlanRepository.GetById(id);
            return View(meal);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, MealPlan meal)
        {
            if (ModelState.IsValid) 
            {
                mealPlanRepository.Update(id, meal);
                return RedirectToAction("Index");
            }
            return View(meal);
        }

     
        [HttpGet]
        public IActionResult Delete(int id)
        {
            MealPlan mealPlan = mealPlanRepository.GetById(id);
            return PartialView("ConfirmDelete", mealPlan);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ConfirmDelete(MealPlan mealPlan)
        {
            mealPlanRepository.Delete(mealPlan.Id);
            return RedirectToAction("Index");
        }
    }
}
