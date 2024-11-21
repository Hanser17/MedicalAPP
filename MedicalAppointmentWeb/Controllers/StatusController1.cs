using AutoMapper;
using MedicalAppoiments.Domain.Entities.system;
using MedicalAppoiments.Persistance.Models.SystemModel.Notifications;
using MedicalAppoiments.Persistance.Models.SystemModel.Status;
using MedicalAppointment.Application.Interfaces.IsystemService;
using MedicalAppointment.Application.Service.system;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MedicalAppointmentWeb.Controllers
{
    public class StatusController1 : Controller
    {
        private readonly IStatusService _statusService;
        private readonly IMapper _mapper;

        public StatusController1(IStatusService statusService, IMapper mapper)
        {
            _statusService = statusService;
            _mapper = mapper;
        }

        public async Task<ActionResult> Index()
        {
            var result = await _statusService.GetAllStatus();

            if (result.success)
            {
                List<Status> status = (List<Status>)result.Data;
                return View(status);
            }
            return View();
        }


        public async Task<ActionResult> Details(int id)
        {
            var result = await _statusService.GetStatusByID(id);
            if (result.success)
            {
                Status status = (Status)result.Data;
                return View(status);
            }
            return View();
        }


        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(StatusSaveDTO statusSaveDTO)
        {
            try
            {

                Status status = _mapper.Map<Status>(statusSaveDTO);
                var result = await _statusService.SaveStatusAsync(status);

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


        public async Task<ActionResult> Edit(int id)
        {
            var result = await _statusService.GetStatusByID(id);
            if (result.success)
            {
                StatusUpdateDTO statusUpdateDTO = _mapper.Map<StatusUpdateDTO>(result.Data);
                return View(statusUpdateDTO);
            }
            return View();
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(StatusUpdateDTO statusUpdateDTO)
        {
            try
            {
                Status status = _mapper.Map<Status>(statusUpdateDTO);
                var result = await _statusService.UpdateStatusAsync(status);
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

       