using ToDoApplication.Models;
using ToDoApplication.ViewModel;

namespace ToDoApplication.Services
{
    public interface IToDoService
    {
        public List<TodoViewModel> AllList { get; }

        public bool Insert(ToDo toDo);
        public bool Update(ToDo toDo);
        public bool Delete(int Id);
        public bool DeleteAll();
        public ToDo GetById(int id);
        public List<ToDo> Search(string word);

    }
}
