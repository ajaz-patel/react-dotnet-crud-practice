using curd_with_react.Data;
using curd_with_react.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using curd_with_react.Dtos;

namespace curd_with_react.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddGoalController : ControllerBase
    {
        private readonly DapperContext _dapperContext;
        private readonly IConfiguration _config;

        public AddGoalController(DapperContext dapperContext, IConfiguration config)
        {
            _config = config;
            _dapperContext = new DapperContext(config);
        }

        [HttpGet("/GetGoal")]

        public IEnumerable<AddGoal> GetAllGoal()
        {
            string sql = "select * from addgoal.Goals";
            return _dapperContext.LoadData<AddGoal>(sql);
        }
        [HttpPost("/AddGoals")]

        public IActionResult AddGoal(AddGoalDto goal)
        {
            string sql = "insert into addgoal.Goals values('" + goal.title + "','" + goal.description + "') ";
            if(_dapperContext.ExecuteSql(sql))
            {
                return Ok(goal);
            }
            else
            {
                return StatusCode(400, "not added");
            }
        }
        [HttpPut("/update/{id}")]

        public IActionResult Update(AddGoalDto goal,int id)
        {
            string sql = "update addgoal.Goals set title='" + goal.title + "',description='" + goal.description+"' where id=" + id;
            if (_dapperContext.ExecuteSql(sql))
            {
                return Ok();
            }
            else
            {
                return StatusCode(400, "not uodated");
            }
        }
        [HttpDelete("/delete/{id}")]
        public IActionResult Delete(int id)
        {
            string sql = "delete from addgoal.Goals where id=" + id;
            if (_dapperContext.ExecuteSql(sql))
            {
                return Ok();
            }
            else
            {
                return StatusCode(400, "not deleted");
            }
        }

    }
}
