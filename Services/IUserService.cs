using System.Collections.Generic;
using System.Threading.Tasks;
using Wasla.DTOs;
using Wasla.Models;

namespace Wasla.Services
{
    public interface IUserService

    {
        Task<List<GovernmentDTO>> GetGovernments();
        Task<List<GovernmentDTO>> SearchInGovernment(string word);

        Task<List<RegionDTO>> GetRegions(string governmentId);
        Task<List<RegionDTO>> SearchInRegion(string word);
        Task<List<AvailableRegionDTO>> GetAvailableRegions(string regionId);
        Task<List<AvailableRegionDTO>> SearchInAvailableRegion(string word);

    }
}