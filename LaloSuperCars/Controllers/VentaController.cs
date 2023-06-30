using LaloSuperCars.Models;
using Microsoft.AspNetCore.Mvc;

namespace LaloSuperCars.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VentaController : Controller
    {
        private ModelContext db;

        public VentaController(ModelContext database)
        {
            this.db = database;
        }

        [HttpGet]
        public ActionResult<IEnumerable<VentaModel>> Get()
        {
            return Ok(db.ventaModel.ToList());
        }

        [HttpPost]
        public ActionResult Post([FromBody] VentaModel json)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Informacion invalida");
            }
            db.ventaModel.Add(json);
            db.SaveChanges();
            return Ok();
        }

        [HttpGet("{id_venta}")]
        public async Task<ActionResult> Find(int? id)
        {
            if (id == null)
            {
                return BadRequest("No existe");
            }
            try
            {
                var item = await db.ventaModel.FindAsync(id);
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
        public ActionResult put([FromBody] VentaModel json)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Informacion invalida");
            }
            var dbjson = db.ventaModel.Where(a => a.Id == json.Id).FirstOrDefault();
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
        [Route("{id_venta}")]
        public ActionResult Delete(int? id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Informacion invalida");
            }
            var dbjson = db.ventaModel.Where(a => a.Id == id).FirstOrDefault();
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
