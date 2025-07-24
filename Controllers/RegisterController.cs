using Azure;
using Microsoft.AspNetCore.Mvc;
using myApp.Models;
using myApp.Services;
using myApp.Views;

namespace myApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RegisterController : ControllerBase
    {
        private readonly IRegisterService _registerService;

        public RegisterController(IRegisterService registerService)
        {
            _registerService = registerService;
        }

        [HttpPost]
        public IActionResult Post([FromBody] StudentDTO record)
        {
            try
            {
                if (record == null)
                {
                    return BadRequest("Record data is null");
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var createdRecord = _registerService.AddRecord(record);
                if(createdRecord == null)
                {
                    return Conflict(new
                    {
                        Message = "Username already exists",
                        Suggestion = "Please choose a different username"
                    });
                }
                return CreatedAtAction(nameof(Post), new { id = createdRecord.StudentName }, createdRecord);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "Internal server error");
            }
        }

        //[HttpGet]
        //public IActionResult Get()
        //{
        //    var records = _libraryService.GetAllRecords();
        //    return Ok(records);
        //}

        [HttpGet("GetByUser")]
        public IActionResult GetByUser([FromQuery] string userName,string Password)
        {
            var record = _registerService.GetUserDetail(userName, Password);
            if (record == null)
            {
                return NotFound();
            }
            return Ok(record);
        }
        [HttpGet("GetDropownData")]
        public IActionResult GetDropownData()
        {
            try
            {
                var CompRecords = _registerService.GetCompRecords();
                var EmpRecords = _registerService.GetEmpRecords();
                return Ok(new
                {
                    CompRecords = CompRecords,
                    EmpRecords = EmpRecords
                });
            }
            catch(Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
            
        }
    }
}
