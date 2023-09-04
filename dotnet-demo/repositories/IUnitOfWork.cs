namespace dotnet_demo.repositories;

public interface IUnitOfWork
{
    Task SaveChangesAsync();
}