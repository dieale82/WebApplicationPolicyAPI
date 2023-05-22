using PolicyModels;

namespace PolicyQueries
{
    public interface ICreatePolicy
    {
        Task<bool> Handle(InsurancePolicy insurancePolicy);
    }
}