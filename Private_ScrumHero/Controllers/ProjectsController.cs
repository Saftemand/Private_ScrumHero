using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Private_ScrumHero.Models;
using Private_ScrumHero.Services;
using Private_ScrumHero.ViewModels;

namespace Private_ScrumHero.Controllers
{
    public class ProjectsController : Controller
    {

        // GET: Projects
        public ActionResult Index()
        {
            ApplicationUser user = System.Web.HttpContext.Current.GetOwinContext()
                .GetUserManager<ApplicationUserManager>()
                .FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());

            if (user == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            List<ProjectViewModel> viewModels = ProjectService.FindRelatedToApplicationUser(user);
            return View(viewModels);
        }

        // GET: Projects/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ProjectViewModel project = ProjectService.FindById(id);

            if (project == null)
            {
                return HttpNotFound();
            }
            return View(project);
        }

        // GET: Projects/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Projects/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProjectId,Name")] ProjectViewModel project)
        {
            ApplicationUser currentUser = System.Web.HttpContext.Current.GetOwinContext()
                .GetUserManager<ApplicationUserManager>()
                .FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());

            ProjectService.CreateProject(project, currentUser);
            return RedirectToAction("Index");
        }

        // GET: Projects/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjectViewModel viewModel = ProjectService.FindById(id);
            if (viewModel == null)
            {
                return HttpNotFound();
            }
            ViewBag.UsersNotInProject = UserService.GetAllUsersNotInProject(viewModel.ProjectId);
            ViewBag.UsersInProject = UserService.GetAllUsersInProject(viewModel.ProjectId);
            return View(viewModel);
        }

        // POST: Projects/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProjectId,Name")] ProjectViewModel project)
        {
            ProjectService.UpdateProject(project);
            return RedirectToAction("Index");
        }

        // GET: Projects/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Project project = null;

            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                project = context.Projects.Find(id);
            }

            if (project == null)
            {
                return HttpNotFound();
            }

            return View(project);
        }

        // POST: Projects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProjectService.DeleteProject(id);

            return RedirectToAction("Index");
        }

    }
}
