using Wasla.DTOs;
using Wasla.Models;

namespace Wasla.Services
{
    public interface IAdminService
    {
        Task<List<GovernmentDTO>> GetGovernments();
        Task AddGovernment(string governmentName);
        Task UpdateGovernment(GovernmentDTO government);
        Task DeleteGovernment(string governmentId);

        Task<List<RegionDTO>> GetRegions(string governmentId);
        Task AddRegion(string governmentId, string regionName);
        Task UpdateRegion(string regionId, string regionName);
        Task DeleteRegion(string regionid);

        Task<List<AvailableRegionDTO>> GetAvailableRegions(string regionid);
        Task AddAvailableRegion(string regionId, string AvailableRegionname, string AvailableRegionDescription);
        Task UpdateAvailableRegion(string availableRegionId, string AvailableRegionname, string AvailableRegionDescription);
        Task DeleteAvailableRegion(string availableRegionid);


    }
}
