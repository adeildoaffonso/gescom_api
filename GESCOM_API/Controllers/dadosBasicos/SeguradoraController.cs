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
    public class SeguradoraController : ApiController
    {
        private ctx_gescom db = new ctx_gescom();

        // GET: api/Seguradora
        [HttpGet]
        public IQueryable<seguradora_tb> ListarSeguradora()
        {
            return db.seguradora_tb;
        }

        // GET: api/Seguradora/5
        [ResponseType(typeof(seguradora_tb))]
        [HttpGet]
        public IHttpActionResult RecuperarPelaChave(int id)
        {
            seguradora_tb seguradora_tb = db.seguradora_tb.Find(id);
            if (seguradora_tb == null)
            {
                return NotFound();
            }

            return Ok(seguradora_tb);
        }

        // PUT: api/Seguradora/5
        [ResponseType(typeof(void))]
        [HttpPut]
        public IHttpActionResult Atualizar(int id, seguradora_tb seguradora_tb)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != seguradora_tb.seguradora_id)
            {
                return BadRequest();
            }

            db.Entry(seguradora_tb).State = EntityState.Modified;
            db.Entry(seguradora_tb.pessoa_tb).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SeguradoraExiste(id))
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

        // POST: api/Seguradora
        [ResponseType(typeof(seguradora_tb))]
        [HttpPost]
        public IHttpActionResult Incluir(seguradora_tb seguradora_tb)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.seguradora_tb.Add(seguradora_tb);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = seguradora_tb.seguradora_id }, seguradora_tb);
        }

        // DELETE: api/Seguradora/5
        [ResponseType(typeof(seguradora_tb))]
        [HttpDelete]
        public IHttpActionResult Remover(int id)
        {
            seguradora_tb seguradora_tb = db.seguradora_tb.Find(id);
            if (seguradora_tb == null)
            {
                return NotFound();
            }

            db.seguradora_tb.Remove(seguradora_tb);
            db.SaveChanges();

            return Ok(seguradora_tb);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SeguradoraExiste(int id)
        {
            return db.seguradora_tb.Count(e => e.seguradora_id == id) > 0;
        }
    }
}