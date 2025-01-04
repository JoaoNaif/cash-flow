using CashFlow.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace CashFlow.Infrastructure.DataAccess;

internal class CashFlowDbContext : DbContext
{
    public CashFlowDbContext(DbContextOptions options) : base(options) { }
    
    // O correto deve ser (Expenses), porém já tinha feito no db por isso está (expenses)
    public DbSet<Expense> expenses { get; set; }
}