using MegaCity.Models;
using MegaCity.Services;
using Microsoft.AspNetCore.Mvc;

namespace MegaCity.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BuildingsController : ControllerBase
{
    private readonly IBuildingsService _service;

    public BuildingsController(IBuildingsService service)
    {
        _service = service;
    }

    [HttpGet("{buildingId}")]
    public async Task<ActionResult> GetBuilding(int buildingId)
    {
        return new OkObjectResult(await _service.FindBuildingById(buildingId));
    }

    [HttpGet()]
    public async Task<ActionResult> GetAllBuildings()
    {
        return new OkObjectResult(await _service.FindAll());
    }

    [HttpPost()]
    public async Task<ActionResult> AddBuilding([FromBody] Building building)
    {
        var createdBuilding = await _service.Create(building);
        if(createdBuilding != null)
        {
            return Created($"api/building/{createdBuilding.Id}", createdBuilding);
        }
        return BadRequest();
    }

    [HttpPut("{buildingId}")]
    public async Task<ActionResult> UpdateBuilding(int buildingId, [FromBody] Building building)
    {
        bool success = await _service.Update(buildingId, building);
        if (success)
        {
            return Ok();
        }
        return BadRequest();
    }
}