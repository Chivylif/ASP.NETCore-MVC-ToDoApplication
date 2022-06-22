using System.Data.SqlClient;
using ToDoApplication.Models;
using ToDoApplication.Repository;
using ToDoApplication.ViewModel;

namespace ToDoApplication.Services
{
    public class ToDoService : IToDoService
    {
        private readonly IRepository _repo;

        public ToDoService(IRepository repo)
        {
            _repo = repo;
        }
        public List<TodoViewModel> AllList
        {
            get
            {
                var statement = "SELECT * FROM todo";

                SqlDataReader data = _repo.FetchDataFromDb(statement);
                var list = new List<TodoViewModel>();

                if (data.HasRows)
                {
                    while (data.Read())
                    {
                        list.Add(
                            new TodoViewModel()
                            {
                                Id = Convert.ToInt32(data["id"].ToString()),
                                Name = data["Name"].ToString(),
                                Date = data["due_date"].ToString()
                            }
                        );
                    }
                }

                return list;
            }
        }



        public bool Delete(int Id)
        {
            var stat = $"DELETE FROM todo WHERE id = {Id}";
            return _repo.ExecuteQuery(stat);
        }

        public bool DeleteAll()
        {
            var stat = $"DELETE FROM todo";
            return _repo.ExecuteQuery(stat);
        }

        public bool Insert(ToDo toDo)
        {
            string date = toDo.Date.ToShortDateString();
            var statement = @$"INSERT INTO todo (name, due_date) 
                            VALUES('{toDo.Name}', '{date}')";

            return _repo.ExecuteQuery(statement);
        }

        public bool Update(ToDo toDo)
        {
            //Convert the date to string
            var date = toDo.Date.ToShortDateString();

            var stat = @$"UPDATE todo SET name = '{toDo.Name}', due_date = '{date}' 
                        WHERE id = {toDo.Id}";

            return _repo.ExecuteQuery(stat);
        }

        public ToDo GetById(int id)
        {
            var stat = $"SELECT * FROM todo WHERE id = {id}";
            SqlDataReader data = _repo.GetDataById(stat);

            ToDo list = new ToDo();

            if (data != null)
            {
                while (data.Read())
                {
                    list.Date = Convert.ToDateTime(data.GetString(2));
                    list.Name = data.GetString(1);
                }
            }

            return list;
        }

        public List<ToDo> Search(string word)
        {
            var stat = $"SELECT * FROM todo WHERE name LIKE '%{word}%'";
            var res = _repo.FetchDataFromDb(stat);

            var list = new List<ToDo>();

            if (res != null)
            {
                while (res.Read())
                {
                    list.Add(
                        new ToDo()
                        {
                            Id = Convert.ToInt32(res["id"].ToString()),
                            Name = res["name"].ToString()
                        }
                    );
                }
            }

            return list;
        }
    }
}
