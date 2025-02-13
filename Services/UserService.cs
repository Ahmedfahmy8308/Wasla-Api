using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Wasla.Data;
using Wasla.DTOs;
using Wasla.Models;

namespace Wasla.Services
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _context;

        public UserService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<GovernmentDTO>> GetGovernments()
        {
            List<GovernmentDTO> governmentDTOs = new List<GovernmentDTO>();
            List<Government> governments = await _context.Governments.ToListAsync();
            foreach (Government government in governments)
            {
                governmentDTOs.Add(new GovernmentDTO
                {
                    Id = government.Id,
                    Name = government.Name,
                });
            }
            return governmentDTOs;
        }

        public async Task<List<GovernmentDTO>> SearchInGovernment(string word)
        {
            List<GovernmentDTO> governmentDTOs = new List<GovernmentDTO>();
            List<Government> governments = await _context.Governments.Where(g => g.Name.Contains(word)).ToListAsync();
            foreach (Government government in governments)
            {
                governmentDTOs.Add(new GovernmentDTO
                {
                    Id = government.Id,
                    Name = government.Name,
                });
            }
            return governmentDTOs;
        }

        public async Task<List<RegionDTO>> GetRegions(string governmentId)
        {
            List<RegionDTO> regionDTOs = new List<RegionDTO>();
            List<Region> regions = await _context.Regions.Where(r => r.GovernmentId == governmentId).ToListAsync();
            foreach (Region region in regions)
            {
                regionDTOs.Add(new RegionDTO
                {
                    Id = region.Id,
                    Name = region.Name,
                });
            }
            return regionDTOs;
        }

        public async Task<List<RegionDTO>> SearchInRegion(string word)
        {
            List<RegionDTO> regionDTOs = new List<RegionDTO>();
            List<Region> regions = await _context.Regions.Where(r => r.Name.Contains(word)).ToListAsync();
            foreach (Region region in regions)
            {
                regionDTOs.Add(new RegionDTO
                {
                    Id = region.Id,
                    Name = region.Name,
                });
            }
            return regionDTOs;
        }

        public async Task<List<AvailableRegionDTO>> GetAvailableRegions(string regionId)
        {
            List<AvailableRegionDTO> availableRegionDTOs = new List<AvailableRegionDTO>();
            List<AvailableRegion> availableRegions = await _context.AvailableRegions.Where(ar => ar.RegionId == regionId).ToListAsync();
            foreach (AvailableRegion availableRegion in availableRegions)
            {
                availableRegionDTOs.Add(new AvailableRegionDTO
                {
                    Id = availableRegion.Id,
                    Name = availableRegion.Name,
                });
            }
            return availableRegionDTOs;
        }

        public async Task<List<AvailableRegionDTO>> SearchInAvailableRegion(string word)
        {
            List<AvailableRegionDTO> availableRegionDTOs = new List<AvailableRegionDTO>();
            List<AvailableRegion> availableRegions = await _context.AvailableRegions.Where(ar => ar.Name.Contains(word)).ToListAsync();
            foreach (AvailableRegion availableRegion in availableRegions)
            {
                availableRegionDTOs.Add(new AvailableRegionDTO
                {
                    Id = availableRegion.Id,
                    Name = availableRegion.Name,
                });
            }
            return availableRegionDTOs;

        }

    }
}