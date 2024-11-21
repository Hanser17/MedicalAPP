using AutoMapper;
using MedicalAppoiments.Domain.Entities.medical;
using MedicalAppoiments.Persistance.Models.MedicalModel.Availability;
using MedicalAppoiments.Persistance.Models.MedicalModel.MedicalRecorsd;
using MedicalAppointment.Application.Interfaces.ImedicalService;
using MedicalAppointment.Application.Service.medical.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MedicalAppointmentWeb.Controllers
{
    public class MedicalRecorsdController1 : Controller
    {

        public readonly IMedicalRecordsService _medicalRecordsService;
        public readonly IMapper _mapper;

        public MedicalRecorsdController1(IMedicalRecordsService medicalRecordsService, IMapper mapper)
        {
            _medicalRecordsService = medicalRecordsService;
            _mapper = mapper;
        }

        public async Task<ActionResult> Index()
        {
            var result = await _medicalRecordsService.GetAllMedicalRecordsAsync();
            if (result.success)
            {
                List<MedicalRecorsdModelDTO> medicalRecorsdModelDTOs = (List<MedicalRecorsdModelDTO>)result.Data;
                return View(medicalRecorsdModelDTOs);
            }

            return View();
        }

        public async Task<ActionResult> Details(int id)
        {
            var result = await _medicalRecordsService.GetByIDMedicalRecordsAsync(id);
            if (result.success)
            {
                MedicalRecorsdModelDTO medicalRecorsdModelDTOs = (MedicalRecorsdModelDTO)result.Data;
                return View(medicalRecorsdModelDTOs);
            }
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(MedicalRecorsdSaveDTO medicalRecorsdSaveDTO)
        {
            try
            {
                MedicalRecords medicalRecords = _mapper.Map<MedicalRecords>(medicalRecorsdSaveDTO);
                medicalRecords.CreatedAt = DateTime.Now;
                var result = await _medicalRecordsService.SaveMedicalRecordsAsync(medicalRecords);
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
            var result = await _medicalRecordsService.GetByIDMedicalRecordsAsync(id);
            AvailabilityUdapteDTO availabilityUdapteDTO = _mapper.Map<AvailabilityUdapteDTO>(result.Data);
            return View(availabilityUdapteDTO);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(MedicalRecorsdUdapteDTO medicalRecorsdUdapteDTO)
        {
            try
            {
                MedicalRecords medicalRecords = _mapper.Map<MedicalRecords>(medicalRecorsdUdapteDTO);
                medicalRecords.UpdatedAt = DateTime.Now;
                var result = await _medicalRecordsService.UpdateMedicalRecordsAsync(medicalRecords);
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
