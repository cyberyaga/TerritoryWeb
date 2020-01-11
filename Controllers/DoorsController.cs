using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TerritoryWeb;
using TerritoryWeb.Common;
using TerritoryWeb.Data;
using TerritoryWeb.Models;

namespace TerritoryWeb.Controllers
{
    public class DoorsController : Controller
    {
        private readonly ApplicationDbContext db;
        public DoorsController(ApplicationDbContext context)
        {
            db = context;
        }


        [Authorize(Roles = "Admin,Manager,TerritoryEditor,Editor,ReadOnly")]
        public ActionResult Index(int TerritoryID, bool ProxSort = false)
        {
            int CongID = Common.IdentityExtensions.GetCongregationID(User);
            bool LimitUser = !(User.IsInRole("Admin") || User.IsInRole("Manager") || User.IsInRole("TerritoryEditor"));

            //Make sure the territory is allowed
            string UserID = Common.IdentityExtensions.GetUserID(User);
            List<int> addTerr = db.TerritoryAccesses.Where(x => x.UserId == UserID).Select(s => s.TerritoryId).ToList();

            var ter = db.Territories.Where(t => t.CongregationID == CongID && t.Id == TerritoryID 
                && (LimitUser ? (t.AssignedPublisherId == UserID || addTerr.Contains(t.Id)) : true) 
                );

            if (ter.Count() == 0)
            {
                return NotFound();
            }


            var doors = (from d in db.Doors
                        .Include(d => d.Territory)
                        .Include(d => d.Language)
                        where d.TerritoryId == TerritoryID && d.Territory.CongregationID == CongID
                        && (LimitUser ? (d.Territory.AssignedPublisherId == UserID || addTerr.Contains(d.TerritoryId)) : true) //Make sure the territory is allowed.
                        orderby d.Street ascending, d.Address ascending
                        select d).ToList();

            ViewBag.ProxEnabled = ProxSort;
            ViewBag.languages = (from l in db.Languages //Get Language List for dropdown.
                                 where !l.CongregationID.HasValue || l.CongregationID == CongID
                                 select new SelectListItem() { Value = l.Id.ToString(), Text = l.Description, Selected = false }).ToList();

            ViewBag.doorcodes = (from l in db.DoorCodes //Get Language List for dropdown.
                                 where l.CongregationID == CongID
                                 select new SelectListItem() { Value = l.Id.ToString(), Text = l.Description, Selected = false }).ToList();

            ViewBag.TerritoryName = db.Territories.Single(x => x.Id == TerritoryID && x.CongregationID == CongID).TerritoryName;

            if (LimitUser) //Limit the dropdown.
            {
                ViewBag.TerritoryId = new SelectList(db.Territories.Where(x => x.Id != TerritoryID && x.CongregationID == CongID && (x.AssignedPublisherId == UserID || addTerr.Contains(x.Id))).OrderBy(s => s.TerritoryName), "Id", "TerritoryName");
            }
            else
            {
                ViewBag.TerritoryId = new SelectList(db.Territories.Where(x => x.Id != TerritoryID && x.CongregationID == CongID).OrderBy(s => s.TerritoryName), "Id", "TerritoryName");
            }


            //Proximity Sort
            if (ProxSort && doors.Count() > 0)
            {
                List<Door> DoorList = new List<Door>();
                Door lastAdded = doors[0];
                DoorList.Add(lastAdded);
                Haversine h = new Haversine();
                //Loop Through 
                for (int i = 1; i < doors.Count(); i++)
                {
                    double Prox = 50;
                    Door closest = new Door();
                    TerritoryWeb.Common.Haversine.Position p1 = new TerritoryWeb.Common.Haversine.Position { Latitude = (double)lastAdded.GeoLat, Longitude = (double)lastAdded.GeoLong };

                    //Get the shortest distance (from whatever is not in the DoorList)
                    foreach (Door d in doors.Where(x => !DoorList.Any(s => s.Id == x.Id)))
                    {
                        TerritoryWeb.Common.Haversine.Position p2 = new TerritoryWeb.Common.Haversine.Position { Latitude = (double)d.GeoLat, Longitude = (double)d.GeoLong };
                        //Calculate Proximity
                        double curProx = h.Distance(p1, p2, Haversine.DistanceType.Miles);

                        //If the street is the same, skew distance
                        curProx = (lastAdded.Street == d.Street && curProx > 0.04) ? curProx - 0.04 : curProx;

                        //If distance is shorter, take notes
                        if (Prox > curProx)
                        {
                            Prox = curProx;
                            closest = d;
                        }
                    }

                    //Add to list
                    DoorList.Add(closest);
                    lastAdded = closest;
                }
                doors = DoorList;
            }



            return View(doors);
        }

