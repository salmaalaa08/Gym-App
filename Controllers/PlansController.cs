using GymApp.DAL.Models;
using GymApp.DAL.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GymApp.BLL;
namespace GymApp.Controllers;

public class PlansController : Controller
{
    private readonly IPlansService _services;
    public PlansController(IPlansService service)
    {
        _services = service;
    }

    // Get : baseUrl/Plans/Index
    [HttpGet]
    public async Task<IActionResult> Index(CancellationToken cancellationToken)
    {
        var plans = await _services.PlansAsync(cancellationToken);
        // get all plans
        // send to view 
        return View(plans);
    }
    // Details : baseUrl/Plans/Index/id
    [HttpGet]
    public async Task<IActionResult> Details(int id, CancellationToken cancellationToken)
    {
        var plan = await _services.GetPlanByIdAsync(id, cancellationToken);
        if(plan == null)
            return RedirectToAction(nameof(Index));
        return View(plan);
    }
}