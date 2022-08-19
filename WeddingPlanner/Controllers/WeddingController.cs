using Microsoft.AspNetCore.Mvc;
using WeddingPlanner.Models;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace WeddingPlanner.Controllers;

public class WeddingController : Controller
{
    private WeddingPlannerContext db;
    public WeddingController(WeddingPlannerContext context)
    {
        db = context;
    }
    private int? UUID
    {
        get
        {
            return HttpContext.Session.GetInt32("UUID");
        }
    }

    private bool loggedIn
    {
        get
        {
            return UUID != null;
        }
    }
    [HttpGet("/weddings")]
    public IActionResult Dashboard()
    {
        if(!loggedIn)
        {
            return View("Index");
        }

        List<Wedding> AllWeddings = db.Wedding.ToList();
        return View("Dashboard", AllWeddings);
    }

    [HttpGet("/weddings/new")]
    public IActionResult PlanWedding()
    {
        return View("PlanWedding");
    }
    [HttpPost("/weddings/create")]
    public IActionResult NewWedding(Wedding newWedding)
    {

        if(ModelState.IsValid == false)
        {
            return PlanWedding();
        }

        db.Wedding.Add(newWedding);
        db.SaveChanges();
        return View("Dashboard");
    }
    [HttpPost("/weddings/{weddingId}/add")]
    public IActionResult AddGuests(RSVP newRSVP, int weddingId)
    {
        if (ModelState.IsValid == false)
        {
            return RedirectToAction("All");
        }
        db.RSVP.Add(newRSVP);
        db.SaveChanges();
        return RedirectToAction("Dashboard", new {weddingId = weddingId});
    }
    [HttpGet("/weddings/{weddingId}")]
    public IActionResult ViewWedding(int weddingId)
    {
        Wedding? wedding = db.Wedding
        .FirstOrDefault(wedding => wedding.WeddingId == weddingId);

        if (wedding == null)
        {
            return RedirectToAction("Dashboard");
        }

        return View("ViewWedding", wedding);
    }
}

