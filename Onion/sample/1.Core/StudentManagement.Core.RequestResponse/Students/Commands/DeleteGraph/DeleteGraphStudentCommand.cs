using Zamin.Core.RequestResponse.Commands;
using Zamin.Core.RequestResponse.Endpoints;

namespace StudentManagement.Core.RequestResponse.Students.Commands.DeleteGraph;

public class DeleteGraphStudentCommand : ICommand, IWebRequest
{
    public int Id { get; set; }

    public string Path => "/api/Student/DeleteGraph";
}