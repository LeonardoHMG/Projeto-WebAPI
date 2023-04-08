using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Usuario.Model;

namespace Usuario.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }


        public DbSet<User> Users {get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder){
            var user = modelBuilder.Entity<User>();
            user.ToTable("tb_usuario");
            user.HasKey(x => x.Id);
            user.Property(x => x.Id).HasColumnName("id").ValueGeneratedOnAdd();
            user.Property(x => x.Name).HasColumnName("nome").IsRequired();
            user.Property(x => x.birthDate).HasColumnName("data_nascimento");
        }
    }
}