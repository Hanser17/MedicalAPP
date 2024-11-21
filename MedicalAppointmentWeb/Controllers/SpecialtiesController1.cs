using AutoMapper;
using MedicalAppoiments.Domain.Entities.medical;
using MedicalAppoiments.Persistance.Interfaces.Imedical;
using MedicalAppoiments.Persistance.Models.MedicalModel.Availability;
using MedicalAppoiments.Persistance.Models.MedicalModel.Specialties;
using MedicalAppointment.Application.Interfaces.ImedicalService;
using MedicalAppointment.Application.Service.medical.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MedicalAppointmentWeb.Controllers
{
    public class SpecialtiesController1 : Controller
    {

        public readonly ISpecialtiesService _specialtiesService;
        public readonly IMapper _mapper;

        public SpecialtiesController1(ISpecialtiesService specialtiesService, IMapper mapper)
        {
            _specialtiesService = specialtiesService;
            _mapper = mapper;
        }


        public async Task<ActionResult> Index()
        {
            var result = await _specialtiesService.GetAllSpecialtiesAsync();
            if (result.success)
            {
                List<SpecialtiesModelDTO> specialtiesModelDTO = (List<SpecialtiesModelDTO>)result.Data;
                return View(specialtiesModelDTO);
            }

            return View();
        }

        public async Task<ActionResult> Details(int id)
        {
            var result = await _specialtiesService.GetByIDSpecialtiesAsync(id);
            if (result.success)
            {
                SpecialtiesModelDTO specialtiesModelDTO = (SpecialtiesModelDTO)result.Data;
                return View(specialtiesModelDTO);
            }
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(SpecialtiesSaveDTO specialtiesSaveDTO)
        {
            try
            {
                Specialties specialties = _mapper.Map<Specialties>(specialtiesSaveDTO);
                specialties.IsActive = true;
                specialties.CreatedAt = DateTime.Now;
                var result = await _specialtiesService.SaveSpecialtiesAsync(specialties);
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
            var result = await _specialtiesService.GetByIDSpecialtiesAsync(id);
            SpecialtiesUdapteDTO specialtiesUdapteDTO = _mapper.Map<SpecialtiesUdapteDTO>(result.Data);
            return View(specialtiesUdapteDTO);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(SpecialtiesUdapteDTO specialtiesUdapteDTO)
        {
            try
            {
                Specialties specialties = _mapper.Map<Specialties>(specialtiesUdapteDTO);
                specialties.UpdatedAt = DateTime.Now;
                specialties.IsActive = true;
                var result = await _specialtiesService.UpdateSpecialtiesAsync(specialties);
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
