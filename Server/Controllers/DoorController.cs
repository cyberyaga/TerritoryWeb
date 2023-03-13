using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TerritoryWeb.Shared.Door;
using System.Linq;
using TerritoryWeb.Data.Database;

namespace TerritoryWeb.Server.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("[controller]")]
    public class DoorController : ControllerBase
    {
        private readonly TerritoryWebDbContext db;
        public DoorController(TerritoryWebDbContext context)
        {
            db = context;
        }


        [HttpGet]
        public IEnumerable<DoorIndexView> Get()
        {
            var doors = 
                from d in db.Doors
                select new DoorIndexView() {
                    TerritoryId = d.TerritoryID,
                    Address = d.Address,
                    Street = d.Street,
                    Apartment = d.Apartment,
                    Comments = d.Comments,
                    Name = d.Name,
                    Telephone = d.Telephone,
                    Language = d.Language.Description
                };

            return doors;
        }
    }
}