#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Api_Rest.Models;

namespace Api_Rest.Data
{
    public class Api_RestContext : DbContext
    {
        public Api_RestContext (DbContextOptions<Api_RestContext> options)
            : base(options)
        {
        }

        public DbSet<Api_Rest.Models.Tb_PersonasFisicas> Tb_PersonasFisicas { get; set; }
    }
}
