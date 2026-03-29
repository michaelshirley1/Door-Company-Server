using BusinessApi.Factories;
using BusinessApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace BusinessApi.Controllers;

[ApiController]
[Route("[controller]")]
public class JobController : ControllerBase
{
    private readonly IJobFactory _jobFactory;

    public JobController(IJobFactory jobFactory)
    {
        _jobFactory = jobFactory;
    }

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<Job>), StatusCodes.Status200OK)]
    public IActionResult GetAll()
    {
        var jobs = _jobFactory.GetAll();
        return Ok(jobs);
    }

    [HttpGet("{id:int}")]
    [ProducesResponseType(typeof(Job), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult GetById(int id)
    {
        var job = _jobFactory.GetById(id);
        return job is null ? NotFound($"Job {id} not found.") : Ok(job);
    }
}
