using System;
using EShop.Data.Abstract;
using Microsoft.Extensions.DependencyInjection;

namespace EShop.Data;

public class UnitOfWork : IUnitOfWork
{
    private readonly EShopDbContext _dbContext;
    private readonly IServiceProvider _serviceProvider;
    public void Dispose()
    {
        _dbContext.Dispose();
    }

    public IGenericRepository<TEntity> GetRepository<TEntity>() where TEntity : class
    {
        var repository = _serviceProvider.GetRequiredService<IGenericRepository<TEntity>>();
        return repository;
    }

    public int Save()
    {
        return _dbContext.SaveChanges();
    }

    public async Task<int> SaveAsync()
    {
        return await _dbContext.SaveChangesAsync();

    }
}
