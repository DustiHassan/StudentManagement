using Zamin.Core.Domain.Exceptions;
using Zamin.Core.Domain.ValueObjects;
using Zamin.Utilities.Extensions;

namespace Zamin.Core.Domain.Toolkits.ValueObjects;
public class StudentNumber : BaseValueObject<StudentNumber>
{
    #region Properties
    public string Value { get; private set; }
    #endregion

    #region Constructors and Factories
    public static StudentNumber FromString(string value) => new(value);
    public StudentNumber(string value)
    {
        if (!value.IsStudentNumber())
        {
            throw new InvalidValueObjectStateException("ValidationErrorStringFormat", nameof(StudentNumber));
        }

        Value = value;
    }
    private StudentNumber()
    {

    }
    #endregion

    #region Equality Check
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    #endregion

    #region Operator Overloading

    public static explicit operator string(StudentNumber title) => title.Value;
    public static implicit operator StudentNumber(string value) => new(value);
    #endregion

    #region Methods
    public override string ToString() => Value;

    #endregion

}

