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
    public class UserDetailsResponseModel
    {
        public string Message { set; get; }
        public bool Status { set; get; }
        public List<dynamic> Data { set; get; }
    }

    public class UserDetailsStatusResponseModel
    {
        public string Message { set; get; }
        public bool Status { set; get; }

    }

    [Route("api/[controller]")]
    [ApiController]
    public class UserDetailsController : Controller
    {
        private IConfiguration _configuration;

        public UserDetailsController(IConfiguration config)
        {
            _configuration = config;
        }

        // GET: api/values
        [HttpGet]
        public UserDetailsResponseModel Get()
        {
            UserDetailsResponseModel _objResponseModel = new UserDetailsResponseModel();

            string query = @"
                            select * from
                            user_details
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

            List<dynamic> userDetails = new List<dynamic>();
            for (int i = 0; i < table.Rows.Count; i++)
            {

                UserDetail details = new UserDetail();
                details.Id = Convert.ToInt32(table.Rows[i]["id"]);
                details.UserListId = Convert.ToInt32(table.Rows[i]["user_list_id"]);
                details.Email = table.Rows[i]["email"].ToString();
                details.Phonenumber = table.Rows[i]["phonenumber"].ToString();
                details.Address = table.Rows[i]["address"].ToString();
                userDetails.Add(details);
            }


            _objResponseModel.Data = userDetails;
            _objResponseModel.Status = true;
            _objResponseModel.Message = "User Details Received successfully";
            return _objResponseModel;

        }

        // GET api/values/5
        [HttpGet("{id}")]
        public UserDetailsResponseModel Get(int id)
        {
            UserDetailsResponseModel _objResponseModel = new UserDetailsResponseModel();

            string query = @"
                            select * from
                            user_details where id=@id
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

            List<dynamic> userDetails = new List<dynamic>();
            for (int i = 0; i < table.Rows.Count; i++)
            {

                UserDetail details = new UserDetail();
                details.Id = Convert.ToInt32(table.Rows[i]["id"]);
                details.UserListId = Convert.ToInt32(table.Rows[i]["user_list_id"]);
                details.Email = table.Rows[i]["email"].ToString();
                details.Phonenumber = table.Rows[i]["phonenumber"].ToString();
                details.Address = table.Rows[i]["address"].ToString();
                userDetails.Add(details);
            }


            _objResponseModel.Data = userDetails;
            _objResponseModel.Status = true;
            _objResponseModel.Message = "User Details Received successfully";
            return _objResponseModel;

        }

        // POST api/values
        [HttpPost]
        public UserDetailsStatusResponseModel Post(UserDetail detailsdata)
        {
            UserDetailsStatusResponseModel _objResponseModel = new UserDetailsStatusResponseModel();

            string query = @"
                            insert into user_details
                            (user_list_id, email, phonenumber, address) values (@user_list_id, @email, @phonenumber, @address)
                            ";

            DataTable table = new DataTable();

            string sqlDataSource = _configuration.GetConnectionString("PMDB");
            SqlDataReader myReader;

            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand addDetails = new SqlCommand(query, myCon))
                {
                    addDetails.Parameters.AddWithValue("@user_list_id", detailsdata.UserListId);
                    addDetails.Parameters.AddWithValue("@email", detailsdata.Email);
                    addDetails.Parameters.AddWithValue("@phonenumber", detailsdata.Phonenumber);
                    addDetails.Parameters.AddWithValue("@address", detailsdata.Address);

                    myReader = addDetails.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            _objResponseModel.Status = true;
            _objResponseModel.Message = "New details created successfully.";
            return _objResponseModel;
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public UserDetailsStatusResponseModel Put(UserDetail detailsdata)
        {
            UserDetailsStatusResponseModel _objResponseModel = new UserDetailsStatusResponseModel();

            string query = @"
                           update user_details set
                           user_list_id = @user_list_id,
                           email = @email,
                           phonenumber = @phonenumber,
                           address = @address
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
                    myCommand.Parameters.AddWithValue("@id", detailsdata.Id);
                    myCommand.Parameters.AddWithValue("@user_list_id", detailsdata.UserListId);
                    myCommand.Parameters.AddWithValue("@email", detailsdata.Email);
                    myCommand.Parameters.AddWithValue("@phonenumber", detailsdata.Phonenumber);
                    myCommand.Parameters.AddWithValue("@address", detailsdata.Address);

                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }


            _objResponseModel.Status = true;
            _objResponseModel.Message = "User details updated successfully";
            return _objResponseModel;
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public UserDetailsStatusResponseModel Delete(int id)
        {
            UserDetailsStatusResponseModel _objResponseModel = new UserDetailsStatusResponseModel();

            string query = @"
                           delete from user_details where id=@id
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
            _objResponseModel.Message = "User details deleted successfully";
            return _objResponseModel;

        }
    }
}

