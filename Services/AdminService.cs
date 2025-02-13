using Microsoft.EntityFrameworkCore;
using Wasla.Data;
using Wasla.Models;
using Wasla.DTOs;

namespace Wasla.Services
{
    public class AdminService : IAdminService
    {
        private readonly AppDbContext _context;

        public AdminService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<GovernmentDTO>> GetGovernments()
        {
            
            var record = await _context.Governments.ToListAsync();
            return record.Select(g => new GovernmentDTO
            {
                Id = g.Id,
                Name = g.Name
            }).ToList();
        }

        public async Task AddGovernment(string governmentName)
        {
            var governmentnameexists = await _context.Governments.AnyAsync(g => g.Name == governmentName);
            if (governmentnameexists)
            {
                throw new Exception("Government name already exists");
            }
            Government government = new Government
            {
                Id = Guid.NewGuid().ToString(),
                Name = governmentName
            };
            await _context.Governments.AddAsync(government);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateGovernment(GovernmentDTO government)
        {
            var governmentnameexists = await _context.Governments.AnyAsync(g => g.Name == government.Name);
            if (governmentnameexists)
            {
                throw new Exception("Government name already exists");
            }
            var existingGov = await _context.Governments.FindAsync(government.Id);
            if (existingGov != null)
            {
                existingGov.Name = government.Name;
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Government not found");
            }
        }

        public async Task DeleteGovernment(string governmentId)
        {
            var gov = await _context.Governments.FindAsync(governmentId);
            if (gov != null)
            {
                _context.Governments.Remove(gov);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Government not found");
            }
        }


        public async Task<List<RegionDTO>> GetRegions(string governmentId)
        {
            var record = await _context.Regions.Where(r => r.GovernmentId == governmentId).ToListAsync();
            return record.Select(r => new RegionDTO
            {
                Id = r.Id,
                Name = r.Name
            }).ToList();
        }

        public async Task AddRegion(string governmentId, string regionName)
        {
            var regionnameexistsingovernment = await _context.Regions.AnyAsync(r => r.Name == regionName && r.GovernmentId == governmentId);
            if (regionnameexistsingovernment)
            {
                throw new Exception("Region name already exists in this government");
            }
            var region = new Region
            {
                Id = Guid.NewGuid().ToString(),
                Name = regionName,
                GovernmentId = governmentId
            };
            await _context.Regions.AddAsync(region);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateRegion(string regionId, string regionName)
        {
            var existingRegion = await _context.Regions.FindAsync(regionId);
            var regionnameexistsingovernment = await _context.Regions.AnyAsync(r => r.Name == regionName && r.GovernmentId == existingRegion.GovernmentId);
            if (regionnameexistsingovernment)
            {
                throw new Exception("Region name already exists in this government");
            }
            if (existingRegion != null)
            {
                existingRegion.Name = regionName;
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteRegion(string regionId)
        {
            var region = await _context.Regions.FindAsync(regionId);
            if (region != null)
            {
                _context.Regions.Remove(region);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Region not found");
            }
        } 


        public async Task<List<AvailableRegionDTO>> GetAvailableRegions(string regionId)
        {
            var record = await _context.AvailableRegions.Where(ar => ar.RegionId == regionId).ToListAsync();
            return record.Select(ar => new AvailableRegionDTO
            {
                Id = ar.Id,
                Name = ar.Name,
                Description = ar.Description
            }).ToList();
        }

        public async Task AddAvailableRegion(string regionId, string AvailableRegionname, string AvailableRegionDescription)
        {
            var availableRegion = new AvailableRegion
            {
                Id = Guid.NewGuid().ToString(),
                Name = AvailableRegionname,
                Description = AvailableRegionDescription,
                RegionId = regionId
            };
            await _context.AvailableRegions.AddAsync(availableRegion);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAvailableRegion(string availableRegionId, string AvailableRegionname, string AvailableRegionDescription)
        {
            var existingAvailableRegion = await _context.AvailableRegions.FindAsync(availableRegionId);
            if (existingAvailableRegion != null)
            {
                existingAvailableRegion.Name = AvailableRegionname;
                existingAvailableRegion.Description = AvailableRegionDescription;
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteAvailableRegion(string availableRegionId)
        {
            var availableRegion = await _context.AvailableRegions.FindAsync(availableRegionId);
            if (availableRegion != null)
            {
                _context.AvailableRegions.Remove(availableRegion);
                await _context.SaveChangesAsync();
            }
        }
    }
}
