using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JobTrackerApi.Models;
using JobTrackerApi.Data;

namespace JobTrackerApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class JobsController : ControllerBase
{
    private readonly AppDbContext _context;

    // The Constructor demanding the database connection!
    public JobsController(AppDbContext context)
    {
        _context = context;
    }

    // 1. GET ALL JOBS
    [HttpGet]
    public async Task<ActionResult<IEnumerable<JobApplicationDTO>>> GetJobs()
    {
        // Go to the database, get the JobApplications table, and turn it into a list!
        return await _context.JobApplications
        .Select(x => JobToDTO(x))
        .ToListAsync();
    }

    [HttpPost]
    public async Task<ActionResult<JobApplicationDTO>> PostJob(JobApplicationDTO newJobDTO)
    {
        var rawJob = new JobApplication
        {
            CompanyName = newJobDTO.CompanyName,
            PositionTitle = newJobDTO.PositionTitle,
            Location = newJobDTO.Location,
            JobUrl = newJobDTO.JobUrl,
            SalaryRange = newJobDTO.SalaryRange,
            Status = newJobDTO.Status,
            DateApplied = newJobDTO.DateApplied,
            Notes = "" // We just put a blank string here, because the DTO didn't provide one!
        };
        // 3. We hand the raw model to the Database
        _context.JobApplications.Add(rawJob);
        await _context.SaveChangesAsync();
        // 4. We return the DTO back to the Internet
        return JobToDTO(rawJob);
}


    [HttpGet("{id}")]
    public async Task<ActionResult<JobApplicationDTO>> GetByID(int id)
    {
        var job = await _context.JobApplications.FindAsync(id);
        if(job == null)
        {
        return NotFound();
        }
        else
        {

        return JobToDTO(job);
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteJob(int id)
    {
        var job = await _context.JobApplications.FindAsync(id);
        if(job == null)
        {
            return NotFound();
        }
        _context.JobApplications.Remove(job);
        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateJob(int id, JobApplicationDTO updatedJobDTO)
    {
        if(id != updatedJobDTO.Id)
        {
            return BadRequest();
        }
        var rawJob = new JobApplication
        {
            Id = updatedJobDTO.Id,
            CompanyName = updatedJobDTO.CompanyName,
            PositionTitle = updatedJobDTO.PositionTitle,
            Location = updatedJobDTO.Location,
            JobUrl = updatedJobDTO.JobUrl,
            SalaryRange = updatedJobDTO.SalaryRange,
            Status = updatedJobDTO.Status,
            DateApplied = updatedJobDTO.DateApplied,
            Notes = "" // We just put a blank string here, because the DTO didn't provide one!
        };
        _context.Entry(rawJob).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return NoContent();

    }
     private static JobApplicationDTO JobToDTO(JobApplication job) =>
       new JobApplicationDTO
       {
           Id = job.Id,
           CompanyName = job.CompanyName,
           Location = job.Location,
           JobUrl = job.JobUrl,
           SalaryRange = job.SalaryRange,
           Status = job.Status,
           DateApplied = job.DateApplied,
           PositionTitle = job.PositionTitle
        };
    }

