using MedicalAppoiments.Persistance.Models.appointments;
using MedicalAppointmentWeb.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace MedicalAppointmentWeb.Controllers
{
    public class AppointmentADMController1 : Controller
    {

        public async Task<IActionResult> Index()
        {
            string url = "http://localhost:5273/api/";

            List<AppointmentsModel> appointmentGetResultModel = new List<AppointmentsModel>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(url);

                var responseTask = await client.GetAsync("Appointments/GetAllAppointments");

                if (responseTask.IsSuccessStatusCode)
                {
                    string response = await responseTask.Content.ReadAsStringAsync();

                  
                    appointmentGetResultModel = JsonConvert.DeserializeObject<List<AppointmentsModel>>(response);
                }
                else
                {
                    ViewBag.Message = "";
                }
            }

            return View(appointmentGetResultModel);
        }

        public async Task<IActionResult> Details(int id)
        {
            string url = "http://localhost:5273/api/";

            AppointmentsModel appointmentGetResultModel = new AppointmentsModel();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(url);

                var responseTask = await client.GetAsync($"Appointments/GetByAppointmentsID?id={id}");

                if (responseTask.IsSuccessStatusCode)
                {
                    string response = await responseTask.Content.ReadAsStringAsync();


                    appointmentGetResultModel = JsonConvert.DeserializeObject<AppointmentsModel>(response);
                }
                else
                {
                    ViewBag.Message = "";
                }
            }

            return View(appointmentGetResultModel);
        }

        // GET: AppointmentADMController1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AppointmentADMController1/Create
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

        // GET: AppointmentADMController1/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AppointmentADMController1/Edit/5
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
