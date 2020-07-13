using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Examen.API.Models;
using ExamenAeroMexico.Domain;

namespace Examen.API.Controllers
{
    [Authorize]
    public class VuelosController : ApiController
    {
        private LocalDataContext db = new LocalDataContext();

        // GET: api/Vuelos/5
        [ResponseType(typeof(Vuelo))]
        public IHttpActionResult GetVuelo(DateTime fechaInicio, DateTime fechaFin)
        {
            var vuelo = from v in db.Vueloes
                        where (v.FechaSalida >= fechaInicio && v.FechaSalida <= fechaFin)
                        select v;

            if (vuelo == null)
            {
                return BadRequest();
            }

            return Ok(vuelo);
        }

        // PUT: api/Vuelos/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutVuelo(int id, Vuelo vuelo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != vuelo.VueloId)
            {
                return BadRequest();
            }

            db.Entry(vuelo).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VueloExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Vuelos
        [ResponseType(typeof(Vuelo))]
        public IHttpActionResult PostVuelo(List<Vuelo> vuelo)
        {
            if(vuelo == null)
            {
                return BadRequest();
            }
            foreach (var item in vuelo)
            {
                var v = ToConvertVuelo(item);
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                db.Vueloes.Add(v);
                db.SaveChanges();
            }

            return Ok();
        }

        private Vuelo ToConvertVuelo(Vuelo item)
        {
            return new Vuelo
            {
                NumeroVuelo = item.NumeroVuelo,
                Origen = item.Origen,
                Destino = item.Destino,
                FechaSalida = item.FechaSalida
            };
        }

        // DELETE: api/Vuelos/5
        [ResponseType(typeof(Vuelo))]
        public IHttpActionResult DeleteVuelo(int id)
        {
            Vuelo vuelo = db.Vueloes.Find(id);
            if (vuelo == null)
            {
                return NotFound();
            }

            db.Vueloes.Remove(vuelo);
            db.SaveChanges();

            return Ok(vuelo);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool VueloExists(int id)
        {
            return db.Vueloes.Count(e => e.VueloId == id) > 0;
        }
    }
}