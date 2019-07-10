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


    public class VehicleModelController : ApiController
    {

        protected IVehicleModelService service;
        public VehicleModelController(IVehicleModelService service)
        {
            this.service = service;
        }

        /// <summary>
        /// Get method,
        /// /api/VehicleModel/?page=&pagesize=5&search=&sort=&direction=&makeid=
        /// </summary>
        /// <param name="page">Current page</param>
        /// <param name="pagesize">Page size, if page size is not given it's set to 0</param>
        /// <param name="search">Search</param>
        /// <param name="sort">Sort by Name or Abrv</param>
        /// <param name="direction">Sort direction it can be ascending or descending</param>
        /// <returns>Returns a list of VehicleModelVM</returns>
        [HttpGet]
        public async Task<IHttpActionResult> Get(int? page, int? pagesize, string search, string sort, string direction, int? makeid)
        {
            var sortParameters = new SortParameters()
            {
                Sort = sort,
                SortDirection = direction ?? "Descending"
            };
            var filterParameters = new FilterParameters()
            {
                Search = search,
                VehicleMakeId = makeid
            };
            var pageParameters = new PageParameters()
            {
                Page = page ?? 1,
                PageSize = pagesize ?? 5
            };
            var vehicleModelListPaged = AutoMapper.Mapper.Map<IPagedResult<VehicleModelVM>>(await service.GetVehicleModelsAsync(sortParameters, filterParameters, pageParameters));
            return Ok(vehicleModelListPaged);
        }

        /// <summary>
        /// Get method,
        /// api/VehicleModel/5
        /// </summary>
        /// <param name="id">VehicleModel Id</param>
        /// <returns>Returns a single VehicleModelVM</returns>
        [HttpGet]
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
        /// <summary>
        /// Post method,
        /// api/VehicleModel
        /// </summary>
        /// <param name="VM">View Model, type of VehicleModelVM</param>
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

        /// <summary>
        /// Put method,
        /// api/VehicleModel/5
        /// </summary>
        /// <param name="id">VehicleModel Id, type of int</param>
        /// <param name="VM">View Model, type of VehicleModelVM</param>
        [HttpPut]
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

        /// <summary>
        /// Delete method,
        /// api/VehicleModel/5
        /// </summary>
        /// <param name="id">VehicleModel Id, type of int</param>
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
                    var success = await service.DeleteVehicleModelAsync((int) id);
                    if (!success)
                    {
                        return NotFound();
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
