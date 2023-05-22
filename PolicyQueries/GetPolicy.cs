using PolicyModels;

namespace PolicyQueries
{
    public class GetPolicy : IGetPolicy
    {
        private readonly PolicyDbContext _context;

        public GetPolicy(PolicyDbContext context)
        {
            _context = context;
        }

        public async Task<List<InsurancePolicy>> Handle(string placaVehiculo, string numeroPoliza)
        {
            try
            {
                return await _context.GetPolicies(placaVehiculo, numeroPoliza);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
