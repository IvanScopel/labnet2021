using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using tp04.Data;
using tp04.Entities;
using tp04.Logic;
using tp08.WebApi.Models;

namespace tp08.WebApi.Controllers
{
    
    public class ShippersApiController : ApiController
    {
        ShippersLogic shippersLogic = new ShippersLogic();


        [HttpGet]
        public IEnumerable<ShippersDTO> Get()
        {
            
            var Shippers = from s in shippersLogic.GetAll()
                           select new ShippersDTO()
                           {
                               ShipperID = s.ShipperID,
                               CompanyName = s.CompanyName,
                               Phone = s.Phone
                           };

            return Shippers;
            
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");

            var shipper = shippersLogic.Search(id);

            if (shipper != null)
            {
                shippersLogic.Delete(id);
                return Ok(shipper);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public IHttpActionResult Insert([FromBody]Shippers shipper)
        {

            if (ModelState.IsValid)
            {
                shippersLogic.Add(shipper);
                return Ok();
            }
            else
            {
                return BadRequest();
            }


        }


    }
}