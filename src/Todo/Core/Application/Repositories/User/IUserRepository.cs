namespace Application.Repositories.User;

public interface IUserReadRepository : IReadRepository<Domain.Entities.User>
{
 
}

public interface IUserWriteRepository : IWriteRepository<Domain.Entities.User>
{
}