using MedicalAppoiments.Domain.Entities.appointments;
using MedicalAppoiments.Domain.Entities.medical;
using MedicalAppoiments.Persistance.Models.appointments;
using MedicalAppoiments.Persistance.Models.appointmentsModel;
using MedicalAppoiments.Persistance.Models.DoctorAvailivilityModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Json;

namespace MedicalAppointmentWeb.Controllers
{
    public class DoctorAvailibilityADMController1 : Controller
    {

        public async Task<IActionResult> Index()
        {
            string url = "http://localhost:5273/api/";

            List<DoctorAvailability> doctorAvailability = new List<DoctorAvailability>();

            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(url);

                    var responseTask = await client.GetAsync("DoctorAvailability/DoctorAvailability");

                    if (responseTask.IsSuccessStatusCode)
                    {
                        string response = await responseTask.Content.ReadAsStringAsync();
                        try
                        {
                            doctorAvailability = JsonConvert.DeserializeObject<List<DoctorAvailability>>(response);
                        }
                        catch (JsonException ex)
                        {

                            ViewBag.Message = "Error al procesar los datos: " + ex.Message;
                        }

                        
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
            
            catch (Exception ex)
            {

                ViewBag.Message = "Ocurrió un error inesperado: " + ex.Message;
            }

            return View(doctorAvailability);
        }

        public async Task<IActionResult> Details(int id)
        {
            string url = "http://localhost:5273/api/";

            DoctorAvailability DoctorAvailability = new DoctorAvailability();

            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(url);

                    var responseTask = await client.GetAsync($"DoctorAvailability/GetByDoctorID?id={id}");

                    if (responseTask.IsSuccessStatusCode)
                    {
                        string response = await responseTask.Content.ReadAsStringAsync();

                        DoctorAvailability = JsonConvert.DeserializeObject<DoctorAvailability>(response);
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

            return View(DoctorAvailability);
        }

        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DoctorAvailibilitySaveDTO DoctorAvailibilitySaveDTO)
        {
            string url = "http://localhost:5273/api/";

            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(url);
                   
                    var responseTask = await client.PostAsJsonAsync<DoctorAvailibilitySaveDTO>("DoctorAvailability/SaveDoctor", DoctorAvailibilitySaveDTO);


                    if (responseTask.IsSuccessStatusCode)
                    {

                        string response = await responseTask.Content.ReadAsStringAsync();

                        DoctorAvailability DoctorAvailability = JsonConvert.DeserializeObject<DoctorAvailability>(response);


                    }
                    else
                    {

                        ViewBag.Message = "Error al guardar la cita. Intenta de nuevo.";
                        return View(DoctorAvailibilitySaveDTO);
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


            return View(DoctorAvailibilitySaveDTO);
        }

        public async Task<IActionResult> Edit(int id)
        {
            string url = "http://localhost:5273/api/";

            DoctorAvailibilityUpdateDTO DoctorAvailibilityUpdateDTO = new DoctorAvailibilityUpdateDTO();

            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(url);

                    var responseTask = await client.GetAsync($"DoctorAvailability/GetByDoctorID?id={id}");

                    if (responseTask.IsSuccessStatusCode)
                    {
                        string response = await responseTask.Content.ReadAsStringAsync();
                        
                        DoctorAvailibilityUpdateDTO = JsonConvert.DeserializeObject<DoctorAvailibilityUpdateDTO>(response);
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

            return View(DoctorAvailibilityUpdateDTO);

        }




        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(DoctorAvailibilityUpdateDTO DoctorAvailibilityUpdateDTO)
        {
            string url = "http://localhost:5273/api/";

            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(url);
                    

                    var responseTask = await client.PutAsJsonAsync<DoctorAvailibilityUpdateDTO>("DoctorAvailability/UpdateDoctor", DoctorAvailibilityUpdateDTO);


                    if (responseTask.IsSuccessStatusCode)
                    {

                        string response = await responseTask.Content.ReadAsStringAsync();

                        DoctorAvailability DoctorAvailability = JsonConvert.DeserializeObject<DoctorAvailability>(response);


                    }
                    else
                    {

                        ViewBag.Message = "Error al guardar la cita. Intenta de nuevo.";
                        return View(DoctorAvailibilityUpdateDTO);
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


            return View(DoctorAvailibilityUpdateDTO);
        }

    }
}
