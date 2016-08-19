using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Private_ScrumHero.Models;

namespace Private_ScrumHero.Handlers
{
    /// <summary>
    /// Summary description for SeedDB
    /// </summary>
    public class SeedDB : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            try
            {
                using (ApplicationDbContext dbContext = new ApplicationDbContext())
                {
                    var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(dbContext));

                    string[] roleNames = new string[] { "Developer", "ScrumMaster", "ProductOwner", "Administrator" };

                    foreach (string roleName in roleNames)
                    {
                        // Check to see if Role Exists, if not create it
                        if (!roleManager.RoleExists(roleName))
                        {
                            IdentityRole role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                            role.Name = roleName;
                            roleManager.Create(role);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                context.Response.ContentType = "text/plain";
                context.Response.Write("DB Seed failed: " + ex.Message);
            }
            
            context.Response.ContentType = "text/plain";
            context.Response.Write("DB was seeded");
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}