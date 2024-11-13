using Zamin.Core.Domain.Events;

namespace StudentManagement.Core.Domain.Students.Events;

public record StudentCreated(Guid BusinessId,
    string Title,
    string Description,
    string StudentNumber,
    string NationalCode) : IDomainEvent;