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
using System.Web.Http.Cors;

namespace ProjectMono.WebAPI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class VehicleMakeController : ApiController
    {
        protected IVehicleMakeService service;
        public VehicleMakeController(IVehicleMakeService service)
        {
            this.service = service;
        }

        [HttpGet]
        /// <summary>
        /// Get method,
        /// /api/VehicleMake/?page=&pagesize=5&search=&sort=&direction=
        /// </summary>
        /// <param name="page">Current page</param>
        /// <param name="pagesize">Page size, if page size is not given it's set to 0</param>
        /// <param name="search">Search</param>
        /// <param name="sort">Sort by Name or Abrv</param>
        /// <param name="direction">Sort direction it can be ascending or descending</param>
        /// <returns>Returns a list of VehicleMakeVM</returns>
        public async Task<IHttpActionResult> Get(int? page,int? pagesize, string search, string sort, string direction)
        {
            var sortParameters = new SortParameters()
            {
                Sort = sort,
                SortDirection = direction ?? "Descending"
            };
            var filterParameters = new FilterParameters()
            {
                Search = search
            };
            var pageParameters = new PageParameters()
            {
                Page = page ?? 1,
                /*I set the page size to 0, because as you can see in VehicleMakeService when page size is set to 0 it skips pagging. 
                 * Because in one case I need to get all of thevehicle makes. 
                 * Example is in angular part when I need to get all VehicleMakes when I'm creating a new VehicleModel, 
                 * it needs VehicleMakeId to be created. 
                 * So a drop down menu with all Vehicle Makes can be created from which VehicleMakeId can be chosen from.
                */
                PageSize = pagesize ?? 0
            };
            var vehicleMakeListPaged = AutoMapper.Mapper.Map<IPagedResult<VehicleMakeVM>>(await service.GetVehicleMakesAsync(sortParameters, filterParameters, pageParameters));
            return Ok(vehicleMakeListPaged);
        }

        /// <summary>
        /// Get method,
        /// api/VehicleMake/5
        /// </summary>
        /// <param name="id">VehicleMake Id</param>
        /// <returns>Returns a single VehicleMakeVM</returns>
        [HttpGet]
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

        /// <summary>
        /// Post method,
        /// api/VehicleMake
        /// </summary>
        /// <param name="VM">View Model, type of VehicleMakeVM</param>
        [HttpPost]
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

        /// <summary>
        /// Put method,
        /// api/VehicleMake/5
        /// </summary>
        /// <param name="id">VehicleMake Id, type of int</param>
        /// <param name="VM">View Model, type of VehicleMakeVM</param>
        [HttpPut]
        public async Task<IHttpActionResult> Put(int? id, [FromBody]VehicleMakeVM VM)
        {
            try
            {
                if (id == null)
                {
                    return BadRequest();
                }           
                var success = await service.UpdateVehicleMakeAsync(AutoMapper.Mapper.Map<IVehicleMake>(VM));
                if (!success)
                {
                    return BadRequest();
                }
                return Ok();
            }
            catch
            {
                ModelState.AddModelError("", "Something went wrong can't update VehicleMake");
                return InternalServerError();
            }
        }

        /// <summary>
        /// Delete method,
        /// api/VehicleMake/5
        /// </summary>
        /// <param name="id">VehicleMake Id, type of int</param>
        [HttpDelete]
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
                    var success = await service.DeleteVehicleMakeAsync((int)id);
                    if (!success)
                    {
                        return NotFound();
                    }
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
