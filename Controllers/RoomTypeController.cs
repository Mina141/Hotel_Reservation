using Hotel_Reservation.Irepository;
using Hotel_Reservation.Models;
using Hotel_Reservation.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Hotel_Reservation.Controllers
{
    public class RoomTypeController : Controller
    {
        IRoomType roomTypeRepository;
        public RoomTypeController(IRoomType roomTypeRepository) 
        { 
            this.roomTypeRepository = roomTypeRepository;
        }
        public IActionResult Index()
        {
            return View(roomTypeRepository.GetAll());
        }

        public IActionResult Details(int id)
        {
            return PartialView(roomTypeRepository.GetById(id));
        }

        [HttpGet]
        public IActionResult New()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult New(RoomType room)
        {
            if (ModelState.IsValid) 
            {
                try
                {
                    roomTypeRepository.Insert(room);
                    return RedirectToAction("Index");
                }
                catch(Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                }
            }
            return View(room);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            RoomType roomType = roomTypeRepository.GetById(id);
            return View(roomType);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, RoomType room)
        {
            if (ModelState.IsValid) 
            {
                try
                {
                    roomTypeRepository.Update(id, room);
                    return RedirectToAction("Index");
                }
                catch(Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                }

            }
            return View(room);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ConfirmDelete(RoomType roomType)
        {
            roomTypeRepository.Delete(roomType.Id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            RoomType roomType = roomTypeRepository.GetById(id);
            return PartialView("ConfirmDelete", roomType);
        }
   
    }
}
