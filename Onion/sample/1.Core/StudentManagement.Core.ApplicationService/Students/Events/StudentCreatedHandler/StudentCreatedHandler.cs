using Microsoft.Extensions.Logging;
using StudentManagement.Core.Contracts.People;
using StudentManagement.Core.Domain.Students.Events;
using StudentManagement.Core.Domain.People.Entities;
using Zamin.Core.Contracts.ApplicationServices.Events;


namespace StudentManagement.Core.ApplicationService.Students.Events.StudentCreatedHandler;
public class StudentCreatedHandler : IDomainEventHandler<StudentCreated>
{
    private readonly ILogger<StudentCreatedHandler> _logger;
    private readonly IPersonCommandRepository _personCommandRepository;

    public StudentCreatedHandler(ILogger<StudentCreatedHandler> logger,
                                IPersonCommandRepository personCommandRepository)
    {
        _logger = logger;
        _personCommandRepository = personCommandRepository;
    }
    public async Task Handle(StudentCreated Event)
    {
        try
        {
            Person person = new Person
            {
                FirstName = DateTime.Now.ToString(),
                LastName = DateTime.Now.ToLongTimeString(),
            };
            await _personCommandRepository.InsertAsync(person);
            await _personCommandRepository.CommitAsync();

            _logger.LogInformation("Handeled {Event} in StudentCreatedHandler", Event.GetType().Name);
            await Task.CompletedTask;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error {Event} in StudentCreatedHandler", Event.GetType().Name);
            throw;
        }

    }
}
