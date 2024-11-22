using AutoMapper;
using MedicalAppoiments.Domain.Entities.medical;
using MedicalAppoiments.Persistance.Models.MedicalModel.Availability;
using MedicalAppointment.Application.Interfaces.ImedicalService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MedicalAppointmentWeb.Controllers
{
    public class AvailabilityModesController1 : Controller
    {
        public readonly IAvailabilityModesService _availabilityModesService;
        public readonly IMapper _mapper;


        public AvailabilityModesController1(IAvailabilityModesService availabilityModesService, IMapper mapper)
        {
            _availabilityModesService = availabilityModesService;
            _mapper = mapper;
        }


        public async Task<IActionResult> Index()
        {
            var result = await _availabilityModesService.GetAllAvailabilityModesAsync();
            if (result.success)
            {
                List<AvailabilityModes> AvailabilityModes = (List<AvailabilityModes>)result.Data;
                return View(AvailabilityModes);
            }

            return View();
        }

        public async Task<IActionResult> Details(int id)
        {
            var result = await _availabilityModesService.GetByIDAvailabilityModesAsync(id);
            if (result.success)
            {
                AvailabilityModes AvailabilityModes = (AvailabilityModes)result.Data;
                return View(AvailabilityModes);
            }
            return View();

        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AvailabilitySaveDTO availabilitySaveDTO)
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

        public async Task<IActionResult> Edit(int id)
        {
            var result = await _availabilityModesService.GetByIDAvailabilityModesAsync(id);
            AvailabilityUdapteDTO availabilityUdapteDTO = _mapper.Map<AvailabilityUdapteDTO>(result.Data);
            return View(availabilityUdapteDTO);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(AvailabilityUdapteDTO availabilityUdapteDTO)
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