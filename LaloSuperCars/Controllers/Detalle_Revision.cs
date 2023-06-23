using LaloSuperCars.Models;
using Microsoft.AspNetCore.Mvc;

namespace LaloSuperCars.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class Detalle_Revision : Controller
    {
        private ModelContext db;

        public Detalle_Revision(ModelContext database)
        {
            this.db = database;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Detalle_RevisionModel>> Get()
        {
            return Ok(db.detalleRevisionModel.ToList());
        }

        [HttpPost]
        public ActionResult Post([FromBody] Detalle_RevisionModel json)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Informacion invalida");
            }
            db.detalleRevisionModel.Add(json);
            db.SaveChanges();
            return Ok();
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult> Find(int? id)
        {
            if (id == null)
            {
                return BadRequest("No existe");
            }
            try
            {
                var item = await db.detalleRevisionModel.FindAsync(id);
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
        public ActionResult put([FromBody] Detalle_RevisionModel json)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Informacion invalida");
            }
            var dbjson = db.detalleRevisionModel.Where(a => a.Id_detalle_revision == json.Id_detalle_revision).FirstOrDefault();
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
        [Route("{Id}")]
        public ActionResult Delete(int? id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Informacion invalida");
            }
            var dbjson = db.detalleRevisionModel.Where(a => a.Id_detalle_revision == id).FirstOrDefault();
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
