using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using VacationDays.Data;
using VacationDays.Models;

namespace VacationDays.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private EmployeeData _employeeData = new EmployeeData();

    private const float DaysInYear = 260;

    public HomeController(ILogger<HomeController> logger)
    {      
        _logger = logger;
    }

    public IActionResult Index()
    {       
        return View(_employeeData.GetEmployees());
    }

    public IActionResult Work(int id) 
    {
        var employee = _employeeData.GetEmployee(id);
        return View(employee);
    }

    [HttpPost]
    public IActionResult Work(EmployeeModel model) 
    {
        _employeeData.Work(model);
        model = _employeeData.GetEmployee(model.ID);
        return View(model);
    }

    public IActionResult TakeVacation(int id) 
    {
        var employee = _employeeData.GetEmployee(id);
        return View(employee);
    }

    [HttpPost]
    public IActionResult TakeVacation(EmployeeModel model) 
    {
        _employeeData.TakeVacation(model);
        model = _employeeData.GetEmployee(model.ID);
        return View(model);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
