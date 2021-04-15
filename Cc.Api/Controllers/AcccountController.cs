using Cc.Api.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Cc.Api.Controllers
{
    public class AcccountController : ApiController
    {
        private CcAspAdoXamarinDbEntities Db = new CcAspAdoXamarinDbEntities();

        protected override void Dispose(bool disposing)
        {
            Db.Dispose();
            base.Dispose(disposing);
        }

        [HttpGet]
        public IHttpActionResult ListeProprietaire()
        {
            try
            {
                var proprietaires = Db.Proprietaire
                    .OrderByDescending(x => x.DateDeCreation).ToList();
                return Ok(proprietaires);
            }
            catch (DbUpdateException ex)
            {
                var exception = ex.InnerException?.InnerException as SqlException;
                return BadRequest(exception?.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public IHttpActionResult DetailsProprietaire(int id)
        {
            try
            {
                var proprietaire = Db.Proprietaire.Find(id);
                return Ok(proprietaire);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
