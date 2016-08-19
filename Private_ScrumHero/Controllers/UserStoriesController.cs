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
    public class UserStoriesController : Controller
    {

        // GET: UserStories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserStoryViewModel userStory = UserStoryService.FindById(id);
            if (userStory == null)
            {
                return HttpNotFound();
            }

            userStory.DeveloperTasks = DeveloperTaskService.FindByIds(userStory.DeveloperTaskIds);
            
            return View(userStory);
        }

        // GET: UserStories/Create
        public ActionResult Create(int? backlogId)
        {
            UserStoryViewModel userStoryViewModel = new UserStoryViewModel();
            userStoryViewModel.Backlog = BacklogService.FindById(backlogId);
            userStoryViewModel.BacklogId = userStoryViewModel.Backlog.BacklogId;
            return View(userStoryViewModel);
        }

        // POST: UserStories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name,BacklogId")] UserStoryViewModel viewModel)
        {
            UserStory userStory = UserStoryService.CreateUserStory(viewModel);

            return RedirectToAction("Index", "Backlogs", new { viewModel.BacklogId });
        }

        // GET: UserStories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserStoryViewModel viewModel = UserStoryService.FindById(id);
            if (viewModel == null)
            {
                return HttpNotFound();
            }
            return View(viewModel);
        }

        // POST: UserStories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserStoryId,Name,backlogId")] UserStoryViewModel viewModel)
        {
            UserStoryService.UpdateUserStory(viewModel);    
            
            return RedirectToAction("Index", "Backlogs", new { viewModel.BacklogId });
        }

        // GET: UserStories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserStoryViewModel viewModel = UserStoryService.FindById(id);
            if (viewModel == null)
            {
                return HttpNotFound();
            }
            return View(viewModel);
        }

        // POST: UserStories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id, FormCollection fc)
        {
            UserStoryService.DeleteById(id);
            int backlogId = Convert.ToInt32(fc["backlogId"]);
            return RedirectToAction("Index", "Backlogs", new { backlogId});
        }
    }
}
