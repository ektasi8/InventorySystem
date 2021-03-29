using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopBridge.BAL
{
    public class DataAccessProvider:IRepository
    {
        public void AddProduct(ShopBridge product)
        {
            Inventory dbcontext = new Inventory();
            dbcontext.ShopBridges.Add(product);
            dbcontext.SaveChanges();
        }

        public void DeleteProducts(int id)
        {
            using(Inventory dbcontext=new Inventory())
            {
                ShopBridge singleshoprec = dbcontext.ShopBridges.FirstOrDefault(predicate => predicate.Id == id);
                dbcontext.ShopBridges.Remove(singleshoprec);
                dbcontext.SaveChanges();
            }
        }
        public ShopBridge EditProducts(int id)
        {
            Inventory dbcontext = new Inventory();
            ShopBridge ob = dbcontext.ShopBridges.FirstOrDefault(p => p.Id == id);
            return ob;
        }

        public List<ShopBridge> ListProducts()
        {
            using (Inventory dbcontext = new Inventory())
            {
                List<ShopBridge> products = dbcontext.ShopBridges.ToList();
                return products;
            }
        }
        public void UpdateProducts(ShopBridge product)
        {
            using(Inventory dbcontext=new Inventory())
            {
                var entity = dbcontext.ShopBridges.FirstOrDefault(m => m.Id == product.Id);
                entity.Name = product.Name;
                entity.Description = product.Description;
                entity.Price = product.Price;
                entity.Qty = product.Qty;
                entity.Status = product.Status;
                dbcontext.SaveChanges();
            }
        }


    }
}