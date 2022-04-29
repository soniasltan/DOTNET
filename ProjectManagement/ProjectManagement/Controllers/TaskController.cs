using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;
using ProjectManagement.Models;
using Task = ProjectManagement.Models.Task;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProjectManagement.Controllers
{
    public class TaskResponseModel
    {
        public string Message { set; get; }
        public bool Status { set; get; }
        public List<dynamic> Data { set; get; }
    }

    public class TaskStatusResponseModel
    {
        public string Message { set; get; }
        public bool Status { set; get; }

    }

    public class AddTaskResponseModel
    {
        public string Message { set; get; }
        public int Id { get; set; }
        public bool Status { set; get; }

    }

    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : Controller
    {
        private IConfiguration _configuration;

        public TaskController(IConfiguration config)
        {
            _configuration = config;
        }

        // GET: api/values
        [HttpGet]
        public TaskResponseModel Get()
        {
            TaskResponseModel _objResponseModel = new TaskResponseModel();

            string query = @"
                            select * from
                            task
                            ";

            DataTable table = new DataTable();

            string sqlDataSource = _configuration.GetConnectionString("PMDB");
            SqlDataReader myReader;

            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {

                myCon.Open();
                using (SqlCommand getTasks = new SqlCommand(query, myCon))
                {
                    myReader = getTasks.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            List<dynamic> taskList = new List<dynamic>();
            for (int i = 0; i < table.Rows.Count; i++)
            {

                Task tasks = new Task();
                tasks.Id = Convert.ToInt32(table.Rows[i]["id"]);
                tasks.ProjectId = Convert.ToInt32(table.Rows[i]["project_id"]);
                tasks.TaskTitle = table.Rows[i]["task_title"].ToString();
                tasks.TaskDescription = table.Rows[i]["task_description"].ToString();
                tasks.TaskStatus = table.Rows[i]["task_status"].ToString();
                tasks.AssignedToId = Convert.ToInt32(table.Rows[i]["assigned_to_id"]);
                tasks.AssignedById = Convert.ToInt32(table.Rows[i]["assigned_by_id"]);
                tasks.CreatedDate = table.Rows[i]["created_date"].ToString();
                tasks.UpdatedById = Convert.ToInt32(table.Rows[i]["updated_by_id"]);
                tasks.Attachment = table.Rows[i]["attachment"].ToString();
                taskList.Add(tasks);
            }


            _objResponseModel.Data = taskList;
            _objResponseModel.Status = true;
            _objResponseModel.Message = "Task Data Received successfully";
            return _objResponseModel;

        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public AddTaskResponseModel Post(Task taskdata)
        {

            AddTaskResponseModel _objResponseModel = new AddTaskResponseModel();

            string query = @"
                           insert into task
                           (project_id, task_title, task_description, task_status, assigned_to_id, created_date, updated_by_id)
                    values (@project_id, @task_title, @task_description, @task_status, @assigned_to_id, @created_date, @updated_by_id);
                            ";

            string queryId = @"SELECT MAX(ID) AS LastID FROM task";

            DataTable table = new DataTable();
            DataTable idTable = new DataTable();

            string sqlDataSource = _configuration.GetConnectionString("PMDB");
            SqlDataReader myReader;
            int taskId;

            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {

                myCon.Open();
                using (SqlCommand addTask = new SqlCommand(query, myCon))
                {
                    addTask.Parameters.AddWithValue("@project_id", taskdata.ProjectId);
                    addTask.Parameters.AddWithValue("@task_title", taskdata.TaskTitle);
                    addTask.Parameters.AddWithValue("@task_description", taskdata.TaskDescription);
                    addTask.Parameters.AddWithValue("@task_status", taskdata.TaskStatus);
                    addTask.Parameters.AddWithValue("@assigned_to_id", taskdata.AssignedToId);
                    addTask.Parameters.AddWithValue("@assigned_by_id", taskdata.AssignedById);
                    addTask.Parameters.AddWithValue("@created_date", taskdata.CreatedDate);
                    addTask.Parameters.AddWithValue("@updated_by_id", taskdata.UpdatedById);

                    myReader = addTask.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                }

                using (SqlCommand findId = new SqlCommand(queryId, myCon))
                {
                    myReader = findId.ExecuteReader();
                    idTable.Load(myReader);
                    taskId = Convert.ToInt32(idTable.Rows[0]["LastID"]);

                    myReader.Close();
                    myCon.Close();
                }
            }

            _objResponseModel.Id = taskId;
            _objResponseModel.Status = true;
            _objResponseModel.Message = "Task Data Inserted successfully";
            return _objResponseModel;

        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

