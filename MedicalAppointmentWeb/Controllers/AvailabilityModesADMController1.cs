using MedicalAppoiments.Domain.Entities.medical;
using MedicalAppoiments.Persistance.Models.appointments;
using MedicalAppoiments.Persistance.Models.MedicalModel.Availability;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace MedicalAppointmentWeb.Controllers
{
    public class AvailabilityModesADMController1 : Controller
    {
        public async Task<IActionResult> Index()
        {
            string url = "http://localhost:5273/api/";

            List<AvailabilityModes> AvailabilityModelDTO = new List<AvailabilityModes>();

            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(url);

                    var responseTask = await client.GetAsync("DoctorAvailability/DoctorAvailability");

                    if (responseTask.IsSuccessStatusCode)
                    {
                        string response = await responseTask.Content.ReadAsStringAsync();

                        AvailabilityModelDTO = JsonConvert.DeserializeObject<List<AvailabilityModes>>(response);
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

            return View(AvailabilityModelDTO);
        }

        // GET: AvailabilityModesADMController1/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AvailabilityModesADMController1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AvailabilityModesADMController1/Create
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

        // GET: AvailabilityModesADMController1/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AvailabilityModesADMController1/Edit/5
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

        // GET: AvailabilityModesADMController1/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AvailabilityModesADMController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
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
