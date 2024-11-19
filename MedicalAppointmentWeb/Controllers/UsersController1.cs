using AutoMapper;
using MedicalAppoiments.Domain.Entities.users;
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
            var result = await _usersService.GetUserById(id);
            if (result.success)
            {
                UserModel users = (UserModel) result.Data;
                return View(users);
            }
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UserSaveDTO userSaveDTO)
        {
            try
            {
                Users users =  _mapper.Map<Users>(userSaveDTO);
                users.CreatedAt = DateTime.Now;
                users.IsActive = true;
                var result = await _usersService.SaveUser(users);
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
            var result = await _usersService.GetUserById(id);
            if (result.success)
            {
                UserUpdateDTO userUpdateDTO = _mapper.Map<UserUpdateDTO>(result.Data);
                return View(userUpdateDTO);
            }

            return View();
        }

    
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(UserUpdateDTO userUpdateDTO)
        {
            Users user =  _mapper.Map<Users>(userUpdateDTO);
            user.UpdatedAt = DateTime.Now;
            user.IsActive = true;
            try
            {
                var result = await _usersService.UpdateUser(user);
                if (result.success)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewBag.Message = result.message;
                    return View() ;
                }
                
            }
            catch
            {
                return View();
            }
        }

        
        
    }
}
