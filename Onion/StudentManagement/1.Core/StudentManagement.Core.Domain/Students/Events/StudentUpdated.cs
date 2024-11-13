using Zamin.Core.Domain.Events;

namespace StudentManagement.Core.Domain.Students.Events;

public record StudentUpdated(Guid BusinessId,
    string FirsName,
    string LastName,
    string StudentNumber,
    string NationalCode) : IDomainEvent;
