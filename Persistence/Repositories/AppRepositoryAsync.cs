using Application.Interfaces;
using Ardalis.Specification;
using Ardalis.Specification.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class AppRepositoryAsync<T> : RepositoryBase<T>, IRepositoryAsync<T>, IReadRepositoryAsync<T> where T : class
{
    private readonly BancosDbContext _dbContext;
    
    public AppRepositoryAsync(BancosDbContext dbContext) : base(dbContext)
    {
    }

    public AppRepositoryAsync(BancosDbContext dbContext, ISpecificationEvaluator specificationEvaluator) : base(dbContext, specificationEvaluator)
    {
    }
}