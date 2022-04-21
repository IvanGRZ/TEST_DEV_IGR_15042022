using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Frontweb.Models;
using Newtonsoft.Json;
using System;
using System.Text;

namespace Frontweb.Controllers
{
    public class Tb_PersonasFisicasController : Controller
    {
        HttpClientHandler handler = new HttpClientHandler();

        Tb_PersonasFisicas personasFisica = new Tb_PersonasFisicas();
        List<Tb_PersonasFisicas> personasFisicas = new List<Tb_PersonasFisicas>();

        public Tb_PersonasFisicasController()
        {
            handler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) =>
            {
                return true;
            };
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<List<Tb_PersonasFisicas>> GetPersons()
        {
            personasFisicas = new List<Tb_PersonasFisicas>();

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:7263/api/Tb_PersonasFisicas"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    personasFisicas = JsonConvert.DeserializeObject<List<Tb_PersonasFisicas>>(apiResponse);

                }
            }

            return personasFisicas;
        }

        [HttpGet]
        public async Task<Tb_PersonasFisicas> GetByID(int IdPersonaFisica)
        {
            personasFisica = new Tb_PersonasFisicas();

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:7263/api/Tb_PersonasFisicas/" + IdPersonaFisica))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    personasFisica = JsonConvert.DeserializeObject<Tb_PersonasFisicas>(apiResponse);
                }
            }

            return personasFisica;
        }

        [HttpPost]
        public async Task<Tb_PersonasFisicas> insert(Tb_PersonasFisicas _personasFisica)
        {
            personasFisica = new Tb_PersonasFisicas();

            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(
                    JsonConvert.SerializeObject(_personasFisica), Encoding.UTF8, "application/json");

                using (var response = await httpClient.PostAsync("https://localhost:7263/api/Tb_PersonasFisicas", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    personasFisica = JsonConvert.DeserializeObject<Tb_PersonasFisicas>(apiResponse);
                }
            }

            return personasFisica;
        }

        [HttpPut]
        public async Task<Tb_PersonasFisicas> Update(int IdPersonaFisica, Tb_PersonasFisicas _personasFisica)
        {
            personasFisica = new Tb_PersonasFisicas();

            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(
                    JsonConvert.SerializeObject(_personasFisica), Encoding.UTF8, "application/json");

                using (var response = await httpClient.PutAsync("https://localhost:7263/api/Tb_PersonasFisicas/" + IdPersonaFisica, content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    personasFisica = JsonConvert.DeserializeObject<Tb_PersonasFisicas>(apiResponse);
                }
            }

            return personasFisica;
        }


        [HttpDelete]
        public async Task<string> Delete(int IdPersonaFisica)
        {
            string message = "";

            using (var httpClient = new HttpClient(handler))
            {
                using (var response = await httpClient.DeleteAsync("https://localhost:7263/api/Tb_PersonasFisicas/" + IdPersonaFisica))
                {
                    message = await response.Content.ReadAsStringAsync();
                }
            }

            return message;
        }

    }
}
