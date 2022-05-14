using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using chatServer.Models;

namespace chatServer.Data
{
    public class chatServerContext : DbContext
    {
        public chatServerContext (DbContextOptions<chatServerContext> options)
            : base(options)
        {
        }

        public DbSet<chatServer.Models.Rating>? Rating { get; set; }
    }
}
