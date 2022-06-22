using System.Data.SqlClient;

namespace ToDoApplication.Repository
{
    public class Repository : IRepository
    {
        private readonly string _config;

        public Repository(IConfiguration config)
        {
            _config = config.GetSection("ConnectionStrings:Path").Value;
        }
        public SqlDataReader FetchDataFromDb(string statement)
        {
            SqlConnection con = GetConnection();
            con.Open();

            using (SqlCommand cmd = new SqlCommand(statement, con))
            {
                SqlDataReader data = cmd.ExecuteReader();
                return data;
            }
        }

        public SqlConnection GetConnection()
        {
            return new SqlConnection(_config);
        }

        public bool ExecuteQuery(string statement)
        {
            using (SqlConnection con = GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand(statement, con))
                {
                    con.Open();

                    var res = cmd.ExecuteNonQuery();
                    return res > 0 ? true : false;
                }
            }
        }

        //public bool UpdateDataToDb(string statement)
        //{
        //    using (SqlConnection con = GetConnection())
        //    {
        //        using (SqlCommand cmd = new SqlCommand(statement, con))
        //        {
        //            con.Open();

        //            var res = cmd.ExecuteNonQuery();
        //            return res > 0 ? true : false;
        //        }
        //    }
        //}

        public SqlDataReader GetDataById(string statement)
        {

            SqlConnection con = GetConnection();
            con.Open();

            using (SqlCommand cmd = new SqlCommand(statement, con))
            {
                SqlDataReader data = cmd.ExecuteReader();
                return data;
            }
        }
        //public bool DeleteDataFromDb(string statement)
        //{
        //    using (SqlConnection con = GetConnection())
        //    {
        //        using (SqlCommand cmd = new SqlCommand(statement, con))
        //        {
        //            con.Open();

        //            var res = cmd.ExecuteNonQuery();
        //            return res > 0 ? true : false;
        //        }
        //    }
        //}
    }
}
