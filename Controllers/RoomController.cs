using Hotel_Reservation.Irepository;
using Hotel_Reservation.Models;
using Hotel_Reservation.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Hotel_Reservation.Controllers
{
    public class RoomController : Controller
    {
        IRoom roomRepository;
        IRoomType RoomTypeRepository;
        
        public RoomController(IRoom roomRepository, IRoomType RoomTypeRepository) 
        {
            this.roomRepository = roomRepository;
            this.RoomTypeRepository = RoomTypeRepository;
        }
       
        public IActionResult Index()
        {
            ViewBag.RoomType = RoomTypeRepository.GetAll();
            return View(roomRepository.GetAll());
        }

        public IActionResult Details(int id) 
        {
            ViewBag.RoomType = RoomTypeRepository.GetAll();
            return View(roomRepository.GetById(id));
        }

        [HttpGet]
        public IActionResult New()
        {
            ViewBag.RoomType = RoomTypeRepository.GetAll();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult New(Room room) 
        {
            if (ModelState.IsValid) 
            { 
                if(room.RoomType_Id != 0)
                {
                    try
                    {
                        ViewBag.RoomType = RoomTypeRepository.GetAll();
                        roomRepository.Insert(room);
                        return RedirectToAction("Index");
                    }
                    catch (Exception ex)
                    {
                        ModelState.AddModelError("", ex.Message);
                    }
            }
                
            }
            ViewBag.RoomType = RoomTypeRepository.GetAll();
            return View(room);
        }

        [HttpGet]
        public IActionResult Edit(int id) 
        {
            ViewBag.RoomType = RoomTypeRepository.GetAll();
            Room room = roomRepository.GetById(id);
            return View(room);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id,Room room) 
        {
            if(ModelState.IsValid) 
            {
                if (room.RoomType_Id != 0)
                {
                    try
                    {
                        roomRepository.Update(id, room);
                        return RedirectToAction("Index");
                        
                    }
                    catch (Exception ex)
                    {
                        ModelState.AddModelError("", ex.Message);
                    }
                }

            }

            ViewBag.RoomType = RoomTypeRepository.GetAll();
            return View(room);
           
            }
            
        

        [HttpGet]
        public IActionResult Delete(int id) 
        {
            roomRepository.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
