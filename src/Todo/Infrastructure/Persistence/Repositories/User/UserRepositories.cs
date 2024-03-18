using Application.Repositories.User;
using Domain.Entities;
using Persistence.Context;

namespace Persistence.Repositories.User;


public class UserWriteRepository: WriteRepository<Domain.Entities.User>, IUserWriteRepository
{

    public UserWriteRepository(AppDbContext db) : base(db)
    {
    }

  
}

public class UserReadRepository: ReadRepository<Domain.Entities.User>, IUserReadRepository
{

    public UserReadRepository(AppDbContext db) : base(db)
    {
        
    }


}