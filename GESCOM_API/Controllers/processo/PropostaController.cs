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
using GESCOM_API.Models;

namespace GESCOM_API.Controllers.processo
{
    public class PropostaController : ApiController
    {
        private ctx_gescom db = new ctx_gescom();

        // GET: api/Proposta
        public IQueryable<proposta_tb> Getproposta_tb()
        {
            return db.proposta_tb;
        }

        // GET: api/Proposta/5
        [ResponseType(typeof(proposta_tb))]
        public IHttpActionResult Getproposta_tb(int id)
        {
            proposta_tb proposta_tb = db.proposta_tb.Find(id);
            if (proposta_tb == null)
            {
                return NotFound();
            }

            return Ok(proposta_tb);
        }

        // PUT: api/Proposta/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putproposta_tb(int id, proposta_tb proposta_tb)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != proposta_tb.proposta_id)
            {
                return BadRequest();
            }

            db.Entry(proposta_tb).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!proposta_tbExists(id))
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

        // POST: api/Proposta
        [ResponseType(typeof(proposta_tb))]
        public IHttpActionResult Postproposta_tb(proposta_tb proposta_tb)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.proposta_tb.Add(proposta_tb);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = proposta_tb.proposta_id }, proposta_tb);
        }

        // DELETE: api/Proposta/5
        [ResponseType(typeof(proposta_tb))]
        public IHttpActionResult Deleteproposta_tb(int id)
        {
            proposta_tb proposta_tb = db.proposta_tb.Find(id);
            if (proposta_tb == null)
            {
                return NotFound();
            }

            db.proposta_tb.Remove(proposta_tb);
            db.SaveChanges();

            return Ok(proposta_tb);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool proposta_tbExists(int id)
        {
            return db.proposta_tb.Count(e => e.proposta_id == id) > 0;
        }
    }
}