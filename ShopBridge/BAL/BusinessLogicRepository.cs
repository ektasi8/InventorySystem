using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopBridge.BAL
{
    public class BusinessLogicRepository
    {
        private readonly IRepository _irepository;
        public BusinessLogicRepository(IRepository _repository)
        {
            _irepository = _repository;
        }
        //this return all products details
        public List<ShopBridge> getProducts()
        {
            List<ShopBridge> lstProducts = _irepository.ListProducts();
            return lstProducts;
        }
         //this add new products details
        public void Add(ShopBridge product)
        {
            _irepository.AddProduct(product);
        }
        public ShopBridge Edit(int id)
        {
            ShopBridge product = _irepository.EditProducts(id);
            return product;
        }
        //this delete products details
        public void Delete(int id)
        {
            _irepository.DeleteProducts(id);
        }
        //this update products details
        public void Update(ShopBridge product)
        {
            _irepository.UpdateProducts(product);
        }
        
    }
}
