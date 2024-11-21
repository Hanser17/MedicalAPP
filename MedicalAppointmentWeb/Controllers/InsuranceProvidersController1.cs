using AutoMapper;
using MedicalAppoiments.Domain.Entities.insurance;
using MedicalAppoiments.Domain.Entities.users;
using MedicalAppoiments.Persistance.Models.insuranseModel;
using MedicalAppoiments.Persistance.Models.usersModel;
using MedicalAppointment.Application.Interfaces.IinsuranceService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MedicalAppointmentWeb.Controllers
{
    public class InsuranceProvidersController1 : Controller
    {
        private readonly IInsuranceProvidersService _insuranceProvidersService ;
        private readonly IMapper _mapper;

            public InsuranceProvidersController1 ( IInsuranceProvidersService InsuranceProvidersController, IMapper mapper)
        {
            _insuranceProvidersService = InsuranceProvidersController;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        { 
            var result = await _insuranceProvidersService.GetAllInsuranceProvidersAsync();
            if (result.success)
            {
                List<InsuranceProvidersModel> insuranceProvidersModels = (List<InsuranceProvidersModel>)result.Data;
                return View(insuranceProvidersModels);
            }
            else
            {
                return View();
            }
           
        }

        public async Task<IActionResult> Details(int id)
        {
            
                var result = await _insuranceProvidersService.GetByIDInsuranceProvidersAsync(id);
                if (result.success)
                {
                InsuranceProvidersModel InsuranceProvidersModel = (InsuranceProvidersModel)result.Data;
                    return View(InsuranceProvidersModel);
                }
                return View();
            
        }

      
        public ActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(InsuranceProvidersSaveDTO InsuranceProvidersSaveDTO)
        {
            try
            {
                InsuranceProviders insuranceProviders = _mapper.Map<InsuranceProviders>(InsuranceProvidersSaveDTO);
                insuranceProviders.IsActive = true;
                insuranceProviders.CreatedAt = DateTime.Now;
                var result = await _insuranceProvidersService.SaveInsuranceProvidersAsync(insuranceProviders);
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
            var result = await _insuranceProvidersService.GetByIDInsuranceProvidersAsync(id);
            if (result.success)
            {
                InsuranceProvidersUpdateDTO insuranceProvidersUpdateDTO = _mapper.Map<InsuranceProvidersUpdateDTO>(result.Data);
                return View(insuranceProvidersUpdateDTO);
            }
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(InsuranceProvidersUpdateDTO insuranceProvidersUpdateDTO)
        {

            try
            {
                InsuranceProviders insuranceProviders = _mapper.Map<InsuranceProviders>(insuranceProvidersUpdateDTO);
                insuranceProviders.UpdatedAt = DateTime.Now;
                insuranceProviders.IsActive = true;
                insuranceProviders.Name = insuranceProvidersUpdateDTO.InsuranceProviderName;
                var result = await _insuranceProvidersService.UpdateInsuranceProvidersAsync(insuranceProviders);
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
