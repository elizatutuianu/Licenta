using Licenta.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Licenta.Data
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {

        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Dorm> Dorms { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<AccomodationRequest> AccomodationRequests { get; set; }
    }
}
