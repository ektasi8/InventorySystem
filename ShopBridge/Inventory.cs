using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace ShopBridge
{
    public partial class Inventory : DbContext
    {
        public Inventory()
            : base("name=Inventory")
        {
        }

        public virtual DbSet<ShopBridge> ShopBridges { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
