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

namespace GESCOM_API.Controllers.dadosBasicos
{
    public class SeguradoController : ApiController
    {
        private ctx_gescom db = new ctx_gescom();

        // GET: api/Segurado
        [HttpGet]
        public IQueryable<segurado_tb> ListarSegurado()
        {
            return db.segurado_tb;
        }

        // GET: api/Segurado/5
        [ResponseType(typeof(segurado_tb))]
        [HttpGet]
        public IHttpActionResult RecuperarPelaChave(int id)
        {
            segurado_tb segurado_tb = db.segurado_tb.Find(id);
            if (segurado_tb == null)
            {
                return NotFound();
            }

            return Ok(segurado_tb);
        }

        // PUT: api/Segurado/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Atualizar(int id, segurado_tb segurado_tb)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != segurado_tb.segurado_id)
            {
                return BadRequest();
            }

            db.Entry(segurado_tb).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SeguradoExiste(id))
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

        // POST: api/Segurado
        [ResponseType(typeof(segurado_tb))]
        public IHttpActionResult Incluir(segurado_tb segurado_tb)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.segurado_tb.Add(segurado_tb);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = segurado_tb.segurado_id }, segurado_tb);
        }

        // DELETE: api/Segurado/5
        [ResponseType(typeof(segurado_tb))]
        public IHttpActionResult Remover(int id)
        {
            segurado_tb segurado_tb = db.segurado_tb.Find(id);
            if (segurado_tb == null)
            {
                return NotFound();
            }

            db.segurado_tb.Remove(segurado_tb);
            db.SaveChanges();

            return Ok(segurado_tb);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SeguradoExiste(int id)
        {
            return db.segurado_tb.Count(e => e.segurado_id == id) > 0;
        }
    }
}