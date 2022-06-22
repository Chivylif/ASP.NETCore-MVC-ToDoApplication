using Microsoft.AspNetCore.Mvc;
using ToDoApplication.Models;
using ToDoApplication.Services;

namespace ToDoApplication.Components
{
    public class SearchList : ViewComponent
    {
        private readonly IToDoService _todo;

        public SearchList(IToDoService todo)
        {
            _todo = todo;
        }

        public IViewComponentResult Invoke()
        {

            var todo = new ToDo();
            return View(todo);
        }
    }
}
