using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using TerritoryWeb;
using TerritoryWeb.Models;
using System.Threading.Tasks;
using TerritoryWeb.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace TerritoryWeb.Controllers
{
    public class TerritoryController : Controller
    {
        private readonly ApplicationDbContext db;
        public TerritoryController(ApplicationDbContext context)
        {
            db = context;
        }

        // GET: /Territory/
        //[AuthLog(Roles = "Admin,TerritoryEditor,Editor,Manager,ReadOnly")]
        public ActionResult Index(string sortOrder)
        {
            int CongID = Common.IdentityExtensions.GetCongregationID(User);

            List<Territory> ts = new List<Territory>();

            ts = db.Territories.Where(x => x.CongregationID == CongID).ToList();

            //Limit territories
            string[] ViewAllGroups = { "TerritoryEditor", "Manager", "Admin" };
            bool LimitUser = true;

            for (int i = 0; i < ViewAllGroups.Length; i++)
            {
                if (User.IsInRole(ViewAllGroups[i]))
                {
                    LimitUser = false;
                    break;
                }
            }
/*
            if (LimitUser) //Limit what the user can see to assigned Territories
            {
                string UserId = "";//User.Identity.GetUserId();

                List<int> addTerr = db.TerritoryAccesses.Where(x => x.UserId == UserId).Select(s => s.TerritoryId).ToList();
                ts = ts.Where(x => x.AssignedPublisherId == UserId || addTerr.Contains(x.Id)).ToList();
            }*/
            return View(ts);
        }

        //[AuthLog(Roles = "Admin,Manager,TerritoryEditor,Editor,ReadOnly")]
        public ActionResult ViewTerritories()
        {
            int CongID = Common.IdentityExtensions.GetCongregationID(User);
            return View();
        }

        // GET: /Territory/Details/5
        //[AuthLog(Roles = "Admin,Manager,TerritoryEditor,Editor,ReadOnly")]
        public ActionResult Details(int? id)
        {
            int CongID = Common.IdentityExtensions.GetCongregationID(User);

            if (id == null)
            {
                return BadRequest();
            }

            //Make sure the territory is allowed
            //See if check in is allowed
            string CurrentUserId = "";//User.Identity.GetUserId();
            string[] ViewAllGroups = { "TerritoryEditor", "Manager", "Admin" };
            bool AllowCheckIn = false;

            for (int i = 0; i < ViewAllGroups.Length; i++)
            {
                if (User.IsInRole(ViewAllGroups[i]))
                {
                    AllowCheckIn = true;
                    break;
                }
            }

            List<int> addTerr = db.TerritoryAccesses.Where(x => x.UserId == CurrentUserId).Select(s => s.TerritoryId).ToList();

            Territory territory = db.Territories.Find(id);
            if (territory == null //Not Found
                || (territory != null && territory.CongregationID != CongID) //Not part of the congregation
                || !(AllowCheckIn || addTerr.Contains(territory.Id) || territory.AssignedPublisherId == CurrentUserId))//Not allowed
            {
                //return NotFound();
            }

            //Print if Records in Doors
            ViewBag.PrintEnabled = (territory.Doors.Count > 0 ? "" : "disabled=\"disabled\"");




            ViewBag.AllowCheckin = (AllowCheckIn || CurrentUserId == territory.AssignedPublisherId) ? "" : "disabled=\"disabled\"";
            ViewBag.AllowPerm = AllowCheckIn ? "" : "disabled";

            return View(territory);
        }

        // GET: /Territory/Create
        //[AuthLog(Roles = "Admin,Manager")]
        public ActionResult Create()
        {
            ViewBag.TerritoryTypes = new SelectList(db.TerritoryTypes, "Id", "Description");
            return View();
        }

        // POST: /Territory/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //[AuthLog(Roles = "Admin,Manager")]
        public ActionResult Create([Bind("Id,TerritoryName,City,Type,Notes")] Territory territory, bool createfromgeo, string mapdata = "")
        {
            if (ModelState.IsValid)
            {
                territory.CongregationID = Common.IdentityExtensions.GetCongregationID(User);
                territory.AddedBy = User.Identity.Name;
                territory.Added = DateTime.Now;
                territory.ModifiedBy = User.Identity.Name;
                territory.Modified = DateTime.Now;
                db.Territories.Add(territory);
                db.SaveChanges();

                //if boundaries are present, add
                if (mapdata != "")
                {
                    PointF[] Poly = ParsePolygon(mapdata); //Parse points
                    for (int i = 0; i < Poly.Length; i++)
                    {
                        TerritoryBound t = new TerritoryBound();
                        t.GeoLat = decimal.Parse(Poly[i].X.ToString());
                        t.GeoLong = decimal.Parse(Poly[i].Y.ToString());
                        territory.TerritoryBounds.Add(t); //add to bounds
                    }
                    db.SaveChanges(); //Submit data.
                }


                if (createfromgeo)
                {
                    PointF[] Poly = ParsePolygon(mapdata);
                    List<PointF> points = MapPoints(Poly);

                    List<Door> doors = new List<Door>();
                    
                    //Reverse Geocode
                    foreach (PointF loc in points)
                    {
                        Door d = ReverseGeocodeToDoor(loc);

                        if (d != null && !doors.Any(x => x.Address == d.Address && x.Street == d.Street))
                        {
                            d.TerritoryId = territory.Id;
                            d.AddedBy = User.Identity.Name;
                            d.Added = DateTime.Now;
                            d.ModifiedBy = User.Identity.Name;
                            d.Modified = DateTime.Now;
                            doors.Add(d);
                        }
                    }

                    if (doors.Count > 0)
                    {
                        db.Doors.AddRange(doors);
                        db.SaveChanges();
                    }
                }


                return RedirectToAction("Details", new { id = territory.Id });
            }

            return View(territory);
        }

        // GET: /Territory/Edit/5
        //[AuthLog(Roles = "Admin,Manager")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            Territory territory = db.Territories.Find(id);
            if (territory == null || (territory != null && territory.CongregationID != Common.IdentityExtensions.GetCongregationID(User)))
            {
                return NotFound();
            }
            ViewBag.TerritoryTypes = new SelectList(db.TerritoryTypes, "Id", "Description", territory.TerritoryTypeId);
            return View(territory);
        }

        // POST: /Territory/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //[AuthLog(Roles = "Admin,Manager")]
        public ActionResult Edit([Bind("Id,TerritoryName,City,Type,Notes")] Territory territory, string mapdata = "")
        {
            if (ModelState.IsValid)
            {
                Territory t = db.Territories.Find(territory.Id);
                t.Id = territory.Id;
                t.TerritoryName = territory.TerritoryName;
                t.City = territory.City;
                t.TerritoryTypeId = territory.TerritoryTypeId;
                t.Notes = territory.Notes;

                t.ModifiedBy = User.Identity.Name;
                t.Modified = DateTime.Now;
                db.Entry(t).State = EntityState.Modified;
                db.SaveChanges();

                //if boundaries are present, add
                if (mapdata != "")
                {
                    //Remove previous bounds
                    db.TerritoryBounds.RemoveRange(t.TerritoryBounds);

                    //Add new
                    PointF[] Poly = ParsePolygon(mapdata); //Parse points
                    for (int i = 0; i < Poly.Length; i++)
                    {
                        TerritoryBound tb = new TerritoryBound();
                        tb.GeoLat = decimal.Parse(Poly[i].X.ToString());
                        tb.GeoLong = decimal.Parse(Poly[i].Y.ToString());
                        t.TerritoryBounds.Add(tb); //add to bounds
                    }
                    db.SaveChanges(); //Submit data.
                }

                return RedirectToAction("Details", new { id = t.Id });
            }
            ViewBag.TerritoryTypes = new SelectList(db.TerritoryTypes, "Id", "Description", territory.TerritoryTypeId);
            return View(territory);
        }

        // GET: /Territory/Delete/5
        //[AuthLog(Roles = "Admin,Manager")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            Territory territory = db.Territories.Find(id);
            if (territory == null || (territory != null && territory.CongregationID != Common.IdentityExtensions.GetCongregationID(User)))
            {
                return NotFound();
            }
            return View(territory);
        }

        // POST: /Territory/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        //[AuthLog(Roles = "Admin,Manager")]
        public ActionResult DeleteConfirmed(int id)
        {
            Territory territory = db.Territories.Find(id);
            db.Territories.Remove(territory);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //[AuthLog(Roles = "Admin,Manager")]
        public JsonResult DeleteConfirmedJson(int id)
        {
            Territory territory = db.Territories.Find(id);
            if (territory.CongregationID == Common.IdentityExtensions.GetCongregationID(User))
            {
                //Delete doors
                if (territory.Doors.Count > 0)
                {
                    db.Doors.RemoveRange(territory.Doors);
                }

                //Delete Bounds
                if (territory.TerritoryBounds.Count > 0)
                {
                    db.TerritoryBounds.RemoveRange(territory.TerritoryBounds);
                }

                db.Territories.Remove(territory);
                db.SaveChanges();
                return Json("Ok");
            }
            else
            {
                return null;
            }
        }

        //[AuthLog(Roles = "Admin,Manager,TerritoryEditor")]
        public JsonResult CheckOutTerritory(int TerritoryID, string PublisherID)
        {
            if (TerritoryID == 0 || string.IsNullOrWhiteSpace(PublisherID))
            {
                return null;
            }

            // AspNetUser p = db.AspNetUsers.SingleOrDefault(x => x.Id == PublisherID);
            // if (p == null)
            // {
            //     return null;
            // }

            Territory t = db.Territories.Find(TerritoryID);
            if (t.CongregationID != Common.IdentityExtensions.GetCongregationID(User))
            {
                return null;
            }

            t.CheckedIn = null;
            t.LastCheckedInBy = null;
            t.CheckedOut = DateTime.Now;
            t.AssignedPublisherId = PublisherID;
            db.SaveChanges();

            //Send Email
            //ApplicationUserManager UserManager = Request.GetOwinContext().GetUserManager<ApplicationUserManager>();
            string TerritoryURL = Url.Action("Details", "Territory", new { id = TerritoryID }, Request.Scheme);
            string body = "You have been assigned a new territory.\r\n\r\nTo View it, please click this link:\r\n " + TerritoryURL;
            //UserManager.SendEmail(PublisherID, "Territory Assigned", body);


            return Json("Ok");
        }

        //[AuthLog(Roles = "Admin,Manager,Editor,TerritoryEditor")]
        public JsonResult CheckInTerritory(int TerritoryID)
        {
            if (TerritoryID == 0)
            {
                return null;
            }

            Territory t = db.Territories.Find(TerritoryID);
            if (t.CongregationID != Common.IdentityExtensions.GetCongregationID(User))
            {
                return null;
            }

            //Remove Temp Permissions
            var tmpPerm = db.TerritoryAccesses.Where(x => x.TerritoryId == TerritoryID && x.TempAccess);
            db.TerritoryAccesses.RemoveRange(tmpPerm);

            t.AssignedPublisherId = null;
            t.CheckedOut = null;
            t.CheckedIn = DateTime.Now;
            t.LastCheckedInById = "";//User.Identity.GetUserId();
            db.SaveChanges();
            return Json("Ok");
        }

        //[AuthLog(Roles = "Admin,Manager,Editor,TerritoryEditor")]
        public JsonResult GetListOfPublishers()
        {
            //TODO: Fix Count on query
            Dictionary<string, string> list = new Dictionary<string, string>();
            int CongID = Common.IdentityExtensions.GetCongregationID(User);
            // List<AspNetUser> plist = (from p in db.AspNetUsers.Include(d => d.Territories)
            //                          where p.CongregationID == CongID
            //                          orderby p.LastName ascending, p.FirstName ascending
            //                          select p).ToList();

            // plist.ForEach(x => list.Add(x.Id.ToString(), x.FullName + " (" + x.Territories.Count + ")"));

            return Json(list);
        }

        //[AuthLog(Roles = "Admin,Manager,TerritoryEditor,Editor,ReadOnly")]
        public JsonResult GetTerritoryCord(int TerritoryID)
        {

            int CongID = Common.IdentityExtensions.GetCongregationID(User);

            TerritoryCordinateIDModel tcord = new TerritoryCordinateIDModel();
            var dlist = (from d in db.Doors
                         where d.TerritoryId == TerritoryID && d.GeoLat != null && d.GeoLong != null && d.Territory.CongregationID == CongID
                         orderby d.GeoLat ascending, d.GeoLong ascending
                         select new { d.Id, AddressFull = d.Address + " " + d.Street, d.GeoLat, d.GeoLong }).Distinct().ToList();

            //Get territory bounds
            List<TerritoryBound> tBound = db.TerritoryBounds.Where(x => x.TerritoryId == TerritoryID).ToList();

            //Add Doors to model
            dlist.ForEach(x => tcord.DoorCoordinates.Add(new TerritoryCordinateIDModel.DoorIDModel() { DoorID = x.Id, Address = x.AddressFull, Coordinates = new PointF((float)x.GeoLat, (float)x.GeoLong) }));

            //Add Bounds to model
            tBound.ForEach(x => tcord.HullCoordinates.Add(new PointF((float)x.GeoLat, (float)x.GeoLong)));

            return Json(tcord); //Return Model
        }

        //[AuthLog(Roles = "Admin,Manager,TerritoryEditor,Editor,ReadOnly")]
        public JsonResult GetTerritories()
        {
            int CongID = Common.IdentityExtensions.GetCongregationID(User);

            List<TerritoryCordinateModel> tcord = new List<TerritoryCordinateModel>();
            
            var territories = db.Territories.Where(x => x.CongregationID == CongID).ToList();

            foreach (Territory ter in territories)
            {
                TerritoryCordinateModel t = new TerritoryCordinateModel();
                t.TerritoryID = ter.Id;
                t.TerritoryName = ter.TerritoryName;

                t.HullCoordinates = ter.TerritoryBounds.Select(s => new PointF((float)s.GeoLat, (float)s.GeoLong)).ToList();

                //Add Doors to model
                t.DoorCoordinates = ter.Doors.Select(s => new PointF((float)s.GeoLat, (float)s.GeoLong)).ToList();

                tcord.Add(t);
            }

            

           

            return Json(tcord); //Return Model
        }

        //[AuthLog(Roles = "Admin,Manager,TerritoryEditor,Editor,ReadOnly")]
        public JsonResult GetAllDoors()
        {
            int CongID = Common.IdentityExtensions.GetCongregationID(User);

            List<TerritoryCordinateModel> tcord = new List<TerritoryCordinateModel>();

            var territories = db.Territories.Where(x => x.CongregationID == CongID);

            foreach (Territory ter in territories)
            {
                TerritoryCordinateModel t = new TerritoryCordinateModel();
                t.TerritoryID = ter.Id;
                t.TerritoryName = ter.TerritoryName;

                t.HullCoordinates = ter.TerritoryBounds.Select(s => new PointF((float)s.GeoLat, (float)s.GeoLong)).ToList();

                tcord.Add(t);
            }

            return Json(tcord); //Return Model
        }

        //[AuthLog(Roles = "Admin,Manager,TerritoryEditor,Editor,ReadOnly")]
        public JsonResult GetTerritoryPermissions(int TerritoryId)
        {
            int CongID = Common.IdentityExtensions.GetCongregationID(User);

            var tmpaccess = GetPermissions(CongID, TerritoryId);

            return Json(tmpaccess); //Return Model
        }

        //[AuthLog(Roles = "Admin,Manager,TerritoryEditor,Editor")]
        public JsonResult AddTerritoryPermission(int TerritoryId, string UserId, bool AccessType)
        {
            int CongID = Common.IdentityExtensions.GetCongregationID(User);

            Territory t = db.Territories.SingleOrDefault(x => x.Id == TerritoryId && x.CongregationID == CongID);

            if (t != null)
            {
                //Check Access
                string[] ViewAllGroups = { "TerritoryEditor", "Manager", "Admin" };
                bool AllowPermanent = false;

                for (int i = 0; i < ViewAllGroups.Length; i++)
                {
                    if (User.IsInRole(ViewAllGroups[i]))
                    {
                        AllowPermanent = true;
                        break;
                    }
                }


                //Add Access
                var ta = new TerritoryAccess();

                ta.TerritoryId = t.Id;
                ta.UserId = UserId;
                ta.IsRead = false;
                ta.IsWrite = false;
                ta.TempAccess = AllowPermanent ? AccessType : true;

                db.TerritoryAccesses.Add(ta);
                db.SaveChanges();

            }

            var tmpaccess = GetPermissions(CongID, TerritoryId);

            return Json(tmpaccess); //Return Model
        }

        //[AuthLog(Roles = "Admin,Manager,TerritoryEditor,Editor")]
        public JsonResult RemoveTerritoryPermission(int TerritoryId, string UserId)
        {
            int CongID = Common.IdentityExtensions.GetCongregationID(User);

            //Remove
            var access = db.TerritoryAccesses.Where(x => x.UserId == UserId);
            db.TerritoryAccesses.RemoveRange(access);
            db.SaveChanges();

            var tmpaccess = GetPermissions(CongID, TerritoryId);

            return Json(tmpaccess); //Return Model
        }

        private List<TerritoryAccessModel> GetPermissions(int CongID, int TerritoryId)
        {
            List<TerritoryAccessModel> taccess = new List<TerritoryAccessModel>();

/*
            var tmpaccess = db.TerritoryAccesses.Include(d => d.AspNetUser).Where(x => x.TerritoryId == TerritoryId && x.Territory.CongregationID == CongID);

            foreach (var ta in tmpaccess)
            {
                var t = new TerritoryAccessModel();
                t.TerritoryId = ta.TerritoryId;
                t.UserId = ta.UserId;
                t.Name = ta.AspNetUser.FullName;
                t.IsReadOnly = ta.IsRead;
                t.IsWrite = ta.IsWrite;
                t.IsTempAccess = ta.TempAccess;

                taccess.Add(t);
            }
*/
            return taccess;
        }

        public async Task<JsonResult> GetTerritoriesMobile()
        {
            int CongID = 1; //TODO: Get rid of this.

            List<TerritoryWeb.Models.MobileModels.TerritoryListModel> tcord = new List<TerritoryWeb.Models.MobileModels.TerritoryListModel>();

            var territories = db.Territories.Where(x => x.CongregationID == CongID);

            await territories.ForEachAsync(x => tcord.Add(new Models.MobileModels.TerritoryListModel() { 
                TerritoryID = x.Id, 
                TerritoryName = x.TerritoryName,
                DoorCount = x.Doors.Count
            }));

            return Json(tcord); //Return Model
        }

        public async Task<JsonResult> GetTerritoryDetailsMobile(int TerritoryID)
        {
            int CongID = 1; //TODO: Get rid of this.

            List<TerritoryWeb.Models.MobileModels.TerritoryDetailsModel> tcord = new List<TerritoryWeb.Models.MobileModels.TerritoryDetailsModel>();

            var territories = db.Territories.Where(x => x.CongregationID == CongID && x.Id == TerritoryID);

            //Convert to model
            await territories.ForEachAsync(x => tcord.Add(new Models.MobileModels.TerritoryDetailsModel()
            { 
                TerritoryID = x.Id, 
                TerritoryName = x.TerritoryName,
                City = x.City,
                TerritoryType = x.TerritoryType.Description,
                AssignedPublisher = "",//x.AssignedUser.FullName,
                AssignedDate = x.CheckedOut,
                DoorCount = x.Doors.Count,
                HullCoordinates = x.TerritoryBounds.Select(s => new PointF((float)s.GeoLat, (float)s.GeoLong)).ToList()
            }));

            return Json(tcord); //Return Model
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Helper Functions
        private PointF[] ParsePolygon(string sPoly)
        {
            string[] sPolyArr = sPoly.Split(')');
            List<PointF> Poly = new List<PointF>();
            foreach (string xy in sPolyArr.AsEnumerable())
            {
                string cleanxy = xy.Replace("(", "");
                if (!string.IsNullOrWhiteSpace(cleanxy))
                {
                    string[] xyarr = cleanxy.Split(',');
                    float x;
                    float y;

                    if (xyarr.Length == 2 && float.TryParse(xyarr[0], out x) && float.TryParse(xyarr[1], out y))
                    {
                        PointF p = new PointF(x, y);
                        Poly.Add(p);
                    }
                }
            }
            return Poly.ToArray();
        }

        private List<PointF> MapPoints(PointF[] polygon)
        {
            List<PointF> PointList = new List<PointF>();

            //Get furthest dimentions
            float xplus = -1000;
            float xminus = 1000;
            float yplus = -1000;
            float yminus = 1000;
            foreach (PointF p in polygon.AsEnumerable())
            {
                xplus = (p.X > xplus) ? p.X : xplus;
                xminus = (p.X < xminus) ? p.X : xminus;
                yplus = (p.Y > yplus) ? p.Y : yplus;
                yminus = (p.Y < yminus) ? p.Y : yminus;
            }

            PointF CurrPoint = new PointF(xplus, yplus);
            float ScanRes = 0.00015F;

            while (CurrPoint.Y > yminus)
            {
                if (IsPointInPolygon(polygon, CurrPoint))
                {
                    PointList.Add(CurrPoint);
                }
                CurrPoint.X = CurrPoint.X - ScanRes;

                if (CurrPoint.X < xminus)
                {
                    CurrPoint.X = xplus;
                    CurrPoint.Y = CurrPoint.Y - ScanRes;
                }
            }

            return PointList;
        }

        private bool IsPointInPolygon(PointF[] polygon, PointF point)
        {
            bool isInside = false;
            for (int i = 0, j = polygon.Length - 1; i < polygon.Length; j = i++)
            {
                if (((polygon[i].Y > point.Y) != (polygon[j].Y > point.Y)) &&
                (point.X < (polygon[j].X - polygon[i].X) * (point.Y - polygon[i].Y) / (polygon[j].Y - polygon[i].Y) + polygon[i].X))
                {
                    isInside = !isInside;
                }
            }
            return isInside;
        }

        private Door ReverseGeocodeToDoor(PointF point)
        {
            return null;
            /*
            string coord = point.X.ToString() + "," + point.Y.ToString();

            var address = "https://maps.googleapis.com/maps/api/geocode/json?latlng=" + coord + "&key=" + Properties.Settings.Default.GoogleAPIKey;
            var result = new System.Net.WebClient().DownloadString(address);
            JavaScriptSerializer jss = new JavaScriptSerializer();
            var gogResult = jss.Deserialize<GoogleGeoCodeResponse>(result);

            if (gogResult.status == "OK" && gogResult.results.Count() > 0)// && gogResult.results[0].geometry.location_type == "ROOFTOP")
            {
                decimal Lat;
                decimal lng;

                decimal.TryParse(gogResult.results[0].geometry.location.lat, out Lat);
                decimal.TryParse(gogResult.results[0].geometry.location.lng, out lng);


                Door d = new Door();
                d.Address = gogResult.results[0].address_components[0].long_name;
                d.Street = gogResult.results[0].address_components[1].long_name;
                d.PostalCode = gogResult.results[0].address_components[7].long_name;
                d.GeoLat = Lat;
                d.GeoLong = lng;

                return d;
            }
            else
            {
                return null;
            }*/
        }
        #endregion
    }

}