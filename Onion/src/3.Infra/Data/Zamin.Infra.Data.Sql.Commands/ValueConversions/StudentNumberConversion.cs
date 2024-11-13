using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Zamin.Core.Domain.Toolkits.ValueObjects;

namespace Zamin.Infra.Data.Sql.Commands.ValueConversions
{
    public class StudentNumberConversion : ValueConverter<StudentNumber, string>
    {
        public StudentNumberConversion() : base(c => c.Value, c => StudentNumber.FromString(c))
        {

        }
    }
}
