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
        public List<ShopBridge> getProducts()
        {
            List<ShopBridge> lstProducts = _irepository.ListProducts();
            return lstProducts;
        }
        public void Add(ShopBridge product)
        {
            _irepository.AddProduct(product);
        }
        public ShopBridge Edit(int id)
        {
            ShopBridge product = _irepository.EditProducts(id);
            return product;
        }

        public void Delete(int id)
        {
            _irepository.DeleteProducts(id);
        }
        public void Update(ShopBridge product)
        {
            _irepository.UpdateProducts(product);
        }
        
    }
}