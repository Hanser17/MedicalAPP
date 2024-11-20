
using AutoMapper;
using MedicalAppoiments.Domain.Entities.users;
using MedicalAppoiments.Persistance.Models.usersModel;
using MedicalAppointment.Application.Interfaces.Iusersservice;
using MedicalAppointment.Application.Service.users.service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace MedicalAppointmentWeb.Controllers
{
    public class PatientController1 : Controller

    {
        public readonly IPatientService _patientService;
        public readonly IMapper _mapper;

        public PatientController1 (IPatientService patientService, IMapper mapper)
        {
            _patientService = patientService;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            var result = await _patientService.GetAllPatients();
            if (result.success)
            {
                List<PatientsModel> patientsModels = (List<PatientsModel>)result.Data;
                return View(patientsModels);
            }
           
            
            return View();
        }

        public async  Task<IActionResult> Details(int id)
        {
            var result = await _patientService.GetPatientById(id);
            if (result.success)
            {
                PatientsModel patientsModel = (PatientsModel)result.Data;
                return View(patientsModel);
            }
            return View();
        }

     
        public ActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PatientSaveDTO patientSaveDTO)
        {
            try
            {
                Patients patients = _mapper.Map<Patients>(patientSaveDTO);
                patients.IsActive = true;
                patients.CreatedAt = DateTime.Now;
                var result = await _patientService.SavePatientAsync(patients);
                if(result.success)
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
            var result = await _patientService.GetPatientById(id);
            PatientUpdateDTO patientUpdateDTO = _mapper.Map<PatientUpdateDTO>(result.Data);
            return View(patientUpdateDTO);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(PatientUpdateDTO patientUpdateDTO)
        {
            try
            {
                Patients patients = _mapper.Map<Patients>(patientUpdateDTO);
                patients.UpdatedAt = DateTime.Now;
                patients.IsActive = true;
                var result = await _patientService.UpdatePatientAsync(patients);
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
