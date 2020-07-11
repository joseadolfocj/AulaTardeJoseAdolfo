
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace CEP.Models
{
    public class Context : DbContext
    {

        public DbSet<CepObject> CepObject { get; set; }
        public Context(DbContextOptions<Context> options) : base(options)
        {

        }

    }
}