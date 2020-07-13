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
    public class PasajerosController : ApiController
    {
        private LocalDataContext db = new LocalDataContext();

        // GET: api/Pasajeros
        public IQueryable<Pasajero> GetPasajeroes()
        {
            return db.Pasajeroes;
        }

        // GET: api/Pasajeros/5
        [ResponseType(typeof(Pasajero))]
        public IHttpActionResult GetPasajero(int id)
        {
            Pasajero pasajero = db.Pasajeroes.Find(id);
            if (pasajero == null)
            {
                return NotFound();
            }

            return Ok(pasajero);
        }

        // PUT: api/Pasajeros/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPasajero(int id, Pasajero pasajero)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pasajero.PasajeroId)
            {
                return BadRequest();
            }

            db.Entry(pasajero).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PasajeroExists(id))
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

        // POST: api/Pasajeros
        [ResponseType(typeof(Pasajero))]
        public IHttpActionResult PostPasajero(List<Pasajero> pasajero)
        {
            if(pasajero == null)
            {
                return BadRequest();
            }

            foreach (var item in pasajero)
            {
                var p = ToConvertPasajero(item);

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                db.Pasajeroes.Add(p);
                db.SaveChanges();
            }

            return Ok();
        }

        private Pasajero ToConvertPasajero(Pasajero item)
        {
            return new Pasajero
            {
                Nombre = item.Nombre,
                ApellidoPaterno = item.ApellidoPaterno,
                ApellidoMaterno = item.ApellidoMaterno
            };
        }

        // DELETE: api/Pasajeros/5
        [ResponseType(typeof(Pasajero))]
        public IHttpActionResult DeletePasajero(int id)
        {
            Pasajero pasajero = db.Pasajeroes.Find(id);
            if (pasajero == null)
            {
                return NotFound();
            }

            db.Pasajeroes.Remove(pasajero);
            db.SaveChanges();

            return Ok(pasajero);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PasajeroExists(int id)
        {
            return db.Pasajeroes.Count(e => e.PasajeroId == id) > 0;
        }
    }
}