using PolicyModels;

namespace PolicyQueries
{
    public interface IGetPolicy
    {
        Task<List<InsurancePolicy>> Handle(string placaVehiculo, string numeroPoliza);
    }
}