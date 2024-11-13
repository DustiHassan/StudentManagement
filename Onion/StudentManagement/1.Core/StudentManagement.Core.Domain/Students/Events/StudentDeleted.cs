using Zamin.Core.Domain.Events;

namespace StudentManagement.Core.Domain.Students.Events;

public record StudentDeleted(Guid BusinessId) : IDomainEvent;
