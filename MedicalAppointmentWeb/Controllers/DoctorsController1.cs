using AutoMapper;
using MedicalAppoiments.Domain.Entities.users;
using MedicalAppoiments.Persistance.Models.usersModel;
using MedicalAppointment.Application.Interfaces.Iusersservice;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MedicalAppointmentWeb.Controllers
{
    public class DoctorsController1 : Controller
    {
        private readonly IDoctorService _doctorService;
        private readonly IMapper _mapper;
        public DoctorsController1 (IDoctorService doctorService, IMapper mapper)
        {
            _doctorService = doctorService;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            var result = await _doctorService.GetAllDoctorsAsync();
            if (result.success)
            {
                List<DoctorsModel> doctorsModels = (List<DoctorsModel>)result.Data;
                return View(doctorsModels);
            }
            else
            {
                return View();
            }
            
        }
        public async Task<IActionResult> Details(int id)
        {
            var result = await _doctorService.GetDoctorByIdAsync(id);
            if (result.success)
            {
                DoctorsModel doctorsModel = (DoctorsModel)result.Data; 
                return View(doctorsModel);
            }
            return View();
        }

       
        public ActionResult Create()
        {
            return View();
        }

        // POST: DoctorsController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DoctorsSaveDTO doctorsSaveDTO)
        { 
           
            try
            {
                Doctors doctors = _mapper.Map<Doctors>(doctorsSaveDTO);
                doctors.IsActive = true;
                doctors.CreatedAt = DateTime.Now;
                var result = await _doctorService.SaveDoctorAsync(doctors);
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
            var result = await _doctorService.GetDoctorByIdAsync(id);
            if (result.success)
            {
                DoctorUpdateDTO doctorUpdateDTO = _mapper.Map<DoctorUpdateDTO>(result.Data);
                return View(doctorUpdateDTO);
            }
            return View();
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit (DoctorUpdateDTO doctorUpdateDTO)
        {

            try
            {
                Doctors doctors = _mapper.Map<Doctors>(doctorUpdateDTO);
                doctors.UpdatedAt = DateTime.Now;
                doctors.IsActive = true;
                var result = await _doctorService.UpdateDoctorAsync(doctors);
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
