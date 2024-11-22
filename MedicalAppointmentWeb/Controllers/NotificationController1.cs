using AutoMapper;
using MedicalAppoiments.Domain.Entities.appointments;
using MedicalAppoiments.Domain.Entities.system;
using MedicalAppoiments.Persistance.Models.DoctorAvailivilityModel;
using MedicalAppoiments.Persistance.Models.SystemModel.Notifications;
using MedicalAppointment.Application.Interfaces.IappointmentsService;
using MedicalAppointment.Application.Interfaces.IsystemService;
using MedicalAppointment.Application.Service.appointments.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MedicalAppointmentWeb.Controllers
{
    public class NotificationController1 : Controller
    {
        private readonly INotificationsService _notificationsService;
        private readonly IMapper _mapper;


        public NotificationController1(INotificationsService notificationsService, IMapper mapper)
        {
            _notificationsService = notificationsService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _notificationsService.GetAllNotificationsAsync();

            if (result.success)
            {
                List<Notifications> Notifications = (List<Notifications>)result.Data;
                return View(Notifications);
            }
            return View();
        }


        public async Task<IActionResult> Details(int id)
        {
            var result = await _notificationsService.GetNotificationByIdAsync(id);
            if (result.success)
            {
                Notifications Notifications = (Notifications)result.Data;
                return View(Notifications);
            }
            return View();
        }


        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(NotificationSaveDTO notificationSaveDTO)
        {
            try
            {

                Notifications notifications = _mapper.Map<Notifications>(notificationSaveDTO);
                notifications.SentAt = DateTime.Now;
                var result = await _notificationsService.SaveNotificationAsync(notifications);

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
            var result = await _notificationsService.GetNotificationByIdAsync(id);
            if (result.success)
            {
                NotificationUpdateDTO notificationUpdateDTO = _mapper.Map<NotificationUpdateDTO>(result.Data);
                return View(notificationUpdateDTO);
            }
            return View();
        }




        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(NotificationUpdateDTO notificationUpdateDTO)
        {
            try
            {
                Notifications notifications = _mapper.Map<Notifications>(notificationUpdateDTO);
                notifications.SentAt= DateTime.Now;
                var result = await _notificationsService.UpdateNotificationAsync(notifications);
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