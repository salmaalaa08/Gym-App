using Microsoft.AspNetCore.Mvc;
using GymApp.BLL;
using GymApp.BLL.ViewModels.Member;

namespace GymApp.Controllers;

public class MemberController : Controller
{
    private readonly IMemberService _memberService;
    public MemberController(IMemberService memberService)
    {
        _memberService = memberService;
    }
    public async Task<IActionResult> Index()
    {
        // logic to reterive members from the database would go here
        var member = await _memberService.GetMembersAsync();
        return View(member);
    }

    // Create
    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateMemberViewModel memberViewModel)
    {
        // Server Side Validation
        if(!ModelState.IsValid)
            return View(memberViewModel);
        
        // Call Service to create Member
        var result = await _memberService.CreateMemberAsync(memberViewModel);

        // if member is created successfully, redirect to the members list
        if(result)
            return RedirectToAction(nameof(Index));
        
        // else, notify Email or Phone is already taked and return to the Create View with entered data
        ModelState.AddModelError(string.Empty, "Email or Phone is already taken");

        return View(memberViewModel);
    }


}
