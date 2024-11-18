using AutoMapper;
using MedicalAppoiments.Domain.Entities.appointments;
using MedicalAppoiments.Persistance.Models.appointments;
using MedicalAppoiments.Persistance.Models.appointmentsModel;
using MedicalAppointment.Application.Interfaces.IappointmentsService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MedicalAppointmentWeb.Controllers
{
    public class AppointmentController1 : Controller
    {
        private readonly IAppointmentsService _appointmentsService;
        private readonly IMapper _mapper;
        public AppointmentController1 ( IAppointmentsService appointmentsService, IMapper mapper)
        {
            _appointmentsService = appointmentsService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _appointmentsService.GetAllAppointmentsAsync();

            if (result.success)
            {
                List<AppointmentsModel> appointmentsModels = (List<AppointmentsModel>)result.Data;
                return View(appointmentsModels);
            }

            return View();
        }

       
        public async Task<IActionResult> Details(int id)
        {
            var result = await _appointmentsService.GetAppointmentsByIdAsync(id);
            if (result.success)
            {
                AppointmentsModel appointmentsModel = (AppointmentsModel)result.Data;
                return View(appointmentsModel);
            }
            return View();
        }

       
        public  ActionResult Create( )
        { 
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AppointmentSaveDTO appointmentSaveDTO)
        {
            try
            {

                Appointments appointments = _mapper.Map<Appointments>(appointmentSaveDTO);
                appointments.CreatedAt = DateTime.Now;
                appointments.StatusID = 1;
                var result = await _appointmentsService.SaveAppointmentsAsync(appointments);

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
            var result = await _appointmentsService.GetAppointmentsByIdAsync(id);
            if (result.success)
            {
                AppointmentUpdateDTO appointmentUpdateDTO = _mapper.Map<AppointmentUpdateDTO>(result.Data);
                return View(appointmentUpdateDTO);
            }
            return View();
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(AppointmentUpdateDTO appointmentUpdateDTO)
        {
            try
            {
                Appointments appointments = _mapper.Map<Appointments>(appointmentUpdateDTO);
                appointments.UpdatedAt = DateTime.Now;
                

                var result = await _appointmentsService.UpdateAppointmentsAsync(appointments);

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
