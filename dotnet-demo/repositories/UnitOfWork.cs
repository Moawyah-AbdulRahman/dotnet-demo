namespace dotnet_demo.repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly DemoDbContext _context;

    public UnitOfWork(DemoDbContext dbContext)
    {
        _context = dbContext;
    }

    public Task SaveChangesAsync()
    {
        return _context.SaveChangesAsync();
    }
}
