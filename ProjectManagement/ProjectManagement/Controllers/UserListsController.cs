using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using ProjectManagement.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProjectManagement.Controllers
{
    public class UserListResponseModel
    {
        public string Message { set; get; }
        public bool Status { set; get; }
        public List<dynamic> Data { set; get; }
    }

    public class UserListStatusResponseModel
    {
        public string Message { set; get; }
        public bool Status { set; get; }

    }

    [Route("api/[controller]")]
    [ApiController]
    public class UserListsController : Controller
    {
        private IConfiguration _configuration;

        public UserListsController(IConfiguration config)
        {
            _configuration = config;
        }

        // GET: api/values
        [HttpGet]
        public UserListResponseModel Get()
        {
            UserListResponseModel _objResponseModel = new UserListResponseModel();

            string query = @"
                            select * from
                            user_list
                            ";

            DataTable table = new DataTable();

            string sqlDataSource = _configuration.GetConnectionString("PMDB");
            SqlDataReader myReader;

            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {

                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            List<dynamic> userList = new List<dynamic>();
            for (int i = 0; i < table.Rows.Count; i++)
            {

                UserList users = new UserList();
                users.Id = Convert.ToInt32(table.Rows[i]["id"]);
                users.Username = table.Rows[i]["username"].ToString();
                users.Password = table.Rows[i]["password"].ToString();
                users.UserRolesId = Convert.ToInt32(table.Rows[i]["user_roles_id"]);
                userList.Add(users);
            }


            _objResponseModel.Data = userList;
            _objResponseModel.Status = true;
            _objResponseModel.Message = "User Data Received successfully";
            return _objResponseModel;

        }

        // GET api/values/5
        [HttpGet("{id}")]
        public UserListResponseModel Get(int id)
        {
            UserListResponseModel _objResponseModel = new UserListResponseModel();

            string query = @"
                            select * from
                            user_list where id=@id
                            ";

            DataTable table = new DataTable();

            string sqlDataSource = _configuration.GetConnectionString("PMDB");
            SqlDataReader myReader;

            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {

                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@id", id);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            List<dynamic> userList = new List<dynamic>();
            for (int i = 0; i < table.Rows.Count; i++)
            {

                UserList users = new UserList();
                users.Id = Convert.ToInt32(table.Rows[i]["id"]);
                users.Username = table.Rows[i]["username"].ToString();
                users.Password = table.Rows[i]["password"].ToString();
                users.UserRolesId = Convert.ToInt32(table.Rows[i]["user_roles_id"]);
                userList.Add(users);
            }


            _objResponseModel.Data = userList;
            _objResponseModel.Status = true;
            _objResponseModel.Message = "User Data Received successfully";
            return _objResponseModel;

        }

        // POST api/values
        [HttpPost]
        public UserListStatusResponseModel Post(UserList userdata)
        {
            UserListStatusResponseModel _objResponseModel = new UserListStatusResponseModel();

            string query = @"
                            insert into user_list
                            (username, password, user_roles_id) values (@username, @password, @user_roles_id)
                            ";

            DataTable table = new DataTable();

            string sqlDataSource = _configuration.GetConnectionString("PMDB");
            SqlDataReader myReader;

            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand addUser = new SqlCommand(query, myCon))
                {
                    addUser.Parameters.AddWithValue("@username", userdata.Username);
                    addUser.Parameters.AddWithValue("@password", userdata.Password);
                    addUser.Parameters.AddWithValue("@user_roles_id", userdata.UserRolesId);

                    myReader = addUser.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            _objResponseModel.Status = true;
            _objResponseModel.Message = "New user created successfully.";
            return _objResponseModel;
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public UserListStatusResponseModel Put(UserList userdata)
        {
            UserListStatusResponseModel _objResponseModel = new UserListStatusResponseModel();

            string query = @"
                           update user_list set
                           username = @username,
                           password = @password,
                           user_roles_id = @user_roles_id
                           where id=@id
                           ";

            DataTable table = new DataTable();

            string sqlDataSource = _configuration.GetConnectionString("PMDB");
            SqlDataReader myReader;

            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {

                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@id", userdata.Id);
                    myCommand.Parameters.AddWithValue("@username", userdata.Username);
                    myCommand.Parameters.AddWithValue("@password", userdata.Password);
                    myCommand.Parameters.AddWithValue("@user_roles_id", userdata.UserRolesId);

                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }


            _objResponseModel.Status = true;
            _objResponseModel.Message = "User updated successfully";
            return _objResponseModel;
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public UserListStatusResponseModel Delete(int id)
        {
            UserListStatusResponseModel _objResponseModel = new UserListStatusResponseModel();

            string query = @"
                           delete from user_list where id=@id
                            ";

            DataTable table = new DataTable();

            string sqlDataSource = _configuration.GetConnectionString("PMDB");
            SqlDataReader myReader;

            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {

                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@id", id);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }


            _objResponseModel.Status = true;
            _objResponseModel.Message = "User deleted successfully";
            return _objResponseModel;

        }
    }
}

