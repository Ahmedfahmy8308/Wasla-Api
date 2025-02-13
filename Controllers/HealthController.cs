using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Wasla.Data;

namespace Wasla.Controllers
{
    [Route("api/health")]
    [ApiController]
    public class HealthController : ControllerBase
    {
        private readonly AppDbContext _context; 

        public HealthController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult CheckAPIWork()
        {
            return Ok("API is working");
        }

        [HttpGet("db")]
        public IActionResult CheckDBConnection()
        {
            try
            {
                bool canConnect = _context.Database.CanConnect();
                return canConnect ? Ok("DB is connected") : StatusCode(500, "DB connection failed");
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("system")]
        public IActionResult CheckSystemHealth()
        {
            var process = System.Diagnostics.Process.GetCurrentProcess();
            var memoryUsage = process.WorkingSet64 / (1024 * 1024); 
            var cpuUsage = process.TotalProcessorTime.TotalSeconds;

            return Ok(new
            {
                MemoryUsageMB = memoryUsage,
                CPUTimeSeconds = cpuUsage,
                Message = "System health is normal"
            });
        }

        [HttpGet("disk-space")]
        public IActionResult CheckDiskSpace()
        {
            var drive = System.IO.DriveInfo.GetDrives().FirstOrDefault(d => d.IsReady);
            if (drive == null) return StatusCode(500, "Unable to check disk space");

            return Ok(new
            {
                TotalSizeGB = drive.TotalSize / (1024 * 1024 * 1024),
                FreeSpaceGB = drive.AvailableFreeSpace / (1024 * 1024 * 1024),
                Message = "Disk space is sufficient"
            });
        }

    }
}