using AutoMapper;
using MedicalAppoiments.Domain.Entities.appointments;
using MedicalAppoiments.Domain.Entities.system;
using MedicalAppoiments.Persistance.Models.appointments;
using MedicalAppoiments.Persistance.Models.appointmentsModel;
using MedicalAppointmentWeb.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http.Json;

namespace MedicalAppointmentWeb.Controllers
{
    public class AppointmentADMController1 : Controller
    {
        private readonly IMapper _mapper;
        public AppointmentADMController1(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            string url = "http://localhost:5273/api/";

            List<AppointmentsModel> appointmentGetResultModel = new List<AppointmentsModel>();

            try
            {
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
                        ViewBag.Message = "Error al obtener datos desde la API.";
                    }
                }
            }
            catch (HttpRequestException ex)
            {

                ViewBag.Message = "Hubo un problema con la solicitud HTTP: " + ex.Message;
            }
            catch (JsonException ex)
            {

                ViewBag.Message = "Error al procesar los datos: " + ex.Message;
            }
            catch (Exception ex)
            {

                ViewBag.Message = "Ocurrió un error inesperado: " + ex.Message;
            }

            return View(appointmentGetResultModel);
        }

        public async Task<IActionResult> Details(int id)
        {
            string url = "http://localhost:5273/api/";

            AppointmentsModel appointmentsModel = new AppointmentsModel();

            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(url);

                    var responseTask = await client.GetAsync($"Appointments/GetByAppointmentsID?id={id}");

                    if (responseTask.IsSuccessStatusCode)
                    {
                        string response = await responseTask.Content.ReadAsStringAsync();

                        appointmentsModel = JsonConvert.DeserializeObject<AppointmentsModel>(response);
                    }
                    else
                    {
                        ViewBag.Message = "No se pudo encontrar la cita solicitada.";
                    }
                }
            }
            catch (HttpRequestException ex)
            {

                ViewBag.Message = "Hubo un problema con la solicitud HTTP: " + ex.Message;
            }
            catch (JsonException ex)
            {

                ViewBag.Message = "Error al procesar los datos: " + ex.Message;
            }
            catch (Exception ex)
            {

                ViewBag.Message = "Ocurrió un error inesperado: " + ex.Message;
            }

            return View(appointmentsModel);
        }



        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AppointmentSaveDTO appointmentSaveDTO)
        {
            string url = "http://localhost:5273/api/";

            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(url);
                    appointmentSaveDTO.CreatedAt = DateTime.Now;
                    appointmentSaveDTO.StatusID = 1;
                    var responseTask = await client.PostAsJsonAsync<AppointmentSaveDTO>("Appointments/SaveAppointments", appointmentSaveDTO);


                    if (responseTask.IsSuccessStatusCode)
                    {

                        string response = await responseTask.Content.ReadAsStringAsync();

                        Appointments appointments = JsonConvert.DeserializeObject<Appointments>(response);


                    }
                    else
                    {

                        ViewBag.Message = "Error al guardar la cita. Intenta de nuevo.";
                        return View(appointmentSaveDTO);
                    }
                }


                return RedirectToAction(nameof(Index));
            }
            catch (HttpRequestException ex)
            {

            }
            catch (JsonException ex)
            {

                ViewBag.Message = "Hubo un problema al procesar los datos: " + ex.Message;
            }
            catch (Exception ex)
            {

                ViewBag.Message = "Ocurrió un error inesperado: " + ex.Message;
            }


            return View(appointmentSaveDTO);
        }


        public async Task<IActionResult> Edit(int id)
        {
            string url = "http://localhost:5273/api/";

            AppointmentUpdateDTO appointmentUpdateDTO = new AppointmentUpdateDTO();

            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(url);

                    var responseTask = await client.GetAsync($"Appointments/GetByAppointmentsID?id={id}");

                    if (responseTask.IsSuccessStatusCode)
                    {
                        string response = await responseTask.Content.ReadAsStringAsync();
                        appointmentUpdateDTO.UpdatedAt = DateTime.Now;
                        appointmentUpdateDTO = JsonConvert.DeserializeObject<AppointmentUpdateDTO>(response);
                    }
                    else
                    {
                        ViewBag.Message = "No se pudo encontrar la cita solicitada.";
                    }
                }
            }
            catch (HttpRequestException ex)
            {

                ViewBag.Message = "Hubo un problema con la solicitud HTTP: " + ex.Message;
            }
            catch (JsonException ex)
            {

                ViewBag.Message = "Error al procesar los datos: " + ex.Message;
            }
            catch (Exception ex)
            {

                ViewBag.Message = "Ocurrió un error inesperado: " + ex.Message;
            }

            return View(appointmentUpdateDTO);

        } 



        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public  async Task<IActionResult> Edit(AppointmentUpdateDTO appointmentUpdateDTO)
        {
            string url = "http://localhost:5273/api/";

            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(url);
                    appointmentUpdateDTO.UpdatedAt = DateTime.Now;
                    
                    var responseTask = await client.PutAsJsonAsync<AppointmentUpdateDTO>("Appointments/UpdateAppointments", appointmentUpdateDTO);


                    if (responseTask.IsSuccessStatusCode)
                    {

                        string response = await responseTask.Content.ReadAsStringAsync();

                        Appointments appointments = JsonConvert.DeserializeObject<Appointments>(response);


                    }
                    else
                    {

                        ViewBag.Message = "Error al guardar la cita. Intenta de nuevo.";
                        return View(appointmentUpdateDTO);
                    }
                }


                return RedirectToAction(nameof(Index));
            }
            catch (HttpRequestException ex)
            {

            }
            catch (JsonException ex)
            {

                ViewBag.Message = "Hubo un problema al procesar los datos: " + ex.Message;
            }
            catch (Exception ex)
            {

                ViewBag.Message = "Ocurrió un error inesperado: " + ex.Message;
            }


            return View(appointmentUpdateDTO);
        }




    }
}
