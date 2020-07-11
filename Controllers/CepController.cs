using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using CEP.DAL;
using CEP.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
//José Adolfo Costa Junior - 1719375
namespace CEP.Controllers
{
    public class CepController : Controller
    {

        private readonly CepDAO _cepDAO;
        public CepController(CepDAO cepDAO)
        {
            _cepDAO = cepDAO;
        }
        public IActionResult Index()
        {
            
            return View(_cepDAO.Listar());
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
        public IActionResult Salvar(CepObject cepObject)
        {
            _cepDAO.Cadastrar(cepObject);

            return RedirectToAction("Index");
        }

    }
}
