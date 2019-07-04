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
        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<Specialization> Specializations { get; set; }
        public DbSet<IdCardStudent> IdCardStudents { get; set; }
        public DbSet<Roommate> Roommates { get; set; }
        public DbSet<DormsPreferred> DormsPreferreds { get; set; }
        public DbSet<RoomPreferred> RoomPreferreds { get; set; }

        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            foreach (var relationship in modelbuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            base.OnModelCreating(modelbuilder);
        }
    }
}
