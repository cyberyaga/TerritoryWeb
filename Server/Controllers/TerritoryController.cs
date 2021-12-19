using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TerritoryWeb.Server.Data;
using TerritoryWeb.Shared.Territory;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using static TerritoryWeb.Shared.Territory.TerritoryDetails;
using TerritoryWeb.Server.Models;

namespace TerritoryWebPWA.Server.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("[controller]")]
    public class TerritoryController : ControllerBase
    {
        private readonly ILogger<TerritoryController> logger;
        private readonly ApplicationDbContext db;
        public TerritoryController(ILogger<TerritoryController> logger, ApplicationDbContext context)
        {
            this.logger = logger;
            db = context;
        }

        [HttpGet("GetTerritories")]
        public IEnumerable<TerritoryIndexView> GetTerritories()
        {
            var ter =
                from t in db.Territories
                select new TerritoryIndexView()
                {
                    TerritoryId = t.Id,
                    TerritoryName = t.TerritoryName,
                    City = t.City,
                    TerritoryType = t.TerritoryType != null ? t.TerritoryType.Description : null,
                    DoorCount = t.Doors != null ? t.Doors.Count : 0
                };

            return ter;
        }

        [HttpGet("GetTerritoryDetails/{TerritoryId}")]
        public TerritoryDetails GetTerritoryDetails(int TerritoryId)
        {
            TerritoryDetails tds = new TerritoryDetails();

            var td =
                (from t in db.Territories.Include(tb => tb.TerritoryBounds).Include(d => d.Doors)
                 where t.Id == TerritoryId
                 select t).SingleOrDefault();

            if (td != null)
            {
                tds = new TerritoryDetails()
                {
                    Id = td.Id,
                    TerritoryName = td.TerritoryName,
                    City = td.City,
                    TerritoryTypeStr = td.TerritoryType != null ? td.TerritoryType.Description : "",
                    Notes = td.Notes,
                    DoorCount = td.Doors != null ? td.Doors.Count : 0,
                    //AssignedPublisher = t.
                    CheckedOut = td.CheckedOut,
                    CheckedIn = td.CheckedIn,
                    LastCheckedInBy = td.LastCheckedInBy,
                    TerritoryBounds = new List<TerritoryDetails.TerritoryBound>()
                };


                //TerritoryBounds
                if (td.TerritoryBounds != null)
                {
                    foreach (var tb in td.TerritoryBounds)
                    {
                        tds.TerritoryBounds.Add(new TerritoryDetails.TerritoryBound() { GeoLat = decimal.ToDouble(tb.GeoLat), GeoLong = decimal.ToDouble(tb.GeoLong) });
                    }
                }
            }

            return tds;
        }

        [HttpGet("GetTerritoryCreate")]
        public async Task<TerritoryCreateView> GetTerritoryCreate()
        {
            var ts = from t in db.TerritoryTypes
                     select new TerritoryWeb.Shared.Territory.TerritoryType()
                     {
                         TerritoryTypeId = t.Id,
                         TerritoryTypeDescription = t.Description
                     };

            TerritoryCreateView tcv = new TerritoryCreateView();
            tcv.TerritoryTypes = await ts.ToListAsync();
            return tcv;
        }

        [HttpPost]
        public async Task<IActionResult> Post(NewTerritoryBase terr)
        {
            try
            {
                var t = new Territory()
                {
                    TerritoryName = terr.TerritoryName,
                    City = terr.City,
                    Notes = terr.Notes,
                    Type = 1,
                    CongregationID = 1,
                    AddedBy = "cyberyaga@hotmail.com",
                    Added = DateTime.Now,
                    ModifiedBy = "cyberyaga@hotmail.com",
                    Modified = DateTime.Now
                };

                db.Territories.Add(t);

                var result = await db.SaveChangesAsync();

                return Ok(ModelState);
            }
            catch (System.Exception ex)
            {
                logger.LogError("Validation Error: {Message}", ex.Message);
            }

            return BadRequest(ModelState);
        }
    }
}