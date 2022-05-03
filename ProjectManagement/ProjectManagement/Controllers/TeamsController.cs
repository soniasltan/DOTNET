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
    public class TeamsResponseModel
    {
        public string Message { set; get; }
        public bool Status { set; get; }
        public List<dynamic> Data { set; get; }
    }

    public class TeamsStatusResponseModel
    {
        public string Message { set; get; }
        public bool Status { set; get; }

    }

    [Route("api/[controller]")]
    [ApiController]
    public class TeamsController : Controller
    {
        private IConfiguration _configuration;

        public TeamsController(IConfiguration config)
        {
            _configuration = config;
        }

        // GET: api/values
        [HttpGet]
        public TeamsResponseModel Get()
        {
            TeamsResponseModel _objResponseModel = new TeamsResponseModel();

            string query = @"
                            select * from
                            teams
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

            List<dynamic> teamsList = new List<dynamic>();
            for (int i = 0; i < table.Rows.Count; i++)
            {

                Team teams = new Team();
                teams.Id = Convert.ToInt32(table.Rows[i]["id"]);
                teams.Teamname = table.Rows[i]["teamname"].ToString();
                teamsList.Add(teams);
            }


            _objResponseModel.Data = teamsList;
            _objResponseModel.Status = true;
            _objResponseModel.Message = "Teams received successfully";
            return _objResponseModel;

        }

        // GET api/values/5
        [HttpGet("{id}")]
        public TeamsResponseModel Get(int id)
        {
            TeamsResponseModel _objResponseModel = new TeamsResponseModel();

            string query = @"
                            select * from
                            teams where id=@id
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

            List<dynamic> teamsList = new List<dynamic>();
            for (int i = 0; i < table.Rows.Count; i++)
            {

                Team teams = new Team();
                teams.Id = Convert.ToInt32(table.Rows[i]["id"]);
                teams.Teamname = table.Rows[i]["teamname"].ToString();
                teamsList.Add(teams);
            }


            _objResponseModel.Data = teamsList;
            _objResponseModel.Status = true;
            _objResponseModel.Message = "Follow ups received successfully";
            return _objResponseModel;

        }

        // POST api/values
        [HttpPost]
        public TeamsStatusResponseModel Post(Team teamsdata)
        {
            TeamsStatusResponseModel _objResponseModel = new TeamsStatusResponseModel();

            string query = @"
                            insert into teams
                            (teamname) values (@teamname)
                            ";

            DataTable table = new DataTable();

            string sqlDataSource = _configuration.GetConnectionString("PMDB");
            SqlDataReader myReader;

            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand addTeam = new SqlCommand(query, myCon))
                {
                    addTeam.Parameters.AddWithValue("@teamname", teamsdata.Teamname);
                    
                    myReader = addTeam.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            _objResponseModel.Status = true;
            _objResponseModel.Message = "New team created successfully.";
            return _objResponseModel;
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public TeamsStatusResponseModel Put(Team teamsdata)
        {
            TeamsStatusResponseModel _objResponseModel = new TeamsStatusResponseModel();

            string query = @"
                           update teams set
                           teamname = @teamname
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
                    myCommand.Parameters.AddWithValue("@id", teamsdata.Id);
                    myCommand.Parameters.AddWithValue("@teamname", teamsdata.Teamname);

                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }


            _objResponseModel.Status = true;
            _objResponseModel.Message = "Team updated successfully";
            return _objResponseModel;
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public TeamsStatusResponseModel Delete(int id)
        {
            TeamsStatusResponseModel _objResponseModel = new TeamsStatusResponseModel();

            string query = @"
                           delete from teams where id=@id
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
            _objResponseModel.Message = "Team deleted successfully";
            return _objResponseModel;

        }
    }
}

