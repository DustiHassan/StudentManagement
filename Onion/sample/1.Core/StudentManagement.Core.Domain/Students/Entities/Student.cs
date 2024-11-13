using StudentManagement.Core.Domain.Students.Events;
using Zamin.Core.Domain.Entities;
using Zamin.Core.Domain.Exceptions;
using Zamin.Core.Domain.Toolkits.ValueObjects;
using Zamin.Core.Domain.ValueObjects;

namespace StudentManagement.Core.Domain.Students.Entities;

public class Student : AggregateRoot<int>
{
    #region Properties
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public NationalCode NationalCode { get; private set; }
    public StudentNumber StudentNumber { get; private set; }
    #endregion

    #region Constructors
    private Student()
    {

    }
    public Student(string firstName, string lastName, StudentNumber studentNumber, NationalCode nationalCode)
    {
        FirstName = firstName;
        LastName = lastName;
        StudentNumber = studentNumber;
        NationalCode = nationalCode;
        AddEvent(new StudentCreated(BusinessId.Value, FirstName, LastName, StudentNumber.Value, NationalCode.Value));
    }
    #endregion

    #region Commands
    public static Student Create(string firstName, string lastName, StudentNumber studentNumber, NationalCode nationalCode) => new(firstName, lastName, studentNumber, nationalCode);

    public void Update(string firstName, string lastName, StudentNumber studentNumber, NationalCode nationalCode)
    {
        FirstName = firstName;
        LastName = lastName;
        StudentNumber = studentNumber;
        NationalCode = nationalCode;

        AddEvent(new StudentUpdated(BusinessId.Value, FirstName, LastName, StudentNumber.Value, NationalCode.Value));
    }
    public void Delete()
    {
        AddEvent(new StudentDeleted(BusinessId.Value));
    }

    public void DeleteGraph()
    {
        AddEvent(new StudentDeleted(BusinessId.Value));

    }

    #endregion
}
