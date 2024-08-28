using Hotel_Reservation.Irepository;
using Hotel_Reservation.Models;
using Microsoft.AspNetCore.Mvc;

namespace Hotel_Reservation.Controllers
{
    public class ReservationController : Controller
    {
        IReservation reservationRepository;
        IRoomType roomTypeRepository;
        IMealPlan mealPlanRepository;
        public ReservationController( IReservation reservationRepository, IRoomType roomTypeRepository, IMealPlan mealPlanRepository) 
        {
            this.reservationRepository = reservationRepository;
            this.roomTypeRepository = roomTypeRepository;
            this.mealPlanRepository = mealPlanRepository;
        }

        public IActionResult Index()
        {
            ViewBag.MealPlans=mealPlanRepository.GetAll();
            ViewBag.RoomType=roomTypeRepository.GetAll();
            return View(reservationRepository.GetAll());
        }

        public IActionResult Details(int id)
        {
            ViewBag.MealPlans = mealPlanRepository.GetAll();
            ViewBag.RoomType = roomTypeRepository.GetAll();

            return PartialView(reservationRepository.GetById(id));
        }

        [HttpGet]
        public IActionResult New()
        {
            ViewBag.MealPlans = mealPlanRepository.GetAll();
            ViewBag.RoomType = roomTypeRepository.GetAll();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult New(Reservation reservation)
        {
            if (ModelState.IsValid) 
            {
                if (reservation.Id != 0 )
                {
                    try
                    {
                        reservationRepository.Insert(reservation);
                        return RedirectToAction("Index");
                    }
                    catch (Exception ex)
                    {
                        ModelState.AddModelError("", ex.Message);
                    }

                }
                else
                {
                    ModelState.AddModelError("", "Select Room Type");

                    ModelState.AddModelError("","Select Meal Plan");
                }
            }

            ViewBag.MealPlans = mealPlanRepository.GetAll();
            ViewBag.RoomType = roomTypeRepository.GetAll();
            return View(reservation);
            
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Reservation reservation)
        {
            if (ModelState.IsValid)
            {
                if (reservation.Id!=5)
                {
                    try
                    {
                        reservationRepository.Update(id, reservation);
                        return RedirectToAction("Index");
                    }
                    catch (Exception ex)
                    {
                        ModelState.AddModelError("", ex.Message);
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Select Room Type");

                    ModelState.AddModelError("", "Select Meal Plan");
                }
            }
            ViewBag.MealPlans = mealPlanRepository.GetAll();
            ViewBag.RoomType = roomTypeRepository.GetAll();
            return View(reservation);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            Reservation reservation = reservationRepository.GetById(id);
            return PartialView("ConfirmDelete", reservation);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ConfirmDelete(Reservation reservation)
        {
            reservationRepository.Delete(reservation.Id);
            return RedirectToAction("Index");
        }
    }
}
