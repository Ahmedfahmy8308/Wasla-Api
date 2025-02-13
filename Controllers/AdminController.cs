using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Wasla.DTOs;
using Wasla.Models;
using Wasla.Services;

namespace Wasla.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[ApiBearerAuth]
    [Authorize(Roles = "Admin")] 
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _adminService;
        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        [HttpGet]
        [Route("Government")]
        public async Task<IActionResult> Get()
        {
            try
            {
                List<GovernmentDTO> governmentDTOs = await _adminService.GetGovernments();
                return Ok(governmentDTOs);
            }
            catch (System.Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        [Route("Government")]
        public async Task<IActionResult> Post([FromBody] string governmentName)
        {
            try
            {
                await _adminService.AddGovernment(governmentName);
                return Ok("Government added successfully");
            }
            catch (System.Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut]
        [Route("Government")]
        public async Task<IActionResult> Put([FromBody] GovernmentDTO government)
        {
            try
            {
                await _adminService.UpdateGovernment(government);
                return Ok("Government updated successfully");
            }
            catch (System.Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete]
        [Route("Government")]
        public async Task<IActionResult> Delete([FromBody] string governmentId)
        {
            try
            {
                await _adminService.DeleteGovernment(governmentId);
                return Ok("Government deleted successfully");
            }
            catch (System.Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("Region")]
        public async Task<IActionResult> GetRegions(string governmentId)
        {
            try
            {
                List<RegionDTO> regionDTOs = await _adminService.GetRegions(governmentId);
                return Ok(regionDTOs);
            }
            catch (System.Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        [Route("Region")]
        public async Task<IActionResult> PostRegion([FromBody] AddRegionDTO region)
        {
            try
            {
                await _adminService.AddRegion(region.GovernmentId, region.Name);
                return Ok("Region added successfully");
            }
            catch (System.Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut]
        [Route("Region")]
        public async Task<IActionResult> PutRegion([FromBody] RegionDTO region)
        {
            try
            {
                await _adminService.UpdateRegion(region.Id, region.Name);
                return Ok("Region updated successfully");
            }
            catch (System.Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete]
        [Route("Region")]
        public async Task<IActionResult> DeleteRegion([FromBody] string regionId)
        {
            try
            {
                await _adminService.DeleteRegion(regionId);
                return Ok("Region deleted successfully");
            }
            catch (System.Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("AvailableRegion")]
        public async Task<IActionResult> GetAvailableRegions(string regionId)
        {
            try
            {
                List<AvailableRegionDTO> availableRegionDTOs = await _adminService.GetAvailableRegions(regionId);
                return Ok(availableRegionDTOs);
            }
            catch (System.Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        [Route("AvailableRegion")]
        public async Task<IActionResult> PostAvailableRegion([FromBody] AddAvailableRegionDTO availableRegion)
        {
            try
            {
                await _adminService.AddAvailableRegion(availableRegion.regionId, availableRegion.Name, availableRegion.description);
                return Ok("Available Region added successfully");
            }
            catch (System.Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut]
        [Route("AvailableRegion")]
        public async Task<IActionResult> PutAvailableRegion([FromBody] AvailableRegionDTO availableRegion)
        {
            try
            {
                await _adminService.UpdateAvailableRegion(availableRegion.Id, availableRegion.Name, availableRegion.Description);
                return Ok("Available Region updated successfully");
            }
            catch (System.Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete]
        [Route("AvailableRegion")]
        public async Task<IActionResult> DeleteAvailableRegion([FromBody] string availableRegionId)
        {
            try
            {
                await _adminService.DeleteAvailableRegion(availableRegionId);
                return Ok("Available Region deleted successfully");
            }
            catch (System.Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
