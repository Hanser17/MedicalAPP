using AutoMapper;
using MedicalAppoiments.Persistance.Models.usersModel;
using MedicalAppointment.Application.Interfaces.Iusersservice;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MedicalAppointmentWeb.Controllers
{
    public class UsersController1 : Controller
    {
        private readonly IUsersService _usersService;
        private readonly IMapper _mapper;
        public UsersController1 (IUsersService usersService, IMapper mapper)
        {
            _usersService = usersService;
            _mapper = mapper;
        }
       
        public async Task<IActionResult> Index()
        {
            var result = await _usersService.GetAllUsers();
            if(result.success)
            {
                List<UserModel> users = (List<UserModel>)result.Data;
                return View(users);
            }
            return View();
        }

        public async Task<IActionResult> Details(int id)
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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
