using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Private_ScrumHero.Models;
using Private_ScrumHero.Services;
using Private_ScrumHero.ViewModels;

namespace Private_ScrumHero.Controllers
{
    public class DeveloperTasksController : Controller
    {
        
        // GET: DeveloperTasks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DeveloperTaskViewModel developerTask = DeveloperTaskService.FindById(id);
            if (developerTask == null)
            {
                return HttpNotFound();
            }
            return View(developerTask);
        }

        // GET: DeveloperTasks/Create
        public ActionResult Create(int? userStoryId)
        {
            DeveloperTaskViewModel developerTaskViewModel = new DeveloperTaskViewModel();
            developerTaskViewModel.UserStoryId = userStoryId.Value;
            
            return View(developerTaskViewModel);
        }

        // POST: DeveloperTasks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DeveloperTaskName,UserStoryId")] DeveloperTaskViewModel viewModel)
        {
            DeveloperTaskService.CreateDeveloperTask(viewModel);
            return RedirectToAction("Details", "UserStories", new { id = viewModel.UserStoryId });
        }

        // GET: DeveloperTasks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DeveloperTaskViewModel viewModel = DeveloperTaskService.FindById(id);
            if (viewModel == null)
            {
                return HttpNotFound();
            }
            return View(viewModel);
        }

        // POST: DeveloperTasks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DeveloperTaskId,DeveloperTaskName,UserStoryId")] DeveloperTaskViewModel viewModel)
        {
            DeveloperTaskService.UpdateDeveloperTask(viewModel);

            return RedirectToAction("Details", "UserStories", new { id = viewModel.UserStoryId });
        }

        // GET: DeveloperTasks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DeveloperTaskViewModel viewModel = DeveloperTaskService.FindById(id);
            if (viewModel == null)
            {
                return HttpNotFound();
            }
            return View(viewModel);
        }

        // POST: DeveloperTasks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id, FormCollection fc)
        {
            int userStoryId = Convert.ToInt32(fc["UserStoryId"]);

            DeveloperTaskService.DeleteDeveloperTask(id);

            return RedirectToAction("Details", "UserStories", new { id = userStoryId });
        }
    }
}
