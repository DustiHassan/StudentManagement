﻿namespace StudentManagement.Core.RequestResponse.Students.Queries.GetById;

public class StudentQr
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string StudentNumber { get; set; }
    public string NationalCode { get; set; }
}
