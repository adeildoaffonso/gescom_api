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
    public class CorretorController : ApiController
    {
        private ctx_gescom db = new ctx_gescom();

        // GET: api/Corretor
        [HttpGet]
        public IQueryable<corretor_tb> ListarTodos()
        {
            return db.corretor_tb;
        }

        // GET: api/Corretor/5
        [ResponseType(typeof(corretor_tb))]
        [HttpGet]
        public IHttpActionResult RecuperarPelaChave(int id)
        {
            corretor_tb corretor_tb = db.corretor_tb.Find(id);
            if (corretor_tb == null)
            {
                return NotFound();
            }

            return Ok(corretor_tb);
        }

        [HttpGet]
        public IHttpActionResult RecuperarPeloSUSEP(string id)
        {
            corretor_tb corretor_tb = db.corretor_tb.Where(p => p.codigo_susep.Equals(id)).FirstOrDefault();
            if (corretor_tb == null)
            {
                return NotFound();
            }

            return Ok(corretor_tb);
        }

        // PUT: api/Corretor/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Alterar(int id, corretor_tb corretor_tb)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != corretor_tb.corretor_id)
            {
                return BadRequest();
            }

            db.Entry(corretor_tb).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CorretorExiste(id))
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

        // POST: api/Corretor
        [ResponseType(typeof(corretor_tb))]
        public IHttpActionResult Incluir(corretor_tb corretor_tb)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.corretor_tb.Add(corretor_tb);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = corretor_tb.corretor_id }, corretor_tb);
        }

        // DELETE: api/Corretor/5
        [ResponseType(typeof(corretor_tb))]
        public IHttpActionResult Remover(int id)
        {
            corretor_tb corretor_tb = db.corretor_tb.Find(id);
            if (corretor_tb == null)
            {
                return NotFound();
            }

            db.corretor_tb.Remove(corretor_tb);
            db.SaveChanges();

            return Ok(corretor_tb);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        [HttpGet]
        private bool CorretorExiste(int id)
        {
            return db.corretor_tb.Count(e => e.corretor_id == id) > 0;
        }
    }
}