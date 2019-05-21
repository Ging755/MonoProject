using ProjectMono.Common.PagedResultCommon;
using ProjectMono.Common.Parameters;
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

namespace ProjectMono.WebAPI.Controllers
{
    public class VehicleMakeController : ApiController
    {
        protected IVehicleMakeService service;
        public VehicleMakeController(IVehicleMakeService service)
        {
            this.service = service;
        }
        [HttpGet]
        // GET: api/VehicleMake
        public async Task<IHttpActionResult> Get(int? page, string search, string sort, string direction)
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
                PageSize = 5
            };
            var vehicleMakeList = AutoMapper.Mapper.Map<IPagedResult<VehicleMakeVM>>(await service.GetVehicleMakesAsync(sortParameters, filterParameters, pageParameters));
            return Ok(vehicleMakeList);
        }

        [HttpGet]
        // GET: api/VehicleMake/5
        public async Task<IHttpActionResult> Get(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            else
            {
                var VehicleMake = AutoMapper.Mapper.Map<VehicleMakeVM>(await service.GetVehicleMakeAsync((int)id));
                if (VehicleMake == null)
                {
                    return NotFound();
                }
                return Ok(VehicleMake);
            }
        }

        [HttpPost]
        // POST: api/VehicleMake
        public async Task<IHttpActionResult> Post([FromBody]VehicleMakeVM VM)
        {
            try
            {
                await service.AddVehicleMakeAsync(AutoMapper.Mapper.Map<VehicleMake>(VM));
                return Ok();
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Something went wrong with creating VehicleMake");
                return InternalServerError();
            }
        }

        [HttpPut]
        // PUT: api/VehicleMake/5
        public async Task<IHttpActionResult> Put(int? id, [FromBody]VehicleMakeVM VM)
        {
            try
            {
                if (id == null)
                {
                    return BadRequest();
                }
                if (service.GetVehicleMakeAsync((int)id) == null)
                {
                    return BadRequest();
                }
                await service.UpdateVehicleMakeAsync(AutoMapper.Mapper.Map<IVehicleMake>(VM));
                return Ok();
            }
            catch
            {
                ModelState.AddModelError("", "Something went wrong can't update VehicleMake");
                return InternalServerError();
            }
        }

        [HttpDelete]
        // DELETE: api/VehicleMake/5
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
                    if (await service.GetVehicleMakeAsync((int)id) == null)
                    {
                        return BadRequest();
                    }
                    await service.DeleteVehicleMakeAsync(await service.GetVehicleMakeAsync((int)id));
                    return Ok();
                }
            }
            catch
            {
                ModelState.AddModelError("", "Something went wrong can't update VehicleMake");
                return InternalServerError();
            }
        }
    }
}
