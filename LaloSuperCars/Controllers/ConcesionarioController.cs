using LaloSuperCars.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
namespace LaloSuperCars.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ConcesionarioController : Controller
    {
        private ModelContext db;

        public ConcesionarioController(ModelContext database)
        {
            this.db = database;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ConcesionarioModel>> Get()
        {
            return Ok(db.concesionarioModel.ToList());
        }

        [HttpPost]
        public ActionResult Post([FromBody] ConcesionarioModel json)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Informacion invalida");
            }
            db.concesionarioModel.Add(json);
            db.SaveChanges();
            return Ok();
        }

        [HttpGet("{id_concesionario}")]
        public async Task<ActionResult> Find(int? id)
        {
            if (id == null)
            {
                return BadRequest("No existe");
            }
            try
            {
                var item = await db.concesionarioModel.FindAsync(id);
                if (item == null)
                {
                    return NotFound();
                }
                return Ok(item);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpPut]
        public ActionResult put([FromBody] ConcesionarioModel json)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Informacion invalida");
            }
            var dbjson = db.concesionarioModel.Where(a => a.Id == json.Id).FirstOrDefault();
            if (dbjson == null)
            {
                return BadRequest($"proveedor con id json.id no fue encontrado");
            }
            db.Entry(dbjson).CurrentValues.SetValues(json);
            db.Update(dbjson);
            db.SaveChanges();
            return Ok();
        }

        [HttpDelete]
        [Route("{id_concesionario}")]
        public ActionResult Delete(int? id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Informacion invalida");
            }
            var dbjson = db.concesionarioModel.Where(a => a.Id == id).FirstOrDefault();
            if (dbjson == null)
            {
                return BadRequest($"Provedor con id.int no fue encontradp");
            }
            db.Remove(dbjson);
            db.SaveChanges();
            return Ok();
        }
    }
}
