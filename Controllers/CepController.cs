using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using CEP.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
//José Adolfo Costa Junior - 1719375
namespace CEP.Controllers
{
    public class CepController : Controller
    {
        private readonly Context _context;
        public CepController(Context context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var savedCeps = _context.CepObject.ToList();
            return View(savedCeps);
        }

        [HttpPost]
        public IActionResult PesquisaCep(string cep)
        {

            var url = $@"https://viacep.com.br/ws/{cep}/json/";

            WebClient client = new WebClient();

            TempData["resultado"] = client.DownloadString(url);

            if (TempData["resultado"] != null)
            {
                string result = TempData["resultado"].ToString();
                TempData["Result"] = null;

                CepObject cepObject = JsonConvert.DeserializeObject<CepObject>(result);

                return RedirectToAction("Salvar", new { cepObject.Cep, cepObject.Bairro, cepObject.Complemento, cepObject.Localidade, cepObject.Logradouro, cepObject.UF });
            }

            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Salvar(CepObject cepObject)
        {
            _context.Add(cepObject);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
