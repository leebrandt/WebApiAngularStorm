using Microsoft.EntityFrameworkCore;
using WebApiAngularStorm.Models;

namespace WebApiAngularStorm.Services
{
  public class ApiContext : DbContext
  {
    public ApiContext (DbContextOptions<ApiContext> options) : base(options){ }

    public DbSet<Todo> Todos { get; set; }
  }
}