using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eCom.DataContext.Entity;
using eCom.DataContext.Entity.OrderSite;
using Microsoft.EntityFrameworkCore;

namespace eCom.DataContext.Context
{
    public class EComDbContext : DbContext
    {
        public EComDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> User { get; set; }
        public DbSet<UserProfile> UserProfile { get; set; }
        public DbSet<UserRole> GroupRole { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<ProductHistory> ProductHistory { get; set; }
        public DbSet<ProductProperties> ProductProperties { get; set; }
        public DbSet<Supplier> Supplier { get; set; }
        public DbSet<SupplierProduct> SupplierProduct { get; set; }
        public DbSet<PurchaseOrder> PurchaseOrder { get; set; }
        public DbSet<PurchaseOrderDetail> PurchaseOrderDetail { get; set; }
        public DbSet<SalesOrder> SalesOrder { get; set; }
        public DbSet<SalesOrderDetail> SalesOrderDetail { get; set; }
        public DbSet<Receipt> Receipt { get; set; }
        public DbSet<Inventory> Inventory { get; set; }
        public DbSet<InventoryProduct> InventoryProduct { get; set; }
        public DbSet<InventoryReceipt> InventoryReceipt { get; set; }
        public DbSet<InventoryReceiptDetail> InventoryReceiptDetail { get; set; }
        public DbSet<Properties> Properties { get; set; }
        public DbSet<Customer> Customer { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
