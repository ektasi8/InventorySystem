using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace ShopBridge.Controllers
{
    public class InventoryController : Controller
    {
        // GET: Inventory
        public ActionResult Index()
        {
            List<ShopBridge> prodcusts = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:54454/api/");
                //http get
                var responseTask = client.GetAsync("showBridgeApi");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<List<ShopBridge>>();
                    readTask.Wait();

                    prodcusts = readTask.Result;
                }
                else
                {
                    //web api send error message
                    //log response status here...
                    //prodcusts = Enumerable.Empty<ShopBridge>();
                    prodcusts = null;

                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }
            return View(prodcusts);
        }

        public ActionResult Create()
        {
            return View();
        }
        
        [HttpPost]        
        public ActionResult Create(ShopBridge products)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:54454/api/");
                var postData = client.PostAsJsonAsync<ShopBridge>("showBridgeApi", products);
                postData.Wait();

                var result = postData.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator");

            return View(products);
        }


        public ActionResult Delete(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:54454/api/");
                var deleteTask = client.DeleteAsync("showBridgeApi/" + id.ToString());

                var result = deleteTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");

                }
            }

            return RedirectToAction("Index");
            
            //return RedirectToAction();
        }

        public ActionResult Edit(int id)
        {
            ShopBridge product = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:54454/api/showBridgeApi/");

                var responseTask = client.GetAsync("?id=" + id.ToString());
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<ShopBridge>();
                    readTask.Wait();

                    product = readTask.Result;
                }
            }
            return View(product);
        }
        
        [HttpPost]
        public ActionResult Edit(ShopBridge product)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:54454/api/showBridgeApi");

                var putTask = client.PutAsJsonAsync<ShopBridge>("showBridgeApi", product);
                putTask.Wait();

                var result = putTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }

            }
            return View(product);
        }
    }
}