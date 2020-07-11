using CEP.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CEP.DAL
{
    public class CepDAO
    {
        private readonly Context _context;
        public CepDAO(Context context)
        {
            _context = context;
        }

        public void Cadastrar(CepObject cepObject)
        {
            _context.Add(cepObject);
            _context.SaveChanges();
        }

        public List<CepObject> Listar()
        {
            var savedCeps = _context.CepObject.ToList();
            return savedCeps;
        }

        public void Excluir(int id)
        {
            CepObject itemCep = _context.CepObject.Find(id);
            _context.Remove(itemCep);
            _context.SaveChanges();
        }


        public string ListarEndereco(String cep)
        {
            cep = cep.Replace("-", "");
            cep = cep.Insert(5, "-");

            var itemCep = JsonConvert.SerializeObject(_context.CepObject.Where(x => x.Cep == cep));
            
            return itemCep;
        }

        public void AlterarEndereco(CepObject cepObject)
        {
            _context.Update(cepObject);
            _context.SaveChanges();
        }


    }
}
