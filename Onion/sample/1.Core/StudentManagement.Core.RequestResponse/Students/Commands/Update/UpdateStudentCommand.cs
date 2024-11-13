
using Zamin.Core.RequestResponse.Commands;
using Zamin.Core.RequestResponse.Endpoints;

namespace StudentManagement.Core.RequestResponse.Students.Commands.Update;

public class UpdateStudentCommand : ICommand, IWebRequest
{
    public int Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string StudentNumber { get; set; } = string.Empty;
    public string NationalCode { get; set; } = string.Empty;

    public string Path => "/api/Student/Update";
}