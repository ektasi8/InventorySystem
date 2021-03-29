using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ShopBridge.BAL;

namespace ShopBridge.Controllers
{
    public class ShowBridgeAPIController : ApiController,IDisposable
    {
       private readonly BusinessLogicRepository bal;
        public ShowBridgeAPIController()
        {
            bal = new BusinessLogicRepository(new DataAccessProvider());
        }
        public IHttpActionResult Get()
        {
            try
            {               
                var entity = bal.getProducts();
                if (entity.Count==0)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(entity);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        public IHttpActionResult Post([FromBody]ShopBridge product)
        {
            try
            {
                bal.Add(product);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        public IHttpActionResult Put([FromBody]ShopBridge product)
        {
            try
            {
                bal.Update(product);
                return Ok();  
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        public IHttpActionResult Delete([FromUri]int id)
        {
            try
            {
                if (id > 0)
                {
                    bal.Delete(id);
                    return Ok();
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
        public IHttpActionResult Get(int id)
        {
            try
            {
                var entity = bal.getProducts().FirstOrDefault(p=>p.Id==id);
                if (entity!=null)
                {
                    return Ok(entity);
                   
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

    }
}
