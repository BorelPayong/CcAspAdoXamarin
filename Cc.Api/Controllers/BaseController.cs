using Cc.Api.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Cc.Api.Controllers
{
    public class BaseController : ApiController
    {
        protected CcAspAdoXamarinDbEntities db = new CcAspAdoXamarinDbEntities();
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
