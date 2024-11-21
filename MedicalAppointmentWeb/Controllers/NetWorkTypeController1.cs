using AutoMapper;
using MedicalAppoiments.Domain.Entities.appointments;
using MedicalAppoiments.Domain.Entities.insurance;
using MedicalAppoiments.Persistance.Models.DoctorAvailivilityModel;
using MedicalAppoiments.Persistance.Models.NetWorkTypeModel;
using MedicalAppointment.Application.Interfaces.IinsuranceService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MedicalAppointmentWeb.Controllers
{
    public class NetWorkTypeController1 : Controller
    {
        private readonly INetworkTypeService _networkTypeService;
        private readonly IMapper _mapper;

        public NetWorkTypeController1 (INetworkTypeService networkTypeService, IMapper mapper)
        {
            _networkTypeService = networkTypeService;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        { 
            var rerult = await _networkTypeService.GetAllNetworkTypeAsync();
            if (rerult.success)
            {
                List<NetworkType> NetworkType = (List<NetworkType>)rerult.Data;
                return View(NetworkType);
            }

            return View();
        }

        
        public ActionResult Details(int id)
        {
            return View();
        }

        
        public ActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(NetWorkTypeSaveDTO netWorkTypeSaveDTO)
        {
            try
            {

                NetworkType networkType = _mapper.Map<NetworkType>(netWorkTypeSaveDTO);
                networkType.CreatedAt = DateTime.Now;
                networkType.IsActive = true;
                var result = await _networkTypeService.SaveNetworkTypeAsync(networkType);

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

        
        public ActionResult Edit(int id)
        {
            return View();
        }

  
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

       
    }
}
