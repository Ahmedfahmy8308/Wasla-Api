using Microsoft.AspNetCore.Mvc;
using Wasla.Services;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using Wasla.DTOs;
namespace Wasla.Controllers

{
    [ApiController]
    [Route("api/user")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [Route("governments")]
        public async Task<IActionResult> GetGovernments()
        {
            try
            {
                List<GovernmentDTO> governmentDTOs = await _userService.GetGovernments();
                return Ok(governmentDTOs);
            }
            catch (System.Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("Government/Search/{word}")]
        public async Task<IActionResult> SearchInGovernment(string word)
        {
            try
            {
                List<GovernmentDTO> governmentDTOs = await _userService.SearchInGovernment(word);
                return Ok(governmentDTOs);
            }
            catch (System.Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("regions/{governmentId}")]
        public async Task<IActionResult> GetRegions(string governmentId)
        {
            try
            {
                List<RegionDTO> regionDTOs = await _userService.GetRegions(governmentId);
                return Ok(regionDTOs);
            }
            catch (System.Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("Region/Search/{word}")]
        public async Task<IActionResult> SearchInRegion(string word)
        {
            try
            {
                List<RegionDTO> regionDTOs = await _userService.SearchInRegion(word);
                return Ok(regionDTOs);
            }
            catch (System.Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpGet]
        [Route("availableRegions/{regionId}")]
        public async Task<IActionResult> GetAvailableRegions(string regionId)
        {
            try
            {
                List<AvailableRegionDTO> availableRegionDTOs = await _userService.GetAvailableRegions(regionId);
                return Ok(availableRegionDTOs);
            }
            catch (System.Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpGet]
        [Route("AvailableRegion/Search/{word}")]
        public async Task<IActionResult> SearchInAvailableRegion(string word)
        {
            try
            {
                List<AvailableRegionDTO> availableRegionDTOs = await _userService.SearchInAvailableRegion(word);
                return Ok(availableRegionDTOs);
            }
            catch (System.Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        
    }
}