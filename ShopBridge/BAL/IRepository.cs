using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace ShopBridge.BAL
{
    public interface IRepository
    {
        List<ShopBridge> ListProducts();
        void AddProduct(ShopBridge product);
        ShopBridge EditProducts(int id);
        void DeleteProducts(int id);
        void UpdateProducts(ShopBridge product);
    }
}