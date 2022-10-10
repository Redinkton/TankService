using MyTank.Services;
using MyTank.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MyTank.Controllers;

[ApiController]
[Route("[controller]")]
public class TankController : ControllerBase
{
    TankService _service;
    
    public TankController(TankService service)
    {
        _service = service;
    }
     

    [HttpGet]
    public IEnumerable<Tank> GetAll()
    {
        return _service.GetAll();
    }

    [HttpGet("{id}")]
    public ActionResult<Tank> GetById(int id)
    {
        var tank = _service.GetById(id);

        if(tank is not null)
        {
            return tank;
        }
        else
        {
            return NotFound();
        }
    }


    [HttpPost]
    public IActionResult Create(Tank newTank)
    {
        var tank = _service.Create(newTank);
        return CreatedAtAction(nameof(GetById), new { id = tank!.Id }, tank);
    }


    [HttpPut("{id}/updatecurrentvolume")]
    public IActionResult Update(int id, int currentVolume)
    {
        var tankToUpdate = _service.GetById(id);

        if (tankToUpdate is not null)
        {
            _service.Update(id, currentVolume);
            return NoContent();
        }
        else
        {
            return NotFound();
        }
    }


    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var tank = _service.GetById(id);

        if(tank is not null)
        {
            _service.DeleteById(id);
            return Ok();
        }
        else
        {
            return NotFound();
        }
    }
}