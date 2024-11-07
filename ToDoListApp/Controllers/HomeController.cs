using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ToDoListApp.Models;

namespace ToDoListApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ToDoListAppDbContext _dbContext;

        public HomeController(ILogger<HomeController> logger, ToDoListAppDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult ToDoListView()
        {
            var allTasks = _dbContext.ToDoLists.ToList();

            return View(allTasks);
        }

        public IActionResult CreateEditTaskView(int? id)
        {
            if (id != null)
            {
                var taskInDb = _dbContext.ToDoLists.SingleOrDefault(task => task.Id == id);
                return View(taskInDb);
            }
            return View();
        }

        public IActionResult DeleteTask(int id)
        {
            var taskInDb = _dbContext.ToDoLists.SingleOrDefault(task => task.Id == id);

            _dbContext.ToDoLists.Remove(taskInDb);

            _dbContext.SaveChanges();

            return RedirectToAction("ToDoListView");
        }

        public IActionResult CreateEditTaskForm(ToDoList model)
		{
            if (model.Id == 0)
            {
                _dbContext.ToDoLists.Add(model);
            }
            else
            {
                _dbContext.ToDoLists.Update(model);
            }

            _dbContext.SaveChanges();

            return RedirectToAction("ToDoListView");
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
