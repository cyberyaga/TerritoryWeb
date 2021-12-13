using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TerritoryWeb.Server.Data;
using TerritoryWeb.Shared.Territory;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using static TerritoryWeb.Shared.Territory.TerritoryDetails;

namespace TerritoryWebPWA.Server.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("[controller]")]
    public class TerritoryController : ControllerBase
    {
        private readonly ApplicationDbContext db;
        public TerritoryController(ApplicationDbContext context)
        {
            db = context;
        }


        [HttpGet("GetTerritories")]
        public IEnumerable<TerritoryIndexView> GetTerritories()
        {
            var ter = 
                from t in db.Territories
                select new TerritoryIndexView() {
                    TerritoryId = t.Id,
                    TerritoryName = t.TerritoryName,
                    City = t.City,
                    TerritoryType = t.TerritoryType.Description,
                    DoorCount = t.Doors.Count                    
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
                    DoorCount = td.Doors.Count,
                    //AssignedPublisher = t.
                    CheckedOut = td.CheckedOut,
                    CheckedIn = td.CheckedIn,
                    LastCheckedInBy = td.LastCheckedInBy,
                    TerritoryBounds = new List<TerritoryBound>()
                };

                //TerritoryBounds
                foreach (var tb in td.TerritoryBounds)
                {
                    tds.TerritoryBounds.Add(new TerritoryBound() { GeoLat = decimal.ToDouble(tb.GeoLat), GeoLong = decimal.ToDouble(tb.GeoLong) });
                }
            }

            return tds;
        }
    }
}