using Zamin.Core.RequestResponse.Endpoints;
using Zamin.Core.RequestResponse.Queries;

namespace StudentManagement.Core.RequestResponse.Students.Queries.GetById;

public class GetStudentByIdQuery : IQuery<StudentQr?>, IWebRequest
{
    public int StudentId { get; set; }

    public string Path => "/api/Student/GetById";
}