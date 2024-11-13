using StudentManagement.Core.RequestResponse.Students.Queries.GetById;
using Zamin.Core.RequestResponse.Endpoints;
using Zamin.Core.RequestResponse.Queries;

namespace StudentManagement.Core.RequestResponse.Students.Queries.GetAll;

public class GetAllStudentQuery : IQuery<IEnumerable<StudentQr?>>, IWebRequest
{
    public int? IdFilter { get; set; }
    public string? FirstNameFilter { get; set; }
    public string? LastNameFilter { get; set; }
    public string? StudentNumberFilter { get; set; }
    public string? NationalCodeFilter { get; set; }

    public string Path => "/api/Student/GetAll";
}