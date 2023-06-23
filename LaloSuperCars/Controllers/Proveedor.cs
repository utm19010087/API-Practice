﻿using LaloSuperCars.Models;
using Microsoft.AspNetCore.Mvc;

namespace LaloSuperCars.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class Proveedor : Controller
    {
        private ModelContext db;

        public Proveedor(ModelContext database) 
        {
            this.db = database;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ProveedorModel>> Get() 
        {
            return Ok(db.proveedorModel.ToList());
        }

        [HttpPost]
        public ActionResult Post([FromBody]ProveedorModel json) 
        {
            if(!ModelState.IsValid)
            {
                return BadRequest("Informacion invalida");
            }
            db.proveedorModel.Add(json);
            db.SaveChanges();
            return Ok();
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult> Find(int? id) 
        {
            if(id == null)
            {
                return BadRequest("No existe");
            }
            try
            {
                var item = await db.proveedorModel.FindAsync(id);
                if(item==null)
                {
                    return NotFound();
                }
                return Ok(item);
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpPut]
        public ActionResult put([FromBody]ProveedorModel json)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest("Informacion invalida");
            }
            var dbjson = db.proveedorModel.Where(a => a.Id == json.Id).FirstOrDefault();
            if(dbjson == null)
            {
                return BadRequest($"proveedor con id json.id no fue encontrado");
            }
            db.Entry(dbjson).CurrentValues.SetValues(json);
            db.Update(dbjson);
            db.SaveChanges();
            return Ok();
        }

        [HttpDelete]
        [Route("{Id}")]
        public ActionResult Delete(int? id)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest("Informacion invalida");
            }
            var dbjson = db.proveedorModel.Where(a => a.Id == id).FirstOrDefault();
            if(dbjson == null)
            {
                return BadRequest($"Provedor con id.int no fue encontradp");
            }
            db.Remove(dbjson);
            db.SaveChanges();
            return Ok();
        }
    }
}
