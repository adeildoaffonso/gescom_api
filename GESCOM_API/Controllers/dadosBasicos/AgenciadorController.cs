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
    public class AgenciadorController : ApiController
    {
        private ctx_gescom db = new ctx_gescom();

        // GET: api/Agenciador
        [HttpGet]
        public List<agenciador_tb> ListarAgenciador()
        {
            List<agenciador_tb> retorno = new List<agenciador_tb>();
            //antigo.
            var query = (from ag in db.agenciador_tb
                         join pe in db.pessoa_tb on ag.pessoa_id equals pe.pessoa_id
                         select new
                         {
                             agenciador_id = ag.agenciador_id,
                             pessoa_id = ag.pessoa_id,
                             nome = pe.nome, cpf_cnpj = pe.cpf_cnpj, email = pe.email
                         }).ToList();

            retorno = query.Select(x => new agenciador_tb
            {
                agenciador_id = x.agenciador_id,
                pessoa_tb = new pessoa_tb { pessoa_id = x.pessoa_id, nome = x.nome, cpf_cnpj = x.cpf_cnpj, email = x.email }
            }).ToList<agenciador_tb>();

            return retorno;

            //return db.pessoa_tb.ToList();

        }


        // GET: api/Agenciador
        [HttpGet]
        public HttpResponseMessage ListarAgenciador_novo()
        {
/*
            DataTablesQueryResult<agenciador_tb> result = null; //objContratoService.ListarContratos(objQuery, seguradoraId);
            return ApiResponse(result);
*/
            var agenciador = from ag in db.agenciador_tb
                             join pe in db.pessoa_tb on ag.pessoa_id equals pe.pessoa_id
                             select ag;

            return Request.CreateResponse(HttpStatusCode.OK, new { sucesso = true, data = agenciador });

        }

        // GET: api/Agenciador/5
        [ResponseType(typeof(agenciador_tb))]
        [HttpGet]
        public IHttpActionResult RecuperarPelaChave(int id)
        {
            agenciador_tb agenciador_tb = db.agenciador_tb.Find(id);
            if (agenciador_tb == null)
            {
                return NotFound();
            }

            return Ok(agenciador_tb);
        }

        // PUT: api/Agenciador/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Atualizar(int id, agenciador_tb agenciador_tb)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != agenciador_tb.agenciador_id)
            {
                return BadRequest();
            }

            db.Entry(agenciador_tb).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AgenciadorExiste(id))
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

        // POST: api/Agenciador
        [ResponseType(typeof(agenciador_tb))]
        public IHttpActionResult Incluir(agenciador_tb agenciador_tb)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.agenciador_tb.Add(agenciador_tb);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = agenciador_tb.agenciador_id }, agenciador_tb);
        }

        // DELETE: api/Agenciador/5
        [ResponseType(typeof(agenciador_tb))]
        public IHttpActionResult Remover(int id)
        {
            agenciador_tb agenciador_tb = db.agenciador_tb.Find(id);
            if (agenciador_tb == null)
            {
                return NotFound();
            }

            db.agenciador_tb.Remove(agenciador_tb);
            db.SaveChanges();

            return Ok(agenciador_tb);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AgenciadorExiste(int id)
        {
            return db.agenciador_tb.Count(e => e.agenciador_id == id) > 0;
        }
    }
}