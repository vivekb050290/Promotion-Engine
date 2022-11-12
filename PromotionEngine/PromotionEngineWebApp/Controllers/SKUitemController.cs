using Microsoft.AspNetCore.Mvc;
using PromotionEngine.Items;
using PromotionEngine.Store;
using PromotionEngineWebApp.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PromotionEngineWebApp.DTO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PromotionEngineWebApp.Controllers
{
    [Route("api/SKUitems")]
    [ApiController]
    public class SKUitemController : ControllerBase
    {
        private readonly IStore Store;
        public SKUitemController(IStore store)
        {
            Store = store;
        }

        // GET: api/<SKUitemController>
        [HttpGet]
        public ActionResult<IEnumerable<SKUitem>> GetAllSKUitems()
        public ActionResult<IEnumerable<SKUitemDTO>> GetAllSKUitems()
        {
            return Store.GetSKUitems();
            try
            {
                return Ok(Store.GetSKUitems().Select(s => s.ToDTO()));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // GET api/<SKUitemController>/5
        [HttpGet("{id}")]
        public ActionResult<SKUitem> GetSKUitem(string id)
        public ActionResult<SKUitemDTO> GetSKUitem(string id)
        {
            return Store.GetSKUitems().FirstOrDefault(i => id.Equals(i.ID));
            try
            {
                return Ok(Store.GetSKUitems().FirstOrDefault(i => id.Equals(i.ID)).ToDTO());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // POST api/<SKUitemController>
        [HttpPost]
        public void PostSKUitem(SKUitemDTO item)
        public ActionResult<SKUitemDTO> PostSKUitem(SKUitemDTO item)
        {
            Store.AddSKUitem(new SKUitem(item.ID, item.UnitPrice));
            try
            {
                var itemDao = item.ToDAO();

                Store.AddSKUitem(itemDao);

                return CreatedAtAction(
                    nameof(GetSKUitem),
                    new { id = item.ID },
                    itemDao.ToDTO());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // PUT api/<SKUitemController>/5
        [HttpPut("{skuID}")]
        public void Put(string skuID, float unitPrice)
        public ActionResult<SKUitemDTO> Put(string skuID, float unitPrice)
        {
            Store.UpdateSKUitemUnitPrice(skuID, unitPrice);
            try
            {
                Store.UpdateSKUitemUnitPrice(skuID, unitPrice);

                return CreatedAtAction(
                    nameof(GetSKUitem),
                    new { id = skuID },
                    new SKUitem(skuID, unitPrice).ToDTO());

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // DELETE api/<SKUitemController>/5
        [HttpDelete("{skuID}")]
        public void DeleteSKU(string skuID)
        public ActionResult<string> DeleteSKU(string skuID)
        {
            Store.DeleteSKUitem(skuID);
            try
            {
                Store.DeleteSKUitem(skuID);
                return Ok(skuID);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}