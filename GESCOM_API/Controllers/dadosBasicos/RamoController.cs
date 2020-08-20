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
using GESCOM_API;
using GESCOM_API.Models;

namespace GESCOM_API.Controllers
{
    public class RamoController : ApiController
    {
        private ctx_gescom db = new ctx_gescom();

        // GET: api/Ramo
        [HttpGet]
        public IQueryable<ramo_tb> ListarRamo()
        {
            return db.ramo_tb;
        }

        // GET: api/Ramo/5
        [ResponseType(typeof(ramo_tb))]
        [HttpGet]
        public IHttpActionResult RecuperarPelaChave(int id)
        {
            ramo_tb ramo_tb = db.ramo_tb.Find(id);
            if (ramo_tb == null)
            {
                return NotFound();
            }

            return Ok(ramo_tb);
        }

        // PUT: api/Ramo/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Atualizar(int id, ramo_tb ramo_tb)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ramo_tb.ramo_id)
            {
                return BadRequest();
            }

            db.Entry(ramo_tb).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RamoExiste(id))
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

        // POST: api/Ramo
        [ResponseType(typeof(ramo_tb))]
        public IHttpActionResult Incluir(ramo_tb ramo_tb)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ramo_tb.Add(ramo_tb);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = ramo_tb.ramo_id }, ramo_tb);
        }

        // DELETE: api/Ramo/5
        [ResponseType(typeof(ramo_tb))]
        public IHttpActionResult Remover(int id)
        {
            ramo_tb ramo_tb = db.ramo_tb.Find(id);
            if (ramo_tb == null)
            {
                return NotFound();
            }

            db.ramo_tb.Remove(ramo_tb);
            db.SaveChanges();

            return Ok(ramo_tb);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RamoExiste(int id)
        {
            return db.ramo_tb.Count(e => e.ramo_id == id) > 0;
        }
    }
}