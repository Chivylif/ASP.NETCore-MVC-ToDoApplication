using System.Data.SqlClient;

namespace ToDoApplication.Repository
{
    public interface IRepository
    {
        public bool ExecuteQuery(string statement);
        public SqlConnection GetConnection();
        public SqlDataReader FetchDataFromDb(string statement);
        //public bool UpdateDataToDb(string statement);
        //public bool DeleteDataFromDb(string statement);
        public SqlDataReader GetDataById(string statement);
    }
}
