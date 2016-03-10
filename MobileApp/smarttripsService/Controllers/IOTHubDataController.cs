﻿using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.OData;
using Microsoft.Azure.Mobile.Server;
using MyTrips.DataObjects;
using smarttripsService.Models;

namespace smarttripsService.Controllers
{
    public class IOTHubDataController : TableController<IOTHubData>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            smarttripsContext context = new smarttripsContext();
            DomainManager = new EntityDomainManager<IOTHubData>(context, Request);
        }

        // GET tables/IOTHubData
        public IQueryable<IOTHubData> GetAllIOTHubData()
        {
            return Query(); 
        }

        // GET tables/IOTHubData/<id>
        public SingleResult<IOTHubData> GetIOTHubData(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/IOTHubData/<id>
        public Task<IOTHubData> PatchIOTHubData(string id, Delta<IOTHubData> patch)
        {
             return UpdateAsync(id, patch);
        }

        // POST tables/IOTHubData
        public async Task<IHttpActionResult> PostIOTHubData(IOTHubData item)
        {
            IOTHubData current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/IOTHubData/<id>
        public Task DeleteIOTHubData(string id)
        {
             return DeleteAsync(id);
        }
    }
}
