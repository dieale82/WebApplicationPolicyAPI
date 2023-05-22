using Microsoft.EntityFrameworkCore;
using PolicyModels;

namespace PolicyQueries
{
    public class PolicyDbContext : DbContext
    {
        public PolicyDbContext(DbContextOptions<PolicyDbContext> options) : base(options)
        {
        }

        public DbSet<InsurancePolicy> InsurancePolicies { get; set; }

        public async Task<List<InsurancePolicy>> GetPolicies(string placaVehiculo, string numeroPoliza)
        {
            var query = InsurancePolicies.AsQueryable();

            if (!string.IsNullOrEmpty(placaVehiculo))
            {
                query = query.Where(policy => policy.PlacaVehiculo == placaVehiculo);
            }

            if (!string.IsNullOrEmpty(numeroPoliza))
            {
                query = query.Where(policy => policy.NumeroPoliza == numeroPoliza);
            }

            return await query.ToListAsync();
        }
    }
}
