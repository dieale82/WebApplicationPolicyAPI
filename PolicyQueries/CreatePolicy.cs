using Amazon.Auth.AccessControlPolicy;
using PolicyModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolicyQueries
{
    public class CreatePolicy : ICreatePolicy
    {
        private readonly PolicyDbContext _context;

        public CreatePolicy(PolicyDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(InsurancePolicy insurancePolicy)
        {
            try
            {
                if (!CheckValidInsuranceDate(insurancePolicy))
                {
                    throw new Exception("Invalid Insurance Date");
                }

                _context.InsurancePolicies.Add(insurancePolicy);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private bool CheckValidInsuranceDate(InsurancePolicy insurancePolicy)
        {
            if (insurancePolicy.FechaPoliza.Date < System.DateTime.Today.Date)             
                return false;
            else
                return true;
            
        }
    }
}
