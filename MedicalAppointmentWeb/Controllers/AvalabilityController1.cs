using AutoMapper;
using MedicalAppoiments.Domain.Entities.medical;
using MedicalAppoiments.Domain.Entities.system;
using MedicalAppoiments.Persistance.Models;
using MedicalAppoiments.Persistance.Models.MedicalModel.Availability;
using MedicalAppoiments.Persistance.Models.SystemModel.Roles;
using MedicalAppointment.Application.Interfaces.ImedicalService;
using MedicalAppointment.Application.Interfaces.IsystemService;
using MedicalAppointment.Application.Service.system.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MedicalAppointmentWeb.Controllers
{
    public class AvalabilityController1 : Controller
    {
        public readonly IAvailabilityModesService _availabilityModesService;
        public readonly IMapper _mapper;


        public AvalabilityController1(IAvailabilityModesService availabilityModesService, IMapper mapper)
        {
            _availabilityModesService = availabilityModesService;
            _mapper = mapper;
        }


        public  async Task<ActionResult> Index()
        {
            var result = await _availabilityModesService.GetAllAvailabilityModesAsync();
            if (result.success)
            {
                List<AvailabilityModes> availabilityModes = (List<AvailabilityModes>)result.Data;
                return View(availabilityModes);
            }

            return View();
        }

        public async Task<ActionResult> Details(int id)
        {
            var result = await _availabilityModesService.GetByIDAvailabilityModesAsync(id);
            if (result.success)
            {
                AvailabilityModes availabilityModes = (AvailabilityModes)result.Data;
                return View(availabilityModes);
            }
            return View();

        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(AvailabilitySaveDTO availabilitySaveDTO)
        {
            try
            {
                AvailabilityModes availabilityModes = _mapper.Map<AvailabilityModes>(availabilitySaveDTO);
                availabilityModes.IsActive = true;
                availabilityModes.CreatedAt = DateTime.Now;
                var result = await _availabilityModesService.SaveAvailabilityModesAsync(availabilityModes);
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
            var result = await _availabilityModesService.GetByIDAvailabilityModesAsync(id);
            AvailabilityUdapteDTO availabilityUdapteDTO = _mapper.Map<AvailabilityUdapteDTO>(result.Data);
            return View(availabilityUdapteDTO);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(AvailabilityUdapteDTO availabilityUdapteDTO )
        {
            try
            {
                AvailabilityModes availabilityModes = _mapper.Map<AvailabilityModes>(availabilityUdapteDTO);
                availabilityModes.UpdatedAt = DateTime.Now;
                availabilityModes.IsActive = true;
                var result = await _availabilityModesService.UpdateAvailabilityModesAsync(availabilityModes);
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
