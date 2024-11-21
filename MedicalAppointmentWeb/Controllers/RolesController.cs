using AutoMapper;
using MedicalAppoiments.Domain.Entities.system;
using MedicalAppoiments.Domain.Entities.users;
using MedicalAppoiments.Persistance.Models;
using MedicalAppoiments.Persistance.Models.SystemModel.Roles;
using MedicalAppoiments.Persistance.Models.usersModel;
using MedicalAppointment.Application.Interfaces.IsystemService;
using MedicalAppointment.Application.Interfaces.Iusersservice;
using MedicalAppointment.Application.Service.users.service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MedicalAppointmentWeb.Controllers
{
    public class RolesController : Controller
    {

        public readonly IRolesService _rolesService;
        public readonly IMapper _mapper;

        public RolesController(IRolesService rolesService, IMapper mapper)
        {
            _rolesService = rolesService;
            _mapper = mapper;
        }


        public async Task<ActionResult> Index()
        {
            var result = await _rolesService.GetAllRoles();
            if (result.success)
            {
                List<RolesMode> rolesModes = (List<RolesMode>)result.Data;
                return View(rolesModes);
            }


            return View();
        }


        public async Task<ActionResult> Details(int id)
        {
            var result = await _rolesService.GetRolesByID(id);
            if (result.success)
            {
                RolesMode rolesMode = (RolesMode)result.Data;
                return View(rolesMode);
            }
            return View();
        }


        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(RolesSaveDto rolesSaveDto)
        {
            try
            {
                Roles roles = _mapper.Map<Roles>(rolesSaveDto);
                roles.IsActive = true;
                roles.CreatedAt = DateTime.Now;
                var result = await _rolesService.SaveRolesAsync(roles);
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
            var result = await _rolesService.GetRolesByID(id);
            RolesUpdateDTO rolesUpdateDTO = _mapper.Map<RolesUpdateDTO>(result.Data);
            return View(rolesUpdateDTO);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(RolesUpdateDTO rolesUpdateDTO)
        {
            try
            {
                Roles roles = _mapper.Map<Roles>(rolesUpdateDTO);
                roles.UpdatedAt = DateTime.Now;
                roles.IsActive = true;
                var result = await _rolesService.UpdateRolesAsync(roles);
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
    


      