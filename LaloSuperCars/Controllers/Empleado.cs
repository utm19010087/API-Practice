using LaloSuperCars.Models;
using Microsoft.AspNetCore.Mvc;

namespace LaloSuperCars.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class Empleado : Controller
    {
        private ModelContext db;

        public Empleado(ModelContext database)
        {
            this.db = database;
        }

        [HttpGet]
        public ActionResult<IEnumerable<EmpleadoModel>> Get()
        {
            return Ok(db.empleadoModel.ToList());
        }

        [HttpPost]
        public ActionResult Post([FromBody] EmpleadoModel json)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Informacion invalida");
            }
            db.empleadoModel.Add(json);
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
                var item = await db.empleadoModel.FindAsync(id);
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
        public ActionResult put([FromBody] EmpleadoModel json)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Informacion invalida");
            }
            var dbjson = db.empleadoModel.Where(a => a.Id == json.Id).FirstOrDefault();
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
            var dbjson = db.empleadoModel.Where(a => a.Id == id).FirstOrDefault();
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
