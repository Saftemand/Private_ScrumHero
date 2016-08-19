using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Private_ScrumHero.ModelConverters;
using Private_ScrumHero.Models;
using Private_ScrumHero.Services;
using Private_ScrumHero.ViewModels;

namespace Private_ScrumHero.Controllers
{

    public class BacklogsController : Controller
    {

        // GET: Backlogs
        public ActionResult Index(int? backlogId)
        {
            if (backlogId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            
            BacklogViewModel viewModel = BacklogService.FindById(backlogId);

            if (viewModel == null)
            {
                return HttpNotFound();
            }

            return View(viewModel);
        }

    }
}
