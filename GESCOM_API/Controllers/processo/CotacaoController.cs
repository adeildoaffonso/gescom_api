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
    public class CotacaoController : ApiController
    {
        private ctx_gescom db = new ctx_gescom();

        // GET: api/Cotacao
        public IQueryable<cotacao_tb> Listar()
        {
            return db.cotacao_tb;
        }

        // GET: api/Cotacao/5
        [ResponseType(typeof(cotacao_tb))]
        public IHttpActionResult RecuperarPelaChave(int id)
        {
            cotacao_tb cotacao_tb = db.cotacao_tb.Find(id);
            if (cotacao_tb == null)
            {
                return NotFound();
            }

            return Ok(cotacao_tb);
        }

        // PUT: api/Cotacao/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Atualizar(int id, cotacao_tb cotacao_tb)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cotacao_tb.cotacao_id)
            {
                return BadRequest();
            }

            db.Entry(cotacao_tb).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!cotacao_tbExists(id))
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

        // POST: api/Cotacao
        [ResponseType(typeof(cotacao_tb))]
        public IHttpActionResult Inserir(cotacao_tb cotacao_tb)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.cotacao_tb.Add(cotacao_tb);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = cotacao_tb.cotacao_id }, cotacao_tb);
        }

        // DELETE: api/Cotacao/5
        [ResponseType(typeof(cotacao_tb))]
        public IHttpActionResult Apagar(int id)
        {
            cotacao_tb cotacao_tb = db.cotacao_tb.Find(id);
            if (cotacao_tb == null)
            {
                return NotFound();
            }

            db.cotacao_tb.Remove(cotacao_tb);
            db.SaveChanges();

            return Ok(cotacao_tb);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool cotacao_tbExists(int id)
        {
            return db.cotacao_tb.Count(e => e.cotacao_id == id) > 0;
        }
    }
}