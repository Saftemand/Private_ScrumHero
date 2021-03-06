﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Private_ScrumHero.Dao;
using Private_ScrumHero.Models;

namespace Private_ScrumHero
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //Database.SetInitializer(new AppDbContextSeeder());
            //Database.SetInitializer(new DropCreateDatabaseIfModelChanges<ApplicationDbContext>());
            //Database.SetInitializer(new DropCreateDatabaseAlways<ApplicationDbContext>());
            //Database.SetInitializer(new DropCreateDatabaseAlways<ApplicationDbContext>());
            Database.SetInitializer(new ApplicationDbContextSeeder());
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
