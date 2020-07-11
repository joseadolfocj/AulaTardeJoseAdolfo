using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CEP.DAL;
using CEP.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CEP.Controllers
{
    [Route("api/Endereco")]
    [ApiController]
    public class CepAPIController : ControllerBase
    {
        private readonly CepDAO _cepDAO;
        public CepAPIController(CepDAO cepDAO)
        {
            _cepDAO = cepDAO;
        }

        [HttpGet]
        [Route("ListarEnderecos")]
        public List<CepObject> ListarEnderecos()
        {
            return _cepDAO.Listar();
        }

        [HttpGet]
        [Route("ListarEndereco/{cep}")]
        public string ListarEndereco(String cep)
        {
            return _cepDAO.ListarEndereco(cep);
        }

        [HttpPost]
        [Route("CadastrarEndereco")]
        public void CadastrarEndereco(CepObject cepObject)
        {
            _cepDAO.Cadastrar(cepObject);
        }

        [HttpDelete]
        [Route("DeletarEndereco/{id}")]
        public void DeletarEndereco(int id)
        {
            _cepDAO.Excluir(id);
        }

        [HttpPut]
        [Route("AlterarEndereco")]
        public void AlterarEndereco(CepObject cepObject)
        {
            _cepDAO.AlterarEndereco(cepObject);

        }
    }
}
