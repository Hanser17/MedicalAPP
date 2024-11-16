using AutoMapper;
using MedicalAppoiments.Domain.Entities.appointments;
using MedicalAppoiments.Persistance.Models.appointments;
using MedicalAppoiments.Persistance.Models.DoctorAvailivilityModel;
using MedicalAppointment.Application.Interfaces.IappointmentsService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MedicalAppointmentWeb.Controllers
{
    public class DoctorAvailibilityController1 : Controller
    {
        private readonly IDoctorAvailabilityService _doctorAvailabilityService;
        private readonly IMapper _mapper;
        public DoctorAvailibilityController1 (IDoctorAvailabilityService doctorAvailabilityService , IMapper mapper) 
        {
            _doctorAvailabilityService = doctorAvailabilityService;
            _mapper = mapper;
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
                DoctorAvailability doctorAvailabilities = (DoctorAvailability)result.Data;
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
        public async Task<IActionResult> Create( DoctorAvailibilitySaveDTO  doctorAvailibilitySaveDTO)
        {
            
            try
            {

                DoctorAvailability doctorAvailability = _mapper.Map<DoctorAvailability>(doctorAvailibilitySaveDTO);
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


        public async Task<IActionResult> Edit(int id)
          {
            var result = await _doctorAvailabilityService.GetDoctorAvailabilityByIdAsync(id);
            if(result.success)
            {
                DoctorAvailibilityUpdateDTO doctorAvailibilityUpdateDTO = _mapper.Map<DoctorAvailibilityUpdateDTO>(result.Data);
                return View(doctorAvailibilityUpdateDTO);
            }
            return View();
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public  async Task<IActionResult> Edit(DoctorAvailibilityUpdateDTO doctorAvailibilityUpdateDTO)
        {
            try
            {
                DoctorAvailability doctorAvailability = _mapper.Map<DoctorAvailability>(doctorAvailibilityUpdateDTO);
                var result = await _doctorAvailabilityService.UpdateDoctorAvailabilityAsync(doctorAvailability);
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

        
      
    }
}
