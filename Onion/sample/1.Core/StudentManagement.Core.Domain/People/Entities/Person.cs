using Zamin.Core.Domain.Entities;

namespace StudentManagement.Core.Domain.People.Entities
{
    public class Person : AggregateRoot<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
