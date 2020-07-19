using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ProductCatalog.Entities.TestData
{
    public interface ISeeder<in TContext>
        where TContext : DbContext
    {
        void Seed(TContext context);
    }
}