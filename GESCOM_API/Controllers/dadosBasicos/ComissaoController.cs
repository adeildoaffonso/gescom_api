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
    public class ComissaoController : ApiController
    {
        private ctx_gescom db = new ctx_gescom();

        // GET: api/Comissao
        public IQueryable<recibo_comissao_tb> Getrecibo_comissao_tb()
        {
            return db.recibo_comissao_tb;
        }

        // GET: api/Comissao/5
        [ResponseType(typeof(recibo_comissao_tb))]
        public IHttpActionResult Getrecibo_comissao_tb(int id)
        {
            recibo_comissao_tb recibo_comissao_tb = db.recibo_comissao_tb.Find(id);
            if (recibo_comissao_tb == null)
            {
                return NotFound();
            }

            return Ok(recibo_comissao_tb);
        }

        // GET: api/Comissao
        [HttpGet]
        public IQueryable<object> ListarComissao()
        {
            //List<proposta_tb> proposta = db.proposta_tb.Include("cotacao_tb").ToList();

            var recibo = from rec in db.recibo_comissao_tb
                         join pro in db.proposta_tb on rec.proposta_id equals pro.proposta_id
                         join cot in db.cotacao_tb on pro.cotacao_id equals cot.cotacao_id
                         join seg in db.segurado_tb on cot.segurado_id equals seg.segurado_id
                         join pes in db.pessoa_tb on seg.pessoa_id equals pes.pessoa_id
                         select rec;
            return recibo;

            //return db.recibo_comissao_tb.Include("proposta_tb");
        }

        // GET: api/Segurado/5
        [ResponseType(typeof(recibo_comissao_tb))]
        [HttpGet]
        public IHttpActionResult RecuperarPelaChave(int id)
        {
            recibo_comissao_tb comissao_tb = db.recibo_comissao_tb.Find(id);
            if (comissao_tb == null)
            {
                return NotFound();
            }

            return Ok(comissao_tb);
        }

        // PUT: api/Comissao/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Atualizar(int id, recibo_comissao_tb comissao_tb)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != comissao_tb.recibo_comissao_id)
            {
                return BadRequest();
            }

            db.Entry(comissao_tb).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!recibo_comissao_tbExists(id))
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
        [ResponseType(typeof(recibo_comissao_tb))]
        public IHttpActionResult Incluir(recibo_comissao_tb comissao_tb)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.recibo_comissao_tb.Add(comissao_tb);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = comissao_tb.recibo_comissao_id }, comissao_tb);
        }

        // DELETE: api/Segurado/5
        [ResponseType(typeof(recibo_comissao_tb))]
        public IHttpActionResult Remover(int id)
        {
            recibo_comissao_tb comissao_tb = db.recibo_comissao_tb.Find(id);
            if (comissao_tb == null)
            {
                return NotFound();
            }

            db.recibo_comissao_tb.Remove(comissao_tb);
            db.SaveChanges();

            return Ok(comissao_tb);
        }

        // PUT: api/Comissao/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putrecibo_comissao_tb(int id, recibo_comissao_tb recibo_comissao_tb)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != recibo_comissao_tb.recibo_comissao_id)
            {
                return BadRequest();
            }

            db.Entry(recibo_comissao_tb).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!recibo_comissao_tbExists(id))
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

        // POST: api/Comissao
        [ResponseType(typeof(recibo_comissao_tb))]
        public IHttpActionResult Postrecibo_comissao_tb(recibo_comissao_tb recibo_comissao_tb)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.recibo_comissao_tb.Add(recibo_comissao_tb);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = recibo_comissao_tb.recibo_comissao_id }, recibo_comissao_tb);
        }

        // DELETE: api/Comissao/5
        [ResponseType(typeof(recibo_comissao_tb))]
        public IHttpActionResult Deleterecibo_comissao_tb(int id)
        {
            recibo_comissao_tb recibo_comissao_tb = db.recibo_comissao_tb.Find(id);
            if (recibo_comissao_tb == null)
            {
                return NotFound();
            }

            db.recibo_comissao_tb.Remove(recibo_comissao_tb);
            db.SaveChanges();

            return Ok(recibo_comissao_tb);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool recibo_comissao_tbExists(int id)
        {
            return db.recibo_comissao_tb.Count(e => e.recibo_comissao_id == id) > 0;
        }
    }
}