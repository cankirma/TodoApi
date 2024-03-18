using Application.Repositories.Todo;
using Persistence.Context;

namespace Persistence.Repositories.Todo;



public class TodoReadRepository:ReadRepository<Domain.Entities.Todo>, ITodoReadRepository
{
    public TodoReadRepository(AppDbContext db) : base(db)
    {
    }
}

public class TodoWriteRepository : WriteRepository<Domain.Entities.Todo>, ITodoWriteRepository
{
    public TodoWriteRepository(AppDbContext db) : base(db)
    {
    }
}