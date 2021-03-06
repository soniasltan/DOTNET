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
    public class ProjectsResponseModel
    {
        public string Message { set; get; }
        public bool Status { set; get; }
        public List<dynamic> Data { set; get; }
    }

    public class ProjectsStatusResponseModel
    {
        public string Message { set; get; }
        public bool Status { set; get; }

    }

    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : Controller
    {
        private IConfiguration _configuration;

        public ProjectsController(IConfiguration config)
        {
            _configuration = config;
        }

        // GET: api/values
        [HttpGet]
        public ProjectsResponseModel Get()
        {
            ProjectsResponseModel _objResponseModel = new ProjectsResponseModel();

            string query = @"
                            select * from
                            project
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

            List<dynamic> projectsList = new List<dynamic>();
            for (int i = 0; i < table.Rows.Count; i++)
            {

                Project projects = new Project();
                projects.Id = Convert.ToInt32(table.Rows[i]["id"]);
                projects.ProjectName = table.Rows[i]["project_name"].ToString();
                projects.ProjectDescription = table.Rows[i]["project_description"].ToString();
                projects.ClientId = Convert.ToInt32(table.Rows[i]["client_id"]);
                projects.ProjectManagerId = Convert.ToInt32(table.Rows[i]["project_manager_id"]);
                projects.CreatedDate = table.Rows[i]["created_date"].ToString();
                projects.Status = table.Rows[i]["status"].ToString();
                projectsList.Add(projects);
            }


            _objResponseModel.Data = projectsList;
            _objResponseModel.Status = true;
            _objResponseModel.Message = "Projects received successfully";
            return _objResponseModel;

        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ProjectsResponseModel Get(int id)
        {
            ProjectsResponseModel _objResponseModel = new ProjectsResponseModel();

            string query = @"
                            select * from
                            project where id=@id
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

            List<dynamic> projectsList = new List<dynamic>();
            for (int i = 0; i < table.Rows.Count; i++)
            {

                Project projects = new Project();
                projects.Id = Convert.ToInt32(table.Rows[i]["id"]);
                projects.ProjectName = table.Rows[i]["project_name"].ToString();
                projects.ProjectDescription = table.Rows[i]["project_description"].ToString();
                projects.ClientId = Convert.ToInt32(table.Rows[i]["client_id"]);
                projects.ProjectManagerId = Convert.ToInt32(table.Rows[i]["project_manager_id"]);
                projects.CreatedDate = table.Rows[i]["created_date"].ToString();
                projects.Status = table.Rows[i]["status"].ToString();
                projectsList.Add(projects);
            }


            _objResponseModel.Data = projectsList;
            _objResponseModel.Status = true;
            _objResponseModel.Message = "Project received successfully";
            return _objResponseModel;

        }

        // POST api/values
        [HttpPost]
        public ProjectsStatusResponseModel Post(Project projectdata)
        {
            ProjectsStatusResponseModel _objResponseModel = new ProjectsStatusResponseModel();

            string query = @"
                            insert into project
                            (project_name, project_description, client_id, project_manager_id, created_date, status) values (@project_name, @project_description, @client_id, @project_manager_id, @created_date, @status)
                            ";

            DataTable table = new DataTable();

            string sqlDataSource = _configuration.GetConnectionString("PMDB");
            SqlDataReader myReader;

            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand addProject = new SqlCommand(query, myCon))
                {
                    addProject.Parameters.AddWithValue("@project_name", projectdata.ProjectName);
                    addProject.Parameters.AddWithValue("@project_description", projectdata.ProjectDescription);
                    addProject.Parameters.AddWithValue("@client_id", projectdata.ClientId);
                    addProject.Parameters.AddWithValue("@project_manager_id", projectdata.ProjectManagerId);
                    addProject.Parameters.AddWithValue("@created_date", projectdata.CreatedDate);
                    addProject.Parameters.AddWithValue("@status", projectdata.Status);

                    myReader = addProject.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            _objResponseModel.Status = true;
            _objResponseModel.Message = "New project created successfully.";
            return _objResponseModel;
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public ProjectsStatusResponseModel Put(Project projectdata)
        {
            ProjectsStatusResponseModel _objResponseModel = new ProjectsStatusResponseModel();

            string query = @"
                           update project set
                           project_name = @project_name,
                           project_description = @project_description,
                           client_id = @client_id,
                           project_manager_id = @project_manager_id,
                           created_date = @created_date,
                           status = @status
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
                    myCommand.Parameters.AddWithValue("@id", projectdata.Id);
                    myCommand.Parameters.AddWithValue("@project_name", projectdata.ProjectName);
                    myCommand.Parameters.AddWithValue("@project_description", projectdata.ProjectDescription);
                    myCommand.Parameters.AddWithValue("@client_id", projectdata.ClientId);
                    myCommand.Parameters.AddWithValue("@project_manager_id", projectdata.ProjectManagerId);
                    myCommand.Parameters.AddWithValue("@created_date", projectdata.CreatedDate);
                    myCommand.Parameters.AddWithValue("@status", projectdata.Status);

                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }


            _objResponseModel.Status = true;
            _objResponseModel.Message = "Project updated successfully";
            return _objResponseModel;
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public ProjectsStatusResponseModel Delete(int id)
        {
            ProjectsStatusResponseModel _objResponseModel = new ProjectsStatusResponseModel();

            string query = @"
                           delete from project where id=@id
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
            _objResponseModel.Message = "Project deleted successfully";
            return _objResponseModel;

        }
    }
}

