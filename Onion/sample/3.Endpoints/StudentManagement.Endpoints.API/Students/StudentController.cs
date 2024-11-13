using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudentManagement.Core.RequestResponse.Students.Commands.Create;
using StudentManagement.Core.RequestResponse.Students.Commands.Delete;
using StudentManagement.Core.RequestResponse.Students.Commands.DeleteGraph;
using StudentManagement.Core.RequestResponse.Students.Commands.Update;
using StudentManagement.Core.RequestResponse.Students.Queries.GetById;
using System.Net;
using Zamin.EndPoints.Web.Controllers;

namespace StudentManagement.Endpoints.API.Students
{
    [Route("api/[controller]")]
    public class StudentController : BaseController
    {
        #region Commands
        [HttpPost("Create")]
        public async Task<IActionResult> CreateStudent([FromBody] CreateStudentCommand command) => await Create<CreateStudentCommand, Guid>(command);

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateStudent([FromBody] UpdateStudentCommand command) => await Edit(command);

        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteStudent([FromBody] DeleteStudentCommand command) => await Delete(command);

        [HttpDelete("DeleteGraph")]
        public async Task<IActionResult> DeleteGraphStudent([FromBody] DeleteGraphStudentCommand command) => await Delete(command);

        #endregion

        #region Queries
        [Authorize]
        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(GetStudentByIdQuery query) => await Query<GetStudentByIdQuery, StudentQr?>(query);
        #endregion

        #region Methods
        [HttpGet("/Clear")]
        public bool Clear()
        {
            GC.Collect(2);
            return true;
        }
        #endregion
    }
}