        // GET: /Doors/Create
        [Authorize(Roles = "Admin,Manager,Editor,TerritoryEditor")]
        public ActionResult Create(int TerritoryID)
        {
            int CongID = Common.IdentityExtensions.GetCongregationID(User);
            Territory terr = db.Territories.Single(x => x.Id == TerritoryID && x.CongregationID == CongID);


            List<Territory> terrs = new List<Territory>() { terr };

            ViewBag.TerritoryId = new SelectList(terrs, "Id", "TerritoryName");
            ViewBag.LanguageId = new SelectList(db.Languages.Where(l => !l.CongregationID.HasValue || l.CongregationID == CongID), "Id", "Description");
            ViewBag.DoorCodeId = new SelectList(db.DoorCodes.Where(x => x.CongregationID == CongID), "Id", "Description");
            ViewBag.City = db.Territories.Find(TerritoryID).City;
            return View();
        }

        // POST: /Doors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,Manager,Editor,TerritoryEditor")]
        public ActionResult Create([Bind("Id,TerritoryID,Address,Street,Apartment,LanguageID,Comments,Name,Telephone,PostalCode,CodeID,GeoLat,GeoLong")] Door door)
        {
            if (ModelState.IsValid)
            {
                door.Added = DateTime.Now;
                door.AddedBy = User.Identity.Name;
                door.Modified = DateTime.Now;
                door.ModifiedBy = User.Identity.Name;

                db.Doors.Add(door);
                db.SaveChanges();
                return RedirectToAction("Index", new { TerritoryID = door.TerritoryId });
            }

            int CongID = Common.IdentityExtensions.GetCongregationID(User);
            ViewBag.TerritoryId = new SelectList(db.Territories.Where(x => x.CongregationID == CongID), "Id", "TerritoryName", door.TerritoryId);
            ViewBag.LanguageId = new SelectList(db.Languages.Where(l => !l.CongregationID.HasValue || l.CongregationID == CongID), "Id", "Description", door.LanguageId);
            ViewBag.DoorCodeId = new SelectList(db.DoorCodes.Where(x => x.CongregationID == CongID), "Id", "Description");
            return View(door);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,Manager,Editor,TerritoryEditor")]
        public JsonResult InlineEdit([Bind("Id,TerritoryID,Address,Street,Apartment,LanguageID,Comments,Name,Telephone,PostalCode,CodeID,GeoLat,GeoLong")] Door door)
        {
            if (ModelState.IsValid)
            {
                Door d = db.Doors.Find(door.Id);
                //d.TerritoryID = door.TerritoryID;
                d.Address = door.Address;
                d.Street = door.Street;
                d.Apartment = door.Apartment;
                d.LanguageId = door.LanguageId;
                d.Comments = door.Comments;
                d.Name = door.Name;
                d.Telephone = door.Telephone;
                d.PostalCode = door.PostalCode;
                d.DoorCodeId = door.DoorCodeId;
                d.GeoLat = door.GeoLat;
                d.GeoLong = door.GeoLong;
                d.Modified = DateTime.Now;
                d.ModifiedBy = User.Identity.Name;

                db.Entry(d).State = EntityState.Modified;
                db.SaveChanges();
                return Json("OK: Record Updated.");
            }
            return Json("FAILED: Record is not valid.");
        }

        [Authorize(Roles = "Admin,Manager,Editor,TerritoryEditor")]
        public JsonResult DeleteConfirmedJson(int id)
        {
            Door door = db.Doors.Find(id);
            int CongID = Common.IdentityExtensions.GetCongregationID(User);
            if (door.Territory.CongregationID == CongID)
            {
                db.Doors.Remove(door);
                db.SaveChanges();

                return Json("OK");
            }
            else
            {
                return null;
            }
        }

        public JsonResult GetDoorsData(int TerritoryID)
        {
            return Json((from d in db.Doors 
                            where d.TerritoryId == TerritoryID
                            orderby d.Street ascending, d.Address ascending, d.Apartment ascending
                            select new { 
                                d.Id, 
                                d.Address, 
                                d.Street, 
                                d.Apartment,
                                d.GeoLat, 
                                d.GeoLong, 
                                d.Territory.TerritoryName, 
                                d.Comments, 
                                d.Name, 
                                d.Telephone, 
                                Language = d.Language.Description}).ToList());
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
