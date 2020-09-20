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

        // GET: api/Corretor
        [HttpGet]
        public List<corretor_tb> Listar()
        {
            var query = (from co in db.corretor_tb
                         join pe in db.pessoa_tb on co.pessoa_id equals pe.pessoa_id
                         select new
                         {
                             corretor_id = co.corretor_id
                             ,pessoa_id = pe.pessoa_id
                             ,nome = pe.nome
                             ,cpf_cnpj = pe.cpf_cnpj
                             ,email = pe.email
                             ,tipo_pessoa = pe.tipo_pessoa
                         }).ToList();

            List<corretor_tb> retorno = query.Select(p => new corretor_tb
            {
                corretor_id = p.corretor_id,
                pessoa_tb = new pessoa_tb
                {
                    pessoa_id = p.pessoa_id,
                    email = p.email,
                    cpf_cnpj = p.cpf_cnpj,
                    nome = p.nome
                }
            }).ToList<corretor_tb>();
            return retorno;
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
        [HttpPut]
        public IHttpActionResult Atualizar(int id, corretor_tb corretor_tb)
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
            db.Entry(corretor_tb.pessoa_tb).State = EntityState.Modified;

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