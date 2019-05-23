using ProjectMono.Common.PagedResultCommon;
using ProjectMono.Common.Parameters;
using ProjectMono.DAL.Entities;
using ProjectMono.Model;
using ProjectMono.Model.Common;
using ProjectMono.Service.Common;
using ProjectMono.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;

namespace ProjectMono.WebAPI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]

    public class VehicleModelController : ApiController
    {

        protected IVehicleModelService service;
        public VehicleModelController(IVehicleModelService service)
        {
            this.service = service;
        }
        [HttpGet]
        // GET: api/VehicleModel
        public async Task<IHttpActionResult> Get(int? page, int? pagesize, string search, string sort, string direction, int? makeId)
        {
            var sortParameters = new SortParameters()
            {
                Sort = sort,
                SortDirection = direction
            };
            var filterParameters = new FilterParameters()
            {
                Search = search
            };
            var pageParameters = new PageParameters()
            {
                Page = page ?? 1,
                PageSize = pagesize ?? 5
            };
            if(makeId == null)
            {
                makeId = 0;
            }
            var vehicleModelListPaged = AutoMapper.Mapper.Map<IPagedResult<VehicleModelVM>>(await service.GetVehicleModelsAsync(sortParameters, filterParameters, pageParameters, makeId));
            return Ok(vehicleModelListPaged);
        }

        [HttpGet]
        // GET: api/VehicleModel/5
        public async Task<IHttpActionResult> Get(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            else
            {
                var VehicleModel = AutoMapper.Mapper.Map<VehicleModelVM>(await service.GetVehicleModelAsync((int)id));
                if (VehicleModel == null)
                {
                    return NotFound();
                }
                return Ok(VehicleModel);
            }
        }

        [HttpPost]
        // POST: api/VehicleModel
        public async Task<IHttpActionResult> Post([FromBody]VehicleModelVM VM)
        {
            try
            {
                await service.AddVehicleModelAsync(AutoMapper.Mapper.Map<IVehicleModel>(VM));
                return Ok();
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Something went wrong can't create VehicleModel");
                return InternalServerError();
            }
        }

        [HttpPut]
        // PUT: api/VehicleModel/5
        public async Task<IHttpActionResult> Put(int? id, [FromBody]VehicleModelVM VM)
        {
            try
            {
                if (id == null)
                {
                    return BadRequest();
                }
                var success = await service.UpdateVehicleModelAsync(AutoMapper.Mapper.Map<IVehicleModel>(VM));
                if(!success)
                {
                    return BadRequest();
                }
                return Ok();
            }
            catch
            {
                ModelState.AddModelError("", "Something went wrong can't update VehicleModel");
                return InternalServerError();
            }
        }

        [HttpDelete]
        // DELETE: api/VehicleModel/5
        public async Task<IHttpActionResult> Delete(int? id)
        {
            try
            {
                if (id == null)
                {
                    return BadRequest();
                }
                else
                {
                    var success = await service.DeleteVehicleModelAsync((int) id);
                    if (!success)
                    {
                        return BadRequest();
                    }
                    return Ok();
                }
            }
            catch
            {
                ModelState.AddModelError("", "Something went wrong can't update VehicleModel");
                return InternalServerError();
            }
        }
    }
}
