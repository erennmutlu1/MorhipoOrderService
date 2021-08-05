using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MorhipoOrderService.Models.MorhipoModel;
using MorhipoOrderService.Models.MorhipoModels;

namespace MorhipoOrderService.DBContext
{
    class MorhipoDBContext : DbContext
    {
        public DbSet<MorhipoModel> Morhipo { get; set; }

        public DbSet<MorhipoInvoiceAddressModel> MorhipoInvoiceAddress { get; set; }
        public DbSet<MorhipoItemsModel> MorhipoItems { get; set; }
        public DbSet<MorhipoShipmentAddressModel> MorhipoShipmentAddress { get; set; }
        public DbSet<MorhipoOrderDetails> MorhipoOrderDetails { get; set; }


   

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            _ = optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=MorhipoOrderDatabase;Integrated Security=True");
        }




    }




}
