using MedicalAppoiments.Domain.Entities.appointments;
using MedicalAppoiments.Persistance.Models.appointments;
using MedicalAppointment.Application.Interfaces.IappointmentsService;
using MedicalAppointment.Application.Service.appointments.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MedicalAppointmentWeb.Controllers
{
    public class AppointmentController1 : Controller
    {
        private readonly IAppointmentsService _appointmentsService;
        public AppointmentController1 ( IAppointmentsService appointmentsService)
        {
            _appointmentsService = appointmentsService;
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
        public async Task<IActionResult> Create(Appointments appointments)
        {
            try
            {
                appointments.CreatedAt = DateTime.Now;
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
                AppointmentsModel appointmentsModel = (AppointmentsModel)result.Data;
                return View(appointmentsModel);
            }
            return View();
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Appointments appointments)
        {
            try
            {
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
