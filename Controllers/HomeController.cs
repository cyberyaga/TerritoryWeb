using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TerritoryWeb.Data;
using TerritoryWeb.Models;
using static TerritoryWeb.Models.HomeScreenModel;

namespace TerritoryWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext db;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            db = context;
        }

        public IActionResult Index()
        {
            HomeScreenModel hsm = new HomeScreenModel();
            hsm.CheckedInTerritories = new List<CheckedInTerritoriesModel>();
            hsm.TerritoriesAdded = new List<TerritoriesModifiedAdded>();
            hsm.TerritoriesModified = new List<TerritoriesModifiedAdded>();

            if (User.Identity.IsAuthenticated)
            {
                string[] Allowed = { "Manager", "Admin" };

                for (int i = 0; i < Allowed.Length; i++)
                {
                    if (User.IsInRole(Allowed[i]))
                    {
            
                        int CongID = Common.IdentityExtensions.GetCongregationID(User);
                        DateTime lastDay = DateTime.Now.AddDays(-30).Date;

                        hsm.ShowDash = true; //If any allowed, then show
                        hsm.CheckedInTerritories = (from c in db.Territories
                                                    where c.CongregationID == CongID && c.CheckedIn.HasValue
                                                    orderby c.CheckedIn descending
                                                    select new CheckedInTerritoriesModel() 
                                                    { TerritoryID = c.Id, Territory = c.TerritoryName, CheckedInTime = c.CheckedIn.Value }).Take(5).ToList();
                        hsm.TerritoriesAdded = (from t in db.Territories
                                                where t.CongregationID == CongID && t.Doors.Any(x => x.Added >= lastDay)
                                                select new TerritoriesModifiedAdded() 
                                                { TerritoryID = t.Id, Territory = t.TerritoryName, count = t.Doors.Count(), AddedModDate = t.Doors.OrderByDescending(s => s.Added).FirstOrDefault().Added }).OrderByDescending(s => s.AddedModDate).ToList();

                        hsm.TerritoriesModified = (from t in db.Territories
                                                   where t.CongregationID == CongID && t.Doors.Any(x => x.Modified >= lastDay)
                                                   select new TerritoriesModifiedAdded() 
                                                   { TerritoryID = t.Id, Territory = t.TerritoryName, count = t.Doors.Count(), AddedModDate = t.Doors.OrderByDescending(s => s.Modified).FirstOrDefault().Modified }).OrderByDescending(s => s.AddedModDate).ToList();

                        break;
                    }
                }
            }
            return View(hsm);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
