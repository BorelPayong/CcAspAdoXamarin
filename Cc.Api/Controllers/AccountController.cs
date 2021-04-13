using Cc.Api.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using HttpGetAttribute = System.Web.Http.HttpGetAttribute;

namespace Cc.Api.Controllers
{
    public class AccountController : Controller
    {
        private CcAspAdoXamarinDbEntities db = new CcAspAdoXamarinDbEntities();

        [HttpGet]
        public IHttpActionResult ListeProprietaire(int index = 0, int taille = 10)
        {
            try
            {

                var proprietaires = db.Proprietaire
                    .OrderByDescending(x => x.DateDeCreation)
                    .Skip(index * taille).Take(taille).ToList();
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
        public IHttpActionResult ListeBien(int index = 0, int taille = 10)
        {
            try
            {

                var biens = db.Proprietaire
                    .OrderByDescending(x => x.DateDeCreation)
                    .Skip(index * taille).Take(taille).ToList();
                return Ok(biens);
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
    }
}