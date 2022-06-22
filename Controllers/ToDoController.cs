using Microsoft.AspNetCore.Mvc;
using ToDoApplication.Models;
using ToDoApplication.Services;

namespace ToDoApplication.Controllers
{
    public class ToDoController : Controller
    {
        private readonly IToDoService _todo;

        public ToDoController(IToDoService toDoService)
        {
            _todo = toDoService;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ToDo obj)
        {
            if (!ModelState.IsValid)
                return View(obj);

            var res = _todo.Insert(obj);

            if (res)
            {
                TempData["success"] = "Todo was addedd successfully";
                return RedirectToAction("index", "Home");
            }

            TempData["error"] = "Action was not successful";
            return View(obj);
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            if (id == 0 || id == null)
                return RedirectToAction("NotFoundPage", "Home");

            var data = _todo.GetById(id);

            return View(data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(ToDo obj)
        {
            if (!ModelState.IsValid)
                return View(obj);

            var res = _todo.Update(obj);
            TempData["success"] = "List updated successfully";

            return res == true ? RedirectToAction("index", "Home") : View(obj);
        }

        [HttpGet]
        public IActionResult DeleteView(int id)
        {
            var data = _todo.GetById(id);

            return View(data);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var res = _todo.Delete(id);
            TempData["success"] = "Deleted successfully";

            return RedirectToAction("index", "Home");
        }
        [HttpGet]
        public IActionResult DeleteAll()
        {
            var res = _todo.DeleteAll();
            TempData["success"] = "All List Deleted successfully";

            return RedirectToAction("index", "Home");
        }

        [HttpPost]
        public IActionResult Search(ToDo obj)
        {
            var result = _todo.Search(obj.Name);
            if (result.Count == 0)
                TempData["error"] = "Not Found";
            else
                TempData["success"] = "Search Completed Successfully";

            return View(result);
        }
    }
}
