using MedicalAppoiments.Domain.Entities.appointments;
using MedicalAppoiments.Persistance.Models.appointments;
using MedicalAppointment.Application.Interfaces.IappointmentsService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MedicalAppointmentWeb.Controllers
{
    public class DoctorAvailibilityController1 : Controller
    {
        private readonly IDoctorAvailabilityService _doctorAvailabilityService;
       public DoctorAvailibilityController1 (IDoctorAvailabilityService doctorAvailabilityService) 
        {
            _doctorAvailabilityService = doctorAvailabilityService;
        }
        public  async Task<IActionResult> Index()
        { 
            var result = await _doctorAvailabilityService.GetAllDoctorAvailabilityAsync();

            if (result.success)
            {
                List<DoctorAvailability> doctorAvailabilities = (List<DoctorAvailability>)result.Data;
                return View(doctorAvailabilities);
            }
            return View();
        }


        public async Task<IActionResult> Details(int id)
        {
            var result = await _doctorAvailabilityService.GetDoctorAvailabilityByIdAsync(id);
            if (result.success)
            {
                List<DoctorAvailability> doctorAvailabilities = (List<DoctorAvailability>)result.Data;
                return View(doctorAvailabilities);
            }
            return View();
        }

       
        public ActionResult Create()
        {
            return View();
        }

      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( DoctorAvailability doctorAvailability)
        {
            
            try
            {
                var result = await _doctorAvailabilityService.SaveDoctorAvailabilityAsync(doctorAvailability);  

                if (result.success)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewBag.Message = result.message;
                    return View();
                }


            }
            catch
            {
                return View();
            }
        }

       
        public ActionResult Edit(int id)
        {
            return View();
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        
      
    }
}
